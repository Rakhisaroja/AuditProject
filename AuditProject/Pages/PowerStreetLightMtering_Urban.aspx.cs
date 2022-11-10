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
public partial class Pages_PowerStreetLightMtering_Urban : System.Web.UI.Page
{
   CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            chkStatus();
            Filldata8A();

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

        for (int i = 0; i < Rpt8A.Items.Count; i++)
        {
            TextBox inttotalmeter = Rpt8A.Items[i].FindControl("inttotalmeter") as TextBox;
            TextBox numamountforstreetlight = Rpt8A.Items[i].FindControl("numamountforstreetlight") as TextBox;

            TextBox intaudtotalmeter = Rpt8A.Items[i].FindControl("intaudtotalmeter") as TextBox;
            TextBox numaudamountforstreetlight = Rpt8A.Items[i].FindControl("numaudamountforstreetlight") as TextBox;

            intaudtotalmeter.Text = inttotalmeter.Text;
            numaudamountforstreetlight.Text = numamountforstreetlight.Text;

        }
        for (int i = 0; i < RPT8B.Items.Count; i++)
        {
            TextBox intpurchasedcfl = RPT8B.Items[i].FindControl("intpurchasedcfl") as TextBox;
            TextBox intpurchasedled = RPT8B.Items[i].FindControl("intpurchasedled") as TextBox;

            TextBox intpurchasedtube = RPT8B.Items[i].FindControl("intpurchasedtube") as TextBox;
            TextBox intpurchasedothers = RPT8B.Items[i].FindControl("intpurchasedothers") as TextBox;

            TextBox intrelatedeqp = RPT8B.Items[i].FindControl("intrelatedeqp") as TextBox;
            TextBox numamount = RPT8B.Items[i].FindControl("numamount") as TextBox;

            TextBox intaudpurchasedcfl = RPT8B.Items[i].FindControl("intaudpurchasedcfl") as TextBox;
            TextBox intaudpurchasedled = RPT8B.Items[i].FindControl("intaudpurchasedled") as TextBox;

            TextBox intaudpurchasedtube = RPT8B.Items[i].FindControl("intaudpurchasedtube") as TextBox;
            TextBox intaudpurchasedothers = RPT8B.Items[i].FindControl("intaudpurchasedothers") as TextBox;

            TextBox intaudrelatedeqp = RPT8B.Items[i].FindControl("intaudrelatedeqp") as TextBox;
            TextBox numaudamount = RPT8B.Items[i].FindControl("numaudamount") as TextBox;


            intaudpurchasedcfl.Text = intpurchasedcfl.Text;
            intaudpurchasedled.Text = intpurchasedled.Text;

            intaudpurchasedtube.Text = intpurchasedtube.Text;
            intaudpurchasedothers.Text = intpurchasedothers.Text;


            intaudrelatedeqp.Text = intrelatedeqp.Text;
            numaudamount.Text = numamount.Text;

        }
      

        numaudamcplan.Text = numamcplan.Text;
        numaudamcnonplan.Text = numamcnonplan.Text;

        numaudcontractplan.Text = numcontractplan.Text;
        numaudcontractnonplan.Text = numcontractnonplan.Text;


        numaudksebplan.Text = numksebplan.Text;
        numaudksebnonplan.Text = numksebnonplan.Text;

