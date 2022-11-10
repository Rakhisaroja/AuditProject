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
public partial class Pages_MNREGSRegistration_Urban : System.Web.UI.Page
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
        arr.Add("intjobcardapplication");
        arr.Add("intjobcardissuedwithintimelimit");
        arr.Add("intjobcardissuedaftertimelimit");
        arr.Add("intjobcardissuedbalance");
        arr.Add("intjobcardapplicationaud");
        arr.Add("intjobcardissuedwithintimelimitaud");

        arr.Add("intjobcardissuedaftertimelimitaud");
        arr.Add("intjobcardissuedbalanceaud");

        gblObj.SetRepeaterDefault(rptMnregs, arr);
        SetEditablejob();
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptMnregs.Items.Count; i++)
        {
            TextBox intjobcardapplication = rptMnregs.Items[i].FindControl("intjobcardapplication") as TextBox;
            TextBox intjobcardissuedwithintimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimit") as TextBox;
            TextBox intjobcardissuedaftertimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimit") as TextBox;
            TextBox intjobcardissuedbalance = rptMnregs.Items[i].FindControl("intjobcardissuedbalance") as TextBox;


            TextBox intjobcardapplicationaud = rptMnregs.Items[i].FindControl("intjobcardapplicationaud") as TextBox;
            TextBox intjobcardissuedwithintimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimitaud") as TextBox;
            TextBox intjobcardissuedaftertimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimitaud") as TextBox;
            TextBox intjobcardissuedbalanceaud = rptMnregs.Items[i].FindControl("intjobcardissuedbalanceaud") as TextBox;

            intjobcardapplicationaud.Text = intjobcardapplication.Text;
            intjobcardissuedwithintimelimitaud.Text = intjobcardissuedwithintimelimit.Text;

            intjobcardissuedaftertimelimitaud.Text = intjobcardissuedaftertimelimit.Text;
            intjobcardissuedbalanceaud.Text = intjobcardissuedbalance.Text;
        }



    }
    public void SetEditablejob()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptMnregs.Items.Count; i++)
            {
                TextBox intjobcardapplication = rptMnregs.Items[i].FindControl("intjobcardapplication") as TextBox;
                TextBox intjobcardissuedwithintimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimit") as TextBox;
                TextBox intjobcardissuedaftertimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimit") as TextBox;
                TextBox intjobcardissuedbalance = rptMnregs.Items[i].FindControl("intjobcardissuedbalance") as TextBox;

                intjobcardapplication.ReadOnly = false;
                intjobcardissuedwithintimelimit.ReadOnly = false;

                intjobcardissuedaftertimelimit.ReadOnly = false;
                intjobcardissuedbalance.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < rptMnregs.Items.Count; i++)
            {

                TextBox intjobcardapplicationaud = rptMnregs.Items[i].FindControl("intjobcardapplicationaud") as TextBox;
                TextBox intjobcardissuedwithintimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimitaud") as TextBox;
                TextBox intjobcardissuedaftertimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimitaud") as TextBox;
                TextBox intjobcardissuedbalanceaud = rptMnregs.Items[i].FindControl("intjobcardissuedbalanceaud") as TextBox;

                intjobcardapplicationaud.ReadOnly = false;
                intjobcardissuedwithintimelimitaud.ReadOnly = false;

                intjobcardissuedaftertimelimitaud.ReadOnly = false;
                intjobcardissuedbalanceaud.ReadOnly = false;


            }
        }
    }
    void fillGrid()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_mnregsregistrationUrban_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptMnregs.DataSource = dsFill;
            rptMnregs.DataBind();
        }
        else
        {
            SetInitialRow();
        }
        SetEditablejob();
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
        for (int i = 0; i < rptMnregs.Items.Count; i++)
        {
            Label lblNumId = rptMnregs.Items[i].FindControl("lblNumId") as Label;
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

            TextBox intjobcardapplication = rptMnregs.Items[i].FindControl("intjobcardapplication") as TextBox;
            if (intjobcardapplication.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardapplication.Text));
            }
            TextBox intjobcardissuedwithintimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimit") as TextBox;
            if (intjobcardissuedwithintimelimit.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedwithintimelimit.Text));
            }
            TextBox intjobcardissuedaftertimelimit = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimit") as TextBox;
            if (intjobcardissuedaftertimelimit.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedaftertimelimit.Text));
            }
            TextBox intjobcardissuedbalance = rptMnregs.Items[i].FindControl("intjobcardissuedbalance") as TextBox;
            if (intjobcardissuedbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedbalance.Text));
            }


            TextBox intjobcardapplicationaud = rptMnregs.Items[i].FindControl("intjobcardapplicationaud") as TextBox;
            if (intjobcardapplicationaud.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardapplicationaud.Text));
            }
            TextBox intjobcardissuedwithintimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedwithintimelimitaud") as TextBox;
            if (intjobcardissuedwithintimelimitaud.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedwithintimelimitaud.Text));
            }
            TextBox intjobcardissuedaftertimelimitaud = rptMnregs.Items[i].FindControl("intjobcardissuedaftertimelimitaud") as TextBox;
            if (intjobcardissuedaftertimelimitaud.Text == "")
            {
                arrIn.Add(DBNull.Value);
              
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedaftertimelimitaud.Text));
            }
            TextBox intjobcardissuedbalanceaud = rptMnregs.Items[i].FindControl("intjobcardissuedbalanceaud") as TextBox;
            if (intjobcardissuedbalanceaud.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intjobcardissuedbalanceaud.Text));
            }

            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            row = objcomm.update("SP_tb_mnregsregistrationUrban_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BuildingDetails_Urban.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("LicenseDetails_Urban.aspx");
    }
}
