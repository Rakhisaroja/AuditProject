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
public partial class Pages_OtherCommittees_Urban : System.Web.UI.Page
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
        arrIn.Add(5);
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ds = objCom.FillData("[SP_tb_othercommitteeUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvOther.Visible = true;
            grvOther.DataSource = ds;
            grvOther.DataBind();
            disabletextbox();
            // disabletextbox();
        }

        // SetGridDefaultCmnt();
    }
 
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinanceWorkingGroup_Urban.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        pnlNewEntry.Visible = false;
        Save_Data();
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
            arrIn.Add(5);
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
          
            //TextBox lblData44 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox; //item.FindControl("intparticipantMale") as Label;
            //if (lblData44.Text != "")
            //{
            //    arrIn.Add(lblData44.Text.ToString());
            //}
            //else
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            //TextBox txtData4 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;//item.FindControl("intAuditedtotVotersMale") as TextBox;
            //if (txtData4.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);
            //    // arrIn.Add(lblData4.Text.ToString());
            //}
            //else
            //{
            //    arrIn.Add(txtData4.Text.ToString());
            //}
            ///////////////5
          
            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);



            //NEW

            ///////////3
            TextBox txtDatadte= grvOther.Items[i].FindControl("dtmeetingdte") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDatadte.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(Convert.ToDateTime(txtDatadte.Text));
            }


            ///////////3
            TextBox txtDataAudidte = grvOther.Items[i].FindControl("dtAudmeetingdte") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDataAudidte.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(Convert.ToDateTime(txtDataAudidte.Text));
            }


            TextBox txtDatametplace = grvOther.Items[i].FindControl("chvmeetingplace") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDatametplace.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDatametplace.Text);
            }




            TextBox txtDataAudmetplace = grvOther.Items[i].FindControl("chvAudmeetingplace") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDataAudmetplace.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDataAudmetplace.Text);
            }


            TextBox txtDatambrno = grvOther.Items[i].FindControl("intmembernos") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDatambrno.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDatambrno.Text);
            }



            TextBox txtDataAudmbrno = grvOther.Items[i].FindControl("intAudmembernos") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDataAudmbrno.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDataAudmbrno.Text);
            }


            TextBox txtDatametdcnno = grvOther.Items[i].FindControl("intmeetingdecnnos") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDatametdcnno.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDatametdcnno.Text);
            }




            TextBox txtDataAudmetdcnno = grvOther.Items[i].FindControl("intAudmeetingdecnnos") as TextBox;  //item.FindControl("intAuditedtotVotersfemale") as TextBox;
            if (txtDataAudmetdcnno.Text == "")
            {

                arrIn.Add(DBNull.Value);
                // arrIn.Add(lblData3.Text.ToString());
            }
            else
            {
                arrIn.Add(txtDataAudmetdcnno.Text);
            }






            int row = objcomm.update("SP_tb_othercommitteeUrban_IU", arrIn);

            GlobalClass gblObj = new GlobalClass();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
                Session["Flag"] = 1;

            }
            arrIn.Clear();
        }
        Response.Redirect(Request.Url.ToString());
        //}
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrontOffice_Urban.aspx");
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
        else if (txtMeetingDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Meeting Date') ;", true);
            txtMeetingDate.Focus();
            gblObj.setFocus(txtMeetingDate, this);
            return false;
        }

        else if (txtmeetingplace.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Meeting place') ;", true);
            txtmeetingplace.Focus();
            gblObj.setFocus(txtmeetingplace, this);
            return false;
        }
        else if (txtmembrsnos.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Number of Members') ;", true);
            txtmembrsnos.Focus();
            gblObj.setFocus(txtmembrsnos, this);
            return false;
        }
        else if (txtmeetingdecnnos.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Number of decisions on meeting') ;", true);
            txtmeetingdecnnos.Focus();
            gblObj.setFocus(txtmeetingdecnnos, this);
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
     
        arrIn.Add(Convert.ToInt32(lblCommID.Text ));
        arrIn.Add(5);


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

        //commented for urbn
        //if (txtMeetingDtails.Text != "")
        //{
        //    arrIn.Add(txtMeetingDtails.Text.ToString());
        //    arrIn.Add(txtMeetingDtails.Text.ToString());

        //}
        //else
        //{
        //    arrIn.Add(DBNull.Value);
        //    arrIn.Add(DBNull.Value);
        //}
       
        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);

        //NEW 

        if (txtMeetingDate.Text!= "")
        {
            arrIn.Add(Convert.ToDateTime(txtMeetingDate.Text));
            arrIn.Add(Convert.ToDateTime(txtMeetingDate.Text));

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
           
        }
        if (txtmeetingplace.Text!= "")
        {
            arrIn.Add(txtmeetingplace.Text);
            arrIn.Add(txtmeetingplace.Text);

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }
        if (txtmembrsnos.Text != "")
        {
            arrIn.Add(txtmembrsnos.Text);
            arrIn.Add(txtmembrsnos.Text);

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);

        }
        if (txtmeetingdecnnos.Text != "")
        {
            arrIn.Add(txtmeetingdecnnos.Text);
            arrIn.Add(txtmeetingdecnnos.Text);

        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }





        int ep = objcomm.update("SP_tb_othercommitteeUrban_IU", arrIn);
        arrIn.Clear();


        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
        Response.Redirect(Request.Url.ToString());
    }
    public void setID()
    {
        ArrayList arr=new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        arr.Add(5);
        ds = objcom.FillData("SP_tb_othercommittee_setID", arr, CommandType.StoredProcedure);
        if(ds.Tables[0].Rows.Count>0)
        {
            lblCommID.Text=ds.Tables[0].Rows[0][0].ToString();
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
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvnameofcommiteemal") as TextBox;
                TextBox text2 = grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;
                //edit
                //TextBox text3 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;
               // NEW

                TextBox text3 = grvOther.Items[i].FindControl("dtmeetingdte") as TextBox;
                TextBox text4 = grvOther.Items[i].FindControl("chvmeetingplace") as TextBox;
                TextBox text5 = grvOther.Items[i].FindControl("intmembernos") as TextBox;
                TextBox text6 = grvOther.Items[i].FindControl("intmeetingdecnnos") as TextBox;


                TextBox text11 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                TextBox text21 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                //TextBox text31 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;

                //new
                TextBox text31 = grvOther.Items[i].FindControl("dtAudmeetingdte") as TextBox;
                TextBox text41 = grvOther.Items[i].FindControl("chvAudmeetingplace") as TextBox;
                TextBox text51 = grvOther.Items[i].FindControl("intAudmembernos") as TextBox;
                TextBox text61 = grvOther.Items[i].FindControl("intAudmeetingdecnnos") as TextBox;





                text11.Text = text1.Text;
                text21.Text = text2.Text;
                text31.Text = text3.Text;

                //new

                text41.Text = text4.Text;
                text51.Text = text5.Text;
                text61.Text = text6.Text;
            






            }
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
                 TextBox text2= grvOther.Items[i].FindControl("chvoperationalareamal") as TextBox;
                text2.ReadOnly = false;
                 
                //TextBox text3 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;
                //text3.ReadOnly = false;

                //new 

                TextBox text3 = grvOther.Items[i].FindControl("dtmeetingdte") as TextBox;
                if (text3 != null)
                {
                    text3.ReadOnly = false;
                }


                TextBox text4 = grvOther.Items[i].FindControl("chvmeetingplace") as TextBox;
                if (text4 != null)
                {
                    text4.ReadOnly = false;
                }
                


                TextBox text5 = grvOther.Items[i].FindControl("intmembernos") as TextBox;

                if (text5 != null)
                {
                    text5.ReadOnly = false;
                }
                

                TextBox text6 = grvOther.Items[i].FindControl("intmeetingdecnnos") as TextBox;
                if (text6 != null)
                {
                     text6.ReadOnly = false; 
                }
               





                TextBox text7 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                text8.ReadOnly = true;
                //TextBox text9 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;
                //text6.ReadOnly = true;


                //new
                
                TextBox text11 = grvOther.Items[i].FindControl("dtAudmeetingdte") as TextBox;
                if (text11 != null)
                {
                    text11.ReadOnly = true;
                }
                
                
                TextBox text12 = grvOther.Items[i].FindControl("chvAudmeetingplace") as TextBox;
                if (text12 != null)
                {
                    text12.ReadOnly = true;
                }
                
                TextBox text13 = grvOther.Items[i].FindControl("intAudmembernos") as TextBox;
                if (text13 != null)
                {
                    text13.ReadOnly = true;
                }
                
                TextBox text14= grvOther.Items[i].FindControl("intAudmeetingdecnnos") as TextBox;
                if (text14 != null)
                {
                    text14.ReadOnly = true;
                }
                




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
                //TextBox text73 = grvOther.Items[i].FindControl("chvmeetingdetails") as TextBox;
                //text73.ReadOnly = true;
                //new 

                TextBox text73 = grvOther.Items[i].FindControl("dtmeetingdte") as TextBox;
                text73.ReadOnly = true;


                TextBox text74 = grvOther.Items[i].FindControl("chvmeetingplace") as TextBox;
                text74.ReadOnly = true;


                TextBox text75 = grvOther.Items[i].FindControl("intmembernos") as TextBox;
                text75.ReadOnly = true;

                TextBox text76 = grvOther.Items[i].FindControl("intmeetingdecnnos") as TextBox;
                text76.ReadOnly = true;








                TextBox text77 = grvOther.Items[i].FindControl("chvAuditnameofcommiteemal") as TextBox;
                text77.ReadOnly = false;
                TextBox text78 = grvOther.Items[i].FindControl("chvAuditoperationalareamal") as TextBox;
                text78.ReadOnly = false;
                //TextBox text82 = grvOther.Items[i].FindControl("chvAuditmeetingdetails") as TextBox;
                //text82.ReadOnly = false;

                //new
                TextBox text79 = grvOther.Items[i].FindControl("dtAudmeetingdte") as TextBox;
                text79.ReadOnly = false;
                TextBox text80 = grvOther.Items[i].FindControl("chvAudmeetingplace") as TextBox;
                text80.ReadOnly = false;
                TextBox text81 = grvOther.Items[i].FindControl("intAudmembernos") as TextBox;
                text81.ReadOnly = false;
                TextBox text82 = grvOther.Items[i].FindControl("intAudmeetingdecnnos") as TextBox;
                text82.ReadOnly = false;


            }
        }
    }

    protected void grvOther_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
   
}
