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
public partial class Pages_BuildingDetails : System.Web.UI.Page
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
    public void SetBuildingInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intpermitapp");
        arr.Add("intnumberingapp");
        arr.Add("intregularisationapp");
        arr.Add("intownershipapp");
        arr.Add("inttaxremissionapp");
        arr.Add("intpermitcompleted");
        arr.Add("intnumberingcompleted");

        arr.Add("intregularisationcompleted");
        arr.Add("intownershipcompleted");
        arr.Add("inttaxremissioncompleted");
        arr.Add("intpermitbalance");
        arr.Add("intnumberingbalance");
        arr.Add("intregularisationbalance");
        arr.Add("intownershipbalance");
        arr.Add("inttaxremissionbalance");


        arr.Add("intauditedpermitapp");
        arr.Add("intauditednumberingapp");
        arr.Add("intauditedregularisationapp");
        arr.Add("intauditedownershipapp");
        arr.Add("intauditedtaxremissionapp");
        arr.Add("intauditedpermitcompleted");
        arr.Add("intauditednumberingcompleted");

        arr.Add("intauditedregularisationcompleted");
        arr.Add("intauditedownershipcompleted");
        arr.Add("intauditedtaxremissioncompleted");
        arr.Add("intauditedpermitbalance");
        arr.Add("intauditednumberingbalance");
        arr.Add("intauditedregularisationbalance");
        arr.Add("intauditedownershipbalance");
        arr.Add("intauditedtaxremissionbalance");
        gblObj.SetRepeaterDefault(rptBuilding, arr);
        SetEditable();
    }
    public void SetOccupancyInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intoccupancyapplication");
        arr.Add("intoccupancycompleted");
        arr.Add("intoccupancybalance");
        arr.Add("intauditedoccupancyapplication");
        arr.Add("intauditedoccupancycompleted");
        arr.Add("intauditedoccupancybalance");
       
        gblObj.SetRepeaterDefault(rptOccupancy, arr);
        SetEditableOcc();
    }

    public void ValueAssign()
    {
        for (int i = 0; i < rptOccupancy.Items.Count; i++)
        {

            TextBox intoccupancyapplication = rptOccupancy.Items[i].FindControl("intoccupancyapplication") as TextBox;
            TextBox intoccupancycompleted = rptOccupancy.Items[i].FindControl("intoccupancycompleted") as TextBox;
            TextBox intoccupancybalance = rptOccupancy.Items[i].FindControl("intoccupancybalance") as TextBox;
                

            TextBox intauditedoccupancyapplication = rptOccupancy.Items[i].FindControl("intauditedoccupancyapplication") as TextBox;
            TextBox intauditedoccupancycompleted = rptOccupancy.Items[i].FindControl("intauditedoccupancycompleted") as TextBox;
            TextBox intauditedoccupancybalance = rptOccupancy.Items[i].FindControl("intauditedoccupancybalance") as TextBox;


            intauditedoccupancyapplication.Text =intoccupancyapplication.Text;
            intauditedoccupancycompleted.Text = intoccupancycompleted.Text;

            intauditedoccupancybalance.Text = intoccupancybalance.Text;
        }

        for (int i = 0; i < rptBuilding.Items.Count; i++)
        {
            TextBox intpermitapp = rptBuilding.Items[i].FindControl("intpermitapp") as TextBox;
            TextBox intnumberingapp = rptBuilding.Items[i].FindControl("intnumberingapp") as TextBox;
            TextBox intregularisationapp = rptBuilding.Items[i].FindControl("intregularisationapp") as TextBox;
            TextBox intownershipapp = rptBuilding.Items[i].FindControl("intownershipapp") as TextBox;

            TextBox inttaxremissionapp = rptBuilding.Items[i].FindControl("inttaxremissionapp") as TextBox;
            TextBox intpermitcompleted = rptBuilding.Items[i].FindControl("intpermitcompleted") as TextBox;
            TextBox intnumberingcompleted = rptBuilding.Items[i].FindControl("intnumberingcompleted") as TextBox;
            TextBox intregularisationcompleted = rptBuilding.Items[i].FindControl("intregularisationcompleted") as TextBox;

            TextBox intownershipcompleted = rptBuilding.Items[i].FindControl("intownershipcompleted") as TextBox;
            TextBox inttaxremissioncompleted = rptBuilding.Items[i].FindControl("inttaxremissioncompleted") as TextBox;
            TextBox intpermitbalance = rptBuilding.Items[i].FindControl("intpermitbalance") as TextBox;
            TextBox intnumberingbalance = rptBuilding.Items[i].FindControl("intnumberingbalance") as TextBox;

            TextBox intregularisationbalance = rptBuilding.Items[i].FindControl("intregularisationbalance") as TextBox;
            TextBox intownershipbalance = rptBuilding.Items[i].FindControl("intownershipbalance") as TextBox;
            TextBox inttaxremissionbalance = rptBuilding.Items[i].FindControl("inttaxremissionbalance") as TextBox;

            TextBox intauditedpermitapp = rptBuilding.Items[i].FindControl("intauditedpermitapp") as TextBox;
            TextBox intauditednumberingapp = rptBuilding.Items[i].FindControl("intauditednumberingapp") as TextBox;
            TextBox intauditedregularisationapp = rptBuilding.Items[i].FindControl("intauditedregularisationapp") as TextBox;
            TextBox intauditedownershipapp = rptBuilding.Items[i].FindControl("intauditedownershipapp") as TextBox;

            TextBox intauditedtaxremissionapp = rptBuilding.Items[i].FindControl("intauditedtaxremissionapp") as TextBox;
            TextBox intauditedpermitcompleted = rptBuilding.Items[i].FindControl("intauditedpermitcompleted") as TextBox;
            TextBox intauditednumberingcompleted = rptBuilding.Items[i].FindControl("intauditednumberingcompleted") as TextBox;
            TextBox intauditedregularisationcompleted = rptBuilding.Items[i].FindControl("intauditedregularisationcompleted") as TextBox;

            TextBox intauditedownershipcompleted = rptBuilding.Items[i].FindControl("intauditedownershipcompleted") as TextBox;
            TextBox intauditedtaxremissioncompleted = rptBuilding.Items[i].FindControl("intauditedtaxremissioncompleted") as TextBox;
            TextBox intauditedpermitbalance = rptBuilding.Items[i].FindControl("intauditedpermitbalance") as TextBox;
            TextBox intauditednumberingbalance = rptBuilding.Items[i].FindControl("intauditednumberingbalance") as TextBox;

            TextBox intauditedregularisationbalance = rptBuilding.Items[i].FindControl("intauditedregularisationbalance") as TextBox;
            TextBox intauditedownershipbalance = rptBuilding.Items[i].FindControl("intauditedownershipbalance") as TextBox;
            TextBox intauditedtaxremissionbalance = rptBuilding.Items[i].FindControl("intauditedtaxremissionbalance") as TextBox;

            intauditedpermitapp.Text =intpermitapp.Text;
            intauditednumberingapp.Text =intnumberingapp.Text;

            intauditedregularisationapp.Text =intregularisationapp.Text;
            intauditedownershipapp.Text =intownershipapp.Text;



            intauditedtaxremissionapp.Text =inttaxremissionapp.Text;
            intauditedpermitcompleted.Text =intpermitcompleted.Text;

            intauditednumberingcompleted.Text =intnumberingcompleted.Text;
            intauditedregularisationcompleted.Text =intregularisationcompleted.Text;

            intauditedownershipcompleted.Text =intownershipcompleted.Text;
            intauditedtaxremissioncompleted.Text =inttaxremissioncompleted.Text;
            intauditedpermitbalance.Text =intpermitbalance.Text;
            intauditednumberingbalance.Text =intnumberingbalance.Text;

            intauditedregularisationbalance.Text =intregularisationbalance.Text;
            intauditedownershipbalance.Text =intownershipbalance.Text;
            intauditedtaxremissionbalance.Text = inttaxremissionbalance.Text;

        }
       
    }
    public void SetEditableOcc()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptOccupancy.Items.Count; i++)
            {
                TextBox intoccupancyapplication = rptOccupancy.Items[i].FindControl("intoccupancyapplication") as TextBox;
                TextBox intoccupancycompleted = rptOccupancy.Items[i].FindControl("intoccupancycompleted") as TextBox;
                TextBox intoccupancybalance = rptOccupancy.Items[i].FindControl("intoccupancybalance") as TextBox;
                

                intoccupancyapplication.ReadOnly = false;
                intoccupancycompleted.ReadOnly = false;

                intoccupancybalance.ReadOnly = false;               
            }
        }
        else
        {
            for (int i = 0; i < rptOccupancy.Items.Count; i++)
            {
                TextBox intauditedoccupancyapplication = rptOccupancy.Items[i].FindControl("intauditedoccupancyapplication") as TextBox;
                TextBox intauditedoccupancycompleted = rptOccupancy.Items[i].FindControl("intauditedoccupancycompleted") as TextBox;
                TextBox intauditedoccupancybalance = rptOccupancy.Items[i].FindControl("intauditedoccupancybalance") as TextBox;
                
                intauditedoccupancyapplication.ReadOnly = false;
                intauditedoccupancycompleted.ReadOnly = false;

                intauditedoccupancybalance.ReadOnly = false;
            }
        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptBuilding.Items.Count; i++)
            {
                TextBox intpermitapp = rptBuilding.Items[i].FindControl("intpermitapp") as TextBox;
                TextBox intnumberingapp = rptBuilding.Items[i].FindControl("intnumberingapp") as TextBox;
                TextBox intregularisationapp = rptBuilding.Items[i].FindControl("intregularisationapp") as TextBox;
                TextBox intownershipapp = rptBuilding.Items[i].FindControl("intownershipapp") as TextBox;

                TextBox inttaxremissionapp = rptBuilding.Items[i].FindControl("inttaxremissionapp") as TextBox;
                TextBox intpermitcompleted = rptBuilding.Items[i].FindControl("intpermitcompleted") as TextBox;
                TextBox intnumberingcompleted = rptBuilding.Items[i].FindControl("intnumberingcompleted") as TextBox;
                TextBox intregularisationcompleted = rptBuilding.Items[i].FindControl("intregularisationcompleted") as TextBox;

                TextBox intownershipcompleted = rptBuilding.Items[i].FindControl("intownershipcompleted") as TextBox;
                TextBox inttaxremissioncompleted = rptBuilding.Items[i].FindControl("inttaxremissioncompleted") as TextBox;
                TextBox intpermitbalance = rptBuilding.Items[i].FindControl("intpermitbalance") as TextBox;
                TextBox intnumberingbalance = rptBuilding.Items[i].FindControl("intnumberingbalance") as TextBox;

                TextBox intregularisationbalance = rptBuilding.Items[i].FindControl("intregularisationbalance") as TextBox;
                TextBox intownershipbalance = rptBuilding.Items[i].FindControl("intownershipbalance") as TextBox;
                TextBox inttaxremissionbalance = rptBuilding.Items[i].FindControl("inttaxremissionbalance") as TextBox;

                intpermitapp.ReadOnly = false;
                intnumberingapp.ReadOnly = false;

                intregularisationapp.ReadOnly = false;
                intownershipapp.ReadOnly = false;



                inttaxremissionapp.ReadOnly = false;
                intpermitcompleted.ReadOnly = false;

                intnumberingcompleted.ReadOnly = false;
                intregularisationcompleted.ReadOnly = false;

                intownershipcompleted.ReadOnly = false;
                inttaxremissioncompleted.ReadOnly = false;
                intpermitbalance.ReadOnly = false;
                intnumberingbalance.ReadOnly = false;

                intregularisationbalance.ReadOnly = false;
                intownershipbalance.ReadOnly = false;
                inttaxremissionbalance.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < rptBuilding.Items.Count; i++)
            {

                TextBox intauditedpermitapp = rptBuilding.Items[i].FindControl("intauditedpermitapp") as TextBox;
                TextBox intauditednumberingapp = rptBuilding.Items[i].FindControl("intauditednumberingapp") as TextBox;
                TextBox intauditedregularisationapp = rptBuilding.Items[i].FindControl("intauditedregularisationapp") as TextBox;
                TextBox intauditedownershipapp = rptBuilding.Items[i].FindControl("intauditedownershipapp") as TextBox;

                TextBox intauditedtaxremissionapp = rptBuilding.Items[i].FindControl("intauditedtaxremissionapp") as TextBox;
                TextBox intauditedpermitcompleted = rptBuilding.Items[i].FindControl("intauditedpermitcompleted") as TextBox;
                TextBox intauditednumberingcompleted = rptBuilding.Items[i].FindControl("intauditednumberingcompleted") as TextBox;
                TextBox intauditedregularisationcompleted = rptBuilding.Items[i].FindControl("intauditedregularisationcompleted") as TextBox;

                TextBox intauditedownershipcompleted = rptBuilding.Items[i].FindControl("intauditedownershipcompleted") as TextBox;
                TextBox intauditedtaxremissioncompleted = rptBuilding.Items[i].FindControl("intauditedtaxremissioncompleted") as TextBox;
                TextBox intauditedpermitbalance = rptBuilding.Items[i].FindControl("intauditedpermitbalance") as TextBox;
                TextBox intauditednumberingbalance = rptBuilding.Items[i].FindControl("intauditednumberingbalance") as TextBox;

                TextBox intauditedregularisationbalance = rptBuilding.Items[i].FindControl("intauditedregularisationbalance") as TextBox;
                TextBox intauditedownershipbalance = rptBuilding.Items[i].FindControl("intauditedownershipbalance") as TextBox;
                TextBox intauditedtaxremissionbalance = rptBuilding.Items[i].FindControl("intauditedtaxremissionbalance") as TextBox;

                intauditedpermitapp.ReadOnly = false;
                intauditednumberingapp.ReadOnly = false;

                intauditedregularisationapp.ReadOnly = false;
                intauditedownershipapp.ReadOnly = false;



                intauditedtaxremissionapp.ReadOnly = false;
                intauditedpermitcompleted.ReadOnly = false;

                intauditednumberingcompleted.ReadOnly = false;
                intauditedregularisationcompleted.ReadOnly = false;

                intauditedownershipcompleted.ReadOnly = false;
                intauditedtaxremissioncompleted.ReadOnly = false;
                intauditedpermitbalance.ReadOnly = false;
                intauditednumberingbalance.ReadOnly = false;

                intauditedregularisationbalance.ReadOnly = false;
                intauditedownershipbalance.ReadOnly = false;
                intauditedtaxremissionbalance.ReadOnly = false;

            }
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_buildingdetails_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptBuilding.DataSource = dsFill;
            rptBuilding.DataBind();

            rptOccupancy.DataSource = dsFill;
            rptOccupancy.DataBind();


        }
        else
        {
            SetBuildingInitialRow();
            SetOccupancyInitialRow();
        }
        SetEditableOcc();
        SetEditable();
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
        //for (int i = 0; i < rptBuilding.Items.Count; i++)
        //{
        int i = 0;
        Label lblNumId = rptBuilding.Items[i].FindControl("numid") as Label;
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

            TextBox intpermitapp = rptBuilding.Items[i].FindControl("intpermitapp") as TextBox;
            if (intpermitapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intpermitapp.Text));
            }

            TextBox intnumberingapp = rptBuilding.Items[i].FindControl("intnumberingapp") as TextBox;
            if (intnumberingapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intnumberingapp.Text));
            }

            TextBox intregularisationapp = rptBuilding.Items[i].FindControl("intregularisationapp") as TextBox;
            if (intregularisationapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intregularisationapp.Text));
            }

            TextBox intownershipapp = rptBuilding.Items[i].FindControl("intownershipapp") as TextBox;
            if (intownershipapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intownershipapp.Text));
            }

            TextBox inttaxremissionapp = rptBuilding.Items[i].FindControl("inttaxremissionapp") as TextBox;
            if (inttaxremissionapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(inttaxremissionapp.Text));
            }

            TextBox intpermitcompleted = rptBuilding.Items[i].FindControl("intpermitcompleted") as TextBox;
            if (intpermitcompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intpermitcompleted.Text));
            }

            TextBox intnumberingcompleted = rptBuilding.Items[i].FindControl("intnumberingcompleted") as TextBox;
            if (intnumberingcompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intnumberingcompleted.Text));
            }

            TextBox intregularisationcompleted = rptBuilding.Items[i].FindControl("intregularisationcompleted") as TextBox;
            if (intregularisationcompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intregularisationcompleted.Text));
            }

            TextBox intownershipcompleted = rptBuilding.Items[i].FindControl("intownershipcompleted") as TextBox;
            if (intownershipcompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intownershipcompleted.Text));
            }

            TextBox inttaxremissioncompleted = rptBuilding.Items[i].FindControl("inttaxremissioncompleted") as TextBox;
            if (inttaxremissioncompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(inttaxremissioncompleted.Text));
            }

            TextBox intpermitbalance = rptBuilding.Items[i].FindControl("intpermitbalance") as TextBox;
            if (intpermitbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intpermitbalance.Text));
            }

            TextBox intnumberingbalance = rptBuilding.Items[i].FindControl("intnumberingbalance") as TextBox;
            if (intnumberingbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intnumberingbalance.Text));
            }

            TextBox intregularisationbalance = rptBuilding.Items[i].FindControl("intregularisationbalance") as TextBox;
            if (intregularisationbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intregularisationbalance.Text));
            }

            TextBox intownershipbalance = rptBuilding.Items[i].FindControl("intownershipbalance") as TextBox;
            if (intownershipbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intownershipbalance.Text));
            }

            TextBox inttaxremissionbalance = rptBuilding.Items[i].FindControl("inttaxremissionbalance") as TextBox;
            if (inttaxremissionbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(inttaxremissionbalance.Text));
            }








            TextBox intauditedpermitapp = rptBuilding.Items[i].FindControl("intauditedpermitapp") as TextBox;
            if (intauditedpermitapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedpermitapp.Text));
            }

            TextBox intauditednumberingapp = rptBuilding.Items[i].FindControl("intauditednumberingapp") as TextBox;
            if (intauditednumberingapp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditednumberingapp.Text));
            }

            TextBox intauditedregularisationapp = rptBuilding.Items[i].FindControl("intauditedregularisationapp") as TextBox;
            if (intauditedregularisationapp.Text == "")
            {

               // arrIn.Add(Convert.ToInt32(intregularisationapp.Text));
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedregularisationapp.Text));
            }

            TextBox intauditedownershipapp = rptBuilding.Items[i].FindControl("intauditedownershipapp") as TextBox;
            if (intauditedownershipapp.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intownershipapp.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedownershipapp.Text));
            }

            TextBox intauditedtaxremissionapp = rptBuilding.Items[i].FindControl("intauditedtaxremissionapp") as TextBox;
            if (intauditedtaxremissionapp.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(inttaxremissionapp.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedtaxremissionapp.Text));
            }

            TextBox intauditedpermitcompleted = rptBuilding.Items[i].FindControl("intauditedpermitcompleted") as TextBox;
            if (intauditedpermitcompleted.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intpermitcompleted.Text));
            }
            else
            {
               // arrIn.Add(DBNull.Value);
                arrIn.Add(Convert.ToInt32(intauditedpermitcompleted.Text));
            }

            TextBox intauditednumberingcompleted = rptBuilding.Items[i].FindControl("intauditednumberingcompleted") as TextBox;
            if (intauditednumberingcompleted.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intnumberingcompleted.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditednumberingcompleted.Text));
            }

            TextBox intauditedregularisationcompleted = rptBuilding.Items[i].FindControl("intauditedregularisationcompleted") as TextBox;
            if (intauditedregularisationcompleted.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intregularisationcompleted.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedregularisationcompleted.Text));
            }

            TextBox intauditedownershipcompleted = rptBuilding.Items[i].FindControl("intauditedownershipcompleted") as TextBox;
            if (intauditedownershipcompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);// arrIn.Add(Convert.ToInt32(intownershipcompleted.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedownershipcompleted.Text));
            }

            TextBox intauditedtaxremissioncompleted = rptBuilding.Items[i].FindControl("intauditedtaxremissioncompleted") as TextBox;
            if (intauditedtaxremissioncompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);// arrIn.Add(Convert.ToInt32(inttaxremissioncompleted.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedtaxremissioncompleted.Text));
            }

            TextBox intauditedpermitbalance = rptBuilding.Items[i].FindControl("intauditedpermitbalance") as TextBox;
            if (intauditedpermitbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intpermitbalance.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedpermitbalance.Text));
            }

            TextBox intauditednumberingbalance = rptBuilding.Items[i].FindControl("intauditednumberingbalance") as TextBox;
            if (intauditednumberingbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intnumberingbalance.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditednumberingbalance.Text));
            }

            TextBox intauditedregularisationbalance = rptBuilding.Items[i].FindControl("intauditedregularisationbalance") as TextBox;
            if (intauditedregularisationbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intregularisationbalance.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedregularisationbalance.Text));
            }


            TextBox intauditedownershipbalance = rptBuilding.Items[i].FindControl("intauditedownershipbalance") as TextBox;
            if (intauditedownershipbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(intownershipbalance.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedownershipbalance.Text));
            }

            TextBox intauditedtaxremissionbalance = rptBuilding.Items[i].FindControl("intauditedtaxremissionbalance") as TextBox;
            if (intauditedtaxremissionbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
                //arrIn.Add(Convert.ToInt32(inttaxremissionbalance.Text));
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedtaxremissionbalance.Text));
            }


            TextBox intoccupancyapplication = rptOccupancy.Items[i].FindControl("intoccupancyapplication") as TextBox;
            if (intoccupancyapplication.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intoccupancyapplication.Text));
            }

            TextBox intoccupancycompleted = rptOccupancy.Items[i].FindControl("intoccupancycompleted") as TextBox;
            if (intoccupancycompleted.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intoccupancycompleted.Text));
            }

            TextBox intoccupancybalance = rptOccupancy.Items[i].FindControl("intoccupancybalance") as TextBox;
            if (intoccupancybalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intoccupancybalance.Text));
            }

            TextBox intauditedoccupancyapplication = rptOccupancy.Items[i].FindControl("intauditedoccupancyapplication") as TextBox;
            if (intauditedoccupancyapplication.Text == "")
            {
                //if (intoccupancyapplication.Text != "")
                //{

                //    arrIn.Add(Convert.ToInt32(intoccupancyapplication.Text));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedoccupancyapplication.Text));
            }

            TextBox intauditedoccupancycompleted = rptOccupancy.Items[i].FindControl("intauditedoccupancycompleted") as TextBox;
            if (intauditedoccupancycompleted.Text == "")
            {
                //if (intoccupancycompleted.Text != "")
                //{

                //    arrIn.Add(Convert.ToInt32(intoccupancycompleted.Text));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedoccupancycompleted.Text));
            }

            TextBox intauditedoccupancybalance = rptOccupancy.Items[i].FindControl("intauditedoccupancybalance") as TextBox;
            if (intauditedoccupancybalance.Text == "")
            {
                //if (intoccupancybalance.Text != "")
                //{

                //    arrIn.Add(Convert.ToInt32(intoccupancybalance.Text));
                //}
                //else
                //{
                //    arrIn.Add(DBNull.Value);
                //}
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intauditedoccupancybalance.Text));
            }

            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int row = objcomm.update("SP_tb_buildingdetails_IU", arrIn);
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }

       
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PensionDetails.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("MNREGSRegistration.aspx");
    }
}
