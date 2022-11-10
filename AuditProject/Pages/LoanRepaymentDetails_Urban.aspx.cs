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
public partial class Pages_LoanRepaymentDetails_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            chkStatus();
            Filldata();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Submitted Successfully ", this);
            }
            //FillGramasabha();           
            Session["Flag"] = 0;

           
        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                Button1.Enabled = false;
                btnNew.Enabled = false;
            }
            else
            {
                Button1.Enabled = true;
                btnNew.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button1.Enabled = true;
                btnNew.Enabled = false;
            }
            else
            {
                Button1.Enabled = false;
                btnNew.Enabled = false;
            }
        }


    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptLoanRepayment.Items.Count; i++)
        {
            TextBox numob = rptLoanRepayment.Items[i].FindControl("numob") as TextBox;
            TextBox numrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numrecurrentpayment") as TextBox;
            TextBox numcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numcurrentreceipt") as TextBox;
            TextBox numbalance = rptLoanRepayment.Items[i].FindControl("numbalance") as TextBox;
            TextBox chvremarks = rptLoanRepayment.Items[i].FindControl("chvremarks") as TextBox;


            TextBox numauditedob = rptLoanRepayment.Items[i].FindControl("numauditedob") as TextBox;
            TextBox numauditedrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numauditedrecurrentpayment") as TextBox;
            TextBox numauditedcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numauditedcurrentreceipt") as TextBox;
            TextBox numauditedbalance = rptLoanRepayment.Items[i].FindControl("numauditedbalance") as TextBox;
            TextBox chvauditedremarks = rptLoanRepayment.Items[i].FindControl("chvauditedremarks") as TextBox;

            numauditedob.Text = numob.Text;
            numauditedrecurrentpayment.Text = numrecurrentpayment.Text;
            numauditedcurrentreceipt.Text = numcurrentreceipt.Text;
            numauditedbalance.Text = numbalance.Text;
            chvauditedremarks.Text = chvremarks.Text;
        }
    }
    public void SetEditablelics()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptLoanRepayment.Items.Count; i++)
            {
                TextBox numob = rptLoanRepayment.Items[i].FindControl("numob") as TextBox;
                TextBox numrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numrecurrentpayment") as TextBox;
                TextBox numcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numcurrentreceipt") as TextBox;
                TextBox numbalance = rptLoanRepayment.Items[i].FindControl("numbalance") as TextBox;
                TextBox chvremarks = rptLoanRepayment.Items[i].FindControl("chvremarks") as TextBox;

                numob.ReadOnly = false;
                numrecurrentpayment.ReadOnly = false;
                numcurrentreceipt.ReadOnly = false;
                numbalance.ReadOnly = false;
                chvremarks.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < rptLoanRepayment.Items.Count; i++)
            {

                TextBox numauditedob = rptLoanRepayment.Items[i].FindControl("numauditedob") as TextBox;
                TextBox numauditedrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numauditedrecurrentpayment") as TextBox;
                TextBox numauditedcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numauditedcurrentreceipt") as TextBox;
                TextBox numauditedbalance = rptLoanRepayment.Items[i].FindControl("numauditedbalance") as TextBox;
                TextBox chvauditedremarks = rptLoanRepayment.Items[i].FindControl("chvauditedremarks") as TextBox;

                numauditedob.ReadOnly = false;
                numauditedrecurrentpayment.ReadOnly = false;
                numauditedcurrentreceipt.ReadOnly = false;
                numauditedbalance.ReadOnly = false;
                chvauditedremarks.ReadOnly = false;


            }
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_loanrepayment_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptLoanRepayment.DataSource = dsFill;
            rptLoanRepayment.DataBind();

            Control FooterTemplate = rptLoanRepayment.Controls[rptLoanRepayment.Controls.Count - 1].Controls[0];

            Label totnumob = FooterTemplate.FindControl("totnumob") as Label;
            totnumob.Text = dsFill.Tables[0].Rows[0][21].ToString();

            Label totnumrecurrentpayment = FooterTemplate.FindControl("totnumrecurrentpayment") as Label;
            totnumrecurrentpayment.Text = dsFill.Tables[0].Rows[0][22].ToString();

            Label totnumcurrentreceipt = FooterTemplate.FindControl("totnumcurrentreceipt") as Label;
            totnumcurrentreceipt.Text = dsFill.Tables[0].Rows[0][23].ToString();



              


            Label totnumbalance = FooterTemplate.FindControl("totnumbalance") as Label;
            totnumbalance.Text = dsFill.Tables[0].Rows[0][24].ToString();

            Label totnumauditedob = FooterTemplate.FindControl("totnumauditedob") as Label;
            totnumauditedob.Text = dsFill.Tables[0].Rows[0][25].ToString();

            Label totnumauditedrecurrentpayment = FooterTemplate.FindControl("totnumauditedrecurrentpayment") as Label;
            totnumauditedrecurrentpayment.Text = dsFill.Tables[0].Rows[0][26].ToString();

            Label totnumauditedcurrentreceipt = FooterTemplate.FindControl("totnumauditedcurrentreceipt") as Label;
            totnumauditedcurrentreceipt.Text = dsFill.Tables[0].Rows[0][27].ToString();

            Label totnumauditedbalance = FooterTemplate.FindControl("totnumauditedbalance") as Label;
            totnumauditedbalance.Text = dsFill.Tables[0].Rows[0][28].ToString();

        }
        SetEditablelics();
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
        arrIn.Clear();
        for (int i = 0; i < rptLoanRepayment.Items.Count; i++)
        {
            Label lblNumId = rptLoanRepayment.Items[i].FindControl("lblNumId") as Label;
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
            arrIn.Add(i);
            //Label lblincometype = rptNegative.Items[i].FindControl("lblincometype") as Label;
            //if (lblincometype.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToInt32(lblincometype.Text));
            //}
            Label vchaccountheadcode = rptLoanRepayment.Items[i].FindControl("vchaccountheadcode") as Label;
            if (vchaccountheadcode.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(vchaccountheadcode.Text));
            }

            Label lblccounthead = rptLoanRepayment.Items[i].FindControl("lblccounthead") as Label;
            if (lblccounthead.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(lblccounthead.Text);
            }
            arrIn.Add(1);





            TextBox numob = rptLoanRepayment.Items[i].FindControl("numob") as TextBox;
            if (numob.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numob.Text));
            }


            TextBox numrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numrecurrentpayment") as TextBox;
            if (numrecurrentpayment.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numrecurrentpayment.Text));
            }
            TextBox numcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numcurrentreceipt") as TextBox;
            if (numcurrentreceipt.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numcurrentreceipt.Text));
            }
            TextBox numbalance = rptLoanRepayment.Items[i].FindControl("numbalance") as TextBox;
            if (numbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numbalance.Text));
            }
            TextBox chvremarks = rptLoanRepayment.Items[i].FindControl("chvremarks") as TextBox;
            if (chvremarks.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(chvremarks.Text);
            }
            TextBox numauditedob = rptLoanRepayment.Items[i].FindControl("numauditedob") as TextBox;
            if (numauditedob.Text == "")
            {
                //if (numob.Text != "")
                //{

                //    arrIn.Add(Convert.ToDouble(numob.Text));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedob.Text));
            }
            TextBox numauditedrecurrentpayment = rptLoanRepayment.Items[i].FindControl("numauditedrecurrentpayment") as TextBox;
            if (numauditedrecurrentpayment.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedrecurrentpayment.Text));
            }
            TextBox numauditedcurrentreceipt = rptLoanRepayment.Items[i].FindControl("numauditedcurrentreceipt") as TextBox;
            if (numauditedcurrentreceipt.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedcurrentreceipt.Text));
            }
            TextBox numauditedbalance = rptLoanRepayment.Items[i].FindControl("numauditedbalance") as TextBox;
            if (numauditedbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedbalance.Text));
            }
            TextBox chvauditedremarks = rptLoanRepayment.Items[i].FindControl("chvauditedremarks") as TextBox;
            if (chvauditedremarks.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(chvauditedremarks.Text);
            }

            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int row = objcomm.update("SP_tb_loanrepayment_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }

    }

    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (txtType.Text == "")
        {
           
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Type') ;", true);

            gblObj.setFocus(txtType, this);
            return false;

        }


        else if (txtOB.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter OB') ;", true);

            gblObj.setFocus(txtOB, this);
            return false;
        }
      

        return true;
    }
    public void SaveNew()
    {
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(0);

        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrIn.Add(1);
        arrIn.Add(111);
        if (txtType.Text != "")
        {
            arrIn.Add(txtType.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(1);

        if (txtOB.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOB.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtrecurrentpayment.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtrecurrentpayment.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (Txtcurrentreceipt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(Txtcurrentreceipt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (TxtBal.Text  != "")
        {
            arrIn.Add(Convert.ToDouble(TxtBal.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (TxtRem.Text != "")
        {
            arrIn.Add(TxtRem.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        if (txtOB.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOB.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtrecurrentpayment.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtrecurrentpayment.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (Txtcurrentreceipt.Text != "")
        {
            arrIn.Add(Convert.ToDouble(Txtcurrentreceipt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (TxtBal.Text  != "")
        {
            arrIn.Add(Convert.ToDouble(TxtBal.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (TxtRem.Text != "")
        {
            arrIn.Add(TxtRem.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        arrIn.Add(1);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

        int row = objcom.update("SP_tb_loanrepayment_IU", arrIn);
         if (row > 0)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Submitted Successfully!!";
            gblObj.MsgBoxOk("Submitted Successfully ", this);

            Session["Flag"] = 1;
        }
          
        Response.Redirect(Request.Url.ToString());

 }
    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        if (Validation() == true)
        {
            SaveNew();
            pnlNewEntry.Visible = false;
            Filldata();
           
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNewEntry.Visible = true;
        clearTexts();
    }
    public void clearTexts()
    {
        txtType.Text = "";
        txtOB.Text = "";
        txtrecurrentpayment.Text = "";
        Txtcurrentreceipt.Text = "";
        TxtBal.Text = "";
        TxtRem.Text = "";
    }
}
