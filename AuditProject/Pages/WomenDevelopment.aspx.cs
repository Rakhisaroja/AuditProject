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

public partial class Pages_WomenDevelopment : System.Web.UI.Page
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
             
                grvWomenDevelop.Visible = false;

            }
            else
            {
                //add on 13-06-2019
                grvWomenDevelop.Visible = true;

            Filldata();
            chkStatus();

        }
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

    public void ValueAssign()
    {
        for (int i = 0; i < grvWomenDevelop.Items.Count; i++)
        {
            TextBox fltDevFund = grvWomenDevelop.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = grvWomenDevelop.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = grvWomenDevelop.Items[i].FindControl("fltOwnFund") as TextBox;
            TextBox fltOtherFund = grvWomenDevelop.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = grvWomenDevelop.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = grvWomenDevelop.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltOwnFundExp") as TextBox;
            TextBox fltOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = grvWomenDevelop.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = grvWomenDevelop.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = grvWomenDevelop.Items[i].FindControl("fltaudOwnFund") as TextBox;
            TextBox fltaudOtherFund = grvWomenDevelop.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = grvWomenDevelop.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = grvWomenDevelop.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            TextBox fltaudOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOtherFundExp") as TextBox;






            fltaudDevFund.Text = fltDevFund.Text;
            fltaudMG.Text = fltMG.Text;

            fltaudOwnFund.Text = fltOwnFund.Text;
            fltaudOtherFund.Text = fltOtherFund.Text;

            fltaudDevFundExp.Text = fltDevFundExp.Text;
            fltaudMGExp.Text = fltMGExp.Text;

            fltaudOwnFundExp.Text = fltOwnFundExp.Text;
            fltaudOtherFundExp.Text = fltOtherFundExp.Text;
        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < grvWomenDevelop.Items.Count; i++)
            //{
            //    TextBox fltDevFund = grvWomenDevelop.Items[i].FindControl("fltDevFund") as TextBox;
            //    TextBox fltMG = grvWomenDevelop.Items[i].FindControl("fltMG") as TextBox;

            //    TextBox fltOwnFund = grvWomenDevelop.Items[i].FindControl("fltOwnFund") as TextBox;
            //    TextBox fltOtherFund = grvWomenDevelop.Items[i].FindControl("fltOtherFund") as TextBox;

            //    TextBox fltDevFundExp = grvWomenDevelop.Items[i].FindControl("fltDevFundExp") as TextBox;
            //    TextBox fltMGExp = grvWomenDevelop.Items[i].FindControl("fltMGExp") as TextBox;

            //    TextBox fltOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltOwnFundExp") as TextBox;
            //    TextBox fltOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltOtherFundExp") as TextBox;

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
            for (int i = 0; i < grvWomenDevelop.Items.Count; i++)
            {
                TextBox fltaudDevFund = grvWomenDevelop.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = grvWomenDevelop.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = grvWomenDevelop.Items[i].FindControl("fltaudOwnFund") as TextBox;
                TextBox fltaudOtherFund = grvWomenDevelop.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = grvWomenDevelop.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = grvWomenDevelop.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                TextBox fltaudOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


                TextBox fltaudTotalExp = grvWomenDevelop.Items[i].FindControl("fltaudTotalExp") as TextBox;
                TextBox fltaudTotal = grvWomenDevelop.Items[i].FindControl("fltaudTotal") as TextBox;

                fltaudTotalExp.ReadOnly = false;
                fltaudTotal.ReadOnly = false;



                fltaudDevFund.ReadOnly = false;
                fltaudMG.ReadOnly = false;

                fltaudOwnFund.ReadOnly = false;
                fltaudOtherFund.ReadOnly = false;

                fltaudDevFundExp.ReadOnly = false;
                fltaudMGExp.ReadOnly = false;

                fltaudOwnFundExp.ReadOnly = false;
                fltaudOtherFundExp.ReadOnly = false;
            }
        }

    }
    public void Filldata()
    {
         ArrayList arrFill = new ArrayList();
        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); 
        arrFill.Add(Convert.ToInt32(Session["Year"])); 
        arrFill.Add(1);
        DataSet dsFill = objcom.FillData("SP_tb_projectdetails_SelChildProj", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                grvWomenDevelop.Visible = true;
                grvWomenDevelop.DataSource = dsFill;
                grvWomenDevelop.DataBind();
            }
            else
            {
                grvWomenDevelop.Visible = false;
            }
        }
            //add on 13-06-2019
        else
        {
            grvWomenDevelop.Visible = false;
        }
        //add on 13-06-2019
        SetEditable();
    }
    protected void btnSave_Click(object sender, EventArgs e)
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
        for (int i = 0; i < grvWomenDevelop.Items.Count; i++)
        {
            arrIn.Add(1);
            Label lbldecProjectID = grvWomenDevelop.Items[i].FindControl("lbldecProjectID") as Label;
            if (lbldecProjectID.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(lbldecProjectID.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"]));
            arrIn.Add(Convert.ToInt32(Session["Year"]));

            TextBox fltDevFund = grvWomenDevelop.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = grvWomenDevelop.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = grvWomenDevelop.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            TextBox fltOtherFund = grvWomenDevelop.Items[i].FindControl("fltOtherFund") as TextBox;
            if (fltOtherFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            }

            TextBox fltTotal = grvWomenDevelop.Items[i].FindControl("fltTotal") as TextBox;
            if (fltTotal.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotal.Text));

            }



            TextBox fltDevFundExp = grvWomenDevelop.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = grvWomenDevelop.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            TextBox fltOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltOtherFundExp") as TextBox;
            if (fltOtherFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            }


            TextBox fltTotalExp = grvWomenDevelop.Items[i].FindControl("fltTotalExp") as TextBox;
            if (fltTotalExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            }


            TextBox fltaudDevFund = grvWomenDevelop.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = grvWomenDevelop.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = grvWomenDevelop.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            TextBox fltaudOtherFund = grvWomenDevelop.Items[i].FindControl("fltaudOtherFund") as TextBox;
            if (fltaudOtherFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            }


            TextBox fltaudTotal = grvWomenDevelop.Items[i].FindControl("fltaudTotal") as TextBox;
            if (fltaudTotal.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            }



            TextBox fltaudDevFundExp = grvWomenDevelop.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = grvWomenDevelop.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            TextBox fltaudOtherFundExp = grvWomenDevelop.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            if (fltaudOtherFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            }


            TextBox fltaudTotalExp = grvWomenDevelop.Items[i].FindControl("fltaudTotalExp") as TextBox;
            if (fltaudTotalExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudTotalExp.Text));
            }
            int row = objcomm.update("SP_tb_projectdetailschild_U", arrIn);
            arrIn.Clear();
           
        }
        gblObj.MsgBoxOk("Saved successfully ", this);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("SCSTDevelopment.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SocialJusticeChildAged.aspx");
    }
   
}
