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

public partial class Pages_PublicShelter_Urban : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
            chkStatus();
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

    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        if (Validation() == true)
        {
            savenew();
        }
    }

    void fillData()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        //arrIn.Add(2);//Finance
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_ShelterUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txthomelessno.Text = ds.Tables[0].Rows[0][1].ToString();
            txtlandless.Text = ds.Tables[0].Rows[0][2].ToString();
            txtpoorrelief.Text = ds.Tables[0].Rows[0][3].ToString();
            txtnoofbeneficiary.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAudhomelessno.Text = ds.Tables[0].Rows[0][5].ToString();
            txtAudlandless.Text = ds.Tables[0].Rows[0][6].ToString();

            txtAudpoorrelief.Text = ds.Tables[0].Rows[0][7].ToString();
            txtAudnoofbeneficiary.Text = ds.Tables[0].Rows[0][8].ToString();
           

           

        }
        disabletextbox();
    }
    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {



            
                txthomelessno.ReadOnly = false;   
                txtlandless.ReadOnly = false;  
                txtpoorrelief.ReadOnly = false;        
                txtnoofbeneficiary.ReadOnly = false;

            
              txtAudhomelessno.ReadOnly = true;
              txtAudpoorrelief.ReadOnly = true;
              txtAudnoofbeneficiary.ReadOnly = true;
              txtAudlandless.ReadOnly = true;




        }
        else
        {
            txthomelessno.ReadOnly = true;
            txtlandless.ReadOnly = true;
            txtpoorrelief.ReadOnly = true;
            txtnoofbeneficiary.ReadOnly = true;




            txtAudhomelessno.ReadOnly = false;
            txtAudpoorrelief.ReadOnly = false;
            txtAudnoofbeneficiary.ReadOnly = false;
            txtAudlandless.ReadOnly = false;


        }
    }

    public void savenew()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();


        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        if (txthomelessno.Text!= "")
        {
            arrIn.Add(Convert.ToInt32(txthomelessno.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtAudhomelessno.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAudhomelessno.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        if (txtlandless.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtlandless.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtAudlandless.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAudlandless.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }





        if (txtpoorrelief.Text != "")
        {
            arrIn.Add(txtpoorrelief.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtAudpoorrelief.Text != "")
        {
            arrIn.Add(txtAudpoorrelief.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtnoofbeneficiary.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofbeneficiary.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtAudnoofbeneficiary.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAudnoofbeneficiary.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////

        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_ShelterUrban_IU", arrIn);
        GlobalClass gblObj = new GlobalClass();
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
        arrIn.Clear();
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicWorkingGroup_Urban.aspx");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicWorksHouseConstruction_Urban.aspx");
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        //if (ddlWorkingGroup.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
        //    ddlWorkingGroup.Focus();
        //    gblObj.setFocus(ddlWorkingGroup, this);
        //    return false;
        //}
        //else if (txtConveneor.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the Convener') ;", true);
        //    txtConveneor.Focus();
        //    gblObj.setFocus(txtConveneor, this);
        //    return false;
        //}
        //else if (txtnoofMeeting.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter no of Meeting') ;", true);
        //    txtnoofMeeting.Focus();
        //    gblObj.setFocus(txtnoofMeeting, this);
        //    return false;
        //}
        //else if (ddlStatusreport.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
        //    ddlStatusreport.Focus();
        //    gblObj.setFocus(ddlStatusreport, this);
        //    return false;
        //}
        //else  if (ddlWorkingGroup.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
        //    ddlWardNo.Focus();
        //    gblObj.setFocus(ddlWardNo, this);
        //    return false;
        //}

        return true;
    }
    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            txtAudhomelessno.Text = txthomelessno.Text;
            txtAudlandless.Text = txtlandless.Text;
            txtAudpoorrelief.Text = txtpoorrelief.Text;
            txtAudnoofbeneficiary.Text = txtnoofbeneficiary.Text;

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (Validation() == true)
        //{
        ValueAssign();
            savenew();
            fillData();
        //}
    }
}
