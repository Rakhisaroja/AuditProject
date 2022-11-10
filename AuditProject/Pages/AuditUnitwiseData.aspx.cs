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
public partial class Pages_AuditUnitwiseData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillLB();
        }
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
