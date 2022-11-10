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
public partial class Pages_FrontOfficeDet_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            Filldata();
                    
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
    public void SetInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intfrontofficeapplication");
        arr.Add("intfrontofficecompleted");
        arr.Add("intfrontofficebalance");
        arr.Add("intfrontofficeapplicationaud");
        arr.Add("intfrontofficecompletedaud");
        arr.Add("intfrontofficebalanceaud");


        gblObj.SetRepeaterDefault(rptFrontOfce, arr);
        SetEditableFrnt();
    }
    public void SetInitialRowInwrd()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intinward");
        arr.Add("intinwardcompleted");
        arr.Add("intinwardbalance");
        arr.Add("intinwardaud");
        arr.Add("intinwardcompletedaud");
        arr.Add("intinwardbalanceaud");


        gblObj.SetRepeaterDefault(rptInwrd, arr);
        SetEditableInwrd();
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptFrontOfce.Items.Count; i++)
        {
            TextBox intfrontofficeapplication = rptFrontOfce.Items[i].FindControl("intfrontofficeapplication") as TextBox;
            TextBox intfrontofficecompleted = rptFrontOfce.Items[i].FindControl("intfrontofficecompleted") as TextBox;
            TextBox intfrontofficebalance = rptFrontOfce.Items[i].FindControl("intfrontofficebalance") as TextBox;


            TextBox intfrontofficeapplicationaud = rptFrontOfce.Items[i].FindControl("intfrontofficeapplicationaud") as TextBox;
            TextBox intfrontofficecompletedaud = rptFrontOfce.Items[i].FindControl("intfrontofficecompletedaud") as TextBox;
            TextBox intfrontofficebalanceaud = rptFrontOfce.Items[i].FindControl("intfrontofficebalanceaud") as TextBox;

            intfrontofficeapplicationaud.Text = intfrontofficeapplication.Text;
            intfrontofficecompletedaud.Text = intfrontofficecompleted.Text;

            intfrontofficebalanceaud.Text = intfrontofficebalance.Text;

        }

        for (int i = 0; i < rptInwrd.Items.Count; i++)
        {
            TextBox intinward = rptInwrd.Items[i].FindControl("intinward") as TextBox;
            TextBox intinwardcompleted = rptInwrd.Items[i].FindControl("intinwardcompleted") as TextBox;
            TextBox intinwardbalance = rptInwrd.Items[i].FindControl("intinwardbalance") as TextBox;

            TextBox intinwardaud = rptInwrd.Items[i].FindControl("intinwardaud") as TextBox;
            TextBox intinwardcompletedaud = rptInwrd.Items[i].FindControl("intinwardcompletedaud") as TextBox;
            TextBox intinwardbalanceaud = rptInwrd.Items[i].FindControl("intinwardbalanceaud") as TextBox;

             intinwardaud.Text = intinward.Text;
                intinwardcompletedaud.Text = intinwardcompleted.Text;

                intinwardbalanceaud.Text = intinwardbalance.Text;

        }
    }
    public void SetEditableInwrd()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptInwrd.Items.Count; i++)
            {
                TextBox intinward = rptInwrd.Items[i].FindControl("intinward") as TextBox;
                TextBox intinwardcompleted = rptInwrd.Items[i].FindControl("intinwardcompleted") as TextBox;
                TextBox intinwardbalance = rptInwrd.Items[i].FindControl("intinwardbalance") as TextBox;

                intinward.ReadOnly = false;
                intinwardcompleted.ReadOnly = false;

                intinwardbalance.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < rptInwrd.Items.Count; i++)
            {

                TextBox intinwardaud = rptInwrd.Items[i].FindControl("intinwardaud") as TextBox;
                TextBox intinwardcompletedaud = rptInwrd.Items[i].FindControl("intinwardcompletedaud") as TextBox;
                TextBox intinwardbalanceaud = rptInwrd.Items[i].FindControl("intinwardbalanceaud") as TextBox;

                intinwardaud.ReadOnly = false;
                intinwardcompletedaud.ReadOnly = false;

                intinwardbalanceaud.ReadOnly = false;


            }
        }
    }
    public void SetEditableFrnt()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptFrontOfce.Items.Count; i++)
            {
                TextBox intfrontofficeapplication = rptFrontOfce.Items[i].FindControl("intfrontofficeapplication") as TextBox;
                TextBox intfrontofficecompleted = rptFrontOfce.Items[i].FindControl("intfrontofficecompleted") as TextBox;
                TextBox intfrontofficebalance = rptFrontOfce.Items[i].FindControl("intfrontofficebalance") as TextBox;

                intfrontofficeapplication.ReadOnly = false;
                intfrontofficecompleted.ReadOnly = false;

                intfrontofficebalance.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < rptFrontOfce.Items.Count; i++)
            {

                TextBox intfrontofficeapplicationaud = rptFrontOfce.Items[i].FindControl("intfrontofficeapplicationaud") as TextBox;
                TextBox intfrontofficecompletedaud = rptFrontOfce.Items[i].FindControl("intfrontofficecompletedaud") as TextBox;
                TextBox intfrontofficebalanceaud = rptFrontOfce.Items[i].FindControl("intfrontofficebalanceaud") as TextBox;

                intfrontofficeapplicationaud.ReadOnly = false;
                intfrontofficecompletedaud.ReadOnly = false;

                intfrontofficebalanceaud.ReadOnly = false;


            }
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_frontofficeUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptFrontOfce.DataSource = dsFill;
            rptFrontOfce.DataBind();

            rptInwrd.DataSource = dsFill;
            rptInwrd.DataBind();
        }
        else
        {
            SetInitialRow();
            SetInitialRowInwrd();
        }
        SetEditableInwrd();
        SetEditableFrnt();
    }
    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        //for (int i = 0; i < rptBuilding.Items.Count; i++)
        //{
        int i = 0;
        Label lblNumId = rptFrontOfce.Items[i].FindControl("lblNumId") as Label;
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

        TextBox intfrontofficeapplication = rptFrontOfce.Items[i].FindControl("intfrontofficeapplication") as TextBox;
        if (intfrontofficeapplication.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficeapplication.Text));
        }
        TextBox intfrontofficecompleted = rptFrontOfce.Items[i].FindControl("intfrontofficecompleted") as TextBox;
        if (intfrontofficecompleted.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficecompleted.Text));
        }
        TextBox intfrontofficebalance = rptFrontOfce.Items[i].FindControl("intfrontofficebalance") as TextBox;
        if (intfrontofficebalance.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficebalance.Text));
        }
        TextBox intfrontofficeapplicationaud = rptFrontOfce.Items[i].FindControl("intfrontofficeapplicationaud") as TextBox;
        if (intfrontofficeapplicationaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
            
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficeapplicationaud.Text));
        }
        TextBox intfrontofficecompletedaud = rptFrontOfce.Items[i].FindControl("intfrontofficecompletedaud") as TextBox;
        if (intfrontofficecompletedaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
            
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficecompletedaud.Text));
        }
        TextBox intfrontofficebalanceaud = rptFrontOfce.Items[i].FindControl("intfrontofficebalanceaud") as TextBox;
        if (intfrontofficebalanceaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
           
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intfrontofficebalanceaud.Text));
        }



        TextBox intinward = rptInwrd.Items[i].FindControl("intinward") as TextBox;
        if (intinward.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinward.Text));
        }
        TextBox intinwardcompleted = rptInwrd.Items[i].FindControl("intinwardcompleted") as TextBox;
        if (intinwardcompleted.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinwardcompleted.Text));
        }
        TextBox intinwardbalance = rptInwrd.Items[i].FindControl("intinwardbalance") as TextBox;
        if (intinwardbalance.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinwardbalance.Text));
        }

        TextBox intinwardaud = rptInwrd.Items[i].FindControl("intinwardaud") as TextBox;
        if (intinwardaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
            
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinwardaud.Text));
        }
        TextBox intinwardcompletedaud = rptInwrd.Items[i].FindControl("intinwardcompletedaud") as TextBox;
        if (intinwardcompletedaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
            
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinwardcompletedaud.Text));
        }
        TextBox intinwardbalanceaud = rptInwrd.Items[i].FindControl("intinwardbalanceaud") as TextBox;
        if (intinwardbalanceaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
            
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intinwardbalanceaud.Text));
        }

      
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
        arrIn.Add(1);
        int row = objcomm.update("SP_tb_frontofficeUrban_IU", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }

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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LicenseDetails_Urban.aspx");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("BankClosed_Urban.aspx");
    }
}
