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

public partial class Pages_BudgetDetails_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            chkStatus();
            Filldata();
            fillOfficers(0);
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
        txtWlfrAudt.Text = txtWlfr.Text;
        txtHealthAudt.Text = txtHealth.Text;
        txteduAudt.Text = txtedu.Text;
        txtBdgtDatAudt.Text = txtBdgtDat.Text;
        txtBdgtPassDtAudt.Text = txtBdgtPassDt.Text;
        txtOrdrNumAudt.Text = txtOrdrNum.Text;
        txtOpeningAudt.Text = txtOpening.Text;
        txtIncmAudt.Text = txtIncm.Text;
        txtTotalAudt.Text = txtTotal.Text;
        txtExpndtureAudt.Text = txtExpndture.Text;
        txtBlnceAudt.Text = txtBlnce.Text;
        //txtrevisedbudgetDtAudt.Text = txtrevisedbudgetDt.Text;
        txtdecisionAudt.Text = txtdecision.Text;
        txtresolutionnoAudt.Text = txtresolutionno.Text;
        txtStataudtdateAudt.Text = txtStataudtdate.Text;

        txtcarromAudt.Text = txtcarrom.Text;
        txttaxAud.Text = txttax.Text;
        txttownplanAud.Text = txttownplan.Text;
        txtStataudtdcnAudt.Text = txtStataudtdcn.Text;
        txtStataudtdcnNoAudt.Text = txtStataudtdcnNo.Text;

        txtmeetconddteAud.Text = txtmeetconddte.Text; 
        txtsubmitdteAud.Text = txtsubmitdte.Text;
        txtsuplordernumAud.Text = txtsuplordernum.Text;
        txtsuplpassdteAud.Text = txtsuplpassdte.Text;
        txtrvseddteAud.Text = txtrvseddte.Text;
        txtmeetdteAud.Text = txtmeetdte.Text;

        //////////////////
        for (int i = 0; i < grvMembers.Items.Count; i++)
        {
            TextBox text1 = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox;
            TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofofficermal") as TextBox;
            text2.Text = text1.Text;
        }
       
      
    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtDvlpmnt.ReadOnly = false;
          
            txtWlfr.ReadOnly = false;
            txtHealth.ReadOnly = false;

            txtcarrom.ReadOnly = false;
            txtedu.ReadOnly = false;
            txttownplan.ReadOnly = false;
            txttax.ReadOnly = false;
            txtmeetdte.ReadOnly = false;
            txtmeetconddte.ReadOnly = false;
            txtsubmitdte.ReadOnly = false;
            txtrvseddte.ReadOnly = false;
            txtsuplordernum.ReadOnly = false;
            txtsuplpassdte.ReadOnly = false;

            txtBdgtDat.ReadOnly = false;
            txtBdgtPassDt.ReadOnly = false;
            txtOrdrNum.ReadOnly = false;
            txtOpening.ReadOnly = false;
            txtIncm.ReadOnly = false;
            // txtTotal.ReadOnly = false;
            txtExpndture.ReadOnly = false;
            txtBlnce.ReadOnly = false;
            //txtrevisedbudgetDt.ReadOnly = false;
            txtdecision.ReadOnly = false;
            txtresolutionno.ReadOnly = false;
            txtStataudtdate.ReadOnly = false;

            txtStataudtdcn.ReadOnly = false;
            txtStataudtdcnNo.ReadOnly = false;

            //date selection diabled
            txtDvlpmntAudt.Enabled = false;
            txtWlfrAudt.Enabled = false;
            txtHealthAudt.Enabled = false;
            txtcarromAudt.Enabled = false;
            txteduAudt.Enabled = false;
            txtBdgtDatAudt.Enabled = false;
            txtBdgtPassDtAudt.Enabled = false;
            txtOrdrNumAudt.Enabled = false;
            txtOpeningAudt.Enabled = false;
            txtIncmAudt.Enabled = false;
            // txtTotalAudt.ReadOnly = false;
            txtExpndtureAudt.Enabled = false;
            txtBlnceAudt.Enabled = false;
           // txtrevisedbudgetDtAudt.Enabled = false;
            txtdecisionAudt.Enabled = false;
            txtresolutionnoAudt.Enabled = false;
            txtStataudtdateAudt.Enabled = false;

            txtStataudtdcnAudt.Enabled = false;
            txtStataudtdcnNoAudt.Enabled = false;

            //new
            txttownplanAud.Enabled = false;
            txttaxAud.Enabled = false;
            txtmeetdteAud.Enabled = false;
            txtmeetconddteAud.Enabled = false;
            txtsubmitdteAud.Enabled = false;
            txtrvseddteAud.Enabled = false;
            txtsuplordernumAud.Enabled = false;
            txtsuplpassdteAud.Enabled = false;

        }
        else
        {
            txtDvlpmntAudt.ReadOnly = false;
            
            txtWlfrAudt.ReadOnly = false;
            txtHealthAudt.ReadOnly = false;
            txtcarromAudt.ReadOnly = false;
            txteduAudt.ReadOnly = false;
            txtBdgtDatAudt.ReadOnly = false;
            txtBdgtPassDtAudt.ReadOnly = false;
            txtOrdrNumAudt.ReadOnly = false;
            txtOpeningAudt.ReadOnly = false;
            txtIncmAudt.ReadOnly = false;
            // txtTotalAudt.ReadOnly = false;
            txtExpndtureAudt.ReadOnly = false;
            txtBlnceAudt.ReadOnly = false;
            //txtrevisedbudgetDtAudt.ReadOnly = false;
            txtdecisionAudt.ReadOnly = false;
            txtresolutionnoAudt.ReadOnly = false;
            txtStataudtdateAudt.ReadOnly = false;

            txtStataudtdcnAudt.ReadOnly = false;
            txtStataudtdcnNoAudt.ReadOnly = false;

            //new
            txttownplanAud.ReadOnly = false;
            txttaxAud.ReadOnly = false;
            txtmeetdteAud.ReadOnly = false;
            txtmeetconddteAud.ReadOnly = false;
            txtsubmitdteAud.ReadOnly = false;
            txtrvseddteAud.ReadOnly = false;
            txtsuplordernumAud.ReadOnly = false;
            txtsuplpassdteAud.ReadOnly = false;
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_budgetdetailsUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            txtDvlpmnt.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
            txtWlfr.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
            txtHealth.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();
            //new
            txtcarrom.Text = dsFill.Tables[0].Rows[0].ItemArray[43].ToString();
            //new end
            txtedu.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();
            //new 
            txttownplan.Text = dsFill.Tables[0].Rows[0].ItemArray[44].ToString();
            txttax.Text = dsFill.Tables[0].Rows[0].ItemArray[45].ToString();
            txtmeetdte.Text = dsFill.Tables[0].Rows[0].ItemArray[46].ToString();
            txtmeetconddte.Text = dsFill.Tables[0].Rows[0].ItemArray[47].ToString();
            txtsubmitdte.Text = dsFill.Tables[0].Rows[0].ItemArray[48].ToString();
            //new end


            txtBdgtDat.Text = dsFill.Tables[0].Rows[0].ItemArray[6].ToString();
            txtBdgtPassDt.Text = dsFill.Tables[0].Rows[0].ItemArray[7].ToString();
            txtOrdrNum.Text = dsFill.Tables[0].Rows[0].ItemArray[8].ToString();

            //new 

            txtrvseddte.Text = dsFill.Tables[0].Rows[0].ItemArray[49].ToString();
            txtsuplpassdte.Text = dsFill.Tables[0].Rows[0].ItemArray[50].ToString();
            txtsuplordernum.Text = dsFill.Tables[0].Rows[0].ItemArray[51].ToString();
            //new end

            txtOpening.Text = dsFill.Tables[0].Rows[0].ItemArray[9].ToString();
            txtIncm.Text = dsFill.Tables[0].Rows[0].ItemArray[10].ToString();

            double total = (Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[9].ToString()) + Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[10].ToString()));

            txtTotal.Text = total.ToString();// dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
            txtExpndture.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
            txtBlnce.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();
            //txtrevisedbudgetDt.Text = dsFill.Tables[0].Rows[0].ItemArray[14].ToString();
            txtdecision.Text = dsFill.Tables[0].Rows[0].ItemArray[15].ToString();
            txtresolutionno.Text = dsFill.Tables[0].Rows[0].ItemArray[16].ToString();
            txtStataudtdate.Text = dsFill.Tables[0].Rows[0].ItemArray[17].ToString();


            txtDvlpmntAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[18].ToString();
            txtWlfrAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[19].ToString();
            txtHealthAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[20].ToString();
            //new
            txtcarromAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[52].ToString();
            //new end

            txteduAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[21].ToString();

            //new 
            txttownplanAud.Text = dsFill.Tables[0].Rows[0].ItemArray[53].ToString();
            txttaxAud.Text = dsFill.Tables[0].Rows[0].ItemArray[54].ToString();
            txtmeetdteAud.Text = dsFill.Tables[0].Rows[0].ItemArray[55].ToString();
            txtmeetconddteAud.Text= dsFill.Tables[0].Rows[0].ItemArray[56].ToString();
            txtsubmitdteAud.Text= dsFill.Tables[0].Rows[0].ItemArray[57].ToString();
            //new end



            txtBdgtDatAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[22].ToString();
            txtBdgtPassDtAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[23].ToString();
            txtOrdrNumAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[24].ToString();


            //new 

            txtrvseddteAud.Text = dsFill.Tables[0].Rows[0].ItemArray[58].ToString();
            txtsuplpassdteAud.Text = dsFill.Tables[0].Rows[0].ItemArray[59].ToString();
            txtsuplordernumAud.Text = dsFill.Tables[0].Rows[0].ItemArray[60].ToString();
            //new end

            txtOpeningAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[25].ToString();
            txtIncmAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[26].ToString();

            double totalaudt = (Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[25].ToString()) + Convert.ToDouble(dsFill.Tables[0].Rows[0].ItemArray[26].ToString()));


            txtTotalAudt.Text = totalaudt.ToString();// dsFill.Tables[0].Rows[0].ItemArray[27].ToString();
            txtExpndtureAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[28].ToString();
            txtBlnceAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[29].ToString();
            //txtrevisedbudgetDtAudt.Text = dsFill.Tables[0].Rows[0].ItemArray[30].ToString();
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
        Save_DataMembers();
        Filldata();
    }
    public void Save_DataMembers()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvMembers.Items.Count; i++)
        {
            TextBox txtDataq = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox; //@chvnameofmembermal 
            if (txtDataq.Text != "")
            {
                arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
                arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,

           
                Label lblData3 = grvMembers.Items[i].FindControl("intslno") as Label;   ////@intslno ,
               
            
                arrIn.Add(i + 1);    //@intslno
  
                arrIn.Add(DBNull.Value);
                TextBox txtData2 = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox; //@chvnameofmembermal 
                if (txtData2.Text != "")
                {
                    arrIn.Add(txtData2.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
                TextBox txtData3 = grvMembers.Items[i].FindControl("chvAuditnameofofficermal") as TextBox; //@chvAuditnameofmembermal 
                if (txtData3.Text == "")
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(txtData3.Text.ToString());
                }

                arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
                arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
                arrIn.Add(1);
                int ep = objcomm.update("SP_tb_BudgetOfficersUrban_IU", arrIn);
               
            }
            arrIn.Clear();
        }
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

        //NEW

        if (txtcarrom.Text != "")
        {

            arrIn.Add(Convert.ToDateTime(txtcarrom.Text));
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


        //NEW

        if (txttownplan.Text != "")
        {

            arrIn.Add(Convert.ToDateTime(txttownplan.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        //NEW

        if (txttax.Text != "")
        {

            arrIn.Add(Convert.ToDateTime(txttax.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtmeetdte.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtmeetdte.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtmeetconddte.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtmeetconddte.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtsubmitdte.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtsubmitdte.Text));
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



        //new 
        if (txtrvseddte.Text != "")
        {

            arrIn.Add(Convert.ToDateTime(txtrvseddte.Text));

        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtsuplpassdte.Text!= "")
        {

            arrIn.Add(Convert.ToDateTime(txtsuplpassdte.Text));

        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        if (txtsuplordernum.Text != "")
        {

            arrIn.Add(txtsuplordernum.Text);

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

        //if (txtrevisedbudgetDt.Text != "")
        //{
           // arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDt.Text));
        //}
        //else
        //{
            arrIn.Add(DBNull.Value);
        //}
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

        //new
        if (txtcarromAudt.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtcarromAudt.Text));
        }
        else
        {

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


        //new
        if (txttownplanAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txttownplanAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }


        if (txttaxAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txttaxAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }


        if (txtmeetdteAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtmeetdteAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }



        if (txtmeetconddteAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtmeetconddteAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }


        if (txtsubmitdteAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtsubmitdteAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


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
        


        //new

        if (txtrvseddteAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtrvseddteAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }
        if (txtsuplpassdteAud.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(txtsuplpassdteAud.Text));
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }
        if (txtsuplordernumAud.Text != "")
        {
            arrIn.Add(txtsuplordernumAud.Text);
        }
        else
        {

            arrIn.Add(DBNull.Value);


        }

        //new end 
        if (txtOpeningAudt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOpeningAudt.Text));
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
       // if (txtrevisedbudgetDtAudt.Text != "")
       // {
            //arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDtAudt.Text));
       // }
       // else
       // {
            //if (txtrevisedbudgetDt.Text != "")
            //{

            //    arrIn.Add(Convert.ToDateTime(txtrevisedbudgetDt.Text));
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            arrIn.Add(DBNull.Value);
       // }
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
        int row = objcomm.update("SP_tb_budgetdetailsUrban_IU", arrIn);

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
        Response.Redirect("GeneralAdministration_Urban.aspx");
    }
    protected void txtdecision_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtOpening_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtnoofMember_TextChanged(object sender, EventArgs e)
    {
        if (txtnoofMember.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMember.Text);
            fillOfficers(cut);
            //txtnoofMember.ReadOnly = true;
            //btnMember.Enabled = false;
        }
    }
    protected void btnMember_Click(object sender, EventArgs e)
    {
        if (txtnoofMember.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMember.Text);
            fillOfficers(cut);
            //txtnoofMember.ReadOnly = true;
            //btnMember.Enabled = false;
            //disabletextboxmember();
        }
    }
    void fillOfficers(int cut)
    {
        ArrayList arrIn = new ArrayList();
        grvMembers.Visible = true;
        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        grvMembers.Visible = true;
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_BudgetOfficersUrban_S]", arrIn, CommandType.StoredProcedure);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (txtnoofMember.Text != "")
            {
                //txtnoofMeeting.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                int new1 = Convert.ToInt32(txtnoofMember.Text.ToString());
                int old1 = (ds.Tables[0].Rows.Count);
                if (new1 == old1)
                {
                    txtnoofMember.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                    grvMembers.DataSource = ds;
                    grvMembers.DataBind();
                    disabletextboxmember();
                }
                else if (new1 > old1)
                {
                    SetGridDefaultCmntMember(cut, old1);

                }
            }
            else
            {
                grvMembers.DataSource = ds;
                grvMembers.DataBind();
                disabletextboxmember();
            }

        }
        else
        {
            if (cut == 0)
            {
                grvMembers.Visible = false;
                 
            }
            else
            {
                lblnoofMember.Visible = true;
                SetGridDefaultCmntMember(cut, 0);
                //disabletextboxmember();
            }

        }


    }
    private void SetGridDefaultCmntMember(int count, int old)
    {
        //for (int i = 0; i < count; i++)
        //{
        GlobalClass gblObj = new GlobalClass();
        ArrayList ar = new ArrayList();
        ar.Add("SLNO");
        ar.Add("intslno");
        ar.Add("chvnameofofficermal");
        ar.Add("chvAuditnameofofficermal");

        gblObj.SetGridDefaultfill(grvMembers, ar, count);
        if (old != 0)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            //GlobalClass gblObj = new GlobalClass();
            ds = objcom.FillData("[SP_tb_BudgetOfficersUrban_S]", arrIn, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (grvMembers.Items.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Label text1 = grvMembers.Items[i].FindControl("SLNO") as Label;
                        text1.Text = ds.Tables[0].Rows[i][0].ToString();
                        Label text11 = grvMembers.Items[i].FindControl("intslno") as Label;
                        text11.Text = ds.Tables[0].Rows[i][4].ToString();
                        
                        TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofofficermal") as TextBox;
                        text2.Text = ds.Tables[0].Rows[i][6].ToString();
                        TextBox text21 = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox;
                        text21.Text = ds.Tables[0].Rows[i][7].ToString();
                    }
                }

            }
        }



        for (int i = 0; i < count; i++)
        {
            TextBox aa = (TextBox)grvMembers.Items[i].FindControl("chvAuditnameofofficermal");
            aa.ReadOnly = true;
        }
        // }
    }
    public void disabletextboxmember()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvMembers.Items.Count; i++)
            {
                TextBox text1 = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofofficermal") as TextBox;
                text2.ReadOnly = true;

            }
        }
        else
        {
            for (int i = 0; i < grvMembers.Items.Count; i++)
            {
                TextBox text1 = grvMembers.Items[i].FindControl("chvnameofofficermal") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofofficermal") as TextBox;
                text2.ReadOnly = false;

            }
        }
    }
    protected void btnDeleteMem_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

        Label lb1 = item.FindControl("intslno") as Label;

        if (lb1.Text != "")
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
            arrIn.Add(Convert.ToInt32(lb1.Text));
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            int ep = objcom.Delete("[SP_tb_BudgetOfficers_D]", arrIn);
            txtnoofMember.Text = "";
            fillOfficers(0);
            Save_DataMembers();
            fillOfficers(0);
            if (ep > 0)
            {
                gblObj.MsgBoxOk("Deleted Successfully ", this);
                Session["Flag"] = 2;
            }
        }
        //else
        //{
        //    int i = grvMembers.Items.Count - 1;
        //    fillOfficers(i);
        //}
        Response.Redirect(Request.Url.ToString());
    }

    protected void grvMembers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (grvMembers.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }

    }
}