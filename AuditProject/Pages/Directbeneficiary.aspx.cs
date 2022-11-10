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
public partial class Pages_PensionDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            fillGrid();
        }

    }

    /// <summary>
    /// /////////////////Admin a
    /// </summary>
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
            TextBox txtData1 = grvPensionDetails.Items[i].FindControl("numauditedincome") as TextBox; //@numauditedincome 
            if (txtData1.Text == "")
            {
                TextBox lblData4 = grvPensionDetails.Items[i].FindControl("numincome") as TextBox;
                if (lblData4.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData4.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData1.Text.ToString()));
            }
            ///
              TextBox txtData2 = grvPensionDetails.Items[i].FindControl("numauditedexpenditure") as TextBox; //@numauditedexpenditure 
              if (txtData2.Text == "")
            {
                TextBox txtData21 = grvPensionDetails.Items[i].FindControl("numexpenditure") as TextBox;
                if (txtData21.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtData21.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }
            ////
              TextBox txtData3 = grvPensionDetails.Items[i].FindControl("intauditedexistingcount") as TextBox; //@intauditedexistingcount 
            if (txtData3.Text == "")
            {
                TextBox txtData31 = grvPensionDetails.Items[i].FindControl("intexistingcount") as TextBox;
                if (txtData31.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtData31.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData3.Text.ToString()));
            }
            ////
              TextBox txtData4 = grvPensionDetails.Items[i].FindControl("intauditedadditioncount") as TextBox; //@intauditedadditioncount 
            if (txtData4.Text == "")
            {
                TextBox txtData41 = grvPensionDetails.Items[i].FindControl("intadditioncount") as TextBox;
                if (txtData41.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtData41.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData4.Text.ToString()));
            }
            ///
              TextBox txtData5 = grvPensionDetails.Items[i].FindControl("intauditeddeletioncount") as TextBox; //@intauditeddeletioncount 
            if (txtData5.Text == "")
            {
                TextBox txtData51 = grvPensionDetails.Items[i].FindControl("intdeletioncount") as TextBox;
                if (txtData51.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtData51.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData5.Text.ToString()));
            }
            ///
              TextBox txtData6 = grvPensionDetails.Items[i].FindControl("intauditedbalancecount") as TextBox; //@intauditedbalancecount 
            if (txtData6.Text == "")
            {
                TextBox txtData61 = grvPensionDetails.Items[i].FindControl("intbalancecount") as TextBox;
                if (txtData61.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(txtData61.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData6.Text.ToString()));
            }
            //
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int ep = objcomm.update("SP_tb_directbeneficiaryexpenditure_U", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
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
    protected void grvPensionDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
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
