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

public partial class Pages_JobGivenDetails : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            filDetails();
        }

    }
    public void filDetails()
    {
         ArrayList arrFill = new ArrayList();
          
            arrFill.Clear();
            arrFill.Add(285); //Session["LBID"]
            arrFill.Add(20);//Session["Year"]
            DataSet dsFill = objcom.FillData("tb_labourdetails_Sel", arrFill, CommandType.StoredProcedure);
            if (dsFill.Tables[0].Rows.Count > 0)
            {

                txtRegempCnt.Text = dsFill.Tables[0].Rows[0].ItemArray[0].ToString();
                txtEpGetJobCnt.Text = dsFill.Tables[0].Rows[0].ItemArray[1].ToString();
                txtTotlJobDays.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
                txtWageAmt.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
                txtAmtForMaterialCost.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();
                txtRuleCost.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();

                txtRegEmpCntAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[8].ToString();
                txtEpGetJobCntAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[9].ToString();
                txtTotlJobDaysAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[10].ToString();
                txtWageAmtAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
                txtAmtForMaterialCostAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
                txtRuleCostAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();
            }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        SaveAuditDetails();
    }
    public void SaveAuditDetails()
    {
        fillAuditDetails();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(285);
        arrIn.Add(20);
        arrIn.Add(txtRegEmpCntAudt.Text.ToString());
        arrIn.Add(txtEpGetJobCntAudt.Text.ToString());
        arrIn.Add(txtTotlJobDaysAudt.Text.ToString());
        arrIn.Add(txtWageAmtAudt.Text.ToString());
        arrIn.Add(txtAmtForMaterialCostAudt.Text.ToString());  
        arrIn.Add(txtRuleCostAudt.Text.ToString());
        CommonClass objcommon = new CommonClass();

        int row = objcommon.update("[SP_tb_labourdetails_U]", arrIn);

        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
    }
    public void fillAuditDetails()
    {
        if (txtRegEmpCntAudt.Text == "")
        {
            txtRegEmpCntAudt.Text = txtRegempCnt.Text;
        }
        if (txtEpGetJobCntAudt.Text == "")
        {
            txtEpGetJobCntAudt.Text = txtEpGetJobCnt.Text;
        }
        if (txtTotlJobDaysAudt.Text == "")
        {
            txtTotlJobDaysAudt.Text = txtTotlJobDays.Text;
        }
        if (txtWageAmtAudt.Text == "")
        {
            txtWageAmtAudt.Text = txtWageAmt.Text;
        }
        if (txtAmtForMaterialCostAudt.Text == "")
        {
            txtAmtForMaterialCostAudt.Text = txtAmtForMaterialCost.Text;
        }

        if (txtRuleCostAudt.Text == "")
        {
            txtRuleCostAudt.Text = txtRuleCost.Text;
        }

    }
}
