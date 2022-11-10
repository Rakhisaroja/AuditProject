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
public partial class Pages_Porting_Data_Urban : System.Web.UI.Page
{
    CommonClass objcomm = new CommonClass();
    ArrayList arrIn = new ArrayList();
    GlobalClass gblObj = new GlobalClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             chkStatus();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            //FillGramasabha();           
            Session["Flag"] = 0;
        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2")
        {
            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                disable();
                pnlfill.Visible = false;
            }

            else
            {
                pnlfill.Visible = true;
                Enable();

            }
        }
        else
        {
            pnlfill.Visible = false;
            disable();
        }


    }
    protected void btnBank_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("sp_SyncSaankhyaBankbalance", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnCentralFund_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaincomeexpendituremnregs]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
     
    protected void btngrant_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaotherspecialgrants]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnCash_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaloanrepayment]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btndirectBeni_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("sp_SyncSaankhyadirectbeneficiaryexpenditure", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
        //[]
    }
    protected void btnGeneral_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaexpenditure]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());

    }
    protected void btnnegative_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyanegativeincome]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnLoaanrepayment_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaloanrepayment]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnCash_Click1(object sender, EventArgs e)
    {

    }
    protected void btntaxnotaxAcrual_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaownfundaccrual]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());
         
    }
    protected void btntaxnontaxCash_Click(object sender, EventArgs e)
    {
        disable();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        int row = objcomm.update("[sp_SyncSaankhyaownfunddirect]", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Data Porting Successfully ", this);
            Session["Flag"] = 1;
        }
        Enable();
        Response.Redirect(Request.Url.ToString());  
    }
    public void disable()
    {
        btnBank.Enabled = false;
        btnCentralFund.Enabled = false;
        btndirectBeni.Enabled = false;
        btnGeneral.Enabled = false;
        btngrant.Enabled = false;
        btnLoaanrepayment.Enabled = false;
        btnnegative.Enabled = false;
        btntaxnontaxCash.Enabled = false;
        btntaxnotaxAcrual.Enabled = false;
        
    }
    public void Enable()
    {
        btnBank.Enabled = true;
        btnCentralFund.Enabled = true;
        btndirectBeni.Enabled = true;
        btnGeneral.Enabled = true;
        btngrant.Enabled = true;
        btnLoaanrepayment.Enabled = true;
        btnnegative.Enabled = true;
        btntaxnontaxCash.Enabled = true;
        btntaxnotaxAcrual.Enabled = true;

    }
}
