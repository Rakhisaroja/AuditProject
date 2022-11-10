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

public partial class AuditProject_Pages_SocialJusticeChildAged : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             //add on 13-06-2019   add condition
            if (Convert.ToInt32(Session["Year"]) == 22)
            {
                rptchild.Visible = false;
                 
                rptAged.Visible = false;
                 
                rptPaliative.Visible = false;
                
            }
            else
            {
                rptchild.Visible = true;
                rptAged.Visible = true;
                rptPaliative.Visible = true;
                Filldata();
            }  
            chkStatus();
        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2")
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
        for (int i = 0; i < rptchild.Items.Count; i++)
        {
            TextBox fltDevFund = rptchild.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = rptchild.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = rptchild.Items[i].FindControl("fltOwnFund") as TextBox;
            TextBox fltOtherFund = rptchild.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = rptchild.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = rptchild.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = rptchild.Items[i].FindControl("fltOwnFundExp") as TextBox;
            TextBox fltOtherFundExp = rptchild.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = rptchild.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = rptchild.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = rptchild.Items[i].FindControl("fltaudOwnFund") as TextBox;
            TextBox fltaudOtherFund = rptchild.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = rptchild.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = rptchild.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = rptchild.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            TextBox fltaudOtherFundExp = rptchild.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


           



            fltaudDevFund.Text = fltDevFund.Text;
            fltaudMG.Text = fltMG.Text;

            fltaudOwnFund.Text = fltOwnFund.Text;
            fltaudOtherFund.Text = fltOtherFund.Text;

            fltaudDevFundExp.Text = fltDevFundExp.Text;
            fltaudMGExp.Text = fltMGExp.Text;

            fltaudOwnFundExp.Text = fltOwnFundExp.Text;
            fltaudOtherFundExp.Text = fltOtherFundExp.Text;
        }



        for (int i = 0; i < rptAged.Items.Count; i++)
        {
            TextBox fltDevFund = rptAged.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = rptAged.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = rptAged.Items[i].FindControl("fltOwnFund") as TextBox;
            TextBox fltOtherFund = rptAged.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = rptAged.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = rptAged.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = rptAged.Items[i].FindControl("fltOwnFundExp") as TextBox;
            TextBox fltOtherFundExp = rptAged.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = rptAged.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = rptAged.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = rptAged.Items[i].FindControl("fltaudOwnFund") as TextBox;
            TextBox fltaudOtherFund = rptAged.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = rptAged.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = rptAged.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = rptAged.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            TextBox fltaudOtherFundExp = rptAged.Items[i].FindControl("fltaudOtherFundExp") as TextBox;






            fltaudDevFund.Text = fltDevFund.Text;
            fltaudMG.Text = fltMG.Text;

            fltaudOwnFund.Text = fltOwnFund.Text;
            fltaudOtherFund.Text = fltOtherFund.Text;

            fltaudDevFundExp.Text = fltDevFundExp.Text;
            fltaudMGExp.Text = fltMGExp.Text;

            fltaudOwnFundExp.Text = fltOwnFundExp.Text;
            fltaudOtherFundExp.Text = fltOtherFundExp.Text;
        }

        for (int i = 0; i < rptPaliative.Items.Count; i++)
        {
            TextBox fltDevFund = rptPaliative.Items[i].FindControl("fltDevFund") as TextBox;
            TextBox fltMG = rptPaliative.Items[i].FindControl("fltMG") as TextBox;

            TextBox fltOwnFund = rptPaliative.Items[i].FindControl("fltOwnFund") as TextBox;
            TextBox fltOtherFund = rptPaliative.Items[i].FindControl("fltOtherFund") as TextBox;

            TextBox fltDevFundExp = rptPaliative.Items[i].FindControl("fltDevFundExp") as TextBox;
            TextBox fltMGExp = rptPaliative.Items[i].FindControl("fltMGExp") as TextBox;

            TextBox fltOwnFundExp = rptPaliative.Items[i].FindControl("fltOwnFundExp") as TextBox;
            TextBox fltOtherFundExp = rptPaliative.Items[i].FindControl("fltOtherFundExp") as TextBox;

            TextBox fltaudDevFund = rptPaliative.Items[i].FindControl("fltaudDevFund") as TextBox;
            TextBox fltaudMG = rptPaliative.Items[i].FindControl("fltaudMG") as TextBox;

            TextBox fltaudOwnFund = rptPaliative.Items[i].FindControl("fltaudOwnFund") as TextBox;
            TextBox fltaudOtherFund = rptPaliative.Items[i].FindControl("fltaudOtherFund") as TextBox;

            TextBox fltaudDevFundExp = rptPaliative.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            TextBox fltaudMGExp = rptPaliative.Items[i].FindControl("fltaudMGExp") as TextBox;

            TextBox fltaudOwnFundExp = rptPaliative.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            TextBox fltaudOtherFundExp = rptPaliative.Items[i].FindControl("fltaudOtherFundExp") as TextBox;






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
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrFill.Add(2);
        DataSet dsFill = objcom.FillData("SP_tb_projectdetails_SelChildProj", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                rptchild.Visible = true;
                rptchild.DataSource = dsFill;
                rptchild.DataBind();
            }
            else
            {
                rptchild.Visible = false;

            }
        }
        else
        {
            rptchild.Visible = false;
           
        }

        ArrayList arrFillaged = new ArrayList();

        arrFillaged.Clear();
        arrFillaged.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFillaged.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrFillaged.Add(3);
        DataSet dsFillaged = objcom.FillData("SP_tb_projectdetails_SelChildProj", arrFillaged, CommandType.StoredProcedure);
        if (dsFillaged.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                rptAged.Visible = true;
                rptAged.DataSource = dsFillaged;
                rptAged.DataBind();
            }
            else
            {
                rptAged.Visible = false;

            }
        }
        else
        {
            rptAged.Visible = false;
             
        }
        ArrayList arrFillpaliative = new ArrayList();

        arrFillpaliative.Clear();
        arrFillpaliative.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFillpaliative.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        arrFillpaliative.Add(6);
        DataSet dsFillpal = objcom.FillData("SP_tb_projectdetails_SelChildProj", arrFillpaliative, CommandType.StoredProcedure);
        if (dsFillpal.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(Session["Year"]) == 21)
            {
                rptPaliative.Visible = true;
                rptPaliative.DataSource = dsFillpal;
                rptPaliative.DataBind();
            }
            else
            {
                rptPaliative.Visible = false;

            }
        }
        else
        {
            rptPaliative.Visible = false;
             
        }

        SetEditable();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2")
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
        for (int i = 0; i < rptchild.Items.Count; i++)
        {
            arrIn.Clear();
            arrIn.Add(2);
            Label lbldecProjectID = rptchild.Items[i].FindControl("lbldecProjectID") as Label;
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

            TextBox fltDevFund = rptchild.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = rptchild.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = rptchild.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            TextBox fltOtherFund = rptchild.Items[i].FindControl("fltOtherFund") as TextBox;
            if (fltOtherFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            }

            TextBox fltTotal = rptchild.Items[i].FindControl("fltTotal") as TextBox;
            if (fltTotal.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotal.Text));

            }



            TextBox fltDevFundExp = rptchild.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = rptchild.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = rptchild.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            TextBox fltOtherFundExp = rptchild.Items[i].FindControl("fltOtherFundExp") as TextBox;
            if (fltOtherFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            }


            TextBox fltTotalExp = rptchild.Items[i].FindControl("fltTotalExp") as TextBox;
            if (fltTotalExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            }


            TextBox fltaudDevFund = rptchild.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = rptchild.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = rptchild.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            TextBox fltaudOtherFund = rptchild.Items[i].FindControl("fltaudOtherFund") as TextBox;
            if (fltaudOtherFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            }


            TextBox fltaudTotal = rptchild.Items[i].FindControl("fltaudTotal") as TextBox;
            if (fltaudTotal.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            }



            TextBox fltaudDevFundExp = rptchild.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = rptchild.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = rptchild.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            TextBox fltaudOtherFundExp = rptchild.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            if (fltaudOtherFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            }


            TextBox fltaudTotalExp = rptchild.Items[i].FindControl("fltaudTotalExp") as TextBox;
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

            //Aged People

        for (int i = 0; i < rptAged.Items.Count; i++)
        {
            arrIn.Clear();
            arrIn.Add(3);
            Label lbldecProjectID = rptAged.Items[i].FindControl("lbldecProjectID") as Label;
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

            TextBox fltDevFund = rptAged.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = rptAged.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = rptAged.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            TextBox fltOtherFund = rptAged.Items[i].FindControl("fltOtherFund") as TextBox;
            if (fltOtherFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            }

            TextBox fltTotal = rptAged.Items[i].FindControl("fltTotal") as TextBox;
            if (fltTotal.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotal.Text));

            }



            TextBox fltDevFundExp = rptAged.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = rptAged.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = rptAged.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            TextBox fltOtherFundExp = rptAged.Items[i].FindControl("fltOtherFundExp") as TextBox;
            if (fltOtherFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            }


            TextBox fltTotalExp = rptAged.Items[i].FindControl("fltTotalExp") as TextBox;
            if (fltTotalExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            }


            TextBox fltaudDevFund = rptAged.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = rptAged.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = rptAged.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            TextBox fltaudOtherFund = rptAged.Items[i].FindControl("fltaudOtherFund") as TextBox;
            if (fltaudOtherFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            }


            TextBox fltaudTotal = rptAged.Items[i].FindControl("fltaudTotal") as TextBox;
            if (fltaudTotal.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            }



            TextBox fltaudDevFundExp = rptAged.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = rptAged.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = rptAged.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            TextBox fltaudOtherFundExp = rptAged.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            if (fltaudOtherFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            }


            TextBox fltaudTotalExp = rptAged.Items[i].FindControl("fltaudTotalExp") as TextBox;
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
        
        //Paliative


        for (int i = 0; i < rptPaliative.Items.Count; i++)
        {
            arrIn.Clear();
            arrIn.Add(6);
            Label lbldecProjectID = rptPaliative.Items[i].FindControl("lbldecProjectID") as Label;
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

            TextBox fltDevFund = rptPaliative.Items[i].FindControl("fltDevFund") as TextBox;
            if (fltDevFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFund.Text));
            }

            TextBox fltMG = rptPaliative.Items[i].FindControl("fltMG") as TextBox;
            if (fltMG.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMG.Text));
            }
            TextBox fltOwnFund = rptPaliative.Items[i].FindControl("fltOwnFund") as TextBox;
            if (fltOwnFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFund.Text));
            }
            TextBox fltOtherFund = rptPaliative.Items[i].FindControl("fltOtherFund") as TextBox;
            if (fltOtherFund.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFund.Text));

            }

            TextBox fltTotal = rptPaliative.Items[i].FindControl("fltTotal") as TextBox;
            if (fltTotal.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotal.Text));

            }



            TextBox fltDevFundExp = rptPaliative.Items[i].FindControl("fltDevFundExp") as TextBox;
            if (fltDevFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltDevFundExp.Text));
            }

            TextBox fltMGExp = rptPaliative.Items[i].FindControl("fltMGExp") as TextBox;
            if (fltMGExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltMGExp.Text));
            }


            TextBox fltOwnFundExp = rptPaliative.Items[i].FindControl("fltOwnFundExp") as TextBox;
            if (fltOwnFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOwnFundExp.Text));
            }
            TextBox fltOtherFundExp = rptPaliative.Items[i].FindControl("fltOtherFundExp") as TextBox;
            if (fltOtherFundExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltOtherFundExp.Text));
            }


            TextBox fltTotalExp = rptPaliative.Items[i].FindControl("fltTotalExp") as TextBox;
            if (fltTotalExp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltTotalExp.Text));
            }


            TextBox fltaudDevFund = rptPaliative.Items[i].FindControl("fltaudDevFund") as TextBox;
            if (fltaudDevFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFund.Text));
            }

            TextBox fltaudMG = rptPaliative.Items[i].FindControl("fltaudMG") as TextBox;
            if (fltaudMG.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMG.Text));
            }

            TextBox fltaudOwnFund = rptPaliative.Items[i].FindControl("fltaudOwnFund") as TextBox;
            if (fltaudOwnFund.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFund.Text));
            }
            TextBox fltaudOtherFund = rptPaliative.Items[i].FindControl("fltaudOtherFund") as TextBox;
            if (fltaudOtherFund.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFund.Text));
            }


            TextBox fltaudTotal = rptPaliative.Items[i].FindControl("fltaudTotal") as TextBox;
            if (fltaudTotal.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudTotal.Text));
            }



            TextBox fltaudDevFundExp = rptPaliative.Items[i].FindControl("fltaudDevFundExp") as TextBox;
            if (fltaudDevFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudDevFundExp.Text));
            }
            TextBox fltaudMGExp = rptPaliative.Items[i].FindControl("fltaudMGExp") as TextBox;
            if (fltaudMGExp.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudMGExp.Text));
            }
            TextBox fltaudOwnFundExp = rptPaliative.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
            if (fltaudOwnFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOwnFundExp.Text));
            }
            TextBox fltaudOtherFundExp = rptPaliative.Items[i].FindControl("fltaudOtherFundExp") as TextBox;
            if (fltaudOtherFundExp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(fltaudOtherFundExp.Text));
            }


            TextBox fltaudTotalExp = rptPaliative.Items[i].FindControl("fltaudTotalExp") as TextBox;
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


            gblObj.MsgBoxOk("Saved Successfully ", this);



        }


    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2")
        {
            for (int i = 0; i < rptchild.Items.Count; i++)
            {
                TextBox fltDevFund = rptchild.Items[i].FindControl("fltDevFund") as TextBox;
                TextBox fltMG = rptchild.Items[i].FindControl("fltMG") as TextBox;

                TextBox fltOwnFund = rptchild.Items[i].FindControl("fltOwnFund") as TextBox;
                TextBox fltOtherFund = rptchild.Items[i].FindControl("fltOtherFund") as TextBox;

                TextBox fltDevFundExp = rptchild.Items[i].FindControl("fltDevFundExp") as TextBox;
                TextBox fltMGExp = rptchild.Items[i].FindControl("fltMGExp") as TextBox;

                TextBox fltOwnFundExp = rptchild.Items[i].FindControl("fltOwnFundExp") as TextBox;
                TextBox fltOtherFundExp = rptchild.Items[i].FindControl("fltOtherFundExp") as TextBox;

                fltDevFund.ReadOnly = false;
                fltMG.ReadOnly = false;

                fltOwnFund.ReadOnly = false;
                fltOtherFund.ReadOnly = false;

                fltDevFundExp.ReadOnly = false;
                fltMGExp.ReadOnly = false;

                fltOwnFundExp.ReadOnly = false;
                fltOtherFundExp.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < rptchild.Items.Count; i++)
            {
                TextBox fltaudDevFund = rptchild.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = rptchild.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = rptchild.Items[i].FindControl("fltaudOwnFund") as TextBox;
                TextBox fltaudOtherFund = rptchild.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = rptchild.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = rptchild.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = rptchild.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                TextBox fltaudOtherFundExp = rptchild.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


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

        //Aged repeater

        if (Session["RoleID"].ToString() == "2")
        {
            for (int i = 0; i < rptAged.Items.Count; i++)
            {
                TextBox fltDevFund = rptAged.Items[i].FindControl("fltDevFund") as TextBox;
                TextBox fltMG = rptAged.Items[i].FindControl("fltMG") as TextBox;

                TextBox fltOwnFund = rptAged.Items[i].FindControl("fltOwnFund") as TextBox;
                TextBox fltOtherFund = rptAged.Items[i].FindControl("fltOtherFund") as TextBox;

                TextBox fltDevFundExp = rptAged.Items[i].FindControl("fltDevFundExp") as TextBox;
                TextBox fltMGExp = rptAged.Items[i].FindControl("fltMGExp") as TextBox;

                TextBox fltOwnFundExp = rptAged.Items[i].FindControl("fltOwnFundExp") as TextBox;
                TextBox fltOtherFundExp = rptAged.Items[i].FindControl("fltOtherFundExp") as TextBox;

                fltDevFund.ReadOnly = false;
                fltMG.ReadOnly = false;

                fltOwnFund.ReadOnly = false;
                fltOtherFund.ReadOnly = false;

                fltDevFundExp.ReadOnly = false;
                fltMGExp.ReadOnly = false;

                fltOwnFundExp.ReadOnly = false;
                fltOtherFundExp.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < rptAged.Items.Count; i++)
            {
                TextBox fltaudDevFund = rptAged.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = rptAged.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = rptAged.Items[i].FindControl("fltaudOwnFund") as TextBox;
                TextBox fltaudOtherFund = rptAged.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = rptAged.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = rptAged.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = rptAged.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                TextBox fltaudOtherFundExp = rptAged.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


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

        //paliative Repeater


        if (Session["RoleID"].ToString() == "2")
        {
            for (int i = 0; i < rptPaliative.Items.Count; i++)
            {
                TextBox fltDevFund = rptPaliative.Items[i].FindControl("fltDevFund") as TextBox;
                TextBox fltMG = rptPaliative.Items[i].FindControl("fltMG") as TextBox;

                TextBox fltOwnFund = rptPaliative.Items[i].FindControl("fltOwnFund") as TextBox;
                TextBox fltOtherFund = rptPaliative.Items[i].FindControl("fltOtherFund") as TextBox;

                TextBox fltDevFundExp = rptPaliative.Items[i].FindControl("fltDevFundExp") as TextBox;
                TextBox fltMGExp = rptPaliative.Items[i].FindControl("fltMGExp") as TextBox;

                TextBox fltOwnFundExp = rptPaliative.Items[i].FindControl("fltOwnFundExp") as TextBox;
                TextBox fltOtherFundExp = rptPaliative.Items[i].FindControl("fltOtherFundExp") as TextBox;

                fltDevFund.ReadOnly = false;
                fltMG.ReadOnly = false;

                fltOwnFund.ReadOnly = false;
                fltOtherFund.ReadOnly = false;

                fltDevFundExp.ReadOnly = false;
                fltMGExp.ReadOnly = false;

                fltOwnFundExp.ReadOnly = false;
                fltOtherFundExp.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < rptPaliative.Items.Count; i++)
            {
                TextBox fltaudDevFund = rptPaliative.Items[i].FindControl("fltaudDevFund") as TextBox;
                TextBox fltaudMG = rptPaliative.Items[i].FindControl("fltaudMG") as TextBox;

                TextBox fltaudOwnFund = rptPaliative.Items[i].FindControl("fltaudOwnFund") as TextBox;
                TextBox fltaudOtherFund = rptPaliative.Items[i].FindControl("fltaudOtherFund") as TextBox;

                TextBox fltaudDevFundExp = rptPaliative.Items[i].FindControl("fltaudDevFundExp") as TextBox;
                TextBox fltaudMGExp = rptPaliative.Items[i].FindControl("fltaudMGExp") as TextBox;

                TextBox fltaudOwnFundExp = rptPaliative.Items[i].FindControl("fltaudOwnFundExp") as TextBox;
                TextBox fltaudOtherFundExp = rptPaliative.Items[i].FindControl("fltaudOtherFundExp") as TextBox;


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

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("WomenDevelopment.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SocialJusticeBudsSchool.aspx");
    }
}
