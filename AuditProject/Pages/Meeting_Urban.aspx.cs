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
public partial class Pages_Meeting_Urban : System.Web.UI.Page
{
   

       CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            Filldata();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Submitted Successfully ", this);
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
                Button1.Enabled = false;
                btnNew.Enabled = false;
            }
            else
            {

                Button1.Enabled = true;
                btnNew.Enabled = true; ;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button1.Enabled = true;
                btnNew.Enabled = false;
            }
            else
            {
                Button1.Enabled = false;
                btnNew.Enabled = false;
            }
        }


    }
    public void SetInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intcommitteeno");
        arr.Add("dtcommittee");
        arr.Add("inttotalmembers");
        arr.Add("intattendancettot");
        arr.Add("intmotiontot");
        arr.Add("dtauditedcommittee");
        arr.Add("intAudtotalmembers");
        arr.Add("intauditedattendancettot");
        arr.Add("intauditedmotiontot");
     

        gblObj.SetRepeaterDefault(rptMeeting, arr);
    }

    public void ValueAssign()
    {
        for (int i = 0; i < rptMeeting.Items.Count; i++)
        {
            TextBox dtcommittee = rptMeeting.Items[i].FindControl("dtcommittee") as TextBox;
            TextBox intattendancettot = rptMeeting.Items[i].FindControl("intattendancettot") as TextBox;

            TextBox intmotiontot = rptMeeting.Items[i].FindControl("intmotiontot") as TextBox;

            TextBox dtauditedcommittee = rptMeeting.Items[i].FindControl("dtauditedcommittee") as TextBox;
            TextBox intauditedattendancettot = rptMeeting.Items[i].FindControl("intauditedattendancettot") as TextBox;

            TextBox intauditedmotiontot = rptMeeting.Items[i].FindControl("intauditedmotiontot") as TextBox;

            dtauditedcommittee.Text =dtcommittee.Text;
            intauditedattendancettot.Text = intattendancettot.Text;

            intauditedmotiontot.Text = intmotiontot.Text;


            //new

            TextBox inttotalmembrs = rptMeeting.Items[i].FindControl("inttotalmembrs") as TextBox;
            TextBox intAudtotalmembers = rptMeeting.Items[i].FindControl("intAudtotalmembers") as TextBox;

            intAudtotalmembers = inttotalmembrs;



        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptMeeting.Items.Count; i++)
            {
                TextBox dtcommittee = rptMeeting.Items[i].FindControl("dtcommittee") as TextBox;

                TextBox inttotalmembers = rptMeeting.Items[i].FindControl("inttotalmembrs") as TextBox;


                TextBox intattendancettot = rptMeeting.Items[i].FindControl("intattendancettot") as TextBox;

                TextBox intmotiontot = rptMeeting.Items[i].FindControl("intmotiontot") as TextBox;

                TextBox dtauditedcommittee = rptMeeting.Items[i].FindControl("dtauditedcommittee") as TextBox;
                dtauditedcommittee.Enabled = false;
                dtcommittee.ReadOnly = false;
                dtcommittee.Enabled = true;
                inttotalmembers.ReadOnly = false;
                intattendancettot.ReadOnly = false;

                intmotiontot.ReadOnly = false;
             

            }
        }
        else
        {
            for (int i = 0; i < rptMeeting.Items.Count; i++)
            {
                TextBox dtcommittee = rptMeeting.Items[i].FindControl("dtcommittee") as TextBox;
                TextBox dtauditedcommittee = rptMeeting.Items[i].FindControl("dtauditedcommittee") as TextBox;

                TextBox intAudtotalmembers = rptMeeting.Items[i].FindControl("intAudtotalmembers") as TextBox;

                TextBox intauditedattendancettot = rptMeeting.Items[i].FindControl("intauditedattendancettot") as TextBox;

                TextBox intauditedmotiontot = rptMeeting.Items[i].FindControl("intauditedmotiontot") as TextBox;

                dtcommittee.Enabled = false;


                dtauditedcommittee.Enabled = true;
                dtauditedcommittee.ReadOnly = false;
                intAudtotalmembers.ReadOnly = false;
                intauditedattendancettot.ReadOnly = false;

                intauditedmotiontot.ReadOnly = false;
             

            }
        }

    }


    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_committeeUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptMeeting.DataSource = dsFill;
            rptMeeting.DataBind();
        }
        else
        {
            SetInitialRow();
        }
        SetEditable();
    }
    private void SetGridDefaultCmnt()
    {
        GlobalClass gblObj = new GlobalClass();
        ArrayList ar = new ArrayList();
        ar.Add("intID");
        ar.Add("intID1");
        ar.Add("intID2");
        ar.Add("intID3");
        ar.Add("intID4");
        ar.Add("intID5");
        ar.Add("intID6");
      
       // gblObj.SetGridDefault(gvMeeting, ar);
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveData();
        Filldata();
    }
     public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < rptMeeting.Items.Count; i++)
        {
            Label lblNumId = rptMeeting.Items[i].FindControl("lblNumId") as Label;
            if (lblNumId.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblNumId.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

            Label intcommitteeno = rptMeeting.Items[i].FindControl("intcommitteeno") as Label;
            arrIn.Add(Convert.ToInt32(intcommitteeno.Text));

            TextBox dtcommittee = rptMeeting.Items[i].FindControl("dtcommittee") as TextBox;
            if (dtcommittee.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDateTime(dtcommittee.Text));
            }


            //new

            TextBox inttotalmembrs = rptMeeting.Items[i].FindControl("inttotalmembrs") as TextBox;
            if (inttotalmembrs.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(inttotalmembrs.Text));
            }

            //new end


            TextBox intattendancettot = rptMeeting.Items[i].FindControl("intattendancettot") as TextBox;
            if (intattendancettot.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intattendancettot.Text));
            }

            TextBox intmotiontot = rptMeeting.Items[i].FindControl("intmotiontot") as TextBox;
            if (intmotiontot.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intmotiontot.Text));
            }

            TextBox dtauditedcommittee = rptMeeting.Items[i].FindControl("dtauditedcommittee") as TextBox;
            if (dtauditedcommittee.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDateTime(dtauditedcommittee.Text));
            }



            //new 

            TextBox intAudtotalmembers = rptMeeting.Items[i].FindControl("intAudtotalmembers") as TextBox;
            if (intAudtotalmembers.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToInt32(intAudtotalmembers.Text));
            }

            //new end


            TextBox intauditedattendancettot = rptMeeting.Items[i].FindControl("intauditedattendancettot") as TextBox;
            if (intauditedattendancettot.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedattendancettot.Text));
            }

            TextBox intauditedmotiontot = rptMeeting.Items[i].FindControl("intauditedmotiontot") as TextBox;
            if (intauditedmotiontot.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedmotiontot.Text));
            }
            arrIn.Add(1);

            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int row = objcomm.update("SP_tb_committeeUrban_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }

        }
     }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberWardDetails_Urban.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("GramasabhaDetails_Urban.aspx");
    }
    private bool Validation()
    {
        GlobalClass gblObj = new GlobalClass();
        if (dtMeetingDate.Text == "")
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Meeting Date') ;", true);

            gblObj.setFocus(dtMeetingDate, this);
            return false;

        }

        return true;
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton button = (sender as ImageButton);
        //Get the command argument
        string commandArgument = button.CommandArgument;
        RepeaterItem item = button.NamingContainer as RepeaterItem;
        int rowIndex = item.ItemIndex;

        Label numid = rptMeeting.Items[rowIndex].FindControl("lblNumId") as Label;

       // TextBox wardno = grvMergeHeader.Items[rowIndex].FindControl("intWardNo") as TextBox;

        if (numid.Text != "")
        {
            CommonClass objCom = new CommonClass();
            DataSet dsGrid = new DataSet();
            ArrayList arrIn = new ArrayList();
            arrIn.Add(Convert.ToInt32(numid.Text.ToString()));
           // arrIn.Add(Convert.ToInt32(wardno.Text.ToString()));
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            arrIn.Add(Convert.ToInt32(Session["Year"]));

            int row = objCom.update("[SP_tb_meeting_Urban_D]", arrIn);
            if (row > 0)
            {
                Session["Flag"] = 2;
            }
            Response.Redirect(Request.Url.ToString());
        }
        Filldata();

    }


    public void SaveNew()
    {

        DataSet ds = new DataSet();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(0);
               
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

        arrIn.Add(0);

        if (dtMeetingDate.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(dtMeetingDate.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        //new 

        if (txttotalmembr.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txttotalmembr.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
      

        if (txtAttndnceCnt.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAttndnceCnt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtMtnCnt.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtMtnCnt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        if (dtMeetingDate.Text != "")
        {
            arrIn.Add(Convert.ToDateTime(dtMeetingDate.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        //new 

        if (txttotalmembr.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txttotalmembr.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtAttndnceCnt.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtAttndnceCnt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (txtMtnCnt.Text != "")
        {
            arrIn.Add(Convert.ToInt32(txtMtnCnt.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }


        
        arrIn.Add(1);
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

       


       



        int row = objcom.update("SP_tb_committeeUrban_IU", arrIn);
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
    public void clearTexts()
    {
        dtMeetingDate.Text = "";
        txttotalmembr.Text = "";
        txtAttndnceCnt.Text = "";
        txtMtnCnt.Text = "";
       
    }
    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        if (Validation() == true)
        {
            SaveNew();
            clearTexts();
            Filldata();
            SetEditable();
        }
        pnlNewEntry.Visible = false;

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        pnlNewEntry.Visible = true;
    }
}
