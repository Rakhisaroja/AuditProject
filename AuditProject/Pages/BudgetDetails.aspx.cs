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
public partial class Pages_BudgetDetails : System.Web.UI.Page
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
        txtDvlpmntAudt.Text = txtDvlpmnt.Text;
        txtWlfrAudt.Text =txtWlfr.Text;
        txtHealthAudt.Text =txtHealth.Text;
        txteduAudt.Text =txtedu.Text;
        txtBdgtDatAudt.Text =txtBdgtDat.Text;
        txtBdgtPassDtAudt.Text =txtBdgtPassDt.Text;
        txtOrdrNumAudt.Text =txtOrdrNum.Text;
        txtOpeningAudt.Text =txtOpening.Text;
        txtIncmAudt.Text =txtIncm.Text;
        txtTotalAudt.Text =txtTotal.Text;
        txtExpndtureAudt.Text =txtExpndture.Text;
        txtBlnceAudt.Text =txtBlnce.Text;
        txtrevisedbudgetDtAudt.Text =txtrevisedbudgetDt.Text;
        txtdecisionAudt.Text =txtdecision.Text;
        txtresolutionnoAudt.Text = txtresolutionno.Text;
        txtStataudtdateAudt.Text = txtStataudtdate.Text;

        txtStataudtdcnAudt.Text = txtStataudtdcn.Text;
        txtStataudtdcnNoAudt.Text = txtStataudtdcnNo.Text;
        
    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtDvlpmnt.ReadOnly = false;
            txtWlfr.ReadOnly = false;
            txtHealth.ReadOnly = false;
            txtedu.ReadOnly = false;
            txtBdgtDat.ReadOnly = false;
            txtBdgtPassDt.ReadOnly = false;
            txtOrdrNum.ReadOnly = false;
            txtOpening.ReadOnly = false;
            txtIncm.ReadOnly = false;
           // txtTotal.ReadOnly = false;
            txtExpndture.ReadOnly = false;
            txtBlnce.ReadOnly = false;
            txtrevisedbudgetDt.ReadOnly = false;
            txtdecision.ReadOnly = false;
            txtresolutionno.ReadOnly = false;
            txtStataudtdate.ReadOnly = false;

            txtStataudtdcn.ReadOnly = false;
            txtStataudtdcnNo.ReadOnly = false;


        }
        else
        {
            txtDvlpmntAudt.ReadOnly = false;
            txtWlfrAudt.ReadOnly = false;
            txtHealthAudt.ReadOnly = false;
            txteduAudt.ReadOnly = false;
            txtBdgtDatAudt.ReadOnly = false;
            txtBdgtPassDtAudt.ReadOnly = false;
            txtOrdrNumAudt.ReadOnly = false;
            txtOpeningAudt.ReadOnly = false;
            txtIncmAudt.ReadOnly = false;
           // txtTotalAudt.ReadOnly = false;
            txtExpndtureAudt.ReadOnly = false;
            txtBlnceAudt.ReadOnly = false;
            txtrevisedbudgetDtAudt.ReadOnly = false;
            txtdecisionAudt.ReadOnly = false;
            txtresolutionnoAudt.ReadOnly = false;
            txtStataudtdateAudt.ReadOnly = false;

            txtStataudtdcnAudt.ReadOnly = false;
            txtStataudtdcnNoAudt.ReadOnly = false;
        }
    }
    public void Filldata()
    {
          ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_budgetdetails_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            txtDvlpmnt.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
            txtWlfr.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
            txtHealth.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();
            txtedu.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();
            txtBdgtDat.Text = dsFill.Tables[0].Rows[0].ItemArray[6].ToString();
            txtBdgtPassDt.Text = dsFill.Tables[0].Rows[0].ItemArray[7].ToString();
            txtOrdrNum.Text = dsFill.Tables[0].Rows[0].ItemArray[8].ToString();
            txtOpening.Text = dsFill.Tables[0].Rows[0].ItemArray[9].ToString();
            txtIncm.Text = dsFill.Tables[0].Rows[0].ItemArray[10].ToString();

            double total = (Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[9].ToString()) + Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[10].ToString()));

            txtTotal.Text = total.ToString();// dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
            txtExpndture.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
            txtBlnce.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();
            txtrevisedbudgetDt.Text = dsFill.Tables[0].Rows[0].ItemArray[14].ToString();
            txtdecision.Text = dsFill.Tables[0].Rows[0].ItemArray[15].ToString();
            txtresolutionno.Text = dsFill.Tables[0].Rows[0].ItemArray[16].ToString();
            txtStataudtdate.Text = dsFill.Tables[0].Rows[0].ItemArray[17].ToString();


            txtDvlpmntAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[18].ToString();
            txtWlfrAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[19].ToString();
            txtHealthAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[20].ToString();
            txteduAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[21].ToString();
            txtBdgtDatAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[22].ToString();
            txtBdgtPassDtAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[23].ToString();
            txtOrdrNumAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[24].ToString();
            txtOpeningAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[25].ToString();
            txtIncmAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[26].ToString();

            double totalaudt = (Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[25].ToString()) + Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[26].ToString()));


            txtTotalAudt.Text = totalaudt.ToString();// dsFill.Tables[0].Rows[0].ItemArray[27].ToString();
            txtExpndtureAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[28].ToString();
            txtBlnceAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[29].ToString();
            txtrevisedbudgetDtAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[30].ToString();
            txtdecisionAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[31].ToString();
            txtresolutionnoAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[32].ToString();
            txtStataudtdateAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[33].ToString();

            txtStataudtdcn.Text = dsFill.Tables[0].Rows[0].ItemArray[39].ToString();
            txtStataudtdcnNo.Text = dsFill.Tables[0].Rows[0].ItemArray[40].ToString();
            txtStataudtdcnAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[41].ToString();
            txtStataudtdcnNoAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[42].ToString();
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
        if (txtDvlpmnt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtDvlpmnt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtWlfr.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtWlfr.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtHealth.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtHealth.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtedu.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtedu.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtBdgtDat.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtBdgtDat.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtBdgtPassDt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtBdgtPassDt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtOrdrNum.Text != "")
        {
            arrIn.Add(txtOrdrNum.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtOpening.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOpening.Text));
            Session["OB"] = Convert.ToDouble(txtOpening.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
            Session["OB"] = 0;
        }
        if (txtIncm.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtIncm.Text));
            Session["Incm"] = Convert.ToDouble(txtIncm.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
            Session["Incm"] = 0;
        }
        //if (txtTotal.Text != "")
        //{
           
        //    arrIn.Add(total);
        //    arrIn.Add(Convert.ToDouble(txtTotal.Text));
        //}
        //else
        //{
        //    arrIn.Add(DBNull.Value);
        //}




        double total = Convert.ToDouble(Session["OB"]) + Convert.ToDouble(Session["Incm"]);

        txtTotal.Text = total.ToString();
        arrIn.Add(Convert.ToDouble(txtTotal.Text));

        if (txtExpndture.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtExpndture.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtBlnce.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtBlnce.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        
        if (txtrevisedbudgetDt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtdecision.Text != "")
        {
            arrIn.Add(txtdecision.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtresolutionno.Text != "")
        {
            arrIn.Add(txtresolutionno.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtStataudtdate.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtStataudtdate.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtDvlpmntAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtDvlpmntAudt.Text));
        }
        else
        {
            //if (txtDvlpmnt.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtDvlpmnt.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
            
        }
        if (txtWlfrAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtWlfrAudt.Text));
        }
        else
        {
            //if (txtWlfr.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtWlfr.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
            
        }
        if (txtHealthAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtHealthAudt.Text));
        }
        else
        {
            //if (txtHealth.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtHealth.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value); 
        }
        if (txteduAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txteduAudt.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);

            //if (txtedu.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtedu.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
           
        }
        if (txtBdgtDatAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtBdgtDatAudt.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);
            //if (txtBdgtDat.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtBdgtDat.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
           
            
        }
        if (txtBdgtPassDtAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtBdgtPassDtAudt.Text));
        }
        else
        {
            //if (txtBdgtPassDt.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtBdgtPassDt.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}

            arrIn.Add(DBNull.Value);
            
        }
        if (txtOrdrNumAudt.Text != "")
        {
            arrIn.Add(txtOrdrNumAudt.Text);
        }
        else
        {
            //if (txtOrdrNum.Text != "")
            //{

            //    arrIn.Add(txtOrdrNum.Text);
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
          
        }
        if (txtOpeningAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble( txtOpeningAudt.Text));
            Session["OBAudt"] = Convert.ToDouble(txtOpeningAudt.Text);
        }
        else
        {
            //if (txtOpening.Text != "")
            //{

            //    arrIn.Add(Convert.ToDouble(txtOpening.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }
        if (txtIncmAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtIncmAudt.Text));
            Session["IncmAudt"] = Convert.ToDouble(txtIncmAudt.Text);
        }
        else
        {
            //if (txtIncm.Text != "")
            //{

            //    arrIn.Add(Convert.ToDouble(txtIncm.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }

        double totalAudt = Convert.ToDouble(Session["OBAudt"]) + Convert.ToDouble(Session["IncmAudt"]);

        txtTotalAudt.Text = totalAudt.ToString();
        //arrIn.Add(Convert.ToDouble(txtTotal.Text));


        if (txtTotalAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtTotalAudt.Text));
        }
        else
        {
            //if (txtTotal.Text != "")
            //{

            //    arrIn.Add(Convert.ToDouble(txtTotal.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }
        if (txtExpndtureAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtExpndtureAudt.Text));
        }
        else
        {
            //if (txtExpndture.Text != "")
            //{

            //    arrIn.Add(Convert.ToDouble(txtExpndture.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value); 
        }
        if (txtBlnceAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtBlnceAudt.Text));
        }
        else
        {
            //if (txtBlnce.Text != "")
            //{

            //    arrIn.Add(Convert.ToDouble(txtBlnce.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value); 
        }
        if (txtrevisedbudgetDtAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDtAudt.Text));
        }
        else
        {
            //if (txtrevisedbudgetDt.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDt.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }
        if (txtdecisionAudt.Text != "")
        {
            arrIn.Add(txtdecisionAudt.Text);
        }
        else
        {
            //if (txtdecision.Text != "")
            //{

            //    arrIn.Add(txtdecision.Text);
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }
        if (txtresolutionnoAudt.Text != "")
        {
            arrIn.Add(txtresolutionnoAudt.Text);
        }
        else
        {
            //if (txtresolutionno.Text != "")
            //{

            //    arrIn.Add(txtresolutionno.Text);
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);  
        }
        if (txtStataudtdateAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtStataudtdateAudt.Text));
        }
        else
        {
            //if (txtStataudtdate.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtStataudtdate.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value); 
        }
        arrIn.Add(1);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

        if (txtStataudtdcn.Text != "")
        {

            arrIn.Add(txtStataudtdcn.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtStataudtdcnNo.Text != "")
        {

            arrIn.Add(txtStataudtdcnNo.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtStataudtdcnAudt.Text != "")
        {
            arrIn.Add(txtStataudtdcnAudt.Text);
        }
        else
        {
            //if (txtStataudtdcn.Text != "")
            //{

            //    arrIn.Add(txtStataudtdcn.Text);
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }

        if (txtStataudtdcnNoAudt.Text != "")
        {
            arrIn.Add(txtStataudtdcnNoAudt.Text);
        }
        else
        {
            //if (txtStataudtdcnNo.Text != "")
            //{

            //    arrIn.Add(txtStataudtdcnNo.Text);
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
        }
        int row = objcomm.update("SP_tb_budgetdetails_IU", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
       Response.Redirect("MemberWardDetails.aspx");
       // Response.Redirect("AgricultureDetails.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("GeneralAdministration.aspx");
    }
    protected void txtdecision_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtOpening_TextChanged(object sender, EventArgs e)
    {

    }
}
