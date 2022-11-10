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
public partial class Pages_Townplaningprojdet_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
             //add on 13-06-2019   add condition
            if(Convert.ToInt32(Session["Year"])==22)
            {
                rptHealth.Visible = false;
                ////rptHealth.DataSource = null;
                ////rptHealth.DataBind();
            }
            else
            {
                rptHealth.Visible=true;
            Filldata();
            }
            
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
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
                
            }
            else
            {

                Button1.Enabled = true;
                
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button1.Enabled = true;
                
            }
            else
            {
                Button1.Enabled = false;
               
            }
        }


    }
    //public void ValueAssign()
    //{
    //    for (int i = 0; i < rptHospDet.Items.Count; i++)
    //    {
    //        TextBox intcount = rptHospDet.Items[i].FindControl("intcount") as TextBox;
    //        TextBox numipcount = rptHospDet.Items[i].FindControl("numipcount") as TextBox;

    //        TextBox numopcount = rptHospDet.Items[i].FindControl("numopcount") as TextBox;
    //        RadioButtonList sbmtSc = rptHospDet.Items[i].FindControl("sbmtSc") as RadioButtonList;

    //        TextBox dtafslastsubmitted = rptHospDet.Items[i].FindControl("dtafslastsubmitted") as TextBox;
    //        TextBox dtauditedlast = rptHospDet.Items[i].FindControl("dtauditedlast") as TextBox;

    //        TextBox intcountaud = rptHospDet.Items[i].FindControl("intcountaud") as TextBox;
    //        TextBox numipcountaud = rptHospDet.Items[i].FindControl("numipcountaud") as TextBox;

    //        TextBox numopcountaud = rptHospDet.Items[i].FindControl("numopcountaud") as TextBox;
    //        RadioButtonList sbmt = rptHospDet.Items[i].FindControl("sbmt") as RadioButtonList;

    //        TextBox dtafslastsubmittedaud = rptHospDet.Items[i].FindControl("dtafslastsubmittedaud") as TextBox;
    //        TextBox dtauditedlastaud = rptHospDet.Items[i].FindControl("dtauditedlastaud") as TextBox;

    //        intcountaud.Text =intcount.Text;
    //        numipcountaud.Text =numipcount.Text;

    //        numopcountaud.Text =numopcount.Text;
    //        sbmt.SelectedValue =sbmtSc.Text;

    //        dtafslastsubmittedaud.Text =dtafslastsubmitted.Text;
    //        dtauditedlastaud.Text = dtauditedlast.Text;
    //    }
      
    //}
    //public void valueAssignHospMeeting()
    //{
    //    for (int i = 0; i < rptHospMeeting.Items.Count; i++)
    //    {
    //        TextBox intMeetingNo = rptHospMeeting.Items[i].FindControl("intMeetingNo") as TextBox;
    //        TextBox dtdate = rptHospMeeting.Items[i].FindControl("dtdate") as TextBox;

    //        TextBox chvRemarks = rptHospMeeting.Items[i].FindControl("chvRemarks") as TextBox;


    //        TextBox intMeetingNoaudited = rptHospMeeting.Items[i].FindControl("intMeetingNoaudited") as TextBox;
    //        TextBox dtdateaudited = rptHospMeeting.Items[i].FindControl("dtdateaudited") as TextBox;

    //        TextBox chvRemarksAudted = rptHospMeeting.Items[i].FindControl("chvRemarksAudted") as TextBox;


    //        intMeetingNoaudited.Text = intMeetingNo.Text;
    //        dtdateaudited.Text = dtdate.Text;

    //        chvRemarksAudted.Text = chvRemarks.Text;
    //    }
    //}
    //public void SetGridDefaultHospMeeting()
    //{
    //    ArrayList arr = new ArrayList();

    //    arr.Add("numid");
    //    arr.Add("SLNO");
    //    arr.Add("chvhospitaltypemal");
    //    arr.Add("inthospitaltypeid");
    //    arr.Add("intMeetingNo");
    //    arr.Add("dtdate");
    //    arr.Add("chvRemarks");
    //    arr.Add("intMeetingNoaudited");
    //    arr.Add("dtdateaudited");
    //    arr.Add("chvRemarksAudted");


    //    //gblObj.SetRepeaterDefault(rptHospMeeting, arr);
    //}
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < rptHealth.Items.Count; i++)
            //{
            //    TextBox fltDevFund = rptHealth.Items[i].FindControl("fltDevFund") as TextBox;
            //    TextBox fltMG = rptHealth.Items[i].FindControl("fltMG") as TextBox;

            //    TextBox fltOwnFund = rptHealth.Items[i].FindControl("fltOwnFund") as TextBox;
            //    TextBox fltOtherFund = rptHealth.Items[i].FindControl("fltOtherFund") as TextBox;

            //    TextBox fltDevFundExp = rptHealth.Items[i].FindControl("fltDevFundExp") as TextBox;
            //    TextBox fltMGExp = rptHealth.Items[i].FindControl("fltMGExp") as TextBox;

            //    TextBox fltOwnFundExp = rptHealth.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //    TextBox fltOtherFundExp = rptHealth.Items[i].FindControl("fltOtherFundExp") as TextBox;

            //    fltDevFund.ReadOnly = false;
            //    fltMG.ReadOnly = false;

            //    fltOwnFund.ReadOnly = false;
            //    fltOtherFund.ReadOnly = false;

            //    fltDevFundExp.ReadOnly = false;
            //    fltMGExp.ReadOnly = false;

            //    fltOwnFundExp.ReadOnly = false;
            //    fltOtherFundExp.ReadOnly = false;

            //}
        }
        else
        {
            for (int i = 0; i < rptHealth.Items.Count; i++)
            {
                TextBox fltaudDevFund = rptHealth.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = rptHealth.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = rptHealth.Items[i].FindControl("fltaudOwnFund") as TextBox;
                //TextBox fltaudOtherFund = rptHealth.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = rptHealth.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = rptHealth.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = rptHealth.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
               // TextBox fltaudOtherFundExp = rptHealth.Items[i].FindControl("fltaudOtherFundExp") as TextBox;

                //TextBox fltaudTotalExp = rptHealth.Items[i].FindControl("fltaudTotalExp") as TextBox;
                //TextBox fltaudTotal = rptHealth.Items[i].FindControl("fltaudTotal") as TextBox;

               // fltaudTotalExp.ReadOnly = false;
                //fltaudTotal.ReadOnly = false;



                fltaudDevFund.ReadOnly = false;
                fltaudMG.ReadOnly = false;

                fltaudOwnFund.ReadOnly = false;
               // fltaudOtherFund.ReadOnly = false;

                fltaudDevFundExp.ReadOnly = false;
                fltaudMGExp.ReadOnly = false;

                fltaudOwnFundExp.ReadOnly = false;
                //f\ltaudOtherFundExp.ReadOnly = false;
            }
        }

    }
    //public void SetEditableHospDet()
    //{
    //    if (Session["RoleID"].ToString() == "2")
    //    {
    //        for (int i = 0; i < rptHospDet.Items.Count; i++)
    //        {
    //            TextBox intcount = rptHospDet.Items[i].FindControl("intcount") as TextBox;
    //            TextBox numipcount = rptHospDet.Items[i].FindControl("numipcount") as TextBox;

    //            TextBox numopcount = rptHospDet.Items[i].FindControl("numopcount") as TextBox;
    //            RadioButtonList sbmtSc = rptHospDet.Items[i].FindControl("sbmtSc") as RadioButtonList;

    //            TextBox dtafslastsubmitted = rptHospDet.Items[i].FindControl("dtafslastsubmitted") as TextBox;
    //            TextBox dtauditedlast = rptHospDet.Items[i].FindControl("dtauditedlast") as TextBox;

            

    //            intcount.ReadOnly = false;
    //            numipcount.ReadOnly = false;

    //            numopcount.ReadOnly = false;
    //            sbmtSc.Enabled = true;

    //            dtafslastsubmitted.ReadOnly = false;
    //            dtauditedlast.ReadOnly = false;

               

    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < rptHospDet.Items.Count; i++)
    //        {
    //            TextBox intcountaud = rptHospDet.Items[i].FindControl("intcountaud") as TextBox;
    //            TextBox numipcountaud = rptHospDet.Items[i].FindControl("numipcountaud") as TextBox;

    //            TextBox numopcountaud = rptHospDet.Items[i].FindControl("numopcountaud") as TextBox;
    //            RadioButtonList sbmt = rptHospDet.Items[i].FindControl("sbmt") as RadioButtonList;

    //            TextBox dtafslastsubmittedaud = rptHospDet.Items[i].FindControl("dtafslastsubmittedaud") as TextBox;
    //            TextBox dtauditedlastaud = rptHospDet.Items[i].FindControl("dtauditedlastaud") as TextBox;

    //            intcountaud.ReadOnly = false;
    //            numipcountaud.ReadOnly = false;

    //            numopcountaud.ReadOnly = false;
    //            sbmt.Enabled = true;

    //            dtafslastsubmittedaud.ReadOnly = false;
    //            dtauditedlastaud.ReadOnly = false;
    //        }
    //    }

    //}
    //public void fillHospDet()
    //{
    //    ArrayList arrFill = new ArrayList();

    //    arrFill.Clear();
    //    arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
    //    arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

    //    DataSet dsFill = objcom.FillData("SP_tb_hospitaldetails_Sel", arrFill, CommandType.StoredProcedure);
    //    if (dsFill.Tables[0].Rows.Count > 0)
    //    {
    //        rptHospDet.DataSource = dsFill;
    //        rptHospDet.DataBind();
    //        for (int i = 0; i < rptHospDet.Items.Count; i++)
    //        {
    //            RadioButtonList sbmtSc = rptHospDet.Items[i].FindControl("sbmtSc") as RadioButtonList;
    //            sbmtSc.SelectedValue = dsFill.Tables[0].Rows[i].ItemArray[9].ToString();

    //            if (dsFill.Tables[0].Rows[i].ItemArray[9].ToString() == "1")
    //            {
    //                sbmtSc.Items[0].Selected = true;
    //            }
    //            else
    //            {
    //                sbmtSc.Items[1].Selected = true;
    //            }

    //            RadioButtonList rd = rptHospDet.Items[i].FindControl("sbmt") as RadioButtonList;
    //            if (dsFill.Tables[0].Rows[i].ItemArray[15].ToString() == "1")
    //            {
    //                rd.Items[0].Selected = true;
    //            }
    //            else
    //            {
    //                rd.Items[1].Selected = true;
    //            }
    //        }

    //    }
    //    SetEditableHospDet();
    //}
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

        DataSet dsFill = objcom.FillData("SP_tb_projectdetailstownplngUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                rptHealth.Visible = true;
                rptHealth.DataSource = dsFill;
                rptHealth.DataBind();

            }
            else
            {
                rptHealth.Visible = false;

            }
        }
        else
        {
            rptHealth.Visible = false;
           
        }
        SetEditable();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssignPrj();
        }
        SaveData();
        Filldata();
        SetEditable();
    }

    public void ValueAssignPrj()
    {
        for (int i = 0; i < rptHealth.Items.Count; i++)
        {
            TextBox fltDevFund = rptHealth.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = rptHealth.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = rptHealth.Items[i].FindControl("fltOwnFund") as TextBox;
            //TextBox fltOtherFund = rptHealth.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = rptHealth.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = rptHealth.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = rptHealth.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //TextBox fltOtherFundExp = rptHealth.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = rptHealth.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = rptHealth.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = rptHealth.Items[i].FindControl("fltaudOwnFund") as TextBox;
            //TextBox fltaudOtherFund = rptHealth.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = rptHealth.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = rptHealth.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = rptHealth.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            //TextBox fltaudOtherFundExp = rptHealth.Items[i].FindControl("fltaudOtherFundExp") as TextBox;






            fltaudDevFund.Text = fltDevFund.Text;
            fltaudMG.Text = fltMG.Text;

            fltaudOwnFund.Text = fltOwnFund.Text;
           // fltaudOtherFund.Text = fltOtherFund.Text;

            fltaudDevFundExp.Text = fltDevFundExp.Text;
            fltaudMGExp.Text = fltMGExp.Text;

            fltaudOwnFundExp.Text = fltOwnFundExp.Text;
            //fltaudOtherFundExp.Text = fltOtherFundExp.Text;
        }
    }



    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < rptHealth.Items.Count; i++)
        {
            Label intWorkingGroupID = rptHealth.Items[i].FindControl("intWorkingGroupID") as Label;
            if (intWorkingGroupID.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intWorkingGroupID.Text));
            }
            Label lbldecProjectID = rptHealth.Items[i].FindControl("lbldecProjectID") as Label;
            if (lbldecProjectID.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(lbldecProjectID.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

            TextBox fltDevFund = rptHealth.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = rptHealth.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = rptHealth.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            //TextBox fltOtherFund = rptHealth.Items[i].FindControl("fltOtherFund") as TextBox;
            //if (fltOtherFund.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            //}

            //TextBox fltTotal = rptHealth.Items[i].FindControl("fltTotal") as TextBox;
            //if (fltTotal.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotal.Text));

            //}



            TextBox fltDevFundExp = rptHealth.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = rptHealth.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = rptHealth.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            //TextBox fltOtherFundExp = rptHealth.Items[i].FindControl("fltOtherFundExp") as TextBox;
            //if (fltOtherFundExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            //}


            //TextBox fltTotalExp = rptHealth.Items[i].FindControl("fltTotalExp") as TextBox;
            //if (fltTotalExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            //}


            TextBox fltaudDevFund = rptHealth.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = rptHealth.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = rptHealth.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            //TextBox fltaudOtherFund = rptHealth.Items[i].FindControl("fltaudOtherFund") as TextBox;
            //if (fltaudOtherFund.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            //}


            //TextBox fltaudTotal = rptHealth.Items[i].FindControl("fltaudTotal") as TextBox;
            //if (fltaudTotal.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            //}



            TextBox fltaudDevFundExp = rptHealth.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = rptHealth.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = rptHealth.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            //TextBox fltaudOtherFundExp = rptHealth.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            //if (fltaudOtherFundExp.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            //}


            //TextBox fltaudTotalExp = rptHealth.Items[i].FindControl("fltaudTotalExp") as TextBox;
            //if (fltaudTotalExp.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudTotalExp.Text));
            //}
            int row = objcomm.update("SP_tb_projectdetailsUrban_U", arrIn);
            arrIn.Clear();
            Session["Flag"] = 1;
            gblObj.MsgBoxOk("Saved Successfully ", this);



        }
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("Townplngartscltureprojdet_Urban.aspx");
    }
  
