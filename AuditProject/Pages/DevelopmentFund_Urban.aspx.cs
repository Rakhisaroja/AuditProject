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

public partial class Pages_DevelopmentFund_Urban : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    CommonClass objCom = new CommonClass();
    int row;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();

            fillGrid();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        fillGrid();
    }
    public void ValueAssign()
    {

        if (Convert.ToInt32(Session["RoleID"]) == 2)
        {
            for (int i = 0; i < grvDevelopmentFund.Items.Count; i++)
            {
                TextBox T1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox;              
                TextBox T2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;               
                TextBox T3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox;              
                TextBox T4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;               
                TextBox T5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox;              
                TextBox T6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;


                Label T11 = grvDevelopmentFund.Items[i].FindControl("Prodalloc") as Label;                 
                Label T21 = grvDevelopmentFund.Items[i].FindControl("Prodexp") as Label;                
                Label T31 = grvDevelopmentFund.Items[i].FindControl("Servalloc") as Label;                
                Label T41 = grvDevelopmentFund.Items[i].FindControl("Servexp") as Label;                
                Label T51 = grvDevelopmentFund.Items[i].FindControl("Infraalloc") as Label;               
                Label T61 = grvDevelopmentFund.Items[i].FindControl("Infraexp") as Label;

                T1.Text = T11.Text;
                T2.Text = T21.Text;
                T3.Text = T31.Text;
                T4.Text = T41.Text;
                T5.Text = T51.Text;
                T6.Text = T61.Text;            
                
            }
        }
    }
    public void setEditable()
    {

        if (Convert.ToInt32(Session["RoleID"]) == 2)
        {
            for (int i = 0; i < grvDevelopmentFund.Items.Count; i++)
            {
                TextBox T1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox;
                T1.ReadOnly = true;
                TextBox T2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;
                T2.ReadOnly = true;
                TextBox T3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox;
                T3.ReadOnly = true;
                TextBox T4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;
                T4.ReadOnly = true;
                TextBox T5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox;
                T5.ReadOnly = true;
                TextBox T6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;

                T6.ReadOnly = true;
            }
        }
        else
        {
            for (int i = 0; i < grvDevelopmentFund.Items.Count; i++)
            {
                TextBox T1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox;
                T1.ReadOnly = false;
                TextBox T2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;
                T2.ReadOnly = false;
                TextBox T3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox;
                T3.ReadOnly = false;
                TextBox T4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;
                T4.ReadOnly = false;
                TextBox T5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox;
                T5.ReadOnly = false;
                TextBox T6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;

                T6.ReadOnly = false;
            }
        }
    }
    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();
        arrIn.Clear();
        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        DataSet ds = new DataSet();
        ds = objCom.FillData("[SP_tb_devfundsec_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvDevelopmentFund.DataSource = ds;
            grvDevelopmentFund.DataBind();
            for (int i = 0; i < grvDevelopmentFund.Items.Count; i++)
            {
                Label FundSrcId = grvDevelopmentFund.Items[i].FindControl("FundSrcId") as Label;
                if (Convert.ToInt32(FundSrcId.Text.ToString()) == 99)
                {
                    TextBox txt1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox;
                    txt1.Enabled = false;
                    TextBox txt2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;
                    txt2.Enabled = false;
                    TextBox txt3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox;
                    txt3.Enabled = false;
                    TextBox txt4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;
                    txt4.Enabled = false;
                    TextBox txt5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox;
                    txt5.Enabled = false;
                    TextBox txt6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;
                    txt6.Enabled = false;
                }
               // -------------------
                //if (Convert.ToInt32(Session["RoleID"]) == 2)
                //{
                //    TextBox T1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox;
                //    T1.ReadOnly = true;
                //    TextBox T2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;
                //    T2.ReadOnly = true;
                //    TextBox T3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox;
                //    T3.ReadOnly = true;
                //    TextBox T4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;
                //    T4.ReadOnly = true;
                //    TextBox T5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox;
                //    T5.ReadOnly = true;
                //    TextBox T6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;
                //    T6.ReadOnly = true;
                //}
               
                //---------------
            }
        }
        setEditable();
    }
    public void Save_Data()
    
    {

        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ArrayList arrProd = new ArrayList();
        ArrayList arrServ = new ArrayList();
        ArrayList arrInfra = new ArrayList();

        for (int i = 0; i < grvDevelopmentFund.Items.Count; i++)
        {
            arrProd.Clear();
            arrServ.Clear();
            arrInfra.Clear();
            Label lblLBId = grvDevelopmentFund.Items[i].FindControl("LBId") as Label;
            Label lblYearId = grvDevelopmentFund.Items[i].FindControl("FinYearId") as Label;
            Label lblFundSrcId = grvDevelopmentFund.Items[i].FindControl("FundSrcId") as Label;
            Label lblProdid = grvDevelopmentFund.Items[i].FindControl("Prodid") as Label;
            Label lblServid = grvDevelopmentFund.Items[i].FindControl("Servid") as Label;
            Label lblInfraid = grvDevelopmentFund.Items[i].FindControl("Infraid") as Label;
            arrProd.Add(Convert.ToInt32(lblLBId.Text.ToString()));
            arrProd.Add(Convert.ToInt32(lblYearId.Text.ToString()));
            arrProd.Add(Convert.ToInt32(lblFundSrcId.Text.ToString()));
            arrProd.Add(Convert.ToInt32(lblProdid.Text.ToString()));
            //--------
            arrServ.Add(Convert.ToInt32(lblLBId.Text.ToString()));
            arrServ.Add(Convert.ToInt32(lblYearId.Text.ToString()));
            arrServ.Add(Convert.ToInt32(lblFundSrcId.Text.ToString()));
            arrServ.Add(Convert.ToInt32(lblServid.Text.ToString()));
            //-------
            arrInfra.Add(Convert.ToInt32(lblLBId.Text.ToString()));
            arrInfra.Add(Convert.ToInt32(lblYearId.Text.ToString()));
            arrInfra.Add(Convert.ToInt32(lblFundSrcId.Text.ToString()));
            arrInfra.Add(Convert.ToInt32(lblInfraid.Text.ToString()));
            if (Convert.ToInt32(lblFundSrcId.Text.ToString()) != 99)
            {
                TextBox txtData1 = grvDevelopmentFund.Items[i].FindControl("ProdallocAud") as TextBox; //@numauditedobamount 
                if (txtData1.Text == "")
                {
                    arrProd.Add(DBNull.Value);
                }
                else
                {
                    arrProd.Add(Convert.ToDouble(txtData1.Text.ToString()));
                }
                TextBox txtData2 = grvDevelopmentFund.Items[i].FindControl("ProdexpAud") as TextBox;
                if (txtData2.Text == "")
                {
                    arrProd.Add(DBNull.Value);
                }
                else
                {
                    arrProd.Add(Convert.ToDouble(txtData2.Text.ToString()));
                }
                row = objCom.update("SP_tb_devfundsec_U", arrProd);
                arrProd.Clear();
                //------------------------------------
                TextBox txtData3 = grvDevelopmentFund.Items[i].FindControl("ServallocAud") as TextBox; //@numauditedobamount 
                if (txtData3.Text == "")
                {
                    arrServ.Add(DBNull.Value);
                }
                else
                {
                    arrServ.Add(Convert.ToDouble(txtData3.Text.ToString()));
                }
                TextBox txtData4 = grvDevelopmentFund.Items[i].FindControl("ServexpAud") as TextBox;
                if (txtData4.Text == "")
                {
                    arrServ.Add(DBNull.Value);
                }
                else
                {
                    arrServ.Add(Convert.ToDouble(txtData4.Text.ToString()));
                }
                row = objCom.update("SP_tb_devfundsec_U", arrServ);
                arrServ.Clear();
                //-----------------------------
                TextBox txtData5 = grvDevelopmentFund.Items[i].FindControl("InfraallocAud") as TextBox; //@numauditedobamount 
                if (txtData5.Text == "")
                {
                    arrInfra.Add(DBNull.Value);
                }
                else
                {
                    arrInfra.Add(Convert.ToDouble(txtData5.Text.ToString()));
                }
                TextBox txtData6 = grvDevelopmentFund.Items[i].FindControl("InfraexpAud") as TextBox;
                if (txtData6.Text == "")
                {
                    arrInfra.Add(DBNull.Value);
                }
                else
                {
                    arrInfra.Add(Convert.ToDouble(txtData6.Text.ToString()));
                }
                row = objCom.update("SP_tb_devfundsec_U", arrInfra);
                arrInfra.Clear();
                //-----------------------------
            }
        }
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved successfully ", this);
        }
    }
    protected void grvMergeHeader_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceAllocation_Urban.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceExpense_Urban.aspx");
    }
}
