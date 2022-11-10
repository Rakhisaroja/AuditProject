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

public partial class Pages_Remarks : System.Web.UI.Page
{
    GlobalClass clsObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcombos();
        }
    }
    public void fillcombos()
    {
        DataSet ds = new DataSet();

        if ((Convert.ToString(Session["LBType"]) =="5")||(Convert.ToString(Session["LBType"]) =="1")||(Convert.ToString(Session["LBType"]) =="2"))
        {

            ds = clsObj.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=0 and intParentMenuId=0 and intMenuId in (1,2,3,15,16,17,18,19,20)", CommandType.Text);
        }
        else if ((Convert.ToString(Session["LBType"]) =="3")||(Convert.ToString(Session["LBType"]) =="4"))
        {
            ds = clsObj.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=0 and intParentMenuId=0 and intMenuId in (1,2,3,16,17,18,19,20,90,86,79)", CommandType.Text);

        }
            
            
            clsObj.FillCombo(drmainHeading, ds, 1);
        
    }
    protected void drmainHeading_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        if (Convert.ToString(Session["LBType"]) == "5")
        {

            ds = clsObj.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=1 and     (chvOnClick IS NOT NULL)  and intParentMenuId=" + drmainHeading.SelectedValue.ToString(), CommandType.Text);

        }
        else
        {

            ds = clsObj.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=1  and     (chvOnClickUrban IS NOT NULL) and intParentMenuId=" + drmainHeading.SelectedValue.ToString(), CommandType.Text);


        }


            
            
            clsObj.FillCombo(drsubHeading, ds, 1);
        fillRemarks();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateSave() == true)
        {
            
            
            lblErr.Text="";

            ArrayList arr = new ArrayList();
            arr.Add(Session["LBID"].ToString());
            arr.Add(Session["Year"].ToString());
            arr.Add(drmainHeading.SelectedValue);
            arr.Add(drsubHeading.SelectedValue.ToString());
            arr.Add(txtRemarks.Text.Trim());
            arr.Add(Session["UserID"]);
            clsObj.Fetch("SP_Remarks_IU", CommandType.StoredProcedure, arr);
            drmainHeading.SelectedValue = "0";
            drsubHeading.SelectedValue = "0";
            txtRemarks.Text = "";
            GlobalClass gblObj = new GlobalClass();
            gblObj.MsgBoxOk("Saved Successfully ", this);
        }
    }
    public bool ValidateSave()
    {
        bool outval = true;
        if (drmainHeading.SelectedValue == "0")
        {
            lblErr.Text = "Select Main Heading";
            outval = false;
        }
        else if (drsubHeading.SelectedValue == "0" && drsubHeading.Items.Count > 1)
        {
                lblErr.Text = "Select Sub Heading";
                outval = false;
        }
        else if (txtRemarks.Text.Trim() == "")
        {
            lblErr.Text = "Enter Remarks";
            outval = false;
        }
        return outval;
    }
    public void fillRemarks()
    {
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            arr.Add(Session["LBID"].ToString());
            arr.Add(Session["Year"].ToString());
            arr.Add(drmainHeading.SelectedValue);
            arr.Add(drsubHeading.SelectedValue.ToString());
            ds = clsObj.Fetch("SP_Remarks_S", CommandType.StoredProcedure, arr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drmainHeading.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
                drsubHeading.SelectedValue = ds.Tables[0].Rows[0][1].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                txtRemarks.Text = "";
            }
    }
    protected void drsubHeading_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillRemarks();
    }
}