//    public void SaveHospDet()
//{

//    DataSet ds = new DataSet();
//    CommonClass objcomm = new CommonClass();
//    ArrayList arrIn = new ArrayList();
//    for (int i = 0; i < rptHospDet.Items.Count; i++)
//    {

//        Label numhospitalid = rptHospDet.Items[i].FindControl("numhospitalid") as Label;
//        if (numhospitalid.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt64(numhospitalid.Text));
//        }
//        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
//        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

//        Label inthospitaltypeid = rptHospDet.Items[i].FindControl("inthospitaltypeid") as Label;
//        if (inthospitaltypeid.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt32(inthospitaltypeid.Text));
//        }

//        TextBox intcount = rptHospDet.Items[i].FindControl("intcount") as TextBox;
//        if (intcount.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt32(intcount.Text));
//        }
//        TextBox numipcount = rptHospDet.Items[i].FindControl("numipcount") as TextBox;
//        if (numipcount.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt64(numipcount.Text));
//        }
//        TextBox numopcount = rptHospDet.Items[i].FindControl("numopcount") as TextBox;
//        if (numopcount.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt64(numopcount.Text));

//        }

//        //Label tnyhmcexisting = rptHospDet.Items[i].FindControl("tnyhmcexisting") as Label;
//        //if (tnyhmcexisting.Text == "")
//        //{

