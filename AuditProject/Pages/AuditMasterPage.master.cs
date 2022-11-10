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
public partial class Pages_AuditMasterPage : System.Web.UI.MasterPage
{
    CommonClass objCommon = new CommonClass();
    protected void Page_Init(object sender, EventArgs e)
    {
 

        try
        {
            if (Session["UserID"] == null || int.Parse(Session["UserID"].ToString()) == 0)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["Pass"] == "1")
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["LBID"].ToString() == "5001" || (Session["LBID"].ToString() == "5000" && Session["RoleID"].ToString() == "1"))
            {
                //fillDrop();
            }
            else
            {
                fillDrop();
                chkStatus();
            }

        }

        catch (Exception ex)
        {
            Response.Redirect("Login.aspx");
        }

    }
    public void chkStatus()
    {
       // lblLB.Text = "";
        //Session["AuditLBName"] = "";
        //if (Session["AuditLBName"] != null)
        //{
        //    lblLB.Visible = true;
        //    lblLB.Text = Session["AuditLBName"].ToString();
        //}
       // ((MasterPageType)this.Master).lblText = "Whatever";
        ArrayList arr = new ArrayList();
        CommonClass objcom = new CommonClass();
        arr.Add(Session["LBID"]);
        arr.Add(Session["Year"]);
        DataSet status = new DataSet();
        status = objcom.FillData("SP_tb_auditmain_S", arr, CommandType.StoredProcedure);
        if (status.Tables[0].Rows.Count > 0)
        {
            Session["ApproveStatus"] = status.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            Session["ApproveStatus"] = "";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblFinYear.Text = Session["YearSetting"].ToString();

            if (Session["LBID"].ToString() == "5000" && Session["RoleID"].ToString() == "1")
            {
                 lblLB.Text = "";
                Session["AuditLBName"] = "";
                 lblUser.Text = Session["UserName"].ToString() + '-' + Session["UserDesig"].ToString() + '-' + Session["LBNAME"].ToString();
                 lblUser.Style.Add("width", "100%");
                 lblLB.Style.Add("width", "100%");
                //if (Session["AuditLBName"] != null)
                //{
                //    lblLB.Text = Session["AuditLBName"].ToString();
                //}
                
                //fillDrop();
            }
            else
            {
               // lblAuditLBName.Visible = true;
                fillDrop();
            }
        }
         
    }
    void fillDrop()
    {
        if (Session["RoleID"].ToString() == "1")
        {
            if (Session["AuditLBName"] != null)
            {
                lblLB.Visible = true;
                lblLB.Text = "";
                lblLB.Text = Session["AuditLBName"].ToString();
                //lblLB.Text = "";
            }
        }
        else
        {
            lblLB.Visible = false;
        }
        lblUser.Visible = true;
        lblUser.Text = Session["UserName"].ToString() + '-' + Session["UserDesig"].ToString() + '-' + Session["LBNAME"].ToString();// +'-' + Session["AuditLBName"].ToString();
        //lblUser.Width = '100%';
        lblUser.Style.Add("width","100%");
        string str1 = "";
        ArrayList arrin = new ArrayList();
        DataSet ds = new DataSet();
        arrin.Add(Session["RoleID"].ToString());
        arrin.Add(Session["LBType"].ToString());
        //Modified by Rakhi S 03.08.2020
        //----------************************************//
        if(Session["Year"].ToString() != "21")
        {
            arrin.Add(22);

        }
        else
        {
            arrin.Add(Session["Year"].ToString());
        }
        //----------************************************//
        //arrin.Add(Session["UserType"].ToString());

        ds = objCommon.Fetch("Sp_SelectMasterMenu", CommandType.StoredProcedure, arrin);
       
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i][0].ToString() == "15" || ds.Tables[0].Rows[i][0].ToString() == "41" || ds.Tables[0].Rows[i][0].ToString() == "111" || ds.Tables[0].Rows[i][0].ToString() == "137")
            {
                str1 = str1 + " <li style='font-size: 21px;font-family: Meera; color: #17a2b8;padding-top: 12px;'> ";
                str1 = str1 + ds.Tables[0].Rows[i][2].ToString() ;
            }
            else if (ds.Tables[0].Rows[i][0].ToString() != "21" && ds.Tables[0].Rows[i][0].ToString() != "22" && ds.Tables[0].Rows[i][0].ToString() != "23" && ds.Tables[0].Rows[i][0].ToString() != "24" && ds.Tables[0].Rows[i][0].ToString() != "25" && ds.Tables[0].Rows[i][0].ToString() != "26" && ds.Tables[0].Rows[i][0].ToString() != "27" && ds.Tables[0].Rows[i][0].ToString() != "28" && ds.Tables[0].Rows[i][0].ToString() != "29" && ds.Tables[0].Rows[i][0].ToString() != "117" && ds.Tables[0].Rows[i][0].ToString() != "118" && ds.Tables[0].Rows[i][0].ToString() != "119" && ds.Tables[0].Rows[i][0].ToString() != "120" && ds.Tables[0].Rows[i][0].ToString() != "121" && ds.Tables[0].Rows[i][0].ToString() != "122" && ds.Tables[0].Rows[i][0].ToString() != "123" && ds.Tables[0].Rows[i][0].ToString() != "124" && ds.Tables[0].Rows[i][0].ToString() != "125" && ds.Tables[0].Rows[i][0].ToString() != "193")
            {
                str1 = str1 + " <li class='menu-item-has-children active dropdown' style='font-size: 21px;font-family: Meera'> ";
                str1 = str1 + " <a href='#'  class='dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'  > <i class='menu-icon fa fa-table'></i>" + ds.Tables[0].Rows[i][2].ToString() + "</a>";

            }
            else if (ds.Tables[0].Rows[i][0].ToString() == "27" || ds.Tables[0].Rows[i][0].ToString() == "28" || ds.Tables[0].Rows[i][0].ToString() == "123" || ds.Tables[0].Rows[i][0].ToString() == "124")
            {
                // str1 = str1 + " <a href='#'  class='dropdown-toggle' target='_blank' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' > <i class='menu-icon fa fa-table'></i>" + ds.Tables[0].Rows[i][2].ToString() + "</a>";
                str1 = str1 + " <li class='menu-item-has-children active dropdown' style='font-size: 21px;font-family: Meera'> ";
                str1 = str1 + " <a href='" + ds.Tables[0].Rows[i][3].ToString() + "' target='_blank  > <i class='menu-icon fa fa-table'></i>" + ds.Tables[0].Rows[i][2].ToString() + "</a>";

            }

            else
            {
                str1 = str1 + " <li class='menu-item-has-children active dropdown' style='font-size: 21px;font-family: Meera'> ";
                str1 = str1 + " <a href='" + ds.Tables[0].Rows[i][3].ToString() + "'> <i class='menu-icon fa fa-table'></i>" + ds.Tables[0].Rows[i][2].ToString() + "</a>";

            }
          //str1 = str1 + " <li class='nav navbar-nav'><a href='" + ds.Tables[0].Rows[i][3].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "' >" + ds.Tables[0].Rows[i][2].ToString() + "</a>";
                arrin.Clear();
                arrin.Add(ds.Tables[0].Rows[i][0]);
                arrin.Add(Session["RoleID"].ToString());
                arrin.Add(Session["LBType"].ToString());
                //arrin.Add(Session["Year"].ToString());

                //Modified by Rakhi S 03.08.2020
                //----------************************************//
                if (Session["Year"].ToString() != "21")
                {
                    arrin.Add(22);

                }
                else
                {
                    arrin.Add(Session["Year"].ToString());
                }
                //----------************************************//
                DataSet ds1 = new DataSet();
                ds1 = objCommon.Fetch("Sp_SelectSubMenu", CommandType.StoredProcedure, arrin);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    str1 = str1 + " <ul class='sub-menu children dropdown-menu' runat='server'>";
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (ds.Tables[0].Rows[i][0].ToString() != "15")
                        {
                            str1 = str1 + "<li class='menu-item-has-children active dropdown' style='font-size: 21px;font-family: Meera' ><i class='fa fa-book' runat='server'></i><a  href='" + ds1.Tables[0].Rows[j][2].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "' >" + ds1.Tables[0].Rows[j][1].ToString() + "</a>";


                            str1 = str1 + "</li>";
                        }
                        else
                        {
                            //str1 = str1 + "<li><i class='fa fa-book' runat='server'></i><a  href='" + ds1.Tables[0].Rows[j][2].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "' >" + ds1.Tables[0].Rows[j][1].ToString() + "</a>";
                            //str1 = str1 + "<li><i class='fa fa-book' runat='server'></i><a href='" + ds1.Tables[0].Rows[j][2].ToString() + "'> <i class='menu-icon fa fa-table'></i>" + ds1.Tables[0].Rows[j][1].ToString() + "</a>";
                            str1 = str1 + "<li><i class='fa fa-book' runat='server'></i> <a href='#'  class='dropdown-toggle' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'  > <i class='menu-icon fa fa-table'></i>" + ds1.Tables[0].Rows[j][1].ToString() + "</a>";
                
                            arrin.Clear();
                            //arrin.Add(ds.Tables[0].Rows[i][0]);
                            arrin.Add(ds1.Tables[0].Rows[j][0]);
                            arrin.Add(Session["RoleID"].ToString());
                            DataSet ds2 = new DataSet();
                            ds2= objCommon.Fetch("Sp_SelectSubsubMenu", CommandType.StoredProcedure, arrin);

                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                str1 = str1 + " <ul class='sub-menu children dropdown-menu' runat='server'>";
                                for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                                {
                                    str1 = str1 + " <li ><i class='fa fa-book' runat='server'></i> ";
                                    str1 = str1 + "<a  href='" + ds2.Tables[0].Rows[k][2].ToString() + "' id='hLink" + Convert.ToString(i + 1) + "' >" + ds2.Tables[0].Rows[k][1].ToString() + "</a>";
                                   str1 = str1 + "</li>";
                                }
                                str1 = str1 + "</ul>";

                            }
                            str1 = str1 + "</li>";
                        }

                       
                    }
                    str1 = str1 + "</ul>";
                }
                str1 = str1 + "</li>";
            }
     
        // str1 = str1 + "</ul>";

        drop.InnerHtml = str1;

    }
    
}
