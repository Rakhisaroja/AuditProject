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
public partial class Pages_SchoolList : System.Web.UI.Page
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
        ds = objCom.FillData("[SP_tb_school_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvMergeHeader.DataSource = ds;
            grvMergeHeader.DataBind();
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                DropDownList text14 = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList;
                text14.SelectedValue = ds.Tables[0].Rows[i][10].ToString();
                DropDownList text24 = grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList;
                text24.SelectedValue = ds.Tables[0].Rows[i][20].ToString();
            }
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
                TextBox text0 = grvMergeHeader.Items[i].FindControl("nchvSchoolName") as TextBox;                
                TextBox text1 = grvMergeHeader.Items[i].FindControl("intstudentcount") as TextBox;                
                TextBox text2 = grvMergeHeader.Items[i].FindControl("intteacherscount") as TextBox;              
                TextBox text3 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywater") as TextBox;              
                TextBox text4 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricity") as TextBox;                
                TextBox text5 = grvMergeHeader.Items[i].FindControl("intfurniture") as TextBox;               
                TextBox text6 = grvMergeHeader.Items[i].FindControl("inttoilet") as TextBox;               
                TextBox text7 = grvMergeHeader.Items[i].FindControl("intwashbasin") as TextBox;               
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvkitchen") as TextBox;               
                DropDownList text9 = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList;               

                TextBox text81 = grvMergeHeader.Items[i].FindControl("nchvSchoolNameaudit") as TextBox;              
                TextBox text91 = grvMergeHeader.Items[i].FindControl("intstudentcountaudit") as TextBox;               
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intteacherscountaudit") as TextBox;               
                TextBox text11 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywateraudit") as TextBox;                
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricityaudit") as TextBox;                
                TextBox text13 = grvMergeHeader.Items[i].FindControl("intfurnitureaudit") as TextBox;                
                TextBox text14 = grvMergeHeader.Items[i].FindControl("inttoiletaudit") as TextBox;                
                TextBox text15 = grvMergeHeader.Items[i].FindControl("intwashbasinaudit") as TextBox;                
                TextBox text16 = grvMergeHeader.Items[i].FindControl("chvkitchenaudit") as TextBox;                
                DropDownList text17 = grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList;

                text81.Text = text0.Text;
                text91.Text = text1.Text;
                text10.Text = text2.Text;
                text11.Text = text3.Text;
                text12.Text = text4.Text;
                text13.Text = text5.Text;
                text14.Text = text6.Text;
                text15.Text = text7.Text;
                text16.Text = text8.Text;
                text17.SelectedValue = text9.SelectedValue;

            }
        }
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                TextBox text0 = grvMergeHeader.Items[i].FindControl("nchvSchoolName") as TextBox;
                text0.ReadOnly = false;
                TextBox text1 = grvMergeHeader.Items[i].FindControl("intstudentcount") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvMergeHeader.Items[i].FindControl("intteacherscount") as TextBox;
                text2.ReadOnly = false;
                TextBox text3 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywater") as TextBox;
                text3.ReadOnly = false;
                TextBox text4 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricity") as TextBox;
                text4.ReadOnly = false;
                TextBox text5 = grvMergeHeader.Items[i].FindControl("intfurniture") as TextBox;
                text5.ReadOnly = false;
                TextBox text6 = grvMergeHeader.Items[i].FindControl("inttoilet") as TextBox;
                text6.ReadOnly = false;
                TextBox text7 = grvMergeHeader.Items[i].FindControl("intwashbasin") as TextBox;
                text7.ReadOnly = false;
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvkitchen") as TextBox;
                text8.ReadOnly = false;
                  DropDownList text9 = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList;
                text9.Enabled = true;



                TextBox text81 = grvMergeHeader.Items[i].FindControl("nchvSchoolNameaudit") as TextBox;
                text81.ReadOnly = true;
                TextBox text91 = grvMergeHeader.Items[i].FindControl("intstudentcountaudit") as TextBox;
                text91.ReadOnly = true;
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intteacherscountaudit") as TextBox;
                text10.ReadOnly = true;
                TextBox text11 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywateraudit") as TextBox;
                text11.ReadOnly = true;
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricityaudit") as TextBox;
                text12.ReadOnly = true;
                TextBox text13 = grvMergeHeader.Items[i].FindControl("intfurnitureaudit") as TextBox;
                text13.ReadOnly = true;
                TextBox text14 = grvMergeHeader.Items[i].FindControl("inttoiletaudit") as TextBox;
                text14.ReadOnly = true;
                TextBox text15 = grvMergeHeader.Items[i].FindControl("intwashbasinaudit") as TextBox;
                text15.ReadOnly = true;
                TextBox text16 = grvMergeHeader.Items[i].FindControl("chvkitchenaudit") as TextBox;
                text16.ReadOnly = true;
                DropDownList text17= grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList;
                text17.Enabled = false;

            }

        }
        else
        {
            for (int i = 0; i < grvMergeHeader.Items.Count; i++)
            {
                TextBox text0 = grvMergeHeader.Items[i].FindControl("nchvSchoolName") as TextBox;
                text0.ReadOnly = true;
                TextBox text1 = grvMergeHeader.Items[i].FindControl("intstudentcount") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvMergeHeader.Items[i].FindControl("intteacherscount") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywater") as TextBox;
                text3.ReadOnly = true;
                TextBox text4 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricity") as TextBox;
                text4.ReadOnly = true;
                TextBox text5 = grvMergeHeader.Items[i].FindControl("intfurniture") as TextBox;
                text5.ReadOnly = true;
                TextBox text6 = grvMergeHeader.Items[i].FindControl("inttoilet") as TextBox;
                text6.ReadOnly = true;
                TextBox text7 = grvMergeHeader.Items[i].FindControl("intwashbasin") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvMergeHeader.Items[i].FindControl("chvkitchen") as TextBox;
                text8.ReadOnly = true;
                DropDownList text9 = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList;
                text9.Enabled = false;



                TextBox text81 = grvMergeHeader.Items[i].FindControl("nchvSchoolNameaudit") as TextBox;
                text81.ReadOnly = false;
                TextBox text91 = grvMergeHeader.Items[i].FindControl("intstudentcountaudit") as TextBox;
                text91.ReadOnly = false;
                TextBox text10 = grvMergeHeader.Items[i].FindControl("intteacherscountaudit") as TextBox;
                text10.ReadOnly = false;
                TextBox text11 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywateraudit") as TextBox;
                text11.ReadOnly = false;
                TextBox text12 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricityaudit") as TextBox;
                text12.ReadOnly = false;
                TextBox text13 = grvMergeHeader.Items[i].FindControl("intfurnitureaudit") as TextBox;
                text13.ReadOnly = false;
                TextBox text14 = grvMergeHeader.Items[i].FindControl("inttoiletaudit") as TextBox;
                text14.ReadOnly = false;
                TextBox text15 = grvMergeHeader.Items[i].FindControl("intwashbasinaudit") as TextBox;
                text15.ReadOnly = false;
                TextBox text16 = grvMergeHeader.Items[i].FindControl("chvkitchenaudit") as TextBox;
                text16.ReadOnly = false;
                DropDownList text17 = grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList;
                text17.Enabled = false;
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
        //numid, intlbid, , intfinancialyearid, nchvSchoolName, , , , , , , , , , , , , 
       // , , , , , , , numUserEntry, numSeatEntry, dtEntryDate, intStatus

        for (int i = 0; i < grvMergeHeader.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));

            Label intSchoolID1 = grvMergeHeader.Items[i].FindControl("intSchoolID") as Label;
            arrIn.Add(Convert.ToInt32(intSchoolID1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"]));
            TextBox lblData22 = grvMergeHeader.Items[i].FindControl("nchvSchoolName") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData22.Text != "")
            {
                arrIn.Add(lblData22.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvMergeHeader.Items[i].FindControl("nchvSchoolNameaudit") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData2.Text != "")
            {
                arrIn.Add(txtData2.Text.ToString());

            }
            else
            {
                arrIn.Add(DBNull.Value);
                
            }
            TextBox lblData122 = grvMergeHeader.Items[i].FindControl("intstudentcount") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData122.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData122.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData42 = grvMergeHeader.Items[i].FindControl("intstudentcountaudit") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData42.Text != "")
            {
                arrIn.Add(Convert.ToInt32(txtData42.Text.ToString()));

            }
            else
            {
                arrIn.Add(DBNull.Value);
                
            }
            TextBox lblData33 = grvMergeHeader.Items[i].FindControl("intteacherscount") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData33.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData33.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            ///////////3
            TextBox txtData3 = grvMergeHeader.Items[i].FindControl("intteacherscountaudit") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
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
            TextBox lblData44 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywater") as TextBox; //item.FindControl("intparticipantMale") as Label;
            if (lblData44.Text != "")
            {
                arrIn.Add(lblData44.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvMergeHeader.Items[i].FindControl("chvbasicfacilitywateraudit") as TextBox;//item.FindControl("intAuditedtotVotersMale") as TextBox;
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
            TextBox lblData55 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricity") as TextBox; //item.FindControl("intparticipantfemale") as Label;
            if (lblData55.Text != "")
            {
                arrIn.Add(lblData55.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData5 = grvMergeHeader.Items[i].FindControl("chvbasicfacilityelectricityaudit") as TextBox; //item.FindControl("intAuditedtotVotersFemale") as TextBox;
            if (txtData5.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
                //arrIn.Add(lblData5.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData5.Text.ToString());
            }

            //////////////6
            TextBox lblData66 = grvMergeHeader.Items[i].FindControl("intfurniture") as TextBox; //item.FindControl("chvplacemal") as Label;
            if (lblData66.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData66.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData6 = grvMergeHeader.Items[i].FindControl("intfurnitureaudit") as TextBox; //item.FindControl("chvauditedplacemal") as TextBox;
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
            TextBox lblData77 = grvMergeHeader.Items[i].FindControl("inttoilet") as TextBox; //item.FindControl("dtgramasabha") as Label;
            if (lblData77.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData77.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData7 = grvMergeHeader.Items[i].FindControl("inttoiletaudit") as TextBox; //item.FindControl("dtauditedgramasabha") as TextBox;
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
            TextBox lblData88 = grvMergeHeader.Items[i].FindControl("intwashbasin") as TextBox; //item.FindControl("fltAttenPrece") as Label;
            if (lblData88.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData88.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData8 = grvMergeHeader.Items[i].FindControl("intwashbasinaudit") as TextBox; //item.FindControl("fltAuditAttenPrece") as TextBox;
            if (txtData8.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
                // arrIn.Add(lblData8.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData8.Text.ToString());
            }
            /////////9
            TextBox lblData91 = grvMergeHeader.Items[i].FindControl("chvkitchen") as TextBox; //item.FindControl("chvremarks") as Label;
            if (lblData91.Text != "")
            {
                arrIn.Add(lblData91.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData9 = grvMergeHeader.Items[i].FindControl("chvkitchenaudit") as TextBox; // item.FindControl("chvauditedremarks") as TextBox;
            if (txtData9.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
                // arrIn.Add(lblData9.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData9.Text.ToString());
            }
            DropDownList ddlNew = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList;
            if (ddlNew.SelectedIndex > 0)
            {
                arrIn.Add(ddlNew.SelectedValue);
            }
         
            else
            {
                arrIn.Add(DBNull.Value);
            }
            //DropDownList txtData9 = grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList; // item.FindControl("chvauditedremarks") as TextBox;

            DropDownList ddlNew1 = grvMergeHeader.Items[i].FindControl("tnyptaaudit") as DropDownList;
            if (ddlNew1.SelectedIndex == 0)
            {
                //DropDownList lblData9 = grvMergeHeader.Items[i].FindControl("tnypta") as DropDownList; //item.FindControl("chvremarks") as Label;
                arrIn.Add(DBNull.Value);
               
                // arrIn.Add(lblData9.Text.ToString());
            }
            else
            {
                arrIn.Add(ddlNew1.SelectedValue.ToString());
            }

            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);
            int ep = objcomm.update("SP_tb_school_IU", arrIn);
            GlobalClass gblObj = new GlobalClass();
            if (ep > 0)
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
        pnlNewEntry.Visible = false;
        fillGrid();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvMergeHeader.Items)
        {
            TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
            Label lblData = item.FindControl("intparticipantfemale") as Label;
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
        Response.Redirect("EduProjDet.aspx");
    }

    protected void ddlWardNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlWardNo.SelectedIndex > 0)
        //{
        //    ddlWardName.SelectedValue = ddlWardNo.SelectedValue;
        //}
        //else
        //{
        //    ddlWardName.SelectedIndex = 0;
        //}
    }
    protected void ddlWardName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlWardName.SelectedIndex > 0)
        //{
        //    ddlWardNo.SelectedValue = ddlWardName.SelectedValue;
        //}
        //else
        //{
        //    ddlWardNo.SelectedIndex = 0;
        //}
    }
    public void setID()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
       // arr.Add(ddlWardNo.SelectedValue);
        ds = objcomm.FillData("SP_tb_school_setID", arr, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGSNo.Text = ds.Tables[0].Rows[0][0].ToString();
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
        //arrIn.Add(ddlWardNo.SelectedValue);
        //arrIn.Add(ddlWardNo.SelectedValue);

        if (txtSchoolName.Text != "")
        {
            arrIn.Add( txtSchoolName.Text.ToString());
            arrIn.Add( txtSchoolName.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        if (txtnoofStudent.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofStudent.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofStudent.Text.ToString()));

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);

        ////////////4
        if (txtnoofTeacher.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofTeacher.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofTeacher.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        ///////////////5
        if (txtWater.Text != "")
        {
            arrIn.Add( txtWater.Text.ToString());
            arrIn.Add( txtWater.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtElecricity.Text != "")
        {
            arrIn.Add(txtElecricity.Text.ToString());
            arrIn.Add(txtElecricity.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        // arrIn.Add(DBNull.Value);
        //////////////6
        if (txtnoofFurniture.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofFurniture.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofFurniture.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtnoofToilet.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofToilet.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofToilet.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtnoofWashbase.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtnoofWashbase.Text.ToString()));
            arrIn.Add(Convert.ToInt32(txtnoofWashbase.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        /////////7
        if (txtKitchen.Text != "")
        {
            arrIn.Add(txtKitchen.Text.ToString());
            arrIn.Add(txtKitchen.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        ///////////////8
        if (ddlpta.SelectedIndex>0)
        {
            arrIn.Add(Convert.ToInt32(ddlpta.SelectedValue));
            arrIn.Add(Convert.ToInt32(ddlpta.SelectedValue));
            
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        /////////9
      
        //arrIn.Add(DBNull.Value);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
      
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_school_IU", arrIn);
        GlobalClass gblObj = new GlobalClass();
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
        arrIn.Clear();
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        //if (ddlWardNo.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Ward') ;", true);
        //    ddlWardNo.Focus();
        //    gblObj.setFocus(ddlWardNo, this);
        //    return false;
        //}
        //else if (ttxGSPlace.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Place') ;", true);
        //    ttxGSPlace.Focus();
        //    gblObj.setFocus(ttxGSPlace, this);
        //    return false;
        //}
       if (txtSchoolName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter School') ;", true);
            txtSchoolName.Focus();
            gblObj.setFocus(txtSchoolName, this);
            return false;
        }
        else if (txtnoofStudent.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter no of Student') ;", true);
            txtnoofStudent.Focus();
            gblObj.setFocus(txtnoofStudent, this);
            return false;
        }
        else if (txtnoofTeacher.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter no of Teacher') ;", true);
            txtnoofTeacher.Focus();
            gblObj.setFocus(txtnoofTeacher, this);
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
            //pnlNewEntry.Visible = true;

        }
    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("ArtProjDet.aspx");
    }
}

