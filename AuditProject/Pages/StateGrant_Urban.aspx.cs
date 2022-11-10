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

public partial class Pages_StateGrant_Urban : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
 
            fillGridStateGrant();
            fillGridStateGrantChild();
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

    public void disabletextbox1()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvStateGrant.Items.Count; i++)
            {
                TextBox text7 = grvStateGrant.Items[i].FindControl("fltbudget") as TextBox;
                text7.ReadOnly = true;             /////////////////not editable
                TextBox text8 = grvStateGrant.Items[i].FindControl("fltrelease") as TextBox;
                text8.ReadOnly = true;
                 TextBox text17 = grvStateGrant.Items[i].FindControl("fltexpense") as TextBox;
                 text17.ReadOnly = true;             /////////////////not editable
                TextBox text18 = grvStateGrant.Items[i].FindControl("fltlapse") as TextBox;
                text18.ReadOnly = true;

                TextBox text27 = grvStateGrant.Items[i].FindControl("fltaudbudget") as TextBox;
                text27.ReadOnly = true;             /////////////////not editable
                TextBox text28 = grvStateGrant.Items[i].FindControl("fltaudrelease") as TextBox;
                text28.ReadOnly = true;
                 TextBox text37 = grvStateGrant.Items[i].FindControl("fltaudexpense") as TextBox;
                 text37.ReadOnly = true;             /////////////////not editable
                 TextBox text38 = grvStateGrant.Items[i].FindControl("fltaudlapse") as TextBox;
                 text38.ReadOnly = true;

            }

        }
        else
        {
            for (int i = 0; i < grvStateGrant.Items.Count; i++)
            {
                TextBox text7 = grvStateGrant.Items[i].FindControl("fltbudget") as TextBox;
                text7.ReadOnly = true;             /////////////////not editable
                TextBox text8 = grvStateGrant.Items[i].FindControl("fltrelease") as TextBox;
                text8.ReadOnly = true;
                 TextBox text17 = grvStateGrant.Items[i].FindControl("fltexpense") as TextBox;
                 text17.ReadOnly = true;             /////////////////not editable
                TextBox text18 = grvStateGrant.Items[i].FindControl("fltlapse") as TextBox;
                text18.ReadOnly = true;

                TextBox text27 = grvStateGrant.Items[i].FindControl("fltaudbudget") as TextBox;
                text27.ReadOnly = false;             /////////////////not editable
                TextBox text28 = grvStateGrant.Items[i].FindControl("fltaudrelease") as TextBox;
                text28.ReadOnly = false;
                 TextBox text37 = grvStateGrant.Items[i].FindControl("fltaudexpense") as TextBox;
                 text37.ReadOnly = false;             /////////////////not editable
                TextBox text38 = grvStateGrant.Items[i].FindControl("fltaudlapse") as TextBox;
                text38.ReadOnly = true;


            }
        }
    }
  
    
    public void disabletextbox2()
    {

        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            for (int i = 0; i < grvStateGrantChild.Items.Count; i++)
            {
                TextBox text7 = grvStateGrantChild.Items[i].FindControl("fltalloc") as TextBox;
                text7.ReadOnly = true;             /////////////////not editable
                TextBox text8 = grvStateGrantChild.Items[i].FindControl("fltexpense") as TextBox;
                text8.ReadOnly = true;

                TextBox text17 = grvStateGrantChild.Items[i].FindControl("fltaudalloc") as TextBox;
                text17.ReadOnly = true;             /////////////////not editable
                TextBox text18 = grvStateGrantChild.Items[i].FindControl("fltaudexpense") as TextBox;
                text18.ReadOnly = true;
 

            }

        }
        else
        {
            for (int i = 0; i < grvStateGrantChild.Items.Count; i++)
            {
                  TextBox text7 = grvStateGrantChild.Items[i].FindControl("fltalloc") as TextBox;
                text7.ReadOnly = true;             /////////////////not editable
                TextBox text8 = grvStateGrantChild.Items[i].FindControl("fltexpense") as TextBox;
                text8.ReadOnly = true;

                TextBox text17 = grvStateGrantChild.Items[i].FindControl("fltaudalloc") as TextBox;
                text17.ReadOnly = false;             /////////////////not editable
                TextBox text18 = grvStateGrantChild.Items[i].FindControl("fltaudexpense") as TextBox;
                text18.ReadOnly = false;


            }
        }
    }
    void fillGridStateGrant()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_stategrants_S]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvStateGrant.DataSource = ds;
            grvStateGrant.DataBind();
            disabletextbox1();

            //lblOBAuditAmt.Text = ds.Tables[0].Rows[0][6].ToString();
            //lblOBAmt.Text = ds.Tables[0].Rows[0][5].ToString();//
            //obtot.Text = ds.Tables[0].Rows[0][5].ToString();
            //auditobtot.Text = ds.Tables[0].Rows[0][6].ToString();

            Control FooterTemplate = grvStateGrant.Controls[grvStateGrant.Controls.Count - 1].Controls[0];
                    
            Label obtot1 = FooterTemplate.FindControl("totbudget") as Label;
            obtot1.Text = ds.Tables[0].Rows[0][14].ToString();

            Label auditobtot1 = FooterTemplate.FindControl("totfltrelease") as Label;
            auditobtot1.Text = ds.Tables[0].Rows[0][15].ToString();

            Label totfltexpense1 = FooterTemplate.FindControl("totfltexpense") as Label;
            totfltexpense1.Text = ds.Tables[0].Rows[0][16].ToString();

            Label totfltlapse1 = FooterTemplate.FindControl("totfltlapse") as Label;
            totfltlapse1.Text = ds.Tables[0].Rows[0][17].ToString();

            Label totaudbudget1 = FooterTemplate.FindControl("totaudbudget") as Label;
            totaudbudget1.Text = ds.Tables[0].Rows[0][18].ToString();

            Label totaudfltrelease1 = FooterTemplate.FindControl("totaudfltrelease") as Label;
            totaudfltrelease1.Text = ds.Tables[0].Rows[0][19].ToString();

            Label totaudfltexpense1 = FooterTemplate.FindControl("totaudfltexpense") as Label;
            totaudfltexpense1.Text = ds.Tables[0].Rows[0][20].ToString();

            Label totaudfltlapse1 = FooterTemplate.FindControl("totaudfltlapse") as Label;
            totaudfltlapse1.Text = ds.Tables[0].Rows[0][21].ToString();
        }
    }
    void fillGridStateGrantChild()
    {
        ArrayList arrIn = new ArrayList();

        arrIn.Add(Session["LBID"].ToString());
        arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();
        ds = objcom.FillData("[SP_tb_devfundsec_S1]", arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvStateGrantChild.DataSource = ds;
            grvStateGrantChild.DataBind();
            disabletextbox2();

            //lblOBAuditAmt.Text = ds.Tables[0].Rows[0][6].ToString();
            //lblOBAmt.Text = ds.Tables[0].Rows[0][5].ToString();//
            //obtot.Text = ds.Tables[0].Rows[0][5].ToString();
            //auditobtot.Text = ds.Tables[0].Rows[0][6].ToString();

            Control FooterTemplate = grvStateGrantChild.Controls[grvStateGrantChild.Controls.Count - 1].Controls[0];           
 
            Label totfltalloc1 = FooterTemplate.FindControl("totfltalloc") as Label;
            totfltalloc1.Text = ds.Tables[0].Rows[0][11].ToString();
            Label totfltexpense1 = FooterTemplate.FindControl("totfltexpense") as Label;
            totfltexpense1.Text = ds.Tables[0].Rows[0][12].ToString();
            //Label obtot1 = FooterTemplate.FindControl("totbudget") as Label;
            //obtot1.Text = ds.Tables[0].Rows[0][16].ToString();
            Label totfltaudalloc1 = FooterTemplate.FindControl("totfltaudalloc") as Label;
            totfltaudalloc1.Text = ds.Tables[0].Rows[0][13].ToString();
            Label totfltaudexpense1 = FooterTemplate.FindControl("totfltaudexpense") as Label;
            totfltaudexpense1.Text = ds.Tables[0].Rows[0][14].ToString();
          
        }
    }
    

    public void Save_Data()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvStateGrant.Items.Count; i++)
        {
            
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,     
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,

            Label lblData1 = grvStateGrant.Items[i].FindControl("intFundSrcID") as Label;   ////@vchaccountheadcode ,

            arrIn.Add(lblData1.Text.ToString());
            TextBox lblData12 = grvStateGrant.Items[i].FindControl("fltbudget") as TextBox;
            if (lblData12.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData12.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvStateGrant.Items[i].FindControl("fltaudbudget") as TextBox; //@numauditedobamount 
            if (txtData2.Text == "")
            {
                TextBox lblData2 = grvStateGrant.Items[i].FindControl("fltbudget") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }
            /////////////
            TextBox lblData112 = grvStateGrant.Items[i].FindControl("fltrelease") as TextBox;
            if (lblData112.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData112.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData12 = grvStateGrant.Items[i].FindControl("fltaudrelease") as TextBox; //@numauditedobamount 
            if (txtData12.Text == "")
            {
                TextBox lblData2 = grvStateGrant.Items[i].FindControl("fltrelease") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData12.Text.ToString()));
            }
            ///////////
            TextBox lblData122 = grvStateGrant.Items[i].FindControl("fltexpense") as TextBox;
            if (lblData122.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData122.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData22 = grvStateGrant.Items[i].FindControl("fltaudexpense") as TextBox; //@numauditedobamount 
            if (txtData22.Text == "")
            {
                TextBox lblData2 = grvStateGrant.Items[i].FindControl("fltexpense") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData22.Text.ToString()));
            }
            /////
            TextBox lblData123 = grvStateGrant.Items[i].FindControl("fltlapse") as TextBox;
            if (lblData123.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData123.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData24 = grvStateGrant.Items[i].FindControl("fltaudlapse") as TextBox; //@numauditedobamount 
            if (txtData24.Text == "")
            {
                TextBox lblData2 = grvStateGrant.Items[i].FindControl("fltlapse") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData24.Text.ToString()));
            }
            ////////////
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int row = objcomm.update("SP_tb_stategrants_U", arrIn);

            GlobalClass gblObj = new GlobalClass();
            if (row > 0)
            {
                gblObj.MsgBoxOk("Saved Successfully ", this);
            }
            arrIn.Clear();
        }
    }
    public void Save_DataChild()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        for (int i = 0; i < grvStateGrantChild.Items.Count; i++)
        {
           
            arrIn.Add(Convert.ToInt32(Session["LBID"]));        ////@intLBID Int ,  
            arrIn.Add(Convert.ToInt32(Session["Year"]));        ////@intfinancialyearid Int ,
              Label lblData11 = grvStateGrantChild.Items[i].FindControl("intMajorSecID") as Label;   ////@vchaccountheadcode ,
              if (lblData11.Text.ToString() == "" && i != grvStateGrantChild.Items.Count - 1)
              {
                  i++;
              }
              else if (i == grvStateGrantChild.Items.Count - 1)
              {
                  return ;
              }
            Label lblData1 = grvStateGrantChild.Items[i].FindControl("intFundSrcID") as Label;   ////@vchaccountheadcode ,
            Label lblData111 = grvStateGrantChild.Items[i].FindControl("intMajorSecID") as Label;   ////@vchaccountheadcode ,
            arrIn.Add(Convert.ToInt32(lblData1.Text.ToString()));
            arrIn.Add(Convert.ToInt32(lblData111.Text.ToString()));         
            
            TextBox lblData12 = grvStateGrantChild.Items[i].FindControl("fltalloc") as TextBox;
            if (lblData12.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData12.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData2 = grvStateGrantChild.Items[i].FindControl("fltaudalloc") as TextBox; //@numauditedobamount 
            if (txtData2.Text == "")
            {
                TextBox lblData2 = grvStateGrantChild.Items[i].FindControl("fltalloc") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData2.Text.ToString()));
            }
            /////////////
            TextBox lblData112 = grvStateGrantChild.Items[i].FindControl("fltexpense") as TextBox;
            if (lblData112.Text != "")
            {
                arrIn.Add(Convert.ToDouble(lblData112.Text.ToString()));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
            TextBox txtData12 = grvStateGrantChild.Items[i].FindControl("fltaudexpense") as TextBox; //@numauditedobamount 
            if (txtData12.Text == "")
            {
                TextBox lblData2 = grvStateGrantChild.Items[i].FindControl("fltexpense") as TextBox;
                if (lblData2.Text != "")
                {
                    arrIn.Add(Convert.ToDouble(lblData2.Text.ToString()));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                }
            }
            else
            {
                arrIn.Add(Convert.ToDouble(txtData12.Text.ToString()));
            }
           
            ////////////
            arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
            arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
            arrIn.Add(1);
            int ep = objcomm.update("SP_tb_devfundsec_U1", arrIn);
            arrIn.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        Save_Data();
        Save_DataChild();
        fillGridStateGrant();
        fillGridStateGrantChild();
    }
    public void clearGrid()
    {
        foreach (RepeaterItem item in grvStateGrant.Items)
        {
            //TextBox txtData1 = item.FindControl("intauditedwardno") as TextBox;
            //Label lblData = item.FindControl("intparticipantfemale") as Label;
            //TextBox txtData = item.FindControl("chvauditedremarks") as TextBox;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Save_Data();
    }

   

    protected void btnPrev_Click(object sender, EventArgs e)
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

  
    }
   
}
