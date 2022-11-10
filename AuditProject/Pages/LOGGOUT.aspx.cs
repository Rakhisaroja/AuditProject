using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class LOGGOUT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            ClassLogin objLogin = new ClassLogin();
            ClassGlobal objGloabal = new ClassGlobal();
            ArrayList Arrin = new ArrayList();

            Arrin.Add(Convert.ToInt64(Session["UserID"].ToString()));   //@numUserId
            Arrin.Add(Convert.ToInt64(Session["NumSessionID"])); 
           // Arrin.Add(Session.SessionID);                               // @numSessionID
            Arrin.Add(1);                                     //@tnyStatus

            if (Session["RoleID"].ToString() != "1")
            {
                Arrin.Add(Convert.ToInt32(Session["LBID"].ToString()));
            }
            else
            {
                Arrin.Add(5000);
            }
            //objGloabal.UserLogID = objLogin.SaveLogout(Arrin);
            objGloabal.UserLogID = objLogin.SaveLogout(Arrin);
            Session["NumSessionID"] = null;
            Arrin.Clear();

            //Session.Clear();
            Response.Redirect("Login.aspx");
            //Response.Redirect("Default2.aspx");
        }
        //Session.Clear();
        //Response.Redirect("Default2.aspx");
        if (Request.QueryString["mode"].ToString() == "logout")
        {
            lblmsg.Text = "You have been Successfully logged out";
        }
        if (Request.QueryString["mode"].ToString() == "session")
        {
            lblmsg.Text = "User's Session Expired";// mode session page LOGGOUT";
        }
        lmsg.Text = "User's Session Expired";
       
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
