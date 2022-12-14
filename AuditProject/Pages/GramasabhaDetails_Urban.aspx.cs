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

public partial class Pages_GramasabhaDetails_Urban : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            fillGrid();
            DataSet ds = new DataSet();
            CommonClass objCom = new CommonClass();
            GlobalClass gblObj = new GlobalClass();
            ArrayList arr = new ArrayList();
            arr.Add(Session["LBID"]);
            ds = objCom.FillData("SP_TB_WardMaster_S",arr, CommandType.StoredProcedure);
            gblObj.FillCombo(ddlWardNo, ds, 0);
            gblObj.FillCombo(ddlWardName, ds, 1);
            chkStatus();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            if (Convert.ToInt32(Session["Flag"]) == 2)
            {
                gblObj.MsgBoxOk("Deleted sucessfully !", this);
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
            DataSet ds=new DataSet();
            CommonClass objCom=new CommonClass();
            ds = objCom.FillData("[SP_tb_gramasabhaUrban_S]", arrIn, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grvMergeHeader.DataSource = ds;
                grvMergeHeader.DataBind();
                disabletextbox();
            }       
        
        // SetGridDefaultCmnt();
    }
    public void ValueAssign() 
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                TextBox text1 = grvMergeHeader.Items[i].FindControl("inttotVotersfemale") as TextBox;                 
                TextBox text2 = grvMergeHeader.Items[i].FindControl("inttotVotersMale") as TextBox;                
                TextBox text3 = grvMergeHeader.Items[i].FindControl("intparticipantfemale") as TextBox;                 
                TextBox text4 = grvMergeHeader.Items[i].FindControl("intparticipantmale") as TextBox;                
                TextBox text5 = grvMergeHeader.Items[i].FindControl("chvplacemal") as TextBox;                 
                TextBox text6 = grvMergeHeader.Items[i].FindControl("dtgramasabha") as TextBox;                 
                TextBox text7 = grvMergeHeader.Items[i].FindControl("fltAttenPrece") as TextBox;                
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvremarks") as TextBox;

                TextBox text81 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersFemale") as TextBox;               
                TextBox text9 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersMale") as TextBox;               
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intaudiitedparticipantfemale") as TextBox;               
                TextBox text11 = grvMergeHeader.Items[i].FindControl("intauditedparticipantmale") as TextBox;              
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvauditedplacemal") as TextBox;               
                TextBox text13 = grvMergeHeader.Items[i].FindControl("dtauditedgramasabha") as TextBox;               
                TextBox text14 = grvMergeHeader.Items[i].FindControl("fltAuditAttenPrece") as TextBox;               
                TextBox text15 = grvMergeHeader.Items[i].FindControl("chvauditedremarks") as TextBox;


                text81.Text = text1.Text;
                text9.Text = text2.Text;
                text10.Text = text3.Text;
                text11.Text = text4.Text;
                text12.Text = text5.Text;
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
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                TextBox text1 = grvMergeHeader.Items[i].FindControl("inttotVotersfemale") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvMergeHeader.Items[i].FindControl("inttotVotersMale") as TextBox;
                text2.ReadOnly = false;
                TextBox text3 = grvMergeHeader.Items[i].FindControl("intparticipantfemale") as TextBox;
                text3.ReadOnly = false;
                TextBox text4 = grvMergeHeader.Items[i].FindControl("intparticipantmale") as TextBox;
                text4.ReadOnly = false;
                  TextBox text5 = grvMergeHeader.Items[i].FindControl("chvplacemal") as TextBox;
                text5.ReadOnly = false;
                TextBox text6 = grvMergeHeader.Items[i].FindControl("dtgramasabha") as TextBox;
                text6.ReadOnly = false;
                TextBox text7 = grvMergeHeader.Items[i].FindControl("fltAttenPrece") as TextBox;
                text7.ReadOnly = false;
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvremarks") as TextBox;
                text8.ReadOnly = false;


                TextBox text81 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersFemale") as TextBox;
                text81.ReadOnly = true;
                TextBox text9 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersMale") as TextBox;
                text9.ReadOnly = true;
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intaudiitedparticipantfemale") as TextBox;
                text10.ReadOnly = true;
                TextBox text11 = grvMergeHeader.Items[i].FindControl("intauditedparticipantmale") as TextBox;
                text11.ReadOnly = true;
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvauditedplacemal") as TextBox;
                text12.ReadOnly = true;
                TextBox text13 = grvMergeHeader.Items[i].FindControl("dtauditedgramasabha") as TextBox;
                text13.ReadOnly = true;
                TextBox text14 = grvMergeHeader.Items[i].FindControl("fltAuditAttenPrece") as TextBox;
                text14.ReadOnly = true;
                TextBox text15 = grvMergeHeader.Items[i].FindControl("chvauditedremarks") as TextBox;
                text15.ReadOnly = true;

                ImageButton del = grvMergeHeader.Items[i].FindControl("btnDelete") as ImageButton;
                del.Visible = true;
                //TextBox text16 = grvMergeHeader.Items[i].FindControl("chvAuditedEngFirstName") as TextBox;
                //text16.ReadOnly = true;

            }

        }
        else
        {
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                TextBox text1 = grvMergeHeader.Items[i].FindControl("inttotVotersfemale") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvMergeHeader.Items[i].FindControl("inttotVotersMale") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvMergeHeader.Items[i].FindControl("intparticipantfemale") as TextBox;
                text3.ReadOnly = true;
                TextBox text4 = grvMergeHeader.Items[i].FindControl("intparticipantmale") as TextBox;
                text4.ReadOnly = true;
                TextBox text5 = grvMergeHeader.Items[i].FindControl("chvplacemal") as TextBox;
                text5.ReadOnly = true;
                TextBox text6 = grvMergeHeader.Items[i].FindControl("dtgramasabha") as TextBox;
                text6.ReadOnly = true;
                TextBox text7 = grvMergeHeader.Items[i].FindControl("fltAttenPrece") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvremarks") as TextBox;
                text8.ReadOnly = true;


                TextBox text81 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersFemale") as TextBox;
                text81.ReadOnly = false;
                TextBox text9 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersMale") as TextBox;
                text9.ReadOnly = false;
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intaudiitedparticipantfemale") as TextBox;
                text10.ReadOnly = false;
                TextBox text11 = grvMergeHeader.Items[i].FindControl("intauditedparticipantmale") as TextBox;
                text11.ReadOnly = false;
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvauditedplacemal") as TextBox;
                text12.ReadOnly = false;
                TextBox text13 = grvMergeHeader.Items[i].FindControl("dtauditedgramasabha") as TextBox;
                text13.ReadOnly = false;
                TextBox text14 = grvMergeHeader.Items[i].FindControl("fltAuditAttenPrece") as TextBox;
                text14.ReadOnly = false;
                TextBox text15 = grvMergeHeader.Items[i].FindControl("chvauditedremarks") as TextBox;
                text15.ReadOnly = false;

                ImageButton del = grvMergeHeader.Items[i].FindControl("btnDelete") as ImageButton;
                del.Visible = false;
                //TextBox text16 = grvMergeHeader.Items[i].FindControl("chvAuditedEngFirstName") as TextBox;
                //text16.ReadOnly = false;
            }
        }
    }
    private void SetGridDefaultCmnt()
    {
        GlobalClass gblObj = new GlobalClass();
        ArrayList ar = new ArrayList();
        ar.Add("intWardNo");
        ar.Add("TotvoteFemale");
        ar.Add("Totvotemale");
        ar.Add("particvoteFemale");
        ar.Add("particvotemale");
        ar.Add("chvGSPlace");
        ar.Add("chvGSDate");
        ar.Add("AttendPrecen");
        ar.Add("Remarks");

        ar.Add("AuditintWardNo");
        ar.Add("AuditTotvoteFemale");
        ar.Add("AuditTotvotemale");
        ar.Add("AuditparticvoteFemale");
        ar.Add("Auditparticvotemale");
        ar.Add("AuditchvGSPlace");
        ar.Add("AuditchvGSDate");
        ar.Add("AuditAttendPrecen");
        ar.Add("AuditRemarks");
        //ar.Add("AgendaProcedure1");
        //ar.Add("AgendaProcedure2");
        //ar.Add("AgendaProcedure3");
       // gblObj.SetGridDefault(grvMergeHeader, ar);
         
    }
   

    protected void grvMergeHeader_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
  
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

       
        for (int i = 0; i < grvMergeHeader.Items.Count; i++)
        {
            Label intgramasabhano = grvMergeHeader.Items[i].FindControl("intgramasabhano") as Label;
            arrIn.Add(Convert.ToInt32(intgramasabhano.Text.ToString()));
            TextBox txtData1 = grvMergeHeader.Items[i].FindControl("intWardNo") as TextBox;  // item.FindControl("intWardNo") as Label;
          
                arrIn.Add(txtData1.Text.ToString());
                arrIn.Add(txtData1.Text.ToString());
                TextBox txtnoofmaleVote1 = grvMergeHeader.Items[i].FindControl("inttotVotersMale") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
                if (txtnoofmaleVote1.Text != "")
                {
                    arrIn.Add(txtnoofmaleVote1.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
                TextBox txtnoofmaleVoteaudit1 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersMale") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
                if (txtnoofmaleVoteaudit1.Text != "")
                {
                    arrIn.Add(txtnoofmaleVoteaudit1.Text.ToString());

                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            TextBox txtnoofFemaleVote1 = grvMergeHeader.Items[i].FindControl("inttotVotersfemale") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (txtnoofFemaleVote1.Text != "")
            {
                arrIn.Add(txtnoofFemaleVote1.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            ///////////3
            TextBox txtnoofFemaleVoteaudit1 = grvMergeHeader.Items[i].FindControl("intAuditedtotVotersfemale") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtnoofFemaleVoteaudit1.Text == "")
            {

                arrIn.Add(DBNull.Value);
               // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtnoofFemaleVoteaudit1.Text.ToString());
            }
            ////////////4
            TextBox txtnoofmaleParicipate1 = grvMergeHeader.Items[i].FindControl("intparticipantMale") as TextBox; //item.FindControl("intparticipantMale") as Label;
            if (txtnoofmaleParicipate1.Text != "")
            {
                arrIn.Add(txtnoofmaleParicipate1.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtnoofmaleParicipateaudit1 = grvMergeHeader.Items[i].FindControl("intauditedparticipantmale") as TextBox;//item.FindControl("intAuditedtotVotersMale") as TextBox;
            if (txtnoofmaleParicipateaudit1.Text == "")
            {
                arrIn.Add(DBNull.Value);
               // arrIn.Add(lblData4.Text.ToString());
            }
            else
            {
                arrIn.Add(txtnoofmaleParicipateaudit1.Text.ToString());
            }
            ///////////////5
            TextBox txtnoofFemaleParicipate1 = grvMergeHeader.Items[i].FindControl("intparticipantfemale") as TextBox; //item.FindControl("intparticipantfemale") as Label;
            if (txtnoofFemaleParicipate1.Text != "")
            {
                arrIn.Add(txtnoofFemaleParicipate1.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtnoofFemaleParicipateaudit1 = grvMergeHeader.Items[i].FindControl("intaudiitedparticipantfemale") as TextBox; //item.FindControl("intAuditedtotVotersFemale") as TextBox;
            if (txtnoofFemaleParicipateaudit1.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(lblData5.Text.ToString());
            }
            else
            {
                arrIn.Add(txtnoofFemaleParicipateaudit1.Text.ToString());
            }

            //////////////6
            TextBox lblData66 = grvMergeHeader.Items[i].FindControl("chvplacemal") as TextBox; //item.FindControl("chvplacemal") as Label;
            if (lblData66.Text != "")
            {
                arrIn.Add(lblData66.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData6 = grvMergeHeader.Items[i].FindControl("chvauditedplacemal") as TextBox; //item.FindControl("chvauditedplacemal") as TextBox;
            if (txtData6.Text == "")
            {
                arrIn.Add(DBNull.Value);
              //  arrIn.Add(lblData6.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData6.Text.ToString());
            }
            /////////7
            TextBox lblData77 = grvMergeHeader.Items[i].FindControl("dtgramasabha") as TextBox; //item.FindControl("dtgramasabha") as Label;
            if (lblData77.Text != "")
            {
                arrIn.Add(lblData77.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData7 = grvMergeHeader.Items[i].FindControl("dtauditedgramasabha") as TextBox; //item.FindControl("dtauditedgramasabha") as TextBox;
            if (txtData7.Text == "")
            {
                arrIn.Add(DBNull.Value);
               // arrIn.Add(lblData7.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData7.Text.ToString());
            }
            ///////////////8
            ////TextBox lblData88 = grvMergeHeader.Items[i].FindControl("fltAttenPrece") as TextBox; //item.FindControl("fltAttenPrece") as Label;
            ////if (lblData88.Text != "")
            ////{
            ////    arrIn.Add(lblData88.Text.ToString());
            ////}
            ////else
            ////{
            ////    arrIn.Add(DBNull.Value);
            ////}
            ////TextBox txtData8 = grvMergeHeader.Items[i].FindControl("fltAuditAttenPrece") as TextBox; //item.FindControl("fltAuditAttenPrece") as TextBox;
            ////if (txtData8.Text == "")
            ////{
            ////    TextBox lblData8 = grvMergeHeader.Items[i].FindControl("fltAttenPrece") as TextBox; //item.FindControl("fltAttenPrece") as Label;
            ////    if (lblData8.Text != "")
            ////    {
            ////        arrIn.Add(lblData8.Text.ToString());
            ////    }
            ////    else
            ////    {
            ////        arrIn.Add(DBNull.Value);
            ////    }
            ////   // arrIn.Add(lblData8.Text.ToString());
            ////}
            ////else
            ////{
            ////    arrIn.Add(txtData8.Text.ToString());
            ////}

            /////////////////////
            double fvote = 0; double mvote = 0; double fparti = 0; double mparti = 0;
            double per  = 0.0;
            if (txtnoofFemaleVote1.Text != "")
            {
                fvote = Convert.ToDouble(txtnoofFemaleVote1.Text);
            }
            else
            {
                fvote = 0;
            }
            if (txtnoofmaleVote1.Text != "")
            {
                mvote = Convert.ToDouble(txtnoofmaleVote1.Text);
            }
            else
            {
                mvote = 0;
            }
            if (txtnoofFemaleParicipate1.Text != "")
            {
                fparti = Convert.ToDouble(txtnoofFemaleParicipate1.Text);
            }
            else
            {
                fparti = 0;
            }
            if (txtnoofmaleParicipate1.Text != "")
            {
                mparti = Convert.ToDouble(txtnoofmaleParicipate1.Text);
            }
            else
            {
                mparti = 0;
            }
            per  = Math.Round((((fparti + mparti) / (fvote + mvote)) * 100), 2);
            if ((fvote + mvote) == 0)
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(per));
            }
            /////////////////////audit
            double fvoteaudit = 0; double mvoteaudit = 0; double fpartiaudit = 0; double mpartiaudit = 0;
            double perAud = 0.0;
            if (txtnoofFemaleVoteaudit1.Text != "")
            {
                fvoteaudit = Convert.ToDouble(txtnoofFemaleVoteaudit1.Text);
            }
            else
            {
                fvoteaudit = 0;
            }
            if (txtnoofmaleVoteaudit1.Text != "")
            {
                mvoteaudit = Convert.ToDouble(txtnoofmaleVoteaudit1.Text);
            }
            else
            {
                mvoteaudit = 0;
            }
            if (txtnoofFemaleParicipateaudit1.Text != "")
            {
                fpartiaudit = Convert.ToDouble(txtnoofFemaleParicipateaudit1.Text);
            }
            else
            {
                fpartiaudit = 0;
            }
            if (txtnoofmaleParicipateaudit1.Text != "")
            {
                mpartiaudit = Convert.ToDouble(txtnoofmaleParicipateaudit1.Text);
            }
            else
            {
                mpartiaudit = 0;
            }
            perAud = Math.Round((((fpartiaudit + mpartiaudit) / (fvoteaudit + mvoteaudit)) * 100), 2);
            if ((fvote + mvote) == 0)
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(perAud));
            }
            ////////////////////audit
            /////////9
            TextBox lblData91 = grvMergeHeader.Items[i].FindControl("chvremarks") as TextBox; //item.FindControl("chvremarks") as Label;
            if (lblData91.Text != "")
            {
                arrIn.Add(lblData91.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData9 = grvMergeHeader.Items[i].FindControl("chvauditedremarks") as TextBox; // item.FindControl("chvauditedremarks") as TextBox;
            if (txtData9.Text == "")
            {
                arrIn.Add(DBNull.Value);
               // arrIn.Add(lblData9.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData9.Text.ToString());
            }
         
          arrIn.Add(Convert.ToInt64(Session["UserID"]));
          arrIn.Add(Convert.ToInt64(Session["SeatID"]));
          arrIn.Add(Convert.ToInt32(Session["LBID"]));
          arrIn.Add(Convert.ToInt32(Session["Year"]));
          arrIn.Add(1);
          int row = objcomm.update("SP_tb_gramasabhaUrban_U", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        fillGrid();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvMergeHeader.Items)
        {
            TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
            Label lblData = item. FindControl("intparticipantfemale") as Label;
            TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
        }
    }
    protected void grvMergeHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (grvMergeHeader.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_Data();
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("Meeting_Urban.aspx");
    }

    protected void ddlWardNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWardNo.SelectedIndex > 0)
        {
            ddlWardName.SelectedValue = ddlWardNo.SelectedValue;
            setID();
        }
        else
        {
            ddlWardName.SelectedIndex = 0;
            lblGSNo.Text = "";
        }
    }
    protected void ddlWardName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWardName.SelectedIndex > 0)
        {
            ddlWardNo.SelectedValue = ddlWardName.SelectedValue;
            setID();
        }
        else
        {
            ddlWardNo.SelectedIndex = 0;
            lblGSNo.Text = "";
        }
    }
    public void savenew()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        
        arrIn.Add(Convert.ToInt32( lblGSNo.Text));

        arrIn.Add(ddlWardNo.SelectedValue);
        arrIn.Add(ddlWardNo.SelectedValue);

        if (txtnoofMaleVote.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofMaleVote.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofMaleVote.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        if (txtnoofFemaleVote.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofFemaleVote.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofFemaleVote.Text.ToString()));

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);

        ////////////4
        if (txtnoofMaleParicipate.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofMaleParicipate.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofMaleParicipate.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        ///////////////5
        if (txtnoofFemaleParicipate.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofFemaleParicipate.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofFemaleParicipate.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
       // arrIn.Add(DBNull.Value);
        //////////////6
        if (ttxGSPlace.Text != "")
        {
            arrIn.Add(ttxGSPlace.Text.ToString());
            arrIn.Add(ttxGSPlace.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        /////////7
        if (txtGSDate.Text != "")
        {
            arrIn.Add(txtGSDate.Text.ToString());
            arrIn.Add(txtGSDate.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
       

        double fvote = 0; double mvote = 0; double fparti = 0; double mparti = 0;
        double perAud = 0.0;
        if (txtnoofFemaleVote.Text != "")
        {
            fvote = Convert.ToDouble(txtnoofFemaleVote.Text);
        }
        else
        {
            fvote = 0;
        }
        if (txtnoofMaleVote.Text != "")
        {
            mvote = Convert.ToDouble(txtnoofMaleVote.Text);
        }
        else
        {
            mvote = 0;
        }
        if (txtnoofFemaleParicipate.Text != "")
        {
            fparti = Convert.ToDouble(txtnoofFemaleParicipate.Text);
        }
        else
        {
            fparti = 0;
        }
        if (txtnoofMaleParicipate.Text != "")
        {
            mparti = Convert.ToDouble(txtnoofMaleParicipate.Text);
        }
        else
        {
            mparti = 0;
        }
        if (fvote != 0 || mvote != 0)
        {
            perAud = Math.Round((((fparti + mparti) / (fvote + mvote)) * 100), 2);
        }
        else
        {
            perAud = 0;
        }
       
        arrIn.Add(perAud);
        arrIn.Add(perAud);

        if (txtRemarks.Text != "")
        {
            arrIn.Add(txtRemarks.Text.ToString());
            arrIn.Add(txtRemarks.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        arrIn.Add(1);
        int row = objcomm.update("SP_tb_gramasabhaUrban_U", arrIn);
        GlobalClass gblObj = new GlobalClass();
        arrIn.Clear();
        if (row > 0)
        {
            //gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
      
        Response.Redirect(Request.Url.ToString());
    }
    //public void fillper()
    //{
    //    double perAud = 0.0, allAud = 0.0, expAud = 0.0;
    //    allAud = Convert.ToDouble(dsAmt.Tables[0].Rows[0].ItemArray[0].ToString());
    //    expAud = Convert.ToDouble(dsAmt.Tables[0].Rows[0].ItemArray[1].ToString());
    //    if (allAud != 0)
    //    {
    //        perAud = Math.Round(((expAud / allAud) * 100), 2);
    //    }
    //}
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (lblGSNo.Text == "")
        {
            ddlWardName.SelectedIndex = 0;
            ddlWardNo.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Ward') ;", true);
            ddlWardNo.Focus();
            gblObj.setFocus(ddlWardNo, this);
            return false;

        }
        else if (ddlWardNo.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Ward') ;", true);
            ddlWardNo.Focus();
            gblObj.setFocus(ddlWardNo, this);
            return false;
        }
        else  if (ttxGSPlace.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Place') ;", true);
            ttxGSPlace.Focus();
            gblObj.setFocus(ttxGSPlace, this);
            return false;
        }
        else if (txtGSDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter date') ;", true);
            txtGSDate.Focus();
            gblObj.setFocus(txtGSDate, this);
            return false;
        }
        else if (txtRemarks.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Remarks') ;", true);
            txtRemarks.Focus();
            gblObj.setFocus(txtRemarks, this);
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
        }
    }
    public void setID()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        arr.Add(ddlWardNo.SelectedValue);
        ds = objcomm.FillData("SP_tb_gramasabha_setID", arr, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGSNo.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton button = (sender as ImageButton);
        //Get the command argument
        string commandArgument = button.CommandArgument;
        RepeaterItem item = button.NamingContainer as RepeaterItem;
        int rowIndex = item.ItemIndex;
        Label intgramasabhano = grvMergeHeader.Items[rowIndex].FindControl("intgramasabhano") as Label;
      
        TextBox wardno = grvMergeHeader.Items[rowIndex].FindControl("intWardNo") as TextBox;

        if (intgramasabhano.Text != "")
        {
            CommonClass objCom = new CommonClass();
            DataSet dsGrid = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(intgramasabhano.Text.ToString()));
            arrIn.Add(Convert.ToInt32(wardno.Text.ToString()));
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            arrIn.Add(Convert.ToInt32(Session["Year"]));

            int row = objCom.update("[SP_tb_gramasabhaUrban_D]", arrIn);
            if (row > 0)
            {
                Session["Flag"] = 2;
            }
            Response.Redirect(Request.Url.ToString());
        }       
        fillGrid();       
    }
}

