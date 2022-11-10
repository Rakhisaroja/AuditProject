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
public partial class Pages_Crematorium : System.Web.UI.Page
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
    public void ValueAssign()
    {
        intcrematoriumexistsaudited.Text = intcrematoriumexists.Text;
        intcrematoriumnewaudited.Text =intcrematoriumnew.Text;
        numamountaudited.Text = numamount.Text;
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            intcrematoriumexists.ReadOnly = false;
            intcrematoriumnew.ReadOnly = false;
            numamount.ReadOnly = false;
        }
        else
        {

            intcrematoriumexistsaudited.ReadOnly = false;
            intcrematoriumnewaudited.ReadOnly = false;
            numamountaudited.ReadOnly = false;
        }
    }
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_crematorium_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            lblnum.Text = dsFill.Tables[0].Rows[0].ItemArray[1].ToString();
            intcrematoriumexists.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
            intcrematoriumnew.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
            numamount.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();

            intcrematoriumexistsaudited.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();
            intcrematoriumnewaudited.Text = dsFill.Tables[0].Rows[0].ItemArray[6].ToString();
            numamountaudited.Text = dsFill.Tables[0].Rows[0].ItemArray[7].ToString();

           
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

        if (lblnum.Text != "")
        {
            arrIn.Add(lblnum.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
      
        if (intcrematoriumexists.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intcrematoriumexists.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (intcrematoriumnew.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intcrematoriumnew.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (numamount.Text != "")
        {
            arrIn.Add(Convert.ToDouble(numamount.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (intcrematoriumexistsaudited.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intcrematoriumexistsaudited.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
           
        }
        if (intcrematoriumnewaudited.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intcrematoriumnewaudited.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
          
        }
        if (numamountaudited.Text != "")
        {
            arrIn.Add(Convert.ToDouble(numamountaudited.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        
        arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
        arrIn.Add(1);
        int row = objcomm.update("SP_tb_crematorium_IU", arrIn);
        if (row > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}
