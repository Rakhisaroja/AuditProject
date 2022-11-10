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

public partial class Pages_ProjectSectorWise_Urban : System.Web.UI.Page
{
    CommonClass objCom = new CommonClass();
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();

            if (Convert.ToInt32(Session["Flag"]) == 1)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            //FillGramasabha();           
            Session["Flag"] = 0;
            fillStandingCommittee();
        }
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



    public void fillStandingCommittee()
    {
        ArrayList arrIn = new ArrayList();
        DataSet ds = new DataSet();
        if ((Session["LBType"].ToString() == "1") || (Session["LBType"].ToString() == "2") || (Session["LBType"].ToString() == "5"))
        {
            arrIn.Add(5);
            ds = objCom.FillData("[SP_TB_StandingCommittee_MST_S]", arrIn, CommandType.StoredProcedure);
            gblObj.FillCombo(ddlStandingCommittee, ds, 2);
        }
        else if((Session["LBType"].ToString() == "3")||(Session["LBType"].ToString() == "4"))
        {
            arrIn.Add(3);
            ds = objCom.FillData("[SP_TB_StandingCommittee_MST_S]", arrIn, CommandType.StoredProcedure);
            gblObj.FillCombo(ddlStandingCommittee, ds, 2);
        }
    }
    protected void ddlStandingCommittee_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(ddlStandingCommittee.SelectedValue));
        ds = objCom.FillData("[SP_TB_Sector_MST_S]", arr, CommandType.StoredProcedure);
        gblObj.FillCombo(ddlSector, ds, 1);
        rptSector.Visible = false;
        //rptSector.DataSource = null;
        //rptSector.DataBind();
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
        for (int i = 0; i < rptSector.Items.Count; i++)
        {
            Label intWorkingGroupID = rptSector.Items[i].FindControl("intWorkingGroupID") as Label;
            if (intWorkingGroupID.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intWorkingGroupID.Text));
            }
            Label lbldecProjectID = rptSector.Items[i].FindControl("lbldecProjectID") as Label;
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

            TextBox fltDevFund = rptSector.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = rptSector.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = rptSector.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            //TextBox fltOtherFund = rptSector.Items[i].FindControl("fltOtherFund") as TextBox;
            //if (fltOtherFund.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            //}

            //TextBox fltTotal = rptSector.Items[i].FindControl("fltTotal") as TextBox;
            //if (fltTotal.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotal.Text));

            //}



            TextBox fltDevFundExp = rptSector.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = rptSector.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = rptSector.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            //TextBox fltOtherFundExp = rptSector.Items[i].FindControl("fltOtherFundExp") as TextBox;
            //if (fltOtherFundExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            //}


            //TextBox fltTotalExp = rptSector.Items[i].FindControl("fltTotalExp") as TextBox;
            //if (fltTotalExp.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            //}


            TextBox fltaudDevFund = rptSector.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = rptSector.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = rptSector.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            //TextBox fltaudOtherFund = rptSector.Items[i].FindControl("fltaudOtherFund") as TextBox;
            //if (fltaudOtherFund.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            //}


            //TextBox fltaudTotal = rptSector.Items[i].FindControl("fltaudTotal") as TextBox;
            //if (fltaudTotal.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);

            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            //}



            TextBox fltaudDevFundExp = rptSector.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = rptSector.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = rptSector.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            //TextBox fltaudOtherFundExp = rptSector.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            //if (fltaudOtherFundExp.Text == "")
            //{
            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            //}


            //TextBox fltaudTotalExp = rptSector.Items[i].FindControl("fltaudTotalExp") as TextBox;
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
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrFill.Add(Convert.ToInt32(ddlSector.SelectedValue));
        DataSet dsFill = objCom.FillData("[SP_tb_ProjectDetailsSectorWiseUrban_Sel]", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptSector.Visible = true;
            rptSector.DataSource = dsFill;
            rptSector.DataBind();


        }
        else
        {
            rptSector.Visible = false;
        }


        SetEditable();
        //ValueAssign();
    }
    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Filldata();
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptSector.Items.Count; i++)
        {
            TextBox fltDevFund = rptSector.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = rptSector.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = rptSector.Items[i].FindControl("fltOwnFund") as TextBox;
            //TextBox fltOtherFund = rptSector.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = rptSector.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = rptSector.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = rptSector.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //TextBox fltOtherFundExp = rptSector.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = rptSector.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = rptSector.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = rptSector.Items[i].FindControl("fltaudOwnFund") as TextBox;
            TextBox fltaudOtherFund = rptSector.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = rptSector.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = rptSector.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = rptSector.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            //TextBox fltaudOtherFundExp = rptSector.Items[i].FindControl("fltaudOtherFundExp") as TextBox;






            fltaudDevFund.Text = fltDevFund.Text;
            fltaudMG.Text = fltMG.Text;

            fltaudOwnFund.Text = fltOwnFund.Text;
            //fltaudOtherFund.Text = fltOtherFund.Text;

            fltaudDevFundExp.Text = fltDevFundExp.Text;
            fltaudMGExp.Text = fltMGExp.Text;

            fltaudOwnFundExp.Text = fltOwnFundExp.Text;
            //fltaudOtherFundExp.Text = fltOtherFundExp.Text;
        }
    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < rptSector.Items.Count; i++)
            //{
            //    TextBox fltDevFund = rptSector.Items[i].FindControl("fltDevFund") as TextBox;
            //    TextBox fltMG = rptSector.Items[i].FindControl("fltMG") as TextBox;

            //    TextBox fltOwnFund = rptSector.Items[i].FindControl("fltOwnFund") as TextBox;
            //    TextBox fltOtherFund = rptSector.Items[i].FindControl("fltOtherFund") as TextBox;

            //    TextBox fltDevFundExp = rptSector.Items[i].FindControl("fltDevFundExp") as TextBox;
            //    TextBox fltMGExp = rptSector.Items[i].FindControl("fltMGExp") as TextBox;

            //    TextBox fltOwnFundExp = rptSector.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //    TextBox fltOtherFundExp = rptSector.Items[i].FindControl("fltOtherFundExp") as TextBox;

            //    fltDevFund.ReadOnly = false;
            //    fltMG.ReadOnly = false;

            //    fltOwnFund.ReadOnly = false;
            //    //fltOtherFund.ReadOnly = false;

            //    fltDevFundExp.ReadOnly = false;
            //    fltMGExp.ReadOnly = false;

            //    fltOwnFundExp.ReadOnly = false;
            //    //fltOtherFundExp.ReadOnly = false;

            //}
        }
        else
        {
            for (int i = 0; i < rptSector.Items.Count; i++)
            {
                TextBox fltaudDevFund = rptSector.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = rptSector.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = rptSector.Items[i].FindControl("fltaudOwnFund") as TextBox;
                //TextBox fltaudOtherFund =rptSector.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = rptSector.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = rptSector.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = rptSector.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                //TextBox fltaudOtherFundExp =rptSector.Items[i].FindControl("fltaudOtherFundExp") as TextBox;

                //TextBox fltaudTotalExp = rptSector.Items[i].FindControl("fltaudTotalExp") as TextBox;
                //TextBox fltaudTotal = rptSector.Items[i].FindControl("fltaudTotal") as TextBox;

                //fltaudTotalExp.ReadOnly = false;
                //fltaudTotal.ReadOnly = false;



                fltaudDevFund.ReadOnly = false;
                fltaudMG.ReadOnly = false;

                fltaudOwnFund.ReadOnly = false;
                //fltaudOtherFund.ReadOnly = false;

                fltaudDevFundExp.ReadOnly = false;
                fltaudMGExp.ReadOnly = false;

                fltaudOwnFundExp.ReadOnly = false;
                //fltaudOtherFundExp.ReadOnly = false;
            }
        }

    }

    
}
