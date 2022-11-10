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

public partial class Pages_CleaningList : System.Web.UI.Page
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
        ds = objcom.FillData("[SP_tb_solidwastemanagement_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtMechPlantexist.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBiogasexist.Text = ds.Tables[0].Rows[0][2].ToString();
            txtVerni.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMechaNew.Text = ds.Tables[0].Rows[0][4].ToString();
            txtBiogasNew.Text = ds.Tables[0].Rows[0][5].ToString();
            txtVemiNew.Text = ds.Tables[0].Rows[0][6].ToString();
            if (ds.Tables[0].Rows[0][7].ToString() == "")
            {
                ddlGreen.SelectedIndex = 0;
            }
            else
            {
                ddlGreen.SelectedValue = ds.Tables[0].Rows[0][7].ToString();
            }
            //ddlGreen.SelectedValue = ds.Tables[0].Rows[0][7].ToString();
            if (ds.Tables[0].Rows[0][8].ToString() == "")
            {
                ddlSanitary.SelectedIndex = 0;
            }
            else
            {
                ddlSanitary.SelectedValue = ds.Tables[0].Rows[0][8].ToString();
            }
            //ddlSanitary.SelectedValue = ds.Tables[0].Rows[0][8].ToString();
            txtnoplanAmt.Text = ds.Tables[0].Rows[0][9].ToString();
            txtByProdDet.Text = ds.Tables[0].Rows[0][10].ToString();
            txtByProdAmt.Text = ds.Tables[0].Rows[0][11].ToString();


            txtAuditMechPlantexist.Text = ds.Tables[0].Rows[0][12].ToString();
            txtAuditBiogasexist.Text = ds.Tables[0].Rows[0][13].ToString();
            txtAuditvermiexist.Text = ds.Tables[0].Rows[0][14].ToString();
            txtAuditMechaNew.Text = ds.Tables[0].Rows[0][15].ToString();
            txtAuditBiogasNew.Text = ds.Tables[0].Rows[0][16].ToString();
            txtAuditVemiNew.Text = ds.Tables[0].Rows[0][17].ToString();
            if (ds.Tables[0].Rows[0][18].ToString() == "")
            {
                ddlAuditGreen.SelectedIndex = 0;
            }
            else
            {
                ddlAuditGreen.SelectedValue = ds.Tables[0].Rows[0][18].ToString();
            }
            if (ds.Tables[0].Rows[0][19].ToString() == "")
            {
                ddlAuditSanitary.SelectedIndex =0;
            }
            else
            {
                ddlAuditSanitary.SelectedValue = ds.Tables[0].Rows[0][19].ToString();
            }
            txtAuditnoplanAmt.Text = ds.Tables[0].Rows[0][20].ToString();
            txtAuditByProdDet.Text = ds.Tables[0].Rows[0][21].ToString();
            txtAuditByProdAmt.Text = ds.Tables[0].Rows[0][22].ToString();

           

        }
        disabletextbox();
    }
    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtMechPlantexist.ReadOnly = false;
            txtBiogasexist.ReadOnly = false;
            txtVerni.ReadOnly = false;
            txtMechaNew.ReadOnly = false;
            txtBiogasNew.ReadOnly = false;
            txtVemiNew.ReadOnly = false;
            ddlGreen.Enabled = true;
            ddlSanitary.Enabled = true;
            txtnoplanAmt.ReadOnly = false;
            txtByProdDet.ReadOnly = false;
            txtByProdAmt.ReadOnly = false;

            txtAuditMechPlantexist.ReadOnly = true;
            txtAuditBiogasexist.ReadOnly = true;
            txtAuditvermiexist.ReadOnly = true;
            txtAuditMechaNew.ReadOnly = true;
            txtAuditBiogasNew.ReadOnly = true;
            txtAuditVemiNew.ReadOnly = true;
            ddlAuditGreen.Enabled = false;
            ddlAuditSanitary.Enabled = false;
            txtAuditnoplanAmt.ReadOnly = true;
            txtAuditByProdDet.ReadOnly = true;
            txtAuditByProdAmt.ReadOnly = true;


        }
        else
        {
            txtMechPlantexist.ReadOnly = true;
            txtBiogasexist.ReadOnly = true;
            txtVerni.ReadOnly = true;
            txtMechaNew.ReadOnly = true;
            txtBiogasNew.ReadOnly = true;
            txtVemiNew.ReadOnly = true;
            ddlGreen.Enabled = false;
            ddlSanitary.Enabled = false;
            txtnoplanAmt.ReadOnly = true;
            txtByProdDet.ReadOnly = true;
            txtByProdAmt.ReadOnly = true;

            txtAuditMechPlantexist.ReadOnly = false;
            txtAuditBiogasexist.ReadOnly = false;
            txtAuditvermiexist.ReadOnly = false;
            txtAuditMechaNew.ReadOnly = false;
            txtAuditBiogasNew.ReadOnly = false;
            txtAuditVemiNew.ReadOnly = false;
            ddlAuditGreen.Enabled = true;
            ddlAuditSanitary.Enabled = true;
            txtAuditnoplanAmt.ReadOnly = false;
            txtAuditByProdDet.ReadOnly = false;
            txtAuditByProdAmt.ReadOnly = false;

        }
    }

    public void savenew()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();


        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        if (txtMechPlantexist.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtMechPlantexist.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditMechPlantexist.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditMechPlantexist.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtBiogasexist.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtBiogasexist.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditBiogasexist.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditBiogasexist.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtVerni.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtVerni.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditvermiexist.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditvermiexist.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtMechaNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtMechaNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditMechaNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditMechaNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtBiogasNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtBiogasNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditBiogasNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditBiogasNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtVemiNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtVemiNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditVemiNew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAuditVemiNew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (ddlGreen.SelectedIndex >0)
        {
            arrIn.Add(Convert.ToInt32(ddlGreen.SelectedValue));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (ddlAuditGreen.SelectedIndex > 0)
        {
            arrIn.Add(Convert.ToInt32(ddlAuditGreen.SelectedValue));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (ddlSanitary.SelectedIndex > 0)
        {
            arrIn.Add(Convert.ToInt32(ddlSanitary.SelectedValue));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (ddlAuditSanitary.SelectedIndex > 0)
        {
            arrIn.Add(Convert.ToInt32(ddlAuditSanitary.SelectedValue));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtnoplanAmt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtnoplanAmt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditnoplanAmt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtAuditnoplanAmt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtByProdDet.Text != "")
        {
            arrIn.Add(txtByProdDet.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditByProdDet.Text != "")
        {
            arrIn.Add(txtAuditByProdDet.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtByProdAmt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtByProdAmt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditByProdAmt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtAuditByProdAmt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        
        /////////////

        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_solidwastemanagement_IU", arrIn);
        GlobalClass gblObj = new GlobalClass();
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
        arrIn.Clear();
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("CleanProjDet.aspx");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("EduProjDet.aspx");
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
            txtAuditMechPlantexist.Text = txtMechPlantexist.Text;
            txtAuditBiogasexist.Text = txtBiogasexist.Text;
            txtAuditvermiexist.Text = txtVerni.Text;
            txtAuditMechaNew.Text = txtMechaNew.Text;
            txtAuditBiogasNew.Text = txtBiogasNew.Text;
            txtAuditVemiNew.Text = txtVemiNew.Text;
            ddlAuditGreen.SelectedValue = ddlGreen.SelectedValue;
            ddlAuditSanitary.SelectedValue = ddlSanitary.SelectedValue;
            txtAuditnoplanAmt.Text = txtnoplanAmt.Text;
            txtAuditByProdDet.Text = txtByProdDet.Text;
            txtAuditByProdAmt.Text = txtByProdAmt.Text;
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
