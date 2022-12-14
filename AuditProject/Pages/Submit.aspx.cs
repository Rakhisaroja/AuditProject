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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UnicodeToMalayalam;

using System.Collections.Generic;



public partial class Submit : System.Web.UI.Page
{
    GlobalClass clsObj = new GlobalClass();
 
    UnicodeTOMal objMal1 = new UnicodeTOMal();


    static String fontpath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Fonts\\MLRV0NTT.TTF";
    static BaseFont mal = iTextSharp.text.pdf.BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    Font fontmal = new Font(mal, 12, Font.NORMAL, CMYKColor.BLACK);
    Font fontmalRemark = new Font(mal, 12, Font.ITALIC, CMYKColor.BLACK);
    static String fontpath1 = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Fonts\\MLRV0NTT.TTF";
    static BaseFont mal1 = iTextSharp.text.pdf.BaseFont.CreateFont(fontpath1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    Font fontmalhead = new Font(mal1, 13, Font.BOLD, CMYKColor.BLACK);
    static String fontpath2 = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Fonts\\MLRV0NTT.TTF";
    static BaseFont mal2 = iTextSharp.text.pdf.BaseFont.CreateFont(fontpath2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    Font fontmalheadsub = new Font(mal2, 15, Font.BOLD, CMYKColor.BLACK);
    Font fontmalheadmain = new Font(mal, 18, Font.BOLDITALIC, CMYKColor.BLACK);
    Font titleFont = FontFactory.GetFont("Courier", 14, Font.BOLD, CMYKColor.BLACK);
    Font EngFontBold = FontFactory.GetFont("Courier", 12, Font.BOLD, CMYKColor.BLACK);
    Font EngFont = FontFactory.GetFont("Courier", 12, Font.NORMAL, CMYKColor.BLACK);

    Font EngFontRemark = FontFactory.GetFont("Courier", 12, Font.ITALIC, CMYKColor.BLACK);
    Font EngFont1 = FontFactory.GetFont("AnjaliOldLipi", 12, Font.NORMAL, CMYKColor.BLACK);
    Font EngFontU = FontFactory.GetFont("TIMES_ROMAN", 12, Font.UNDERLINE, CMYKColor.BLACK);




    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StatusCheck();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if(Session["RoleID"].ToString()=="2" && (Session["ApproveStatus"]==null || Session["ApproveStatus"].ToString()=="2"))
        //{
        if (Session["RoleID"].ToString() == "2")
        {
            SubmitApplication(1);
        }
        else
        {
            SubmitApplication(3);
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        if(Session["RoleID"].ToString()=="1")
        {
            SubmitApplication(2);
        }
    }
    public void SubmitApplication(int status)
    {
        lblerr.Text = "";
        if (txtRemarks.Text.Trim() != "")
        {
            ArrayList arr = new ArrayList();
            arr.Add(Session["LBID"].ToString());
            arr.Add(Session["Year"].ToString());
            DataSet dsLB = new DataSet();
            dsLB = clsObj.Fetch("SP_tb_generaladministrationRPT_S", CommandType.StoredProcedure, arr);
            if (dsLB.Tables[0].Rows.Count > 0)
            {
                arr.Add(txtRemarks.Text.Trim());
                arr.Add(status);
                arr.Add(Session["UserID"]);
                arr.Add(Session["SeatID"]);

                clsObj.Fetch("SP_AuditSubmit_IU", CommandType.StoredProcedure, arr);
                if (status == 1)
                {
                    lblerr.Text = "Submitted Successfully";
                    btnSubmit.Visible = false;
                }
                else if (status == 2)
                {
                    lblerr.Text = "Returned Successfully";
                    btnReturn.Visible = false;
                    btnSubmit.Visible = false;
                }
                else if (status == 3)
                {
                    lblerr.Text = "Approved Successfully";
                    btnSubmit.Visible = false;
                    btnReturn.Visible = false;
                }
            }
            else
            {
                lblerr.Text = "Enter General Administration Details(പൊതുവിവരം >> പൊതുഭരണം)";
            }


        }
        else
        {
            lblerr.Text = "Enter Remarks";
        }
    }
    public void StatusCheck()
    {
        ArrayList arr = new ArrayList();
        arr.Add(Session["LBID"].ToString());
        arr.Add(Session["Year"].ToString());
        DataSet ds = new DataSet();
        ds = clsObj.Fetch("SP_SubmittedStatus_S", CommandType.StoredProcedure, arr);
        int status = 0;
        lblerr.Text = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
             status = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }
        if (status == 1)
        {
            lblerr.Text = "Application Submitted ";
        }
        else if (status == 2)
        {
            lblerr.Text = "'Submitted Forms are Returned for Modification'";
        }
        else if (status == 3)
        {
            lblerr.Text = "Approved";
        }


        if (Session["RoleID"].ToString() == "2")
        {
            btnReturn.Visible = false;
            btnSubmit.Visible = true;
            if (ds.Tables[0].Rows.Count == 0)
            {
                btnSubmit.Visible = true;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "2" || ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                btnSubmit.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
            }

        }
        else if (Session["RoleID"].ToString() == "1")
        {
            btnSubmit.Text = "Approve";
            btnReturn.Visible = true;
            btnSubmit.Visible = true;
            if (ds.Tables[0].Rows.Count == 0)
            {
                btnSubmit.Visible = false;
                btnReturn.Visible = false;
            }
            else if (ds.Tables[0].Rows[0][0].ToString() == "1")
            {
                btnReturn.Visible = true;
                btnSubmit.Visible = true;

            }
            else
            {
                btnReturn.Visible = false;
                btnSubmit.Visible = false;
            }
        }
    }
    protected void btnConsolidateReport_Click(object sender, EventArgs e)
    {
        int yearid = Convert.ToInt32(Session["Year"]);
        Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 15f, 15f);

        Response.ContentType = "application/pdf";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.AddHeader("content-disposition", "attachment;filename=consolidationrp.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        writer.Close();
        writer.PageEvent = new Footer();
        pdfDoc.Open();

        String sqlquery = "";
        ArrayList Arry = new ArrayList();
        DataSet ds = new DataSet();
        Int64 lbcount = 0;
        double area = 0;
         Int64 populationmale = 0;
         Int64 populationfemale = 0; 
        Int64 totpopulation = 0;
        double audob = 0, audcb = 0;

        PdfPTable table = new PdfPTable(1);
        Paragraph ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("തദ്ദേശ സ്വയംഭരണ സ്ഥാപനങ്ങളുടെ‍ സമാഹൃത റിപ്പോര്‍ട്ട്   ‍\n", fontmalheadmain, EngFontBold)));
        table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
        ph.Alignment = Element.ALIGN_CENTER;
        table.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cellhead = new PdfPCell();
        cellhead.AddElement(ph);
        cellhead.MinimumHeight = 70f;
        table.AddCell(cellhead);
        table.WidthPercentage = 95;
       // pdfDoc.Add(table);
        //-------------------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase("\n"));
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("പൊതുഭരണം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാനതലം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);


        sqlquery = " select    chvlbType,  count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += " sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationmale,0))+ sum(isnull(numauditedpopulationfemale,0)) total";
        sqlquery += " from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        //  sqlquery += "   where intfinancialyearid=  " + yearid + " group by  tnylbtypecategory, chvlbType, M_LocalBody.intLBTypeID";
        sqlquery += " group by  tnylbtypecategory, chvlbType, M_LocalBody.intLBTypeID";

        sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";
        ds = clsObj.Fetch(sqlquery, CommandType.Text);


        table = new PdfPTable(6);
        table.SpacingBefore = 20f;
        PdfPCell cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][1]);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area+Convert.ToDouble(ds.Tables[0].Rows[i][2]);
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][4]);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][5]);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        } 
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);




        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += "from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(1,3,4) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
      //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";
        
        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ജില്ലാതലം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation=Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);
        //-----------------------------------------------District Panchayath
        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += "from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(1) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        ds = clsObj.Fetch(sqlquery, CommandType.Text);

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ജില്ലാപഞ്ചായത്ത്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);

        //-----------------------------------------------corporation
        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += "from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(4) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        ds = clsObj.Fetch(sqlquery, CommandType.Text);

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("കോര്‍പ്പറേഷന്‍"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);




        //-----------------------------------------------Municipality
        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += "from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(3) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        ds = clsObj.Fetch(sqlquery, CommandType.Text);

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("മുനിസിപ്പാലിറ്റി"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);


        //-----------------------------------------------BP
        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += "from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(2) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        ds = clsObj.Fetch(sqlquery, CommandType.Text);

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ബ്ലോക്ക് പഞ്ചായത്ത്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);


        //-----------------------------------------------GP
        sqlquery = "select  B.intDistID, TB_District_MST.chvDistName, A.chvLBName as BlockName,";sqlquery += " tb_generaladministration.intlbid, B.chvLBName,M_LBType.chvlbType,";
                sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
                sqlquery += " sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
                sqlquery += " from  tb_generaladministration ";
                sqlquery += " inner join M_LocalBody B on tb_generaladministration.intlbid=B.intlbid   and B.intLBTypeID=5";
                sqlquery += " inner join TB_District_MST on B.intDistID=TB_District_MST.intID";
                sqlquery += " inner join M_LBType on B.intLBTypeID=M_LBType.intlbtypeid";
                sqlquery += " inner join M_LocalBody A on B.intBlockID=A.intlbid";
                sqlquery += " where   B.intLBTypeID in(5)";
                sqlquery += " group by    tb_generaladministration.intlbid, B.chvLBName,M_LBType.chvlbType,";
                sqlquery += " B.intDistID, TB_District_MST.chvDistName,A.intBlockID,A.chvLBName";
         

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമപഞ്ചായത്ത്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(8);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബ്ലോക്ക് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][8].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][9].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            //populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][9].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][8].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][9].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
           // table.DefaultCell.HorizontalAlignment(Element.ALIGN_RIGHT);
            table.AddCell(cell);

        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);
        //-------------------------------------------------------------------------------------------------------------------



        ///opening balance
        //-------------------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase("\n"));
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("നീക്കിയിരുപ്പ്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാനതലം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);


        sqlquery = " select    chvlbType, count(distinct M_LocalBody.intlbid) lbcount, sum(isnull(numobamount,0)) ob,    sum(isnull(numauditedobamount,0)) audob,   sum(isnull(numCBamount,0)) cb,    sum(isnull(numauditedCBamount,0)) audcb  from  tb_bankob inner join M_LocalBody on tb_bankob.intlbid=M_LocalBody.intlbid inner join  TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid  group by M_LBType.chvlbType";
        ds = clsObj.Fetch(sqlquery, CommandType.Text);


        table = new PdfPTable(4);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഒ. ബി."), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സി.ബി."), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][1]);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            audob = audob + Convert.ToDouble(ds.Tables[0].Rows[i][3]);
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            audcb = audcb + Convert.ToInt64(ds.Tables[0].Rows[i][5]);

            //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            //table.AddCell(cell);
            //populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][5]);
            //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            //table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(audob.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(audcb.ToString(), fontmal, EngFont)));
        table.AddCell(cell);

        pdfDoc.Add(table);


        //----------------------------------------------------------------------------------------------------------

        sqlquery = " select    chvlbType, count(M_LocalBody.intlbid) lbcount,  sum(isnull(numobamount,0)) ob,    sum(isnull(numauditedobamount,0)) audob, sum(isnull(numCBamount,0)) cb,    sum(isnull(numauditedCBamount,0)) audcb  from  tb_bankob inner join M_LocalBody on tb_bankob.intlbid=M_LocalBody.intlbid inner join  TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID inner join M_LBType on  M_LocalBody.intLBTypeID=M_LBType.intlbtypeid group by M_LBType.chvlbType,M_LocalBody.intlbid";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ജില്ലാതലം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);
        //-----------------------------------------------District Panchayath
        sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        sqlquery += " sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        sqlquery += " from  tb_generaladministration ";
        sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        sqlquery += " where    M_LocalBody.intLBTypeID in(1) ";///and intfinancialyearid=  " + yearid;
        sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        //  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);

        ds = clsObj.Fetch(sqlquery, CommandType.Text);
        ph = new Paragraph(new Phrase(""));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ജില്ലാപഞ്ചായത്ത്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        table.SpacingBefore = 20f;
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        table.AddCell(cell);
        pdfDoc.Add(table);

        ////-----------------------------------------------corporation
        //sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        //sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        //sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        //sqlquery += "from  tb_generaladministration ";
        //sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        //sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        //sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        //sqlquery += " where    M_LocalBody.intLBTypeID in(4) ";///and intfinancialyearid=  " + yearid;
        //sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        //sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        ////  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);
        //ph = new Paragraph(new Phrase(""));
        //ph.Add(new Phrase(objMal1.unicodetoMalayamFont("കോര്‍പ്പറേഷന്‍"), fontmalheadsub));
        //ph.Alignment = Element.ALIGN_CENTER;
        //ph.SpacingBefore = 10f;
        //pdfDoc.Add(ph);

        //table = new PdfPTable(7);
        //table.SpacingBefore = 20f;
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //}
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //pdfDoc.Add(table);




        ////-----------------------------------------------Municipality
        //sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        //sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        //sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        //sqlquery += "from  tb_generaladministration ";
        //sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        //sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        //sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        //sqlquery += " where    M_LocalBody.intLBTypeID in(3) ";///and intfinancialyearid=  " + yearid;
        //sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        //sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        ////  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);
        //ph = new Paragraph(new Phrase(""));
        //ph.Add(new Phrase(objMal1.unicodetoMalayamFont("മുനിസിപ്പാലിറ്റി"), fontmalheadsub));
        //ph.Alignment = Element.ALIGN_CENTER;
        //ph.SpacingBefore = 10f;
        //pdfDoc.Add(ph);

        //table = new PdfPTable(7);
        //table.SpacingBefore = 20f;
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //}
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //pdfDoc.Add(table);


        ////-----------------------------------------------BP
        //sqlquery = "select    M_LocalBody.intDistID, TB_District_MST.chvDistName, chvlbType,count(tb_generaladministration.intlbid) lbcount, ";
        //sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        //sqlquery += "sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        //sqlquery += "from  tb_generaladministration ";
        //sqlquery += " inner join M_LocalBody on tb_generaladministration.intlbid=M_LocalBody.intlbid";
        //sqlquery += " inner join TB_District_MST on M_LocalBody.intDistID=TB_District_MST.intID";
        //sqlquery += " inner join M_LBType on M_LocalBody.intLBTypeID=M_LBType.intlbtypeid";
        //sqlquery += " where    M_LocalBody.intLBTypeID in(2) ";///and intfinancialyearid=  " + yearid;
        //sqlquery += " group by   M_LocalBody.intDistID,chvDistName,chvlbType ";
        //sqlquery += " order by  M_LocalBody.intDistID,chvlbType";
        ////  sqlquery = sqlquery + " order by  tnylbtypecategory,M_LocalBody.intLBTypeid";

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);

        //ds = clsObj.Fetch(sqlquery, CommandType.Text);
        //ph = new Paragraph(new Phrase(""));
        //ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ബ്ലോക്ക് പഞ്ചായത്ത്"), fontmalheadsub));
        //ph.Alignment = Element.ALIGN_CENTER;
        //ph.SpacingBefore = 10f;
        //pdfDoc.Add(ph);

        //table = new PdfPTable(7);
        //table.SpacingBefore = 20f;
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    area = area + Convert.ToDouble(ds.Tables[0].Rows[i][4].ToString());
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][6].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][7].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //}
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //pdfDoc.Add(table);


        ////-----------------------------------------------GP
        //sqlquery = "select  B.intDistID, TB_District_MST.chvDistName, A.chvLBName as BlockName,"; sqlquery += " tb_generaladministration.intlbid, B.chvLBName,M_LBType.chvlbType,";
        //sqlquery += " sum(isnull(numauditedarea,0)) area, 'Sq. Km' unit, sum(isnull(numauditedpopulationmale,0)) male, ";
        //sqlquery += " sum(isnull(numauditedpopulationfemale,0)) female, sum(isnull(numauditedpopulationtrans,0)) transgender ";
        //sqlquery += " from  tb_generaladministration ";
        //sqlquery += " inner join M_LocalBody B on tb_generaladministration.intlbid=B.intlbid   and B.intLBTypeID=5";
        //sqlquery += " inner join TB_District_MST on B.intDistID=TB_District_MST.intID";
        //sqlquery += " inner join M_LBType on B.intLBTypeID=M_LBType.intlbtypeid";
        //sqlquery += " inner join M_LocalBody A on B.intBlockID=A.intlbid";
        //sqlquery += " where   B.intLBTypeID in(5)";
        //sqlquery += " group by    tb_generaladministration.intlbid, B.chvLBName,M_LBType.chvlbType,";
        //sqlquery += " B.intDistID, TB_District_MST.chvDistName,A.intBlockID,A.chvLBName";


        //ds = clsObj.Fetch(sqlquery, CommandType.Text);
        //ph = new Paragraph(new Phrase(""));
        //ph.Add(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമപഞ്ചായത്ത്"), fontmalheadsub));
        //ph.Alignment = Element.ALIGN_CENTER;
        //ph.SpacingBefore = 10f;
        //pdfDoc.Add(ph);

        //table = new PdfPTable(7);
        //table.SpacingBefore = 20f;
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജില്ല"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശസ്വയംഭരണ സ്ഥാപനത്തിന്‍റെ തരം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എണ്ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിസ്തീര്‍ണം"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്ത്രീ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
        //cell.MinimumHeight = 25f;
        //table.AddCell(cell);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    lbcount += Convert.ToInt64(ds.Tables[0].Rows[i][3].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    area = area + Convert.ToDouble(ds.Tables[0].Rows[i][6].ToString());
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationmale += Convert.ToInt64(ds.Tables[0].Rows[i][8].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
        //    table.AddCell(cell);
        //    populationfemale += Convert.ToInt64(ds.Tables[0].Rows[i][9].ToString());
        //    totpopulation = Convert.ToInt64(ds.Tables[0].Rows[i][8].ToString()) + Convert.ToInt64(ds.Tables[0].Rows[i][9].ToString());
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(totpopulation.ToString(), fontmal, EngFont)));
        //    // table.DefaultCell.HorizontalAlignment(Element.ALIGN_RIGHT);
        //    table.AddCell(cell);
        //}
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(lbcount.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(area.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationmale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(populationfemale.ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish((populationmale + populationfemale).ToString(), fontmal, EngFont)));
        //table.AddCell(cell);
        //pdfDoc.Add(table);
        //-------------------------------------------------------------------------------------------------------------------
    
        pdfDoc.Close();

        Response.Write(pdfDoc);
        Response.End();


    }
}
