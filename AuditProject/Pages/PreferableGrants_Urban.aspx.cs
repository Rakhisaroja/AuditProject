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
public partial class Pages_PreferableGrants_Urban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Session["LBID"] = 276;
            //Session["Year"] = 21;
            //Session["UserID"] = 80374;
            //Session["SeatID"] = 5027601002;
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
            for (int i = 0; i < grvPreferableGrants.Items.Count; i++)
            {              
                //////////////////not Editable
                TextBox text10 = grvPreferableGrants.Items[i].FindControl("numob") as TextBox;
                TextBox text1 = grvPreferableGrants.Items[i].FindControl("numincome") as TextBox;
                TextBox text2 = grvPreferableGrants.Items[i].FindControl("numexpenditure") as TextBox;    
                TextBox text4 = grvPreferableGrants.Items[i].FindControl("intexistingcount") as TextBox;               
                TextBox text6 = grvPreferableGrants.Items[i].FindControl("intadditioncount") as TextBox;               
                TextBox text7 = grvPreferableGrants.Items[i].FindControl("intdeletioncount") as TextBox;                
                TextBox text8 = grvPreferableGrants.Items[i].FindControl("intbalancecount") as TextBox;

                TextBox text20 = grvPreferableGrants.Items[i].FindControl("numauditedob") as TextBox;
                TextBox text21 = grvPreferableGrants.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox text22 = grvPreferableGrants.Items[i].FindControl("numauditedexpenditure") as TextBox;      
                TextBox text12 = grvPreferableGrants.Items[i].FindControl("intauditedexistingcount") as TextBox;               
                TextBox text13 = grvPreferableGrants.Items[i].FindControl("intauditedadditioncount") as TextBox;             
                TextBox text14 = grvPreferableGrants.Items[i].FindControl("intauditeddeletioncount") as TextBox;              
                TextBox text15 = grvPreferableGrants.Items[i].FindControl("intauditedbalancecount") as TextBox;

                text20.Text = text10.Text;
                text21.Text = text1.Text;
                text22.Text = text2.Text;
                text12.Text = text4.Text;
                text13.Text = text6.Text;
                text14.Text = text7.Text;
                text15.Text = text8.Text;                 
            }
        }
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvPreferableGrants.Items.Count; i++)
            {

                //////////////////not Editable
                TextBox text1 = grvPreferableGrants.Items[i].FindControl("numob") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvPreferableGrants.Items[i].FindControl("numincome") as TextBox;
                text2.ReadOnly = false;
                TextBox text3 = grvPreferableGrants.Items[i].FindControl("numexpenditure") as TextBox;
                text3.ReadOnly = false;
                //////////////////not Editable
                TextBox text4 = grvPreferableGrants.Items[i].FindControl("intexistingcount") as TextBox;
                text4.ReadOnly = false;
                 TextBox text6 = grvPreferableGrants.Items[i].FindControl("intadditioncount") as TextBox;
                 text6.ReadOnly = false;
                TextBox text7 = grvPreferableGrants.Items[i].FindControl("intdeletioncount") as TextBox;
                text7.ReadOnly = false;
                TextBox text8 = grvPreferableGrants.Items[i].FindControl("intbalancecount") as TextBox;
                text8.ReadOnly = false;
                


                TextBox text9 = grvPreferableGrants.Items[i].FindControl("numauditedob") as TextBox;
                text9.ReadOnly = true;
                TextBox text10 = grvPreferableGrants.Items[i].FindControl("numauditedincome") as TextBox;
                text10.ReadOnly = true;
                TextBox text11 = grvPreferableGrants.Items[i].FindControl("numauditedexpenditure") as TextBox;
                text11.ReadOnly = true;
                TextBox text12 = grvPreferableGrants.Items[i].FindControl("intauditedexistingcount") as TextBox;
                text12.ReadOnly = true;
                 TextBox text13 = grvPreferableGrants.Items[i].FindControl("intauditedadditioncount") as TextBox;
                text13.ReadOnly = true;
                TextBox text14 = grvPreferableGrants.Items[i].FindControl("intauditeddeletioncount") as TextBox;
                text14.ReadOnly = true;
                TextBox text15 = grvPreferableGrants.Items[i].FindControl("intauditedbalancecount") as TextBox;
                text15.ReadOnly = true;


            }

        }
        else
        {
            for (int i = 0; i < grvPreferableGrants.Items.Count; i++)
            {
                TextBox text1 = grvPreferableGrants.Items[i].FindControl("numob") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvPreferableGrants.Items[i].FindControl("numincome") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvPreferableGrants.Items[i].FindControl("numexpenditure") as TextBox;
                text3.ReadOnly = true;
                TextBox text4 = grvPreferableGrants.Items[i].FindControl("intexistingcount") as TextBox;
                text4.ReadOnly = true;
                TextBox text6 = grvPreferableGrants.Items[i].FindControl("intadditioncount") as TextBox;
                text6.ReadOnly = true;
                TextBox text7 = grvPreferableGrants.Items[i].FindControl("intdeletioncount") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvPreferableGrants.Items[i].FindControl("intbalancecount") as TextBox;
                text8.ReadOnly = true;

                TextBox text9 = grvPreferableGrants.Items[i].FindControl("numauditedob") as TextBox;
                text9.ReadOnly = false;
                TextBox text10 = grvPreferableGrants.Items[i].FindControl("numauditedincome") as TextBox;
                text10.ReadOnly = false;
                TextBox text11 = grvPreferableGrants.Items[i].FindControl("numauditedexpenditure") as TextBox;
                text11.ReadOnly = false;
                TextBox text12 = grvPreferableGrants.Items[i].FindControl("intauditedexistingcount") as TextBox;
                text12.ReadOnly = false;
                TextBox text13 = grvPreferableGrants.Items[i].FindControl("intauditedadditioncount") as TextBox;
                text13.ReadOnly = false;
                TextBox text14 = grvPreferableGrants.Items[i].FindControl("intauditeddeletioncount") as TextBox;
                text14.ReadOnly = false;
                TextBox text15 = grvPreferableGrants.Items[i].FindControl("intauditedbalancecount") as TextBox;
                text15.ReadOnly = false;
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
        ds = objcom.FillData("[SP_tb_otherspecialgrants_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvPreferableGrants.DataSource = ds;
            grvPreferableGrants.DataBind();
            /////////////
            //lblCBAuditAmt.Text = ds.Tables[0].Rows[0][6].ToString();
            //lblCBAmt.Text = ds.Tables[0].Rows[0][5].ToString();
            Control FooterTemplate = grvPreferableGrants.Controls[grvPreferableGrants.Controls.Count - 1].Controls[0];
            Label obtot1 = FooterTemplate.FindControl("totob") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][24].ToString();

            Label incometot1 = FooterTemplate.FindControl("totincome") as Label;
            incometot1.Text = ds.Tables[0].Rows[0][26].ToString();

            Label expentot1 = FooterTemplate.FindControl("totexpenditure") as Label;
            expentot1.Text = ds.Tables[0].Rows[0][28].ToString();

            Label auditobtot1 = FooterTemplate.FindControl("totAuditob") as Label;
            auditobtot1.Text = ds.Tables[0].Rows[0][25].ToString();

            Label auditincometot1 = FooterTemplate.FindControl("totAuditincome") as Label;
            auditincometot1.Text = ds.Tables[0].Rows[0][27].ToString();

            Label Auditexpentot1 = FooterTemplate.FindControl("totAuditexpenditure") as Label;
            Auditexpentot1.Text = ds.Tables[0].Rows[0][29].ToString();
            disabletextbox();

            /////////////
        }
    }




    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvPreferableGrants.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,    
           
            
            Label lblData1 = grvPreferableGrants.Items[i].FindControl("vchaccountheadcode") as Label;   ////@@intmainexpendituretype ,
          
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            Label lblData11 = grvPreferableGrants.Items[i].FindControl("vchaccounthead") as Label;   ////@@intmainexpendituretype ,

            arrIn.Add(lblData11.Text.ToString());
            arrIn.Add(1);
            //arrIn.Add(DBNull.Value);
            TextBox lblData21 = grvPreferableGrants.Items[i].FindControl("numob") as TextBox;
            if (lblData21.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData21.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData1 = grvPreferableGrants.Items[i].FindControl("numauditedob") as TextBox; //@numauditedobamount 
            if (txtData1.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData1.Text.ToString()));
            }
            TextBox lblData31 = grvPreferableGrants.Items[i].FindControl("numincome") as TextBox;
            if (lblData31.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData31.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvPreferableGrants.Items[i].FindControl("numauditedincome") as TextBox; //@numauditedobamount 
            if (txtData2.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }
            TextBox lblData41 = grvPreferableGrants.Items[i].FindControl("numexpenditure") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData3 = grvPreferableGrants.Items[i].FindControl("numauditedexpenditure") as TextBox; //@numauditedobamount 
            if (txtData3.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData3.Text.ToString()));
            }
            TextBox lblData51 = grvPreferableGrants.Items[i].FindControl("intexistingcount") as TextBox;
            if (lblData51.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData51.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvPreferableGrants.Items[i].FindControl("intauditedexistingcount") as TextBox; //@numauditedobamount 
            if (txtData4.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData4.Text.ToString()));
            }
            TextBox lblData61 = grvPreferableGrants.Items[i].FindControl("intadditioncount") as TextBox;
            if (lblData61.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData61.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData5 = grvPreferableGrants.Items[i].FindControl("intauditedadditioncount") as TextBox; //@numauditedobamount 
            if (txtData5.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData5.Text.ToString()));
            }
            TextBox lblData71 = grvPreferableGrants.Items[i].FindControl("intdeletioncount") as TextBox;
            if (lblData71.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData71.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData6 = grvPreferableGrants.Items[i].FindControl("intauditeddeletioncount") as TextBox; //@numauditedobamount 
            if (txtData6.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData6.Text.ToString()));
            }
            TextBox lblData81 = grvPreferableGrants.Items[i].FindControl("intbalancecount") as TextBox;
            if (lblData81.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData81.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData7 = grvPreferableGrants.Items[i].FindControl("intauditedbalancecount") as TextBox; //@numauditedobamount 
            if (txtData7.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData7.Text.ToString()));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_otherspecialgrants_IU", arrIn);

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
        Save_Data();
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
    protected void grvPreferableGrants_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Int32 expamounttotal = 0;
        Int32 Auditexpamounttotal = 0;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            expamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[1]);
            Auditexpamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[3]);
            TextBox Data1 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("numexpamounttotal") as TextBox;
            Data1.Text = expamounttotal.ToString();

            TextBox Data2 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("Auditexpamounttotal") as TextBox;
            Data2.Text = Auditexpamounttotal.ToString();

        }
    }
}
