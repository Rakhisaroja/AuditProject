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

public partial class Pages_PublicWorksAssets_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            fillGrid();
            chkStatus();

        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        Save_Data();
        pnlNewEntry.Visible = false;
        fillGrid();

    }
    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvOther.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));

            Label intAssetID1 = grvOther.Items[i].FindControl("intAssetID") as Label;
            arrIn.Add(Convert.ToInt32(intAssetID1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(Session["Year"]));
            TextBox lblData22 = grvOther.Items[i].FindControl("chvAssetType") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData22.Text != "")
            {
                arrIn.Add(lblData22.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            //aud
            TextBox txtData21 = grvOther.Items[i].FindControl("chvAssetTypeAud") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData21.Text != "")
            {
              
                arrIn.Add(txtData21.Text.ToString());

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            TextBox lblData221 = grvOther.Items[i].FindControl("chvAssetValue") as TextBox;  ////(Label)e.Item.FindControl("inttotVotersMale");
            if (lblData221.Text != "")
            {
                arrIn.Add(lblData221.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            //aud
            TextBox lblData33 = grvOther.Items[i].FindControl("chvAssetValueAud") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData33.Text != "")
            {
                arrIn.Add(lblData33.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            DropDownList lblData55 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatus") as DropDownList; //item.FindControl("intparticipantfemale") as Label;
            if (lblData55.SelectedIndex > 0)
            {
                arrIn.Add(lblData55.SelectedValue.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }

            //aud

            DropDownList lblData551 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatusAud") as DropDownList; //item.FindControl("intparticipantfemale") as Label;
            if (lblData551.SelectedIndex > 0)
            {
                arrIn.Add(lblData551.SelectedValue.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            TextBox txtData2 = grvOther.Items[i].FindControl("chvMeter") as TextBox;  //(TextBox).Item..FindControl("intAuditedtotVotersMale");
            if (txtData2.Text != "")
            {
                arrIn.Add(txtData2.Text.ToString());

            }
            else
            {
                arrIn.Add(DBNull.Value);
            }

            //aud
            TextBox lblData331 = grvOther.Items[i].FindControl("chvMeterAud") as TextBox;//item.FindControl("inttotVotersfemale") as Label;
            if (lblData331.Text != "")
            {
                arrIn.Add(lblData331.Text.ToString());
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }


            arrIn.Add(Convert.ToInt64(Session["UserID"]));
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));

            arrIn.Add(1);
            int row = objcomm.update("SP_tb_AssetDetailsUrban_IU", arrIn);

            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
        //}
    }

    public void ValueAssign()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvAssetType") as TextBox;
                TextBox text2 = grvOther.Items[i].FindControl("chvAssetValue") as TextBox;
                DropDownList text3 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatus") as DropDownList;   
                TextBox text4 = grvOther.Items[i].FindControl("chvMeter") as TextBox;




                TextBox text11 = grvOther.Items[i].FindControl("chvAssetTypeAud") as TextBox;
                TextBox text21 = grvOther.Items[i].FindControl("chvAssetValueAud") as TextBox;
                DropDownList text31 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatusAud") as DropDownList;  
                TextBox text41 = grvOther.Items[i].FindControl("chvMeterAud") as TextBox;



                text11.Text = text1.Text;
                text21.Text = text2.Text;
                text31.SelectedValue = text3.SelectedValue;
                text41.Text = text4.Text;


            }
        }
    }

    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();


        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(lblGSNo.Text));
        arrIn.Add(Convert.ToInt32(Session["Year"]));

        if (txtAssetType.Text != "")
        {
            arrIn.Add(txtAssetType.Text.ToString());
            arrIn.Add(txtAssetType.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        if (txtAsset.Text != "")
        {
            arrIn.Add(txtAsset.Text.ToString());
            arrIn.Add(txtAsset.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        if (ddlSCPTSP.SelectedIndex >0)
        {
            arrIn.Add(Convert.ToInt32(ddlSCPTSP.SelectedValue.ToString()));
            arrIn.Add(Convert.ToInt32(ddlSCPTSP.SelectedValue.ToString()));
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        if (txtMtr.Text != "")
        {
            arrIn.Add(txtMtr.Text.ToString());
            arrIn.Add(txtMtr.Text.ToString());
        }
        else
        {
            arrIn.Add(DBNull.Value);
            arrIn.Add(DBNull.Value);
        }

        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);
        int ep = objcomm.update("[SP_tb_AssetDetailsUrban_IU]", arrIn);
        if (ep > 0)
        {
            gblObj.MsgBoxOk("Saved Successfully ", this);
            Session["Flag"] = 1;
        }
        arrIn.Clear();
        Response.Redirect(Request.Url.ToString());
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (pnlNewEntry.Visible == true)
        {
            pnlNewEntry.Visible = false;
        }
        else
        {


            setID();
            GlobalClass gbl = new GlobalClass();
            pnlNewEntry.Visible = true;
            gbl.ResetFormControlValues(this);
            fillGrid();
            //pnlNewEntry.Visible = true;

        }
    }
    public void setID()
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        // arr.Add(ddlWardNo.SelectedValue);
        ds = objcomm.FillData("[SP_tb_AssetDetailsUrban_setID]", arr, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblGSNo.Text = ds.Tables[0].Rows[0][0].ToString();
        }

    }
    void fillGrid()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objCom = new CommonClass();
        ds = objCom.FillData("[SP_tb_AssetDetailsUrban_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvOther.Visible = true;
            grvOther.DataSource = ds;
            grvOther.DataBind();

            int chk = 0;
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                DropDownList text14 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatus") as DropDownList;
                text14.SelectedValue = ds.Tables[0].Rows[i][6].ToString();
                DropDownList text24 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatusAud") as DropDownList;
                text24.SelectedValue = ds.Tables[0].Rows[i][10].ToString();
            }


        }
        disabletextbox();


        // SetGridDefaultCmnt();
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvAssetType") as TextBox;
                text1.ReadOnly = false;

                TextBox text2 = grvOther.Items[i].FindControl("chvAssetValue") as TextBox;
                text2.ReadOnly = false;
              
                DropDownList text3 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatus") as DropDownList;
                text3.Enabled = true;

                TextBox text4 = grvOther.Items[i].FindControl("chvMeter") as TextBox;
                text4.ReadOnly = false;


                TextBox text11 = grvOther.Items[i].FindControl("chvAssetTypeAud") as TextBox;
                text11.ReadOnly = true;

                TextBox text21 = grvOther.Items[i].FindControl("chvAssetValueAud") as TextBox;
                text21.ReadOnly = true;
               
                DropDownList text31 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatusAud") as DropDownList;
                text31.Enabled = false;

                TextBox text41 = grvOther.Items[i].FindControl("chvMeterAud") as TextBox;
                text41.ReadOnly = true;



            }
        }
        else
        {
            for (int i = 0; i < grvOther.Items.Count; i++)
            {
                TextBox text1 = grvOther.Items[i].FindControl("chvAssetType") as TextBox;
                text1.ReadOnly = true;

                TextBox text2 = grvOther.Items[i].FindControl("chvAssetValue") as TextBox;
                text2.ReadOnly = true;

                DropDownList text3 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatus") as DropDownList;
                text3.Enabled = false;

                TextBox text4 = grvOther.Items[i].FindControl("chvMeter") as TextBox;
                text4.ReadOnly = true;



                TextBox text11 = grvOther.Items[i].FindControl("chvAssetTypeAud") as TextBox;
                text11.ReadOnly = false;

                TextBox text21 = grvOther.Items[i].FindControl("chvAssetValueAud") as TextBox;
                text21.ReadOnly = false;

                DropDownList text31 = grvOther.Items[i].FindControl("chvSCPTSPFeecibitystatusAud") as DropDownList;
                text31.Enabled = true;

                TextBox text41 = grvOther.Items[i].FindControl("chvMeterAud") as TextBox;
                text41.ReadOnly = false;

            }
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublicWorkDet_Urban.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        // Response.Redirect("FinanceOtherCommittees.aspx");
        Response.Redirect("Power_Urban.aspx");
    }
}
