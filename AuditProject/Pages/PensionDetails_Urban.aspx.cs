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
using AuditClassLibrary;
public partial class Pages_PensionDetails_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            chkStatus();
            Filldata();
        }
       
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4") 
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                Button1.Enabled = false;
            }
            else
            {

                Button1.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }


    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptPension.Items.Count; i++)
        {
            TextBox intapplicationcount = rptPension.Items[i].FindControl("intapplicationcount") as TextBox;
            TextBox intapprovedwithintimelimit = rptPension.Items[i].FindControl("intapprovedwithintimelimit") as TextBox;
            TextBox intapprovedaftertimelimit = rptPension.Items[i].FindControl("intapprovedaftertimelimit") as TextBox;
            TextBox intrejected = rptPension.Items[i].FindControl("intrejected") as TextBox;

            TextBox intapplicationcountaudited = rptPension.Items[i].FindControl("intapplicationcountaudited") as TextBox;
            TextBox intapprovedwithintimelimitaudited = rptPension.Items[i].FindControl("intapprovedwithintimelimitaudited") as TextBox;
            TextBox intapprovedaftertimelimitaudited = rptPension.Items[i].FindControl("intapprovedaftertimelimitaudited") as TextBox;
            TextBox intrejectedaudited = rptPension.Items[i].FindControl("intrejectedaudited") as TextBox;

            intapplicationcountaudited.Text =intapplicationcount.Text;
            intapprovedwithintimelimitaudited.Text =intapprovedwithintimelimit.Text;

            intapprovedaftertimelimitaudited.Text = intapprovedaftertimelimit.Text;
            intrejectedaudited.Text = intrejected.Text;

        }

    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptPension.Items.Count; i++)
            {
                TextBox intapplicationcount = rptPension.Items[i].FindControl("intapplicationcount") as TextBox;
                TextBox intapprovedwithintimelimit = rptPension.Items[i].FindControl("intapprovedwithintimelimit") as TextBox;
                TextBox intapprovedaftertimelimit = rptPension.Items[i].FindControl("intapprovedaftertimelimit") as TextBox;
                TextBox intrejected = rptPension.Items[i].FindControl("intrejected") as TextBox;

                intapplicationcount.ReadOnly = false;
                intapprovedwithintimelimit.ReadOnly = false;

                intapprovedaftertimelimit.ReadOnly = false;
                intrejected.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < rptPension.Items.Count; i++)
            {
                TextBox intapplicationcountaudited = rptPension.Items[i].FindControl("intapplicationcountaudited") as TextBox;
                TextBox intapprovedwithintimelimitaudited = rptPension.Items[i].FindControl("intapprovedwithintimelimitaudited") as TextBox;
                TextBox intapprovedaftertimelimitaudited = rptPension.Items[i].FindControl("intapprovedaftertimelimitaudited") as TextBox;
                TextBox intrejectedaudited = rptPension.Items[i].FindControl("intrejectedaudited") as TextBox;

                intapplicationcountaudited.ReadOnly = false;
                intapprovedwithintimelimitaudited.ReadOnly = false;

                intapprovedaftertimelimitaudited.ReadOnly = false;
                intrejectedaudited.ReadOnly = false;

            }
        }
    }


    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_pensionUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptPension.DataSource = dsFill;
            rptPension.DataBind();

          
        }
        SetEditable();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveData();
        Filldata();
    }
    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < rptPension.Items.Count; i++)
        {
            Label lblNumId = rptPension.Items[i].FindControl("lblNumId") as Label;
            if (lblNumId.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblNumId.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
            Label intpensionid = rptPension.Items[i].FindControl("intpensionid") as Label;
            if (intpensionid.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intpensionid.Text));
            }



            TextBox intapplicationcount = rptPension.Items[i].FindControl("intapplicationcount") as TextBox;
            if (intapplicationcount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapplicationcount.Text));
            }

            TextBox intapprovedwithintimelimit = rptPension.Items[i].FindControl("intapprovedwithintimelimit") as TextBox;
            if (intapprovedwithintimelimit.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapprovedwithintimelimit.Text));
            }

            TextBox intapprovedaftertimelimit = rptPension.Items[i].FindControl("intapprovedaftertimelimit") as TextBox;
            if (intapprovedaftertimelimit.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapprovedaftertimelimit.Text));
            }
            TextBox intrejected = rptPension.Items[i].FindControl("intrejected") as TextBox;
            if (intrejected.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intrejected.Text));
            }

            TextBox intapplicationcountaudited = rptPension.Items[i].FindControl("intapplicationcountaudited") as TextBox;
            if (intapplicationcountaudited.Text == "")
            {
                arrIn.Add(DBNull.Value);
              
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapplicationcountaudited.Text));
            }



            TextBox intapprovedwithintimelimitaudited = rptPension.Items[i].FindControl("intapprovedwithintimelimitaudited") as TextBox;
            if (intapprovedwithintimelimitaudited.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
               
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapprovedwithintimelimitaudited.Text));
            }
            TextBox intapprovedaftertimelimitaudited = rptPension.Items[i].FindControl("intapprovedaftertimelimitaudited") as TextBox;
            if (intapprovedaftertimelimitaudited.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intapprovedaftertimelimitaudited.Text));
            }

            TextBox intrejectedaudited = rptPension.Items[i].FindControl("intrejectedaudited") as TextBox;
            if (intrejectedaudited.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intrejectedaudited.Text));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_pensionUrban_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration_Urban.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingDetails_Urban.aspx");
    }
}
