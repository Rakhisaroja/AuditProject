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
public partial class Pages_Porting_Data : System.Web.UI.Page
{
    CommonClass objcomm = new CommonClass();
   
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
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

        if ((Session["LBType"].ToString() == "1")||(Session["LBType"].ToString() == "2")||(Session["LBType"].ToString() == "5"))
        {
              row = objcomm.update("sp_SyncSaankhyaBankbalance", arrIn);
        }
        else if((Session["LBType"].ToString() == "3")||(Session["LBType"].ToString() == "4"))
        {
              row = objcomm.update("sp_SyncSaankhyaBankbalanceUrban", arrIn);
        }
        
        //Urban
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

     //   int row = objcomm.update("[sp_SyncSaankhyaincomeexpendituremnregs]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaincomeexpendituremnregs", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaincomeexpendituremnregsUrban", arrIn);
        }
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

       // int row = objcomm.update("[sp_SyncSaankhyaotherspecialgrants]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaotherspecialgrants", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaotherspecialgrantsUrban", arrIn);
        }
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

       // int row = objcomm.update("[sp_SyncSaankhyaloanrepayment]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaloanrepayment", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaloanrepaymentUrban", arrIn);
        } 
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

     //   int row = objcomm.update("sp_SyncSaankhyadirectbeneficiaryexpenditure", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyadirectbeneficiaryexpenditure", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyadirectbeneficiaryexpenditureUrban", arrIn);
        } 
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

        //int row = objcomm.update("[sp_SyncSaankhyaexpenditure]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaexpenditure", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaexpenditureUrban", arrIn);
        }
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
        ArrayList arrIn = new ArrayList();
        disable();
        int row = 0;
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

       // int row = objcomm.update("[sp_SyncSaankhyanegativeincome]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyanegativeincome", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyanegativeincomeUrban", arrIn);
        }
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
        int row = 0;
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

      //  int row = objcomm.update("[sp_SyncSaankhyaloanrepayment]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaloanrepayment", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaloanrepaymentUrban", arrIn);
        } 
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
        int row = 0;
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

       // int row = objcomm.update("[sp_SyncSaankhyaownfundaccrual]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaownfundaccrual", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaownfundaccrualUrban", arrIn);
        } 
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
        int row = 0;
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"] 
        arrIn.Add(Convert.ToInt32(Session["FinYear"])); //Session["FinYear"]

        //int row = objcomm.update("[sp_SyncSaankhyaownfunddirect]", arrIn);
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            row = objcomm.update("sp_SyncSaankhyaownfunddirect", arrIn);
        }
        else if ((Session["LBType"].ToString() == "3") || (Session["LBType"].ToString() == "4"))
        {
            row = objcomm.update("sp_SyncSaankhyaownfunddirectUrban", arrIn);
        }
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
