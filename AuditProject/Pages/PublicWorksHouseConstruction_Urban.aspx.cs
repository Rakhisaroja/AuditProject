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
public partial class Pages_PublicWorksConstruction_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
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


    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ds = objCom.FillData("[SP_tb_HouseConstructionUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvOther.Visible = true;
            grvOther.DataSource = ds;
            grvOther.DataBind();
            
               
        }
        disabletextbox();


        // SetGridDefaultCmnt();
    }
    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofconstruction") as TextBox;
                TextBox text2 = grvOther.Items[i].FindControl("intnoofbenediciaries") as TextBox;
                TextBox text3 = grvOther.Items[i].FindControl("floatamount") as TextBox;
                TextBox text4 = grvOther.Items[i].FindControl("intnoofcompleted") as TextBox;




                TextBox text11 = grvOther.Items[i].FindControl("chvnameofconstructionAud") as TextBox;
                TextBox text21 = grvOther.Items[i].FindControl("intnoofbenediciariesAud") as TextBox;
                TextBox text31 = grvOther.Items[i].FindControl("floatamountAud") as TextBox;
                TextBox text41 = grvOther.Items[i].FindControl("intnoofcompletedAud") as TextBox;



                text11.Text = text1.Text;
                text21.Text = text2.Text;
                text31.Text = text3.Text;
                text41.Text = text4.Text;
          
                 
            }
        }
    }

    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofconstruction") as TextBox;
                text1.ReadOnly = false;

                TextBox text2 = grvOther.Items[i].FindControl("intnoofbenediciaries") as TextBox;
                text2.ReadOnly = false;

                TextBox text3 = grvOther.Items[i].FindControl("floatamount") as TextBox;
                text3.ReadOnly = false;

                TextBox text4 = grvOther.Items[i].FindControl("intnoofcompleted") as TextBox;
                text4.ReadOnly = false;









                TextBox text11 = grvOther.Items[i].FindControl("chvnameofconstructionAud") as TextBox;
                text1.ReadOnly = false;

                TextBox text21 = grvOther.Items[i].FindControl("intnoofbenediciariesAud") as TextBox;
                text21.ReadOnly = true;
                TextBox text31 = grvOther.Items[i].FindControl("floatamountAud") as TextBox;
                text31.ReadOnly = true;
                TextBox text41 = grvOther.Items[i].FindControl("intnoofcompletedAud") as TextBox;
                text41.ReadOnly = true;



            }
        }
        else
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofconstruction") as TextBox;
                text1.ReadOnly = true;

                TextBox text2 = grvOther.Items[i].FindControl("intnoofbenediciaries") as TextBox;
                text2.ReadOnly = true;

                TextBox text3 = grvOther.Items[i].FindControl("floatamount") as TextBox;
                text3.ReadOnly = true;

                TextBox text4 = grvOther.Items[i].FindControl("intnoofcompleted") as TextBox;
                text4.ReadOnly = true;



                TextBox text11 = grvOther.Items[i].FindControl("chvnameofconstructionAud") as TextBox;
                text1.ReadOnly = false;

                TextBox text21 = grvOther.Items[i].FindControl("intnoofbenediciariesAud") as TextBox;
                text21.ReadOnly = false;
                TextBox text31 = grvOther.Items[i].FindControl("floatamountAud") as TextBox;
                text31.ReadOnly = false;
                TextBox text41 = grvOther.Items[i].FindControl("intnoofcompletedAud") as TextBox;
                text41.ReadOnly = false;

            }
        }
    }
    public void SetStreetLightInitialRow()
    {
        //LapsePerce LapseAmt  manoenSpentPerce manoenSpentAmt AnnualPlanAssuredtype AnnualPlanAssuredAmt RecieptPayment
        //RecieptPayment StateSanctAmt StateAlotAmt StateAlotAmt txtfundtype SLNO
        ArrayList arr = new ArrayList();
        arr.Add("txtSlno");
        arr.Add("txtGroupName");
        arr.Add("txtChairmanName");
        arr.Add("txtConveneorName");
        arr.Add("txtMeetingCount");
        arr.Add("txtStatusreport");
        arr.Add("txtMonitoringCommitte");
        arr.Add("txtMonitoringRpt");
        arr.Add("txtAuditGroupName");

       

        gblObj.SetRepeaterDefault(grvOther, arr);
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicShelter_Urban.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        pnlNewEntry.Visible = false;
        fillGrid();

    }
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        //[intlbid]
        //   ,[intfinancalyearid]
        //   ,[intstandingcommitteetype]
        //   ,[chvnameofchairman]
        //   ,[chvnameofchairmanmal]
        //   ,[chvnameofconvenor]
        //   ,[chvnameofconvenormal]
        //   ,[intnoofmeetings]
        //   ,[tnystatusreport]
        //   ,[tnymonitoringcommittee]
        //   ,[tnymonitoringreport]
        //   ,chvAuditnameofchairman 
        //   ,chvAuditnameofchairmanmal 
        //   ,chvAuditnameofconvenor 
        //   ,chvAuditnameofconvenormal
        //   ,intAuditnoofmeetings
        //   ,tnyAuditstatusreport
        //   ,tnyAuditmonitoringcommittee 
        //   ,tnyAuditmonitoringreport

        //   ,numUserEntry
        //   ,numSeatEntry
        //   ,dtDate
        //   ,intStatus)
        for (int i = 0; i < grvOther.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));

            Label intHouseID1 = grvOther.Items[i].FindControl("intHouselID") as Label;
            arrIn.Add(Convert.ToInt32(intHouseID1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"]));
            TextBox lblData22 = grvOther.Items[i].FindControl("chvnameofconstruction") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData22.Text != "")
            {
                arrIn.Add(lblData22.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            //aud
            TextBox lblData221 = grvOther.Items[i].FindControl("chvnameofconstructionAud") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData221.Text != "")
            {
                arrIn.Add(lblData221.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }







            TextBox txtData2 = grvOther.Items[i].FindControl("intnoofbenediciaries") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData2.Text != "")
            {
                arrIn.Add(Convert.ToInt32( txtData2.Text));

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            //aud
            TextBox txtData21 = grvOther.Items[i].FindControl("intnoofbenediciariesAud") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData21.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData21.Text));

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }



            TextBox lblData33 = grvOther.Items[i].FindControl("floatamount") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData33.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData33.Text));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
          //aud

            TextBox lblData331 = grvOther.Items[i].FindControl("floatamountAud") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData331.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData331.Text));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }

            TextBox lblData23 = grvOther.Items[i].FindControl("intnoofcompleted") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData23.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData23.Text));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            //aud

            TextBox lblData231 = grvOther.Items[i].FindControl("intnoofcompletedAud") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData231.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData231.Text));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);
            int row = objcomm.update("SP_tb_houseconstructionUrban_IU", arrIn);
             
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
        //}
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
       // Response.Redirect("FinanceOtherCommittees.aspx");
        Response.Redirect("HouseDetails_Urban.aspx");
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        
        if (txtnameofhouseconsruction.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter construction Name of the house  ') ;", true);
            txtnameofhouseconsruction.Focus();
            gblObj.setFocus(txtnameofhouseconsruction, this);
            return false;
        }
        else if (txtamount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the amount') ;", true);
            txtamount.Focus();
            gblObj.setFocus(txtamount, this);
            return false;
        }
        else if (txtnoofbeneficiary.Text== "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the number of beneficiary') ;", true);
            txtnoofbeneficiary.Focus();
            gblObj.setFocus(txtnoofbeneficiary, this);
            return false;
        }
        else if (txtnoofcompleted.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the number of completed') ;", true);
            txtnoofcompleted.Focus();
            gblObj.setFocus(txtnoofcompleted, this);
            return false;
        }


        //else if (ddlStatusreport.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
        //    ddlStatusreport.Focus();
        //    gblObj.setFocus(ddlStatusreport, this);
        //    return false;
        //}
        //else  if (ddlWorkingGroup.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
        //    ddlWardNo.Focus();
        //    gblObj.setFocus(ddlWardNo, this);
        //    return false;
        //}

        return true;
    }
    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        if (Validation() == true)
        {
            savenew();

            pnlNewEntry.Visible = false;
            fillGrid();
        }
    }
    public void savenew()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        
        
        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(lblGSNo.Text));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        

        if (txtnameofhouseconsruction.Text != "")
        {
            arrIn.Add(txtnameofhouseconsruction.Text.ToString());
            arrIn.Add(txtnameofhouseconsruction.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
       
        if (txtnoofbeneficiary.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofbeneficiary.Text));
            arrIn.Add(Convert.ToInt32(txtnoofbeneficiary.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
      
        if (txtamount.Text!= "")
        {
            arrIn.Add(Convert.ToInt32(txtamount.Text));
            arrIn.Add(Convert.ToInt32(txtamount.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        if (txtnoofcompleted.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofcompleted.Text));
            arrIn.Add(Convert.ToInt32(txtnoofcompleted.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

      
        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));       
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_houseconstructionUrban_IU", arrIn);
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
        arrIn.Clear();
        Response.Redirect(Request.Url.ToString());
    }

    public void setID()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        // arr.Add(ddlWardNo.SelectedValue);
        ds = objcomm.FillData("SP_tb_Houseconstruction_setID", arr, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGSNo.Text = ds.Tables[0].Rows[0][0].ToString();
        }

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (pnlNewEntry.Visible == true)
        {
            pnlNewEntry.Visible = false;
        }
        else
        {


            setID();
            GlobalClass gbl = new GlobalClass();
            pnlNewEntry.Visible = true;
            gbl.ResetFormControlValues(this);
            fillGrid();
            //pnlNewEntry.Visible = true;
             
        }
    }





   
}
