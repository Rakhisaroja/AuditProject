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
public partial class Pages_TaxNontaxCashDetails_Urban : System.Web.UI.Page
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
        for (int i = 0; i < rptCash.Items.Count; i++)
        {
            TextBox numCurrentamount = rptCash.Items[i].FindControl("numCurrentamount") as TextBox;
            TextBox numauditedcurrentamount = rptCash.Items[i].FindControl("numauditedcurrentamount") as TextBox;


      
            numauditedcurrentamount.Text = numCurrentamount.Text;
        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < rptCash.Items.Count; i++)
            //{
            //    TextBox numCurrentamount = rptCash.Items[i].FindControl("numCurrentamount") as TextBox;

            //    numCurrentamount.ReadOnly = true;
            //}
        }
        else
        {
            for (int i = 0; i < rptCash.Items.Count; i++)
            {
                TextBox numauditedcurrentamount = rptCash.Items[i].FindControl("numauditedcurrentamount") as TextBox;
              

                numauditedcurrentamount.ReadOnly = false;
               
            }
        }

    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_ownfunddirectincome_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptCash.DataSource = dsFill;
            rptCash.DataBind();
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
        for (int i = 0; i < rptCash.Items.Count; i++)
        {
            Label lblNumId = rptCash.Items[i].FindControl("lblNumId") as Label;
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
            Label lblincometype = rptCash.Items[i].FindControl("lblincometype") as Label;
            if (lblincometype.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblincometype.Text));
            }
            Label vchaccountheadcode = rptCash.Items[i].FindControl("vchaccountheadcode") as Label;
            if (vchaccountheadcode.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(vchaccountheadcode.Text));
            }

            Label lblccounthead = rptCash.Items[i].FindControl("lblccounthead") as Label;
            if (lblccounthead.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(lblccounthead.Text);
            }
            arrIn.Add(1);

            TextBox numCurrentamount = rptCash.Items[i].FindControl("numCurrentamount") as TextBox;
            if (numCurrentamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numCurrentamount.Text));
            }

            TextBox numauditedcurrentamount = rptCash.Items[i].FindControl("numauditedcurrentamount") as TextBox;
            if ((numauditedcurrentamount.Text == "") || (numauditedcurrentamount.Text == "0.00"))
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedcurrentamount.Text));
            }
            arrIn.Add(1);

            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
           
            int row = objcomm.update("SP_tb_ownfunddirectincome_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("TaxNonTaxAcrual_Urban.aspx");
    }
}
