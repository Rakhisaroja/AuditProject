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
public partial class Pages_DrinkingWaterList : System.Web.UI.Page
{
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillData();
            filltap();
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

    protected void btnNewSave_Click(object sender, EventArgs e)
    {
        //ValueAssign();
        //savenew();
        //Save_DataTap();
        //fillData();
        //filltap();
    }
    public void ValueAssign()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtAuddwprojectexistingbeneficiary.Text = txtdwprojectexistingbeneficiary.Text;
            txtAuditdwprojectexistingdirect.Text = txtdwprojectexistingdirect.Text;
            txtAuditdwprojectnewbeneficiary.Text = txtdwprojectnewbeneficiary.Text;
            txtAuditdwprojectnewdirect.Text = txtdwprojectnewdirect.Text;
            txtAuditwell.Text = txtwell.Text;
            txtAuditborewell.Text = txtborewell.Text;
            txtAuditpond.Text = txtpond.Text;
            txtAuditStream.Text = txtstream.Text;
            txtAuditriver.Text = txtriver.Text;
            txtAuditBenefi.Text = txtBenefi.Text;

            for (int i = 0; i < grvTap.Items.Count; i++)
            {
                TextBox text1 = grvTap.Items[i].FindControl("inttapsexisting") as TextBox;             
                TextBox text2 = grvTap.Items[i].FindControl("inttapsnew") as TextBox;
              
                TextBox text11 = grvTap.Items[i].FindControl("intaudtapsexisting") as TextBox;             
                TextBox text21 = grvTap.Items[i].FindControl("intaudtapsnew") as TextBox;

                text11.Text = text1.Text;
                text21.Text = text2.Text;            

            }
        }
    }
    void fillData()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        //arrIn.Add(2);//Finance
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_drinkingwater_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdwprojectexistingbeneficiary.Text = ds.Tables[0].Rows[0][1].ToString();
            txtdwprojectexistingdirect.Text = ds.Tables[0].Rows[0][2].ToString();
            txtdwprojectnewbeneficiary.Text = ds.Tables[0].Rows[0][3].ToString();
            txtdwprojectnewdirect.Text = ds.Tables[0].Rows[0][4].ToString();
            txtwell.Text = ds.Tables[0].Rows[0][5].ToString();
            txtborewell.Text = ds.Tables[0].Rows[0][6].ToString();
            txtpond.Text = ds.Tables[0].Rows[0][7].ToString();
            txtstream.Text = ds.Tables[0].Rows[0][8].ToString();
            txtriver.Text = ds.Tables[0].Rows[0][9].ToString();
            txtBenefi.Text = ds.Tables[0].Rows[0][10].ToString();

            txtAuddwprojectexistingbeneficiary.Text = ds.Tables[0].Rows[0][11].ToString();
            txtAuditdwprojectexistingdirect.Text = ds.Tables[0].Rows[0][12].ToString();
            txtAuditdwprojectnewbeneficiary.Text = ds.Tables[0].Rows[0][13].ToString();
            txtAuditdwprojectnewdirect.Text = ds.Tables[0].Rows[0][14].ToString();
            txtAuditwell.Text = ds.Tables[0].Rows[0][15].ToString();
            txtAuditborewell.Text = ds.Tables[0].Rows[0][16].ToString();
            txtAuditpond.Text = ds.Tables[0].Rows[0][17].ToString();
            txtAuditStream.Text = ds.Tables[0].Rows[0][18].ToString();
            txtAuditriver.Text = ds.Tables[0].Rows[0][19].ToString();
            txtAuditBenefi.Text = ds.Tables[0].Rows[0][20].ToString();           

        }
        disabletextbox();
    }
    public void filltap()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        //arrIn.Add(2);//Finance
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_drinkingwaterTaps_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvTap.DataSource = ds;
            grvTap.DataBind();
            disableTaptextbox();
        }        
    }

    public void disableTaptextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        { 
            for (int i = 0; i < grvTap.Items.Count; i++)
            {
                TextBox text1 = grvTap.Items[i].FindControl("inttapsexisting") as TextBox;
                text1.ReadOnly = false;
                TextBox text2 = grvTap.Items[i].FindControl("inttapsnew") as TextBox;
                text2.ReadOnly = false;

                TextBox text11 = grvTap.Items[i].FindControl("intaudtapsexisting") as TextBox;
                text11.ReadOnly = true;
                TextBox text21 = grvTap.Items[i].FindControl("intaudtapsnew") as TextBox;
                text21.ReadOnly = true;

            }
        }
        else
        {
            for (int i = 0; i < grvTap.Items.Count; i++)
            {
                TextBox text1 = grvTap.Items[i].FindControl("inttapsexisting") as TextBox;
                text1.ReadOnly = true;
                TextBox text2 = grvTap.Items[i].FindControl("inttapsnew") as TextBox;
                text2.ReadOnly = true;

                TextBox text11 = grvTap.Items[i].FindControl("intaudtapsexisting") as TextBox;
                text11.ReadOnly = false;
                TextBox text21 = grvTap.Items[i].FindControl("intaudtapsnew") as TextBox;
                text21.ReadOnly = false;

            }
        }
    }
    public void disabletextbox()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            txtdwprojectexistingbeneficiary.ReadOnly=false;
            txtdwprojectexistingdirect.ReadOnly = false;
            txtdwprojectnewbeneficiary.ReadOnly = false;
            txtdwprojectnewdirect.ReadOnly = false;
            txtwell.ReadOnly = false;
            txtborewell.ReadOnly = false;
            txtpond.ReadOnly = false;
            txtstream.ReadOnly = false;
            txtriver.ReadOnly = false;
            txtBenefi.ReadOnly = false;

            txtAuddwprojectexistingbeneficiary.ReadOnly = true;
            txtAuditdwprojectexistingdirect.ReadOnly = true;
            txtAuditdwprojectnewbeneficiary.ReadOnly = true;
            txtAuditdwprojectnewdirect.ReadOnly = true;
            txtAuditwell.ReadOnly = true;
            txtAuditborewell.ReadOnly = true;
            txtAuditpond.ReadOnly = true;
            txtAuditStream.ReadOnly = true;
            txtAuditriver.ReadOnly = true;
            txtAuditBenefi.ReadOnly = true;


        }
        else
        {
            txtdwprojectexistingbeneficiary.ReadOnly = true;
            txtdwprojectexistingdirect.ReadOnly = true;
            txtdwprojectnewbeneficiary.ReadOnly = true;
            txtdwprojectnewdirect.ReadOnly = true;
            txtwell.ReadOnly = true;
            txtborewell.ReadOnly = true;
            txtpond.ReadOnly = true;
            txtstream.ReadOnly = true;
            txtriver.ReadOnly = true;
            txtBenefi.ReadOnly = true;

            txtAuddwprojectexistingbeneficiary.ReadOnly = false;
            txtAuditdwprojectexistingdirect.ReadOnly = false;
            txtAuditdwprojectnewbeneficiary.ReadOnly = false;
            txtAuditdwprojectnewdirect.ReadOnly = false;
            txtAuditwell.ReadOnly = false;
            txtAuditborewell.ReadOnly = false;
            txtAuditpond.ReadOnly = false;
            txtAuditStream.ReadOnly = false;
            txtAuditriver.ReadOnly = false;
            txtAuditBenefi.ReadOnly = false;
        }
    }

    public void savenew()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();


        arrIn.Add(Convert.ToInt32(Session["LBID"]));
        arrIn.Add(Convert.ToInt32(Session["Year"]));
        if (txtdwprojectexistingbeneficiary.Text != "")
        {
            arrIn.Add(txtdwprojectexistingbeneficiary.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuddwprojectexistingbeneficiary.Text != "")
        {
            arrIn.Add(txtAuddwprojectexistingbeneficiary.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtdwprojectexistingdirect.Text != "")
        {
            arrIn.Add(txtdwprojectexistingdirect.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditdwprojectexistingdirect.Text != "")
        {
            arrIn.Add(txtAuditdwprojectexistingdirect.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtdwprojectnewbeneficiary.Text != "")
        {
            arrIn.Add(txtdwprojectnewbeneficiary.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditdwprojectnewbeneficiary.Text != "")
        {
            arrIn.Add(txtAuditdwprojectnewbeneficiary.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtdwprojectnewdirect.Text != "")
        {
            arrIn.Add(txtdwprojectnewdirect.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditdwprojectnewdirect.Text != "")
        {
            arrIn.Add(txtAuditdwprojectnewdirect.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtwell.Text != "")
        {
            arrIn.Add(txtwell.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditwell.Text != "")
        {
            arrIn.Add(txtAuditwell.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtborewell.Text != "")
        {
            arrIn.Add(txtborewell.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditborewell.Text != "")
        {
            arrIn.Add(txtAuditborewell.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtpond.Text != "")
        {
            arrIn.Add(txtpond.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditpond.Text != "")
        {
            arrIn.Add(txtAuditpond.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtstream.Text != "")
        {
            arrIn.Add(txtstream.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditStream.Text != "")
        {
            arrIn.Add(txtAuditStream.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtriver.Text != "")
        {
            arrIn.Add(txtriver.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditriver.Text != "")
        {
            arrIn.Add(txtAuditriver.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////////
        if (txtBenefi.Text != "")
        {
            arrIn.Add(txtBenefi.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        ///
        if (txtAuditBenefi.Text != "")
        {
            arrIn.Add(txtAuditBenefi.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        /////////////

        arrIn.Add(Convert.ToInt64(Session["UserID"]));
        arrIn.Add(Convert.ToInt64(Session["SeatID"]));
        arrIn.Add(1);
        int ep = objcomm.update("SP_tb_drinkingwater_IU", arrIn);
        arrIn.Clear();
    }
    public void Save_DataTap()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();
        
        for (int i = 0; i < grvTap.Items.Count; i++)
        {
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,      
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,

            Label lblData1 = grvTap.Items[i].FindControl("intWardNo") as Label;   ////@intwardno ,
            //Label lblData3 = grvTap.Items[i].FindControl("intslno") as Label;   ////@intslno ,
            if (lblData1.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            
            TextBox lblData41 = grvTap.Items[i].FindControl("inttapsexisting") as TextBox;
            if (lblData41.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData41.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData3 = grvTap.Items[i].FindControl("intaudtapsexisting") as TextBox; //@chvAuditnameofmembermal 
            if (txtData3.Text == "")
            {
                arrIn.Add(DBNull.Value);
            }
            else
            {
                arrIn.Add(Convert.ToInt32(txtData3.Text.ToString()));
            }
            TextBox lblData15 = grvTap.Items[i].FindControl("inttapsnew") as TextBox;
            if (lblData15.Text != "")
            {
                arrIn.Add(Convert.ToInt32(lblData15.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData4 = grvTap.Items[i].FindControl("intaudtapsnew") as TextBox; //@chvAuditnameofmembermal 
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
            arrIn.Add(1);
            int ep = objcomm.update("SP_tb_drinkingwaterTaps_IU", arrIn);
            arrIn.Clear();
            if (ep > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
        }
        
           // gblObj.MsgBoxOk("Saved Successfully ", this);
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DrinkingWaterProjDet.aspx");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("CleanProjDet.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ValueAssign();
        savenew();
        Save_DataTap();
        fillData();
        filltap();
    }
}
