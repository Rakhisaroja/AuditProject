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
public partial class Pages_BankClosed_Urban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            //Session["LBID"] = 276;
            //Session["Year"] = 21;
            //Session["UserID"] = 80374;
            //Session["SeatID"] = 5027601002;
            fillGrid();
            chkStatus();
            //Session["lblOBAmt"] = obtot.Text;
            //Session["lblOBAuditAmt"] = auditobtot.Text;
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
            for (int i = 0; i < grvBalanced.Items.Count; i++)
            {
                TextBox text7 = grvBalanced.Items[i].FindControl("txtBalancd") as TextBox;
                           /////////////////not editable
                TextBox text8 = grvBalanced.Items[i].FindControl("txtAuditedBalancd") as TextBox;
                text8.Text = text7.Text;

            }

        }
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvBalanced.Items.Count; i++)
            {
                TextBox text7 = grvBalanced.Items[i].FindControl("txtBalancd") as TextBox;
                text7.ReadOnly = true;             /////////////////not editable
                TextBox text8 = grvBalanced.Items[i].FindControl("txtAuditedBalancd") as TextBox;
                text8.ReadOnly = true;

            }

        }
        else
        {
            for (int i = 0; i < grvBalanced.Items.Count; i++)
            {
                TextBox text1 = grvBalanced.Items[i].FindControl("txtBalancd") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvBalanced.Items[i].FindControl("txtAuditedBalancd") as TextBox;
                text2.ReadOnly = false;


            }
        }
    }

    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_bankCBUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvBalanced.DataSource = ds;
            grvBalanced.DataBind();
            disabletextbox();

            //lblOBAuditAmt.Text = ds.Tables[0].Rows[0][6].ToString();
            //lblOBAmt.Text = ds.Tables[0].Rows[0][5].ToString();//
            //obtot.Text = ds.Tables[0].Rows[0][5].ToString();
            //auditobtot.Text = ds.Tables[0].Rows[0][6].ToString();

            Control FooterTemplate = grvBalanced.Controls[grvBalanced.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("CBtot") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][5].ToString();
            Label auditobtot1 = FooterTemplate.FindControl("auditCBtot") as Label;
            auditobtot1.Text = ds.Tables[0].Rows[0][6].ToString();
        }
    }


    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvBalanced.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvBalanced.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,

            arrIn.Add(lblData1.Text.ToString());
            TextBox lblData12 = grvBalanced.Items[i].FindControl("txtBalancd") as TextBox;
            if (lblData12.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData12.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvBalanced.Items[i].FindControl("txtAuditedBalancd") as TextBox; //@numauditedobamount 
            if (txtData2.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }

            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_bankCBUrban_U", arrIn);
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
        ValueAssign();
        Save_Data();
        fillGrid();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvBalanced.Items)
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

    protected void grvBalanced_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        //double totalob = 0;
        //double totalAudit = 0;
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    Label lblob = (Label)e.Item.FindControl("obtot");
        //    if (lblob != null)
        //    {
        //        totalob += Convert.ToInt32(lblob.Text);
        //    }

        //    Label lblAudit = (Label)e.Item.FindControl("auditobtot");
        //    if (lblAudit != null)
        //    {
        //        totalAudit += Convert.ToInt32(lblAudit.Text);
        //    }
        //}

        //if (e.Item.ItemType == ListItemType.Footer)
        //{
        //    Label lbltotalob = (Label)e.Item.FindControl("obtot");
        //    if (lbltotalob != null)
        //    {
        //        lbltotalob.Text = lbltotalob.ToString();
        //        totalob = 0;
        //    }
        //    Label lbltotalAuditob = (Label)e.Item.FindControl("auditobtot");
        //    if (lbltotalAuditob != null)
        //    {
        //        lbltotalAuditob.Text = lbltotalAuditob.ToString();
        //        totalob = 0;
        //    }
        //}
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrontOfficeDet_Urban.aspx");

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

    }
    protected void grvBalanced_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //string d = lblOBAmt.Text;
        //double totalob = 0;
        //double totalAudit = 0;
        //totalob = Convert.ToDouble(Session["lblOBAmt"]);
        //totalAudit = Convert.ToDouble(Session["lblOBAuditAmt"]);
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    Label lblob = (Label)e.Item.FindControl("obtot");
        //    if (lblob != null)
        //    {
        //        totalob += Convert.ToInt32(lblob.Text);
        //    }

        //    Label lblAudit = (Label)e.Item.FindControl("auditobtot");
        //    if (lblAudit != null)
        //    {
        //        totalAudit += Convert.ToInt32(lblAudit.Text);
        //    }
        //}

        //if (e.Item.ItemType == ListItemType.Footer)
        //{
        //    Label lbltotalob = (Label)e.Item.FindControl("obtot");
        //    if (lbltotalob != null)
        //    {
        //        lbltotalob.Text = lblOBAmt.Text.ToString();
        //        totalob = 0;
        //    }
        //    Label lbltotalAuditob = (Label)e.Item.FindControl("auditobtot");
        //    if (lbltotalAuditob != null)
        //    {
        //        lbltotalAuditob.Text = lblOBAuditAmt.Text.ToString();
        //        totalob = 0;
        //    }
        //}
    }
    //protected void grvBalanced_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item)
    //    {
    //        total += Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Amount"));
    //    }
    //    if (e.Item.ItemType == ListItemType.Footer)
    //    {
    //        Label lblamount = (Label)e.Item.FindControl("lblTotal");
    //        lblamount.Text = total.ToString();
    //    }
    //}
}
