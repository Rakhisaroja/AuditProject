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
public partial class Pages_SocialJusticeNurserySchool_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();
    GlobalClass gblObj = new GlobalClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             //add on 13-06-2019   add condition
            if(Convert.ToInt32(Session["Year"])==22)
            {
                grvSocialJustice.Visible = false;
                 
            }
            else
            {
                grvSocialJustice.Visible = true;
            FillDataSocial();
            }
            Filldata();
            chkStatus();
            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            Session["Flag"] = 0;
            SetEditable();
        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                btnSave.Enabled = false;
                //btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                //btnNew.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
                //btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                //btnNew.Enabled = false;
            }
        }


    }

    public void Filldata()
    {
        //rakhi s 21.02.2019
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_NurseryschooldetailsUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            numNurseryCount.Text = dsFill.Tables[0].Rows[0][11].ToString();
            numAudNurseryCount.Text = dsFill.Tables[0].Rows[0][12].ToString();
            numOwnedPlace.Text = dsFill.Tables[0].Rows[0][0].ToString();
            numSuitableBuilding.Text = dsFill.Tables[0].Rows[0][1].ToString();
            numCompoundWall.Text = dsFill.Tables[0].Rows[0][2].ToString();
            numDrinkingWater.Text = dsFill.Tables[0].Rows[0][3].ToString();
            numElectricity.Text = dsFill.Tables[0].Rows[0][4].ToString();
            numAuditOwnedPlace.Text = dsFill.Tables[0].Rows[0][5].ToString();
            numAuditSuitableBuilding.Text = dsFill.Tables[0].Rows[0][6].ToString();
            numAuditCompoundWall.Text = dsFill.Tables[0].Rows[0][7].ToString();
            numAuditDrinkingWater.Text = dsFill.Tables[0].Rows[0][8].ToString();
            numAuditElectricity.Text = dsFill.Tables[0].Rows[0][9].ToString();
        }
    }
    public void FillDataSocial()
    {
        ArrayList arrFillsocial = new ArrayList();
        arrFillsocial.Clear();
        arrFillsocial.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFillsocial.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFillsocial = objcom.FillData("SP_tb_projectdetailsSocial_Sel", arrFillsocial, CommandType.StoredProcedure);
        if (dsFillsocial.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                grvSocialJustice.Visible = true;
                grvSocialJustice.DataSource = dsFillsocial;
                grvSocialJustice.DataBind();
            }
            else
            {
                grvSocialJustice.Visible = false;

            }
        }
        else
        {
            grvSocialJustice.Visible = false;
             
        }

    }
    public void Save_Datasocial()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < grvSocialJustice.Items.Count; i++)
        {
            Label intWorkingGroupID = grvSocialJustice.Items[i].FindControl("intWorkingGroupID") as Label;
            if (intWorkingGroupID.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intWorkingGroupID.Text));
            }
            Label lbldecProjectID = grvSocialJustice.Items[i].FindControl("lbldecProjectID") as Label;
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

            TextBox fltDevFund = grvSocialJustice.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = grvSocialJustice.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = grvSocialJustice.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            //TextBox fltOtherFund = grvSocialJustice.Items[i].FindControl("fltOtherFund") as TextBox;
            //if (fltOtherFund.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            //}

            //TextBox fltTotal = grvSocialJustice.Items[i].FindControl("fltTotal") as TextBox;
            //if (fltTotal.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotal.Text));

            //}



            TextBox fltDevFundExp = grvSocialJustice.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = grvSocialJustice.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = grvSocialJustice.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            //TextBox fltOtherFundExp = grvSocialJustice.Items[i].FindControl("fltOtherFundExp") as TextBox;
            //if (fltOtherFundExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            //}


            //TextBox fltTotalExp = grvSocialJustice.Items[i].FindControl("fltTotalExp") as TextBox;
            //if (fltTotalExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            //}


            TextBox fltaudDevFund = grvSocialJustice.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = grvSocialJustice.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = grvSocialJustice.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            //TextBox fltaudOtherFund = grvSocialJustice.Items[i].FindControl("fltaudOtherFund") as TextBox;
            //if (fltaudOtherFund.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            //}


            //TextBox fltaudTotal = grvSocialJustice.Items[i].FindControl("fltaudTotal") as TextBox;
            //if (fltaudTotal.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            //}



            TextBox fltaudDevFundExp = grvSocialJustice.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = grvSocialJustice.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = grvSocialJustice.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            //TextBox fltaudOtherFundExp = grvSocialJustice.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            //if (fltaudOtherFundExp.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            //}


            //TextBox fltaudTotalExp = grvSocialJustice.Items[i].FindControl("fltaudTotalExp") as TextBox;
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

            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
   
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("SocialJusticeBudsSchool_Urban.aspx");
    }
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            numAudNurseryCount.Text = numNurseryCount.Text;
            numAuditOwnedPlace.Text = numOwnedPlace.Text;
            numAuditSuitableBuilding.Text = numSuitableBuilding.Text;
            numAuditCompoundWall.Text = numCompoundWall.Text;
            numAuditDrinkingWater.Text = numDrinkingWater.Text;
            numAuditElectricity.Text = numElectricity.Text;
            
            for (int i = 0; i < grvSocialJustice.Items.Count; i++)
            {
                TextBox fltaudDevFund = grvSocialJustice.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = grvSocialJustice.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = grvSocialJustice.Items[i].FindControl("fltaudOwnFund") as TextBox;
                //TextBox fltaudOtherFund = grvSocialJustice.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = grvSocialJustice.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = grvSocialJustice.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = grvSocialJustice.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                //TextBox fltaudOtherFundExp = grvSocialJustice.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


                //TextBox fltaudTotalExp = grvSocialJustice.Items[i].FindControl("fltaudTotalExp") as TextBox;
                //TextBox fltaudTotal = grvSocialJustice.Items[i].FindControl("fltaudTotal") as TextBox;
                ///
                TextBox fltDevFund = grvSocialJustice.Items[i].FindControl("fltDevFund") as TextBox;
                TextBox fltMG = grvSocialJustice.Items[i].FindControl("fltMG") as TextBox;

                TextBox fltOwnFund = grvSocialJustice.Items[i].FindControl("fltOwnFund") as TextBox;
                //TextBox fltOtherFund = grvSocialJustice.Items[i].FindControl("fltOtherFund") as TextBox;

                TextBox fltDevFundExp = grvSocialJustice.Items[i].FindControl("fltDevFundExp") as TextBox;
                TextBox fltMGExp = grvSocialJustice.Items[i].FindControl("fltMGExp") as TextBox;

                TextBox fltOwnFundExp = grvSocialJustice.Items[i].FindControl("fltOwnFundExp") as TextBox;
               // TextBox fltOtherFundExp = grvSocialJustice.Items[i].FindControl("fltOtherFundExp") as TextBox;


                //TextBox fltTotalExp = grvSocialJustice.Items[i].FindControl("fltTotalExp") as TextBox;
                //TextBox fltTotal = grvSocialJustice.Items[i].FindControl("fltTotal") as TextBox;



                fltaudDevFund.Text = fltDevFund.Text;
                fltaudMG.Text = fltMG.Text;
                fltaudOwnFund.Text = fltOwnFund.Text;
                //fltaudOtherFund.Text = fltOtherFund.Text;
                fltaudDevFundExp.Text = fltDevFundExp.Text;
                fltaudMGExp.Text = fltMGExp.Text;
                fltaudOwnFundExp.Text = fltOwnFundExp.Text;
                //fltaudOtherFundExp.Text = fltOtherFundExp.Text;
                //fltaudTotalExp.Text = fltTotalExp.Text;
                //fltaudTotal.Text = fltTotal.Text;

            }

        }
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        SetEditable();
        Save_Data();
        Save_Datasocial();

        //pnlNewEntry.Visible = false;
        FillDataSocial();
        Filldata();

    }
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrFill = new ArrayList();
        arrFill.Add(Convert.ToInt32(Session["LBID"].ToString())); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["YearID"]

        if (numOwnedPlace.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numOwnedPlace.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (numSuitableBuilding.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numSuitableBuilding.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (numCompoundWall.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numCompoundWall.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (numDrinkingWater.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numDrinkingWater.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (numElectricity.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numElectricity.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
       
        //------------------------------------------------
        if (numAuditOwnedPlace.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAuditOwnedPlace.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (numAuditSuitableBuilding.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAuditSuitableBuilding.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }


        if (numAuditCompoundWall.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAuditCompoundWall.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (numAuditDrinkingWater.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAuditDrinkingWater.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }


        if (numAuditElectricity.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAuditElectricity.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (numNurseryCount.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numNurseryCount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (numAudNurseryCount.Text != "")
        {
            arrFill.Add(Convert.ToInt32(numAudNurseryCount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        
        
        arrFill.Add(Convert.ToInt64(Session["UserID"]));
        arrFill.Add(Convert.ToInt64(Session["SeatID"]));
        arrFill.Add(1);
        int row = objcomm.update("SP_tb_NurseryschooldetailsUrban_IU", arrFill);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("SocialJusticeChildAged_Urban.aspx");
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            numNurseryCount.ReadOnly = false;
            numOwnedPlace.ReadOnly = false;
            numSuitableBuilding.ReadOnly = false;
            numCompoundWall.ReadOnly = false;
            numDrinkingWater.ReadOnly = false;
            numElectricity.ReadOnly = false;

            numAudNurseryCount.ReadOnly = true;
            numAuditOwnedPlace.ReadOnly = true;
            numAuditSuitableBuilding.ReadOnly = true;
            numAuditCompoundWall.ReadOnly = true;
            numAuditDrinkingWater.ReadOnly = true;
            numAuditElectricity.ReadOnly = true;

        }
        else
        {
            for (int i = 0; i < grvSocialJustice.Items.Count; i++)
            {
                TextBox fltaudDevFund = grvSocialJustice.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = grvSocialJustice.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = grvSocialJustice.Items[i].FindControl("fltaudOwnFund") as TextBox;
                // TextBox fltaudOtherFund = grvSocialJustice.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = grvSocialJustice.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = grvSocialJustice.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = grvSocialJustice.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                //TextBox fltaudOtherFundExp = grvSocialJustice.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


                //TextBox fltaudTotalExp = grvSocialJustice.Items[i].FindControl("fltaudTotalExp") as TextBox;
                //TextBox fltaudTotal = grvSocialJustice.Items[i].FindControl("fltaudTotal") as TextBox;

                //fltaudTotalExp.ReadOnly = false;
                //fltaudTotal.ReadOnly = false;



                fltaudDevFund.ReadOnly = false;
                fltaudMG.ReadOnly = false;

                fltaudOwnFund.ReadOnly = false;
                //fltaudOtherFund.ReadOnly = false;

                fltaudDevFundExp.ReadOnly = false;
                fltaudMGExp.ReadOnly = false;

                fltaudOwnFundExp.ReadOnly = false;
                // fltaudOtherFundExp.ReadOnly = false;
            }
            numAuditOwnedPlace.ReadOnly = false;
            numAuditSuitableBuilding.ReadOnly = false;
            numAuditCompoundWall.ReadOnly = false;
            numAuditDrinkingWater.ReadOnly = false;
            numAuditElectricity.ReadOnly = false;

            numNurseryCount.ReadOnly = true;
            numOwnedPlace.ReadOnly = true;
            numSuitableBuilding.ReadOnly = true;
            numCompoundWall.ReadOnly = true;
            numDrinkingWater.ReadOnly = true;
            numElectricity.ReadOnly = true;
        }
    }
    //private bool Validation()
    //{
    //    GlobalClass gblObj = new GlobalClass();
    //    if (txtCommitte.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the Committee') ;", true);
    //        txtCommitte.Focus();
    //        gblObj.setFocus(txtCommitte, this);
    //        return false;
    //    }
    //    else if (txtoperational.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter Name of the operational sector') ;", true);
    //        txtoperational.Focus();
    //        gblObj.setFocus(txtoperational, this);
    //        return false;
    //    }
    //    else if (txtMeetingDtails.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Please Enter the Meeting Details') ;", true);
    //        txtMeetingDtails.Focus();
    //        gblObj.setFocus(txtMeetingDtails, this);
    //        return false;
    //    }


    //    return true;
    //}
    //protected void btnNewSave_Click(object sender, EventArgs e)
    //{
    //    if (Validation() == true)
    //    {
    //        setID();
    //        savenew();

    //        pnlNewEntry.Visible = false;
    //        fillGrid();
    //    }
    //}
    //public void savenew()
    //{
    //    DataSet ds = new DataSet();
    //    CommonClass objcomm = new CommonClass();
    //    ArrayList arrIn = new ArrayList();

    //    arrIn.Add(Convert.ToInt32(Session["LBID"]));
    //    arrIn.Add(Convert.ToInt32(Session["Year"]));

    //    arrIn.Add(Convert.ToInt32(lblCommID.Text));
    //    arrIn.Add(3);


    //    if (txtCommitte.Text != "")
    //    {
    //        arrIn.Add(txtCommitte.Text.ToString());
    //        arrIn.Add(txtCommitte.Text.ToString());
    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //        arrIn.Add(DBNull.Value);
    //    }
    //    if (txtoperational.Text != "")
    //    {
    //        arrIn.Add(txtoperational.Text.ToString());
    //        arrIn.Add(txtoperational.Text.ToString());

    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //        arrIn.Add(DBNull.Value);
    //    }
    //    if (txtMeetingDtails.Text != "")
    //    {
    //        arrIn.Add(txtMeetingDtails.Text.ToString());
    //        arrIn.Add(txtMeetingDtails.Text.ToString());

    //    }
    //    else
    //    {
    //        arrIn.Add(DBNull.Value);
    //        arrIn.Add(DBNull.Value);
    //    }

    //    arrIn.Add(Convert.ToInt64(Session["UserID"]));
    //    arrIn.Add(Convert.ToInt64(Session["SeatID"]));
    //    arrIn.Add(1);
    //    int ep = objcomm.update("SP_tb_othercommittee_IU", arrIn);
    //    arrIn.Clear();
    //    if (ep > 1)
    //    {
    //        gblObj.MsgBoxOk("Saved Successfully ", this);
    //        Session["Flag"] = 1;
    //    }
    //    Response.Redirect(Request.Url.ToString());
    //}chvnameofcommiteemal
    //public void setID()
    //{
    //    ArrayList arr = new ArrayList();
    //    DataSet ds = new DataSet();
    //    CommonClass objcomm = new CommonClass();
    //    arr.Add(Session["LBID"]);
    //    arr.Add(Session["Year"]);
    //    arr.Add(3);
    //    ds = objcom.FillData("SP_tb_othercommittee_setID", arr, CommandType.StoredProcedure);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblCommID.Text = ds.Tables[0].Rows[0][0].ToString();
    //    }

    //}
    //protected void btnNew_Click(object sender, EventArgs e)
    //{
    //    if (pnlNewEntry.Visible == true)
    //    {
    //        pnlNewEntry.Visible = false;
    //    }
    //    else
    //    {
    //        lblCommID.Text = "";
    //        setID();
    //        GlobalClass gbl = new GlobalClass();
    //        pnlNewEntry.Visible = true;
    //        gbl.ResetFormControlValues(this);
    //        fillGrid();
    //        //pnlNewEntry.Visible = true;

    //    }
    //}


    //public void disabletextbox()
    //{

    //    if (Session["RoleID"].ToString() == "2")
    //    {
    //        for (int i = 0; i < grvOther.Items.Count; i++)
    //        {
    //            TextBox text1 = grvOther.Items[i].FindControl("numOwnedPlace") as TextBox;
    //            text1.ReadOnly = false;
    //            TextBox text2 = grvOther.Items[i].FindControl("numSuitableBuilding") as TextBox;
    //            text2.ReadOnly = false;
    //            TextBox text3 = grvOther.Items[i].FindControl("numCompoundWall") as TextBox;
    //            text3.ReadOnly = false;
    //            TextBox text4 = grvOther.Items[i].FindControl("numDrinkingWater") as TextBox;
    //            text4.ReadOnly = false;
    //            TextBox text5 = grvOther.Items[i].FindControl("numElectricity") as TextBox;
    //            text5.ReadOnly = false;

    //            TextBox text6 = grvOther.Items[i].FindControl("numAuditOwnedPlace") as TextBox;
    //            text6.ReadOnly = true;
    //            TextBox text7 = grvOther.Items[i].FindControl("numAuditSuitableBuilding") as TextBox;
    //            text7.ReadOnly = true;
    //            TextBox text8 = grvOther.Items[i].FindControl("numAuditCompoundWall") as TextBox;
    //            text8.ReadOnly = true;
    //            TextBox text9 = grvOther.Items[i].FindControl("numAuditDrinkingWater") as TextBox;
    //            text9.ReadOnly = true;
    //            TextBox text10 = grvOther.Items[i].FindControl("numAuditElectricity") as TextBox;
    //            text10.ReadOnly = true;

    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < grvOther.Items.Count; i++)
    //        {
    //            TextBox text71 = grvOther.Items[i].FindControl("numOwnedPlace") as TextBox;
    //            text71.ReadOnly = true;
    //            TextBox text72 = grvOther.Items[i].FindControl("numSuitableBuilding") as TextBox;
    //            text72.ReadOnly = true;
    //            TextBox text73 = grvOther.Items[i].FindControl("numCompoundWall") as TextBox;
    //            text73.ReadOnly = true;
    //            TextBox text74 = grvOther.Items[i].FindControl("numDrinkingWater") as TextBox;
    //            text74.ReadOnly = true;
    //            TextBox text75 = grvOther.Items[i].FindControl("numElectricity") as TextBox;
    //            text75.ReadOnly = true;

    //            TextBox text76 = grvOther.Items[i].FindControl("numAuditOwnedPlace") as TextBox;
    //            text76.ReadOnly = false;
    //            TextBox text81 = grvOther.Items[i].FindControl("numAuditSuitableBuilding") as TextBox;
    //            text81.ReadOnly = false;
    //            TextBox text82 = grvOther.Items[i].FindControl("numAuditCompoundWall") as TextBox;
    //            text82.ReadOnly = false;
    //            TextBox text83 = grvOther.Items[i].FindControl("numAuditDrinkingWater") as TextBox;
    //            text83.ReadOnly = false;
    //            TextBox text84 = grvOther.Items[i].FindControl("numAuditElectricity") as TextBox;
    //            text84.ReadOnly = false;

    //        }
    //    }
    //}
    //public void SetEditable()
    //{
    //    if (Session["RoleID"].ToString() == "2")
    //    {
    //        numOwnedPlace.ReadOnly = false;
    //        numSuitableBuilding.ReadOnly = false;
    //        numCompoundWall.ReadOnly = false;
    //        numDrinkingWater.ReadOnly = false;
    //        numElectricity.ReadOnly = false;

    //    }
    //    else
    //    {
    //        for (int i = 0; i < grvSocialJustice.Items.Count; i++)
    //        {
    //            TextBox fltaudDevFund = grvSocialJustice.Items[i].FindControl("fltaudDevFund") as TextBox;
    //            TextBox fltaudMG = grvSocialJustice.Items[i].FindControl("fltaudMG") as TextBox;

    //            TextBox fltaudOwnFund = grvSocialJustice.Items[i].FindControl("fltaudOwnFund") as TextBox;
    //            // TextBox fltaudOtherFund = grvSocialJustice.Items[i].FindControl("fltaudOtherFund") as TextBox;

    //            TextBox fltaudDevFundExp = grvSocialJustice.Items[i].FindControl("fltaudDevFundExp") as TextBox;
    //            TextBox fltaudMGExp = grvSocialJustice.Items[i].FindControl("fltaudMGExp") as TextBox;

    //            TextBox fltaudOwnFundExp = grvSocialJustice.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
    //            //TextBox fltaudOtherFundExp = grvSocialJustice.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


    //            //TextBox fltaudTotalExp = grvSocialJustice.Items[i].FindControl("fltaudTotalExp") as TextBox;
    //            //TextBox fltaudTotal = grvSocialJustice.Items[i].FindControl("fltaudTotal") as TextBox;

    //            //fltaudTotalExp.ReadOnly = false;
    //            //fltaudTotal.ReadOnly = false;



    //            fltaudDevFund.ReadOnly = false;
    //            fltaudMG.ReadOnly = false;

    //            fltaudOwnFund.ReadOnly = false;
    //            //fltaudOtherFund.ReadOnly = false;

    //            fltaudDevFundExp.ReadOnly = false;
    //            fltaudMGExp.ReadOnly = false;

    //            fltaudOwnFundExp.ReadOnly = false;
    //            // fltaudOtherFundExp.ReadOnly = false;
    //        }
    //        numAuditOwnedPlace.ReadOnly = false;
    //        numAuditSuitableBuilding.ReadOnly = false;
    //        numAuditCompoundWall.ReadOnly = false;
    //        numAuditDrinkingWater.ReadOnly = false;
    //        numAuditElectricity.ReadOnly = false;

    //    }
    //}
  
}
