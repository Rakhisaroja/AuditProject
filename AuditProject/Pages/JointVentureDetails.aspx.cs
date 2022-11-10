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
public partial class Pages_JointVentureDetails : System.Web.UI.Page
{
    int row;
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkStatus();
            SetStreetLightInitialRow();
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
    public void SetStreetLightInitialRow()
    {
        ArrayList arr = new ArrayList();
        arr.Add("SLNO");
        arr.Add("numid");
        arr.Add("intagencylbtypeid");
        arr.Add("intagencylbid");
        arr.Add("chvlbType");
        arr.Add("numob");
        arr.Add("numincome");
        arr.Add("numexpenditure");
      
       
        arr.Add("numauditedob");
        arr.Add("numauditedincome");
        arr.Add("numauditedexpenditure");

        gblObj.SetRepeaterDefault(rptJoint, arr);
    }
    public void ValueAssign()
    {
        for (int i = 0; i < rptJoint.Items.Count; i++)
        {
            TextBox numob = rptJoint.Items[i].FindControl("numob") as TextBox;
            TextBox numincome = rptJoint.Items[i].FindControl("numincome") as TextBox;
            TextBox numexpenditure = rptJoint.Items[i].FindControl("numexpenditure") as TextBox;

            TextBox numauditedob = rptJoint.Items[i].FindControl("numauditedob") as TextBox;
            TextBox numauditedincome = rptJoint.Items[i].FindControl("numauditedincome") as TextBox;
            TextBox numauditedexpenditure = rptJoint.Items[i].FindControl("numauditedexpenditure") as TextBox;


            numauditedob.Text =numob.Text;
            numauditedincome.Text = numincome.Text;
            numauditedexpenditure.Text = numexpenditure.Text;
        }
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < rptJoint.Items.Count; i++)
            {
                TextBox numob = rptJoint.Items[i].FindControl("numob") as TextBox;
                TextBox numincome = rptJoint.Items[i].FindControl("numincome") as TextBox;
                TextBox numexpenditure = rptJoint.Items[i].FindControl("numexpenditure") as TextBox;


                numob.ReadOnly = false;
                numincome.ReadOnly = false;
                numexpenditure.ReadOnly = false;
            }
        }
        else
        {
            for (int i = 0; i < rptJoint.Items.Count; i++)
            {
                TextBox numauditedob = rptJoint.Items[i].FindControl("numauditedob") as TextBox;
                TextBox numauditedincome = rptJoint.Items[i].FindControl("numauditedincome") as TextBox;
                TextBox numauditedexpenditure = rptJoint.Items[i].FindControl("numauditedexpenditure") as TextBox;


                numauditedob.ReadOnly = false;
                numauditedincome.ReadOnly = false;
                numauditedexpenditure.ReadOnly = false;

            }
        }

    }
    void fillGrid()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("tb_jointventureexpenditure_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            rptJoint.DataSource = dsFill;
            rptJoint.DataBind();


            Control FooterTemplate = rptJoint.Controls[rptJoint.Controls.Count - 1].Controls[0];


                


            Label totnumob = FooterTemplate.FindControl("totnumob") as Label;
            totnumob.Text = dsFill.Tables[0].Rows[0][16].ToString();

            Label totnumincome = FooterTemplate.FindControl("totnumincome") as Label;
            totnumincome.Text = dsFill.Tables[0].Rows[0][17].ToString();

            Label totnumexpenditure = FooterTemplate.FindControl("totnumexpenditure") as Label;
            totnumexpenditure.Text = dsFill.Tables[0].Rows[0][18].ToString();

          



            Label totnumauditedob = FooterTemplate.FindControl("totnumauditedob") as Label;
            totnumauditedob.Text = dsFill.Tables[0].Rows[0][19].ToString();

            Label totnumauditedincome = FooterTemplate.FindControl("totnumauditedincome") as Label;
            totnumauditedincome.Text = dsFill.Tables[0].Rows[0][20].ToString();

            Label totnumauditedexpenditure = FooterTemplate.FindControl("totnumauditedexpenditure") as Label;
            totnumauditedexpenditure.Text = dsFill.Tables[0].Rows[0][21].ToString();

            
        }
        SetEditable();
    }
    public void SaveData()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        for (int i = 0; i < rptJoint.Items.Count; i++)
        {
            Label lblNumId = rptJoint.Items[i].FindControl("lblNumId") as Label;
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

            //Label lblincometype = rptNegative.Items[i].FindControl("lblincometype") as Label;
            //if (lblincometype.Text == "")
            //{

            //    arrIn.Add(DBNull.Value);
            //}
            //else
            //{
            //    arrIn.Add(Convert.ToInt32(lblincometype.Text));
            //}
            Label intagencylbtypeid = rptJoint.Items[i].FindControl("intagencylbtypeid") as Label;
            if (intagencylbtypeid.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intagencylbtypeid.Text));
            }

            Label intagencylbid = rptJoint.Items[i].FindControl("intagencylbid") as Label;
            if (intagencylbid.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(intagencylbid.Text));
            }
            





            TextBox numob = rptJoint.Items[i].FindControl("numob") as TextBox;
            if (numob.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numob.Text));
            }

            TextBox numincome = rptJoint.Items[i].FindControl("numincome") as TextBox;
            if (numincome.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numincome.Text));
            }

            TextBox numexpenditure = rptJoint.Items[i].FindControl("numexpenditure") as TextBox;
            if (numexpenditure.Text == "")
            {

                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numexpenditure.Text));
            }

            TextBox numauditedob = rptJoint.Items[i].FindControl("numauditedob") as TextBox;
            if (numauditedob.Text == "")
            {
                arrIn.Add(DBNull.Value);
               
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedob.Text));
            }

            TextBox numauditedincome = rptJoint.Items[i].FindControl("numauditedincome") as TextBox;
            if (numauditedincome.Text == "")
            {
                arrIn.Add(DBNull.Value);
              
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedincome.Text));
            }


            TextBox numauditedexpenditure = rptJoint.Items[i].FindControl("numauditedexpenditure") as TextBox;
            if (numauditedexpenditure.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToDouble(numauditedexpenditure.Text));
            }
            arrIn.Add(1);
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            row = objcomm.update("SP_tb_jointventureexpenditure_IU", arrIn);
            arrIn.Clear();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
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
}