//        //    arrIn.Add(DBNull.Value);
//        //}
//        //else
//        //{
//        //    arrIn.Add(Convert.ToInt32(tnyhmcexisting.Text));
//        //}
//        RadioButtonList sbmtSc = rptHospDet.Items[i].FindControl("sbmtSc") as RadioButtonList;
//        if (sbmtSc.SelectedValue == "1")
//        {
//            arrIn.Add(1);
//        }
//        else
//        {
//            arrIn.Add(2);
//        }


//        TextBox dtafslastsubmitted = rptHospDet.Items[i].FindControl("dtafslastsubmitted") as TextBox;
//        if (dtafslastsubmitted.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToDateTime(dtafslastsubmitted.Text));
//        }


//        TextBox dtauditedlast = rptHospDet.Items[i].FindControl("dtauditedlast") as TextBox;
//        if (dtauditedlast.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToDateTime(dtauditedlast.Text));
//        }
//        TextBox intcountaud = rptHospDet.Items[i].FindControl("intcountaud") as TextBox;
//        if (intcountaud.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt32(intcountaud.Text));
//        }


//        TextBox numipcountaud = rptHospDet.Items[i].FindControl("numipcountaud") as TextBox;
//        if (numipcountaud.Text == "")
//        {

//            arrIn.Add(Convert.ToInt32(numipcount.Text));
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt32(numipcountaud.Text));
//        }

