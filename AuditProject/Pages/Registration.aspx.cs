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
public partial class Pages_Registration : System.Web.UI.Page
{
    CommonClass objcom = new CommonClass();

    GlobalClass gblObj = new GlobalClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            chkStatus();
            Filldata();
        }
      
    }
    public void chkStatus()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {

            if (Session["ApproveStatus"].ToString() == "1" || Session["ApproveStatus"].ToString() == "3")
            {
                Button1.Enabled = false;
            }
            else
            {

                Button1.Enabled = true;
            }
        }
        else if (Session["RoleID"].ToString() == "1")
        {
            if (Session["ApproveStatus"].ToString() == "1")
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }


    }
    public void ValueAssign()
    {
        intbirthapplicationhospitalaud.Text  =intbirthapplicationhospital.Text;
        intbirthapplicationdirectaud.Text =intbirthapplicationdirect.Text;
        intbirthcertwithintimelimitaud.Text =intbirthcertwithintimelimit.Text;
        intbirthcertaftertimelimitaud.Text =intbirthcertaftertimelimit.Text;
        chvbirthremarksaud.Text =chvbirthremarks.Text;
        intdeathapplicationhospitalaud.Text =intdeathapplicationhospital.Text;
        intdeathapplicationdirectaud.Text =intdeathapplicationdirect.Text;
        intdeathcertwithintimelimitaud.Text =intdeathcertwithintimelimit.Text;
        intdeathcertaftertimelimitaud.Text =intdeathcertaftertimelimit.Text;
        chvdeathremarksaud.Text =chvdeathremarks.Text;

        intmarriageapplicationaud.Text =intmarriageapplication.Text;
        intmarragecertwithintimelimitaud.Text =intmarragecertwithintimelimit.Text;
        intmarriagecertaftertimelimitaud.Text = intmarriagecertaftertimelimit.Text;
        chvmarriageremarksaud.Text = chvmarriageremarks.Text;
    }
    public void SetEditable()
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            intbirthapplicationhospital.ReadOnly = false;
            intbirthapplicationdirect.ReadOnly = false;
            intbirthcertwithintimelimit.ReadOnly = false;

            intbirthcertaftertimelimit.ReadOnly = false;
            chvbirthremarks.ReadOnly = false;
            intdeathapplicationhospital.ReadOnly = false;

            intdeathapplicationdirect.ReadOnly = false;
            intdeathcertwithintimelimit.ReadOnly = false;
            intdeathcertaftertimelimit.ReadOnly = false;

            chvdeathremarks.ReadOnly = false;
            intmarriageapplication.ReadOnly = false;
            intmarragecertwithintimelimit.ReadOnly = false;


            intmarriagecertaftertimelimit.ReadOnly = false;
            chvmarriageremarks.ReadOnly = false;
        }
        else
        {

            intbirthapplicationhospitalaud.ReadOnly = false;
            intbirthapplicationdirectaud.ReadOnly = false;
            intbirthcertwithintimelimitaud.ReadOnly = false;
            intbirthcertaftertimelimitaud.ReadOnly = false;
            chvbirthremarksaud.ReadOnly = false;
            intdeathapplicationhospitalaud.ReadOnly = false;
            intdeathapplicationdirectaud.ReadOnly = false;

            intdeathcertwithintimelimitaud.ReadOnly = false;
            intdeathcertaftertimelimitaud.ReadOnly = false;
            chvdeathremarksaud.ReadOnly = false;

            intmarriageapplicationaud.ReadOnly = false;
            intmarragecertwithintimelimitaud.ReadOnly = false;
            intmarriagecertaftertimelimitaud.ReadOnly = false;
            chvmarriageremarksaud.ReadOnly = false;
        }
    }
    //public void ValueAssign()
    //{

      


    //    intbirthapplicationhospitalaud.Text =    intbirthapplicationhospital.Text;
    //    intbirthapplicationdirectaud.Text =  intbirthapplicationdirect.Text;
    //    intbirthcertwithintimelimitaud.Text =   intbirthcertwithintimelimit.Text;
    //    intbirthcertaftertimelimitaud.Text = intbirthcertaftertimelimit.Text;
    //    chvbirthremarksaud.Text = chvbirthremarks.Text;
    //    intdeathapplicationhospitalaud.Text =  intdeathapplicationhospital.Text;
    //    intdeathapplicationdirectaud.Text = intdeathapplicationdirect.Text;

    //    intdeathcertwithintimelimitaud.Text = intdeathcertwithintimelimit.Text;
    //    intdeathcertaftertimelimitaud.Text =  intdeathcertaftertimelimit.Text;
    //    chvdeathremarksaud.Text =  chvdeathremarks.Text;

    //    intmarriageapplicationaud.Text =  intmarriageapplication.Text;
    //    intmarragecertwithintimelimitaud.Text =  intmarragecertwithintimelimit.Text;
    //    intmarriagecertaftertimelimitaud.Text = intmarriagecertaftertimelimit.Text;
    //    chvmarriageremarksaud.Text = chvmarriageremarks.Text;
    //}
    public void Filldata()
    {
        ArrayList arrFill = new ArrayList();

        arrFill.Clear();
        arrFill.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrFill.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]
        DataSet dsFill = objcom.FillData("SP_tb_regstration_Sel", arrFill, CommandType.StoredProcedure);
        if (dsFill.Tables[0].Rows.Count > 0)
        {
            lblnum.Text = dsFill.Tables[0].Rows[0].ItemArray[1].ToString();
            intbirthapplicationhospital.Text = dsFill.Tables[0].Rows[0].ItemArray[2].ToString();
            intbirthapplicationdirect.Text = dsFill.Tables[0].Rows[0].ItemArray[3].ToString();
            intbirthcertwithintimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[4].ToString();

            intbirthcertaftertimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[5].ToString();
            chvbirthremarks.Text = dsFill.Tables[0].Rows[0].ItemArray[6].ToString();
            intdeathapplicationhospital.Text = dsFill.Tables[0].Rows[0].ItemArray[7].ToString();

            intdeathapplicationdirect.Text = dsFill.Tables[0].Rows[0].ItemArray[8].ToString();
            intdeathcertwithintimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[9].ToString();
            intdeathcertaftertimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[10].ToString();

            chvdeathremarks.Text = dsFill.Tables[0].Rows[0].ItemArray[11].ToString();
            intmarriageapplication.Text = dsFill.Tables[0].Rows[0].ItemArray[12].ToString();
            intmarragecertwithintimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[13].ToString();


            intmarriagecertaftertimelimit.Text = dsFill.Tables[0].Rows[0].ItemArray[14].ToString();
            chvmarriageremarks.Text = dsFill.Tables[0].Rows[0].ItemArray[15].ToString();
            intbirthapplicationhospitalaud.Text = dsFill.Tables[0].Rows[0].ItemArray[16].ToString();
            intbirthapplicationdirectaud.Text = dsFill.Tables[0].Rows[0].ItemArray[17].ToString();
            intbirthcertwithintimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[18].ToString();
            intbirthcertaftertimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[19].ToString();
            chvbirthremarksaud.Text = dsFill.Tables[0].Rows[0].ItemArray[20].ToString();
            intdeathapplicationhospitalaud.Text = dsFill.Tables[0].Rows[0].ItemArray[21].ToString();
            intdeathapplicationdirectaud.Text = dsFill.Tables[0].Rows[0].ItemArray[22].ToString();

            intdeathcertwithintimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[23].ToString();
            intdeathcertaftertimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[24].ToString();
            chvdeathremarksaud.Text = dsFill.Tables[0].Rows[0].ItemArray[25].ToString();

            intmarriageapplicationaud.Text = dsFill.Tables[0].Rows[0].ItemArray[26].ToString();
            intmarragecertwithintimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[27].ToString();
            intmarriagecertaftertimelimitaud.Text = dsFill.Tables[0].Rows[0].ItemArray[28].ToString();
            chvmarriageremarksaud.Text = dsFill.Tables[0].Rows[0].ItemArray[29].ToString();


           
        }
        SetEditable();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "4")
        {
            ValueAssign();
        }

        SaveRegistration();
        Filldata();
    }
    public void SaveRegistration()
    {
        DataSet ds = new DataSet();
        CommonClass objcomm = new CommonClass();
        ArrayList arrIn = new ArrayList();

        if (lblnum.Text != "")
        {
            arrIn.Add(lblnum.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        arrIn.Add(Convert.ToInt32(Session["LBID"])); //Session["LBID"]
        arrIn.Add(Convert.ToInt32(Session["Year"])); //Session["Year"]

        if (intbirthapplicationhospital.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intbirthapplicationhospital.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }

        if (intbirthapplicationdirect.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intbirthapplicationdirect.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }



        if (intbirthcertwithintimelimit.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intbirthcertwithintimelimit.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (intbirthcertaftertimelimit.Text != "")
        {
            arrIn.Add(Convert.ToInt32(intbirthcertaftertimelimit.Text));
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
        if (chvbirthremarks.Text != "")
        {
            arrIn.Add(chvbirthremarks.Text);
        }
        else
        {
            arrIn.Add(DBNull.Value);
        }
            if (intbirthapplicationhospitalaud.Text != "")
            {

                arrIn.Add(Convert.ToInt32(intbirthapplicationhospitalaud.Text));
            }
            else
            {
                arrIn.Add(DBNull.Value);
            }
                if (intbirthapplicationdirectaud.Text != "")
                {
                    arrIn.Add(Convert.ToInt32(intbirthapplicationdirectaud.Text));
                }
                else
                {
                    arrIn.Add(DBNull.Value);
                
                   
                }
                    if (intbirthcertwithintimelimitaud.Text != "")
                    {
                        arrIn.Add(Convert.ToInt32(intbirthcertwithintimelimitaud.Text));
                    }
                    else
                    {
                        arrIn.Add(DBNull.Value);
                       
                    }
                        if (intbirthcertaftertimelimitaud.Text != "")
                        {
                            arrIn.Add(Convert.ToInt32(intbirthcertaftertimelimitaud.Text));
                        }
                        else
                        {
                            arrIn.Add(DBNull.Value);
                           
                        }
                            if (chvbirthremarksaud .Text != "")
                            {
                                arrIn.Add(chvbirthremarksaud.Text);
                            }
                            else
                            {
                                arrIn.Add(DBNull.Value);
                              
                            }


                            if (intdeathapplicationhospital.Text != "")
                            {
                                arrIn.Add(Convert.ToInt32(intdeathapplicationhospital.Text));
                            }
                            else
                            {
                                arrIn.Add(DBNull.Value);
                            }
                            if (intdeathapplicationdirect.Text != "")
                            {
                                arrIn.Add(Convert.ToInt32(intdeathapplicationdirect.Text));
                            }
                            else
                            {
                                arrIn.Add(DBNull.Value);
                            }
                            if (intdeathcertwithintimelimit.Text != "")
                            {
                                arrIn.Add(Convert.ToInt32(intdeathcertwithintimelimit.Text));
                            }
                            else
                            {
                                arrIn.Add(DBNull.Value);
                            }
                                if (intdeathcertaftertimelimit.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intdeathcertaftertimelimit.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (chvdeathremarks.Text != "")
                                {
                                    arrIn.Add(chvdeathremarks.Text);
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (intdeathapplicationhospitalaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intdeathapplicationhospitalaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                   
                                }
                                if (intdeathapplicationdirectaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intdeathapplicationdirectaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                   
                                }
                                if (intdeathcertwithintimelimitaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intdeathcertwithintimelimitaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (intdeathcertaftertimelimitaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intdeathcertaftertimelimitaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                    
                                }
                                if (chvdeathremarksaud.Text != "")
                                {
                                    arrIn.Add(chvdeathremarksaud.Text);
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                   
                                }






                                if (intmarriageapplication.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarriageapplication.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (intmarragecertwithintimelimit.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarragecertwithintimelimit.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (intmarriagecertaftertimelimit.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarriagecertaftertimelimit.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);

                                }
                                if (chvmarriageremarks.Text != "")
                                {
                                    arrIn.Add(chvmarriageremarks .Text);
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (intmarriageapplicationaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarriageapplicationaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                    
                                }
                                if (intmarragecertwithintimelimitaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarragecertwithintimelimitaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                  
                                }
                                if (intmarriagecertaftertimelimitaud.Text != "")
                                {
                                    arrIn.Add(Convert.ToInt32(intmarriagecertaftertimelimitaud.Text));
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                }
                                if (chvmarriageremarksaud.Text != "")
                                {
                                    arrIn.Add(chvmarriageremarksaud .Text);
                                }
                                else
                                {
                                    arrIn.Add(DBNull.Value);
                                   
                                }


                                arrIn.Add(Convert.ToInt64(Session["UserID"]));////@numUserentry numeric(18,0) ,
                                arrIn.Add(Convert.ToInt64(Session["SeatID"]));////@numSeatentry  numeric(18,0) 
                                arrIn.Add(1);

                                int row = objcomm.update("SP_tb_regstration_IU", arrIn);
                                if (row > 0)
                                {
                                    gblObj.MsgBoxOk("Saved Successfully ", this);
                                }
       }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Crematorium.aspx");
    }
    protected void btnNxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("PensionDetails.aspx");
    }
}
