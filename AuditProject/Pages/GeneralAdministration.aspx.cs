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

public partial class Pages_GeneralAdministration : System.Web.UI.Page
{
    CommonClass objCom = new CommonClass();
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            //FillGramasabha();           
            Session["Flag"] = 0;
            fillDistrict();
            fillTaluk();
            fillAssembly();
            fillDetails();
            if (Convert.ToInt32(Session["RoleID"]) == 2)
            {
                EditSec();
            }
            //if (Convert.ToInt32(Session["RoleID"]) == 1)
            if (Convert.ToInt32(Session["RoleID"]) == 1)
            {
                EditAud();
            }
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
                btnAddNewTal.Enabled = false;
                btnAddNewAss.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnAddNewTal.Enabled = true;
                btnAddNewAss.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
                btnAddNewTal.Enabled = false;
                btnAddNewAss.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;                
                btnAddNewTal.Enabled = false;
                btnAddNewAss.Enabled = false;
              
            }
        }


    }
    public void fillDistrict()
    {
        DataSet ds = new DataSet();
        ds = objCom.FillData("SP_TB_District_MST_S", CommandType.StoredProcedure);
        gblObj.FillCombo(ddlDistrict, ds, 1);
        gblObj.FillCombo(ddlDistrictAud, ds, 1);
    }
  public void fillDetails()
    {
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
        arrIn.Add(Convert.ToInt64(Session["Year"]));
        DataSet dsGen = new DataSet();
        dsGen = objCom.FillData("[SP_tb_generaladministration_S]", arrIn, CommandType.StoredProcedure);
        if (dsGen.Tables[0].Rows.Count > 0)
        {
            ddlDistrict.SelectedValue = dsGen.Tables[0].Rows[0].ItemArray[2].ToString();
            fillTalukAssembly();
            txtEast.Text = dsGen.Tables[0].Rows[0].ItemArray[4].ToString();
            txtWest.Text = dsGen.Tables[0].Rows[0].ItemArray[5].ToString();
            txtSouth.Text = dsGen.Tables[0].Rows[0].ItemArray[6].ToString();
            txtNorth.Text = dsGen.Tables[0].Rows[0].ItemArray[7].ToString();
            txtArea.Text = dsGen.Tables[0].Rows[0].ItemArray[8].ToString();
            txtMale.Text = dsGen.Tables[0].Rows[0].ItemArray[9].ToString();
            txtFemale.Text = dsGen.Tables[0].Rows[0].ItemArray[10].ToString();
            txtPreName.Text = dsGen.Tables[0].Rows[0].ItemArray[12].ToString();
            txtPrePeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[13].ToString();
            txtSecName.Text = dsGen.Tables[0].Rows[0].ItemArray[14].ToString();
            txtSecPeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[15].ToString();
            txtFinName.Text = dsGen.Tables[0].Rows[0].ItemArray[16].ToString();
            txtFinPeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[17].ToString();
            txtDevName.Text = dsGen.Tables[0].Rows[0].ItemArray[18].ToString();
            txtDevPeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[19].ToString();
            txtHealthName.Text = dsGen.Tables[0].Rows[0].ItemArray[20].ToString();
            txtHealthPeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[21].ToString();
            txtWelfareName.Text = dsGen.Tables[0].Rows[0].ItemArray[22].ToString();
            txtWelfarePeriod.Text = dsGen.Tables[0].Rows[0].ItemArray[23].ToString();
        }
        fillAuditedDetails();
    }
    public void fillAuditedDetails()
    {
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
        arrIn.Add(Convert.ToInt64(Session["Year"]));
        DataSet dsGen = new DataSet();
        dsGen = objCom.FillData("[SP_tb_generaladministration_S_Aud]", arrIn, CommandType.StoredProcedure);
        if (dsGen.Tables[0].Rows.Count > 0)
        {
            ddlDistrictAud.SelectedValue = dsGen.Tables[0].Rows[0].ItemArray[2].ToString();
            txtEastAud.Text = dsGen.Tables[0].Rows[0].ItemArray[4].ToString();
            txtWestAud.Text = dsGen.Tables[0].Rows[0].ItemArray[5].ToString();
            txtSouthAud.Text = dsGen.Tables[0].Rows[0].ItemArray[6].ToString();
            txtNorthAud.Text = dsGen.Tables[0].Rows[0].ItemArray[7].ToString();
            txtAreaAud.Text = dsGen.Tables[0].Rows[0].ItemArray[8].ToString();
            txtMaleAud.Text = dsGen.Tables[0].Rows[0].ItemArray[9].ToString();
            txtFemaleAud.Text = dsGen.Tables[0].Rows[0].ItemArray[10].ToString();
            txtPreNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[12].ToString();
            txtPrePeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[13].ToString();
            txtSecNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[14].ToString();
            txtSecPeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[15].ToString();
            txtFinNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[16].ToString();
            txtFinPeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[17].ToString();
            txtDevNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[18].ToString();
            txtDevPeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[19].ToString();
            txtHealthNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[20].ToString();
            txtHealthPeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[21].ToString();
            txtWelfareNameAud.Text = dsGen.Tables[0].Rows[0].ItemArray[22].ToString();
            txtWelfarePeriodAud.Text = dsGen.Tables[0].Rows[0].ItemArray[23].ToString();
        }
    }
    public void EditSec()
    {
        //ddlDistict.SelectedValue
        //ddlTaluk.SelectedValue
        //ddlAssembly.SelectedValue
        ddlDistrictAud.Enabled = false;
        txtEast.ReadOnly  = false;
        txtWest.ReadOnly = false;
        txtSouth.ReadOnly = false;
        txtNorth.ReadOnly = false;
        txtArea.ReadOnly = false;
        txtMale.ReadOnly =false;
        txtFemale.ReadOnly = false;
        txtPreName.ReadOnly = false;
        txtPrePeriod.ReadOnly = false;
        txtSecName.ReadOnly = false;
        txtSecPeriod.ReadOnly = false;
        txtFinName.ReadOnly = false;
        txtFinPeriod.ReadOnly = false;
        txtDevName.ReadOnly = false;
        txtDevPeriod.ReadOnly = false;
        txtHealthName.ReadOnly = false;
        txtHealthPeriod.ReadOnly = false;
        txtWelfareName.ReadOnly = false;
        txtWelfarePeriod.ReadOnly = false;
    }
    public void EditAud()
    {
        //ddlDistict.SelectedValue
        //ddlTaluk.SelectedValue
        //ddlAssembly.SelectedValue
        ddlDistrict.Enabled = false;
        ddlTaluk.Enabled = false;
        ddlAssembly.Enabled = false;
        txtEastAud.ReadOnly = false;
        txtWestAud.ReadOnly = false;
        txtSouthAud.ReadOnly = false;
        txtNorthAud.ReadOnly = false;
        txtAreaAud.ReadOnly = false;
        txtMaleAud.ReadOnly = false;
        txtFemaleAud.ReadOnly = false;
        txtPreNameAud.ReadOnly = false;
        txtPrePeriodAud.ReadOnly = false;
        txtSecNameAud.ReadOnly = false;
        txtSecPeriodAud.ReadOnly = false;
        txtFinNameAud.ReadOnly = false;
        txtFinPeriodAud.ReadOnly = false;
        txtDevNameAud.ReadOnly = false;
        txtDevPeriodAud.ReadOnly = false;
        txtHealthNameAud.ReadOnly = false;
        txtHealthPeriodAud.ReadOnly = false;
        txtWelfareNameAud.ReadOnly = false;
        txtWelfarePeriodAud.ReadOnly = false;
    }
    public void fillTalukAssembly()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds.Clear();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(ddlDistrict.SelectedValue));
        ds = objCom.FillData("SP_m_taluk_S", arr, CommandType.StoredProcedure);
        gblObj.FillCombo(ddlTaluk, ds, 1);
        ds1 = objCom.FillData("SP_m_assembly_S", arr, CommandType.StoredProcedure);
        gblObj.FillCombo(ddlAssembly, ds1, 1);
        //gblObj.FillCombo(ddlAssemblyAud, ds1, 1);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        ds.Clear();
        ds1.Clear();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(ddlDistrict.SelectedValue));
        ds = objCom.FillData("SP_m_taluk_S", arr, CommandType.StoredProcedure);
        gblObj.FillCombo(ddlTaluk, ds, 1);
        ds1 = objCom.FillData("SP_m_assembly_S", arr, CommandType.StoredProcedure);
        gblObj.FillCombo(ddlAssembly, ds1, 1);
        //gblObj.FillCombo(ddlAssemblyAud, ds1, 1);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["RoleID"]) == 1)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["RoleID"]));
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            if (ddlDistrictAud.SelectedIndex < 0)
            {
                if (ddlDistrict.SelectedIndex < 0)
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(Convert.ToInt32(ddlDistrict.SelectedValue));
                }
                
            }
            else { 
                 arrIn.Add(Convert.ToInt32(ddlDistrictAud.SelectedValue));
            }
            //--------------------------
            if (txtEastAud.Text == "")
            {
                if (txtEast.Text != "")
                {
                    arrIn.Add(txtEast.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtEastAud.Text);
            }
            //--------------------------
            if (txtWestAud.Text == "")
            {
                if (txtWest.Text != "")
                {
                    arrIn.Add(txtWest.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtWestAud.Text);
            }
            
            //--------------------------
            if (txtSouthAud.Text == "")
            {
                if (txtSouth.Text != "")
                {
                    arrIn.Add(txtSouth.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtSouthAud.Text);
            }

            //--------------------------
            if (txtNorthAud.Text == "")
            {
                if (txtNorth.Text != "")
                {
                    arrIn.Add(txtNorth.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtNorthAud.Text);
            }
            //--------------------------
            if (txtAreaAud.Text == "")
            {
                if (txtArea.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtArea.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtAreaAud.Text.ToString()));
            }

            //--------------------------
            if (txtMaleAud.Text == "")
            {
                if (txtMale.Text != "")
                {
                    arrIn.Add(Convert.ToInt64(txtMale.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToInt64(txtMaleAud.Text.ToString()));
            }
         
            //--------------------------
            if (txtFemaleAud.Text == "")
            {
                if (txtFemale.Text != "")
                {
                    arrIn.Add(Convert.ToInt64(txtFemale.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToInt64(txtFemaleAud.Text.ToString()));
            }
            
            //--------------------------
            if (txtPreNameAud.Text == "")
            {
                if (txtPreName.Text != "")
                {
                    arrIn.Add(txtPreName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtPreNameAud.Text);
            }
       
              //--------------------------
            if (txtPrePeriodAud.Text == "")
            {
                if (txtPrePeriod.Text != "")
                {
                    arrIn.Add(txtPrePeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtPrePeriodAud.Text);
            }
            
              //--------------------------
            if (txtSecNameAud.Text == "")
            {
                if (txtSecName.Text != "")
                {
                    arrIn.Add(txtSecName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtSecNameAud.Text);
            }
            
             //--------------------------
            if (txtSecPeriodAud.Text == "")
            {
                if (txtSecPeriod.Text != "")
                {
                    arrIn.Add(txtSecPeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtSecPeriodAud.Text);
            }
           
             //--------------------------
            if (txtFinNameAud.Text == "")
            {
                if (txtFinName.Text != "")
                {
                    arrIn.Add(txtFinName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtFinNameAud.Text);
            }
            
             //--------------------------
            if (txtFinPeriodAud.Text == "")
            {
                if (txtFinPeriod.Text != "")
                {
                    arrIn.Add(txtFinPeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtFinPeriodAud.Text);
            }
            
             //--------------------------
            if (txtDevNameAud.Text == "")
            {
                if (txtDevName.Text != "")
                {
                    arrIn.Add(txtDevName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtDevNameAud.Text);
            }
            
             //--------------------------
            if (txtDevPeriodAud.Text == "")
            {
                if (txtDevPeriod.Text != "")
                {
                    arrIn.Add(txtDevPeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtDevPeriodAud.Text);
            }
            
             //--------------------------
            if (txtHealthNameAud.Text == "")
            {
                if (txtHealthName.Text != "")
                {
                    arrIn.Add(txtHealthName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtHealthNameAud.Text);
            }
           
             //--------------------------
            if (txtHealthPeriodAud.Text == "")
            {
                if (txtHealthPeriod.Text != "")
                {
                    arrIn.Add(txtHealthPeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtHealthPeriodAud.Text);
            }
            
             //--------------------------
            if (txtWelfareNameAud.Text == "")
            {
                if (txtWelfareName.Text != "")
                {
                    arrIn.Add(txtWelfareName.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtWelfareNameAud.Text);
            }
            
             //--------------------------
            if (txtWelfarePeriodAud.Text == "")
            {
                if (txtWelfarePeriod.Text != "")
                {
                    arrIn.Add(txtWelfarePeriod.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtWelfarePeriodAud.Text);
            }
            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));
            arrIn.Add(Convert.ToInt64(Session["Year"]));
             //--------------------------
            if (int.Parse(ddlDistrict.SelectedValue) <= 0)
            {
                gblObj.MsgBoxOk("Please select the District", this);
            }
            else
            {
                int row = objCom.update("SP_tb_generaladministration_U", arrIn);
                if (row > 0)
                {
                    gblObj.MsgBoxOk("saved successfully ", this);
                    Session["Flag"] = 0;
                }
            }
        }
        if (Convert.ToInt32(Session["RoleID"]) == 2)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["RoleID"]));
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            if (ddlDistrict.SelectedIndex < 0)
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(ddlDistrict.SelectedValue));
            }
            if (txtEast.Text != "")
            {
                arrIn.Add(txtEast.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtWest.Text != "")
            {
                arrIn.Add(txtWest.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtSouth.Text != "")
            {
                arrIn.Add(txtSouth.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtNorth.Text != "")
            {
                arrIn.Add(txtNorth.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtArea.Text != "")
            {
                arrIn.Add(Convert.ToDouble(txtArea.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtMale.Text != "")
            {
                arrIn.Add(Convert.ToInt64(txtMale.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtFemale.Text != "")
            {
                arrIn.Add(Convert.ToInt64(txtFemale.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtPreName.Text != "")
            {
                arrIn.Add(txtPreName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtPrePeriod.Text != "")
            {
                arrIn.Add(txtPrePeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtSecName.Text != "")
            {
                arrIn.Add(txtSecName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtSecPeriod.Text != "")
            {
                arrIn.Add(txtSecPeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtFinName.Text != "")
            {
                arrIn.Add(txtFinName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtFinPeriod.Text != "")
            {
                arrIn.Add(txtFinPeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtDevName.Text != "")
            {
                arrIn.Add(txtDevName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtDevPeriod.Text != "")
            {
                arrIn.Add(txtDevPeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtHealthName.Text != "")
            {
                arrIn.Add(txtHealthName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtHealthPeriod.Text != "")
            {
                arrIn.Add(txtHealthPeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtWelfareName.Text != "")
            {
                arrIn.Add(txtWelfareName.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            if (txtWelfarePeriod.Text != "")
            {
                arrIn.Add(txtWelfarePeriod.Text);
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));
            arrIn.Add(Convert.ToInt64(Session["Year"]));
            if (int.Parse(ddlDistrict.SelectedValue) <= 0)
            {
                gblObj.MsgBoxOk("Please select the District", this);
            }
            else
            {
                int row = objCom.update("SP_tb_generaladministration_U", arrIn);
                if (row > 0)
                {
                    GlobalClass gblObj = new GlobalClass();
                    gblObj.MsgBoxOk("Saved Successfully ", this);
                    Session["Flag"] = 0;
                }
            }
        }
        fillDetails();
        fillAuditedDetails();
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetDetails.aspx");
    }

    protected void ddlDistrictAud_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        //DataSet ds1 = new DataSet();
        //ds.Clear();
        //ds1.Clear();
        //ArrayList arr = new ArrayList();
        //arr.Add(Convert.ToInt32(ddlDistrict.SelectedValue));
        //ds = objCom.FillData("SP_m_taluk_S", arr, CommandType.StoredProcedure);
        //gblObj.FillCombo(ddlTalukAud, ds, 1);
        //ds1 = objCom.FillData("SP_m_assembly_S", arr, CommandType.StoredProcedure);
        //gblObj.FillCombo(ddlAssemblyAud, ds1, 1);
    }
    public void fillTaluk()
    {
        ArrayList arrFillT = new ArrayList();
        string strTal="";
        arrFillT.Clear();
        arrFillT.Add(Convert.ToInt32(Session["LBID"]));
        DataSet dsFillT = objCom.FillData("SP_tb_taluklbwise_S", arrFillT, CommandType.StoredProcedure);
        if (dsFillT.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsFillT.Tables[0].Rows.Count; i++)
            {
                strTal = strTal + dsFillT.Tables[0].Rows[i].ItemArray[1].ToString();
                strTal += (i < dsFillT.Tables[0].Rows.Count - 1) ? "," : string.Empty;
            }
        }
        txtTalukNew.Text = strTal;
        txtTalukAud.Text = strTal;

    }
    public void fillAssembly()
    {
        ArrayList arrFillA = new ArrayList();
        arrFillA.Clear();
        string str=""; 
        arrFillA.Add(Convert.ToInt32(Session["LBID"]));
        DataSet dsFillA = objCom.FillData("SP_tb_assemblylbwise_S", arrFillA, CommandType.StoredProcedure);
        if (dsFillA.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsFillA.Tables[0].Rows.Count; i++)
            {
                str = str + dsFillA.Tables[0].Rows[i].ItemArray[1].ToString();
                str += (i < dsFillA.Tables[0].Rows.Count - 1) ? "," : string.Empty;
                //txtAssNew.Text += dsFillA.Tables[0].Rows[i].ItemArray[1].ToString() + "," + ' ';
                //txtAssemblyAud.Text += dsFillA.Tables[0].Rows[i].ItemArray[1].ToString() + "," + ' ';
            }
        }
        txtAssNew.Text = str;
        txtAssemblyAud.Text = str;
    }
     
 protected void btnAddNewTal_Click(object sender, EventArgs e)
    {
       ArrayList arrTal = new ArrayList();
       arrTal.Add(Convert.ToInt32(Session["LBID"]));
       arrTal.Add(Convert.ToInt32(ddlTaluk.SelectedValue));
       objCom.update("SP_tb_taluklbwise_I", arrTal);
       txtTalukNew.Visible = true;
       fillTaluk();
       ddlTaluk.SelectedIndex = 0;
    }
    protected void btnAddNewAss_Click(object sender, EventArgs e)
    {
        ArrayList arrAss = new ArrayList();
        arrAss.Add(Convert.ToInt32(ddlAssembly.SelectedValue));
        arrAss.Add(Convert.ToInt32(Session["LBID"]));
        objCom.update("SP_tb_assemblylbwise_I", arrAss);
        txtAssNew.Visible = true;
        fillAssembly();
        ddlAssembly.SelectedIndex = 0;
    }
    protected void ddlTaluk_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList arrTal = new ArrayList();
        arrTal.Add(Convert.ToInt32(Session["LBID"]));
        arrTal.Add(Convert.ToInt32(ddlTaluk.SelectedValue));
        objCom.update("SP_tb_taluklbwise_I", arrTal);
        fillTaluk();
    }
    protected void ddlAssembly_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList arrAss = new ArrayList();
        arrAss.Add(Convert.ToInt32(ddlAssembly.SelectedValue));
        arrAss.Add(Convert.ToInt32(Session["LBID"]));
        objCom.update("SP_tb_assemblylbwise_I", arrAss);
        fillAssembly();
    }
    protected void lbtnRemove_Click(object sender, EventArgs e)
    {
        ArrayList arrRem = new ArrayList();
        arrRem.Add(Convert.ToInt32(Session["LBID"]));
        arrRem.Add(Convert.ToInt32(Session["RoleID"]));
        objCom.update("SP_tb_taluklbwise_Del", arrRem);
        txtTalukNew.Visible = true;
        fillTaluk();
        ddlTaluk.SelectedIndex = 0;
    }
    protected void lbtnRemoveAss_Click(object sender, EventArgs e)
    {
        ArrayList arrRemAss = new ArrayList();
        arrRemAss.Add(Convert.ToInt32(Session["LBID"]));
        arrRemAss.Add(Convert.ToInt32(Session["RoleID"]));
        objCom.update("SP_tb_assemblylbwise_Del", arrRemAss);
        txtAssNew.Visible = true;
        fillAssembly();
        ddlAssembly.SelectedIndex = 0;
    }
}
