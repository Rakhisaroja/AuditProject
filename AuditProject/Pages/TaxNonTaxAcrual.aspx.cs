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
public partial class Pages_TaxNonTaxAcrual : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            chkStatus();
            Filldata();
           
            Session["CurrentAmt"]="0";
            Session["ArrearAmt"]="0";
            Session["AdvanceAmt"]="0";

             Session["CurrentamountAudt"]="0";
            Session["ArrearamountAudt"]="0";
            Session["AdvanceamountAudt"] = "0";
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
        for (int i = 0; i < rptAcrual.Items.Count; i++)
        {
            TextBox txtincomeExpnditureamount = rptAcrual.Items[i].FindControl("txtincomeExpnditureamount") as TextBox;
            TextBox txtnumCurrentamount = rptAcrual.Items[i].FindControl("txtnumCurrentamount") as TextBox;
            TextBox txtnumArrearamount = rptAcrual.Items[i].FindControl("txtnumArrearamount") as TextBox;
            TextBox txtnumAdvanceamount = rptAcrual.Items[i].FindControl("txtnumAdvanceamount") as TextBox;
            TextBox txtnumTotalamount = rptAcrual.Items[i].FindControl("txtnumTotalamount") as TextBox;






            TextBox txtincomeExpnditureamountAudt = rptAcrual.Items[i].FindControl("txtincomeExpnditureamountAudt") as TextBox;
            TextBox txtnumCurrentamountAudt = rptAcrual.Items[i].FindControl("txtnumCurrentamountAudt") as TextBox;
            TextBox txtnumArrearamountAudt = rptAcrual.Items[i].FindControl("txtnumArrearamountAudt") as TextBox;

            TextBox txtnumAdvanceamountAudt = rptAcrual.Items[i].FindControl("txtnumAdvanceamountAudt") as TextBox;
            TextBox txtnumTotalamountAudt = rptAcrual.Items[i].FindControl("txtnumTotalamountAudt") as TextBox;


            txtincomeExpnditureamountAudt.Text = txtincomeExpnditureamount.Text;
            txtnumCurrentamountAudt.Text = txtnumCurrentamount.Text;
            txtnumArrearamountAudt.Text = txtnumArrearamount.Text;
            txtnumAdvanceamountAudt.Text = txtnumAdvanceamount.Text;
            txtnumTotalamountAudt.Text = txtnumTotalamount.Text;
        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < rptAcrual.Items.Count; i++)
            //{
            //    TextBox txtincomeExpnditureamount = rptAcrual.Items[i].FindControl("txtincomeExpnditureamount") as TextBox;
            //    TextBox txtnumCurrentamount = rptAcrual.Items[i].FindControl("txtnumCurrentamount") as TextBox;
            //    TextBox txtnumArrearamount = rptAcrual.Items[i].FindControl("txtnumArrearamount") as TextBox;
            //    TextBox txtnumAdvanceamount = rptAcrual.Items[i].FindControl("txtnumAdvanceamount") as TextBox;
            //    TextBox txtnumTotalamount = rptAcrual.Items[i].FindControl("txtnumTotalamount") as TextBox;
              
            //    txtincomeExpnditureamount.ReadOnly=true;
            //    txtnumCurrentamount.ReadOnly = true;
            //    txtnumArrearamount.ReadOnly = true;
            //    txtnumAdvanceamount.ReadOnly = true;
            //    txtnumTotalamount.ReadOnly = true;
            //}
        }
            else
            {
            for (int i = 0; i < rptAcrual.Items.Count; i++)
                {
                    TextBox txtincomeExpnditureamountAudt = rptAcrual.Items[i].FindControl("txtincomeExpnditureamountAudt") as TextBox;
                    TextBox txtnumCurrentamountAudt = rptAcrual.Items[i].FindControl("txtnumCurrentamountAudt") as TextBox;
                    TextBox txtnumArrearamountAudt = rptAcrual.Items[i].FindControl("txtnumArrearamountAudt") as TextBox;

                    TextBox txtnumAdvanceamountAudt = rptAcrual.Items[i].FindControl("txtnumAdvanceamountAudt") as TextBox;
                    TextBox txtnumTotalamountAudt = rptAcrual.Items[i].FindControl("txtnumTotalamountAudt") as TextBox;

                    txtincomeExpnditureamountAudt.ReadOnly=false;
                    txtnumCurrentamountAudt.ReadOnly=false;
                    txtnumArrearamountAudt.ReadOnly=false;
                    txtnumAdvanceamountAudt.ReadOnly=false;
                    txtnumTotalamountAudt.ReadOnly = false;
                }
            }
        
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
        for (int i = 0; i < rptAcrual.Items.Count; i++)
        {
            Label lblNumId = rptAcrual.Items[i].FindControl("lblNumId") as Label;
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
            Label lblincometype = rptAcrual.Items[i].FindControl("lblincometype") as Label;
            if (lblincometype.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblincometype.Text));
            }
            Label vchaccountheadcode = rptAcrual.Items[i].FindControl("vchaccountheadcode") as Label;
            if (vchaccountheadcode.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(vchaccountheadcode.Text));
            }

            Label lblccounthead = rptAcrual.Items[i].FindControl("lblccounthead") as Label;
            if (lblccounthead.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(lblccounthead.Text);
            }
            arrIn.Add(1);

            TextBox txtincomeExpnditureamount = rptAcrual.Items[i].FindControl("txtincomeExpnditureamount") as TextBox;
            if (txtincomeExpnditureamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtincomeExpnditureamount.Text));
            }

            TextBox txtnumCurrentamount = rptAcrual.Items[i].FindControl("txtnumCurrentamount") as TextBox;
            if (txtnumCurrentamount.Text == "")
            {
                Session["CurrentAmt"] = "0";
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumCurrentamount.Text));
                Session["CurrentAmt"] = txtnumCurrentamount.Text;
            }

            TextBox txtnumArrearamount = rptAcrual.Items[i].FindControl("txtnumArrearamount") as TextBox;
            if (txtnumArrearamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
                Session["ArrearAmt"] = "0";
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumArrearamount.Text));
                Session["ArrearAmt"] = txtnumArrearamount.Text;
            }

            TextBox txtnumAdvanceamount = rptAcrual.Items[i].FindControl("txtnumAdvanceamount") as TextBox;
            if (txtnumAdvanceamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
                Session["AdvanceAmt"] = "0";
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumAdvanceamount.Text));
                Session["AdvanceAmt"] = txtnumAdvanceamount.Text;
            }


            TextBox txtnumTotalamount = rptAcrual.Items[i].FindControl("txtnumTotalamount") as TextBox;
            double tot =  (Convert.ToDouble(Session["CurrentAmt"]) + Convert.ToDouble(Session["ArrearAmt"]) + Convert.ToDouble(Session["AdvanceAmt"]));

            txtnumTotalamount.Text = tot.ToString();
           
            arrIn.Add(Convert.ToDouble(txtnumTotalamount.Text));
           


            TextBox txtincomeExpnditureamountAudt = rptAcrual.Items[i].FindControl("txtincomeExpnditureamountAudt") as TextBox;
            if (txtincomeExpnditureamountAudt.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtincomeExpnditureamountAudt.Text));
            }

            TextBox txtnumCurrentamountAudt = rptAcrual.Items[i].FindControl("txtnumCurrentamountAudt") as TextBox;
            if (txtnumCurrentamountAudt.Text == "")
            {
                arrIn.Add(DBNull.Value);
                Session["CurrentamountAudt"] = "0";
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumCurrentamountAudt.Text));
                Session["CurrentamountAudt"] = txtnumCurrentamountAudt.Text;
            }


            TextBox txtnumArrearamountAudt = rptAcrual.Items[i].FindControl("txtnumArrearamountAudt") as TextBox;
            if (txtnumArrearamountAudt.Text == "")
            {
                arrIn.Add(DBNull.Value);
                Session["ArrearamountAudt"] = "0";
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumArrearamountAudt.Text));
                Session["ArrearamountAudt"] = txtnumArrearamountAudt.Text;
            }

            TextBox txtnumAdvanceamountAudt = rptAcrual.Items[i].FindControl("txtnumAdvanceamountAudt") as TextBox;
            if (txtnumAdvanceamountAudt.Text == "")
            {
                arrIn.Add(DBNull.Value);

                Session["AdvanceamountAudt"] = "0";
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumAdvanceamountAudt.Text));
                Session["AdvanceamountAudt"] = txtnumAdvanceamountAudt.Text;
            }
           
            TextBox txtnumTotalamountAudt = rptAcrual.Items[i].FindControl("txtnumTotalamountAudt") as TextBox;
            double totAudt = (Convert.ToDouble(Session["CurrentamountAudt"]) + Convert.ToDouble(Session["ArrearamountAudt"]) + Convert.ToDouble(Session["AdvanceamountAudt"]));

            txtnumTotalamountAudt.Text = totAudt.ToString();

            if (txtnumTotalamountAudt.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtnumTotalamountAudt.Text));
            }
            arrIn.Add(1);

            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
           
            int row = objcomm.update("SP_tb_ownfundaccrualincome_IU", arrIn);
            arrIn.Clear();
           
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
         
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_ownfundaccrualincome_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptAcrual.DataSource = dsFill;
            rptAcrual.DataBind();
        }
        SetEditable();
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("TaxNontaxCashDetails.aspx");
    }
}
