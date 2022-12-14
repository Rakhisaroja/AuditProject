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

public partial class Pages_MemberWardDetails : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

          
            //Session["LBID"] = 276;
            //Session["Year"] = 21;
            //Session["UserID"] = 80374;
            //Session["SeatID"] = 5027601002;
            fillGrid();
            chkStatus();
            //disabletextbox();
        }
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }


    }

    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2")
        {
            for (int i = 0; i < grvMemWard.Items.Count; i++)
            {
                TextBox text1 = grvMemWard.Items[i].FindControl("nchvDirection") as TextBox;
                
                TextBox text2 = grvMemWard.Items[i].FindControl("intPopulationWardwiseFemale") as TextBox;
               
                TextBox text3 = grvMemWard.Items[i].FindControl("intPopulationWardwiseMale") as TextBox;
                
                TextBox text4 = grvMemWard.Items[i].FindControl("chvMalFirstName") as TextBox;
                

                TextBox text5 = grvMemWard.Items[i].FindControl("nchAuditvDirection") as TextBox;
               
                TextBox text6 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseFemale") as TextBox;
                
                TextBox text7 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseMale") as TextBox;
                
                TextBox text8 = grvMemWard.Items[i].FindControl("chvAuditedMalFirstName") as TextBox;

                text5.Text = text1.Text;
                text6.Text = text2.Text;
                text7.Text = text3.Text;
                text8.Text = text4.Text;
               
            }
        }
    }
    public void disabletextbox()
    {

        if (Session["RoleID"].ToString() == "2")
        {
            for (int i = 0; i < grvMemWard.Items.Count; i++)
            {
                TextBox text1 = grvMemWard.Items[i].FindControl("nchvDirection") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvMemWard.Items[i].FindControl("intPopulationWardwiseFemale") as TextBox;
                text2.ReadOnly = false;
                TextBox text3 = grvMemWard.Items[i].FindControl("intPopulationWardwiseMale") as TextBox;
                text3.ReadOnly = false;
                TextBox text4 = grvMemWard.Items[i].FindControl("chvMalFirstName") as TextBox;
                text4.ReadOnly = false;

                TextBox text5 = grvMemWard.Items[i].FindControl("nchAuditvDirection") as TextBox;
                text5.ReadOnly = true;
                TextBox text6 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseFemale") as TextBox;
                text6.ReadOnly = true;
                TextBox text7 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseMale") as TextBox;
                text7.ReadOnly = true;
                TextBox text8 = grvMemWard.Items[i].FindControl("chvAuditedMalFirstName") as TextBox;
                text8.ReadOnly = true;

            }

        }
        else
        {
            for (int i = 0; i < grvMemWard.Items.Count; i++)
            {
                TextBox text1 = grvMemWard.Items[i].FindControl("nchvDirection") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvMemWard.Items[i].FindControl("intPopulationWardwiseFemale") as TextBox;
                text2.ReadOnly = true;
                TextBox text3 = grvMemWard.Items[i].FindControl("intPopulationWardwiseMale") as TextBox;
                text3.ReadOnly = true;
                TextBox text4 = grvMemWard.Items[i].FindControl("chvMalFirstName") as TextBox;
                text4.ReadOnly = true;

                TextBox text5 = grvMemWard.Items[i].FindControl("nchAuditvDirection") as TextBox;
                text5.ReadOnly = false;
                TextBox text6 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseFemale") as TextBox;
                text6.ReadOnly = false;
                TextBox text7 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseMale") as TextBox;
                text7.ReadOnly = false;
                TextBox text8 = grvMemWard.Items[i].FindControl("chvAuditedMalFirstName") as TextBox;
                text8.ReadOnly = false;
            }
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
            disabletextbox();
        }  
    }
    //private void SetGridDefaultCmnt()
    //{
    //    GlobalClass gblObj = new GlobalClass();
    //    ArrayList ar = new ArrayList();
    //    ar.Add("intWardNo");
    //    ar.Add("TotvoteFemale");
    //    ar.Add("Totvotemale");
    //    ar.Add("particvoteFemale");
    //    ar.Add("particvotemale");
    //    ar.Add("chvGSPlace");
    //    ar.Add("chvGSDate");
    //    ar.Add("AttendPrecen");
    //    ar.Add("Remarks");

    //    ar.Add("AuditintWardNo");
    //    ar.Add("AuditTotvoteFemale");
    //    ar.Add("AuditTotvotemale");
    //    ar.Add("AuditparticvoteFemale");
    //    ar.Add("Auditparticvotemale");
    //    ar.Add("AuditchvGSPlace");
    //    ar.Add("AuditchvGSDate");
    //    ar.Add("AuditAttendPrecen");
    //    ar.Add("AuditRemarks");
    //    //ar.Add("AgendaProcedure1");
    //    //ar.Add("AgendaProcedure2");
    //    //ar.Add("AgendaProcedure3");
    //    // gblObj.SetGridDefault(grvMergeHeader, ar);

    //}


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
    ////       
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
            
            Label lblData1 = grvMemWard.Items[i].FindControl("intWardNo") as Label;   ////@intWardNo Int ,

            arrIn.Add(lblData1.Text.ToString());
              TextBox lblData21 = grvMemWard.Items[i].FindControl("nchvDirection") as TextBox;
                if (lblData21.Text != "")
                {
                    arrIn.Add(lblData21.Text.ToString()); ////@nchvDirection nvarchar(500),
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
                arrIn.Add(DBNull.Value);
                arrIn.Add(DBNull.Value);
                TextBox lblData31 = grvMemWard.Items[i].FindControl("chvMalFirstName") as TextBox;
                if (lblData31.Text != "")
                {
                    arrIn.Add(lblData31.Text.ToString());////@chvEngFirstName varchar(200) ,
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
                TextBox txtData2 = grvMemWard.Items[i].FindControl("chvAuditedMalFirstName") as TextBox;   ////@chvAuditedEngFirstName varchar(200) ,
            if (txtData2.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(txtData2.Text.ToString());
            }
            TextBox txtData22 = grvMemWard.Items[i].FindControl("nchAuditvDirection") as TextBox;  ////@nchAuditvDirection nvarchar(500),
            if (txtData22.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(txtData22.Text.ToString());
            }
            TextBox lblData33 = grvMemWard.Items[i].FindControl("intPopulationWardwiseFemale") as TextBox;
            if (lblData33.Text != "")
            {
                arrIn.Add(Convert.ToInt32( lblData33.Text.ToString())); ////@intPopulationWardwiseFemale int,
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData3 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseFemale") as TextBox;      ////@intAuditedPopulnWardwiseFemale Int ,
            if (txtData3.Text == "")
            {
                arrIn.Add(DBNull.Value);
                        
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData3.Text.ToString()));
            }
            ////////////4
            TextBox lblData41 = grvMemWard.Items[i].FindControl("intPopulationWardwiseMale") as TextBox;  ////@intPopulationWardwiseMale int,	
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvMemWard.Items[i].FindControl("intAuditedPopulnWardwiseMale") as TextBox; ////@intAuditedPopulnWardwiseMale Int ,	 
            if (txtData4.Text == "")
            {
                arrIn.Add(DBNull.Value);
                
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData4.Text.ToString()));
            }
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 

            int row = objcomm.update("SP_TB_MemberWardDetails_U", arrIn);
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
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
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        Response.Redirect("BudgetDetails.aspx");
    }
   
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("Meeting.aspx");
    }
}
