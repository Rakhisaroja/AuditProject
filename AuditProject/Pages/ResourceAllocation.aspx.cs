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
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using AuditClassLibrary;
using System.Data.SqlClient;

public partial class Pages_ResourceAllocation : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    CommonClass objCom = new CommonClass();
    int row;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillGrid();
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

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < rptPublicWrk.Items.Count; i++)
            //{
            //    TextBox fltDevFund = rptPublicWrk.Items[i].FindControl("fltDevFund") as TextBox;
            //    TextBox fltMG = rptPublicWrk.Items[i].FindControl("fltMG") as TextBox;

            //    TextBox fltOwnFund = rptPublicWrk.Items[i].FindControl("fltOwnFund") as TextBox;
            //    TextBox fltOtherFund = rptPublicWrk.Items[i].FindControl("fltOtherFund") as TextBox;

            //    TextBox fltDevFundExp = rptPublicWrk.Items[i].FindControl("fltDevFundExp") as TextBox;
            //    TextBox fltMGExp = rptPublicWrk.Items[i].FindControl("fltMGExp") as TextBox;

            //    TextBox fltOwnFundExp = rptPublicWrk.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //    TextBox fltOtherFundExp = rptPublicWrk.Items[i].FindControl("fltOtherFundExp") as TextBox;

            //    fltDevFund.ReadOnly = false;
            //    fltMG.ReadOnly = false;

            //    fltOwnFund.ReadOnly = false;
            //    fltOtherFund.ReadOnly = false;

            //    fltDevFundExp.ReadOnly = false;
            //    fltMGExp.ReadOnly = false;

            //    fltOwnFundExp.ReadOnly = false;
            //    fltOtherFundExp.ReadOnly = false;

            //}
        }
        else
        {
            for (int i = 0; i < grvResourceAllocation.Items.Count; i++)
            {
                TextBox txt1 = grvResourceAllocation.Items[i].FindControl("fltaudalloc") as TextBox;
              
                TextBox txt2 = grvResourceAllocation.Items[i].FindControl("fltaudexpense") as TextBox;
               
                TextBox txt3 = grvResourceAllocation.Items[i].FindControl("tnyaudper") as TextBox;

                txt1.ReadOnly = false;

                txt2.ReadOnly = false;
                txt3.ReadOnly = false;
            }
        }

    }
    public void ValueAssign()
    {
        for (int i = 0; i < grvResourceAllocation.Items.Count; i++)
        {
            Label fltalloc = grvResourceAllocation.Items[i].FindControl("fltalloc") as Label;
            Label fltexpense = grvResourceAllocation.Items [i].FindControl("fltexpense") as Label;

            Label tnyper = grvResourceAllocation.Items[i].FindControl("tnyper") as Label;


            TextBox txt1 = grvResourceAllocation.Items[i].FindControl("fltaudalloc") as TextBox;

            TextBox txt2 = grvResourceAllocation.Items[i].FindControl("fltaudexpense") as TextBox;

            TextBox txt3 = grvResourceAllocation.Items[i].FindControl("tnyaudper") as TextBox;

            txt1.Text = fltalloc.Text;
            txt2.Text = fltexpense.Text;

            txt3.Text = tnyper.Text;
           
        }
    }
    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();
        arrIn.Clear();
        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        DataSet ds = new DataSet();
        ds = objCom.FillData("[SP_tb_resourcealloc_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvResourceAllocation.DataSource = ds;
            grvResourceAllocation.DataBind();
            for (int i = 0; i < grvResourceAllocation.Items.Count; i++)
            {
                Label FundSrcId = grvResourceAllocation.Items[i].FindControl("FundSrcId") as Label;
                if (Convert.ToInt32(FundSrcId.Text.ToString()) == 99)
                {
                    TextBox txt1 = grvResourceAllocation.Items[i].FindControl("fltaudalloc") as TextBox;
                    txt1.Enabled = false;
                    TextBox txt2 = grvResourceAllocation.Items[i].FindControl("fltaudexpense") as TextBox;
                    txt2.Enabled = false;
                    TextBox txt3 = grvResourceAllocation.Items[i].FindControl("tnyaudper") as TextBox;
                    txt3.Enabled = false;
                    ArrayList arrAmt = new ArrayList();
                    arrAmt.Clear();
                    arrAmt.Add(Convert.ToInt32(Session["LBID"]));
                    arrAmt.Add(Convert.ToInt32(Session["Year"]));
                    DataSet dsAmt = new DataSet();
                    dsAmt = objCom.FillData("[SP_tb_resourcealloc_AmtTot]", arrAmt, CommandType.StoredProcedure);
                    if (dsAmt.Tables[0].Rows.Count > 0)
                    {
                      double perAud=0.0,allAud=0.0, expAud=0.0;
                        allAud = Convert.ToDouble(dsAmt.Tables[0].Rows[0].ItemArray[0].ToString());
                        expAud = Convert.ToDouble(dsAmt.Tables[0].Rows[0].ItemArray[1].ToString());
                        if (allAud != 0)
                        {
                            perAud = Math.Round(((expAud / allAud) * 100), 2);
                        }
                       txt1.Text = allAud.ToString();
                       txt2.Text = expAud.ToString();
                       txt3.Text = perAud.ToString();
                    }
                }
                //---------------------------------
                //if (Convert.ToInt32(Session["RoleID"]) == 2)
                //{
                //    TextBox T1 = grvResourceAllocation.Items[i].FindControl("fltaudalloc") as TextBox;
                //    T1.ReadOnly = true;
                //    TextBox T2 = grvResourceAllocation.Items[i].FindControl("fltaudexpense") as TextBox;
                //    T2.ReadOnly = true;
                //    TextBox T3 = grvResourceAllocation.Items[i].FindControl("tnyaudper") as TextBox;
                //    T3.ReadOnly = true;
                //}
                //-------------------------------
            }
            
    }
    SetEditable();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
            Save_Data();
            fillGrid();
        
    }
    private void SetGridDevelopmentFund()
    {
        ArrayList ar = new ArrayList();
        ar.Clear();
        ar.Add("SlNo");
        ar.Add("chvFundSource");
        ar.Add("fltalloc");
        ar.Add("fltexpense");
        ar.Add("tnyper");
        ar.Add("fltaudalloc");
        ar.Add("fltaudexpense");
        ar.Add("tnyaudper");
        gblObj.SetGridDefault(grvResourceAllocation, ar);
    }
    protected void grvResourceAllocation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    public void Save_Data()
    {
    
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ArrayList arrIn = new ArrayList();
        arrIn.Clear();
        for (int i = 0; i < grvResourceAllocation.Items.Count; i++)
        {
            Label lblLBId = grvResourceAllocation.Items[i].FindControl("LBId") as Label;
            Label lblYearId = grvResourceAllocation.Items[i].FindControl("FinYearId") as Label;
            Label lblFundSrcId = grvResourceAllocation.Items[i].FindControl("FundSrcId") as Label;
            arrIn.Add(Convert.ToInt32(lblLBId.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblYearId.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblFundSrcId.Text.ToString()));
            if (Convert.ToInt32(lblFundSrcId.Text.ToString()) != 99)
            {
                TextBox txtData1 = grvResourceAllocation.Items[i].FindControl("fltaudalloc") as TextBox; //@numauditedobamount 
                if (txtData1.Text == "")
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(Convert.ToDouble(txtData1.Text.ToString()));
                }
                //-------------
                TextBox txtData2 = grvResourceAllocation.Items[i].FindControl("fltaudexpense") as TextBox;
                if (txtData2.Text == "")
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
                }
                //-------------
                TextBox txtData3 = grvResourceAllocation.Items[i].FindControl("tnyaudper") as TextBox;
                if (txtData3.Text == "")
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(Convert.ToDouble(txtData3.Text.ToString()));
                }
                //-------------
                row = objCom.update("SP_tb_resourcealloc_U", arrIn);
                arrIn.Clear();
            }
            //if (Convert.ToInt32(lblFundSrcId.Text.ToString()) == 99)
            //{

            //}
        }
      if (row > 0)
            {
                gblObj.MsgBoxOk("Saved successfully ", this);
            }
    }
    protected void grvResourceAllocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DevelopmentFund.aspx");
    }
}
