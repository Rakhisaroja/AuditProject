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
public partial class Pages_AnnualPlanExpenditureWelfare : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
            fillMember(0);
            fillMeetings(0);
            disabletextbox();
            txtnoofMeeting.ReadOnly = false;
            btnMeeting.Enabled = true;
            txtnoofMember.ReadOnly = false;
            btnMember.Enabled = true;
            chkStatus();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            if (Convert.ToInt32(Session["Flag"]) == 2)
            {
                gblObj.MsgBoxOk("Deleted Successfully ", this);
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
                btnMember.Enabled = false;
                btnMeeting.Enabled = false;
                txtnoofMeeting.Enabled = false;
                txtnoofMember.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnMember.Enabled = true;
                btnMeeting.Enabled = true;
                txtnoofMeeting.Enabled = true;
                txtnoofMember.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
                btnMember.Enabled = false;
                btnMeeting.Enabled = false;
                txtnoofMeeting.Enabled = false;
                txtnoofMember.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnMember.Enabled = false;
                btnMeeting.Enabled = false;
                txtnoofMeeting.Enabled = false;
                txtnoofMember.Enabled = false;
            }
        }


    }

    public void disabletextboxmeetings()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvMeetingDate.Items.Count; i++)
            {
                TextBox text1 = grvMeetingDate.Items[i].FindControl("dtdate") as TextBox;
                text1.Enabled = true;
                TextBox text2 = grvMeetingDate.Items[i].FindControl("dtAuditDate") as TextBox;
                text2.Enabled = false;

            }
        }
        else
        {
            for (int i = 0; i < grvMeetingDate.Items.Count; i++)
            {
                TextBox text1 = grvMeetingDate.Items[i].FindControl("dtdate") as TextBox;
                text1.Enabled = false;
                TextBox text2 = grvMeetingDate.Items[i].FindControl("dtAuditDate") as TextBox;
                text2.Enabled = true;

            }
        }
    }
    public void disabletextboxmember()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvMembers.Items.Count; i++)
            {
                TextBox text1 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox;
                text2.ReadOnly = true;

            }
        }
        else
        {
            for (int i = 0; i < grvMembers.Items.Count; i++)
            {
                TextBox text1 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox;
                text2.ReadOnly = false;

            }
        }
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtChairman.ReadOnly = false;
            txtMotiontot.ReadOnly = false;

            txtAuditMotiontot.ReadOnly = true;
            txtChairmanmalAudit.ReadOnly = true;

        }
        else
        {
            txtChairman.ReadOnly = true;
            txtMotiontot.ReadOnly = true;

            txtAuditMotiontot.ReadOnly = false;
            txtChairmanmalAudit.ReadOnly = false;

        }
    }
    protected void btnDeleteMeeting_Click(object sender, EventArgs e)
    {

        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

        Label lb1 = item.FindControl("intMeetingNo") as Label;
        Label lb2 = item.FindControl("intstandingcommitteetype") as Label;
        Label lb3 = item.FindControl("numstandingcommitteeid") as Label;

        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
        arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
        arrIn.Add(Convert.ToInt64(lb3.Text));
        arrIn.Add(Convert.ToInt32(lb2.Text));
        arrIn.Add(Convert.ToInt32(lb1.Text));
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        int ep = objcom.Delete("[SP_tb_Standingcommitteemeetings_D]", arrIn);
        fillMeetings(0);
        Save_DataMeetings();
        fillMeetings(0);
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Deleted Successfully ", this);
            Session["Flag"] = 2;

        }
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnDeleteMem_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

        Label lb1 = item.FindControl("intslno") as Label;
        Label lb2 = item.FindControl("intstandingcommitteetype") as Label;
        Label lb3 = item.FindControl("numstandingcommitteeid") as Label;
        if (lb3.Text != "")
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
            arrIn.Add(Convert.ToInt64(lb3.Text));
            arrIn.Add(Convert.ToInt32(lb2.Text));
            arrIn.Add(Convert.ToInt32(lb1.Text));
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            int ep = objcom.Delete("[SP_tb_Standingcommitteememberrs_D]", arrIn);
            txtnoofMember.Text = "";
            fillMember(0);
            //Save_DataMembers();
            fillMember(0);
            if (ep > 0)
            {
                gblObj.MsgBoxOk("Deleted Successfully ", this);
                Session["Flag"] = 2;

            }

        }
        //else
        //{
        //    int i = grvMembers.Items.Count - 1;
        //    fillMember(i);
        //}
        Response.Redirect(Request.Url.ToString());
    }

    void fillMeetings(int cut)
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(3);
        DataSet ds = new DataSet();
        grvMeetingDate.Visible = true;
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_Standingcommitteemeetings_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //        txtnoofMeeting.Text =Convert.ToString( ds.Tables[0].Rows.Count);
            //        grvMeetingDate.DataSource = ds;
            //        grvMeetingDate.DataBind();
            //        disabletextboxmeetings();
            //    }
            //    else
            //    {
            //        if (cut == 0)
            //        {
            //            grvMeetingDate.Visible = false;
            //        }
            //        else
            //        {
            //            lblnoofMeetingDate.Visible = true;
            //            SetGridDefaultCmntMeeting(cut);                
            //        }
            //    }        
            //}
            if (txtnoofMeeting.Text != "")
            {
                //txtnoofMeeting.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                int new1 = Convert.ToInt32(txtnoofMeeting.Text.ToString());
                int old1 = (ds.Tables[0].Rows.Count);
                if (new1 == old1)
                {
                    txtnoofMeeting.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                    grvMeetingDate.DataSource = ds;
                    grvMeetingDate.DataBind();
                    disabletextboxmeetings();
                }
                else if (new1 > old1)
                {
                    SetGridDefaultCmntMeeting(cut, old1);

                }
            }
            else
            {
                grvMeetingDate.DataSource = ds;
                grvMeetingDate.DataBind();
                disabletextboxmeetings();
            }

        }
        else
        {
            if (cut == 0)
            {
                grvMeetingDate.Visible = false;
                
            }
            else
            {
                lblnoofMeetingDate.Visible = true;
                SetGridDefaultCmntMeeting(cut, 0);
                //disabletextboxmember();
            }

        }


    }
    private void SetGridDefaultCmntMember(int count, int old)
    {
        //for (int i = 0; i < count; i++)
        //{
        GlobalClass gblObj = new GlobalClass();
        ArrayList ar = new ArrayList();
        ar.Add("SLNO");
        ar.Add("intslno");
        ar.Add("chvnameofmembermal");
        ar.Add("numstandingcommitteeid");
        ar.Add("intstandingcommitteetype");
        ar.Add("chvAuditnameofmembermal");

        gblObj.SetGridDefaultfill(grvMembers, ar, count);
        if (old != 0)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
            arrIn.Add(3);
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            //GlobalClass gblObj = new GlobalClass();
            ds = objcom.FillData("[SP_tb_Standingcommitteememberrs_S]", arrIn, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (grvMembers.Items.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Label text1 = grvMembers.Items[i].FindControl("SLNO") as Label;
                        text1.Text = ds.Tables[0].Rows[i][0].ToString();
                        Label text11 = grvMembers.Items[i].FindControl("intslno") as Label;
                        text11.Text = ds.Tables[0].Rows[i][6].ToString();
                        Label text12 = grvMembers.Items[i].FindControl("intstandingcommitteetype") as Label;
                        text12.Text = ds.Tables[0].Rows[i][3].ToString();
                        Label text13 = grvMembers.Items[i].FindControl("numstandingcommitteeid") as Label;
                        text13.Text = ds.Tables[0].Rows[i][2].ToString();
                        TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox;
                        text2.Text = ds.Tables[0].Rows[i][9].ToString();
                        TextBox text21 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox;
                        text21.Text = ds.Tables[0].Rows[i][8].ToString();
                    }
                }

            }
        }



        for (int i = 0; i < count; i++)
        {
            TextBox aa = (TextBox)grvMembers.Items[i].FindControl("chvAuditnameofmembermal");
            aa.ReadOnly = true;
        }
        // }
    }

    private void SetGridDefaultCmntMeeting(int count, int old)
    {
        GlobalClass gblObj = new GlobalClass();
        ArrayList ar = new ArrayList();
        ar.Add("SLNO");
        ar.Add("intMeetingNo");
        ar.Add("dtdate");
        ar.Add("dtAuditDate");
        ar.Add("intAuditMeetingNo");
        ar.Add("numstandingcommitteeid");
        ar.Add("intstandingcommitteetype");

        gblObj.SetGridDefaultfill(grvMeetingDate, ar, count);
        if (old != 0)
        {
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Session["LBID"].ToString());
            arrIn.Add(Session["Year"].ToString());
            arrIn.Add(3);
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            //GlobalClass gblObj = new GlobalClass();
            ds = objcom.FillData("[SP_tb_Standingcommitteemeetings_S]", arrIn, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (grvMeetingDate.Items.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Label text1 = grvMeetingDate.Items[i].FindControl("SLNO") as Label;
                        text1.Text = ds.Tables[0].Rows[i][0].ToString();
                        Label text11 = grvMeetingDate.Items[i].FindControl("intMeetingNo") as Label;
                        text11.Text = ds.Tables[0].Rows[i][5].ToString();
                        Label text22 = grvMeetingDate.Items[i].FindControl("intAuditMeetingNo") as Label;
                        text22.Text = ds.Tables[0].Rows[i][7].ToString();
                        Label text12 = grvMeetingDate.Items[i].FindControl("intstandingcommitteetype") as Label;
                        text12.Text = ds.Tables[0].Rows[i][2].ToString();
                        Label text13 = grvMeetingDate.Items[i].FindControl("numstandingcommitteeid") as Label;
                        text13.Text = ds.Tables[0].Rows[i][1].ToString();
                        TextBox text2 = grvMeetingDate.Items[i].FindControl("dtdate") as TextBox;
                        text2.Text = ds.Tables[0].Rows[i][6].ToString();
                        TextBox text21 = grvMeetingDate.Items[i].FindControl("dtAuditDate") as TextBox;
                        text21.Text = ds.Tables[0].Rows[i][8].ToString();
                    }
                }

            }
        }

        for (int i = 0; i < count; i++)
        {
            if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
            {
                TextBox aa = (TextBox)grvMeetingDate.Items[i].FindControl("dtAuditDate");
                aa.ReadOnly = true;
            }
            else
            {
                TextBox aa1 = (TextBox)grvMeetingDate.Items[i].FindControl("dtdate");
                aa1.ReadOnly = true;
            }

        }
    }
    void fillMember(int cut)
    {
        ArrayList arrIn = new ArrayList();
        grvMembers.Visible = true;
        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(3);
        DataSet ds = new DataSet();
        grvMembers.Visible = true;
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_Standingcommitteememberrs_S]", arrIn, CommandType.StoredProcedure);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (txtnoofMember.Text != "")
            {
                //txtnoofMeeting.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                int new1 = Convert.ToInt32(txtnoofMember.Text.ToString());
                int old1 = (ds.Tables[0].Rows.Count);
                if (new1 == old1)
                {
                    txtnoofMember.Text = Convert.ToString(ds.Tables[0].Rows.Count);
                    grvMembers.DataSource = ds;
                    grvMembers.DataBind();
                    disabletextboxmember();
                }
                else if (new1 > old1)
                {
                    SetGridDefaultCmntMember(cut, old1);

                }
            }
            else
            {
                grvMembers.DataSource = ds;
                grvMembers.DataBind();
                disabletextboxmember();
            }

        }
        else
        {
            if (cut == 0)
            {
                grvMembers.Visible = false;
                
            }
            else
            {
                lblnoofMember.Visible = true;
                SetGridDefaultCmntMember(cut, 0);
                //disabletextboxmember();
            }

        }


    }
    void fillData()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        arrIn.Add(3);//Finance
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_StandingCommittee_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtChairman.Text = ds.Tables[0].Rows[0][5].ToString();
            txtChairmanmalAudit.Text = ds.Tables[0].Rows[0][21].ToString();
            txtMotiontot.Text = ds.Tables[0].Rows[0][6].ToString();
            txtAuditMotiontot.Text = ds.Tables[0].Rows[0][22].ToString();

            disabletextbox();

        }
    }
    //private void SetGridDefaultCmnt()
    //{
    //    GlobalClass gblObj = new GlobalClass();
    //    ArrayList ar = new ArrayList();
    //    ar.Add("intWardNo");
    //    ar.Add("TotvoteFemale");
    //    ar.Add("Totvotemale");
    //    ar.Add("particvoteFemale");
    //    ar.Add("particvotemale");
    //    ar.Add("chvGSPlace");
    //    ar.Add("chvGSDate");
    //    ar.Add("AttendPrecen");
    //    ar.Add("Remarks");

    //    ar.Add("AuditintWardNo");
    //    ar.Add("AuditTotvoteFemale");
    //    ar.Add("AuditTotvotemale");
    //    ar.Add("AuditparticvoteFemale");
    //    ar.Add("Auditparticvotemale");
    //    ar.Add("AuditchvGSPlace");
    //    ar.Add("AuditchvGSDate");
    //    ar.Add("AuditAttendPrecen");
    //    ar.Add("AuditRemarks");
    //    //ar.Add("AgendaProcedure1");
    //    //ar.Add("AgendaProcedure2");
    //    //ar.Add("AgendaProcedure3");
    //    // gblObj.SetGridDefault(grvMergeHeader, ar);

    //}


    public void Save_DataMembers()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvMembers.Items.Count; i++)
        {
            TextBox txtDataq = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox; //@chvnameofmembermal 
            if (txtDataq.Text != "")
            {
                arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
                arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,

                Label lblData1 = grvMembers.Items[i].FindControl("numstandingcommitteeid") as Label;   ////@numstandingcommitteeid ,
                Label lblData2 = grvMembers.Items[i].FindControl("intstandingcommitteetype") as Label;   ////@intstandingcommitteetype ,
                Label lblData3 = grvMembers.Items[i].FindControl("intslno") as Label;   ////@intslno ,
                if (lblData1.Text != "")
                {
                    arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
                    //arrIn.Add(1);
                }
                else
                {
                    arrIn.Add(Convert.ToInt32(lblStandCommID.Text));
                }
                //if (lblData2.Text != "")
                //{
                //    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                arrIn.Add(3);

                //if (lblData3.Text != "")
                //{
                //    arrIn.Add(Convert.ToInt32(lblData3.Text.ToString()));
                //}
                //else
                //{
                arrIn.Add(i + 1);    //@intslno
                //}
                arrIn.Add(DBNull.Value);
                TextBox txtData2 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox; //@chvnameofmembermal 
                if (txtData2.Text != "")
                {
                    arrIn.Add(txtData2.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
                TextBox txtData3 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox; //@chvAuditnameofmembermal 
                if (txtData3.Text == "")
                {
                    arrIn.Add(DBNull.Value);
                }
                else
                {
                    arrIn.Add(txtData3.Text.ToString());
                }

                arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
                arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
                arrIn.Add(1);
                int ep = objcomm.update("SP_tb_Standingcommitteememberrs_IU", arrIn);
                //if (ep > 0)
                //{
                //    gblObj.MsgBoxOk("Saved Successfully ", this);
                //}
            }
            arrIn.Clear();
        }
    }

    public void Save_DataMeetings()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvMeetingDate.Items.Count; i++)
        {
            TextBox dtdate1 = (TextBox)grvMeetingDate.Items[i].FindControl("dtdate");
            if (dtdate1.Text != "")
            {
                arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
                arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
                //arrIn.Add(0);
                Label ngcommitteeid = (Label)grvMeetingDate.Items[i].FindControl("numstandingcommitteeid");//as TextBox;
                if (ngcommitteeid.Text != "")
                {
                    arrIn.Add(ngcommitteeid.Text);
                }
                else
                {
                    //arrIn.Add(DBNull.Value);
                    arrIn.Add(Convert.ToInt32(lblStandCommID.Text));
                    //arrIn.Add(1);
                }
                arrIn.Add(3);
                arrIn.Add(i + 1);
                arrIn.Add(i + 1);
                TextBox membermal = (TextBox)grvMeetingDate.Items[i].FindControl("dtdate");
                if (membermal.Text != "")
                {
                    arrIn.Add(membermal.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);

                }
                TextBox Auditnameofmembermal = (TextBox)grvMeetingDate.Items[i].FindControl("dtAuditDate");// as TextBox;
                if (Auditnameofmembermal.Text != "")
                {
                    arrIn.Add(Auditnameofmembermal.Text);
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }

                arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
                arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
                arrIn.Add(1);
                int i1 = objcomm.update("SP_tb_Standingcommitteemeetings_IU", arrIn);
            }
            arrIn.Clear();
        }
    }
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtChairmanmalAudit.Text = txtChairman.Text;
            txtAuditMotiontot.Text = txtMotiontot.Text;

            //////////////////
            for (int i = 0; i < grvMembers.Items.Count; i++)
            {
                TextBox text1 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox;
                TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox;
                text2.Text = text1.Text;

            }
            /////////////
            for (int i = 0; i < grvMeetingDate.Items.Count; i++)
            {
                Label lb1 = grvMeetingDate.Items[i].FindControl("intMeetingNo") as Label;
                Label lb2 = grvMeetingDate.Items[i].FindControl("intAuditMeetingNo") as Label;
                TextBox text1 = grvMeetingDate.Items[i].FindControl("dtdate") as TextBox;
                TextBox text2 = grvMeetingDate.Items[i].FindControl("dtAuditDate") as TextBox;
                text2.Text = text1.Text;
                lb2.Text = lb1.Text;

            }
        }
    }
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
        arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
        arrIn.Add(3);                       //, @intstandingcommitteetype  int 
        //////////////////////////
        if (txtChairman.Text != "")//, @chvnameofchairman  nvarchar(250) 
        {
            arrIn.Add(txtChairman.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtChairmanmalAudit.Text != "")//, @chvnameofchairman  nvarchar(250) 
        {
            arrIn.Add(txtChairmanmalAudit.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtMotiontot.Text != "")//, @chvnameofchairman  nvarchar(250) 
        {
            arrIn.Add(Convert.ToInt32(txtMotiontot.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (txtAuditMotiontot.Text != "")//, @chvnameofchairman  nvarchar(250) 
        {
            arrIn.Add(Convert.ToInt32(txtAuditMotiontot.Text.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        //arrIn.Add(DBNull.Value);
        //arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);


        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        arrIn.Add(DBNull.Value);
        //arrIn.Add(DBNull.Value);

        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
        arrIn.Add(1);
        DataSet ds1 = new DataSet();
        ds1 = objcomm.FillData("SP_tb_StandingCommittee_IU", arrIn, CommandType.StoredProcedure);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            lblStandCommID.Text = ds1.Tables[0].Rows[0][0].ToString();
        }
        arrIn.Clear();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // ValueAssign();
        // Save_Data();
        // //check();
        //Save_DataMeetings();
        // Save_DataMembers();
        // fillData();
        // fillMeetings(0);
        // fillMember(0);

        //     gblObj.MsgBoxOk("Saved Successfully ", this);
        ValueAssign();
        Save_Data();
        Save_DataMeetings();
        Save_DataMembers();

        fillData();
        fillMeetings(0);
        fillMember(0);
        GlobalClass gblObj = new GlobalClass();
        gblObj.MsgBoxOk("Saved Successfully ", this);
        Session["Flag"] = 1;
        Response.Redirect(Request.Url.ToString());
    }





    protected void grvMembers_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (grvMembers.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }

    }
    protected void grvMeetingDate_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (grvMeetingDate.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }
    }
    protected void txtnoofMember_TextChanged(object sender, EventArgs e)
    {
        if (txtnoofMember.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMember.Text);
            fillMember(cut);
            //txtnoofMember.ReadOnly = true;
            //btnMember.Enabled = false;
        }
    }
    protected void btnMeeting_Click(object sender, EventArgs e)
    {
        if (txtnoofMeeting.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMeeting.Text);
            fillMeetings(cut);
            //txtnoofMeeting.ReadOnly = true;
            //btnMeeting.Enabled = false;
            //disabletextboxmeetings();
        }
    }
    protected void btnMember_Click(object sender, EventArgs e)
    {
        if (txtnoofMember.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMember.Text);
            fillMember(cut);
            //txtnoofMember.ReadOnly = true;
            //btnMember.Enabled = false;
            //disabletextboxmember();
        }
    }
    protected void txtnoofMeeting_TextChanged(object sender, EventArgs e)
    {
        if (txtnoofMeeting.Text != "")
        {
            int cut = Convert.ToInt32(txtnoofMeeting.Text);
            fillMeetings(cut);
            //txtnoofMeeting.ReadOnly = true;
            //btnMeeting.Enabled = false;

            //disabletextboxmeetings();
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("WelfareWorkingGroup.aspx");
    }
}