//        TextBox numopcountaud = rptHospDet.Items[i].FindControl("numopcountaud") as TextBox;
//        if (numopcountaud.Text == "")
//        {

//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToInt32(numopcountaud.Text));
//        }

//        RadioButtonList rd = rptHospDet.Items[i].FindControl("sbmt") as RadioButtonList;
//        if (rd.SelectedValue == "1")
//        {
//            arrIn.Add(1);
//        }
//        else
//        {
//            arrIn.Add(2);
//        }


//        TextBox dtafslastsubmittedaud = rptHospDet.Items[i].FindControl("dtafslastsubmittedaud") as TextBox;
//        if (dtafslastsubmittedaud.Text == "")
//        {
//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToDateTime(dtafslastsubmittedaud.Text));
//        }

//        TextBox dtauditedlastaud = rptHospDet.Items[i].FindControl("dtauditedlastaud") as TextBox;
//        if (dtauditedlastaud.Text == "")
//        {
//            arrIn.Add(DBNull.Value);
//        }
//        else
//        {
//            arrIn.Add(Convert.ToDateTime(dtauditedlastaud.Text));
//        }
//        arrIn.Add(Convert.ToInt64(Session["UserID"]));
//        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
       
//        arrIn.Add(1);
//        int row = objcomm.update("SP_tb_hospitaldetails_IU", arrIn);
//        arrIn.Clear();

