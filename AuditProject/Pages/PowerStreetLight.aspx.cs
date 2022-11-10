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
public partial class Pages_PowerStreetLight : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            Filldatastreetlight();           
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
        for (int i = 0; i < RptStreetLightDet.Items.Count; i++)
        {
            TextBox intincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intincanddescentexisting") as TextBox;
            TextBox intincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intincanddescentdismantled") as TextBox;
            TextBox intcflexisting = RptStreetLightDet.Items[i].FindControl("intcflexisting") as TextBox;
            TextBox intledexisting = RptStreetLightDet.Items[i].FindControl("intledexisting") as TextBox;
            TextBox intlednew = RptStreetLightDet.Items[i].FindControl("intlednew") as TextBox;

            TextBox intfluerescent = RptStreetLightDet.Items[i].FindControl("intfluerescent") as TextBox;

            TextBox intothers = RptStreetLightDet.Items[i].FindControl("intothers") as TextBox;

            TextBox intaudincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intaudincanddescentexisting") as TextBox;

            TextBox intaudincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intaudincanddescentdismantled") as TextBox;

            TextBox intadcflexisting = RptStreetLightDet.Items[i].FindControl("intadcflexisting") as TextBox;

            TextBox intaudledexisting = RptStreetLightDet.Items[i].FindControl("intaudledexisting") as TextBox;

            TextBox intaudlednew = RptStreetLightDet.Items[i].FindControl("intaudlednew") as TextBox;

            TextBox intaudfluerescent = RptStreetLightDet.Items[i].FindControl("intaudfluerescent") as TextBox;

            TextBox intaudothers = RptStreetLightDet.Items[i].FindControl("intaudothers") as TextBox;


            intaudincanddescentexisting.Text = intincanddescentexisting.Text;
            intaudincanddescentdismantled.Text = intincanddescentdismantled.Text;
            intadcflexisting.Text = intcflexisting.Text;
            intaudledexisting.Text = intledexisting.Text;
            intaudlednew.Text = intlednew.Text;
            intaudfluerescent.Text = intfluerescent.Text;
            intaudothers.Text = intothers.Text;
        }
    }

    public void SetEditableStreetLightDet()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < RptStreetLightDet.Items.Count; i++)
            {
                TextBox intincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intincanddescentexisting") as TextBox;
                TextBox intincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intincanddescentdismantled") as TextBox;
                TextBox intcflexisting = RptStreetLightDet.Items[i].FindControl("intcflexisting") as TextBox;
                TextBox intledexisting = RptStreetLightDet.Items[i].FindControl("intledexisting") as TextBox;
                TextBox intlednew = RptStreetLightDet.Items[i].FindControl("intlednew") as TextBox;

                TextBox intfluerescent = RptStreetLightDet.Items[i].FindControl("intfluerescent") as TextBox;

                TextBox intothers = RptStreetLightDet.Items[i].FindControl("intothers") as TextBox;




                intincanddescentexisting.ReadOnly = false;
                intincanddescentdismantled.ReadOnly = false;
                intcflexisting.ReadOnly = false;
                intledexisting.ReadOnly = false;
                intlednew.ReadOnly = false;

                intfluerescent.ReadOnly = false;
                intothers.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < RptStreetLightDet.Items.Count; i++)
            {
                TextBox intaudincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intaudincanddescentexisting") as TextBox;

                TextBox intaudincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intaudincanddescentdismantled") as TextBox;

                TextBox intadcflexisting = RptStreetLightDet.Items[i].FindControl("intadcflexisting") as TextBox;

                TextBox intaudledexisting = RptStreetLightDet.Items[i].FindControl("intaudledexisting") as TextBox;

                TextBox intaudlednew = RptStreetLightDet.Items[i].FindControl("intaudlednew") as TextBox;

                TextBox intaudfluerescent = RptStreetLightDet.Items[i].FindControl("intaudfluerescent") as TextBox;

                TextBox intaudothers = RptStreetLightDet.Items[i].FindControl("intaudothers") as TextBox;


                intaudincanddescentexisting.ReadOnly = false;
                intaudincanddescentdismantled.ReadOnly = false;
                intadcflexisting.ReadOnly = false;
                intaudledexisting.ReadOnly = false;
                intaudlednew.ReadOnly = false;
                intaudfluerescent.ReadOnly = false;
                intaudothers.ReadOnly = false;

            }
        }

    }
    public void SetStreetLightInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("chvWardMalName");
        arr.Add("intWardNo");

        arr.Add("intincanddescentexisting");
        arr.Add("intincanddescentdismantled");
        arr.Add("intcflexisting");
        arr.Add("intledexisting");
        arr.Add("intlednew");
        arr.Add("intfluerescent");
        arr.Add("intothers");

        arr.Add("intaudincanddescentexisting");
        arr.Add("intaudincanddescentdismantled");
        arr.Add("intadcflexisting");
        arr.Add("intaudledexisting");
        arr.Add("intaudlednew");
        arr.Add("intaudfluerescent");
        arr.Add("intaudothers");
        gblObj.SetRepeaterDefault(RptStreetLightDet, arr);
    }

    public void Filldatastreetlight()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]

        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("tb_streetlight_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            RptStreetLightDet.DataSource = dsFill;
            RptStreetLightDet.DataBind();
        }
        else
        {
            SetStreetLightInitialRow();
        }
        SetEditableStreetLightDet();
    }

    public void SaveStreetLight()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < RptStreetLightDet.Items.Count; i++)
        {
            Label lblNumId = RptStreetLightDet.Items[i].FindControl("lblNumId") as Label;
            if (lblNumId.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(lblNumId.Text));
            }
            arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]

            Label intWardNo = RptStreetLightDet.Items[i].FindControl("intWardNo") as Label;
            arrIn.Add(intWardNo.Text);
            arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
            TextBox intincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intincanddescentexisting") as TextBox;
            if (intincanddescentexisting.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intincanddescentexisting.Text));
            }

            TextBox intincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intincanddescentdismantled") as TextBox;
            if (intincanddescentdismantled.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intincanddescentdismantled.Text));
            }


            TextBox intcflexisting = RptStreetLightDet.Items[i].FindControl("intcflexisting") as TextBox;
            if (intcflexisting.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intcflexisting.Text));
            }

            TextBox intledexisting = RptStreetLightDet.Items[i].FindControl("intledexisting") as TextBox;
            if (intledexisting.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intledexisting.Text));
            }

            TextBox intlednew = RptStreetLightDet.Items[i].FindControl("intlednew") as TextBox;
            if (intlednew.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intlednew.Text));
            }

            TextBox intfluerescent = RptStreetLightDet.Items[i].FindControl("intfluerescent") as TextBox;
            if (intfluerescent.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intfluerescent.Text));
            }

            TextBox intothers = RptStreetLightDet.Items[i].FindControl("intothers") as TextBox;
            if (intothers.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intothers.Text));
            }

            TextBox intaudincanddescentexisting = RptStreetLightDet.Items[i].FindControl("intaudincanddescentexisting") as TextBox;
            if (intaudincanddescentexisting.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudincanddescentexisting.Text));
            }

            TextBox intaudincanddescentdismantled = RptStreetLightDet.Items[i].FindControl("intaudincanddescentdismantled") as TextBox;
            if (intaudincanddescentdismantled.Text == "")
            {

                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudincanddescentdismantled.Text));
            }

            TextBox intadcflexisting = RptStreetLightDet.Items[i].FindControl("intadcflexisting") as TextBox;
            if (intadcflexisting.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intadcflexisting.Text));
            }

            TextBox intaudledexisting = RptStreetLightDet.Items[i].FindControl("intaudledexisting") as TextBox;
            if (intaudledexisting.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudledexisting.Text));
            }

            TextBox intaudlednew = RptStreetLightDet.Items[i].FindControl("intaudlednew") as TextBox;
            if (intaudlednew.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudlednew.Text));
            }

            TextBox intaudfluerescent = RptStreetLightDet.Items[i].FindControl("intaudfluerescent") as TextBox;
            if (intaudfluerescent.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudfluerescent.Text));
            }

            TextBox intaudothers = RptStreetLightDet.Items[i].FindControl("intaudothers") as TextBox;
            if (intaudothers.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudothers.Text));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);

            int row = objcomm.update("SP_tb_streetlight_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
    }
    protected void BtnStreetlight_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveStreetLight();
        Filldatastreetlight();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PowerStreetLightMtering.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Power.aspx");
    }
}
