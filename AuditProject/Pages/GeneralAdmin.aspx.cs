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
public partial class Pages_GeneralAdmin : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            //Session["LBID"] = 276;
            //Session["Year"] = 21;
            //Session["UserID"] = 80374;
            //Session["SeatID"] = 5027601002;
            fillGridAdmin();
            fillGridElected();
            fillGridCharges();
            fillGridExp();
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

    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvGenralAdmin.Items.Count; i++)
            {

                TextBox txtData1 = grvGenralAdmin.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;
            }
            for (int i = 0; i < grvGenralAdminElected.Items.Count; i++)
            {

                TextBox txtData1 = grvGenralAdminElected.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;
            }
           
            for (int i = 0; i < grvGenralAdminOfficeExp.Items.Count; i++)
            {

                TextBox txtData1 = grvGenralAdminOfficeExp.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;
            }
            for (int i = 0; i < grvGenralAdminCharges.Items.Count; i++)
            {
                 
                TextBox txtData11 = grvGenralAdminCharges.Items[i].FindControl("txtexpamounttotal") as TextBox;
                txtData11.ReadOnly = false;

                TextBox txtData1 = grvGenralAdminCharges.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;
            }
           

        }
        else
        {
            for (int i = 0; i < grvGenralAdmin.Items.Count; i++)
            {
                 
                TextBox txtData1 = grvGenralAdmin.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = false;
            }
            for (int i = 0; i < grvGenralAdminElected.Items.Count; i++)
            {
                 
                TextBox txtData1 = grvGenralAdminElected.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = false;
            }
            for (int i = 0; i < grvGenralAdminOfficeExp.Items.Count; i++)
            {
              
                TextBox txtData1 = grvGenralAdminOfficeExp.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData1.ReadOnly = false;
            }
            for (int i = 0; i < grvGenralAdminCharges.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminCharges.Items[i].FindControl("txtexpamounttotal") as TextBox;
                txtData1.ReadOnly = true;

                TextBox txtData11 = grvGenralAdminCharges.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.ReadOnly = false;

            }
            
        }
    }
    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvGenralAdmin.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdmin.Items[i].FindControl("txtexpamounttotal") as TextBox;

                TextBox txtData11 = grvGenralAdmin.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.Text = txtData1.Text;
            }
            for (int i = 0; i < grvGenralAdminElected.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminElected.Items[i].FindControl("txtexpamounttotal") as TextBox;

                TextBox txtData11 = grvGenralAdminElected.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.Text = txtData1.Text;
            }
            for (int i = 0; i < grvGenralAdminOfficeExp.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminOfficeExp.Items[i].FindControl("txtexpamounttotal") as TextBox;

                TextBox txtData11 = grvGenralAdminOfficeExp.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.Text = txtData1.Text;
            }
            for (int i = 0; i < grvGenralAdminCharges.Items.Count; i++)
            {
                TextBox txtData1 = grvGenralAdminCharges.Items[i].FindControl("txtexpamounttotal") as TextBox;

                TextBox txtData11 = grvGenralAdminCharges.Items[i].FindControl("txtauditedexpamounttotal") as TextBox;
                txtData11.Text = txtData1.Text;
            }
        }
    }
    
    /// <summary>
    /// /////////////////Admin a
    /// </summary>
    void fillGridAdmin()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(1);  ///MainexpenType
        arrIn.Add(1);  //subExpenTYpe
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_expenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvGenralAdmin.DataSource = ds;
            grvGenralAdmin.DataBind();
            Control FooterTemplate = grvGenralAdmin.Controls[grvGenralAdmin.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("amounttotal") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][9].ToString();

            Label incometot1 = FooterTemplate.FindControl("Auditamounttotal") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][10].ToString();

            lblGtot.Text = ds.Tables[0].Rows[0][9].ToString();
            lblAuditGtot.Text = ds.Tables[0].Rows[0][10].ToString();
        }
       
        //int tot = 0;
        //int Atot = 0;
        //tot = Convert.ToInt32(lblGtot.Text);
        //Atot = Convert.ToInt32(lblAuditGtot.Text);

        //tot = Convert.ToInt32(lblGtot.Text.ToString());
        //Atot = Convert.ToInt32(ds.Tables[0].Rows[0][10].ToString());
        //lblGtot.Text = tot.ToString();
        //lblAuditGtot.Text = Atot.ToString();

    }




    public void Save_DataAdmin()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvGenralAdmin.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvGenralAdmin.Items[i].FindControl("mainexpendituretype") as Label;   ////@@intmainexpendituretype ,
            Label lblData2 = grvGenralAdmin.Items[i].FindControl("subexpendituretype") as Label;   ////@@intsubexpendituretype ,
            Label lblData3 = grvGenralAdmin.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32( lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32( lblData2.Text.ToString()));
            arrIn.Add(Convert.ToInt32( lblData3.Text.ToString()));
            TextBox lblData14 = grvGenralAdmin.Items[i].FindControl("txtexpamounttotal") as TextBox;
            if (lblData14.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData14.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvGenralAdmin.Items[i].FindControl("txtauditedexpamounttotal") as TextBox; //@numauditedobamount 
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
            int ep = objcomm.update("SP_tb_expenditure_U", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSaveAdmin_Click(object sender, EventArgs e)
    {
        Save_DataAdmin();
        fillGridAdmin();
    }
    //public void clearGrid()
    //{
    //    foreach (RepeaterItem item in grvGenralAdmin.Items)
    //    {
    //        //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
    //        //Label lblData = item.FindControl("intparticipantfemale") as Label;
    //        //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
    //    }
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_DataAdmin();
    }

    //protected void grvGenralAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (grvGenralAdmin.Items.Count < 1)
    //    {
    //        if (e.Item.ItemType == ListItemType.Footer)
    //        {
    //            Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
    //            lblFooter.Visible = true;
    //        }
    //    }
    //}
    protected void grvGenralAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //Int32 expamounttotal = 0;
        //Int32 Auditexpamounttotal = 0;
        //ListItemType lt = e.Item.ItemType;
        //if (lt == ListItemType.Item || lt == ListItemType.AlternatingItem)
        //{ DataRowView dv = e.Item.DataItem as DataRowView;
        //if (dv != null)
        //{

        //    expamounttotal += Convert.ToInt64(dv["AdImpression"]);
        //    Auditexpamounttotal += Convert.ToInt64(dv["AdImpression"]);
        //    TextBox Data1 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("numexpamounttotal") as TextBox;
        //    Data1.Text = expamounttotal.ToString();

        //    TextBox Data2 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("Auditexpamounttotal") as TextBox;
        //    Data2.Text = Auditexpamounttotal.ToString();
        //}
        //}
    }
    public void ChildRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        //ListItemType lt = e.Item.ItemType;
        //if (lt == ListItemType.Item || lt == ListItemType.AlternatingItem)
        //{
        //    DataRowView dv = e.Item.DataItem as DataRowView;
        //    if (dv != null)
        //    {
        //        cntView += Convert.ToInt64(dv["AdImpression"]);
        //        cntClick += Convert.ToInt64(dv["AdClicks"]);
        //    }

        //}
        //else if (e.Item.ItemType == ListItemType.Footer)
        //{
        //    Label lblCount = e.Item.FindControl("lblImpressionCount") as Label;
        //    lblCount.Text = cntView.ToString();

        //    Label lblSum = e.Item.FindControl("lblClickCount") as Label;
        //    lblSum.Text = cntClick.ToString();
        //    cntView = 0;
        //    cntClick = 0;
        //}
    }
    ////////////////////////////////////elected b
    void fillGridElected()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(1);  ///MainexpenType
        arrIn.Add(2);  //subExpenTYpe
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_expenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvGenralAdminElected.DataSource = ds;
            grvGenralAdminElected.DataBind();

            Control FooterTemplate = grvGenralAdminElected.Controls[grvGenralAdminElected.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("amounttotal") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][9].ToString();

            Label incometot1 = FooterTemplate.FindControl("Auditamounttotal") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][10].ToString();

            double tot = 0;
            double Atot = 0;
            tot = Convert.ToDouble(lblGtot.Text);
            if (lblAuditGtot.Text != "" && incometot1.Text!="")
            {
                Atot = Convert.ToDouble(lblAuditGtot.Text);
                Atot += Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());
                lblAuditGtot.Text = Atot.ToString();
            }

            tot += Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());
          

            lblGtot.Text = tot.ToString();
           
        }
    }




    public void Save_DataElectd()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvGenralAdminElected.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvGenralAdminElected.Items[i].FindControl("mainexpendituretype") as Label;   ////@@intmainexpendituretype ,
            Label lblData2 = grvGenralAdminElected.Items[i].FindControl("subexpendituretype") as Label;   ////@@intsubexpendituretype ,
            Label lblData3 = grvGenralAdminElected.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData2.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
            TextBox lblData41 = grvGenralAdminElected.Items[i].FindControl("txtexpamounttotal") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvGenralAdminElected.Items[i].FindControl("txtauditedexpamounttotal") as TextBox; //@numauditedobamount 
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
            int ep = objcomm.update("SP_tb_expenditure_U", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSaveElected_Click(object sender, EventArgs e)
    {
        Save_DataElectd();
        fillGridElected();
    }
    //public void clearGrid()
    //{
    //    foreach (RepeaterItem item in grvGenralAdminElected.Items)
    //    {
    //        //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
    //        //Label lblData = item.FindControl("intparticipantfemale") as Label;
    //        //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
    //    }
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Save_DataElectd();
    //}

    protected void grvGenralAdminElected_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (grvGenralAdminElected.Items.Count < 1)
        //{
        //    if (e.Item.ItemType == ListItemType.Footer)
        //    {
        //        Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
        //        lblFooter.Visible = true;
        //    }
        //}
    }
    /////////////////////////////////Charges  c
    void fillGridCharges()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(1);  ///MainexpenType
        arrIn.Add(4);  //subExpenTYpe
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_expenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvGenralAdminCharges.DataSource = ds;
            grvGenralAdminCharges.DataBind();

            Control FooterTemplate = grvGenralAdminCharges.Controls[grvGenralAdminCharges.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("amounttotal") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][9].ToString();

            Label incometot1 = FooterTemplate.FindControl("Auditamounttotal") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][10].ToString();

            double tot = 0;
            double Atot = 0;
            tot = Convert.ToDouble(lblGtot.Text);

            tot = Convert.ToDouble(lblGtot.Text);
            if (lblAuditGtot.Text != "" && incometot1.Text != "")
            {
                Atot = Convert.ToDouble(lblAuditGtot.Text);
                Atot += Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());
                lblAuditGtot.Text = Atot.ToString();
            }

            tot += Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());


            lblGtot.Text = tot.ToString();
        }
    }


    public void Save_DataCharges()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvGenralAdminCharges.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvGenralAdminCharges.Items[i].FindControl("mainexpendituretype") as Label;   ////@@intmainexpendituretype ,
            Label lblData2 = grvGenralAdminCharges.Items[i].FindControl("subexpendituretype") as Label;   ////@@intsubexpendituretype ,
            Label lblData3 = grvGenralAdminCharges.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData2.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
            TextBox lblData41 = grvGenralAdminCharges.Items[i].FindControl("txtexpamounttotal") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvGenralAdminCharges.Items[i].FindControl("txtauditedexpamounttotal") as TextBox; //@numauditedobamount 
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
            int ep = objcomm.update("SP_tb_expenditure_U", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSaveCharges_Click(object sender, EventArgs e)
    {
        Save_DataCharges();
        fillGridCharges();
    }
    //public void clearGrid()
    //{
    //    foreach (RepeaterItem item in grvGenralAdminCharges.Items)
    //    {
    //        //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
    //        //Label lblData = item.FindControl("intparticipantfemale") as Label;
    //        //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
    //    }
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Save_DataCharges();
    //}

    protected void grvGenralAdminCharges_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (grvGenralAdminCharges.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }
    }
    ////////////////////////////////////Expenses  d
    void fillGridExp()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(1);  ///MainexpenType
        arrIn.Add(3);  //subExpenTYpe
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_expenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvGenralAdminOfficeExp.DataSource = ds;
            grvGenralAdminOfficeExp.DataBind();

            Control FooterTemplate = grvGenralAdminOfficeExp.Controls[grvGenralAdminOfficeExp.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("amounttotal") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][9].ToString();

            Label incometot1 = FooterTemplate.FindControl("Auditamounttotal") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][10].ToString();

            double tot = 0;
            double Atot = 0;
            tot = Convert.ToDouble(lblGtot.Text);
            if (lblAuditGtot.Text != "" && incometot1.Text != "")
            {
                Atot = Convert.ToDouble(lblAuditGtot.Text);
                Atot += Convert.ToDouble(ds.Tables[0].Rows[0][10].ToString());
                lblAuditGtot.Text = Atot.ToString();
            }

            tot += Convert.ToDouble(ds.Tables[0].Rows[0][9].ToString());


            lblGtot.Text = tot.ToString();
            
        }
        disabletextbox();
    }




    public void Save_DataExp()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvGenralAdminOfficeExp.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvGenralAdminOfficeExp.Items[i].FindControl("mainexpendituretype") as Label;   ////@@intmainexpendituretype ,
            Label lblData2 = grvGenralAdminOfficeExp.Items[i].FindControl("subexpendituretype") as Label;   ////@@intsubexpendituretype ,
            Label lblData3 = grvGenralAdminOfficeExp.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData2.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
            TextBox lblData41 = grvGenralAdminOfficeExp.Items[i].FindControl("txtexpamounttotal") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvGenralAdminOfficeExp.Items[i].FindControl("txtauditedexpamounttotal") as TextBox; //@numauditedobamount 
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
    protected void btnSaveOfficeExp_Click(object sender, EventArgs e)
    {
        Save_DataExp();
        fillGridExp();
    }
    //public void clearGrid()
    //{
    //    foreach (RepeaterItem item in grvGenralAdminOfficeExp.Items)
    //    {
    //        //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
    //        //Label lblData = item.FindControl("intparticipantfemale") as Label;
    //        //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
    //    }
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Save_DataExp();
    //}

    protected void grvGenralAdminOfficeExp_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (grvGenralAdminOfficeExp.Items.Count < 1)
        //{
        //    if (e.Item.ItemType == ListItemType.Footer)
        //    {
        //        Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
        //        lblFooter.Visible = true;
        //    }
        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_DataAdmin();
        Save_DataCharges();
        Save_DataElectd();
        Save_DataExp();
        fillGridAdmin();
        fillGridCharges();
        fillGridElected();
        fillGridExp();
    }
}
