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
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using AuditClassLibrary;
using System.Data.SqlClient;
public partial class Pages_DistWiseAuditStatus : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserType"].ToString() == "5" || Session["UserType"].ToString() == "85")
            {
               fillGridUnit();
                
            }
            else if (Session["UserType"].ToString() == "32")
            {                
                fillUnitLBWise();

            }
            else
            {
                if (Session["DistID"] !=null || Session["DistID"].ToString() != "")
                {
                    lblDistID.Visible = false;
                    // int index = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

                    lblDistID.Text = Session["DistID"].ToString();//GrdUnit.DataKeys[index].Values[0].ToString();
                    ArrayList arrIn = new ArrayList();
                    arrIn.Add(Convert.ToInt32(lblDistID.Text));
                    DataSet ds = new DataSet();
                    CommonClass objcom = new CommonClass();
                    ds = objcom.FillData("[SP_TB_District_MST_Select]", arrIn, CommandType.StoredProcedure);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblDistrict.Text = ds.Tables[0].Rows[0][1].ToString();
                        lblDistrict.Visible = true;
                    }
                    //lblDistrict.Text = "1";//GrdUnit.DataKeys[index].Values[1].ToString();
                    //lblDistrict.Visible = true;
                    fillLBWise();
                }

            }

        }
    }
    ////private void SetGridDefault(DataSet ds)
    ////{
    ////    //for (int i = 0; i < count; i++)
    ////    //{
    ////    GlobalClass gblObj = new GlobalClass();
    ////    ArrayList ar = new ArrayList();
    ////    ar.Add("SLNO");
    ////    ar.Add("intslno");
    ////    ar.Add("chvnameofmembermal");
    ////    ar.Add("numstandingcommitteeid");
    ////    ar.Add("intstandingcommitteetype");
    ////    ar.Add("chvAuditnameofmembermal");

    ////    gblObj.SetGridDefaultfill(grvMembers, ar, count);
    ////    if (old != 0)
    ////    {
    ////        ArrayList arrIn = new ArrayList();
    ////        arrIn.Add(Convert.ToInt32(Session["LBID"].ToString()));
    ////        arrIn.Add(Convert.ToInt32(Session["Year"].ToString()));
    ////        arrIn.Add(3);
    ////        DataSet ds = new DataSet();
    ////        CommonClass objcom = new CommonClass();
    ////        //GlobalClass gblObj = new GlobalClass();
    ////        ds = objcom.FillData("[SP_tb_Standingcommitteememberrs_S]", arrIn, CommandType.StoredProcedure);

    ////        if (ds.Tables[0].Rows.Count > 0)
    ////        {
    ////            if (grvMembers.Items.Count > 0)
    ////            {
    ////                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    ////                {
    ////                    Label text1 = grvMembers.Items[i].FindControl("SLNO") as Label;
    ////                    text1.Text = ds.Tables[0].Rows[i][0].ToString();
    ////                    Label text11 = grvMembers.Items[i].FindControl("intslno") as Label;
    ////                    text11.Text = ds.Tables[0].Rows[i][6].ToString();
    ////                    Label text12 = grvMembers.Items[i].FindControl("intstandingcommitteetype") as Label;
    ////                    text12.Text = ds.Tables[0].Rows[i][3].ToString();
    ////                    Label text13 = grvMembers.Items[i].FindControl("numstandingcommitteeid") as Label;
    ////                    text13.Text = ds.Tables[0].Rows[i][2].ToString();
    ////                    TextBox text2 = grvMembers.Items[i].FindControl("chvAuditnameofmembermal") as TextBox;
    ////                    text2.Text = ds.Tables[0].Rows[i][9].ToString();
    ////                    TextBox text21 = grvMembers.Items[i].FindControl("chvnameofmembermal") as TextBox;
    ////                    text21.Text = ds.Tables[0].Rows[i][8].ToString();
    ////                }
    ////            }

    ////        }
    ////    }



    ////    for (int i = 0; i < count; i++)
    ////    {
    ////        TextBox aa = (TextBox)grvMembers.Items[i].FindControl("chvAuditnameofmembermal");
    ////        aa.ReadOnly = true;
    ////    }
    ////    // }
    ////}
    public void fillUnitLBWise()
    {
        LoginReference.Service objService = new LoginReference.Service();
        string webUrlString = ConfigurationManager.AppSettings["LoginReference.service"];

        objService.Url = webUrlString;
        string data;
        ArrayList arrIn = new ArrayList();
        data = "";
        data = objService.getLBDetailsSanchaya(Session["Unit"].ToString(), Session["unitID"].ToString());
        if (data != "")
        {
            DataSet dstable = new DataSet();
            DataSet dsward = new DataSet();
            //string xmlstring = httpResponse;
            StringReader theReader = new StringReader(data);
            dstable.ReadXml(theReader);
            if (dstable.Tables[0].Rows.Count > 0)
            {
             
                    //if (dstable.Tables[0].Rows[i][0].ToString() != "")
                    //{
                        pnlLBList.Visible = true;
                        grdLBList.DataSource = dstable;
                        grdLBList.DataBind();
                       
                        for (int i = 0; i < dstable.Tables[0].Rows.Count; i++)
                        {
                        arrIn.Add(Convert.ToInt32(dstable.Tables[0].Rows[i][0]));
                        arrIn.Add(Session["Year"]);
                        DataSet ds = new DataSet();
                        CommonClass objcom = new CommonClass();
                        ds = objcom.FillData("[SP_Audit_LB_Select]", arrIn, CommandType.StoredProcedure);
                        arrIn.Clear();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //    pnlLBList.Visible = true;
                            //    grdLBList.DataSource = ds;
                            //    grdLBList.DataBind();
                            //}
                            //if (ds.Tables[0].Rows.Count > 0)
                            //{
                            int count = ds.Tables[0].Rows.Count;
                            int k = 0;

                            //for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            //{  
                            k = i;
                                (grdLBList.Rows[k].FindControl("chkNotStartedStatus") as CheckBox).Checked = false;
                                (grdLBList.Rows[k].FindControl("chkongoingStatus") as CheckBox).Checked = false;
                                (grdLBList.Rows[k].FindControl("chkSubmitStatus") as CheckBox).Checked = false;
                                (grdLBList.Rows[k].FindControl("chkReturnStatus") as CheckBox).Checked = false;
                                (grdLBList.Rows[k].FindControl("chkApprovedStatus") as CheckBox).Checked = false;
                              
                                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == grdLBList.DataKeys[k].Values[0].ToString())
                                {
                                    if (ds.Tables[0].Rows[0].ItemArray[2].ToString() != "0")
                                    {
                                        CheckBox NotStarted = (CheckBox)grdLBList.Rows[k].FindControl("chkNotStartedStatus");
                                        NotStarted.Checked = true;
                                        NotStarted.BackColor = System.Drawing.Color.Red;
                                    }
                                    else if (ds.Tables[0].Rows[0].ItemArray[3].ToString() != "0")
                                    {
                                        CheckBox ongoing = (CheckBox)grdLBList.Rows[k].FindControl("chkongoingStatus");
                                        ongoing.Checked = true;
                                        ongoing.BackColor = System.Drawing.Color.Red;
                                    }
                                    else if (ds.Tables[0].Rows[0].ItemArray[4].ToString() != "0")
                                    {
                                        CheckBox Submit = (CheckBox)grdLBList.Rows[k].FindControl("chkSubmitStatus");
                                        Submit.Checked = true;
                                        Submit.BackColor = System.Drawing.Color.Red;
                                    }
                                    else if (ds.Tables[0].Rows[0].ItemArray[5].ToString() != "0")
                                    {
                                        CheckBox Return = (CheckBox)grdLBList.Rows[k].FindControl("chkReturnStatus");
                                        Return.Checked = true;
                                        Return.BackColor = System.Drawing.Color.Red;
                                    }
                                    else if (ds.Tables[0].Rows[0].ItemArray[6].ToString() != "0")
                                    {
                                        CheckBox Approved = (CheckBox)grdLBList.Rows[k].FindControl("chkApprovedStatus");
                                        Approved.Checked = true;
                                        Approved.BackColor = System.Drawing.Color.Red;
                                    }
                                   // j++;
                                //}
                            }
                       // }

                    }
                }
            }
        }
    }

    void fillGridUnit()
    {
        ArrayList arrIn = new ArrayList();
        //arrIn.Add(Session["LBID"].ToString());
        //arrIn.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        CommonClass objcom = new CommonClass();
        GlobalClass gblObj = new GlobalClass();

        arrIn.Add(Session["Year"]);
        ds = objcom.FillData("[SP_DistWide_Audit_S]",arrIn, CommandType.StoredProcedure);
        if (ds.Tables[0].Rows.Count > 0)
        {
            pnlGrdUnit.Visible = true;
            GrdUnit.DataSource = ds;
            GrdUnit.DataBind();
        }
        else
        {
            pnlGrdUnit.Visible = false;
            
        }
        //disabletextbox();
    }
    protected void lnkAnnualRpt_Click(object sender, EventArgs e)
    {
        lblDistID.Visible = false;
        int index = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt64(GrdUnit.DataKeys[index].Values[0].ToString()));
        lblDistID.Text = GrdUnit.DataKeys[index].Values[1].ToString();

    }

    protected void lnkFund_Click(object sender, EventArgs e)
    {
        lblDistID.Visible = false;
        int index = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
        ArrayList arrIn = new ArrayList();
        arrIn.Add(Convert.ToInt64(GrdUnit.DataKeys[index].Values[0].ToString()));
        lblDistID.Text = GrdUnit.DataKeys[index].Values[1].ToString();

    }

    //protected void lnkRtnAudit_Click(object sender, EventArgs e)
    //{
    //    lblDistID.Visible = false;
    //    int index = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
    //    ArrayList arrIn = new ArrayList();
    //    arrIn.Add(Convert.ToInt64(GrdUnit.DataKeys[index].Values[0].ToString()));
    //    lblDistID.Text = GrdUnit.DataKeys[index].Values[1].ToString();

    //}
    protected void lnkUnit_Click(object sender, EventArgs e)
    {
        lblDistID.Visible = false;
        int index = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;

        lblDistID.Text = GrdUnit.DataKeys[index].Values[0].ToString();
         
        lblDistrict.Text = GrdUnit.DataKeys[index].Values[1].ToString();
        lblDistrict.Visible = true;
        fillLBWise();

    }
    public void fillLBWise()
    {
        ArrayList arrIn = new ArrayList();
        if (lblDistID.Text != "")
        {
            arrIn.Add(Convert.ToInt32(lblDistID.Text));
            arrIn.Add(Session["Year"]);
            DataSet ds = new DataSet();
            CommonClass objcom = new CommonClass();
            ds = objcom.FillData("[SP_DistAudit_LB_S]", arrIn, CommandType.StoredProcedure);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlLBList.Visible = true;
                grdLBList.DataSource = ds;
                grdLBList.DataBind();
            }
            else
            {
                pnlLBList.Visible = false;
                 
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
    protected void lnkAnnualRpt_Click(object sender, ImageClickEventArgs e)
    {
        GlobalClass gblObj = new GlobalClass();
        int index = ((sender as ImageButton).NamingContainer as GridViewRow).RowIndex;
        Session["LBIDA"] = (grdLBList.DataKeys[index].Values[0].ToString());
        Session["Rpt"] = 1;

        ArrayList Arry = new ArrayList();
        DataSet dsLB = new DataSet();
        Arry.Add(Session["LBIDA"]);
        Arry.Add(Convert.ToInt64(Session["Year"]));

        CommonClass ClsGlobal = new CommonClass();
        dsLB = ClsGlobal.Fetch("SP_tb_generaladministrationRPT_S", CommandType.StoredProcedure, Arry);
        if (dsLB.Tables[0].Rows.Count > 0)
        {
            ArrayList arr = new ArrayList();
            arr.Add(Convert.ToInt32(Session["LBIDA"]));
            arr.Add(Session["Year"]);
            CommonClass objcom = new CommonClass();
            DataSet dbstatus = new DataSet();
            //GlobalClass gblObj = new GlobalClass();
            dbstatus = objcom.FillData("SP_tb_auditmain_S", arr, CommandType.StoredProcedure);
            if (dbstatus.Tables[0].Rows.Count > 0)
            {
                if (dbstatus.Tables[0].Rows[0][0].ToString() == "3")
                {
                    Response.Redirect("AuditReport.aspx");
                }
                else
                {
                    gblObj.MsgBoxOk("Sorry!!, not yet Approved", this);
                }
            }
            else
            {
                gblObj.MsgBoxOk("Sorry!!, not yet Completed", this);
            }
        }
        else
        {
            gblObj.MsgBoxOk("Sorry!!, yet not yet Completed", this);
        }
        //Response.Redirect(Request.Url.ToString());
    }

    protected void lnkFund_Click(object sender, ImageClickEventArgs e)
    {
        GlobalClass gblObj = new GlobalClass();
        int index = ((sender as ImageButton).NamingContainer as GridViewRow).RowIndex;
        Session["LBIDA"] = (grdLBList.DataKeys[index].Values[0].ToString());
        Session["Rpt"] = 2;
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Convert.ToInt32(Session["LBIDA"]));
        arr.Add(Convert.ToInt32(Session["Year"]));
        //ClsGlobal.Fetch("sp_SyncSaankhyarptfinSurplus", CommandType.StoredProcedure, arr);
        arr.Add(1);
        CommonClass ClsGlobal = new CommonClass();
        ds = ClsGlobal.Fetch("SP_rptfinSurplusRPT_Sel", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("AuditReport.aspx");
        }
        else
        {
            gblObj.MsgBoxOk("Sorry!!, not yet Completed", this);
        }
    }
    protected void lnkRtnAudit_Click(object sender, ImageClickEventArgs e)
    {
        int index = ((sender as ImageButton).NamingContainer as GridViewRow).RowIndex;
        string intid = (grdLBList.DataKeys[index].Values[0].ToString());
        if (Session["RoleID"].ToString() == "3" && intid != "")
        {
            SubmitApplication(1, Convert.ToInt32(intid));
            fillLBWise();
        }
    }
    //public void chkSttaus()
    //{
    //    ArrayList arr = new ArrayList();
    //    CommonClass objcom = new CommonClass();
    //    arr.Add(Session["LBID"]);
    //    arr.Add(Session["Year"]);
    //    DataSet status = new DataSet();
    //    status = objcom.FillData("SP_tb_auditmain_S", arr, CommandType.StoredProcedure);
    //    if (status.Tables[0].Rows.Count > 0)
    //    {
    //        Session["ApproveStatus"] = status.Tables[0].Rows[0][0].ToString();
    //    }
    //    else
    //    {
    //        Session["ApproveStatus"] = "";
    //    }
    //}
    public void SubmitApplication(int status, Int32 lbid)
    {
        //lblerr.Text = "";
        //if (txtRemarks.Text.Trim() != "")
        //{
        ArrayList arr = new ArrayList();
        CommonClass objcom = new CommonClass();
        arr.Add(lbid);
        arr.Add(Session["Year"]);
        DataSet dbstatus = new DataSet();
        GlobalClass gblObj = new GlobalClass();
        dbstatus = objcom.FillData("SP_tb_auditmain_S", arr, CommandType.StoredProcedure);
        if (dbstatus.Tables[0].Rows.Count > 0)
        {
            if (dbstatus.Tables[0].Rows[0][0].ToString() == "3")
            {
                ArrayList arr1 = new ArrayList();
                arr1.Add(lbid);
                arr1.Add(Session["Year"].ToString());
                arr1.Add("Returned by (Auditor)Higher Authority");
                arr1.Add(status);
                arr1.Add(Session["UserID"]);
                arr1.Add(Session["SeatID"]);
                CommonClass clsObj = new CommonClass();
                clsObj.Fetch("SP_AuditSubmit_IU", CommandType.StoredProcedure, arr1);

                gblObj.MsgBoxOk("Returned Successfully ", this);
            }
            else
            {
                gblObj.MsgBoxOk("Sorry!!, not yet approved", this);
            }

        }
        else
        {
            gblObj.MsgBoxOk("Sorry!!, not yet completed", this);
        }
        // Response.Redirect(Request.Url.ToString());
    }

}

