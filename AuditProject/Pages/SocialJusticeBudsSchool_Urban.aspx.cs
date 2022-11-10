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


public partial class Pages_SocialJusticeBudsSchool_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Filldata();
             //add on 13-06-2019   add condition
            if(Convert.ToInt32(Session["Year"])==22)
            {
                grvSocialJustice.Visible = false;
                
            }
            else
            {
                grvSocialJustice.Visible=true;
                FillDataSocial();

            }

            chkStatus();
        }
        //SetEditable();
       
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

    }
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtbudsscoolbencountaudit.Text = txtbudsscoolbencount.Text;
            txtbudsscoolexpenditureaudit.Text = txtbudsscoolexpenditure.Text;
            txtscholarshipbencountaudit.Text = txtscholarshipbencount.Text;
            txtscholarshipamountaudit.Text = txtscholarshipamount.Text;
            txtequipmentsnoaudit.Text = txtequipmentscount.Text;
            txtequipmentamtaudit.Text = txtequipmentsamt.Text;
            txtbudsschoolexistingaudit.Text = txtbudsschoolexisting.Text;
            txtbudsscoolcurrentyearaudit.Text = txtbudsscoolcurrentyear.Text;
            txtbudsschoolnotexistingaudit.Text = txtbudsschoolnotexisting.Text;
            txtbasicfacilityaudit.Text = txtbasicfacility.Text;
            txtvehiclerentaudit.Text = txtvehiclerent.Text;
            txthonarariumaudit.Text = txthonararium.Text;
            txtotherexpaudit.Text = txtotherexp.Text;
      
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
                ///
                TextBox fltDevFund = grvSocialJustice.Items[i].FindControl("fltDevFund") as TextBox;
                TextBox fltMG = grvSocialJustice.Items[i].FindControl("fltMG") as TextBox;

                TextBox fltOwnFund = grvSocialJustice.Items[i].FindControl("fltOwnFund") as TextBox;
                //TextBox fltOtherFund = grvSocialJustice.Items[i].FindControl("fltOtherFund") as TextBox;

                TextBox fltDevFundExp = grvSocialJustice.Items[i].FindControl("fltDevFundExp") as TextBox;
                TextBox fltMGExp = grvSocialJustice.Items[i].FindControl("fltMGExp") as TextBox;

                TextBox fltOwnFundExp = grvSocialJustice.Items[i].FindControl("fltOwnFundExp") as TextBox;
                //TextBox fltOtherFundExp = grvSocialJustice.Items[i].FindControl("fltOtherFundExp") as TextBox;


                //TextBox fltTotalExp = grvSocialJustice.Items[i].FindControl("fltTotalExp") as TextBox;
                //TextBox fltTotal = grvSocialJustice.Items[i].FindControl("fltTotal") as TextBox;

                         

                fltaudDevFund.Text=fltDevFund.Text;
                fltaudMG.Text=fltMG.Text;
                fltaudOwnFund.Text=fltOwnFund.Text; 
               // fltaudOtherFund.Text=fltOtherFund.Text; 
                fltaudDevFundExp.Text=fltDevFundExp.Text; 
                fltaudMGExp.Text=fltMGExp.Text;
                fltaudOwnFundExp.Text=fltOwnFundExp.Text; 
                //fltaudOtherFundExp.Text=fltOtherFundExp.Text;
                //fltaudTotalExp.Text = fltTotalExp.Text;
                //fltaudTotal.Text = fltTotal.Text;
                
            }
           
        }
    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtbudsscoolbencount.ReadOnly = false;
            txtbudsscoolexpenditure.ReadOnly = false;
            txtscholarshipbencount.ReadOnly = false;
            txtscholarshipamount.ReadOnly = false;
            txtequipmentscount.ReadOnly = false;
            txtequipmentsamt.ReadOnly = false;
             txtbudsschoolexisting.ReadOnly = false;
             txtbudsscoolcurrentyear.ReadOnly = false;
             txtbudsschoolnotexisting.ReadOnly = false;
             txtbasicfacility.ReadOnly = false;
             txtvehiclerent.ReadOnly = false;
              txthonararium.ReadOnly = false;
              txtotherexp.ReadOnly = false;
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
            txtbudsscoolbencountaudit.ReadOnly = false;
            txtbudsscoolexpenditureaudit.ReadOnly = false;
            txtscholarshipbencountaudit.ReadOnly = false;
            txtscholarshipamountaudit.ReadOnly = false;
            txtequipmentsnoaudit.ReadOnly = false;
            txtequipmentamtaudit.ReadOnly = false;
            txtbudsschoolexistingaudit.ReadOnly = false;
            txtbudsscoolcurrentyearaudit.ReadOnly = false;
            txtbudsschoolnotexistingaudit.ReadOnly = false;
            txtbasicfacilityaudit.ReadOnly = false;
            txtvehiclerentaudit.ReadOnly = false;
            txthonarariumaudit.ReadOnly = false;
            txtotherexpaudit.ReadOnly = false;
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

    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"].ToString())); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["YearID"]

        DataSet dsFill = objcom.FillData("SP_tb_budschooldetails_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            txtbudsscoolbencount.Text = dsFill.Tables[0].Rows[0].ItemArray[1].ToString();
            txtbudsscoolexpenditure.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
            txtscholarshipbencount.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
            txtscholarshipamount.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();
            txtequipmentscount.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();
            txtequipmentsamt.Text = dsFill.Tables[0].Rows[0].ItemArray[6].ToString();
            txtbudsschoolexisting.Text = dsFill.Tables[0].Rows[0].ItemArray[7].ToString();
            txtbudsscoolcurrentyear.Text = dsFill.Tables[0].Rows[0].ItemArray[8].ToString();
            txtbudsschoolnotexisting.Text = dsFill.Tables[0].Rows[0].ItemArray[9].ToString();
            txtbasicfacility.Text = dsFill.Tables[0].Rows[0].ItemArray[10].ToString();
            txtvehiclerent.Text = dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
            txthonararium.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
            txtotherexp.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();
            txtbudsscoolbencountaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[14].ToString();
            txtbudsscoolexpenditureaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[15].ToString();
            txtscholarshipbencountaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[16].ToString();
            txtscholarshipamountaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[17].ToString();
            txtequipmentsnoaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[18].ToString();
            txtequipmentamtaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[19].ToString();
            txtbudsschoolexistingaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[20].ToString();
            txtbudsscoolcurrentyearaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[21].ToString();
            txtbudsschoolnotexistingaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[22].ToString();
            txtbasicfacilityaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[23].ToString();
            txtvehiclerentaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[24].ToString();
            txthonarariumaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[25].ToString();
            txtotherexpaudit.Text = dsFill.Tables[0].Rows[0].ItemArray[26].ToString();

        }
        SetEditable();

    }

     public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrFill = new ArrayList();
        arrFill.Add(Convert.ToInt32(Session["LBID"].ToString())); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["YearID"]

        if (txtbudsscoolbencount.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtbudsscoolbencount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (txtbudsscoolexpenditure.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtbudsscoolexpenditure.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        
          if (txtscholarshipbencount.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtscholarshipbencount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtscholarshipamount.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtscholarshipamount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        
        if (txtequipmentscount.Text != "")
        {
            arrFill.Add(Convert.ToInt32(txtequipmentscount.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
          if (txtequipmentsamt.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtequipmentsamt.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
       
        if (txtbudsschoolexisting.Text != "")
        {
            arrFill.Add( (txtbudsschoolexisting.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbudsscoolcurrentyear.Text != "")
        {
            arrFill.Add( (txtbudsscoolcurrentyear.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbudsschoolnotexisting.Text != "")
        {
            arrFill.Add( (txtbudsschoolnotexisting.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbasicfacility.Text != "")
        {
            arrFill.Add( (txtbasicfacility.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtvehiclerent.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtvehiclerent.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txthonararium.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txthonararium.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtotherexp.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtotherexp.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
         //------------------------------------------------
        if (txtbudsscoolbencountaudit.Text != "")
        {
            arrFill.Add(Convert.ToInt32(txtbudsscoolbencountaudit.Text));
        }
        else
        {
            //if (txtbudsscoolbencount.Text != "")
            //{
            //    arrFill.Add(Convert.ToInt32(txtbudsscoolbencount.Text));
            //}
            //else
            //{
            //    arrFill.Add(DBNull.Value);
            //}
            arrFill.Add(DBNull.Value);
        }
        if (txtbudsscoolexpenditureaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtbudsscoolexpenditureaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }


        if (txtscholarshipbencountaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtscholarshipbencountaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtscholarshipamountaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtscholarshipamountaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }


        if (txtequipmentsnoaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtequipmentsnoaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtequipmentamtaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtequipmentamtaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        if (txtbudsschoolexistingaudit.Text != "")
        {
            arrFill.Add( (txtbudsschoolexistingaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbudsscoolcurrentyearaudit.Text != "")
        {
            arrFill.Add( (txtbudsscoolcurrentyearaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbudsschoolnotexistingaudit.Text != "")
        {
            arrFill.Add( (txtbudsschoolnotexistingaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtbasicfacilityaudit.Text != "")
        {
            arrFill.Add( (txtbasicfacilityaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtvehiclerentaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtvehiclerentaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txthonarariumaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txthonarariumaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }
        if (txtotherexpaudit.Text != "")
        {
            arrFill.Add(Convert.ToDouble(txtotherexpaudit.Text));
        }
        else
        {
            arrFill.Add(DBNull.Value);
        }

        arrFill.Add(1);
        arrFill.Add(Convert.ToInt64(Session["UserID"]));
        arrFill.Add(Convert.ToInt64(Session["SeatID"]));
        int row = objcomm.update("SP_tb_budschooldetails_IU", arrFill);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
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
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("SocialJusticeNurserySchool_Urban.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        Save_Datasocial();
        Filldata();
        FillDataSocial();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PovertyReduction_Urban.aspx");
    }
}
