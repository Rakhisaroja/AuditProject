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
public partial class Pages_WelfareOtherCommittee_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();
    GlobalClass gblObj = new GlobalClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            

              
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
        arrIn.Add(7);
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ds = objCom.FillData("[SP_tb_othercommittee_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvOther.Visible = true;
            grvOther.DataSource = ds;
            grvOther.DataBind();
            disabletextbox();
            // disabletextbox();
        }
        else
        {
            grvOther.Visible = false;
           
        }

        // SetGridDefaultCmnt();
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        //Response.Redirect("AnnualPlanExpenditureFinance_Urban.aspx");
        Response.Redirect("WelfareWorkingGroup_Urban.aspx");
    }
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofcommiteemal") as TextBox;
                TextBox text2 = grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;
                TextBox text3 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;

                TextBox text11 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                TextBox text21 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                TextBox text31 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;
               
                text11.Text = text1.Text;
                text21.Text = text2.Text;
                text31.Text = text3.Text;             
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


        for (int i = 0; i < grvOther.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            arrIn.Add(Convert.ToInt32(Session["Year"]));
            Label intstandingcommit = grvOther.Items[i].FindControl("@intstandingcommitteetype") as Label;
            Label OtherCommID = grvOther.Items[i].FindControl("intOtherCommID") as Label;

            arrIn.Add(Convert.ToInt32(OtherCommID.Text.ToString()));
            arrIn.Add(7);
            TextBox lblData22 = grvOther.Items[i].FindControl("chvnameofcommiteemal") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData22.Text != "")
            {
                arrIn.Add(lblData22.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData2.Text != "")
            {
                arrIn.Add(txtData2.Text.ToString());

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }

            TextBox lblData33 = grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData33.Text != "")
            {
                arrIn.Add(lblData33.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            ///////////3
            TextBox txtData3 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtData3.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtData3.Text.ToString());
            }

            TextBox lblData44 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox; //item.FindControl("intparticipantMale") as Label;
            if (lblData44.Text != "")
            {
                arrIn.Add(lblData44.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;//item.FindControl("intAuditedtotVotersMale") as TextBox;
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

            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);
            int ep = objcomm.update("SP_tb_othercommittee_IU", arrIn);

            GlobalClass gblObj = new GlobalClass();
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
        Response.Redirect("PovertyReduction_Urban.aspx");
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (txtCommitte.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the Committee') ;", true);
            txtCommitte.Focus();
            gblObj.setFocus(txtCommitte, this);
            return false;
        }
        else if (txtoperational.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the operational sector') ;", true);
            txtoperational.Focus();
            gblObj.setFocus(txtoperational, this);
            return false;
        }
        else if (txtMeetingDtails.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Meeting Details') ;", true);
            txtMeetingDtails.Focus();
            gblObj.setFocus(txtMeetingDtails, this);
            return false;
        }


        return true;
    }
    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        if (Validation() == true)
        {
            setID();
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

        arrIn.Add(Convert.ToInt32(lblCommID.Text));
        arrIn.Add(7);


        if (txtCommitte.Text != "")
        {
            arrIn.Add(txtCommitte.Text.ToString());
            arrIn.Add(txtCommitte.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtoperational.Text != "")
        {
            arrIn.Add(txtoperational.Text.ToString());
            arrIn.Add(txtoperational.Text.ToString());

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtMeetingDtails.Text != "")
        {
            arrIn.Add(txtMeetingDtails.Text.ToString());
            arrIn.Add(txtMeetingDtails.Text.ToString());

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_othercommittee_IU", arrIn);
        arrIn.Clear();
        if (ep > 1)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
        Response.Redirect(Request.Url.ToString());
    }
    public void setID()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        arr.Add(7);
        ds = objcom.FillData("SP_tb_othercommittee_setID", arr, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCommID.Text = ds.Tables[0].Rows[0][0].ToString();
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
            lblCommID.Text = "";
            setID();
            GlobalClass gbl = new GlobalClass();
            pnlNewEntry.Visible = true;
            gbl.ResetFormControlValues(this);
            fillGrid();
            //pnlNewEntry.Visible = true;

        }
    }

    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofcommiteemal") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;
                text2.ReadOnly = false;
                TextBox text3 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;
                text3.ReadOnly = false;

                TextBox text4 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                text4.ReadOnly = true;
                TextBox text5 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                text5.ReadOnly = true;
                TextBox text6 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;
                text6.ReadOnly = true;

            }
        }
        else
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text71 = grvOther.Items[i].FindControl("chvnameofcommiteemal") as TextBox;
                text71.ReadOnly = true;
                TextBox text72 = grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;
                text72.ReadOnly = true;
                TextBox text73 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;
                text73.ReadOnly = true;

                TextBox text74 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                text74.ReadOnly = false;
                TextBox text81 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                text81.ReadOnly = false;
                TextBox text82 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;
                text82.ReadOnly = false;
            }
        }
    }

    protected void grvOther_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
