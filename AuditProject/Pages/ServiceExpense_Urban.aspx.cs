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
public partial class Pages_ServiceExpense_Urban : System.Web.UI.Page
{
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

    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvGenralAdminService.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminService.Items[i].FindControl("txtexpamounttotal") as TextBox;

                TextBox txtData11 = grvGenralAdminService.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.Text = txtData1.Text;
            }
        }
    }

    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvGenralAdminService.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminService.Items[i].FindControl("txtexpamounttotal") as TextBox;
                txtData1.ReadOnly = false;

                TextBox txtData11 = grvGenralAdminService.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.ReadOnly = true;
            }          
           

        }
        else
        {

            for (int i = 0; i < grvGenralAdminService.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminService.Items[i].FindControl("txtexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;

                TextBox txtData11 = grvGenralAdminService.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.ReadOnly = false;

            }
            
        }
    }
    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(2);  ///MainexpenType
        arrIn.Add(1);  //subExpenTYpe
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_expenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvGenralAdminService.DataSource = ds;
            grvGenralAdminService.DataBind();
            Control FooterTemplate = grvGenralAdminService.Controls[grvGenralAdminService.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("amounttotal") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][9].ToString();

            Label incometot1 = FooterTemplate.FindControl("Auditamounttotal") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][10].ToString();

            //double tot = 0;
            //double Atot = 0;
            //tot = Convert.ToDouble(lblGtot.Text);
            //Atot = Convert.ToDouble(lblAuditGtot.Text);

            //tot += Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());
            //Atot += Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());

            //lblGtot.Text = tot.ToString();
            //lblAuditGtot.Text = Atot.ToString();
        }
        disabletextbox();
    }
 




    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvGenralAdminService.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvGenralAdminService.Items[i].FindControl("mainexpendituretype") as Label;   ////@@intmainexpendituretype ,
            Label lblData2 = grvGenralAdminService.Items[i].FindControl("subexpendituretype") as Label;   ////@@intsubexpendituretype ,
            Label lblData3 = grvGenralAdminService.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData2.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
            TextBox lblData41 = grvGenralAdminService.Items[i].FindControl("txtexpamounttotal") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvGenralAdminService.Items[i].FindControl("txtauditedexpamounttotal") as TextBox; //@numauditedobamount 
            if (txtData1.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData1.Text.ToString()));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_expenditure_U", arrIn);

            GlobalClass gblObj = new GlobalClass();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save_Data();
        fillGrid();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvGenralAdminService.Items)
        {
            //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
            //Label lblData = item.FindControl("intparticipantfemale") as Label;
            //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_Data();
    }

    protected void grvGenralAdminService_ItemCommand(object source, RepeaterCommandEventArgs e)
    {      
        //Int32 expamounttotal = 0;
        //Int32 Auditexpamounttotal = 0;
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
            
        //    expamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2]);
        //    Auditexpamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4]);
        //    TextBox Data1 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("numexpamounttotal") as TextBox;
        //    Data1.Text= expamounttotal.ToString();

        //    TextBox Data2 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("Auditexpamounttotal") as TextBox;
        //    Data2.Text = Auditexpamounttotal.ToString();

        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        fillGrid();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("DevelopmentFund_Urban.aspx");
    }
}
