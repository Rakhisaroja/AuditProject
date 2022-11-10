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
public partial class Pages_PowerStreetLightExp_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {



            chkStatus();
            Fill8D();
        }


    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                Button2.Enabled = false;
            }
            else
            {

                Button2.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button2.Enabled = true;
            }
            else
            {
                Button2.Enabled = false;
            }
        }


    }
    public void ValueAssign()
    {


        for (int i = 0; i < Rpt8D.Items.Count; i++)
        {
            TextBox numamount = Rpt8D.Items[i].FindControl("numamount") as TextBox;
            TextBox numaudamount = Rpt8D.Items[i].FindControl("numaudamount") as TextBox;

            numaudamount.Text = numamount.Text;
        }
    }



    public void SetEditable8D()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < Rpt8D.Items.Count; i++)
            {
                TextBox numamount = Rpt8D.Items[i].FindControl("numamount") as TextBox;


                numamount.ReadOnly = false;


            }
        }
        else
        {
            for (int i = 0; i < Rpt8D.Items.Count; i++)
            {
                TextBox numaudamount = Rpt8D.Items[i].FindControl("numaudamount") as TextBox;

                numaudamount.ReadOnly = false;

            }
        }

    }




    public void SetStreetlightExpInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");

        arr.Add("chvmonthmal");
        arr.Add("intmonthid");
        arr.Add("numamount");
        arr.Add("numaudamount");
        gblObj.SetRepeaterDefault(Rpt8D, arr);

    }
  
    public void Fill8D()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]

        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_streetlightexpenditure_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            Rpt8D.DataSource = dsFill;
            Rpt8D.DataBind();
        }
        else
        {
            SetStreetlightExpInitialRow();
        }
        SetEditable8D();
    }


   

   


    protected void BtnStreetLightExp_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveStreetLightExp();
        Fill8D();
    }
    public void SaveStreetLightExp()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < Rpt8D.Items.Count; i++)
        {
            Label lblNumId = Rpt8D.Items[i].FindControl("numid") as Label;
            if (lblNumId.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblNumId.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]


            Label intmonthid = Rpt8D.Items[i].FindControl("intmonthid") as Label;
            if (intmonthid.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intmonthid.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
            TextBox numamount = Rpt8D.Items[i].FindControl("numamount") as TextBox;
            if (numamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numamount.Text));
            }

            TextBox numaudamount = Rpt8D.Items[i].FindControl("numaudamount") as TextBox;
            if (numaudamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numaudamount.Text));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_streetlightexpenditure_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PowerStreetLightMtering_Urban.aspx");
    }
  
}