//        if (row > 0)
//        {
//            //lblMessage.Visible = true;
//            //lblMessage.Text = "Submitted Successfully!!";
//            gblObj.MsgBoxOk("Submitted Successfully ", this);

//            Session["Flag"] = 1;
//        }



//    }
//    Response.Redirect(Request.Url.ToString());
//}
   
    protected void ddlWardNo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //private bool Validation()
    //{
    //    GlobalClass gblObj = new GlobalClass();
    //    if (  ddlHosp.SelectedIndex  == 0)
    //    {
    //        ddlHosp.SelectedIndex = 0;
    //        ddlHosp.SelectedIndex = 0;
    //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please select Hospital') ;", true);
    //        ddlHosp.Focus();
    //        gblObj.setFocus(ddlHosp, this);
    //        return false;

    //    }
    
    //    return true;
    //}
    //protected void btnNewSave_Click(object sender, EventArgs e)
    //{
    //    if (Validation() == true)
    //    {
    //        SaveHospMeetngDet();
    //        clearTexts();
    //        FillHospMeetingDet();
    //        SetEditableHospMeeting();
    //    }
    //    //pnlNewEntry.Visible = false;
    //}
    //public void clearTexts()
    //{
    //    ddlHosp.SelectedIndex = 0;
    //    txtMtngDate.Text = "";
    //    txtNo11.Text = "";
    //    txtRemarks.Text = "";
    //}
    //public void SaveHospMeetngDet()
    //{
    //    DataSet ds = new DataSet();
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(0);

    //    if (ddlHosp.SelectedIndex > 0)
    //    {
    //        arrIn.Add(Convert.ToInt32(ddlHosp.SelectedItem.Value));
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }
      
    //    arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
    //    arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

    //   if(txtMtngDate.Text !="")
    //   {
    //    arrIn.Add(txtMtngDate.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }
    //    if (txtNo11.Text != "")
    //    {
    //        arrIn.Add(txtNo11.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }

    //    if (txtMtngDate.Text != "")
    //    {
    //    arrIn.Add(txtMtngDate.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }
    //    if (txtNo11.Text != "")
    //    {
    //        arrIn.Add(txtNo11.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }

    //    if (txtRemarks.Text != "")
    //    {
    //        arrIn.Add(txtRemarks.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }


    //    if (txtRemarks.Text != "")
    //    {
    //        arrIn.Add(txtRemarks.Text);
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //    }
    //    arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
    //    arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
    //    arrIn.Add(1);
    //    int row = objcom.update("SP_tb_hospitalmeeting_IU", arrIn);
    //    if (row > 0)
    //    {
    //        //lblMessage.Visible = true;
    //        //lblMessage.Text = "Submitted Successfully!!";
    //        gblObj.MsgBoxOk("Submitted Successfully ", this);

    //        Session["Flag"] = 1;
    //    }
    //    Response.Redirect(Request.Url.ToString());
        
    //}
    //public void FillHospMeetingDet()
    //{
    //    ArrayList arrFill = new ArrayList();

    //    arrFill.Clear();
    //    arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
    //    arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
    //    DataSet dsFill = objcom.FillData("SP_tb_hospitalmeeting_Sel", arrFill, CommandType.StoredProcedure);
    //    if (dsFill.Tables[0].Rows.Count > 0)
    //    {
    //        rptHospMeeting.DataSource = dsFill;
    //        rptHospMeeting.DataBind();
    //    }
    //    else
    //    {
    //        //SetGridDefaultHospMeeting();
    //    }
    //    SetEditableHospMeeting();
    //}
    //public void SetEditableHospMeeting()
    //{
    //    if (Session["RoleID"].ToString() == "2")
    //    {
    //        for (int i = 0; i < rptHospMeeting.Items.Count; i++)
    //        {
    //            TextBox intMeetingNo = rptHospMeeting.Items[i].FindControl("intMeetingNo") as TextBox;
    //            TextBox dtdate = rptHospMeeting.Items[i].FindControl("dtdate") as TextBox;

    //            TextBox chvRemarks = rptHospMeeting.Items[i].FindControl("chvRemarks") as TextBox;


    //            intMeetingNo.ReadOnly = false;
    //            dtdate.ReadOnly = false;

    //            chvRemarks.ReadOnly = false;


    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < rptHospMeeting.Items.Count; i++)
    //        {
    //            TextBox intMeetingNoaudited = rptHospMeeting.Items[i].FindControl("intMeetingNoaudited") as TextBox;
    //            TextBox dtdateaudited = rptHospMeeting.Items[i].FindControl("dtdateaudited") as TextBox;

    //            TextBox chvRemarksAudted = rptHospMeeting.Items[i].FindControl("chvRemarksAudted") as TextBox;


    //            intMeetingNoaudited.ReadOnly = false;
    //            dtdateaudited.ReadOnly = false;

    //            chvRemarksAudted.ReadOnly = false;
               
    //        }
    //    }

    //}

    //public void UpdHospMeeting()
    //{
    //    DataSet ds = new DataSet();
    //    CommonClass objcomm = new CommonClass();
    //    ArrayList arrIn = new ArrayList();
    //    for (int i = 0; i < rptHospMeeting.Items.Count; i++)
    //    {
    //        Label lblNumId = rptHospMeeting.Items[i].FindControl("lblNumId") as Label;
    //        if (lblNumId.Text == "")
    //        {

    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToInt32(lblNumId.Text));
    //        }

    //        Label Label3 = rptHospMeeting.Items[i].FindControl("Label3") as Label;
    //        if (Label3.Text == "")
    //        {

    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToInt32(Label3.Text));
    //        }


    //        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
    //        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]




    //        TextBox dtdate = rptHospMeeting.Items[i].FindControl("dtdate") as TextBox;
    //        if (dtdate.Text == "")
    //        {

    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToDateTime(dtdate.Text));
    //        }

    //        TextBox intMeetingNo = rptHospMeeting.Items[i].FindControl("intMeetingNo") as TextBox;
    //        if (intMeetingNo.Text == "")
    //        {

    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToInt32(intMeetingNo.Text));
    //        }

    //        TextBox dtdateaudited = rptHospMeeting.Items[i].FindControl("dtdateaudited") as TextBox;
    //        if (dtdateaudited.Text == "")
    //        {
    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToDateTime(dtdateaudited.Text));
    //        }
    //        TextBox intMeetingNoaudited = rptHospMeeting.Items[i].FindControl("intMeetingNoaudited") as TextBox;
    //        if (intMeetingNoaudited.Text == "")
    //        {
    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(Convert.ToInt32(intMeetingNoaudited.Text));
    //        }

    //        TextBox chvRemarks = rptHospMeeting.Items[i].FindControl("chvRemarks") as TextBox;

    //        if (chvRemarks.Text == "")
    //        {

    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(chvRemarks.Text);
    //        }



    //        TextBox chvRemarksAudted = rptHospMeeting.Items[i].FindControl("chvRemarksAudted") as TextBox;
    //        if (chvRemarksAudted.Text == "")
    //        {
    //            arrIn.Add(DBNull.Value);
    //        }
    //        else
    //        {
    //            arrIn.Add(chvRemarksAudted.Text);
    //        }
          
    //        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
    //        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
    //        arrIn.Add(1);
    //        int row = objcomm.update("SP_tb_hospitalmeeting_IU", arrIn);
    //        arrIn.Clear();
    //        if (row > 0)
    //        {
    //            //lblMessage.Visible = true;
    //            //lblMessage.Text = "Submitted Successfully!!";
    //            gblObj.MsgBoxOk("Submitted Successfully ", this);

    //            Session["Flag"] = 1;
    //        }
    //    }

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssignPrj();
        }
        SaveData();
        Filldata();
        SetEditable();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("TownplanningWorkingGroup_Urban.aspx");
    }
}
