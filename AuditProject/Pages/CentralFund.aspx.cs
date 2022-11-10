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

public partial class Pages_CentralFund : System.Web.UI.Page
{
    int row;
    CommonClass objcom = new CommonClass();
   
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            fillGrid();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Submitted Successfully ", this);
            }
            //FillGramasabha();           
            Session["Flag"] = 0;
        }
       
    }
    public void SetInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");

        arr.Add("vchaccounthead");
        arr.Add("vchaccountheadcode");
        arr.Add("numprevcb");
        arr.Add("numincome");
        arr.Add("numexpenditure");
        arr.Add("numauditedprevcb");
        arr.Add("numauditedincome");
        arr.Add("numauditedexpenditure");
        gblObj.SetRepeaterDefault(rptCentralFund, arr);

    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
        }


    }


    public void ValueAssign()
    {
         for (int i = 0; i < rptCentralFund.Items.Count; i++)
            {
                TextBox numprevcb = rptCentralFund.Items[i].FindControl("numprevcb") as TextBox;
                TextBox numincome = rptCentralFund.Items[i].FindControl("numincome") as TextBox;
                TextBox numexpenditure = rptCentralFund.Items[i].FindControl("numexpenditure") as TextBox;




             TextBox numauditedprevcb = rptCentralFund.Items[i].FindControl("numauditedprevcb") as TextBox;
                TextBox numauditedincome = rptCentralFund.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox numauditedexpenditure = rptCentralFund.Items[i].FindControl("numauditedexpenditure") as TextBox;

                numauditedprevcb.Text = numprevcb.Text;
                numauditedincome.Text = numincome.Text;
                numauditedexpenditure.Text = numexpenditure.Text;
        }
    }


    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptCentralFund.Items.Count; i++)
            {
                TextBox numprevcb = rptCentralFund.Items[i].FindControl("numprevcb") as TextBox;
                TextBox numincome = rptCentralFund.Items[i].FindControl("numincome") as TextBox;
                TextBox numexpenditure = rptCentralFund.Items[i].FindControl("numexpenditure") as TextBox;


                numprevcb.ReadOnly = false;
                numincome.ReadOnly = false;
                numexpenditure.ReadOnly = false;
            }
        }
        else
        {
            for (int i = 0; i < rptCentralFund.Items.Count; i++)
            {
                TextBox numauditedprevcb = rptCentralFund.Items[i].FindControl("numauditedprevcb") as TextBox;
                TextBox numauditedincome = rptCentralFund.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox numauditedexpenditure = rptCentralFund.Items[i].FindControl("numauditedexpenditure") as TextBox;


                numauditedprevcb.ReadOnly = false;
                numauditedincome.ReadOnly = false;
                numauditedexpenditure.ReadOnly = false;

            }
        }

    }
    void fillGrid()
    {
           ArrayList arrFill = new ArrayList();
          
            arrFill.Clear();
            arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
            DataSet dsFill = objcom.FillData("tb_incomeexpendituremnregs_Sel", arrFill, CommandType.StoredProcedure);
            if (dsFill.Tables[0].Rows.Count > 0)
            {
                rptCentralFund.DataSource = dsFill;
                rptCentralFund.DataBind();
            }
            else
            {
                SetInitialRow();
            }
            SetEditable();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveData();
        fillGrid();
    }
    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < rptCentralFund.Items.Count; i++)
        {
            Label lblNumId = rptCentralFund.Items[i].FindControl("lblNumId") as Label;
            if (lblNumId.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblNumId.Text));
            }
            arrIn.Add(1);
            arrIn.Add(1);
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
           
            //Label lblincometype = rptNegative.Items[i].FindControl("lblincometype") as Label;
            //if (lblincometype.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToInt32(lblincometype.Text));
            //}
            Label vchaccountheadcode = rptCentralFund.Items[i].FindControl("vchaccountheadcode") as Label;
            if (vchaccountheadcode.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(vchaccountheadcode.Text));
            }

            Label lblccounthead = rptCentralFund.Items[i].FindControl("lblccounthead") as Label;
            if (lblccounthead.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(lblccounthead.Text);
            }
            arrIn.Add(1);





            TextBox numprevcb = rptCentralFund.Items[i].FindControl("numprevcb") as TextBox;
            if (numprevcb.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numprevcb.Text));
            }

            TextBox numincome = rptCentralFund.Items[i].FindControl("numincome") as TextBox;
            if (numincome.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numincome.Text));
            }

            arrIn.Add(DBNull.Value);

            TextBox numexpenditure = rptCentralFund.Items[i].FindControl("numexpenditure") as TextBox;
            if (numexpenditure.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numexpenditure.Text));
            }

            arrIn.Add(DBNull.Value);


            TextBox numauditedprevcb = rptCentralFund.Items[i].FindControl("numauditedprevcb") as TextBox;
            if (numauditedprevcb.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //if (numprevcb.Text != "")
                //{

                //    arrIn.Add(Convert.ToDouble(numprevcb.Text));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedprevcb.Text));
            }

            TextBox numauditedincome = rptCentralFund.Items[i].FindControl("numauditedincome") as TextBox;
            if (numauditedincome.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedincome.Text));
            }

            arrIn.Add(DBNull.Value);

            TextBox numauditedexpenditure = rptCentralFund.Items[i].FindControl("numauditedexpenditure") as TextBox;
            if (numauditedexpenditure.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedexpenditure.Text));
            }

            arrIn.Add(DBNull.Value);

            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

             row = objcomm.update("SP_tb_incomeexpendituremnregs_IU", arrIn);
             arrIn.Clear();
             if (row > 0)
             {
                 gblObj.MsgBoxOk("Saved Successfully ", this);
             }
        }
       

    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (txtType.Text == "")
        {
           
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Hospital') ;", true);
        
            gblObj.setFocus(txtType, this);
            return false;

        }

        return true;
    }

    public void clearTexts()
    {
        txtType.Text = "";
        txtOB.Text = "";
        txtIncm.Text = "";
        txtexp.Text = "";
    }
    protected void btnNewSave_Click(object sender, EventArgs e)
    {

        if (Validation() == true)
        {
            SaveNew();
            clearTexts();
            fillGrid();
            SetEditable();
        }
        pnlNewEntry.Visible = false;


      
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNewEntry.Visible = true;
    }
    public void SaveNew()
    {
         
        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(0);

        arrIn.Add(0);
        arrIn.Add(0);
      
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrIn.Add(0);

        if (txtType.Text != "")
       {
           arrIn.Add(txtType.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        arrIn.Add(1);


        if (txtOB.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOB.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtIncm.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtIncm.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(DBNull.Value);

        if (txtexp.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtexp.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        arrIn.Add(DBNull.Value);

        if (txtOB.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtOB.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtIncm.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtIncm.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(DBNull.Value);

        if (txtexp.Text != "")
        {
            arrIn.Add(Convert.ToDouble(txtexp.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        arrIn.Add(DBNull.Value);
        arrIn.Add(1);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

        int row = objcom.update("SP_tb_incomeexpendituremnregs_IU", arrIn);
        arrIn.Clear();
        if (row > 0)
        {
            //lblMessage.Visible = true;
            //lblMessage.Text = "Submitted Successfully!!";
            gblObj.MsgBoxOk("Submitted Successfully ", this);

            Session["Flag"] = 1;
        }

        Response.Redirect(Request.Url.ToString());

        
    }
    protected void btnDeleteSr_Click(object sender, ImageClickEventArgs e)
    {

          ImageButton button = (sender as ImageButton);
 
    //Get the command argument
    string commandArgument = button.CommandArgument;
 
    //Get the Repeater Item reference
    RepeaterItem item = button.NamingContainer as RepeaterItem;
 
    //Get the repeater item index
    int rowIndex = item.ItemIndex;

       // int rowIndex = ((sender as ImageButton).Parent.Parent as Repeater).r
    Label lblAccHd = (Label)rptCentralFund.Items[rowIndex].FindControl("vchaccountheadcode");

        Label txt9 = (Label)rptCentralFund.Items[rowIndex].FindControl("lblNumId");
        lblAccHd.Visible = true;
        txt9.Visible = true;

        //Session["intCCYearId"] = gendao.GetCCYearId();

        if (lblAccHd.Text != "")
        {
            DataSet dsGrid = new DataSet();
            ArrayList arrin = new ArrayList();
            arrin.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrin.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
            arrin.Add(Convert.ToInt64(lblAccHd.Text));
            arrin.Add(Convert.ToInt64(txt9.Text));
            int row = objcom.update("SP_tb_incomeexpendituremnregs_D", arrin);
        }
        lblAccHd.Visible = false;
        txt9.Visible = false;
        fillGrid();
        gblObj.MsgBoxOk("Row Deleted   !", this);
    }
}
