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

public partial class Pages_FrontOffice_Urban : System.Web.UI.Page
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
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }


    }
    public void ValueAssign()
    {

        ddlseatAud.SelectedValue = ddlseat.SelectedValue;
        txtseatdetAud.Text = txtseatdet.Text;


        ddlcounterAud.SelectedValue = ddlcounter.SelectedValue;
        txtcounterAud.Text=txtcounter.Text;


        ddlthapalAud.SelectedValue = ddlthapal.SelectedValue;
        txttapaldetAud.Text = txttapaldet.Text;


        ddlrampAud.SelectedValue = ddlramp.SelectedValue;
        txtrampAud.Text = txtramp.Text;


        ddltockenAud.SelectedValue = ddltocken.SelectedValue;
        txttockenAud.Text = txttocken.Text;


        ddldrinkwtrAud.SelectedValue = ddldrinkwtr.SelectedValue;
        txtdrnkwtrAud.Text = txtdrnkwtr.Text;


        ddltoiletAud.Text = ddltoilet.SelectedValue;
        txttoiletAud.Text = txttoilet.Text;


        ddlmagazineAud.SelectedValue = ddlmagazine.SelectedValue;
        txtmagazineAud.Text = txtmagazine.Text;


        ddltelvnAud.SelectedValue = ddltelvn.SelectedValue;
        txttelvnAud.Text = txttelvn.Text;


        ddlapplnformAud.SelectedValue = ddlapplnform.SelectedValue;
        txtapplformAud.Text = txtapplform.Text;

       
    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            ddlseatAud.Enabled=false;
            ddlseat.Enabled = true;
            txtseatdetAud.ReadOnly=true;
            txtseatdet.ReadOnly=false;


            ddlcounterAud.Enabled=false;
            ddlcounter.Enabled=true;
            txtcounterAud.ReadOnly = true;
            txtcounter.ReadOnly = false;


            ddlthapalAud.Enabled=false;
             ddlthapal.Enabled=true;
             txttapaldetAud.ReadOnly = true;
             txttapaldet.ReadOnly = false;


            ddlrampAud.Enabled=false;
            ddlramp.Enabled=true;
            txtrampAud.ReadOnly = true;
            txtramp.ReadOnly = false;


            ddltockenAud.Enabled=false;
             ddltocken.Enabled=true;
            txttockenAud.ReadOnly = true;
            txttocken.ReadOnly = false;


            ddldrinkwtrAud.Enabled=false;
             ddldrinkwtr.Enabled=true;
            txtdrnkwtrAud.ReadOnly = true;
             txtdrnkwtr.ReadOnly = false;

            ddltoiletAud.Enabled=false;
            ddltoilet.Enabled=true;
            txttoiletAud.ReadOnly = true;
            txttoilet.ReadOnly = false;


            ddlmagazineAud.Enabled=false;
            ddlmagazine.Enabled=true;
            txtmagazineAud.ReadOnly = true;
            txtmagazine.ReadOnly = false;


            ddltelvnAud.Enabled=false;
            ddltelvn.Enabled=true;
            txttelvnAud.ReadOnly = true;
            txttelvn.ReadOnly = false;


            ddlapplnformAud.Enabled=false;
             ddlapplnform.Enabled=true;
             txtapplformAud.ReadOnly = true;
             txtapplform.ReadOnly = false;

        }
        else
        {


            ddlseatAud.Enabled = true;
            ddlseat.Enabled = false;
            txtseatdetAud.ReadOnly = false;
            txtseatdet.ReadOnly = true;


            ddlcounterAud.Enabled = true;
            ddlcounter.Enabled = false;
            txtcounterAud.ReadOnly = false;
            txtcounter.ReadOnly = true;


            ddlthapalAud.Enabled = true;
            ddlthapal.Enabled = false;
            txttapaldetAud.ReadOnly = false;
            txttapaldet.ReadOnly = true;


            ddlrampAud.Enabled = true;
            ddlramp.Enabled = false;
            txtrampAud.ReadOnly = false;
            txtramp.ReadOnly = true;


            ddltockenAud.Enabled = true;
            ddltocken.Enabled = true;
            txttockenAud.ReadOnly = true;
            txttocken.ReadOnly = true;


            ddldrinkwtrAud.Enabled = true;
            ddldrinkwtr.Enabled = false;
            txtdrnkwtrAud.ReadOnly = false;
            txtdrnkwtr.ReadOnly = true;

            ddltoiletAud.Enabled = true;
            ddltoilet.Enabled = false;
            txttoiletAud.ReadOnly = false;
            txttoilet.ReadOnly = true;


            ddlmagazineAud.Enabled = true;
            ddlmagazine.Enabled = false;
            txtmagazineAud.ReadOnly = false;
            txtmagazine.ReadOnly = true;


            ddltelvnAud.Enabled = true;
            ddltelvn.Enabled = false;
            txttelvnAud.ReadOnly = false;
            txttelvn.ReadOnly = true;


            ddlapplnformAud.Enabled = true;
            ddlapplnform.Enabled = false;
            txtapplformAud.ReadOnly = false;
            txtapplform.ReadOnly = true;



           
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_frontoffice_Urban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {

            ddlcounter.SelectedIndex =Convert.ToInt32(dsFill.Tables[0].Rows[0][0]);
            txtcounter.Text = dsFill.Tables[0].Rows[0][1].ToString();


            ddlcounterAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][2]);
            txtcounterAud.Text = dsFill.Tables[0].Rows[0][3].ToString();
         

            //******************************************************************


            ddlthapal.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][4]);
            txttapaldet.Text = dsFill.Tables[0].Rows[0][5].ToString();


            ddlthapalAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][6]);
            txttapaldetAud.Text = dsFill.Tables[0].Rows[0][7].ToString();
         

            //***********************************************



            ddlseat.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][8]);
            txtseatdet.Text = dsFill.Tables[0].Rows[0][9].ToString();


            ddlseatAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][10]);
            txtseatdetAud.Text = dsFill.Tables[0].Rows[0][11].ToString();
         
            //*********************************************************


            ddlramp.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][12]);
            txtramp.Text = dsFill.Tables[0].Rows[0][13].ToString();


            ddlrampAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][14]);
            txtrampAud.Text = dsFill.Tables[0].Rows[0][15].ToString();

            //*********************************************************


            ddltocken.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][16]);
            txttocken.Text = dsFill.Tables[0].Rows[0][17].ToString();


            ddltockenAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][18]);
            txttockenAud.Text = dsFill.Tables[0].Rows[0][19].ToString();



            //*********************************************************


            ddldrinkwtr.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][20]);
            txtdrnkwtr.Text = dsFill.Tables[0].Rows[0][21].ToString();


            ddldrinkwtrAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][22]);
            txtdrnkwtrAud.Text = dsFill.Tables[0].Rows[0][23].ToString();



            //*********************************************************


            ddltoilet.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][24]);
            txttoilet.Text = dsFill.Tables[0].Rows[0][25].ToString();


            ddltoiletAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][26]);
            txttoiletAud.Text = dsFill.Tables[0].Rows[0][27].ToString();


            //*********************************************************


            ddlmagazine.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][28]);
            txtmagazine.Text = dsFill.Tables[0].Rows[0][29].ToString();


            ddlmagazineAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][30]);
            txtmagazineAud.Text = dsFill.Tables[0].Rows[0][31].ToString();

            //RAKHI 21.05.2019
            //*********************************************************


            ddltelvn.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][32]);
            txttelvn.Text = dsFill.Tables[0].Rows[0][33].ToString();


            ddltelvnAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][34]);
            txttelvnAud.Text = dsFill.Tables[0].Rows[0][35].ToString();

            //*********************************************************


            ddlapplnform.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][36]);
            txtapplform.Text = dsFill.Tables[0].Rows[0][37].ToString();


            ddlapplnformAud.SelectedIndex = Convert.ToInt32(dsFill.Tables[0].Rows[0][38]);
            txtapplformAud.Text = dsFill.Tables[0].Rows[0][39].ToString();

        }
        SetEditable();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        Save_Data();  
        Filldata();
    }
    
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

        if (ddlcounter.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlcounter.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtcounter.Text != "")
        {
            arrIn.Add(txtcounter.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }
        //****************************************
        if (ddlcounterAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlcounterAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtcounterAud.Text != "")
        {
            arrIn.Add(txtcounterAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }
        //****************************************

        if (ddlthapal.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlthapal.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttapaldet.Text != "")
        {
            arrIn.Add(txttapaldet.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }
        //****************************************

        if (ddlthapalAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlthapalAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttapaldetAud.Text != "")
        {
            arrIn.Add(txttapaldetAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }
        //****************************************

        if (ddlseat.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlseat.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtseatdet.Text != "")
        {
            arrIn.Add(txtseatdet.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }
        //****************************************

        if (ddlseatAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlseatAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtseatdetAud.Text != "")
        {
            arrIn.Add(txtseatdetAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        //****************************************

        if (ddlramp.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlramp.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtramp.Text != "")
        {
            arrIn.Add(txtramp.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }

        //****************************************

        if (ddlrampAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlrampAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtrampAud.Text != "")
        {
            arrIn.Add(txtrampAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        //****************************************

        if (ddltocken.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltocken.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttocken.Text != "")
        {
            arrIn.Add(txttocken.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        //****************************************

        if (ddltockenAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltockenAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttockenAud.Text != "")
        {
            arrIn.Add(txttockenAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        //****************************************

        if (ddldrinkwtr.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddldrinkwtr.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtdrnkwtr.Text != "")
        {
            arrIn.Add(txtdrnkwtr.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }

        //****************************************

        if (ddldrinkwtrAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddldrinkwtrAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtdrnkwtrAud.Text != "")
        {
            arrIn.Add(txtdrnkwtrAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }


        //****************************************

        if (ddltoilet.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltoilet.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttoilet.Text != "")
        {
            arrIn.Add(txttoilet.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }


        //****************************************

        if (ddltoiletAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltoiletAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttoiletAud.Text != "")
        {
            arrIn.Add(txttoiletAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }

        //****************************************

        if (ddlmagazine.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlmagazine.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtmagazine.Text != "")
        {
            arrIn.Add(txtmagazine.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }



        //****************************************

        if (ddlmagazineAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlmagazineAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtmagazineAud.Text != "")
        {
            arrIn.Add(txtmagazineAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }

        //****************************************

        if (ddltelvn.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltelvn.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttelvn.Text != "")
        {
            arrIn.Add(txttelvn.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);


        }


        //****************************************

        if (ddltelvnAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddltelvnAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txttelvnAud.Text != "")
        {
            arrIn.Add(txttelvnAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        //****************************************

        if (ddlapplnform.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlapplnform.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtapplform.Text != "")
        {
            arrIn.Add(txtapplform.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }



        //****************************************

        if (ddlapplnformAud.SelectedIndex > 0)
        {

            arrIn.Add(Convert.ToInt32(ddlapplnformAud.SelectedValue.ToString()));

        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        if (txtapplformAud.Text != "")
        {
            arrIn.Add(txtapplformAud.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);

        }


        
        arrIn.Add(Convert.ToInt32(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 



        arrIn.Add(1);
        int row = objcomm.update("SP_tb_frontoffice_Urban_IU", arrIn);

        if (row > 0)
        {
            
            
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberWardDetails_Urban.aspx");
        // Response.Redirect("AgricultureDetails.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinanceOtherCommittees_Urban.aspx");
    }
   
  
   
    
}