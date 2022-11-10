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
public partial class Pages_NegativeIncomeDetails_Urban : System.Web.UI.Page
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
        arr.Add("vchaccounthead");
        arr.Add("vchaccountheadcode");
        arr.Add("numob");

        arr.Add("numincome");
        arr.Add("numrepayment");


        arr.Add("numforfiet");
        arr.Add("numbalance");
        arr.Add("numauditedob");
        arr.Add("numauditedincome");
        arr.Add("numauditedrepayment");


        arr.Add("numauditedforfiet");
        arr.Add("numauditedbalance");

        gblObj.SetRepeaterDefault(rptNegative, arr);
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptNegative.Items.Count; i++)
        {
            TextBox numob = rptNegative.Items[i].FindControl("numob") as TextBox;
            TextBox numincome = rptNegative.Items[i].FindControl("numincome") as TextBox;
            TextBox numrepayment = rptNegative.Items[i].FindControl("numrepayment") as TextBox;
            TextBox numforfiet = rptNegative.Items[i].FindControl("numforfiet") as TextBox;
            TextBox numbalance = rptNegative.Items[i].FindControl("numbalance") as TextBox;


            TextBox numauditedob = rptNegative.Items[i].FindControl("numauditedob") as TextBox;
            TextBox numauditedincome = rptNegative.Items[i].FindControl("numauditedincome") as TextBox;
            TextBox numauditedrepayment = rptNegative.Items[i].FindControl("numauditedrepayment") as TextBox;
            TextBox numauditedforfiet = rptNegative.Items[i].FindControl("numauditedforfiet") as TextBox;
            TextBox numauditedbalance = rptNegative.Items[i].FindControl("numauditedbalance") as TextBox;



            numauditedob.Text = numob.Text;
            numauditedincome.Text = numincome.Text;
            numauditedrepayment.Text = numrepayment.Text;
            numauditedforfiet.Text = numforfiet.Text;
            numauditedbalance.Text = numbalance.Text;
        }



    }

    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptNegative.Items.Count; i++)
            {
                TextBox numob = rptNegative.Items[i].FindControl("numob") as TextBox;
                TextBox numincome = rptNegative.Items[i].FindControl("numincome") as TextBox;
                TextBox numrepayment = rptNegative.Items[i].FindControl("numrepayment") as TextBox;
                TextBox numforfiet = rptNegative.Items[i].FindControl("numforfiet") as TextBox;
                TextBox numbalance = rptNegative.Items[i].FindControl("numbalance") as TextBox;


                numob.ReadOnly = false;
                numincome.ReadOnly = false;
                numrepayment.ReadOnly = false;
                numforfiet.ReadOnly = false;
                numbalance.ReadOnly = false;
            }
        }
        else
        {
            for (int i = 0; i < rptNegative.Items.Count; i++)
            {
                TextBox numauditedob = rptNegative.Items[i].FindControl("numauditedob") as TextBox;
                TextBox numauditedincome = rptNegative.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox numauditedrepayment = rptNegative.Items[i].FindControl("numauditedrepayment") as TextBox;
                TextBox numauditedforfiet = rptNegative.Items[i].FindControl("numauditedforfiet") as TextBox;
                TextBox numauditedbalance = rptNegative.Items[i].FindControl("numauditedbalance") as TextBox;


                numauditedob.ReadOnly = false;
                numauditedincome.ReadOnly = false;
                numauditedrepayment.ReadOnly = false;
                numauditedforfiet.ReadOnly = false;
                numauditedbalance.ReadOnly = false;

            }
        }

    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_negativeincome_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptNegative.DataSource = dsFill;
            rptNegative.DataBind();

            Control FooterTemplate = rptNegative.Controls[rptNegative.Controls.Count - 1].Controls[0];


                


            Label totnumob = FooterTemplate.FindControl("totnumob") as Label;
            totnumob.Text = dsFill.Tables[0].Rows[0][20].ToString();

            Label totnumincome = FooterTemplate.FindControl("totnumincome") as Label;
            totnumincome.Text = dsFill.Tables[0].Rows[0][21].ToString();

            Label totnumrepayment = FooterTemplate.FindControl("totnumrepayment") as Label;
            totnumrepayment.Text = dsFill.Tables[0].Rows[0][22].ToString();

            Label totnumforfiet = FooterTemplate.FindControl("totnumforfiet") as Label;
            totnumforfiet.Text = dsFill.Tables[0].Rows[0][23].ToString();

            Label totnumnumbalance = FooterTemplate.FindControl("totnumnumbalance") as Label;
            totnumnumbalance.Text = dsFill.Tables[0].Rows[0][24].ToString();



            Label totnumauditedob = FooterTemplate.FindControl("totnumauditedob") as Label;
            totnumauditedob.Text = dsFill.Tables[0].Rows[0][25].ToString();

            Label totnumauditedincome = FooterTemplate.FindControl("totnumauditedincome") as Label;
            totnumauditedincome.Text = dsFill.Tables[0].Rows[0][26].ToString();

            Label totnumauditedrepayment = FooterTemplate.FindControl("totnumauditedrepayment") as Label;
            totnumauditedrepayment.Text = dsFill.Tables[0].Rows[0][27].ToString();

              Label totnumauditedforfiet = FooterTemplate.FindControl("totnumauditedforfiet") as Label;
            totnumauditedforfiet.Text = dsFill.Tables[0].Rows[0][28].ToString();


              Label totnumauditedbalance = FooterTemplate.FindControl("totnumauditedbalance") as Label;
            totnumauditedbalance.Text = dsFill.Tables[0].Rows[0][29].ToString();



        }
        else
        {
            SetInitialRow();
        }
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
        for (int i = 0; i < rptNegative.Items.Count; i++)
        {
            Label lblNumId = rptNegative.Items[i].FindControl("lblNumId") as Label;
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
           
            arrIn.Add(i);
            //Label lblincometype = rptNegative.Items[i].FindControl("lblincometype") as Label;
            //if (lblincometype.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToInt32(lblincometype.Text));
            //}
            Label vchaccountheadcode = rptNegative.Items[i].FindControl("vchaccountheadcode") as Label;
            if (vchaccountheadcode.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt64(vchaccountheadcode.Text));
            }

            Label lblccounthead = rptNegative.Items[i].FindControl("lblccounthead") as Label;
            if (lblccounthead.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(lblccounthead.Text);
            }
            arrIn.Add(1);

            

            

            TextBox numob = rptNegative.Items[i].FindControl("numob") as TextBox;
            if (numob.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numob.Text));
            }

            TextBox numincome = rptNegative.Items[i].FindControl("numincome") as TextBox;
            if (numincome.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numincome.Text));
            }

            TextBox numrepayment = rptNegative.Items[i].FindControl("numrepayment") as TextBox;
            if (numrepayment.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numrepayment.Text));
            }

            TextBox numforfiet = rptNegative.Items[i].FindControl("numforfiet") as TextBox;
            if (numforfiet.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numforfiet.Text));
            }

            TextBox numbalance = rptNegative.Items[i].FindControl("numbalance") as TextBox;
            if (numbalance.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numbalance.Text));
            }

            TextBox numauditedob = rptNegative.Items[i].FindControl("numauditedob") as TextBox;
            if (numauditedob.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedob.Text));
            }

            TextBox numauditedincome = rptNegative.Items[i].FindControl("numauditedincome") as TextBox;
            if (numauditedincome.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedincome.Text));
            }

            TextBox numauditedrepayment = rptNegative.Items[i].FindControl("numauditedrepayment") as TextBox;
            if (numauditedrepayment.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedrepayment.Text));
            }

            TextBox numauditedforfiet = rptNegative.Items[i].FindControl("numauditedforfiet") as TextBox;
            if (numauditedforfiet.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedforfiet.Text));
            }

            TextBox numauditedbalance = rptNegative.Items[i].FindControl("numauditedbalance") as TextBox;
            if (numauditedbalance.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedbalance.Text));
            }

            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int row = objcomm.update("SP_tb_negativeincome_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
    }
}
