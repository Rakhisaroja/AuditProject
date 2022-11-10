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
public partial class Pages_OtherPriorityGrants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGrid();
        }
    }

    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_TB_MemberWardDetails_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvMemWard.DataSource = ds;
            grvMemWard.DataBind();
            DataSet dsn = new DataSet();
            dsn = objcom.FillData("[SP_m_direction_S]", CommandType.StoredProcedure);
            // gblObj.FillCombo(ddlNotType, dsn, 1);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList ddlDirn = (grvMemWard.Items[i].FindControl("cmbDirection") as DropDownList);
                CommonClass objcommon = new CommonClass();
                gblObj.FillCombo(ddlDirn, dsn, 2);
                ddlDirn.SelectedValue = ds.Tables[0].Rows[i][5].ToString();
            }
        }
    }
  
    protected void grvMemWard_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvMemWard.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      

            Label lblData1 = grvMemWard.Items[i].FindControl("intWardNo") as Label;   ////@intWardNo Int ,

            arrIn.Add(lblData1.Text.ToString());
            TextBox txtData2 = grvMemWard.Items[i].FindControl("chvAuditedEngFirstName") as TextBox; //@chvAuditedEngFirstName varchar(200) ,
            if (txtData2.Text == "")
            {
                TextBox lblData2 = grvMemWard.Items[i].FindControl("chvEngFirstName") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(lblData2.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtData2.Text.ToString());
            }
            DropDownList cmbDirn = grvMemWard.Items[i].FindControl("cmbDirection") as DropDownList;  ////@intAuditedDirectionType Int ,
            if (cmbDirn.SelectedIndex == 0)
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(cmbDirn.SelectedValue);
            }
            TextBox txtData3 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseFemale") as TextBox;  ////@intAuditedPopulnWardwiseFemale Int ,
            if (txtData3.Text == "")
            {
                TextBox lblData3 = grvMemWard.Items[i].FindControl("intPopulationWardwiseFemale") as TextBox;
                if (lblData3.Text != "")
                {
                    arrIn.Add(lblData3.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtData3.Text.ToString());
            }
            ////////////4
            TextBox txtData4 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseMale") as TextBox;////@intAuditedPopulnWardwiseMale Int ,
            if (txtData4.Text == "")
            {
                TextBox lblData4 = grvMemWard.Items[i].FindControl("intPopulationWardwiseMale") as TextBox;
                if (lblData4.Text != "")
                {
                    arrIn.Add(lblData4.Text.ToString());
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(txtData4.Text.ToString());
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int ep = objcomm.update("SP_TB_MemberWardDetails_U", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save_Data();
        fillGrid();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvMemWard.Items)
        {
            //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
            //Label lblData = item.FindControl("intparticipantfemale") as Label;
            //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
        }
    }
    protected void ggrvMemWard_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (grvMemWard.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblFooter = (Label)e.Item.FindControl("lblEmptyData");
                lblFooter.Visible = true;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_Data();
    }
}
