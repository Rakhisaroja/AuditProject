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
public partial class Pages_LicenseDetails_Urban : System.Web.UI.Page
{
    int row;
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            fillGrid();
           
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
        arr.Add("intindustryapplication");
        arr.Add("intindustrycompleted");
        arr.Add("intindustrybalance");
        arr.Add("intindustryapplicationaud");
        arr.Add("intindustrycompletedaud");
        arr.Add("intindustrybalanceaud");

      
        gblObj.SetRepeaterDefault(rptlicense, arr);
        SetEditablelics();
    }
    public void SetInitialRowLveStk()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intlvestockapplication");
        arr.Add("intlivestockcompleted");
        arr.Add("intlivestockbalance");
        arr.Add("intlvestockapplicationaud");
        arr.Add("intlivestockcompletedaud");
        arr.Add("intlivestockbalanceaud");


        gblObj.SetRepeaterDefault(rptLiveStock, arr);
        SetEditablelivStk();
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptlicense.Items.Count; i++)
        {
            TextBox intindustryapplication = rptlicense.Items[i].FindControl("intindustryapplication") as TextBox;
            TextBox intindustrycompleted = rptlicense.Items[i].FindControl("intindustrycompleted") as TextBox;
            TextBox intindustrybalance = rptlicense.Items[i].FindControl("intindustrybalance") as TextBox;

            TextBox intindustryapplicationaud = rptlicense.Items[i].FindControl("intindustryapplicationaud") as TextBox;
            TextBox intindustrycompletedaud = rptlicense.Items[i].FindControl("intindustrycompletedaud") as TextBox;
            TextBox intindustrybalanceaud = rptlicense.Items[i].FindControl("intindustrybalanceaud") as TextBox;

            intindustryapplicationaud.Text = intindustryapplication.Text;
            intindustrycompletedaud.Text = intindustrycompleted.Text;

            intindustrybalanceaud.Text = intindustrybalance.Text;
        }
        for (int i = 0; i < rptLiveStock.Items.Count; i++)
        {
            TextBox intlvestockapplication = rptLiveStock.Items[i].FindControl("intlvestockapplication") as TextBox;
            TextBox intlivestockcompleted = rptLiveStock.Items[i].FindControl("intlivestockcompleted") as TextBox;
            TextBox intlivestockbalance = rptLiveStock.Items[i].FindControl("intlivestockbalance") as TextBox;

            TextBox intlvestockapplicationaud = rptLiveStock.Items[i].FindControl("intlvestockapplicationaud") as TextBox;
            TextBox intlivestockcompletedaud = rptLiveStock.Items[i].FindControl("intlivestockcompletedaud") as TextBox;
            TextBox intlivestockbalanceaud = rptLiveStock.Items[i].FindControl("intlivestockbalanceaud") as TextBox;

            intlvestockapplicationaud.Text =intlvestockapplication.Text;
            intlivestockcompletedaud.Text = intlivestockcompleted.Text;
            intlivestockbalanceaud.Text = intlivestockbalance.Text;
        }

         
    }
    public void SetEditablelics()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptlicense.Items.Count; i++)
            {
                TextBox intindustryapplication = rptlicense.Items[i].FindControl("intindustryapplication") as TextBox;
                TextBox intindustrycompleted = rptlicense.Items[i].FindControl("intindustrycompleted") as TextBox;
                TextBox intindustrybalance = rptlicense.Items[i].FindControl("intindustrybalance") as TextBox;
         
                intindustryapplication.ReadOnly = false;
                intindustrycompleted.ReadOnly = false;

                intindustrybalance.ReadOnly = false;
 

            }
        }
        else
        {
            for (int i = 0; i < rptlicense.Items.Count; i++)
            {

                TextBox intindustryapplicationaud = rptlicense.Items[i].FindControl("intindustryapplicationaud") as TextBox;
                TextBox intindustrycompletedaud = rptlicense.Items[i].FindControl("intindustrycompletedaud") as TextBox;
                TextBox intindustrybalanceaud = rptlicense.Items[i].FindControl("intindustrybalanceaud") as TextBox;

                intindustryapplicationaud.ReadOnly = false;
                intindustrycompletedaud.ReadOnly = false;

                intindustrybalanceaud.ReadOnly = false;


            }
        }
    }

    public void SetEditablelivStk()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptLiveStock.Items.Count; i++)
            {
                TextBox intlvestockapplication = rptLiveStock.Items[i].FindControl("intlvestockapplication") as TextBox;
                TextBox intlivestockcompleted = rptLiveStock.Items[i].FindControl("intlivestockcompleted") as TextBox;
                TextBox intlivestockbalance = rptLiveStock.Items[i].FindControl("intlivestockbalance") as TextBox;

                intlvestockapplication.ReadOnly = false;
                intlivestockcompleted.ReadOnly = false;

                intlivestockbalance.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < rptLiveStock.Items.Count; i++)
            {

                TextBox intlvestockapplicationaud = rptLiveStock.Items[i].FindControl("intlvestockapplicationaud") as TextBox;
                TextBox intlivestockcompletedaud = rptLiveStock.Items[i].FindControl("intlivestockcompletedaud") as TextBox;
                TextBox intlivestockbalanceaud = rptLiveStock.Items[i].FindControl("intlivestockbalanceaud") as TextBox;

                intlvestockapplicationaud.ReadOnly = false;
                intlivestockcompletedaud.ReadOnly = false;

                intlivestockbalanceaud.ReadOnly = false;


            }
        }
    }
    void fillGrid()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_licenseUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptlicense.DataSource = dsFill;
            rptlicense.DataBind();

            rptLiveStock.DataSource = dsFill;
            rptLiveStock.DataBind();
        }
        else
        {
            SetInitialRow();
            SetInitialRowLveStk();
        }
        SetEditablelics();
        SetEditablelivStk();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveData();
        fillGrid();
    }
    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        //for (int i = 0; i < rptBuilding.Items.Count; i++)
        //{
        int i = 0;
        Label lblNumId = rptlicense.Items[i].FindControl("lblNumId") as Label;
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

        TextBox intindustryapplication = rptlicense.Items[i].FindControl("intindustryapplication") as TextBox;
        if (intindustryapplication.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustryapplication.Text));
        }

        TextBox intindustrycompleted = rptlicense.Items[i].FindControl("intindustrycompleted") as TextBox;
        if (intindustrycompleted.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustrycompleted.Text));
        }

        TextBox intindustrybalance = rptlicense.Items[i].FindControl("intindustrybalance") as TextBox;
        if (intindustrybalance.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustrybalance.Text));
        }

        TextBox intindustryapplicationaud = rptlicense.Items[i].FindControl("intindustryapplicationaud") as TextBox;
        if (intindustryapplicationaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustryapplicationaud.Text));
        }

        TextBox intindustrycompletedaud = rptlicense.Items[i].FindControl("intindustrycompletedaud") as TextBox;
        if (intindustrycompletedaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
           
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustrycompletedaud.Text));
        }

        TextBox intindustrybalanceaud = rptlicense.Items[i].FindControl("intindustrybalanceaud") as TextBox;
        if (intindustrybalanceaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
           
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intindustrybalanceaud.Text));
        }


        TextBox intlvestockapplication = rptLiveStock.Items[i].FindControl("intlvestockapplication") as TextBox;
        if (intlvestockapplication.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlvestockapplication.Text));
        }
        TextBox intlivestockcompleted = rptLiveStock.Items[i].FindControl("intlivestockcompleted") as TextBox;
        if (intlivestockcompleted.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlivestockcompleted.Text));
        }
        TextBox intlivestockbalance = rptLiveStock.Items[i].FindControl("intlivestockbalance") as TextBox;
        if (intlivestockbalance.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlivestockbalance.Text));
        }
        TextBox intlvestockapplicationaud = rptLiveStock.Items[i].FindControl("intlvestockapplicationaud") as TextBox;
        if (intlvestockapplicationaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
           
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlvestockapplicationaud.Text));
        }
        TextBox intlivestockcompletedaud = rptLiveStock.Items[i].FindControl("intlivestockcompletedaud") as TextBox;
        if (intlivestockcompletedaud.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlivestockcompletedaud.Text));
        }
        TextBox intlivestockbalanceaud = rptLiveStock.Items[i].FindControl("intlivestockbalanceaud") as TextBox;
        if (intlivestockbalanceaud.Text == "")
        {
            arrIn.Add(DBNull.Value);
           
        }
        else
        {
            arrIn.Add(Convert.ToInt32(intlivestockbalanceaud.Text));
        }

        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
        arrIn.Add(1);
        int row = objcomm.update("SP_tb_licenseUrban_IU", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MNREGSRegistration_Urban.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrontOfficeDet_Urban.aspx");
    }
}
