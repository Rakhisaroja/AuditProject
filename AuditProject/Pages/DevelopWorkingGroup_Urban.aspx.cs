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
public partial class Pages_DevelopWorkingGroup_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //SetStreetLightInitialRow();
            DataSet ds = new DataSet();
            CommonClass objCom = new CommonClass();
            GlobalClass gblObj = new GlobalClass();
            ArrayList arr = new ArrayList();
            arr.Add(6);
            ds = objCom.FillData("[SP_ML_WorkingGroup_S]", arr, CommandType.StoredProcedure);
            gblObj.FillCombo(ddlWorkingGroup, ds, 1);
            fillGrid();
            chkStatus();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }

            Session["Flag"] = 0;
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
        arrIn.Add(6);
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ds = objCom.FillData("[SP_tb_WorkingGroupUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvFinanceWorking.Visible = true;
            grvFinanceWorking.DataSource = ds;
            grvFinanceWorking.DataBind();
            int chk = 0;
            for (int i = 0; i < grvFinanceWorking.Items.Count; i++)
            {
                DropDownList text14 = grvFinanceWorking.Items[i].FindControl("tnystatusreport") as DropDownList;
                text14.SelectedValue = ds.Tables[0].Rows[i][10].ToString();
                DropDownList text24 = grvFinanceWorking.Items[i].FindControl("tnymonitoringcommittee") as DropDownList;
                text24.SelectedValue = ds.Tables[0].Rows[i][11].ToString();
                DropDownList text34 = grvFinanceWorking.Items[i].FindControl("tnymonitoringreport") as DropDownList;
                text34.SelectedValue = ds.Tables[0].Rows[i][12].ToString();

                DropDownList text44 = grvFinanceWorking.Items[i].FindControl("tnyAuditstatusreport") as DropDownList;
                text44.SelectedValue = ds.Tables[0].Rows[i][19].ToString();
                DropDownList text54 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringcommittee") as DropDownList;
                text54.SelectedValue = ds.Tables[0].Rows[i][20].ToString();
                DropDownList text64 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringreport") as DropDownList;
                text64.SelectedValue = ds.Tables[0].Rows[i][21].ToString();


                //NEW
                DropDownList text74 = grvFinanceWorking.Items[i].FindControl("tnyCoastalArea") as DropDownList;
                text74.SelectedValue = ds.Tables[0].Rows[i][22].ToString();


                DropDownList text84 = grvFinanceWorking.Items[i].FindControl("tnyfisheInspector") as DropDownList;
                text84.SelectedValue = ds.Tables[0].Rows[i][23].ToString();

        



                DropDownList text95 = grvFinanceWorking.Items[i].FindControl("tnyAuditCoastalArea") as DropDownList;
                text95.SelectedValue = ds.Tables[0].Rows[i][25].ToString();


                DropDownList text96 = grvFinanceWorking.Items[i].FindControl("tnyAuditfisheInspector") as DropDownList;
                text96.SelectedValue = ds.Tables[0].Rows[i][26].ToString();







            }
            disabletextbox();
        }

        // SetGridDefaultCmnt();
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvFinanceWorking.Items.Count; i++)
            {
                TextBox text1 = grvFinanceWorking.Items[i].FindControl("chvnameofchairman") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvFinanceWorking.Items[i].FindControl("chvnameofconvenor") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvFinanceWorking.Items[i].FindControl("intnoofmeetings") as TextBox;
                text3.ReadOnly = true;
                DropDownList text4 = grvFinanceWorking.Items[i].FindControl("tnystatusreport") as DropDownList;
                text4.Enabled = false;
                DropDownList text5 = grvFinanceWorking.Items[i].FindControl("tnymonitoringcommittee") as DropDownList;
                text5.Enabled = false;
                DropDownList text6 = grvFinanceWorking.Items[i].FindControl("tnymonitoringreport") as DropDownList;
                text6.Enabled = false;

                
                //new

                DropDownList text74 = grvFinanceWorking.Items[i].FindControl("tnyCoastalArea") as DropDownList;
                text74.Enabled = false;


                DropDownList text84 = grvFinanceWorking.Items[i].FindControl("tnyfisheInspector") as DropDownList;
                text84.Enabled = false;


                TextBox text878 = grvFinanceWorking.Items[i].FindControl("txtfishZoneDev") as TextBox;
                text878.ReadOnly = true;
                
                
                
                
                
                
                
                
                TextBox text11 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofchairman") as TextBox;
                text11.ReadOnly = true;
                TextBox text21 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofconvenor") as TextBox;
                text21.ReadOnly = true;
                TextBox text31 = grvFinanceWorking.Items[i].FindControl("intAuditnoofmeetings") as TextBox;
                text31.ReadOnly = true;
                DropDownList text41 = grvFinanceWorking.Items[i].FindControl("tnyAuditstatusreport") as DropDownList;
                text41.Enabled = false;
                DropDownList text51 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringcommittee") as DropDownList;
                text51.Enabled = false;
                DropDownList text61 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringreport") as DropDownList;
                text61.Enabled = false;

                //new

                DropDownList text95 = grvFinanceWorking.Items[i].FindControl("tnyAuditCoastalArea") as DropDownList;
                text95.Enabled = false;


                DropDownList text96 = grvFinanceWorking.Items[i].FindControl("tnyAuditfisheInspector") as DropDownList;
                text96.Enabled = false;



                TextBox text888 = grvFinanceWorking.Items[i].FindControl("txtAuditfishZoneDev") as TextBox;
                text888.ReadOnly = true;
            }
        }
        else
        {
            for (int i = 0; i < grvFinanceWorking.Items.Count; i++)
            {
                TextBox text1 = grvFinanceWorking.Items[i].FindControl("chvnameofchairman") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvFinanceWorking.Items[i].FindControl("chvnameofconvenor") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvFinanceWorking.Items[i].FindControl("intnoofmeetings") as TextBox;
                text3.ReadOnly = true;
                DropDownList text4 = grvFinanceWorking.Items[i].FindControl("tnystatusreport") as DropDownList;
                text4.Enabled = false;
                DropDownList text5 = grvFinanceWorking.Items[i].FindControl("tnymonitoringcommittee") as DropDownList;
                text5.Enabled = false;
                DropDownList text6 = grvFinanceWorking.Items[i].FindControl("tnymonitoringreport") as DropDownList;
                text6.Enabled = false;

                
                //new

                DropDownList text74 = grvFinanceWorking.Items[i].FindControl("tnyCoastalArea") as DropDownList;
                text74.Enabled = false;


                DropDownList text84 = grvFinanceWorking.Items[i].FindControl("tnyfisheInspector") as DropDownList;
                text84.Enabled = false;


                TextBox text878 = grvFinanceWorking.Items[i].FindControl("txtfishZoneDev") as TextBox;
                text878.ReadOnly = true;




                
                TextBox text11 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofchairman") as TextBox;
                text11.ReadOnly = false;
                TextBox text21 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofconvenor") as TextBox;
                text21.ReadOnly = false;
                TextBox text31 = grvFinanceWorking.Items[i].FindControl("intAuditnoofmeetings") as TextBox;
                text31.ReadOnly = false;
                DropDownList text41 = grvFinanceWorking.Items[i].FindControl("tnyAuditstatusreport") as DropDownList;
                text41.Enabled = true;
                DropDownList text51 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringcommittee") as DropDownList;
                text51.Enabled = true;
                DropDownList text61 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringreport") as DropDownList;
                text61.Enabled = true;

                //new

                DropDownList text95 = grvFinanceWorking.Items[i].FindControl("tnyAuditCoastalArea") as DropDownList;
                text95.Enabled = true;


                DropDownList text96 = grvFinanceWorking.Items[i].FindControl("tnyAuditfisheInspector") as DropDownList;
                text96.Enabled = true;



                TextBox text888 = grvFinanceWorking.Items[i].FindControl("txtAuditfishZoneDev") as TextBox;
                text888.ReadOnly = false;



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

        arr.Add("txtAuditChairmanName");
        arr.Add("txtAuditConveneorName");

        arr.Add("txtAuditMeetingCount");
        arr.Add("txtAuditStatusreport");

        arr.Add("txtAuditMonitoringCommitte");
        arr.Add("txtAuditMonitoringRpt");





        gblObj.SetRepeaterDefault(grvFinanceWorking, arr);
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("AnnualPlanExpenditureDevelop_Urban.aspx");
    }
    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvFinanceWorking.Items.Count; i++)
            {
                TextBox text1 = grvFinanceWorking.Items[i].FindControl("chvnameofchairman") as TextBox;
                TextBox text2 = grvFinanceWorking.Items[i].FindControl("chvnameofconvenor") as TextBox;
                TextBox text3 = grvFinanceWorking.Items[i].FindControl("intnoofmeetings") as TextBox;
                DropDownList text4 = grvFinanceWorking.Items[i].FindControl("tnystatusreport") as DropDownList;
                DropDownList text5 = grvFinanceWorking.Items[i].FindControl("tnymonitoringcommittee") as DropDownList;
                DropDownList text6 = grvFinanceWorking.Items[i].FindControl("tnymonitoringreport") as DropDownList;


                //new

                DropDownList text74 = grvFinanceWorking.Items[i].FindControl("tnyCoastalArea") as DropDownList;
               


                DropDownList text84 = grvFinanceWorking.Items[i].FindControl("tnyfisheInspector") as DropDownList;



                TextBox text878 = grvFinanceWorking.Items[i].FindControl("txtfishZoneDev") as TextBox;
                




                TextBox text11 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofchairman") as TextBox;
                TextBox text21 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofconvenor") as TextBox;
                TextBox text31 = grvFinanceWorking.Items[i].FindControl("intAuditnoofmeetings") as TextBox;
                DropDownList text41 = grvFinanceWorking.Items[i].FindControl("tnyAuditstatusreport") as DropDownList;
                DropDownList text51 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringcommittee") as DropDownList;
                DropDownList text61 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringreport") as DropDownList;


                DropDownList text95 = grvFinanceWorking.Items[i].FindControl("tnyAuditCoastalArea") as DropDownList;
              
                DropDownList text96 = grvFinanceWorking.Items[i].FindControl("tnyAuditfisheInspector") as DropDownList;



                TextBox text888 = grvFinanceWorking.Items[i].FindControl("txtAuditfishZoneDev") as TextBox;
              








                text11.Text = text1.Text;
                text21.Text = text2.Text;
                text31.Text = text3.Text;
                text41.SelectedValue = text4.SelectedValue;
                text51.SelectedValue = text5.SelectedValue;
                text61.SelectedValue = text6.SelectedValue;


                //new


                text95.Text = text74.Text;
                text96.Text = text84.Text;

                text888.Text = text878.Text;



            }
        }
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
        for (int i = 0; i < grvFinanceWorking.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            arrIn.Add(Convert.ToInt32(Session["Year"]));
            Label intstandingcommit = grvFinanceWorking.Items[i].FindControl("@intstandingcommitteetype") as Label;
            Label intWorkingG = grvFinanceWorking.Items[i].FindControl("intWorkingGroupID") as Label;
            arrIn.Add(6);
            arrIn.Add(Convert.ToInt32(intWorkingG.Text.ToString()));
            //TextBox txtData1 = grvMergeHeader.Items[i].FindControl("intWardNo") as TextBox;  // item.FindControl("intWardNo") as Label;

            //    arrIn.Add(txtData1.Text.ToString());
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
            TextBox lblData22 = grvFinanceWorking.Items[i].FindControl("chvnameofchairman") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData22.Text != "")
            {
                arrIn.Add(lblData22.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofchairman") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData2.Text != "")
            {
                arrIn.Add(txtData2.Text.ToString());

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
            TextBox lblData33 = grvFinanceWorking.Items[i].FindControl("chvnameofconvenor") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData33.Text != "")
            {
                arrIn.Add(lblData33.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            ///////////3
            TextBox txtData3 = grvFinanceWorking.Items[i].FindControl("chvAuditnameofconvenor") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtData3.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData3.Text.ToString());
            }
           
            ////////////4
            TextBox lblData44 = grvFinanceWorking.Items[i].FindControl("intnoofmeetings") as TextBox; //item.FindControl("intparticipantMale") as Label;
            if (lblData44.Text != "")
            {
                arrIn.Add(lblData44.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvFinanceWorking.Items[i].FindControl("intAuditnoofmeetings") as TextBox;//item.FindControl("intAuditedtotVotersMale") as TextBox;
            if (txtData4.Text == "")
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData4.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData4.Text.ToString());
            }
            ///////////////5
            DropDownList lblData55 = grvFinanceWorking.Items[i].FindControl("tnystatusreport") as DropDownList; //item.FindControl("intparticipantfemale") as Label;
            if (lblData55.SelectedIndex > 0)
            {
                arrIn.Add(lblData55.SelectedValue.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            DropDownList txtData5 = grvFinanceWorking.Items[i].FindControl("tnyAuditstatusreport") as DropDownList; //item.FindControl("intAuditedtotVotersFemale") as TextBox;
            if (txtData5.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(lblData5.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData5.SelectedValue.ToString());
            }

            //////////////6
            DropDownList lblData66 = grvFinanceWorking.Items[i].FindControl("tnymonitoringcommittee") as DropDownList; //item.FindControl("chvplacemal") as Label;
            if (lblData66.SelectedIndex > 0)
            {
                arrIn.Add(lblData66.SelectedValue.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            DropDownList txtData6 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringcommittee") as DropDownList; //item.FindControl("chvauditedplacemal") as TextBox;
            if (txtData6.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                //  arrIn.Add(lblData6.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData6.SelectedValue.ToString());
            }
            /////////7
            DropDownList lblData77 = grvFinanceWorking.Items[i].FindControl("tnymonitoringreport") as DropDownList; //item.FindControl("dtgramasabha") as Label;
            if (lblData77.SelectedIndex > 0)
            {
                arrIn.Add(lblData77.SelectedValue.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            DropDownList txtData7 = grvFinanceWorking.Items[i].FindControl("tnyAuditmonitoringreport") as DropDownList; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData7.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData7.Text.ToString());
            }

            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);



            //new

            DropDownList txtData87 = grvFinanceWorking.Items[i].FindControl("tnyCoastalArea") as DropDownList; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData87.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData87.Text.ToString());
            }


            DropDownList txtData34 = grvFinanceWorking.Items[i].FindControl("tnyfisheInspector") as DropDownList; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData34.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData34.Text.ToString());
            }

            TextBox lblData343 = grvFinanceWorking.Items[i].FindControl("txtfishZoneDev") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData343.Text != "")
            {
                arrIn.Add(lblData343.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            

            //Auditnew

            DropDownList txtData43 = grvFinanceWorking.Items[i].FindControl("tnyAuditCoastalArea") as DropDownList; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData43.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData43.Text.ToString());
            }



            DropDownList txtData22 = grvFinanceWorking.Items[i].FindControl("tnyAuditfisheInspector") as DropDownList; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData22.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData22.Text.ToString());
            }

            TextBox lblData332 = grvFinanceWorking.Items[i].FindControl("txtAuditfishZoneDev") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData332.Text != "")
            {
                arrIn.Add(lblData332.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }




            int ep = objcomm.update("SP_tb_WorkingGroupUrban_IU", arrIn);
            if (ep > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
        //}
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgricultureDetails_Urban.aspx");
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (ddlWorkingGroup.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Working Group') ;", true);
            ddlWorkingGroup.Focus();
            gblObj.setFocus(ddlWorkingGroup, this);
            return false;
        }
        else if (txtChairMan.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the Chairman') ;", true);
            txtChairMan.Focus();
            gblObj.setFocus(txtChairMan, this);
            return false;
        }
        else if (txtConveneor.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the Convener') ;", true);
            txtConveneor.Focus();
            gblObj.setFocus(txtConveneor, this);
            return false;
        }
        else if (txtnoofMeeting.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter no of Meeting') ;", true);
            txtnoofMeeting.Focus();
            gblObj.setFocus(txtnoofMeeting, this);
            return false;
        }

        else if (ddlStatusreport.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Status Report status') ;", true);
            ddlStatusreport.Focus();
            gblObj.setFocus(ddlStatusreport, this);
            return false;
        }
        else if (ddlMonitoringCom.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Monitoring Committee Status') ;", true);
            ddlMonitoringCom.Focus();
            gblObj.setFocus(ddlMonitoringCom, this);
            return false;
        }
        else if (ddlMonitoringRpt.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Monitoring Report Status') ;", true);
            ddlMonitoringRpt.Focus();
            gblObj.setFocus(ddlMonitoringRpt, this);
            return false;
        }
        else if (ddlplace.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Place Status') ;", true);
            ddlplace.Focus();
            gblObj.setFocus(ddlplace, this);
            return false;
        }
        else if (ddlinspector.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Fisheries Inspector Status') ;", true);
            ddlinspector.Focus();
            gblObj.setFocus(ddlinspector, this);
            return false;
        }
        else if (txtfishwg.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Working group details(Fisheries)') ;", true);
            txtfishwg.Focus();
            gblObj.setFocus(txtfishwg, this);
            return false;
        }

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
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        arrIn.Add(6);

        arrIn.Add(ddlWorkingGroup.SelectedValue);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        if (txtChairMan.Text != "")
        {
            arrIn.Add(txtChairMan.Text.ToString());
            arrIn.Add(txtChairMan.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        if (txtConveneor.Text != "")
        {
            arrIn.Add(txtConveneor.Text.ToString());
            arrIn.Add(txtConveneor.Text.ToString());

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        
        ////////////4
        if (txtnoofMeeting.Text != "")
        {
            arrIn.Add(txtnoofMeeting.Text.ToString());
            arrIn.Add(txtnoofMeeting.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        // arrIn.Add(DBNull.Value);
        ///////////////5
        if (ddlStatusreport.SelectedIndex > 0)
        {
            arrIn.Add(Convert.ToInt32(ddlStatusreport.SelectedValue.ToString()));
            arrIn.Add(Convert.ToInt32(ddlStatusreport.SelectedValue.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        // arrIn.Add(DBNull.Value);
        //////////////6
        if (ddlMonitoringCom.SelectedIndex > 0)
        {
            arrIn.Add(ddlMonitoringCom.SelectedValue.ToString());
            arrIn.Add(ddlMonitoringCom.SelectedValue.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        // arrIn.Add(DBNull.Value);
        /////////7
        if (ddlMonitoringRpt.SelectedIndex > 0)
        {
            arrIn.Add(ddlMonitoringRpt.SelectedValue.ToString());
            arrIn.Add(ddlMonitoringRpt.SelectedValue.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        // arrIn.Add(DBNull.Value);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);



        if (ddlplace.SelectedIndex > 0)
        {
            arrIn.Add(ddlplace.SelectedValue.ToString());
            

        }
        else
        {
            arrIn.Add(DBNull.Value);
           
        }


        if (ddlinspector.SelectedIndex > 0)
        {
            arrIn.Add(ddlinspector.SelectedValue.ToString());
           

        }
        else
        {
            arrIn.Add(DBNull.Value);
            
        }

        if (txtfishwg.Text != "")
        {
            arrIn.Add(txtfishwg.Text.ToString());
            
        }
        else
        {
            arrIn.Add(DBNull.Value);
           
        }



        //aud

        if (ddlplace.SelectedIndex > 0)
        {
            
            arrIn.Add(ddlplace.SelectedValue.ToString());

        }
        else
        {
            arrIn.Add(DBNull.Value);
            
        }


        if (ddlinspector.SelectedIndex > 0)
        {
            arrIn.Add(ddlinspector.SelectedValue.ToString());
           

        }
        else
        {
            arrIn.Add(DBNull.Value);
            
        }

        if (txtfishwg.Text != "")
        {
            arrIn.Add(txtfishwg.Text.ToString());
            
        }
        else
        {
            arrIn.Add(DBNull.Value);
            
        }


        int ep = objcomm.update("SP_tb_WorkingGroupUrban_IU", arrIn);
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
        arrIn.Clear();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (pnlNewEntry.Visible == true)
        {
            pnlNewEntry.Visible = false;
        }
        else
        {
            GlobalClass gbl = new GlobalClass();
            pnlNewEntry.Visible = true;
            gbl.ResetFormControlValues(this);
            fillGrid();
            //pnlNewEntry.Visible = true;

        }
    }

    protected void ddlWorkingGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWorkingGroup.SelectedIndex > 0)
        {
            int chk = Convert.ToInt32(ddlWorkingGroup.SelectedValue);
            ArrayList arrIn = new ArrayList();
            GlobalClass gbl = new GlobalClass();
            gbl.ResetFormControlValues(this);
            fillGrid();
            ddlWorkingGroup.SelectedValue = chk.ToString();
            arrIn.Add(Session["LBID"].ToString());
            arrIn.Add(Session["Year"].ToString());
            arrIn.Add(6);
            arrIn.Add(ddlWorkingGroup.SelectedValue);
            DataSet ds = new DataSet();
            CommonClass objCom = new CommonClass();
            ds = objCom.FillData("[SP_tb_WorkingGroup_Select]", arrIn, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtChairMan.Text = ds.Tables[0].Rows[0][6].ToString();
                txtConveneor.Text = ds.Tables[0].Rows[0][8].ToString();
                txtnoofMeeting.Text = ds.Tables[0].Rows[0][9].ToString();
                ddlStatusreport.SelectedValue = ds.Tables[0].Rows[0][10].ToString();
                ddlMonitoringCom.SelectedValue = ds.Tables[0].Rows[0][11].ToString();
                ddlMonitoringRpt.SelectedValue = ds.Tables[0].Rows[0][12].ToString();

            }
        }
    }
}