        //}
       
    }
    protected void BtnStreetLightMeetering_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }
        SaveStreetLightMetering();
        Filldata8A();
    }
    public void SaveStreetLightMetering()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < Rpt8A.Items.Count; i++)
        {
            Label lblNumId = Rpt8A.Items[i].FindControl("lblNumId") as Label;
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

            TextBox inttotalmeter = Rpt8A.Items[i].FindControl("inttotalmeter") as TextBox;
            if (inttotalmeter.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(inttotalmeter.Text));
            }

            arrIn.Add(2);

            TextBox numamountforstreetlight = Rpt8A.Items[i].FindControl("numamountforstreetlight") as TextBox;
            if (numamountforstreetlight.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numamountforstreetlight.Text));
            }


            TextBox intaudtotalmeter = Rpt8A.Items[i].FindControl("intaudtotalmeter") as TextBox;
            if (intaudtotalmeter.Text == "")
            {
                arrIn.Add(DBNull.Value);


            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudtotalmeter.Text));
            }

            arrIn.Add(2);

            TextBox numaudamountforstreetlight = Rpt8A.Items[i].FindControl("numaudamountforstreetlight") as TextBox;
            if (numaudamountforstreetlight.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(numaudamountforstreetlight.Text));
            }


        }
        for (int i = 0; i < RPT8B.Items.Count; i++)
        {
            TextBox intpurchasedcfl = RPT8B.Items[i].FindControl("intpurchasedcfl") as TextBox;
            if (intpurchasedcfl.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intpurchasedcfl.Text));
            }
            TextBox intpurchasedled = RPT8B.Items[i].FindControl("intpurchasedled") as TextBox;
            if (intpurchasedled.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intpurchasedled.Text));
            }
            TextBox intpurchasedtube = RPT8B.Items[i].FindControl("intpurchasedtube") as TextBox;
            if (intpurchasedtube.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intpurchasedtube.Text));
            }
            TextBox intpurchasedothers = RPT8B.Items[i].FindControl("intpurchasedothers") as TextBox;
            if (intpurchasedothers.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intpurchasedothers.Text));
            }
            TextBox intrelatedeqp = RPT8B.Items[i].FindControl("intrelatedeqp") as TextBox;
            if (intrelatedeqp.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intrelatedeqp.Text));
            }
            TextBox numamount = RPT8B.Items[i].FindControl("numamount") as TextBox;
            if (numamount.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numamount.Text));
            }
            TextBox intaudpurchasedcfl = RPT8B.Items[i].FindControl("intaudpurchasedcfl") as TextBox;
            if (intaudpurchasedcfl.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudpurchasedcfl.Text));
            }
            TextBox intaudpurchasedled = RPT8B.Items[i].FindControl("intaudpurchasedled") as TextBox;
            if (intaudpurchasedled.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudpurchasedled.Text));
            }
            TextBox intaudpurchasedtube = RPT8B.Items[i].FindControl("intaudpurchasedtube") as TextBox;
            if (intaudpurchasedtube.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudpurchasedtube.Text));
            }
            TextBox intaudpurchasedothers = RPT8B.Items[i].FindControl("intaudpurchasedothers") as TextBox;
            if (intaudpurchasedothers.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudpurchasedothers.Text));
            }
            TextBox intaudrelatedeqp = RPT8B.Items[i].FindControl("intaudrelatedeqp") as TextBox;
            if (intaudrelatedeqp.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(intaudrelatedeqp.Text));
            }
            TextBox numaudamount = RPT8B.Items[i].FindControl("numaudamount") as TextBox;
            if (numaudamount.Text == "")
            {
                arrIn.Add(DBNull.Value);

            }
            else
            {
                arrIn.Add(Convert.ToDouble(numaudamount.Text));
            }
        }
        //for (int i = 0; i < RPT8C.Items.Count; i++)
        //{
        // TextBox numamcplan = RPT8C.Items[0].FindControl("numamcplan") as TextBox;
        if (numamcplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numamcplan.Text));
        }
        // TextBox numamcnonplan = RPT8C.Items[0].FindControl("numamcnonplan") as TextBox;
        if (numamcnonplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numamcnonplan.Text));
        }
        //  TextBox numaudamcplan = RPT8C.Items[0].FindControl("numaudamcplan") as TextBox;
        if (numaudamcplan.Text == "")
        {
            arrIn.Add(DBNull.Value);


        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudamcplan.Text));
        }
        //  TextBox numaudamcnonplan = RPT8C.Items[0].FindControl("numaudamcnonplan") as TextBox;
        if (numaudamcnonplan.Text == "")
        {
            arrIn.Add(DBNull.Value);

        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudamcnonplan.Text));
        }
        //  TextBox numcontractplan = RPT8C.Items[1].FindControl("numcontractplan") as TextBox;
        if (numcontractplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numcontractplan.Text));
        }
        // TextBox numcontractnonplan = RPT8C.Items[1].FindControl("numcontractnonplan") as TextBox;
        if (numcontractnonplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numcontractnonplan.Text));
        }
        //  TextBox numaudcontractplan = RPT8C.Items[1].FindControl("numaudcontractplan") as TextBox;
        if (numaudcontractplan.Text == "")
        {
            arrIn.Add(DBNull.Value);

        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudcontractplan.Text));
        }
        //  TextBox numaudcontractnonplan = RPT8C.Items[1].FindControl("numaudcontractnonplan") as TextBox;
        if (numaudcontractnonplan.Text == "")
        {
            arrIn.Add(DBNull.Value);

        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudcontractnonplan.Text));
        }
        //  TextBox numksebplan = RPT8C.Items[2].FindControl("numksebplan") as TextBox;
        if (numksebplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numksebplan.Text));
        }
        //  TextBox numksebnonplan = RPT8C.Items[2].FindControl("numksebnonplan") as TextBox;
        if (numksebnonplan.Text == "")
        {

            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numksebnonplan.Text));
        }
        //  TextBox numaudksebplan = RPT8C.Items[2].FindControl("numaudksebplan") as TextBox;
        if (numaudksebplan.Text == "")
        {
            arrIn.Add(DBNull.Value);
        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudksebplan.Text));
        }
        // TextBox numaudksebnonplan = RPT8C.Items[2].FindControl("numaudksebnonplan") as TextBox;
        if (numaudksebnonplan.Text == "")
        {
            arrIn.Add(DBNull.Value);

        }
        else
        {
            arrIn.Add(Convert.ToDouble(numaudksebnonplan.Text));
        }
        //}

        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
        arrIn.Add(1);
        int row = objcomm.update("SP_tb_streetlightmetering_IU", arrIn);
        arrIn.Clear();
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }

    public void Filldata8A()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

        DataSet dsFill = objcom.FillData("SP_tb_streetlightmetering_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            Rpt8A.DataSource = dsFill;
            Rpt8A.DataBind();
            RPT8B.DataSource = dsFill;
            RPT8B.DataBind();


            numamcplan.Text = dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
            numamcnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[14].ToString();

            numcontractplan.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
            numcontractnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[15].ToString();

            numksebplan.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();
            numksebnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[16].ToString();


            numaudamcplan.Text = dsFill.Tables[0].Rows[0].ItemArray[26].ToString();
            numaudamcnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[29].ToString();
            numaudcontractplan.Text = dsFill.Tables[0].Rows[0].ItemArray[27].ToString();
            numaudcontractnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[30].ToString();


            numaudksebplan.Text = dsFill.Tables[0].Rows[0].ItemArray[28].ToString();
            numaudksebnonplan.Text = dsFill.Tables[0].Rows[0].ItemArray[31].ToString();
        }




        else
        {
            SetStreetlightMeteringInitialRow();
            SetStreetlightMeteringInitialRow1();

        }
        SetEditable8A();
        SetEditable8B();
        SetEditable8C();

    }
    public void SetEditable8A()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < Rpt8A.Items.Count; i++)
            {
                TextBox inttotalmeter = Rpt8A.Items[i].FindControl("inttotalmeter") as TextBox;
                TextBox numamountforstreetlight = Rpt8A.Items[i].FindControl("numamountforstreetlight") as TextBox;

                inttotalmeter.ReadOnly = false;
                numamountforstreetlight.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < Rpt8A.Items.Count; i++)
            {
                TextBox intaudtotalmeter = Rpt8A.Items[i].FindControl("intaudtotalmeter") as TextBox;
                TextBox numaudamountforstreetlight = Rpt8A.Items[i].FindControl("numaudamountforstreetlight") as TextBox;

                intaudtotalmeter.ReadOnly = false;
                numaudamountforstreetlight.ReadOnly = false;
            }
        }

    }
    public void SetEditable8B()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < RPT8B.Items.Count; i++)
            {
                TextBox intpurchasedcfl = RPT8B.Items[i].FindControl("intpurchasedcfl") as TextBox;
                TextBox intpurchasedled = RPT8B.Items[i].FindControl("intpurchasedled") as TextBox;

                TextBox intpurchasedtube = RPT8B.Items[i].FindControl("intpurchasedtube") as TextBox;
                TextBox intpurchasedothers = RPT8B.Items[i].FindControl("intpurchasedothers") as TextBox;

                TextBox intrelatedeqp = RPT8B.Items[i].FindControl("intrelatedeqp") as TextBox;
                TextBox numamount = RPT8B.Items[i].FindControl("numamount") as TextBox;

                intpurchasedcfl.ReadOnly = false;
                intpurchasedled.ReadOnly = false;

                intpurchasedtube.ReadOnly = false;
                intpurchasedothers.ReadOnly = false;

                intrelatedeqp.ReadOnly = false;
                numamount.ReadOnly = false;

            }
        }
        else
        {
            for (int i = 0; i < RPT8B.Items.Count; i++)
            {
                TextBox intaudpurchasedcfl = RPT8B.Items[i].FindControl("intaudpurchasedcfl") as TextBox;
                TextBox intaudpurchasedled = RPT8B.Items[i].FindControl("intaudpurchasedled") as TextBox;

                TextBox intaudpurchasedtube = RPT8B.Items[i].FindControl("intaudpurchasedtube") as TextBox;
                TextBox intaudpurchasedothers = RPT8B.Items[i].FindControl("intaudpurchasedothers") as TextBox;

                TextBox intaudrelatedeqp = RPT8B.Items[i].FindControl("intaudrelatedeqp") as TextBox;
                TextBox numaudamount = RPT8B.Items[i].FindControl("numaudamount") as TextBox;


                intaudpurchasedcfl.ReadOnly = false;
                intaudpurchasedled.ReadOnly = false;

                intaudpurchasedtube.ReadOnly = false;
                intaudpurchasedothers.ReadOnly = false;


                intaudrelatedeqp.ReadOnly = false;
                numaudamount.ReadOnly = false;

            }
        }

    }

    public void SetEditable8C()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            //for (int i = 0; i < RPT8C.Items.Count; i++)
            //{
            //TextBox numamcplan = RPT8C.Items[0].FindControl("numamcplan") as TextBox;
            //TextBox numamcnonplan = RPT8C.Items[0].FindControl("numamcnonplan") as TextBox;

            //TextBox numcontractplan = RPT8C.Items[1].FindControl("numcontractplan") as TextBox;
            //TextBox numcontractnonplan = RPT8C.Items[1].FindControl("numcontractnonplan") as TextBox;

            //TextBox numksebplan = RPT8C.Items[2].FindControl("numksebplan") as TextBox;
            //TextBox numksebnonplan = RPT8C.Items[2].FindControl("numksebnonplan") as TextBox;

            numamcplan.ReadOnly = false;
            numamcnonplan.ReadOnly = false;

            numcontractplan.ReadOnly = false;
            numcontractnonplan.ReadOnly = false;

            numksebplan.ReadOnly = false;
            numksebnonplan.ReadOnly = false;

            //}
        }
        else
        {
            //for (int i = 0; i < RPT8C.Items.Count; i++)
            //{
            //TextBox numaudamcplan = RPT8C.Items[0].FindControl("numaudamcplan") as TextBox;
            //TextBox numaudamcnonplan = RPT8C.Items[0].FindControl("numaudamcnonplan") as TextBox;

            //TextBox numaudcontractplan = RPT8C.Items[1].FindControl("numaudcontractplan") as TextBox;
            //TextBox numaudcontractnonplan = RPT8C.Items[1].FindControl("numaudcontractnonplan") as TextBox;

            //TextBox numaudksebplan = RPT8C.Items[2].FindControl("numaudksebplan") as TextBox;
            //TextBox numaudksebnonplan = RPT8C.Items[2].FindControl("numaudksebnonplan") as TextBox;


            numaudamcplan.ReadOnly = false;
            numaudamcnonplan.ReadOnly = false;

            numaudcontractplan.ReadOnly = false;
            numaudcontractnonplan.ReadOnly = false;


            numaudksebplan.ReadOnly = false;
            numaudksebnonplan.ReadOnly = false;

            //}
        }

    }

    public void SetStreetlightMeteringInitialRow()
    {
        ArrayList arr3 = new ArrayList();
        arr3.Add("SLNO");
        arr3.Add("numid");

        arr3.Add("inttotalmeter");
        arr3.Add("numamountforstreetlight");
        arr3.Add("intaudtotalmeter");
        arr3.Add("numaudamountforstreetlight");
        gblObj.SetRepeaterDefault(Rpt8A, arr3);
    }
    public void SetStreetlightMeteringInitialRow1()
    {
        ArrayList arr1 = new ArrayList();
        arr1.Add("SLNO");
        arr1.Add("numid");
        arr1.Add("intpurchasedcfl");
        arr1.Add("intpurchasedled");
        arr1.Add("intpurchasedtube");
        arr1.Add("intpurchasedothers");
        arr1.Add("intrelatedeqp");
        arr1.Add("numamount");
        arr1.Add("intaudpurchasedcfl");
        arr1.Add("intaudpurchasedled");
        arr1.Add("intaudpurchasedtube");
        arr1.Add("intaudpurchasedothers");
        arr1.Add("intaudrelatedeqp");
        arr1.Add("numaudamount");
        gblObj.SetRepeaterDefault(RPT8B, arr1);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PowerStreetLightExp_Urban.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PowerStreetLight_Urban.aspx");
    }
}
