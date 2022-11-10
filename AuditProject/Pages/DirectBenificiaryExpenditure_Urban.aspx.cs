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

public partial class Pages_DirectBenificiaryExpenditure_Urban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
            for (int i = 0; i < grvPensionDetails.Items.Count; i++)
            {
                ////////not editable

                TextBox text1 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;              
                TextBox text2 = grvPensionDetails.Items[i].FindControl("numexpenditure") as TextBox;    
                TextBox text3 = grvPensionDetails.Items[i].FindControl("intexistingcount") as TextBox;              
                TextBox text4 = grvPensionDetails.Items[i].FindControl("intadditioncount") as TextBox;              
                TextBox text5 = grvPensionDetails.Items[i].FindControl("intdeletioncount") as TextBox;               
                TextBox text6 = grvPensionDetails.Items[i].FindControl("intbalancecount") as TextBox;             

                TextBox text21 = grvPensionDetails.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox text22 = grvPensionDetails.Items[i].FindControl("numauditedexpenditure") as TextBox;      
                TextBox text9 = grvPensionDetails.Items[i].FindControl("intauditedexistingcount") as TextBox;              
                TextBox text10 = grvPensionDetails.Items[i].FindControl("intauditedadditioncount") as TextBox;               
                TextBox text11 = grvPensionDetails.Items[i].FindControl("intauditeddeletioncount") as TextBox;              
                TextBox text12 = grvPensionDetails.Items[i].FindControl("intauditedbalancecount") as TextBox;

                text21.Text = text1.Text;
                text22.Text = text2.Text;
                text9.Text = text3.Text;
                text10.Text = text4.Text;
                text11.Text = text5.Text;
                text12.Text = text6.Text;
            }
        }
    }

    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvPensionDetails.Items.Count; i++)
            {
                ////////not editable
                TextBox text1 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvPensionDetails.Items[i].FindControl("numexpenditure") as TextBox;
                text2.ReadOnly = false;
                ////////not editable
                TextBox text3 = grvPensionDetails.Items[i].FindControl("intexistingcount") as TextBox;
                text3.ReadOnly = false;
                TextBox text4 = grvPensionDetails.Items[i].FindControl("intadditioncount") as TextBox;
                text4.ReadOnly = false;
                TextBox text5 = grvPensionDetails.Items[i].FindControl("intdeletioncount") as TextBox;
                text5.ReadOnly = false;
                TextBox text6 = grvPensionDetails.Items[i].FindControl("intbalancecount") as TextBox;
                text6.ReadOnly = false;

                TextBox text7 = grvPensionDetails.Items[i].FindControl("numauditedincome") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvPensionDetails.Items[i].FindControl("numauditedexpenditure") as TextBox;
                text8.ReadOnly = true;                
                TextBox text9 = grvPensionDetails.Items[i].FindControl("intauditedexistingcount") as TextBox;
                text9.ReadOnly = true;
                TextBox text10 = grvPensionDetails.Items[i].FindControl("intauditedadditioncount") as TextBox;
                text10.ReadOnly = true;
                TextBox text11 = grvPensionDetails.Items[i].FindControl("intauditeddeletioncount") as TextBox;
                text11.ReadOnly = true;
                TextBox text12 = grvPensionDetails.Items[i].FindControl("intauditedbalancecount") as TextBox;
                text12.ReadOnly = true;
            }

        }
        else
        {
            for (int i = 0; i < grvPensionDetails.Items.Count; i++)
            {
                TextBox text1 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvPensionDetails.Items[i].FindControl("numexpenditure") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvPensionDetails.Items[i].FindControl("intexistingcount") as TextBox;
                text3.ReadOnly = true;
                TextBox text4 = grvPensionDetails.Items[i].FindControl("intadditioncount") as TextBox;
                text4.ReadOnly = true;
                TextBox text5 = grvPensionDetails.Items[i].FindControl("intdeletioncount") as TextBox;
                text5.ReadOnly = true;
                TextBox text6 = grvPensionDetails.Items[i].FindControl("intbalancecount") as TextBox;
                text6.ReadOnly = true;

                TextBox text7 = grvPensionDetails.Items[i].FindControl("numauditedincome") as TextBox;
                text7.ReadOnly = false;
                TextBox text8 = grvPensionDetails.Items[i].FindControl("numauditedexpenditure") as TextBox;
                text8.ReadOnly = false;
                TextBox text9 = grvPensionDetails.Items[i].FindControl("intauditedexistingcount") as TextBox;
                text9.ReadOnly = false;
                TextBox text10 = grvPensionDetails.Items[i].FindControl("intauditedadditioncount") as TextBox;
                text10.ReadOnly = false;
                TextBox text11 = grvPensionDetails.Items[i].FindControl("intauditeddeletioncount") as TextBox;
                text11.ReadOnly = false;
                TextBox text12 = grvPensionDetails.Items[i].FindControl("intauditedbalancecount") as TextBox;
                text12.ReadOnly = false;
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
        ds = objcom.FillData("[SP_tb_directbeneficiaryexpenditure_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvPensionDetails.DataSource = ds;
            grvPensionDetails.DataBind();
        }
        disabletextbox();
    }

    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvPensionDetails.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,  
            
            Label lblData3 = grvPensionDetails.Items[i].FindControl("vchaccountheadcode") as Label;   ////@vchaccountheadcode ,

            arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
            TextBox lblData41 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }

            TextBox txtData1 = grvPensionDetails.Items[i].FindControl("numauditedincome") as TextBox; //@numauditedincome 
            if (txtData1.Text == "")
            {
                //TextBox lblData4 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;
                //if (lblData4.Text != "")
                //{
                //    arrIn.Add(Convert.ToDouble(lblData4.Text.ToString()));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData1.Text.ToString()));
            }
            ///
            TextBox txtData22 = grvPensionDetails.Items[i].FindControl("numexpenditure") as TextBox;
            if (txtData22.Text != "")
            {
                arrIn.Add(Convert.ToDouble(txtData22.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvPensionDetails.Items[i].FindControl("numauditedexpenditure") as TextBox; //@numauditedexpenditure 
            if (txtData2.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }
            ////
            TextBox txtData32 = grvPensionDetails.Items[i].FindControl("intexistingcount") as TextBox;
            if (txtData32.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData32.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData3 = grvPensionDetails.Items[i].FindControl("intauditedexistingcount") as TextBox; //@intauditedexistingcount 
            if (txtData3.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData3.Text.ToString()));
            }
            ////
            TextBox txtData42 = grvPensionDetails.Items[i].FindControl("intadditioncount") as TextBox;
            if (txtData42.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData42.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvPensionDetails.Items[i].FindControl("intauditedadditioncount") as TextBox; //@intauditedadditioncount 
            if (txtData4.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData4.Text.ToString()));
            }
            ///
            TextBox txtData52 = grvPensionDetails.Items[i].FindControl("intdeletioncount") as TextBox;
            if (txtData52.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData52.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData5 = grvPensionDetails.Items[i].FindControl("intauditeddeletioncount") as TextBox; //@intauditeddeletioncount 
            if (txtData5.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData5.Text.ToString()));
            }
            ///
            TextBox txtData62 = grvPensionDetails.Items[i].FindControl("intbalancecount") as TextBox;
            if (txtData62.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData62.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData6 = grvPensionDetails.Items[i].FindControl("intauditedbalancecount") as TextBox; //@intauditedbalancecount 
            if (txtData6.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData6.Text.ToString()));
            }
            //
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_directbeneficiaryexpenditure_U", arrIn);

            GlobalClass gblObj = new GlobalClass();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
    }
    protected void btnSave_Click (object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        fillGrid();
    }

    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_Data();
    }

    
    protected void grvPensionDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //    Int32 expamounttotal = 0;
        //    Int32 Auditexpamounttotal = 0;
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {

        //        expamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[1]);
        //        Auditexpamounttotal += Convert.ToInt32(((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[3]);
        //        TextBox Data1 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[2]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("numexpamounttotal") as TextBox;
        //        Data1.Text = expamounttotal.ToString();

        //        TextBox Data2 = (((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray[4]) as TextBox; //grvGenralAdminService.Items[e.Item.DataItem].FindControl("Auditexpamounttotal") as TextBox;
        //        Data2.Text = Auditexpamounttotal.ToString();

        //    }
        //}
    }
}
