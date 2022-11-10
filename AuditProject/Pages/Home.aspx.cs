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
public partial class Pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["LBID"].ToString() != "" && Session["UserType"].ToString() == "79")
            {
                pnlViewEntry.Visible = false;
                pnlNewEntry.Visible = true;
                fillLB();
            }
            else if (Session["LBID"].ToString() != "" && Session["RoleID"].ToString() == "1")
            {
                pnlViewEntry.Visible = true;
                pnlNewEntry.Visible = true;
                chkAudit();
                fill();
                fillLB();
            }
            else
            {
                pnlViewEntry.Visible = false;
                pnlNewEntry.Visible = false;
            }

        }
    }
    public void chkAudit()
    {
        CommonClass objcom = new CommonClass();
        ArrayList arrin = new ArrayList();
        DataSet ds = new DataSet();
        arrin.Add(Session["unitID"]);
        ds = objcom.FillData("[SP_M_AuditLB_S]", arrin, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GlobalClass objgobl = new GlobalClass();
            objgobl.FillCombo(ddlLocalbody, ds, 1);

        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        fill();
        //Label mpLabel = (Label)Master.FindControl("lblLB");
        //if (mpLabel != null)
        //{
        //    Label1.Text = "Master page label = " + mpLabel.Text;
        //}
        // mpLabel.Text = "gdsgdsgdgfg";
        //ContentPlaceHolder plchldr= this.Master.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
        //   Label lbl = plchldr.FindControl("lblLB") as Label;
        //    if(lbl !=null)
        //    {
        //        lbl.Text = "SomeText";
        //    }
    }
    public void fill()
    {
        if (ddlLocalbody.SelectedIndex > 0)
        {
            int id = Convert.ToInt32(ddlLocalbody.SelectedValue);
            Session["LBID"] = id.ToString();
            Session["AuditLBName"] = ddlLocalbody.SelectedItem.ToString();
        }
    }
    protected void ddlLocalbody_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLocalbody.SelectedIndex > 0)
        {
            Session["AuditLBName"] = "";
            int id = Convert.ToInt32(ddlLocalbody.SelectedValue);
            Session["LBID"] = id.ToString();

            //New Mod
            ArrayList arrIn = new ArrayList();
            CommonClass objcom = new CommonClass();
            DataSet ds = new DataSet();
            arrIn.Add(Session["LBID"]);
            ds = objcom.FillData("[spselectlbtype]", arrIn, CommandType.StoredProcedure);
            if(ds.Tables[0].Rows.Count>0)
            {

                Session["LBType"] = ds.Tables[0].Rows[0][0].ToString();
            }

            
            Session["AuditLBName"] = ddlLocalbody.SelectedItem.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboad.aspx");
    }
    public void fillLB()
    {
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Session["unitID"]);
        arrIn.Add(Session["Year"]);
        ds = objcom.FillData("[SP_Dash_LB_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            pnlLBList.Visible = true;
            grdLBList.DataSource = ds;
            grdLBList.DataBind();
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            int count = ds.Tables[0].Rows.Count;
            int j = 0;
            for (int i = 0; i < grdLBList.Rows.Count; i++)
            {
                (grdLBList.Rows[i].FindControl("chkNotStartedStatus") as CheckBox).Checked = false;
                (grdLBList.Rows[i].FindControl("chkongoingStatus") as CheckBox).Checked = false;
                (grdLBList.Rows[i].FindControl("chkSubmitStatus") as CheckBox).Checked = false;
                (grdLBList.Rows[i].FindControl("chkReturnStatus") as CheckBox).Checked = false;
                (grdLBList.Rows[i].FindControl("chkApprovedStatus") as CheckBox).Checked = false;
                if (ds.Tables[0].Rows[j].ItemArray[0].ToString() == grdLBList.DataKeys[i].Values[0].ToString())
                {
                    if (ds.Tables[0].Rows[j].ItemArray[2].ToString() != "0")
                    {
                        CheckBox NotStarted = (CheckBox)grdLBList.Rows[i].FindControl("chkNotStartedStatus");
                        NotStarted.Checked = true;
                        NotStarted.BackColor = System.Drawing.Color.Red;
                    }
                    else if (ds.Tables[0].Rows[j].ItemArray[3].ToString() != "0")
                    {
                        CheckBox ongoing = (CheckBox)grdLBList.Rows[i].FindControl("chkongoingStatus");
                        ongoing.Checked = true;
                        ongoing.BackColor = System.Drawing.Color.Red;
                    }
                    else if (ds.Tables[0].Rows[j].ItemArray[4].ToString() != "0")
                    {
                        CheckBox Submit = (CheckBox)grdLBList.Rows[i].FindControl("chkSubmitStatus");
                        Submit.Checked = true;
                        Submit.BackColor = System.Drawing.Color.Red;
                    }
                    else if (ds.Tables[0].Rows[j].ItemArray[5].ToString() != "0")
                    {
                        CheckBox Return = (CheckBox)grdLBList.Rows[i].FindControl("chkReturnStatus");
                        Return.Checked = true;
                        Return.BackColor = System.Drawing.Color.Red;
                    }
                    else if (ds.Tables[0].Rows[j].ItemArray[6].ToString() != "0")
                    {
                        CheckBox Approved = (CheckBox)grdLBList.Rows[i].FindControl("chkApprovedStatus");
                        Approved.Checked = true;
                        Approved.BackColor = System.Drawing.Color.Red;
                    }
                    j++;
                }
            }
        }

    }
}