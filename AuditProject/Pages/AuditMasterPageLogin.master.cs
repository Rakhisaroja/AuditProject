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

public partial class Pages_AuditMasterPageLogin : System.Web.UI.MasterPage
{
    CommonClass objCom = new CommonClass();
    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                     
            Session["Flag"] = 0;
            fillYear();
            
        }
    }
    public void fillYear()
    {
        DataSet dsYear = new DataSet();
        dsYear = objCom.FillData("SP_TB_YEAR_MST_S", CommandType.StoredProcedure);
        gblObj.FillCombo(ddYear, dsYear, 1);
        
        
    }
   
    protected bool validations()
    {
        if (username1.Text == "")
        {
            //MsgPanel.Visible = true;
            lblMessage.Text = "യൂസര്‍ ഐഡി രേഖപ്പെടുത്തുക ";
            return true;
        }

        if (password1.Text == "")
        {
            //MsgPanel.Visible = true;
            lblMessage.Text = "പാസ് വേഡ് രേഖപ്പെടുത്തുക";
            return true;
        }
        if (ddYear.SelectedIndex <= 0)
        {
            lblMessage.Text = "വര്‍ഷം തിരഞ്ഞെടുക്കുക";
            return true;
        }
        return false;
    
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        //  if ((txtLogin.Text == "14461") && (txtpswd.Text == "16191"))//(txtLogin.Text == "1") && (txtpswd.Text == "1"))//
        //{
        //    Session["UserID"] = txtLogin.Text;
        //    Response.Redirect("LBwiseDetailsforTesting.aspx");
        //}
        //if ((username1.Text == "80374") && (password1.Text == "123"))//(txtLogin.Text == "1") && (txtpswd.Text == "1"))//
        //{

        //    Session["LoggedInUser"] = username1.Text.ToString();
        //    //Session["Password"] = txtpswd.Text.ToString();
        //    Session["UserID"] = "80374".ToString();
        //    Session["WardID"] = null;
        //    Session["Year"] = "21";
        //    Session["UserName"] = "S Prem".ToString();
        //    Session["UserType"] = "1".ToString();
        //    Session["UserDesig"] = "LB Secretary".ToString();
        //    Session["UserRole"] = "2".ToString();
        //    Session["LBID"] = "276".ToString();
        //    //Session["LBIDLogin"] = dstable.Tables[0].Rows[LoginIndex][3].ToString();
        //    //Session["UserStatus"] = dstable.Tables[0].Rows[LoginIndex][0].ToString();
        //    //Session["SeatStatus"] = dstable.Tables[0].Rows[LoginIndex][12].ToString();
        //    //Session["RoleStatus"] = dstable.Tables[0].Rows[LoginIndex][13].ToString();
        //    Session["SeatID"] = "5027601002".ToString();
        //    ArrayList arr = new ArrayList();
        //    arr.Add(Session["LBID"]);
        //    DataSet LB = new DataSet();
        //    CommonClass objcom = new CommonClass();
        //    LB = objcom.FillData("SP_TBLBSelection_CS", arr, CommandType.StoredProcedure);
        //    Session["LBNAME"] = LB.Tables[0].Rows[0][0].ToString() + LB.Tables[0].Rows[0][1].ToString();
        //    LB.Clear();
        //    arr.Clear();
        //    Session["LBTYPE"] = "5".ToString();
        //    Session["LBTYPELogin"] = "1".ToString();
        //    //["WardID"] = 2;
        //    Session["RoleID"] = "2".ToString();
        //    if (Session["UserID"] != null || int.Parse(Session["UserID"].ToString()) != 0)
        //    {

        //        ArrayList Arrin = new ArrayList();
        //        DataSet ds_usr = new DataSet();
        //        Arrin.Clear();
        //        Arrin.Add(Session["LBID"]);
        //        Arrin.Add(Convert.ToInt64(Session["UserID"].ToString()));   //@numUserId
        //        ds_usr = objcom.FillData("[SP_CheckUserLoggedStatus]", Arrin, CommandType.StoredProcedure);
        //        if (ds_usr.Tables[0].Rows[0][0].ToString() != "")
        //        {
        //            //SaveUserDetails(dstable);
        //            //SaveUserLog();
        //            Response.Redirect("Home.aspx");
        //        }
        //        else
        //        {
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "User has already logged in somewhere else";
        //        }
        //    }
        //}
        //else if ((username1.Text == "167247") && (password1.Text == "123"))//(txtLogin.Text == "1") && (txtpswd.Text == "1"))//
        //{

        //    Session["LoggedInUser"] = username1.Text.ToString();
        //    //Session["Password"] = txtpswd.Text.ToString();
        //    Session["UserID"] = "167247".ToString();
        //    Session["WardID"] = null;
        //    Session["Year"] = "21";
        //    Session["UserName"] = "Arunkumar S".ToString();
        //    Session["UserType"] = "84".ToString();
        //    Session["UserDesig"] = "Deputy Director of Panchayat In charge".ToString();
        //    Session["UserRole"] = "1".ToString();
        //    Session["LBID"] = "5000".ToString();
        //    //Session["LBIDLogin"] = dstable.Tables[0].Rows[LoginIndex][3].ToString();
        //    //Session["UserStatus"] = dstable.Tables[0].Rows[LoginIndex][0].ToString();
        //    //Session["SeatStatus"] = dstable.Tables[0].Rows[LoginIndex][12].ToString();
        //    //Session["RoleStatus"] = dstable.Tables[0].Rows[LoginIndex][13].ToString();
        //    Session["SeatID"] = "6500000001004".ToString();
        //    ArrayList arr = new ArrayList();
        //    arr.Add(Session["LBID"]);
        //    DataSet LB = new DataSet();
        //    CommonClass objcom = new CommonClass();
        //    LB = objcom.FillData("SP_TBLBSelection_CS", arr, CommandType.StoredProcedure);
        //    Session["LBNAME"] = LB.Tables[0].Rows[0][0].ToString() + LB.Tables[0].Rows[0][1].ToString();
        //    LB.Clear();
        //    arr.Clear();
        //    Session["LBTYPE"] = "6".ToString();
        //    Session["LBTYPELogin"] = "1".ToString();
        //    //["WardID"] = 2;
        //    Session["unitID"] = "6500000201"; 
        //    Session["RoleID"] = "1".ToString();
        //    if (Session["UserID"] != null || int.Parse(Session["UserID"].ToString()) != 0)
        //    {

        //        ArrayList Arrin = new ArrayList();
        //        DataSet ds_usr = new DataSet();
        //        Arrin.Clear();
        //        Arrin.Add(Session["LBID"]);
        //        Arrin.Add(Convert.ToInt64(Session["UserID"].ToString()));   //@numUserId
        //        ds_usr = objcom.FillData("[SP_CheckUserLoggedStatus]", Arrin, CommandType.StoredProcedure);
        //        if (ds_usr.Tables[0].Rows[0][0].ToString() != "")
        //        {
        //            //SaveUserDetails(dstable);
        //            //SaveUserLog();
        //            Response.Redirect("Home.aspx");
        //        }
        //        else
        //        {
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "User has already logged in somewhere else";
        //            lnkLogoff.Visible = true;
        //        }
        //    }
        //}
        //else
        //{
            string data;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            int LoginIndex = 0;
            CommonClass objCommon = new CommonClass();
            DataSet ds_usr = new DataSet();
            //LoginBAL objLoginStatusBAL = new LoginBAL();
            //LoginDAL objLoginStatusDAL = new LoginDAL();
            //LoginReference.Service objService = new LoginReference.Service();
            LoginReference.Service objService = new LoginReference.Service();
            string webUrlString = ConfigurationManager.AppSettings["LoginReference.service"];
            string Password = password1.Text.ToString();
            //string FinancialYear = ddYear.SelectedValue.ToString();

            objService.Url = webUrlString;
            data = objService.CheckUserLogin(username1.Text, Password, "126", "1");
            
            if (data != "")
            {
                DataSet dstable = new DataSet();
                DataSet dsward = new DataSet();
                //string xmlstring = httpResponse;
                StringReader theReader = new StringReader(data);
                dstable.ReadXml(theReader);
                if (dstable.Tables[0].Rows.Count > 0)
                {

                    if (dstable.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        if (dstable.Tables[0].Rows[0][13].ToString() == "1" || dstable.Tables[0].Rows[0][10].ToString() == "10" || dstable.Tables[0].Rows[0][10].ToString() == "11" || dstable.Tables[0].Rows[0][10].ToString() == "31" || dstable.Tables[0].Rows[0][10].ToString() == "5" || dstable.Tables[0].Rows[0][10].ToString() == "85" || dstable.Tables[0].Rows[0][10].ToString() == "32") //role active(1) or deactive(0)
                        {
                            Session["LoggedInUser"] = username1.Text.ToString();
                            //Session["Password"] = txtpswd.Text.ToString();
                            Session["UserID"] = dstable.Tables[0].Rows[LoginIndex][2].ToString();



                            if ((dstable.Tables[0].Rows[0][17].ToString() == "2" || dstable.Tables[0].Rows[0][17].ToString() == "1" || dstable.Tables[0].Rows[0][17].ToString() == "3" || dstable.Tables[0].Rows[0][10].ToString() == "10" || dstable.Tables[0].Rows[0][10].ToString() == "11" || dstable.Tables[0].Rows[0][10].ToString() == "31" || dstable.Tables[0].Rows[0][10].ToString() == "85" || dstable.Tables[0].Rows[0][10].ToString() == "32" || dstable.Tables[0].Rows[0][10].ToString() == "5" || dstable.Tables[0].Rows[0][17].ToString() == "4"))
                            {
                                Session["Rpt"] = "";
                                Session["UserName"] = dstable.Tables[0].Rows[LoginIndex][8].ToString();
                                Session["UserType"] = dstable.Tables[0].Rows[LoginIndex][10].ToString();
                                Session["UserDesig"] = dstable.Tables[0].Rows[LoginIndex][9].ToString();
                                Session["UserRole"] = dstable.Tables[0].Rows[LoginIndex][17].ToString();
                                Session["LBID"] = dstable.Tables[0].Rows[LoginIndex][3].ToString();
                                Session["LBIDLogin"] = dstable.Tables[0].Rows[LoginIndex][3].ToString();
                                Session["UserStatus"] = dstable.Tables[0].Rows[LoginIndex][0].ToString();
                                Session["SeatStatus"] = dstable.Tables[0].Rows[LoginIndex][12].ToString();
                                Session["RoleStatus"] = dstable.Tables[0].Rows[LoginIndex][13].ToString();
                                Session["SeatID"] = dstable.Tables[0].Rows[LoginIndex][14].ToString();
                                Session["Year"] = ddYear.SelectedValue;//"21";
                                Session["FinYear"] = Convert.ToInt32(ddYear.SelectedValue) + 1996;
                                Session["RoleID"] = dstable.Tables[0].Rows[0][17].ToString();
                                Session["DistID"] = dstable.Tables[0].Rows[0][23].ToString();
                                Session["unitID"] = dstable.Tables[0].Rows[0][6].ToString(); //"6500000218";//
                                Session["Unit"] = dstable.Tables[0].Rows[0][5].ToString();
                                Session["LBType"] = dstable.Tables[0].Rows[0][4].ToString();
                                Session["YearSetting"] = ddYear.SelectedItem.Text;

                                //Rakhi S 20.08.2020 
                                //if (Session["Year"].ToString() == "21" || Session["Year"].ToString() == "22" || Session["Year"].ToString() == "23")
                                if (Session["Year"].ToString() != "0")//|| Session["Year"].ToString() == "22" || Session["Year"].ToString() == "23")
                                {
                                    if (Session["UserID"] != null || int.Parse(Session["UserID"].ToString()) != 0)
                                    {
                                        ArrayList arr = new ArrayList();
                                        CommonClass objcom = new CommonClass();
                                        arr.Add(Session["LBID"]);
                                        DataSet LB = new DataSet();
                                        LB = objcom.FillData("SP_TBLBSelection_CS", arr, CommandType.StoredProcedure);
                                        if (LB.Tables[0].Rows.Count > 0)
                                        {
                                            Session["LBNAME"] = LB.Tables[0].Rows[0][0].ToString() + LB.Tables[0].Rows[0][1].ToString();
                                        }
                                        // Session["DistID"] = LB.Tables[0].Rows[0][4].ToString();
                                        LB.Clear();
                                        arr.Clear();

                                        ArrayList Arrin = new ArrayList();
                                        //DataSet ds_usr = new DataSet();
                                        Arrin.Clear();
                                        Arrin.Add(Convert.ToInt64(Session["UserID"].ToString()));   //@numUserId
                                        Arrin.Add(Convert.ToInt32(Session["LBID"].ToString()));   //@numUserId
                                        ds_usr = objCommon.FillData("[SP_CheckUserLoggedStatus]", Arrin, CommandType.StoredProcedure);
                                        if ((ds_usr.Tables[0].Rows[0][0].ToString() != "" && Session["RoleID"].ToString() != "3" && Session["UserType"].ToString() != "10" && Session["UserType"].ToString() != "31" && Session["UserType"].ToString() != "32" && Session["UserType"].ToString() != "5") && Session["UserType"].ToString() != "85" && Session["UserType"].ToString() != "11" || Session["UserType"].ToString() == "79")
                                        {
                                            SaveUserDetails(dstable);
                                            SaveUserLog();
                                            //chkStatus();
                                            Response.Redirect("Home.aspx");
                                        }
                                        else if (ds_usr.Tables[0].Rows[0][0].ToString() != "" && (Session["UserType"].ToString() == "10" || Session["UserType"].ToString() == "31" || Session["UserType"].ToString() == "32" || Session["UserType"].ToString() == "5" || Session["UserType"].ToString() == "85" || Session["UserType"].ToString() == "11"))
                                        {
                                            SaveUserDetails(dstable);
                                            SaveUserLog();
                                            //chkStatus();
                                            //Session["numUnitID"] = dstable.Tables[0].Rows[0][6].ToString();
                                            //Session["UnitCode"] = dstable.Tables[0].Rows[0][6].ToString();
                                            Response.Redirect("DistWiseAuditStatus.aspx");
                                        }
                                        else if (ds_usr.Tables[0].Rows[0][0].ToString() != "" && Session["RoleID"].ToString() == "3")
                                        {
                                            SaveUserDetails(dstable);
                                            SaveUserLog();
                                            //chkStatus();
                                            Response.Redirect("Dashboad.aspx");
                                        }
                                        else
                                        {
                                            lblMessage.Visible = true;
                                            lblMessage.Text = "User has already logged in somewhere else";
                                            lnkLogoff.Visible = true;
                                        }
                                    }
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "ശരിയായ വര്‍ഷം രേഖപ്പെടുത്തുക";
                                }
                            }
                            else
                            {
                                if (dstable.Tables[0].Rows[0][17].ToString() == "0")
                                {
                                    //lblMessage.Visible = true;
                                    //lblMessage.Text = "Add suite Sakarma to the Secretary";
                                }
                                else
                                {
                                    //lblMessage.Visible = true;
                                    //lblMessage.Text = "Ward has not been assigned by Secretary";
                                }
                            }
                        }
                        else
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "User has no Role in Audit";
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "User inactive";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "ശരിയായ യൂസര്‍ ഐഡി / പാസ് വേഡ് രേഖപ്പെടുത്തുക";
                }
            }
      // }
    
    }

   
    private void SaveUserDetails(DataSet dstable)
    {
        // string data;
        int LoginIndex = 0;
        CommonClass objCommon = new CommonClass();
        //DefaultLoginBAL objDefaultLoginBAL = new DefaultLoginBAL();
        //DefaultLoginDAL objDefaultLoginDAL = new DefaultLoginDAL();
        //UserDetailsBAL objUserDetailsBAL = new UserDetailsBAL();
        //UserDetailsDAL objUserDetailsDAL = new UserDetailsDAL();
        //LoginReference.Service objService = new LoginReference.Service();
        //string webUrlString = ConfigurationManager.AppSettings["LoginReference.Service"];
        //string Password = txtpswd.Text.ToString();
        //objService.Url = webUrlString;
        // data = objService.CheckUserLogin(txtLogin.Text, Password, "108", "1");
        //if (data != "")
        //{
        //DataSet dstable = new DataSet();

        //StringReader theReader = new StringReader(data);
        //dstable.ReadXml(theReader);
        int rowsaffted = 0;
        ArrayList Arrlist = new ArrayList();
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][2]);                               ////@numUserId 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][3]);                                 ////@intLBID 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][4]);                                 ////@intLBTypeID 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][8].ToString());                                 ////@chvFullName   [nvarchar](max), 
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][9].ToString());                                 ////@chvDesignation [nvarchar](max), 
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][10]);                                 ////@intUserType 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][11]);                                 ////@intFirstLogin 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][12]);                                 ////@seatstatus 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][13]);                                 ////@rolestatus 	[int],
        if (dstable.Tables[0].Rows[LoginIndex][14] == null || dstable.Tables[0].Rows[LoginIndex][14].ToString()=="")
        {
            Arrlist.Add(0);
        }
        else
        {
            Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][14]);                                 ////@numSeatID 	[int],
        }
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][16]);                                 ////@intSuiteID 	[int],
        Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][17]);                                 ////@intRoleID 	[int],
        if (dstable.Tables[0].Rows[LoginIndex][19].ToString() == "")
        {
            Arrlist.Add(DBNull.Value);
        }
        else
        {
            Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][19].ToString());                      ////@chvMobile  [varchar] (50),    
        }
        if (dstable.Tables[0].Rows[LoginIndex][20].ToString() == "")
        {
            Arrlist.Add(DBNull.Value);
        }
        else
        {
            Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][20].ToString());                  ////@chvMail [varchar](50), 
        }
        if (dstable.Tables[0].Rows[LoginIndex][21].ToString() == "")
        {
            Arrlist.Add(DBNull.Value);
        }
        else
        {
            Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][21].ToString());                                 ////@chvUserName [nvarchar](max), 
        }
        if (dstable.Tables[0].Rows[LoginIndex][22].ToString() == "")
        {
            Arrlist.Add(DBNull.Value);
        }
        else
        {
            Arrlist.Add(dstable.Tables[0].Rows[LoginIndex][22].ToString());                                 ////@chvUnitname  [varchar](50)
        }
     
            Arrlist.Add(DBNull.Value);
        
        if (dstable.Tables[0].Rows[LoginIndex][0].ToString() == "")
        {
            Arrlist.Add(DBNull.Value);
        }
        else
        {
            Arrlist.Add(Convert.ToInt32(dstable.Tables[0].Rows[LoginIndex][0].ToString()));                                 ////@intStatus int
        }
        rowsaffted = objCommon.update("SP_TB_LoggedinDetails_Update", Arrlist);

        //
        //}

    }

    private void SaveUserLog()
    {
         ClassLogin1 objLogin = new ClassLogin1();
        ClassGlobal objGloabal = new ClassGlobal();
        String BrowserType;
        BrowserType = Request.Browser.Browser + " " + Request.Browser.MajorVersion + " " + Request.Browser.MinorVersion;
        ArrayList Arrin = new ArrayList();
        Arrin.Add(Convert.ToDouble(Session["UserID"].ToString()));
        Arrin.Add(GetIPAddress1());
        Arrin.Add(Session.SessionID);
        Arrin.Add(BrowserType);
        Arrin.Add(Convert.ToInt32(Session["LBID"].ToString()));
        objGloabal.UserLogID = objLogin.SaveUserLog(Arrin);
        Session["NumSessionID"] = objGloabal.UserLogID;
        Arrin.Clear();
    }
    private String getIPAddress()
    {
        String clientIPAddress;
        string[] computer_name = new string[10];
        computer_name = System.Net.Dns.Resolve(Request.ServerVariables["remote_addr"]).HostName.Split('.');
        if (computer_name[0].ToString() == "localhost")
        {
            string strHostName = System.Net.Dns.GetHostName();
            clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
        }
        else
        {
            clientIPAddress = Request.UserHostAddress.ToString();
            // Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        return clientIPAddress;
    }

    protected string GetIPAddress1()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

        ////if (validations() == true)
        ////{
        ////    return;
        ////}
      
        ////ArrayList arrIn = new ArrayList();
        ////arrIn.Add(UserName.Text.Trim());
        ////arrIn.Add(Password.Text.Trim());
        ////DataSet dsn = new DataSet();
        ////CommonClass objCommon = new CommonClass();
        ////dsn = objCommon.FillData("[GR_SP_TB_AdminUser_Select]", arrIn, CommandType.StoredProcedure);
        ////if (dsn.Tables[0].Rows.Count > 0)
        ////{
        ////    if ((UserName.Text.Trim() == dsn.Tables[0].Rows[0][1].ToString()) && (Password.Text.Trim() == dsn.Tables[0].Rows[0][2].ToString()))
        ////    {
        ////        Session["PUserID"] = "0";
        ////        Session["UserType"] = "100";
        ////        Session["UserName"] = "Admin";
        ////        Session["DistID"] = "0";
        ////        Session["LBID"] = "0";
        ////        Session["WardNo"] = "";
        ////        Session["MemberID"] = "";
        ////        Session["CandidateID"] = "";
        ////        if (Session["PUserID"] != null || int.Parse(Session["UserID"].ToString()) != 0)
        ////        {

        ////            DataSet ds_usr = new DataSet();
        ////            LoginBAL objLoginStatusBAL = new LoginBAL();
        ////            LoginDAL objLoginStatusDAL = new LoginDAL();
        ////            objLoginStatusBAL.NUMPUSERID = Convert.ToInt64(Session["PUserID"].ToString());
        ////            ds_usr = objLoginStatusDAL.GetLoginStatus(objLoginStatusBAL);
        ////            if (ds_usr.Tables[0].Rows[0][0].ToString() != "")
        ////            {
        ////                SaveUserLog();
        ////                Response.Redirect("Home.aspx");
        ////            }
        ////            else
        ////            {
        ////                lblError.Visible = true;
        ////                lblError.Text = "Another user has already been logged in another instance (Window/Tab) of this browser";
        ////                lnkLogoff.Visible = true;

        ////            }
        ////        }
        ////    }
        ////}
        ////else
        ////{
        ////    LoginBAL objLoginBAL = new LoginBAL();
        ////    LoginDAL objLoginDAL = new LoginDAL();
        ////    objLoginBAL.CHVUSERNAME = UserName.Text.Trim();
        ////    objLoginBAL.CHVPASSWORD = Password.Text.Trim();
        ////    DataSet ds = new DataSet();
        ////    ds = objLoginDAL.GetLogin(objLoginBAL);
        ////    if (ds.Tables[0].Rows.Count > 0)
        ////    {
        ////        if ((UserName.Text.Trim() == ds.Tables[0].Rows[0][8].ToString()) && (Password.Text.Trim() == ds.Tables[0].Rows[0][9].ToString()))
        ////        {
        ////            Session["PUserID"] = ds.Tables[0].Rows[0][1].ToString();
        ////            Session["UserType"] = ds.Tables[0].Rows[0][0].ToString();
        ////            Session["UserName"] = ds.Tables[0].Rows[0][2].ToString();
        ////            Session["DistID"] = ds.Tables[0].Rows[0][4].ToString();
        ////            Session["LBID"] = ds.Tables[0].Rows[0][5].ToString();
        ////            Session["WardNo"] = ds.Tables[0].Rows[0][6].ToString();
        ////            Session["MemberID"] = ds.Tables[0].Rows[0][7].ToString();
        ////            Session["LoginName"] = ds.Tables[0].Rows[0][8].ToString();
        ////            Session["CandidateID"] = ds.Tables[0].Rows[0][10].ToString();
        ////            // Response.Redirect("Home.aspx");
        ////            if (Session["PUserID"] != null || int.Parse(Session["UserID"].ToString()) != 0)
        ////            {

        ////                DataSet ds_usr = new DataSet();
        ////                LoginBAL objLoginStatusBAL = new LoginBAL();
        ////                LoginDAL objLoginStatusDAL = new LoginDAL();
        ////                objLoginStatusBAL.NUMPUSERID = Convert.ToInt64(Session["PUserID"].ToString());
        ////                ds_usr = objLoginStatusDAL.GetLoginStatus(objLoginStatusBAL);
        ////                if (ds_usr.Tables[0].Rows[0][0].ToString() != "")
        ////                {
        ////                    SaveUserLog();
        ////                    Response.Redirect("Home.aspx");
        ////                }
        ////                else
        ////                {
        ////                    lblError.Visible = true;
        ////                    lblError.Text = "Another user has already been logged in another instance (Window/Tab) of this browser";
        ////                    lnkLogoff.Visible = true;

        ////                }
        ////            }
        ////        }
        ////        else
        ////        {
        ////            Clear();
        ////            lblError.Visible = true;
        ////            lblError.Text = "ശരിയായ യൂസര്‍ ഐഡി / പാസ് വേഡ് രേഖപ്പെടുത്തുക";
        ////        }

        ////    }
        ////    else
        ////    {
        ////        Clear();
        ////        lblError.Visible = true;
        ////        lblError.Text = "ശരിയായ യൂസര്‍ ഐഡി / പാസ് വേഡ് രേഖപ്പെടുത്തുക";
        ////    }
        ////}
    public void SaveLogout()
    {
        ClassLogin objLogin = new ClassLogin();
        ClassGlobal objGloabal = new ClassGlobal();
        ArrayList Arrin = new ArrayList();

        Arrin.Add(Convert.ToInt64(Session["UserID"].ToString()));   //@numUserId
        Arrin.Add(Convert.ToInt64(Session["NumSessionID"]));
        // Arrin.Add(Session.SessionID);                               // @numSessionID
        Arrin.Add(1);                                     //@tnyStatus
        Arrin.Add(Convert.ToInt32(Session["LBID"].ToString()));
        //objGloabal.UserLogID = objLogin.SaveLogout(Arrin);
        objGloabal.UserLogID = objLogin.SaveLogout(Arrin);
        Session["NumSessionID"] = null;
        Session.Clear();
        Arrin.Clear();

        //Session.Clear();
        Response.Redirect("Login.aspx");
    }
    protected void lnkLogoff_Click(object sender, EventArgs e)
    {
        lnkLogoff.Visible = false;
        SaveLogout();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
