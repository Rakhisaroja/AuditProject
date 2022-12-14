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
public partial class Pages_AuditReport_Report : System.Web.UI.Page
{
    GlobalClass ClsGlobal = new GlobalClass();
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
            if (Session["Rpt"].ToString() == "1")
            {
                Int32 lbid=Convert.ToInt32(Session["LBIDA"]);
                Session["Rpt"] = "";
                Session["LBIDA"] = "";
                PrintReport("Annual_Report", lbid);
            }
            else if (Session["Rpt"].ToString() == "2")
            {
                Int32 lbid = Convert.ToInt32(Session["LBIDA"]);
                Session["Rpt"]= "";
                Session["LBIDA"]= "";
                PrintSurPlus("Surplus", lbid);
            }
        }
    }


    public void PrintReport(string filename, Int32 lb)
    {
        //int lb = Convert.ToInt32(Session["LBID"]);
        int yearid = Convert.ToInt32(Session["Year"]);
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 15f, 15f);

        Response.ContentType = "application/pdf";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        writer.Close();
        writer.PageEvent = new Footer();
        pdfDoc.Open();


        ArrayList Arry = new ArrayList();
        DataSet dsLB = new DataSet();
        Arry.Add(lb);
        Arry.Add(Convert.ToInt64(Session["Year"]));
        dsLB = ClsGlobal.Fetch("SP_tb_generaladministrationRPT_S", CommandType.StoredProcedure, Arry);


        PdfPTable table = new PdfPTable(1);
        Paragraph ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("കേരള പഞ്ചായത്ത് രാജ് നിയമം 2 15 (15) അനുശാസിക്കുന്ന പ്രകാരം ഓഡിറ്റ് സാക്ഷ്യപ്പെടുത്തിയ " + dsLB.Tables[0].Rows[0][1].ToString() + " ന്‍റെ‍ 2017-18 സാമ്പത്തിക വർഷത്തെ വാർഷിക റിപ്പോർട്ട് ‍\n", fontmalheadmain, EngFontBold)));
        table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
        ph.Alignment = Element.ALIGN_CENTER;
        table.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cellhead = new PdfPCell();
        cellhead.AddElement(ph);
        cellhead.MinimumHeight = 70f;
        table.AddCell(cellhead);
        table.WidthPercentage = 95;

        pdfDoc.Add(table);


        //-------------------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase("\n"));
        pdfDoc.Add(ph);

        
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][1].ToString(), fontmalheadmain, EngFont)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase("I. "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("പൊതുഭരണം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);



        table = new PdfPTable(2);
        table.SpacingBefore = 20f;

        PdfPCell cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        DataSet dsTemp = new DataSet();
        ArrayList arrTaluk = new ArrayList();
        arrTaluk.Add(lb);
        dsTemp = ClsGlobal.Fetch("SP_tb_taluklbwise_S", CommandType.StoredProcedure, arrTaluk);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന താലൂക്ക്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        string temp ="";
        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            temp += (dsTemp.Tables[0].Rows[i][1].ToString()) + ",";
        }


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(temp, fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന നിയോജകമണ്ഡലം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_tb_assemblylbwise_S", CommandType.StoredProcedure, arrTaluk);
        temp = "";
        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            temp += (dsTemp.Tables[0].Rows[i][1].ToString()) + ",";
        }



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(temp, fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനത്തിന്റെ അതിരുകള്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കിഴക്ക് -" + dsLB.Tables[0].Rows[0][4].ToString() + ", പടിഞ്ഞാറ് -" + dsLB.Tables[0].Rows[0][5].ToString() + ", തെക്ക് -" + dsLB.Tables[0].Rows[0][6].ToString() + ", വടക്ക് -" + dsLB.Tables[0].Rows[0][7].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനത്തിന്റെ ആകെ വിസ്തീര്‍ണം (ച.കീ)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][8].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം ത്തിന്റെ ആകെ ജനസംഖ്യ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        PdfPTable table1 = new PdfPTable(1);
        table1.DefaultCell.Border = Rectangle.NO_BORDER;
        table1.AddCell(new Phrase(objMal1.unicodetoMalayamFont("ആണ്  : " + dsLB.Tables[0].Rows[0][9].ToString()), fontmal));
        table1.AddCell(new Phrase(objMal1.unicodetoMalayamFont("പെണ്ണ്  : ") + dsLB.Tables[0].Rows[0][10].ToString(), fontmal));
        table1.SpacingAfter = 5f;
        table.AddCell(table1);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പ്രസിഡന്റ് /ചെയർമാൻ /ചെയർപേഴ്സൺ /മേയർ പേര്, കാലയലവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][12].ToString() + " (" + dsLB.Tables[0].Rows[0][13].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][16].ToString() + " (" + dsLB.Tables[0].Rows[0][17].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][18].ToString() + " (" + dsLB.Tables[0].Rows[0][19].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആരോഗ്യ വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][20].ToString() + " (" + dsLB.Tables[0].Rows[0][21].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ഷേമകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][22].ToString() + " (" + dsLB.Tables[0].Rows[0][23].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സെക്രട്ടറിയുടെ പേര്, കാലയലവ്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][14].ToString() + " (" + dsLB.Tables[0].Rows[0][15].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        table.WidthPercentage = 95;
        pdfDoc.Add(table);
        //-----------------------------------------------------------------------------------------------------------------------

        table = new PdfPTable(2);
        dsTemp = new DataSet();
        ArrayList arrTemp = new ArrayList();
        arrTemp.Add(lb);
        arrTemp.Add(yearid);
        dsTemp = ClsGlobal.Fetch("SP_tb_budgetdetails_Sel", CommandType.StoredProcedure, arrTemp);
        if (dsTemp.Tables[0].Rows.Count > 0)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിവിധ സ്റ്റാന്റിംഗ് കമ്മിറ്റികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബഡ്ജറ്റ് നിര്ദ്ദേ ശങ്ങള്‍ സമര്‍പിച്ച തീയതി"), fontmal));
            table.AddCell(cell);
            PdfPTable tblsub = new PdfPTable(2);
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വികസനം"), fontmal));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][18].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ഷേമം"), fontmal));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][19].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആരോഗ്യo", fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][20].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിദ്യാഭ്യാസം"), fontmal));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][21].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);

            table.AddCell(tblsub);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റ് അവതരിപ്പിച്ച തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][22].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][23].ToString(), fontmal, EngFont)));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീരുമാന നമ്പര്‍"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][24].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][25].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം വരവ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][26].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][27].ToString(), fontmal, EngFont)));
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][28].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കിയിരിപ്പ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][29].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സപ്ലിമെന്ററി / റിവെെസ്ഡ് ബഡ്ജറ്റ് തയ്യാറാക്കിയ തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][30].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാര്ഷിളക ബഡ്ജറ്റില്‍ ഉള്പ്പെ്ടാത്ത ചെലവുകള്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][31].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റില്‍ ഉള്ക്കൊ ള്ളിച്ചതിനേക്കാള്‍ കൂടുതല്‍ ചെലവുകള്‍ ഏതെങ്കിലും ഇനത്തില്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം"), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][32].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ വാര്ഷി്ക ബഡ്ജറ്റിന്റെ പകര്പ്പ്  സംസ്ഥാന ഒാഡിറ്റ് വകുപ്പിന് നല്കിപയതിന്റെ വിവരം (തീരുമാനം, നം, തീയതി)"), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][33].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            table.SpacingBefore = 25f;
            table.WidthPercentage = 95;
            pdfDoc.Add(table);
        }
       
        //-----------------------------------------------------------------------------------------------------------------------

        table = new PdfPTable(6);

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("I.i നിയോജകമണ്ഡലങ്ങളുടെ/വാർഡ്കളുടെ വിവരം", fontmalheadsub, EngFontBold)));
        pdfDoc.Add(ph);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാർഡ് നമ്പർ "), fontmal));

        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പേര്"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അതിരുകള്‍"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജനസംഖ്യ"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;

        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാർഡ് മെമ്പര്‍"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീകൾ "), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്മാര്‍"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_TB_MemberWardDetails_S", CommandType.StoredProcedure, arrTemp);

        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }








        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------------------
        table = new PdfPTable(3);
        ph = new Paragraph(new Phrase(" I.ii "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("യോഗനടപടികളുടെ വിവരം"), fontmalheadsub));
        pdfDoc.Add(ph);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("യോഗം ചേര്‍ന്ന തീയതി"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഹാജര്‍ നില"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));

        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));

        table.AddCell(cell);

        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_tb_committee_Sel", CommandType.StoredProcedure, arrTemp);

        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

           
        }



        table.HeaderRows = 1;

        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);
        //---------------------------------------------------------------------------------------------------------
        table = new PdfPTable(9);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമ/വാര്‍ഡ്സഭ വിവരങ്ങള്‍"), fontmalhead));
        cell.MinimumHeight = 25f;
        cell.Colspan = 9;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാര്‍ഡ് നം / പേര്"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വോട്ടര്‍മാരുടെ എണ്ണം"), fontmal));
        cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പങ്കെടുത്ത വോട്ടര്‍മാരുടെ എണ്ണം"), fontmal));
        cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമ/വാര്‍ഡ്സഭ കൂടിയ സ്ഥലം"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീയതി"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഹാജര്‍ ശതമാനം"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(" ", fontmal));
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        cell.Colspan = 2;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        cell.Colspan = 2;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_gramasabha_S", CommandType.StoredProcedure, arr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][12].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][14].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][13].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][16].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][15].ToString(), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);
        
        /*---------------------------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("II. 31.03.2017 ലെ  നീക്കിയിരിപ്പ് വിശദാംശം  (RP 40(a) പ്രകാരം)", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_BankOB", CommandType.StoredProcedure, arr);
        table = new PdfPTable(2);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാങ്ക്"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ് (ഓ.ബി)"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        double fltTotal = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString()));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
            fltTotal += double.Parse(ds.Tables[0].Rows[i][1].ToString() == "" ? "0" : ds.Tables[0].Rows[i][1].ToString());
        }
        cell = new PdfPCell(new Phrase("Total"));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(fltTotal.ToString()));
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        table.AddCell(cell);
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);

        /*-----------------------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase("III. "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("നികുതി നികുതിയേതര വരവുകള്‍"), fontmal));
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("1"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("2"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("3"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("4"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("5"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("6"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("7"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.നം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇന്‍കം & എക്സപെന്‍ഡിച്ചര്‍ പത്രിക പ്രകാരമുള്ള പ്രതീക്ഷിത വരുമാനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43)"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43, ആര്‍.പി-1)"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance) (ആര്‍.പി-36)"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ തന്‍വര്‍ഷം വരവ് (5+6+7)"), fontmal));
        table.AddCell(cell);
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("select intincometype,chvincometypemal from m_incometype", CommandType.Text);

       
        for (int j = 0; j < dsTemp.Tables[0].Rows.Count; j++)
        {
            cell = new PdfPCell(new Phrase((j+1).ToString(),  EngFont));
            arrTemp.Clear();
            arrTemp.Add(lb);
            arrTemp.Add(yearid);
            arrTemp.Add(dsTemp.Tables[0].Rows[j][0]);
            ds = new DataSet();
            ds = ClsGlobal.Fetch("SP_tb_ownfundaccrualincomeRPT_Sel", CommandType.StoredProcedure, arrTemp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cell.Rowspan = ds.Tables[0].Rows.Count + 1;
            }


            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[j][1].ToString(), fontmalhead, EngFont)));
            cell.Colspan = 6;
            table.AddCell(cell);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][14].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][15].ToString(), fontmal, EngFont)));
                table.AddCell(cell);


            }
        }
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;

        pdfDoc.Add(table);

       



        /*-----------------------------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി) കാഷ് അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("1"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("2"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("3"), fontmal));
        table.AddCell(cell);



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.നം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current)(റസീറ്റ് ആന്റ് പേമന്റ് അക്കൌണ്ട് പ്രകാരം)"), fontmal));
        table.AddCell(cell);


        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("select intincometype,chvincometypemal from m_incometype", CommandType.Text);



        for (int j = 0; j < dsTemp.Tables[0].Rows.Count; j++)
        {
            cell = new PdfPCell(new Phrase((j + 1).ToString(), EngFont));
            arrTemp.Clear();
            arrTemp.Add(lb);
            arrTemp.Add(yearid);
            arrTemp.Add(dsTemp.Tables[0].Rows[j][0]);
            ds = new DataSet();
            ds = ClsGlobal.Fetch("SP_ownfunddirectincomeRPT_S", CommandType.StoredProcedure, arrTemp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cell.Rowspan = ds.Tables[0].Rows.Count + 1;
            }


            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[j][1].ToString(), fontmalhead, EngFont)));
            cell.Colspan = 6;
            table.AddCell(cell);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

               
            }
        }


        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);

        



        /*----------Sulekha Datas--------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വരവ് ഭാഗം"), fontmalheadmain));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന ഗ്രാന്റുകള്‍-ലഭ്യതയും വിനിയോഗവും"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(8);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന ബഡ്ജറ്റ് അനുബന്ധം 4 പ്രകാരം വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന സര്‍ക്കാര്‍ അനുവദിച്ച തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റസീപ്റ്റ് & പേമെന്റ് പ്രകാരം വരവ് ചെലവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ശതമാനം"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ലാപ്സായ തുക/ശതമാനം(4-5)"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(8)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        DataSet dsStateGrants = new DataSet();
        dsStateGrants = ClsGlobal.Fetch("SP_tb_stategrantsRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < dsStateGrants.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase((i + 1).ToString()));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(dsStateGrants.Tables[0].Rows[i][1].ToString()), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][2].ToString()));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][3].ToString()));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][4].ToString()));
            table.AddCell(cell);
            PdfPTable pdfSubtbl1 = new PdfPTable(2);
            PdfPTable pdfSubtbl2 = new PdfPTable(2);

            arr.Clear();
            arr.Add(lb);
            arr.Add(yearid);
            arr.Add(dsStateGrants.Tables[0].Rows[i][0]);
            ds = ClsGlobal.Fetch("SP_StateFundExpenseRPT_S", CommandType.StoredProcedure, arr);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {


                cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[j][2].ToString()), fontmal));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl1.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][3].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl1.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][6].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl2.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][7].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl2.AddCell(cell);




            }
            table.AddCell(pdfSubtbl1);
            table.AddCell(pdfSubtbl2);
            cell = new PdfPCell(new Phrase((dsStateGrants.Tables[0].Rows[i][5].ToString() + ", " + Math.Round(double.Parse(dsStateGrants.Tables[0].Rows[i][6].ToString().Trim() == "" ? "0" : dsStateGrants.Tables[0].Rows[i][6].ToString().Trim()), 2).ToString() + " %")));
            table.AddCell(cell);
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        float[] widths = new float[] { 20f, 50f, 40f, 40f, 50f, 80f, 80f, 40f };
        table.SetWidths(widths);
        pdfDoc.Add(table);
       

        



         /*-----------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("മറ്റ് പ്രത്യേകോദ്ദേശ്യ ഗ്രാന്റുകള്‍/പിരിവുകള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);


        table = new PdfPTable(9);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.Colspan = 4;
        cell.MinimumHeight = 25f;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));
        cell.Rowspan = 2;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുണഭോക്താക്കളുടെ എണ്ണം"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        
        
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നിലവിലുണ്ടായിരുന്നവര്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്"), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കം  ചെയ്യപ്പെട്ടവര്‍ "), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി ഗുണഭോക്താക്കള്‍ "), fontmal));

        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_otherspecialgrants", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][7].ToString(), EngFontBold));
                table.AddCell((cell));
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][7].ToString(), EngFont));
                table.AddCell((cell));
            }

        }









        float[] width = { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //----------------------------------------------------------------------------------------------------------------

       

        ph = new Paragraph(new Phrase("II"));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("കേന്ദ്രഫണ്ട്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(5);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_incomeexpendituremnregsRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

            }
        }

        width = new float[] { 1f, 6f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-------------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("VII.സംയുക്ത പ്രോജക്റ്റുകള്‍ ക്കുവേണ്ടിയും, മറ്റ് സര്‍ക്കാര്‍ ഏജന്‍സികള്‍ മുതലായവയില്‍ നിന്നും ലഭിച്ച തുകയുടെ വിവരം", fontmalhead, EngFontBold)));
        
        pdfDoc.Add(ph);



        table = new PdfPTable(5);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഏജന്‍സി"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("tb_jointventureexpenditureRPT_Sel", CommandType.StoredProcedure, arr);
        double totob=0, totexp=0, totincome=0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totob += double.Parse(ds.Tables[0].Rows[i][8].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][8].ToString().Trim());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totincome += double.Parse(ds.Tables[0].Rows[i][9].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][9].ToString().Trim());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totexp += double.Parse(ds.Tables[0].Rows[i][10].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][10].ToString().Trim());
        }
        cell = new PdfPCell(new Phrase(" "));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase("Total"));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totob.ToString()));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totincome.ToString()));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totexp.ToString()));
        table.AddCell(cell);

        width = new float[] { 1f, 6f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        /*------------------------------------------------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("VIII. ഋണശീര്‍ഷ വരവുകള്‍", fontmalhead, EngFontBold)));

        pdfDoc.Add(ph);


        table = new PdfPTable(7);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തിരിച്ചു നല്‍കല്‍"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്ടുകെട്ടല്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_negativeincomeRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" " , fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f,2f,2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        /*-------------------------------------------------------------------------------------------------------------------*/


       
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("IX. വായ്പ്പ തിരിച്ചടവ്",fontmalhead,EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വര്ഷികാരംഭത്തില്‍ തിരികെ ലഭിക്കാനുണ്ടായിരുന്ന തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം നല്‍കിയ തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ലഭിച്ചത്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വര്‍ഷാവസാനം തിരികെ ലഭിക്കുവാന്‍ ബാക്കിയുള്ളത്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്ക്ക്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_loanrepaymentRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase("  ", fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f , 2f , 2f};
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //ph = new Paragraph(new Phrase("Total (II + III + IV + V + VI + VII + VII + IX) ="));
        //pdfDoc.Add(ph);


        /*-------------------------------------------------------------------------------------------------------------------*/


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("X  കേന്ദ്ര സംസ്ഥാന സര്‍ക്കാരുകള്‍ ഗുണഭോക്താക്കള്‍ക്ക് നേരിട്ട് കൈമാറ്റം ചെയ്യുന്ന തുകകളുടെ വിവരങ്ങള്‍", fontmalhead,EngFontBold)));
        pdfDoc.Add(ph);


        table = new PdfPTable(8);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.Colspan = 4;
        cell.MinimumHeight = 25f;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുണഭോക്താക്കളുടെ എണ്ണം"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നിലവിലുണ്ടായിരുന്നവര്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്"), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കം  ചെയ്യപ്പെട്ടവര്‍ "), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി ഗുണഭോക്താക്കള്‍ "), fontmal));

        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_directbeneficiaryexpenditureRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
                table.AddCell((cell));
            }
            else
            {
             
               
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
                table.AddCell((cell));
            }

        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //------------------------------------------------------------------------------------------------------------------


        //ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ചെലവിനം"), fontmalhead));
        //pdfDoc.Add(ph);


        //int mainid = 0;


        //table = new PdfPTable(3);

        //ds.Clear();
        //ds.Dispose();

        //ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
        //    {
        //        ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
        //        pdfDoc.Add(ph);
        //        mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
        //    }
        //    cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
        //    cell.MinimumHeight = 25f;
        //    cell.Colspan = 3;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("Sl no."));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("HEAD"));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("Amount"));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    DataSet dsExpense = new DataSet();
        //    arr.Clear();
        //    arr.Add(lb);
        //    arr.Add(yearid);
        //    arr.Add(ds.Tables[0].Rows[i][0]);
        //    arr.Add(ds.Tables[0].Rows[i][1]);
        //    dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

        //    for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
        //    {


        //        if (j == dsExpense.Tables[0].Rows.Count - 1)
        //        {
        //            cell = new PdfPCell(new Phrase("  "));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
        //            table.AddCell((cell));
        //        }
        //        else
        //        {
        //            cell = new PdfPCell(new Phrase((j + 1).ToString()));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
        //            table.AddCell((cell));
        //        }


        //    }
        //    table.WidthPercentage = 95;
        //    table.SpacingBefore = 20f;
        //    pdfDoc.Add(table);
        //}

        //-------------------------------RAKHI----------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ചെലവിനം"), fontmalhead));
        pdfDoc.Add(ph);


        int mainid = 0;


        table = new PdfPTable(3);

        ds.Clear();
        ds.Dispose();

        ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
        ph = new Paragraph(new Phrase(ds.Tables[0].Rows[0][2].ToString(), titleFont));
        pdfDoc.Add(ph);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
            //{
            //    ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
            //    pdfDoc.Add(ph);
            //    mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
            //}
            if (int.Parse(ds.Tables[0].Rows[i][0].ToString()) == 1)
            {
                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
                cell.MinimumHeight = 25f;
                cell.Colspan = 3;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Sl no."));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("HEAD"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Amount"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                DataSet dsExpense = new DataSet();
                arr.Clear();
                arr.Add(lb);
                arr.Add(yearid);
                arr.Add(ds.Tables[0].Rows[i][0]);
                arr.Add(ds.Tables[0].Rows[i][1]);
                dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

                for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
                {


                    if (j == dsExpense.Tables[0].Rows.Count - 1)
                    {
                        cell = new PdfPCell(new Phrase("  "));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
                        table.AddCell((cell));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase((j + 1).ToString()));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
                        table.AddCell((cell));
                    }


                }
            }
            else
            {

            }
        }
            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);

            //-----------------------------------------------------------------------------------------------------------

            table = new PdfPTable(3);

            ds.Clear();
            ds.Dispose();

            ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
            ph = new Paragraph(new Phrase("Service Expense", titleFont));
            pdfDoc.Add(ph);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
                //{
                //    ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
                //    pdfDoc.Add(ph);
                //    mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
                //}
                if (int.Parse(ds.Tables[0].Rows[i][0].ToString()) == 2)
                {
                    cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
                    cell.MinimumHeight = 25f;
                    cell.Colspan = 3;
                    table.AddCell((cell));

                    cell = new PdfPCell(new Phrase("Sl no."));
                    cell.MinimumHeight = 25f;
                    table.AddCell((cell));

                    cell = new PdfPCell(new Phrase("HEAD"));
                    cell.MinimumHeight = 25f;
                    table.AddCell((cell));

                    cell = new PdfPCell(new Phrase("Amount"));
                    cell.MinimumHeight = 25f;
                    table.AddCell((cell));

                    DataSet dsExpense = new DataSet();
                    arr.Clear();
                    arr.Add(lb);
                    arr.Add(yearid);
                    arr.Add(2);
                    arr.Add(1);
                    dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

                    for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
                    {


                        if (j == dsExpense.Tables[0].Rows.Count - 1)
                        {
                            cell = new PdfPCell(new Phrase("  "));
                            table.AddCell((cell));
                            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
                            table.AddCell((cell));
                            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
                            table.AddCell((cell));
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase((j + 1).ToString()));
                            table.AddCell((cell));
                            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
                            table.AddCell((cell));
                            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
                            table.AddCell((cell));
                        }


                    }
                }
                else
                {

                }
            }
            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);
            //-------------------------------RAKHI----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വികസനഫണ്ട് - മേഖലാടിസ്ഥാനത്തിലുള്ള വകയിരുത്തല്‍"), fontmalhead));
        pdfDoc.Add(ph);
        table = new PdfPTable(15);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമ നം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിഭാഗം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെവകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉല്പാദന മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സേവന മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പശ്ചാത്തല മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_devfundsec_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(i!=(ds.Tables[0].Rows.Count-1) ? (i + 1).ToString() : " ", fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][4].ToString()), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][12].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][13].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][14].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][15].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][21].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][22].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][23].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][24].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][30].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][31].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][32].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][33].ToString(), fontmal));
            table.AddCell((cell));
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/



        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വിഭവ വകയിരുത്തല്‍ / ചെലവ് വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);


        
        table = new PdfPTable(5);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമ നം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിഭവ സ്രോതസ്സുകള്‍"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ് ശതമാനം"), fontmal));
        table.AddCell((cell));

        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_resourcealloc_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i != ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), EngFont));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }

        }
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_resourcealloc_AmtTot", CommandType.StoredProcedure, arr);
        if(ds.Tables[0].Rows.Count>0)
        {
            cell = new PdfPCell(new Phrase(" ", EngFont));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmalhead, EngFontBold)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][1].ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));
            float percnetage = float.Parse(ds.Tables[0].Rows[0][1].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0][1].ToString().Trim()) / float.Parse(ds.Tables[0].Rows[0][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString().Trim()) * 100;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(percnetage.ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));

        }
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------

      


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("III. വാര്‍ഷിക പദ്ധതി ചെലവുകള്‍", fontmalhead,EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_tb_StandingCommittee_S", CommandType.StoredProcedure, arr);
        DataSet dsMembers = new DataSet();
        DataSet dsdates = new DataSet();
        table = new PdfPTable(2);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][21].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അംഗങ്ങള്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));
            
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=1 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" കൂടിയ യോഗങ്ങളുടെ തീയതി"), fontmal));
            table.AddCell((cell));
            
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=1 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            ph.Add(new Phrase("No of Meetings : " + dsdates.Tables[0].Rows.Count.ToString() + "  ", EngFont));
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റവന്യൂ വരവുകള്‍ പരിശോധന വിവരങ്ങള്‍"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][23].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീരുമാനം നം, തീയതി,ഇനം)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][24].ToString() + "," + ds.Tables[0].Rows[0][25].ToString() + "," + ds.Tables[0].Rows[0][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കഴിഞ്ഞ മാസത്തെ ചെലവു വൗച്ചറുകള്‍ പരിശോധിച്ച് അംഗീകരിച്ച തീയതി"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[0][27].ToString()));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പ്രതിമാസ വരവ് ചെലവ് അക്കൗണ്ട് സെക്രട്ടറി തയ്യാറാക്കി സമര്‍പ്പിച്ചതീയതി"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[0][28].ToString()));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫ്രണ്ട് ഒാഫീസ് സംവിധാനത്തിന്റെ പ്രവര്‍ത്തനം വിലയിരുത്തല്‍ - അജണ്ട / തീരുമാനം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][29].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (നം, അടങ്കല്‍, ചെലവ്)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("No : " + ds.Tables[0].Rows[0][30].ToString() + ",Expense :" + ds.Tables[0].Rows[0][31].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഐ.എസ്.ഒ സര്‍ട്ടിഫിക്കറ്റ് നേടിയിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരങ്ങള്‍"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][34].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (വര്‍ഷം, ഖണ്ഡിക)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വര്‍ഷം : " + ds.Tables[0].Rows[0][35].ToString() + ", ഖണ്ഡിക :" + ds.Tables[0].Rows[0][36].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);


        }


        //-----------------------------------------------------------------------------------------------------------
        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എ (i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍"), fontmal));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-----------------------------------------------------------------------------------------------------------
     
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("എ (ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("പൊതുഭരണവുമായി ബന്ധപ്പെട്ട് രൂപീകരിക്കപ്പെട്ട  കമ്മിറ്റികളുടെയും യോഗങ്ങളുടേയും വിവരങ്ങള്‍"), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ബി. വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=2 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=2 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ",", EngFont));
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);



        }


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ബി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1.കൃഷി അനുബന്ധ മേഖലകളും  (പരിസ്ഥിതി, ജലസേചനം, മണ്ണ്-ജലസംരക്ഷണം, വനവത്കരണം, മത്സ്യബന്ധനം ഉള്‍പ്പടെ)", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("[SP_tb_projectdetailsAgriRPT_Sel]", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));




        }




      

        width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------

        

        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("5. മൃഗസംരക്ഷണം, ക്ഷീരവികസനം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsAnimmalHusbndryRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));




        }






          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("6.പ്രാദേശികസാമ്പത്തിക വികസനം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsLoclDvlpmntRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("7.പൊതുമരാമത്ത് (വൈദ്യുതി,  ഊര്‍ജ്ജം ഉള്‍പ്പെടെ)", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsPublicWorkRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);






        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------


        table = new PdfPTable(8);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ള തെരുവുവിളക്കുകളുടെ തരവും എണ്ണവും", fontmalhead, EngFont)));
        cell.Colspan = 6;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmalhead, EngFont)));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒാര്‍ഡിനറി ബള്‍ബ്", fontmalhead, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി.എഫ്.എല്‍നിലവിലുള്ളത്", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എല്‍.ഇ.ഡി", fontmalhead, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഫ്ലൂറസെന്റ് ട്യൂബ്", fontmalhead, EngFont)));
        cell.Rowspan = 2;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുളളവ", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഡിസ്മാന്റില്‍ ചെയ്തത്", fontmalhead, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി സ്ഥാപിച്ചത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_streetlightRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString() + ") " + ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }
        width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(" 8(a) മീറ്ററിംഗ് സംവിധാനത്തിന്റെ വിശദാംശങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(2);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ സ്ഥാപിച്ചിട്ടുള്ള മീറ്ററുകളുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തെരുവുവിളക്കുകള്‍ക്കായി മീറ്റര്‍ സ്ഥാപിച്ചിട്ടില്ലെങ്കില്‍ പ്രസ്തുത ആവശ്യത്തിലേക്ക് നാളിതുവരെ ഒടുക്കിയ തുകയുടെ വിവരങ്ങള്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));

            table.AddCell((cell));
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);





        //-----------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("8(b) വാങ്ങിയ തെരുവുവിളക്കുകളും ചെലവഴിച്ച തുകയും- വിശദവിവരങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(6);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷം വാങ്ങിയ തെരുവുവിളക്കുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 6;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി.എഫ്.എല്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എല്‍.ഇ.ഡി", fontmalhead, EngFont)));
        table.AddCell((cell));
        
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ട്യൂബ്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുളളവ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അനുബന്ധ ഉപകരണങ്ങള്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));

            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(" 8(c) തെരുവുവിളക്ക് പരിപാലനം - ചെലവുവിവരങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);





        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ട് മുഖേന", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ട് മുഖേനയല്ലാതെ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എ.എം.സി", fontmalhead, EngFont)));
            table.AddCell((cell));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][9].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][10].ToString(), fontmal, EngFont)));

            table.AddCell((cell));



            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കരാര്‍ നിയമനം", fontmalhead, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][11].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][12].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കെ.എസ്.ഇ.ബി സൂപ്പര്‍വിഷന്‍ ചാര്‍ജ്", fontmalhead, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][13].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



            table.WidthPercentage = 95;
            table.SpacingBefore = 30f;
            pdfDoc.Add(table);

        }
        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("8(d) തെരുവുവിളക്കുകളുടെ വെെദ്യുതി ചാര്‍ജ്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);


        table = new PdfPTable(2);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മാസം", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുക്കിയ തുക", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightexpenditureRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }





        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("സി. ക്ഷേമകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=3 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=3 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            if (dsdates.Tables[0].Rows.Count > 0)
            {
                ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ", ", EngFont));
            }
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);

        }


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("സി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);







        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1. ദാരിദ്ര്യ ലഘൂകരണം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsPoverty_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }


          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




















        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2.സാമൂഹ്യ നീതി", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsSocial_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));






        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        /* -------------------------------------------------------------------------------------------------*/

        //ഭിന്നശേഷികാര്‍ക്കായി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍




        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഭിന്നശേഷികാര്‍ക്കായി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണഭോക്താക്കളുടെ എണ്ണം", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmal, EngFont)));
        table.AddCell((cell));


        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_budsschoolRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബഡ്സ് സ്കൂള്‍", fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സ്കോളര്‍ഷിപ്പ് / ബത്ത", fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഉപകരണങ്ങള്‍ വാങ്ങി നല്‍കല്‍", fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-------------------------------------------------------------------------------------------------------------------------------------------------

        //2 (a)      ബഡ്സ് സ്ക്കൂള്‍/ബഡ്സ് റിഹാബിലിറ്റേഷന്‍ സെന്റര്‍-വിവരങ്ങള്‍
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("2 (എ)      ബഡ്സ് സ്ക്കൂള്‍/ബഡ്സ് റിഹാബിലിറ്റേഷന്‍ സെന്റര്‍-വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുണ്ട്", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷം സ്ഥാപിച്ചു", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലില്ല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മതിയായ അടിസ്ഥാന സൗകര്യങ്ങള്‍ ഉണ്ട്/ഇല്ല.", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവ് വിവരങ്ങള്‍", fontmal, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാഹനവാ‍ടക", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഓണറേറിയം", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഇതരചെലവുകള്‍", fontmal, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_budsschoolRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


            }


        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("2(e)കുട്ടികള്‍,വൃദ്ധർ ,ട്രാന്സ്ജെലന്ഡേ്ഴ്സ്-പ്രോജക്ടുകളുടെ വിവരങ്ങള്‍ 2 (e)(1). കുട്ടികള്ക്കു വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുട്ടികള്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));






        }






          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);










        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2(e)(2).വൃദ്ധര്ക്കുപവേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(3);

        ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);










        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2(e)(3).പാലിയേറ്റിവ് കെയര്‍ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(6);
        ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

        }





          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);

        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("3. വനിതാവികസനം മേഖല – ദാരിദ്ര്യനിര്മാനര്ജസനം ചുമതല – സ്ത്രീകള്ക്ക്  സ്വയംതൊഴിലും ഗ്രൂപ്പ് എംപ്ലോയ്മെന്റും വനിതാഘടകപദ്ധതിയില്‍ ഉള്പ്പെ്ടുത്തിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



        }


          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);









        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("4. പട്ടിക ജാതി / പട്ടിക വര്ഗ്ഗര വികസനം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsSCST_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



        }





          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);

        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഡി. ആരോഗ്യം വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=4 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=4 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            if (dsdates.Tables[0].Rows.Count > 0)
            {
                ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ", ", EngFont));
            }
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);



        }

        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഡി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഡി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1. ആരോഗ്യമേഖല", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsHealthRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));




        }



          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //----------------------------------------------------------------------------------------------------------------------------------



        //-----ആശുപത്രി-------------------------------


        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആശുപത്രി", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഇന്‍പേഷ്യന്റ്സ് (എണ്ണം)", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒൗട്ട് പേഷ്യന്റ്സ് (എണ്ണം)", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എച്ച്.എം.സി കള്‍ സംബന്ധിച്ചുള്ള വിവരങ്ങള്‍", fontmal, EngFont)));
        cell.Colspan = 2;

        cell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        cell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എച്ച്.എം.സി രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല ", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഷിക കണക്കുകളുടെ വിവരം ", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗങ്ങള്‍ കൂടിയതിന്റെ വിവരങ്ങള്‍", fontmal, EngFont)));
        //table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുവില്‍ സമര്‍പ്പിച്ചത്", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുവില്‍ ഒാഡിറ്റ് നടത്തിയത്", fontmal, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_hospitaldetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                //table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);














        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2. കുടിവെള്ളം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsDrinkingWtr_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



        }





          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);

        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //----------------------------------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ജലനിധി പ്രകാരമുള്ള കുടിവെള്ള പദ്ധതികളുടെ വിവരം  "), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(9);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുടിവെള്ള പദ്ധതികള്‍ (എണ്ണം)", fontmal, EngFont)));
        cell.Colspan = 4;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുടിവെള്ള പദ്ധതി ജലസ്രോതസുകളുടെ വിവരം", fontmal, EngFont)));
        cell.Colspan = 7;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നിര്‍മ്മിച്ചത്", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കിണര്‍", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുഴല്‍കിണര്‍", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുളം", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അരുവി", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നദി", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണ.സമിതി", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നേരിട്ട്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണ.സമിതി", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നേരിട്ട്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_drinkingwaterRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------


        table = new PdfPTable(4);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പൊതു ടാപ്പുകളുടെ എണ്ണം", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നല്‍കിയത്", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_drinkingwaterTapsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);








        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("3. ശുചിത്വം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsClnDetRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));






        }





          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);

        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(10);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഖര ദ്രവ മാലിന്യ സംസ്കരണ സംവിധാനങ്ങളുടെ വിവരങ്ങള്‍     ( ഗ്രാ.പ / വിട്ടുകിട്ടിയവ / കമ്മ്യൂണിറ്റി തലത്തിലുള്ളവയുടെ എണ്ണം)", fontmalhead, EngFont)));
        cell.Colspan = 6;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഹരിത കര്‍മ്മ സേന രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കേ.പരാ.ആക്ട് 219(x) വകുപ്പ് (സര്‍ക്കുലര്‍ നം  576/ഡി.സി1/16/തസ്വഭവ , 24.09.16) പ്രകാരം ശുചിത്വത്തിന് ഫണ്ട് രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടില്‍ ഉല്‍പ്പെടുതാതെ ചെലവഴിച്ച തുകയുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഉപോത്പനങ്ങളുടെ വില്‍പനയില്‍ നിന്നും ലഭിച്ചിട്ടുള്ള വരുമാനത്തിന്റെ വിവരം (വെര്‍മി കമ്പോസ്റ്റ്, മണ്ണിര കമ്പോസ്റ്റ് മുതലായവ)", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി ആരംഭിച്ചവ", fontmalhead, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബയോഗ്യാസ് പ്ലാന്റ്", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബയോഗ്യാസ് പ്ലാന്റ്", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_solidwastemanagementRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString() + "- " + ds.Tables[0].Rows[i][10].ToString() + ", ", fontmal, EngFont)));
            table.AddCell((cell));

        }












        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("4. വിദ്യാഭ്യാസം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsEducation_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);






        //-----------------------------------------------------------------------------------------------------------
        table = new PdfPTable(10);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സ്കൂളുകള്‍", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വിദ്യാര്‍ത്ഥികളുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അധ്യാപകരുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അടിസ്ഥാന സൗകര്യങ്ങളുടെ ലഭ്യത)", fontmalhead, EngFont)));
        cell.Colspan = 6;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 20f;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പി.റ്റി.എ രൂപീകരിച്ചിട്ടുണ്ട്/ ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ജലം", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെെദ്യുതി", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഫര്‍ണീച്ചര്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ടോയിലറ്റ്(എണ്ണം)", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാഷ്ബയിസിന്‍(എണ്ണം)", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പാചക പുര", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_schoolRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            

        }







        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(11);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("5.  കല സാംസ്കാരികം, യുവജനകാര്യം", fontmalhead, EngFont)));
        cell.Colspan = 11;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_projectdetailsArtRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }




          width = new float[] { 6f, 2f, 2f, 2f,2f,2f, 2f, 2f, 2f, 2f, 2f };
          table.SetWidths(width);


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //-------------------------------------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ഇ)പോതുസുരക്ഷയും ആരോഗ്യവും-പഞ്ചായത്തിന്റെ ഇതര സേവനങ്ങളുടെ വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("1.പൊതു ശ്മശാനം/പവര്‍ ക്രിമറ്റോറിയം വിശദവിവരങ്ങള്‍"), fontmal));
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നിര്‍മ്മിച്ചത്‌", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷ ചെലവ്", fontmal, EngFont)));
        table.AddCell((cell));


        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_crematoriumRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //ജനന രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("2.ജനന രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(5);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.Colspan = 2;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" ആശുപത്രി മുഖേന"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നേരിട്ട്"), fontmal));

        table.AddCell((cell));









        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //മരണ രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("3.മരണ രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(5);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.Colspan = 2;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" ആശുപത്രി മുഖേന"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നേരിട്ട്"), fontmal));

        table.AddCell((cell));









        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //വിവാഹ രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("4.വിവാഹ രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(4);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));








        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("5. വിവിധ പെന്‍ഷനുകള്‍ - അപേക്ഷ തീര്‍പ്പാക്കല്‍ വിവരങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);



        table = new PdfPTable(5);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പെന്‍ഷനുകള്‍"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അപേക്ഷകരുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധിക്കുള്ളില്‍ അനുവദിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധി കഴിഞ്ഞ് അനുവദിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നിരസിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));






        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_pensionRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //6.കെട്ടിടങ്ങളുമായി ബന്ധപ്പെട്ട സേവനങ്ങള്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("6.കെട്ടിടങ്ങളുമായി ബന്ധപ്പെട്ട സേവനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(15);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകരുടെ എണ്ണം"), fontmal));

        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവ"), fontmal));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.Colspan = 5;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));





        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_buildingdetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][14].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("7.വാസയോഗ്യമായ വീടില്ല എന്ന സര്‍ട്ടിഫിക്കറ്റ് / താമസക്കാരനാണ് എന്ന സര്‍ട്ടിഫിക്കറ്റ് / ഒക്കുപ്പന്‍സി സര്‍ട്ടിഫിക്കറ്റിനുള്ള അപേക്ഷയിന്‍ മേല്‍ സ്ഥല പരിശോധന നടത്തി റിപ്പോര്‍ട്ട് നല്‍കല്‍"), fontmalhead));
        pdfDoc.Add(ph);


        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_buildingdetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][15].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
                table.AddCell((cell));




            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("8.ദേശീയ ഗ്രാമീണ തൊഴിലുറപ്പ് പദ്ധതി - രജിസ്ട്രേഷന്‍ / തൊഴില്‍കാര്‍ഡ് നല്‍കല്‍ , വേതന വിതരണം  "), fontmalhead));
        pdfDoc.Add(ph);


        table = new PdfPTable(4);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം തൊഴില്‍കാര്‍ഡിനുവേണ്ടി ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തൊഴില്‍കാര്‍ഡ് നല്‍കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധിക്ക് ശേഷം നല്‍കിയ തൊഴില്‍കാര്‍ഡുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_mnregsregistrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        //9. ലെെസന്‍സ് നല്‍കല്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("9. ലെെസന്‍സ് നല്‍കല്‍  "), fontmalhead));
        pdfDoc.Add(ph);


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) ഫാക്ടറി , വ്യവസായം, വ്യാപാരം, വര്‍ക്ക്ഷോപ്പ്, ക്വോറി , ഇഷ്ടിക കമ്പനി, ഹോളോ ബ്രിക്സ്  "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_licenseRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി) ലെെഫ് സ്റ്റോക്ക് ഫാം, പന്നി, പട്ടി മുതലായവ "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_licenseRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //10. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനം വിശദാംശങ്ങള്‍ 

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("10. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനം വിശദാംശങ്ങള്‍  "), fontmalhead));
        pdfDoc.Add(ph);


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ. ഫ്രണ്ട് ഒാഫീസ് ഡയറി "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച (സേവനങ്ങള്‍ക്കുവേണ്ടി) അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_frontofficeRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി. ഇന്‍വേഡ് രജിസ്റ്റര്‍"), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച തപാലുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി കെെമാറിയ തപാലുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_frontofficeRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        /*---------------------------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("II. 31.03.18 ലെ വിവിധ ഇനങ്ങളിലെ നീക്കിയിരിപ്പ് (40(b)പ്രകാരം)", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_BankOB", CommandType.StoredProcedure, arr);
        table = new PdfPTable(2);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാങ്ക്"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ് (ഓ.ബി)"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString()));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
        }

        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        
        table.DefaultCell.MinimumHeight = 50f;
        pdfDoc.Add(table);







/*------------------------------------------------------------------------------------------------------------*/

        table = new PdfPTable(1);
        
        table.WidthPercentage = 25;
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഓഡിറ്റ് റിമാർക്കുകൾ ", fontmalheadsub, EngFontBold)));
        
        ph.SpacingAfter = 10f;
        table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
        table.AddCell(ph);
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        String Remarks="";
        DataSet dsMenu = new DataSet();
        dsMenu = ClsGlobal.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=0 and intParentMenuId=0 and intMenuId in (1,2,3,15,16,17,18,19,20)", CommandType.Text);
        String strMenu = "";
        String strSubMenu = "";
        int CntMain = 0;
        table1 = new PdfPTable(1);
        PdfPCell pdfcell1 = new PdfPCell();
        for (int i = 0; i < dsMenu.Tables[0].Rows.Count; i++)
        {
            Remarks = "";
            strMenu = dsMenu.Tables[0].Rows[i][1].ToString();
            DataSet dsSub = new DataSet();
            
           
            dsSub = ClsGlobal.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=1 and intParentMenuId=" + dsMenu.Tables[0].Rows[i][0].ToString(), CommandType.Text);
            if (dsSub.Tables[0].Rows.Count == 0)
            {
                
                Remarks = fillRemarks(int.Parse(dsMenu.Tables[0].Rows[i][0].ToString()), 0);

                if (Remarks.Trim() != "")
                {
                    CntMain++;
                   
                    strMenu = CntMain.ToString() + " : " + strMenu;
                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strMenu, fontmalhead, EngFontBold)));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;
                    pdfcell1 = new PdfPCell(ph);
                   // Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
                    pdfcell1.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);
                    
                  
                    ph = new Paragraph(new Phrase("Remarks", EngFontBold));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;
                    
                    pdfcell1=  new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);
                  
                    
                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(Remarks, fontmal, EngFont)));
                   // ph.Alignment = Element.ALIGN_JUSTIFIED;
                    
                    
                    ph.Alignment = Element.ALIGN_JUSTIFIED;
                    
                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);  
                 
                }
            }
            int mainMenuCnt = 0; //How many times printed main Menu
            int Cntsub = 0; 
            for (int j = 0; j < dsSub.Tables[0].Rows.Count; j++)
            {
                    Remarks = "";

                    Remarks =  fillRemarks(int.Parse(dsMenu.Tables[0].Rows[i][0].ToString()),int.Parse(dsSub.Tables[0].Rows[j][0].ToString()));
                    
                    if (Remarks != "")
                    {
                        if (mainMenuCnt == 0)
                        {
                            CntMain++;
                            strMenu = CntMain.ToString() + " : " + strMenu;
                            ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strMenu, fontmalhead, EngFontBold)));
                            ph.IndentationLeft = 15f;
                            ph.IndentationRight = 10f;
                            pdfcell1 = new PdfPCell(ph);
                            
                            table1.AddCell(pdfcell1); 
                            mainMenuCnt++;
                        }
                        Cntsub++;
                        strSubMenu = "        " + Cntsub.ToString() + "): " + dsSub.Tables[0].Rows[j][1].ToString();
                        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strSubMenu, fontmal, EngFont)));
                        ph.IndentationLeft = 15f;
                        ph.IndentationRight = 10f;
                        pdfcell1 = new PdfPCell(ph);
                        pdfcell1.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        table1.AddCell(pdfcell1);

                        ph = new Paragraph(new Phrase("Remarks", EngFontBold));
                        ph.IndentationLeft = 15f;
                        ph.IndentationRight = 10f;
                       
                        pdfcell1 = new PdfPCell(ph);
                        pdfcell1.Border =   Rectangle.LEFT_BORDER| Rectangle.RIGHT_BORDER;
                        table1.AddCell(pdfcell1);
  
                        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(Remarks, fontmal, EngFont)));
                       // ph.Alignment = Element.ALIGN_JUSTIFIED;

                        ph.Alignment = Element.ALIGN_JUSTIFIED;

                        pdfcell1 = new PdfPCell(ph);
                        pdfcell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        table1.AddCell(pdfcell1);

                       
                    }          
            }
        }
        table1.WidthPercentage = 95;
        pdfDoc.Add(table1);


        pdfDoc.Close();


        Response.Write(pdfDoc);
        Response.End();

    }
    public void PrintReportNew(string filename, Int32 lb)
    {
        //int lb = Convert.ToInt32(Session["LBID"]);
        int yearid = Convert.ToInt32(Session["Year"]);
        int FinYearid = Convert.ToInt32(Session["FinYear"]);
        int yeartemp = Convert.ToInt32(Session["FinYear"].ToString()) + 1;

        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 15f, 15f);

        Response.ContentType = "application/pdf";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        writer.Close();
        writer.PageEvent = new Footer();
        pdfDoc.Open();


        ArrayList Arry = new ArrayList();
        DataSet dsLB = new DataSet();
        Arry.Add(lb);
        Arry.Add(Convert.ToInt64(Session["Year"]));
        dsLB = ClsGlobal.Fetch("SP_tb_generaladministrationRPT_S", CommandType.StoredProcedure, Arry);


        PdfPTable table = new PdfPTable(1);
        Paragraph ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("കേരള പഞ്ചായത്ത് രാജ് നിയമം 2 15 (15) അനുശാസിക്കുന്ന പ്രകാരം ഓഡിറ്റ് സാക്ഷ്യപ്പെടുത്തിയ " + dsLB.Tables[0].Rows[0][1].ToString() + " ന്‍റെ‍ " + Session["YearSetting"].ToString() + " സാമ്പത്തിക വർഷത്തെ വാർഷിക റിപ്പോർട്ട് ‍\n", fontmalheadmain, EngFontBold)));
        table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
        ph.Alignment = Element.ALIGN_CENTER;
        table.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cellhead = new PdfPCell();
        cellhead.AddElement(ph);
        cellhead.MinimumHeight = 70f;
        table.AddCell(cellhead);
        table.WidthPercentage = 95;

        pdfDoc.Add(table);


        //-------------------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase("\n"));
        pdfDoc.Add(ph);


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][1].ToString(), fontmalheadmain, EngFont)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase("I. "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("പൊതുഭരണം"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        ph.SpacingBefore = 10f;
        pdfDoc.Add(ph);



        table = new PdfPTable(2);
        table.SpacingBefore = 20f;

        PdfPCell cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന ജില്ല"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        DataSet dsTemp = new DataSet();
        ArrayList arrTaluk = new ArrayList();
        arrTaluk.Add(lb);
        dsTemp = ClsGlobal.Fetch("SP_tb_taluklbwise_S", CommandType.StoredProcedure, arrTaluk);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന താലൂക്ക്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        string temp = "";
        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            temp += (dsTemp.Tables[0].Rows[i][1].ToString()) + ",";
        }


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(temp, fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം  സ്ഥിതി ചെയ്യുന്ന നിയോജകമണ്ഡലം"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_tb_assemblylbwise_S", CommandType.StoredProcedure, arrTaluk);
        temp = "";
        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            temp += (dsTemp.Tables[0].Rows[i][1].ToString()) + ",";
        }



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(temp, fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനത്തിന്റെ അതിരുകള്‍"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കിഴക്ക് -" + dsLB.Tables[0].Rows[0][4].ToString() + ", പടിഞ്ഞാറ് -" + dsLB.Tables[0].Rows[0][5].ToString() + ", തെക്ക് -" + dsLB.Tables[0].Rows[0][6].ToString() + ", വടക്ക് -" + dsLB.Tables[0].Rows[0][7].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനത്തിന്റെ ആകെ വിസ്തീര്‍ണം (ച.കീ)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][8].ToString(), fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തദ്ദേശ സ്ഥാപനം ത്തിന്റെ ആകെ ജനസംഖ്യ"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        PdfPTable table1 = new PdfPTable(1);
        table1.DefaultCell.Border = Rectangle.NO_BORDER;
        table1.AddCell(new Phrase(objMal1.unicodetoMalayamFont("ആണ്  : " + dsLB.Tables[0].Rows[0][9].ToString()), fontmal));
        table1.AddCell(new Phrase(objMal1.unicodetoMalayamFont("പെണ്ണ്  : ") + dsLB.Tables[0].Rows[0][10].ToString(), fontmal));
        table1.SpacingAfter = 5f;
        table.AddCell(table1);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പ്രസിഡന്റ് /ചെയർമാൻ /ചെയർപേഴ്സൺ /മേയർ പേര്, കാലയലവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][12].ToString() + " (" + dsLB.Tables[0].Rows[0][13].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][16].ToString() + " (" + dsLB.Tables[0].Rows[0][17].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][18].ToString() + " (" + dsLB.Tables[0].Rows[0][19].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആരോഗ്യ വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][20].ToString() + " (" + dsLB.Tables[0].Rows[0][21].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ഷേമകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി ചെയര്മാന്‍റെ പേര്, കാലയളവ് "), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][22].ToString() + " (" + dsLB.Tables[0].Rows[0][23].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സെക്രട്ടറിയുടെ പേര്, കാലയലവ്"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsLB.Tables[0].Rows[0][14].ToString() + " (" + dsLB.Tables[0].Rows[0][15].ToString() + ")", fontmal, EngFont)));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        table.WidthPercentage = 95;
        pdfDoc.Add(table);
        //-----------------------------------------------------------------------------------------------------------------------

        table = new PdfPTable(2);
        dsTemp = new DataSet();
        ArrayList arrTemp = new ArrayList();
        arrTemp.Add(lb);
        arrTemp.Add(yearid);
        dsTemp = ClsGlobal.Fetch("SP_tb_budgetdetails_Sel", CommandType.StoredProcedure, arrTemp);
        if (dsTemp.Tables[0].Rows.Count > 0)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിവിധ സ്റ്റാന്റിംഗ് കമ്മിറ്റികള്‍ ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റിക്ക് ബഡ്ജറ്റ് നിര്ദ്ദേ ശങ്ങള്‍ സമര്‍പിച്ച തീയതി"), fontmal));
            table.AddCell(cell);
            PdfPTable tblsub = new PdfPTable(2);
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വികസനം"), fontmal));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][18].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ഷേമം"), fontmal));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][19].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആരോഗ്യo", fontmal, EngFont)));
            tblsub.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][20].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിദ്യാഭ്യാസം"), fontmal));
            tblsub.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][21].ToString(), fontmal, EngFont)));
            tblsub.AddCell(cell);

            table.AddCell(tblsub);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റ് അവതരിപ്പിച്ച തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][22].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റ് പാസ്സാക്കിയ തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][23].ToString(), fontmal, EngFont)));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീരുമാന നമ്പര്‍"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][24].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][25].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം വരവ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][26].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][27].ToString(), fontmal, EngFont)));
            table.AddCell(cell);



            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][28].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കിയിരിപ്പ്"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][29].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സപ്ലിമെന്ററി / റിവെെസ്ഡ് ബഡ്ജറ്റ് തയ്യാറാക്കിയ തീയതി"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][30].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാര്ഷിളക ബഡ്ജറ്റില്‍ ഉള്പ്പെ്ടാത്ത ചെലവുകള്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം"), fontmal));
            cell.MinimumHeight = 25f;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][31].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബഡ്ജറ്റില്‍ ഉള്ക്കൊ ള്ളിച്ചതിനേക്കാള്‍ കൂടുതല്‍ ചെലവുകള്‍ ഏതെങ്കിലും ഇനത്തില്‍ ചെയ്തിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരം"), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][32].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ വാര്ഷി്ക ബഡ്ജറ്റിന്റെ പകര്പ്പ്  സംസ്ഥാന ഒാഡിറ്റ് വകുപ്പിന് നല്കിപയതിന്റെ വിവരം (തീരുമാനം, നം, തീയതി)"), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[0][33].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            table.SpacingBefore = 25f;
            table.WidthPercentage = 95;
            pdfDoc.Add(table);
        }

        //-----------------------------------------------------------------------------------------------------------------------

        table = new PdfPTable(6);

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("I.i നിയോജകമണ്ഡലങ്ങളുടെ/വാർഡ്കളുടെ വിവരം", fontmalheadsub, EngFontBold)));
        pdfDoc.Add(ph);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാർഡ് നമ്പർ "), fontmal));

        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പേര്"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അതിരുകള്‍"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ജനസംഖ്യ"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;

        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാർഡ് മെമ്പര്‍"), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീകൾ "), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്മാര്‍"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_TB_MemberWardDetails_S", CommandType.StoredProcedure, arrTemp);

        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }








        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------------------
        table = new PdfPTable(3);
        ph = new Paragraph(new Phrase(" I.ii "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("യോഗനടപടികളുടെ വിവരം"), fontmalheadsub));
        pdfDoc.Add(ph);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("യോഗം ചേര്‍ന്ന തീയതി"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഹാജര്‍ നില"), fontmal));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അവതരിപ്പിച്ച പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));

        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));

        table.AddCell(cell);

        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("SP_tb_committee_Sel", CommandType.StoredProcedure, arrTemp);

        for (int i = 0; i < dsTemp.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell(cell);


        }



        table.HeaderRows = 1;

        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);
        //---------------------------------------------------------------------------------------------------------
        table = new PdfPTable(9);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമ/വാര്‍ഡ്സഭ വിവരങ്ങള്‍"), fontmalhead));
        cell.MinimumHeight = 25f;
        cell.Colspan = 9;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വാര്‍ഡ് നം / പേര്"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വോട്ടര്‍മാരുടെ എണ്ണം"), fontmal));
        cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പങ്കെടുത്ത വോട്ടര്‍മാരുടെ എണ്ണം"), fontmal));
        cell.Colspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രാമ/വാര്‍ഡ്സഭ കൂടിയ സ്ഥലം"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീയതി"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഹാജര്‍ ശതമാനം"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        cell.Border = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(" ", fontmal));
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ് ത്രീ"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുരുഷന്‍"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.Border = 0;
        cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        cell.Colspan = 2;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        cell.Colspan = 2;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_gramasabha_S", CommandType.StoredProcedure, arr);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][12].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][14].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][13].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][16].ToString(), fontmal));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][15].ToString(), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
        }
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);

        /*---------------------------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("II. 31.03." + FinYearid  + "  ലെ  നീക്കിയിരിപ്പ് വിശദാംശം  (RP 40(a) പ്രകാരം)", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_BankOB", CommandType.StoredProcedure, arr);
        table = new PdfPTable(2);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാങ്ക്"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ് (ഓ.ബി)"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        double fltTotal = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString()));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
            fltTotal += double.Parse(ds.Tables[0].Rows[i][1].ToString() == "" ? "0" : ds.Tables[0].Rows[i][1].ToString());
        }
        cell = new PdfPCell(new Phrase("Total"));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(fltTotal.ToString()));
        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        table.AddCell(cell);
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);

        /*-----------------------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase("III. "));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("നികുതി നികുതിയേതര വരവുകള്‍"), fontmal));
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) അക്രൂവല്‍ അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("1"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("2"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("3"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("4"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("5"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("6"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("7"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.നം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇന്‍കം & എക്സപെന്‍ഡിച്ചര്‍ പത്രിക പ്രകാരമുള്ള പ്രതീക്ഷിത വരുമാനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current) (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43)"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം മുന്‍വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (arrear)    (റസീറ്റ് ആന്റ് പേമെന്റ് അക്കൌണ്ട് പ്രകാരം -ആര്‍.പി-43, ആര്‍.പി-1)"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അടുത്ത വര്‍ഷങ്ങളിലേക്ക് ലഭിച്ച തുക (advance) (ആര്‍.പി-36)"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെ തന്‍വര്‍ഷം വരവ് (5+6+7)"), fontmal));
        table.AddCell(cell);
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("select intincometype,chvincometypemal from m_incometype", CommandType.Text);


        for (int j = 0; j < dsTemp.Tables[0].Rows.Count; j++)
        {
            cell = new PdfPCell(new Phrase((j + 1).ToString(), EngFont));
            arrTemp.Clear();
            arrTemp.Add(lb);
            arrTemp.Add(yearid);
            arrTemp.Add(dsTemp.Tables[0].Rows[j][0]);
            ds = new DataSet();
            ds = ClsGlobal.Fetch("SP_tb_ownfundaccrualincomeRPT_Sel", CommandType.StoredProcedure, arrTemp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cell.Rowspan = ds.Tables[0].Rows.Count + 1;
            }


            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[j][1].ToString(), fontmalhead, EngFont)));
            cell.Colspan = 6;
            table.AddCell(cell);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][14].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][15].ToString(), fontmal, EngFont)));
                table.AddCell(cell);


            }
        }
        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;

        pdfDoc.Add(table);





        /*-----------------------------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി) കാഷ് അടിസ്ഥാനത്തിലുളള നികുതി നികുതിയേതര വരുമാനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("1"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("2"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("3"), fontmal));
        table.AddCell(cell);



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.നം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷത്തേക്ക് ലഭിച്ച തുക (current)(റസീറ്റ് ആന്റ് പേമന്റ് അക്കൌണ്ട് പ്രകാരം)"), fontmal));
        table.AddCell(cell);


        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        dsTemp = new DataSet();
        dsTemp = ClsGlobal.Fetch("select intincometype,chvincometypemal from m_incometype", CommandType.Text);



        for (int j = 0; j < dsTemp.Tables[0].Rows.Count; j++)
        {
            cell = new PdfPCell(new Phrase((j + 1).ToString(), EngFont));
            arrTemp.Clear();
            arrTemp.Add(lb);
            arrTemp.Add(yearid);
            arrTemp.Add(dsTemp.Tables[0].Rows[j][0]);
            ds = new DataSet();
            ds = ClsGlobal.Fetch("SP_ownfunddirectincomeRPT_S", CommandType.StoredProcedure, arrTemp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cell.Rowspan = ds.Tables[0].Rows.Count + 1;
            }


            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsTemp.Tables[0].Rows[j][1].ToString(), fontmalhead, EngFont)));
            cell.Colspan = 6;
            table.AddCell(cell);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell(cell);


            }
        }


        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);





        /*----------Sulekha Datas--------------------------------------------------------------------------------------------------*/

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വരവ് ഭാഗം"), fontmalheadmain));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന ഗ്രാന്റുകള്‍-ലഭ്യതയും വിനിയോഗവും"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(8);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന ബഡ്ജറ്റ് അനുബന്ധം 4 പ്രകാരം വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സംസ്ഥാന സര്‍ക്കാര്‍ അനുവദിച്ച തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റസീപ്റ്റ് & പേമെന്റ് പ്രകാരം വരവ് ചെലവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ത.സ്വ.ഭ.സ്ഥാപനം വാര്‍ഷിക പദ്ധതിയില്‍ വകയിരുത്തിയ തുക"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ചെലവഴിച്ച തുക/ശതമാനം"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ലാപ്സായ തുക/ശതമാനം(4-5)"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(8)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        DataSet dsStateGrants = new DataSet();
        dsStateGrants = ClsGlobal.Fetch("SP_tb_stategrantsRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < dsStateGrants.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase((i + 1).ToString()));
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(dsStateGrants.Tables[0].Rows[i][1].ToString()), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][2].ToString()));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][3].ToString()));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dsStateGrants.Tables[0].Rows[i][4].ToString()));
            table.AddCell(cell);
            PdfPTable pdfSubtbl1 = new PdfPTable(2);
            PdfPTable pdfSubtbl2 = new PdfPTable(2);

            arr.Clear();
            arr.Add(lb);
            arr.Add(yearid);
            arr.Add(dsStateGrants.Tables[0].Rows[i][0]);
            ds = ClsGlobal.Fetch("SP_StateFundExpenseRPT_S", CommandType.StoredProcedure, arr);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {


                cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[j][2].ToString()), fontmal));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl1.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][3].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl1.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][6].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl2.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[j][7].ToString()));
                cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
                cell.MinimumHeight = 30f;
                pdfSubtbl2.AddCell(cell);




            }
            table.AddCell(pdfSubtbl1);
            table.AddCell(pdfSubtbl2);
            cell = new PdfPCell(new Phrase((dsStateGrants.Tables[0].Rows[i][5].ToString() + ", " + Math.Round(double.Parse(dsStateGrants.Tables[0].Rows[i][6].ToString().Trim() == "" ? "0" : dsStateGrants.Tables[0].Rows[i][6].ToString().Trim()), 2).ToString() + " %")));
            table.AddCell(cell);
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        float[] widths = new float[] { 20f, 50f, 40f, 40f, 50f, 80f, 80f, 40f };
        table.SetWidths(widths);
        pdfDoc.Add(table);






        /*-----------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("മറ്റ് പ്രത്യേകോദ്ദേശ്യ ഗ്രാന്റുകള്‍/പിരിവുകള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);


        table = new PdfPTable(9);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.Colspan = 4;
        cell.MinimumHeight = 25f;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        cell.Rowspan = 2;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));
        cell.Rowspan = 2;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുണഭോക്താക്കളുടെ എണ്ണം"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നിലവിലുണ്ടായിരുന്നവര്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്"), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കം  ചെയ്യപ്പെട്ടവര്‍ "), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി ഗുണഭോക്താക്കള്‍ "), fontmal));

        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_otherspecialgrants", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), EngFontBold));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][7].ToString(), EngFontBold));
                table.AddCell((cell));
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), EngFont));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][7].ToString(), EngFont));
                table.AddCell((cell));
            }

        }









        float[] width = { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //----------------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase("II"));
        ph.Add(new Phrase(objMal1.unicodetoMalayamFont("കേന്ദ്രഫണ്ട്"), fontmalheadsub));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(5);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫണ്ടിനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_incomeexpendituremnregsRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

            }
        }

        width = new float[] { 1f, 6f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-------------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("VII.സംയുക്ത പ്രോജക്റ്റുകള്‍ ക്കുവേണ്ടിയും, മറ്റ് സര്‍ക്കാര്‍ ഏജന്‍സികള്‍ മുതലായവയില്‍ നിന്നും ലഭിച്ച തുകയുടെ വിവരം", fontmalhead, EngFontBold)));

        pdfDoc.Add(ph);



        table = new PdfPTable(5);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഏജന്‍സി"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("tb_jointventureexpenditureRPT_Sel", CommandType.StoredProcedure, arr);
        double totob = 0, totexp = 0, totincome = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totob += double.Parse(ds.Tables[0].Rows[i][8].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][8].ToString().Trim());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totincome += double.Parse(ds.Tables[0].Rows[i][9].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][9].ToString().Trim());
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            totexp += double.Parse(ds.Tables[0].Rows[i][10].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][10].ToString().Trim());
        }
        cell = new PdfPCell(new Phrase(" "));
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase("Total"));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totob.ToString()));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totincome.ToString()));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(totexp.ToString()));
        table.AddCell(cell);

        width = new float[] { 1f, 6f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        /*------------------------------------------------------------------------------------------------------------------------------------------------*/
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("VIII. ഋണശീര്‍ഷ വരവുകള്‍", fontmalhead, EngFontBold)));

        pdfDoc.Add(ph);


        table = new PdfPTable(7);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തിരിച്ചു നല്‍കല്‍"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്ടുകെട്ടല്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_negativeincomeRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell(cell);
            }
        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        /*-------------------------------------------------------------------------------------------------------------------*/



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("IX. വായ്പ്പ തിരിച്ചടവ്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(7);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വര്ഷികാരംഭത്തില്‍ തിരികെ ലഭിക്കാനുണ്ടായിരുന്ന തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം നല്‍കിയ തുക"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ലഭിച്ചത്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വര്‍ഷാവസാനം തിരികെ ലഭിക്കുവാന്‍ ബാക്കിയുള്ളത്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്ക്ക്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(6)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(7)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_loanrepaymentRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase("  ", fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString()));
                table.AddCell(cell);

                //cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                //table.AddCell(cell);
            }
            else
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString()));
                table.AddCell(cell);

                //cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                //table.AddCell(cell);
            }
        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //ph = new Paragraph(new Phrase("Total (II + III + IV + V + VI + VII + VII + IX) ="));
        //pdfDoc.Add(ph);


        /*-------------------------------------------------------------------------------------------------------------------*/


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("X  കേന്ദ്ര സംസ്ഥാന സര്‍ക്കാരുകള്‍ ഗുണഭോക്താക്കള്‍ക്ക് നേരിട്ട് കൈമാറ്റം ചെയ്യുന്ന തുകകളുടെ വിവരങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);


        table = new PdfPTable(8);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(1)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(2)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(3)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(4)"), fontmal));
        cell.MinimumHeight = 25f;
        table.AddCell(cell);



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("(5)"), fontmal));
        cell.Colspan = 4;
        cell.MinimumHeight = 25f;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്ര.ന"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വരവ്"), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുണഭോക്താക്കളുടെ എണ്ണം"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell(cell);



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നിലവിലുണ്ടായിരുന്നവര്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" തന്‍വര്‍ഷം കൂട്ടിച്ചേര്‍ത്തത്"), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നീക്കം  ചെയ്യപ്പെട്ടവര്‍ "), fontmal));

        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാക്കി ഗുണഭോക്താക്കള്‍ "), fontmal));

        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_directbeneficiaryexpenditureRPT_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i == ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase(" ", fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
                table.AddCell((cell));
            }
            else
            {


                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][1].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][4].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][5].ToString(), fontmal));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
                table.AddCell((cell));
            }

        }
        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //------------------------------------------------------------------------------------------------------------------


        //ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ചെലവിനം"), fontmalhead));
        //pdfDoc.Add(ph);


        //int mainid = 0;


        //table = new PdfPTable(3);

        //ds.Clear();
        //ds.Dispose();

        //ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
        //    {
        //        ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
        //        pdfDoc.Add(ph);
        //        mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
        //    }
        //    cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
        //    cell.MinimumHeight = 25f;
        //    cell.Colspan = 3;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("Sl no."));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("HEAD"));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase("Amount"));
        //    cell.MinimumHeight = 25f;
        //    table.AddCell((cell));

        //    DataSet dsExpense = new DataSet();
        //    arr.Clear();
        //    arr.Add(lb);
        //    arr.Add(yearid);
        //    arr.Add(ds.Tables[0].Rows[i][0]);
        //    arr.Add(ds.Tables[0].Rows[i][1]);
        //    dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

        //    for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
        //    {


        //        if (j == dsExpense.Tables[0].Rows.Count - 1)
        //        {
        //            cell = new PdfPCell(new Phrase("  "));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
        //            table.AddCell((cell));
        //        }
        //        else
        //        {
        //            cell = new PdfPCell(new Phrase((j + 1).ToString()));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
        //            table.AddCell((cell));
        //            cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
        //            table.AddCell((cell));
        //        }


        //    }
        //    table.WidthPercentage = 95;
        //    table.SpacingBefore = 20f;
        //    pdfDoc.Add(table);
        //}

        //-------------------------------RAKHI----------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ചെലവിനം"), fontmalhead));
        pdfDoc.Add(ph);


        int mainid = 0;


        table = new PdfPTable(3);

        ds.Clear();
        ds.Dispose();

        ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
        ph = new Paragraph(new Phrase(ds.Tables[0].Rows[0][2].ToString(), titleFont));
        pdfDoc.Add(ph);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
            //{
            //    ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
            //    pdfDoc.Add(ph);
            //    mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
            //}
            if (int.Parse(ds.Tables[0].Rows[i][0].ToString()) == 1)
            {
                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
                cell.MinimumHeight = 25f;
                cell.Colspan = 3;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Sl no."));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("HEAD"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Amount"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                DataSet dsExpense = new DataSet();
                arr.Clear();
                arr.Add(lb);
                arr.Add(yearid);
                arr.Add(ds.Tables[0].Rows[i][0]);
                arr.Add(ds.Tables[0].Rows[i][1]);
                dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

                for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
                {


                    if (j == dsExpense.Tables[0].Rows.Count - 1)
                    {
                        cell = new PdfPCell(new Phrase("  "));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
                        table.AddCell((cell));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase((j + 1).ToString()));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
                        table.AddCell((cell));
                    }


                }
            }
            else
            {

            }
        }
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(3);

        ds.Clear();
        ds.Dispose();

        ds = ClsGlobal.Fetch("select intmainexpendituretype,intsubexpendituretype,chvmainexpendituretype, chvsubexpendituretype from m_expendituretype", CommandType.Text);
        ph = new Paragraph(new Phrase("Service Expense", titleFont));
        pdfDoc.Add(ph);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //if (mainid != int.Parse(ds.Tables[0].Rows[i][0].ToString()))
            //{
            //    ph = new Paragraph(new Phrase(ds.Tables[0].Rows[i][2].ToString(), titleFont));
            //    pdfDoc.Add(ph);
            //    mainid = int.Parse(ds.Tables[0].Rows[i][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][0].ToString().Trim());
            //}
            if (int.Parse(ds.Tables[0].Rows[i][0].ToString()) == 2)
            {
                cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][3].ToString()));
                cell.MinimumHeight = 25f;
                cell.Colspan = 3;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Sl no."));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("HEAD"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase("Amount"));
                cell.MinimumHeight = 25f;
                table.AddCell((cell));

                DataSet dsExpense = new DataSet();
                arr.Clear();
                arr.Add(lb);
                arr.Add(yearid);
                arr.Add(2);
                arr.Add(1);
                dsExpense = ClsGlobal.Fetch("Sp_expenditureRPT_S", CommandType.StoredProcedure, arr);

                for (int j = 0; j < dsExpense.Tables[0].Rows.Count; j++)
                {


                    if (j == dsExpense.Tables[0].Rows.Count - 1)
                    {
                        cell = new PdfPCell(new Phrase("  "));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString(), fontmalhead, EngFontBold)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString(), EngFontBold));
                        table.AddCell((cell));
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase((j + 1).ToString()));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(dsExpense.Tables[0].Rows[j][0].ToString().Replace("Monthly", ""), fontmal, EngFont)));
                        table.AddCell((cell));
                        cell = new PdfPCell(new Phrase(dsExpense.Tables[0].Rows[j][1].ToString()));
                        table.AddCell((cell));
                    }


                }
            }
            else
            {

            }
        }
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-------------------------------RAKHI----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വികസനഫണ്ട് - മേഖലാടിസ്ഥാനത്തിലുള്ള വകയിരുത്തല്‍"), fontmalhead));
        pdfDoc.Add(ph);
        table = new PdfPTable(15);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമ നം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിഭാഗം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ആകെവകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉല്പാദന മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സേവന മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പശ്ചാത്തല മേഖല"), fontmal));
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(""));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase("%"));
        table.AddCell((cell));
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_devfundsec_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(i != (ds.Tables[0].Rows.Count - 1) ? (i + 1).ToString() : " ", fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][4].ToString()), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][6].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][12].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][13].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][14].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][15].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][21].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][22].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][23].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][24].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][30].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][31].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][32].ToString(), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][33].ToString(), fontmal));
            table.AddCell((cell));
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/



        width = new float[] { 1f, 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("വിഭവ വകയിരുത്തല്‍ / ചെലവ് വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);



        table = new PdfPTable(5);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമ നം"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വിഭവ സ്രോതസ്സുകള്‍"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("വകയിരുത്തിയ തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവഴിച്ച തുക"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെലവ് ശതമാനം"), fontmal));
        table.AddCell((cell));

        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_resourcealloc_S", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (i != ds.Tables[0].Rows.Count - 1)
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), EngFont));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }

        }
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_resourcealloc_AmtTot", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cell = new PdfPCell(new Phrase(" ", EngFont));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmalhead, EngFontBold)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][1].ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));
            float percnetage = float.Parse(ds.Tables[0].Rows[0][1].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0][1].ToString().Trim()) / float.Parse(ds.Tables[0].Rows[0][0].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[0][0].ToString().Trim()) * 100;
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(percnetage.ToString(), fontmalhead, EngFontBold)));
            table.AddCell((cell));

        }
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------




        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("III. വാര്‍ഷിക പദ്ധതി ചെലവുകള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) ധനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_tb_StandingCommittee_S", CommandType.StoredProcedure, arr);
        DataSet dsMembers = new DataSet();
        DataSet dsdates = new DataSet();
        table = new PdfPTable(2);
        if (ds.Tables[0].Rows.Count > 0)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][21].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അംഗങ്ങള്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));

            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=1 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" കൂടിയ യോഗങ്ങളുടെ തീയതി"), fontmal));
            table.AddCell((cell));

            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=1 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            ph.Add(new Phrase("No of Meetings : " + dsdates.Tables[0].Rows.Count.ToString() + "  ", EngFont));
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റവന്യൂ വരവുകള്‍ പരിശോധന വിവരങ്ങള്‍"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][23].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പുതിയ റവന്യൂ വരവുകള്‍ കണ്ടെത്താന്‍ നടപടി സ്വീകരിച്ചതിന്റെ വിവരം (തീരുമാനം നം, തീയതി,ഇനം)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][24].ToString() + "," + ds.Tables[0].Rows[0][25].ToString() + "," + ds.Tables[0].Rows[0][26].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കഴിഞ്ഞ മാസത്തെ ചെലവു വൗച്ചറുകള്‍ പരിശോധിച്ച് അംഗീകരിച്ച തീയതി"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[0][27].ToString()));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പ്രതിമാസ വരവ് ചെലവ് അക്കൗണ്ട് സെക്രട്ടറി തയ്യാറാക്കി സമര്‍പ്പിച്ചതീയതി"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[0][28].ToString()));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഫ്രണ്ട് ഒാഫീസ് സംവിധാനത്തിന്റെ പ്രവര്‍ത്തനം വിലയിരുത്തല്‍ - അജണ്ട / തീരുമാനം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][29].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗുഡ് ഗവര്‍ണന്‍സിനു വേണ്ടി നടപ്പിലാക്കിയ ആധുനികവല്‍കരണ പ്രോജക്ട്ുകള്‍ (നം, അടങ്കല്‍, ചെലവ്)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("No : " + ds.Tables[0].Rows[0][30].ToString() + ",Expense :" + ds.Tables[0].Rows[0][31].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഐ.എസ്.ഒ സര്‍ട്ടിഫിക്കറ്റ് നേടിയിട്ടുണ്ടെങ്കില്‍ ആയതിന്റെ വിവരങ്ങള്‍"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][34].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തീര്‍പ്പാക്കാന്‍ അവശേഷിക്കുന്ന ഒാഡിറ്റ് റിപ്പോര്‍ട്ടിന്‍ മേല്‍ സ്വീകരിച്ച നടപടികളുടെ വിവരം (വര്‍ഷം, ഖണ്ഡിക)"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വര്‍ഷം : " + ds.Tables[0].Rows[0][35].ToString() + ", ഖണ്ഡിക :" + ds.Tables[0].Rows[0][36].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);


        }


        //-----------------------------------------------------------------------------------------------------------
        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("എ (i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍"), fontmal));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-----------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("എ (ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("പൊതുഭരണവുമായി ബന്ധപ്പെട്ട് രൂപീകരിക്കപ്പെട്ട  കമ്മിറ്റികളുടെയും യോഗങ്ങളുടേയും വിവരങ്ങള്‍"), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(1);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------
        //Rakhi.S Empid.9187 [22.06.2019]
        //-----------------------------------------------------------------------------------------------------------

        int sectoridtemp = 0, sectorinitial = 1;
        int standingcommitteetype = 1;
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(standingcommitteetype);
        ds = ClsGlobal.Fetch("SP_tb_ProjectDetailsSectorWiseRuralRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                int sectorID = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());


                if (sectorinitial == 1)
                {
                    ph = new Paragraph(new Phrase(""));
                    ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                    ph.Alignment = Element.ALIGN_CENTER;
                    ph.SpacingBefore = 10f;
                    pdfDoc.Add(ph);
                    sectorinitial++;

                    table = new PdfPTable(11);
                    pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                }
                else
                {
                    if (sectoridtemp != sectorID)
                    {
                        ph = new Paragraph(new Phrase(""));
                        ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                        ph.Alignment = Element.ALIGN_CENTER;
                        ph.SpacingBefore = 10f;
                        pdfDoc.Add(ph);
                        sectorinitial++;

                        table = new PdfPTable(11);
                        pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                    }
                    else
                    {
                    }


                }

                sectoridtemp = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());

            }
        }

        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ബി. വികസനകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=2 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=2 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ",", EngFont));
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);



        }


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ബി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        //-----------------------------------------------------------------------------------------------------------
        //Rakhi.S Empid.9187 [18.06.2019]
        //-----------------------------------------------------------------------------------------------------------

        sectoridtemp = 0; sectorinitial = 1;
        standingcommitteetype = 2;
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(standingcommitteetype);
        ds = ClsGlobal.Fetch("SP_tb_ProjectDetailsSectorWiseRuralRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                int sectorID = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());


                if (sectorinitial == 1)
                {
                    ph = new Paragraph(new Phrase(""));
                    ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                    ph.Alignment = Element.ALIGN_CENTER;
                    ph.SpacingBefore = 10f;
                    pdfDoc.Add(ph);
                    sectorinitial++;

                    table = new PdfPTable(11);
                    pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                }
                else
                {
                    if (sectoridtemp != sectorID)
                    {
                        ph = new Paragraph(new Phrase(""));
                        ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                        ph.Alignment = Element.ALIGN_CENTER;
                        ph.SpacingBefore = 10f;
                        pdfDoc.Add(ph);
                        sectorinitial++;

                        table = new PdfPTable(11);
                        pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                    }
                    else
                    {
                    }


                }

                sectoridtemp = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());

            }
        }

        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1.കൃഷി അനുബന്ധ മേഖലകളും  (പരിസ്ഥിതി, ജലസേചനം, മണ്ണ്-ജലസംരക്ഷണം, വനവത്കരണം, മത്സ്യബന്ധനം ഉള്‍പ്പടെ)", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("[SP_tb_projectdetailsAgriRPT_Sel]", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));




        //}






        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);
        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);

        ////-----------------------------------------------------------------------------------------------------------



        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("5. മൃഗസംരക്ഷണം, ക്ഷീരവികസനം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsAnimmalHusbndryRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));




        //}






        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);
        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);




        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("6.പ്രാദേശികസാമ്പത്തിക വികസനം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsLoclDvlpmntRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));





        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);




        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("7.പൊതുമരാമത്ത് (വൈദ്യുതി,  ഊര്‍ജ്ജം ഉള്‍പ്പെടെ)", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsPublicWorkRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));





        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);






        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------


        table = new PdfPTable(8);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ള തെരുവുവിളക്കുകളുടെ തരവും എണ്ണവും", fontmalhead, EngFont)));
        cell.Colspan = 6;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmalhead, EngFont)));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒാര്‍ഡിനറി ബള്‍ബ്", fontmalhead, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി.എഫ്.എല്‍നിലവിലുള്ളത്", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എല്‍.ഇ.ഡി", fontmalhead, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഫ്ലൂറസെന്റ് ട്യൂബ്", fontmalhead, EngFont)));
        cell.Rowspan = 2;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുളളവ", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഡിസ്മാന്റില്‍ ചെയ്തത്", fontmalhead, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി സ്ഥാപിച്ചത്", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_streetlightRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString() + ") " + ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell((cell));





        }
        width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(" 8(a) മീറ്ററിംഗ് സംവിധാനത്തിന്റെ വിശദാംശങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(2);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ സ്ഥാപിച്ചിട്ടുള്ള മീറ്ററുകളുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തെരുവുവിളക്കുകള്‍ക്കായി മീറ്റര്‍ സ്ഥാപിച്ചിട്ടില്ലെങ്കില്‍ പ്രസ്തുത ആവശ്യത്തിലേക്ക് നാളിതുവരെ ഒടുക്കിയ തുകയുടെ വിവരങ്ങള്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));

            table.AddCell((cell));
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);





        //-----------------------------------------------------------------------------------------------------------
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("8(b) വാങ്ങിയ തെരുവുവിളക്കുകളും ചെലവഴിച്ച തുകയും- വിശദവിവരങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(6);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷം വാങ്ങിയ തെരുവുവിളക്കുകള്‍", fontmalhead, EngFont)));
        cell.Colspan = 6;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി.എഫ്.എല്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എല്‍.ഇ.ഡി", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ട്യൂബ്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുളളവ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അനുബന്ധ ഉപകരണങ്ങള്‍", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));

            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(" 8(c) തെരുവുവിളക്ക് പരിപാലനം - ചെലവുവിവരങ്ങള്‍", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);


        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ട് മുഖേന", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ട് മുഖേനയല്ലാതെ", fontmalhead, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        //Rakhi 07.01.2021
        ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ds = ClsGlobal.Fetch("SP_tb_streetlightmeteringRPT_Sel", CommandType.StoredProcedure, arr);

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എ.എം.സി", fontmalhead, EngFont)));
            table.AddCell((cell));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][9].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][12].ToString(), fontmal, EngFont)));

            table.AddCell((cell));



            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കരാര്‍ നിയമനം", fontmalhead, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][10].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][13].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കെ.എസ്.ഇ.ബി സൂപ്പര്‍വിഷന്‍ ചാര്‍ജ്", fontmalhead, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][11].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][14].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

           
        }
        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("8(d) തെരുവുവിളക്കുകളുടെ വെെദ്യുതി ചാര്‍ജ്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);


        table = new PdfPTable(2);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മാസം", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുക്കിയ തുക", fontmalhead, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        ds = ClsGlobal.Fetch("SP_tb_streetlightexpenditureRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }





        table.WidthPercentage = 95;
        table.SpacingBefore = 30f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("സി. ക്ഷേമകാര്യ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=3 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=3 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            if (dsdates.Tables[0].Rows.Count > 0)
            {
                ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ", ", EngFont));
            }
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);

        }


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("സി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(3);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------
        //Rakhi.S Empid.9187 [19.06.2019]
        //-----------------------------------------------------------------------------------------------------------

        sectoridtemp = 0;
        sectorinitial = 1;
        standingcommitteetype = 3;
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(standingcommitteetype);
        ds = ClsGlobal.Fetch("SP_tb_ProjectDetailsSectorWiseRuralRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                int sectorID = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());


                if (sectorinitial == 1)
                {
                    ph = new Paragraph(new Phrase(""));
                    ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                    ph.Alignment = Element.ALIGN_CENTER;
                    ph.SpacingBefore = 10f;
                    pdfDoc.Add(ph);
                    sectorinitial++;

                    table = new PdfPTable(11);
                    pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                }
                else
                {
                    if (sectoridtemp != sectorID)
                    {
                        ph = new Paragraph(new Phrase(""));
                        ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                        ph.Alignment = Element.ALIGN_CENTER;
                        ph.SpacingBefore = 10f;
                        pdfDoc.Add(ph);
                        sectorinitial++;

                        table = new PdfPTable(11);
                        pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                    }
                    else
                    {
                    }


                }

                sectoridtemp = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());

            }
        }

        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------




        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1. ദാരിദ്ര്യ ലഘൂകരണം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsPoverty_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));





        //}


        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);




        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);




















        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2.സാമൂഹ്യ നീതി", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsSocial_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));






        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);

        /* -------------------------------------------------------------------------------------------------*/

        //ഭിന്നശേഷികാര്‍ക്കായി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍




        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഭിന്നശേഷികാര്‍ക്കായി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണഭോക്താക്കളുടെ എണ്ണം", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmal, EngFont)));
        table.AddCell((cell));


        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_budsschoolRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബഡ്സ് സ്കൂള്‍", fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സ്കോളര്‍ഷിപ്പ് / ബത്ത", fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഉപകരണങ്ങള്‍ വാങ്ങി നല്‍കല്‍", fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-------------------------------------------------------------------------------------------------------------------------------------------------

        //2 (a)      ബഡ്സ് സ്ക്കൂള്‍/ബഡ്സ് റിഹാബിലിറ്റേഷന്‍ സെന്റര്‍-വിവരങ്ങള്‍
        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("2 (എ)      ബഡ്സ് സ്ക്കൂള്‍/ബഡ്സ് റിഹാബിലിറ്റേഷന്‍ സെന്റര്‍-വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുണ്ട്", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷം സ്ഥാപിച്ചു", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലില്ല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മതിയായ അടിസ്ഥാന സൗകര്യങ്ങള്‍ ഉണ്ട്/ഇല്ല.", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവ് വിവരങ്ങള്‍", fontmal, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാഹനവാ‍ടക", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഓണറേറിയം", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഇതരചെലവുകള്‍", fontmal, EngFont)));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_budsschoolRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


            }


        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //-----------------------------------------------------------------------------------------------------------


        //ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("2(e)കുട്ടികള്‍,വൃദ്ധർ ,ട്രാന്സ്ജെലന്ഡേ്ഴ്സ്-പ്രോജക്ടുകളുടെ വിവരങ്ങള്‍ 2 (e)(1). കുട്ടികള്ക്കു വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFontBold)));
        //pdfDoc.Add(ph);
        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുട്ടികള്‍ക്ക് വേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);
        //arr.Add(2);
        //ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));






        //}






        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);
        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);










        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2(e)(2).വൃദ്ധര്ക്കുപവേണ്ടി നടപ്പിലാക്കിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);
        //arr.Add(3);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));





        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);










        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2(e)(3).പാലിയേറ്റിവ് കെയര്‍ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);
        //arr.Add(6);
        //ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //}





        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);

        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);




        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("3. വനിതാവികസനം മേഖല – ദാരിദ്ര്യനിര്മാനര്ജസനം ചുമതല – സ്ത്രീകള്ക്ക്  സ്വയംതൊഴിലും ഗ്രൂപ്പ് എംപ്ലോയ്മെന്റും വനിതാഘടകപദ്ധതിയില്‍ ഉള്പ്പെ്ടുത്തിയ പ്രോജക്ടുകള്‍", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);
        //arr.Add(1);
        //ds = ClsGlobal.Fetch("SP_tb_projectdetails_SelChildProj", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][26].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));



        //}


        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);




        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);









        ////-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("4. പട്ടിക ജാതി / പട്ടിക വര്ഗ്ഗര വികസനം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsSCST_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));



        //}





        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);

        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);





        //-----------------------------------------------------------------------------------------------------------



        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഡി. ആരോഗ്യം വിദ്യാഭ്യാസ സ്റ്റാന്റിംഗ് കമ്മിറ്റി", fontmalhead, EngFont)));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_StandingCommitteeRPT_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            table = new PdfPTable(2);

            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[0][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അംഗങ്ങള്‍(പേര് വിവരം)", fontmal, EngFont)));
            table.AddCell((cell));
            dsMembers.Clear();
            dsMembers.Dispose();
            dsMembers = ClsGlobal.Fetch("select chvAuditnameofmembermal from tb_Standingcommitteememberrs where intstandingcommitteetype=4 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();

            for (int i = 0; i < dsMembers.Tables[0].Rows.Count; i++)
            {

                ph.Add(objMal1.unicodetomalayalamenglish(dsMembers.Tables[0].Rows[i][0].ToString() + ",", fontmal, EngFont));

            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കൂടിയ യോഗങ്ങളുടെ തീയതി", fontmal, EngFont)));
            table.AddCell((cell));

            dsdates.Clear();
            dsdates.Dispose();
            dsdates = ClsGlobal.Fetch("select Convert(varchar,dtAuditDate,103) from tb_Standingcommitteemeetings where intstandingcommitteetype=4 and intfinancialyearid=" + yearid.ToString() + " and intlbid=" + lb.ToString(), CommandType.Text);
            ph = new Paragraph();
            if (dsdates.Tables[0].Rows.Count > 0)
            {
                ph.Add(new Phrase("No of Meetings:" + dsdates.Tables[0].Rows.Count.ToString() + ", ", EngFont));
            }
            for (int i = 0; i < dsdates.Tables[0].Rows.Count; i++)
            {
                ph.Add(new Phrase(objMal1.unicodetoMalayamFont(dsdates.Tables[0].Rows[i][0].ToString()) + " , ", fontmal));
            }
            table.AddCell((ph));
            cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പാസ്സാക്കിയ പ്രമേയങ്ങളുടെ എണ്ണം"), fontmal));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase((ds.Tables[0].Rows[0][13].ToString()), fontmal));
            table.AddCell((cell));

            table.WidthPercentage = 95;
            table.SpacingBefore = 20f;
            pdfDoc.Add(table);



        }

        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഡി(i) വര്‍ക്കിംഗ് ഗ്രൂപ്പുകള്‍", fontmal, EngFont)));
        cell.Colspan = 7;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഗ്രൂപ്പിന്റെ പേര്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ചെയര്‍മാന്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കണ്‍വീനര്‍(പേര് വിവരം)"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("കൂടിയ യോഗങ്ങളുടെ എണ്ണം / തീയതി"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സ്റ്റാറ്റസ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് /ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ്  കമ്മിറ്റിയായി പ്രവൃത്തിച്ചിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മോണിറ്ററിംഗ് റിപ്പോര്‍ട്ട് തയ്യാറാക്കിയിട്ടുണ്ട് / ഇല്ല"), fontmal));
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_WorkingGroupRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell(cell);

        }
        width = new float[] { 6f, 4f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഡി(ii) മറ്റ് കമ്മിറ്റികള്‍ യോഗങ്ങള്‍", fontmalhead, EngFontBold)));
        ph.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കമ്മിറ്റികളുടെ പേര്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രവര്‍ത്തന മേഖല", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗ വിവരം", fontmal, EngFont)));
        table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(4);
        ds = ClsGlobal.Fetch("SP_othercommitteeRPT_S", CommandType.StoredProcedure, arr);
        ////////
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------
        //Rakhi.S Empid.9187 [19.06.2019]
        //-----------------------------------------------------------------------------------------------------------

        sectoridtemp = 0; sectorinitial = 1;
        standingcommitteetype = 4;
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(standingcommitteetype);
        ds = ClsGlobal.Fetch("SP_tb_ProjectDetailsSectorWiseRuralRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                int sectorID = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());


                if (sectorinitial == 1)
                {
                    ph = new Paragraph(new Phrase(""));
                    ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                    ph.Alignment = Element.ALIGN_CENTER;
                    ph.SpacingBefore = 10f;
                    pdfDoc.Add(ph);
                    sectorinitial++;

                    table = new PdfPTable(11);
                    pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                }
                else
                {
                    if (sectoridtemp != sectorID)
                    {
                        ph = new Paragraph(new Phrase(""));
                        ph.Add(new Phrase(objMal1.unicodetoMalayamFont(ds.Tables[0].Rows[i][28].ToString()), fontmalheadsub));
                        ph.Alignment = Element.ALIGN_CENTER;
                        ph.SpacingBefore = 10f;
                        pdfDoc.Add(ph);
                        sectorinitial++;

                        table = new PdfPTable(11);
                        pdfDoc.Add(ProjectDetails_sectorWise_RPT(lb, yearid, standingcommitteetype, sectorID));

                    }
                    else
                    {
                    }


                }

                sectoridtemp = Convert.ToInt32(ds.Tables[0].Rows[i][27].ToString());

            }
        }

        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("1. ആരോഗ്യമേഖല", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsHealthRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));




        //}



        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);



        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);



        //----------------------------------------------------------------------------------------------------------------------------------



        //-----ആശുപത്രി-------------------------------


        table = new PdfPTable(7);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആശുപത്രി", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഇന്‍പേഷ്യന്റ്സ് (എണ്ണം)", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒൗട്ട് പേഷ്യന്റ്സ് (എണ്ണം)", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എച്ച്.എം.സി കള്‍ സംബന്ധിച്ചുള്ള വിവരങ്ങള്‍", fontmal, EngFont)));
        cell.Colspan = 2;

        cell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        cell.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എച്ച്.എം.സി രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല ", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഷിക കണക്കുകളുടെ വിവരം ", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("യോഗങ്ങള്‍ കൂടിയതിന്റെ വിവരങ്ങള്‍", fontmal, EngFont)));
        //table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(" ", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുവില്‍ സമര്‍പ്പിച്ചത്", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഒടുവില്‍ ഒാഡിറ്റ് നടത്തിയത്", fontmal, EngFont)));
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_hospitaldetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                //table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);














        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("2. കുടിവെള്ളം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsDrinkingWtr_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));



        //}





        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);

        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);



        //----------------------------------------------------------------------------------------------------------------------------------

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ജലനിധി പ്രകാരമുള്ള കുടിവെള്ള പദ്ധതികളുടെ വിവരം  "), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(9);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുടിവെള്ള പദ്ധതികള്‍ (എണ്ണം)", fontmal, EngFont)));
        cell.Colspan = 4;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുടിവെള്ള പദ്ധതി ജലസ്രോതസുകളുടെ വിവരം", fontmal, EngFont)));
        cell.Colspan = 7;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നിര്‍മ്മിച്ചത്", fontmal, EngFont)));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കിണര്‍", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുഴല്‍കിണര്‍", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കുളം", fontmal, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അരുവി", fontmal, EngFont)));
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നദി", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണ.സമിതി", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നേരിട്ട്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഗുണ.സമിതി", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നേരിട്ട്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("", fontmal, EngFont)));
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_drinkingwaterRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        //-----------------------------------------------------------------------------------------------------------


        table = new PdfPTable(4);
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പൊതു ടാപ്പുകളുടെ എണ്ണം", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 4;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നല്‍കിയത്", fontmal, EngFont)));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാര്‍ഡ്", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("എണ്ണം", fontmal, EngFont)));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_drinkingwaterTapsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);








        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("3. ശുചിത്വം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsClnDetRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));






        //}





        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);

        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);


        //-----------------------------------------------------------------------------------------------------------

        table = new PdfPTable(10);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഖര ദ്രവ മാലിന്യ സംസ്കരണ സംവിധാനങ്ങളുടെ വിവരങ്ങള്‍     ( ഗ്രാ.പ / വിട്ടുകിട്ടിയവ / കമ്മ്യൂണിറ്റി തലത്തിലുള്ളവയുടെ എണ്ണം)", fontmalhead, EngFont)));
        cell.Colspan = 6;

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഹരിത കര്‍മ്മ സേന രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("കേ.പരാ.ആക്ട് 219(x) വകുപ്പ് (സര്‍ക്കുലര്‍ നം  576/ഡി.സി1/16/തസ്വഭവ , 24.09.16) പ്രകാരം ശുചിത്വത്തിന് ഫണ്ട് രൂപീകരിച്ചിട്ടുണ്ട് / ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടില്‍ ഉല്‍പ്പെടുതാതെ ചെലവഴിച്ച തുകയുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഉപോത്പനങ്ങളുടെ വില്‍പനയില്‍ നിന്നും ലഭിച്ചിട്ടുള്ള വരുമാനത്തിന്റെ വിവരം (വെര്‍മി കമ്പോസ്റ്റ്, മണ്ണിര കമ്പോസ്റ്റ് മുതലായവ)", fontmalhead, EngFont)));
        cell.Rowspan = 3;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmalhead, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി ആരംഭിച്ചവ", fontmalhead, EngFont)));
        cell.Colspan = 3;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബയോഗ്യാസ് പ്ലാന്റ്", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെക്കാനിക്കല്‍പ്ലാന്റുകള്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ബയോഗ്യാസ് പ്ലാന്റ്", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെര്‍മി കമ്പോസ്റ്റ് / മറ്റുള്ളവ", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_solidwastemanagementRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString() + "- " + ds.Tables[0].Rows[i][10].ToString() + ", ", fontmal, EngFont)));
            table.AddCell((cell));

        }












        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("4. വിദ്യാഭ്യാസം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsEducation_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));



        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);






        //-----------------------------------------------------------------------------------------------------------
        table = new PdfPTable(10);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("സ്കൂളുകള്‍", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വിദ്യാര്‍ത്ഥികളുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അധ്യാപകരുടെ എണ്ണം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("അടിസ്ഥാന സൗകര്യങ്ങളുടെ ലഭ്യത)", fontmalhead, EngFont)));
        cell.Colspan = 6;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 20f;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പി.റ്റി.എ രൂപീകരിച്ചിട്ടുണ്ട്/ ഇല്ല", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ജലം", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വെെദ്യുതി", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ഫര്‍ണീച്ചര്‍", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ടോയിലറ്റ്(എണ്ണം)", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വാഷ്ബയിസിന്‍(എണ്ണം)", fontmalhead, EngFont)));
        cell.Rotation = 90;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പാചക പുര", fontmalhead, EngFont)));
        cell.Rotation = 90;

        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);

        ds = ClsGlobal.Fetch("SP_tb_schoolRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
            table.AddCell((cell));



        }







        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //-----------------------------------------------------------------------------------------------------------

        //table = new PdfPTable(11);

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("5.  കല സാംസ്കാരികം, യുവജനകാര്യം", fontmalhead, EngFont)));
        //cell.Colspan = 11;
        //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        //cell.Rowspan = 2;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        //cell.Colspan = 5;
        //table.AddCell((cell));


        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട് ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        //table.AddCell((cell));

        //cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        //table.AddCell((cell));


        //ds.Clear();
        //ds.Dispose();
        //arr.Clear();
        //arr.Add(lb);
        //arr.Add(yearid);

        //ds = ClsGlobal.Fetch("SP_tb_projectdetailsArtRPT_Sel", CommandType.StoredProcedure, arr);

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));


        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));

        //    cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
        //    table.AddCell((cell));





        //}




        //width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        //table.SetWidths(width);


        //table.WidthPercentage = 95;
        //table.SpacingBefore = 20f;
        //pdfDoc.Add(table);



        //-------------------------------------------------------------------------------------------------------------------------------------


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ഇ)പൊതുസുരക്ഷയും ആരോഗ്യവും-പഞ്ചായത്തിന്റെ ഇതര സേവനങ്ങളുടെ വിവരങ്ങള്‍"), fontmalhead));
        ph.Alignment = Element.ALIGN_LEFT;
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("1.പൊതു ശ്മശാനം/പവര്‍ ക്രിമറ്റോറിയം വിശദവിവരങ്ങള്‍"), fontmal));
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("നിലവിലുള്ളത്", fontmal, EngFont)));
        table.AddCell((cell));
        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പുതുതായി നിര്‍മ്മിച്ചത്‌", fontmal, EngFont)));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തന്‍വര്‍ഷ ചെലവ്", fontmal, EngFont)));
        table.AddCell((cell));


        //table.AddCell((cell));
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_crematoriumRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));
            }
        }



        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //ജനന രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("2.ജനന രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(5);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.Colspan = 2;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" ആശുപത്രി മുഖേന"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നേരിട്ട്"), fontmal));

        table.AddCell((cell));









        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //മരണ രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("3.മരണ രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(5);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.Colspan = 2;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" ആശുപത്രി മുഖേന"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" നേരിട്ട്"), fontmal));

        table.AddCell((cell));









        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        //വിവാഹ രജിസ്ട്രേഷന്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("4.വിവാഹ രജിസ്ട്രേഷന്‍"), fontmalhead));
        pdfDoc.Add(ph);




        table = new PdfPTable(4);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം അപേക്ഷിച്ചവര്‍"), fontmal));
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സര്‍ട്ടിഫിക്കറ്റ് നല്‍കല്‍ വിവരങ്ങള്‍"), fontmal));
        cell.Colspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("റിമാര്‍ക്ക്സ്"), fontmal));
        table.AddCell((cell));




        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));








        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" സമയ പരിധിക്കുള്ളില്‍"), fontmal));

        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയ പരിധി കഴിഞ്ഞ്"), fontmal));

        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" "), fontmal));

        table.AddCell((cell));

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_regstrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("5. വിവിധ പെന്‍ഷനുകള്‍ - അപേക്ഷ തീര്‍പ്പാക്കല്‍ വിവരങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);



        table = new PdfPTable(5);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("പെന്‍ഷനുകള്‍"), fontmal));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("അപേക്ഷകരുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധിക്കുള്ളില്‍ അനുവദിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധി കഴിഞ്ഞ് അനുവദിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നിരസിച്ചവയുടെ എണ്ണം"), fontmal));
        table.AddCell((cell));






        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_pensionRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        //6.കെട്ടിടങ്ങളുമായി ബന്ധപ്പെട്ട സേവനങ്ങള്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("6.കെട്ടിടങ്ങളുമായി ബന്ധപ്പെട്ട സേവനങ്ങള്‍"), fontmalhead));
        pdfDoc.Add(ph);

        table = new PdfPTable(15);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകരുടെ എണ്ണം"), fontmal));

        cell.Colspan = 5;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവ"), fontmal));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.Colspan = 5;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));





        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont(" പെര്‍മിറ്റ്"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നം. നല്‍കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ക്രമവത്കരണം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഉടമസ്ഥതാവകാശം"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("നികുതി ഒഴുവാക്കല്‍"), fontmal));
        cell.Rotation = 90;
        cell.VerticalAlignment = Element.ALIGN_TOP;
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_buildingdetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][6].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][7].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][8].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][9].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][10].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][11].ToString(), fontmal, EngFont)));
                table.AddCell((cell));


                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][12].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][13].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][14].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }




        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("7.വാസയോഗ്യമായ വീടില്ല എന്ന സര്‍ട്ടിഫിക്കറ്റ് / താമസക്കാരനാണ് എന്ന സര്‍ട്ടിഫിക്കറ്റ് / ഒക്കുപ്പന്‍സി സര്‍ട്ടിഫിക്കറ്റിനുള്ള അപേക്ഷയിന്‍ മേല്‍ സ്ഥല പരിശോധന നടത്തി റിപ്പോര്‍ട്ട് നല്‍കല്‍"), fontmalhead));
        pdfDoc.Add(ph);


        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));



        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_buildingdetailsRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][15].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
                table.AddCell((cell));




            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);




        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("8.ദേശീയ ഗ്രാമീണ തൊഴിലുറപ്പ് പദ്ധതി - രജിസ്ട്രേഷന്‍ / തൊഴില്‍കാര്‍ഡ് നല്‍കല്‍ , വേതന വിതരണം  "), fontmalhead));
        pdfDoc.Add(ph);


        table = new PdfPTable(4);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം തൊഴില്‍കാര്‍ഡിനുവേണ്ടി ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തൊഴില്‍കാര്‍ഡ് നല്‍കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയപരിധിക്ക് ശേഷം നല്‍കിയ തൊഴില്‍കാര്‍ഡുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_mnregsregistrationRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        //9. ലെെസന്‍സ് നല്‍കല്‍

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("9. ലെെസന്‍സ് നല്‍കല്‍  "), fontmalhead));
        pdfDoc.Add(ph);


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ) ഫാക്ടറി , വ്യവസായം, വ്യാപാരം, വര്‍ക്ക്ഷോപ്പ്, ക്വോറി , ഇഷ്ടിക കമ്പനി, ഹോളോ ബ്രിക്സ്  "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_licenseRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);





        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി) ലെെഫ് സ്റ്റോക്ക് ഫാം, പന്നി, പട്ടി മുതലായവ "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_licenseRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);

        //10. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനം വിശദാംശങ്ങള്‍ 

        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("10. ഫ്രണ്ട് ഒാഫീസ് സംവിധാനം വിശദാംശങ്ങള്‍  "), fontmalhead));
        pdfDoc.Add(ph);


        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("എ. ഫ്രണ്ട് ഒാഫീസ് ഡയറി "), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച (സേവനങ്ങള്‍ക്കുവേണ്ടി) അപേക്ഷകളുടെഎണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി തീര്‍പ്പാക്കിയവയുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_frontofficeRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][0].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][2].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);



        ph = new Paragraph(new Phrase(objMal1.unicodetoMalayamFont("ബി. ഇന്‍വേഡ് രജിസ്റ്റര്‍"), fontmal));
        pdfDoc.Add(ph);



        table = new PdfPTable(3);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തന്‍വര്‍ഷം ലഭിച്ച തപാലുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.MinimumHeight = 50f;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("സമയബന്ധിതമായി കെെമാറിയ തപാലുകളുടെ എണ്ണം"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ശേഷിക്കുന്നവ"), fontmal));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell((cell));


        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_tb_frontofficeRPT_Sel", CommandType.StoredProcedure, arr);

        if (ds.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
                table.AddCell((cell));

                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
                table.AddCell((cell));



            }
        }


        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);


        /*---------------------------------------------------------------------------------------------------------------------*/
        //int yeartemp = Convert.ToInt32(Session["FinYear"].ToString()) + 1;

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("II. 31.03." + yeartemp + " ലെ വിവിധ ഇനങ്ങളിലെ നീക്കിയിരിപ്പ് (40(b)പ്രകാരം)", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        ds = ClsGlobal.Fetch("SP_BankOB", CommandType.StoredProcedure, arr);
        table = new PdfPTable(2);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ബാങ്ക്"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("മുന്നിരിപ്പ് (ഓ.ബി)"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][0].ToString()));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(ds.Tables[0].Rows[i][2].ToString()));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
        }

        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;

        table.DefaultCell.MinimumHeight = 50f;
        pdfDoc.Add(table);







        /*------------------------------------------------------------------------------------------------------------*/

        table = new PdfPTable(1);

        table.WidthPercentage = 25;
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ഓഡിറ്റ് റിമാർക്കുകൾ ", fontmalheadsub, EngFontBold)));

        ph.SpacingAfter = 10f;
        table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
        table.AddCell(ph);
        table.SpacingBefore = 20f;
        pdfDoc.Add(table);
        String Remarks = "";
        DataSet dsMenu = new DataSet();
        dsMenu = ClsGlobal.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=0 and intParentMenuId=0 and intMenuId in (1,2,3,15,16,17,18,19,20)", CommandType.Text);
        String strMenu = "";
        String strSubMenu = "";
        int CntMain = 0;
        table1 = new PdfPTable(1);
        PdfPCell pdfcell1 = new PdfPCell();
        for (int i = 0; i < dsMenu.Tables[0].Rows.Count; i++)
        {
            Remarks = "";
            strMenu = dsMenu.Tables[0].Rows[i][1].ToString();
            DataSet dsSub = new DataSet();


            dsSub = ClsGlobal.Fetch("select intMenuId,chvMenuName from TB_MstMenu where intMenuType=1 and intParentMenuId=" + dsMenu.Tables[0].Rows[i][0].ToString(), CommandType.Text);
            if (dsSub.Tables[0].Rows.Count == 0)
            {

                Remarks = fillRemarks(int.Parse(dsMenu.Tables[0].Rows[i][0].ToString()), 0);

                if (Remarks.Trim() != "")
                {
                    CntMain++;

                    strMenu = CntMain.ToString() + " : " + strMenu;
                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strMenu, fontmalhead, EngFontBold)));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;
                    pdfcell1 = new PdfPCell(ph);
                    // Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER;
                    pdfcell1.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);


                    ph = new Paragraph(new Phrase("Remarks", EngFontBold));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;

                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);


                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(Remarks, fontmal, EngFont)));
                    // ph.Alignment = Element.ALIGN_JUSTIFIED;


                    ph.Alignment = Element.ALIGN_JUSTIFIED;

                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);

                }
            }
            int mainMenuCnt = 0; //How many times printed main Menu
            int Cntsub = 0;
            for (int j = 0; j < dsSub.Tables[0].Rows.Count; j++)
            {
                Remarks = "";

                Remarks = fillRemarks(int.Parse(dsMenu.Tables[0].Rows[i][0].ToString()), int.Parse(dsSub.Tables[0].Rows[j][0].ToString()));

                if (Remarks != "")
                {
                    if (mainMenuCnt == 0)
                    {
                        CntMain++;
                        strMenu = CntMain.ToString() + " : " + strMenu;
                        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strMenu, fontmalhead, EngFontBold)));
                        ph.IndentationLeft = 15f;
                        ph.IndentationRight = 10f;
                        pdfcell1 = new PdfPCell(ph);

                        table1.AddCell(pdfcell1);
                        mainMenuCnt++;
                    }
                    Cntsub++;
                    strSubMenu = "        " + Cntsub.ToString() + "): " + dsSub.Tables[0].Rows[j][1].ToString();
                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(strSubMenu, fontmal, EngFont)));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;
                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);

                    ph = new Paragraph(new Phrase("Remarks", EngFontBold));
                    ph.IndentationLeft = 15f;
                    ph.IndentationRight = 10f;

                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);

                    ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish(Remarks, fontmal, EngFont)));
                    // ph.Alignment = Element.ALIGN_JUSTIFIED;

                    ph.Alignment = Element.ALIGN_JUSTIFIED;

                    pdfcell1 = new PdfPCell(ph);
                    pdfcell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    table1.AddCell(pdfcell1);


                }
            }
        }
        table1.WidthPercentage = 95;
        pdfDoc.Add(table1);


        pdfDoc.Close();


        Response.Write(pdfDoc);
        Response.End();

    }
    public PdfPTable ProjectDetails_sectorWise_RPT(Int32 lb, Int32 yearid, Int32 standingcommitteetype, Int32 sectorID)
    {
        ArrayList arr = new ArrayList();
        DataSet ds = new DataSet();

        PdfPTable table = new PdfPTable(11);
        //table.SpacingBefore = 20f;

        PdfPCell cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("പ്രോജക്ടുകളുടെ വിവരം", fontmalhead, EngFont)));
        cell.Rowspan = 2;
        table.AddCell((cell));


        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വകയിരുത്തിയതുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ചെലവഴിച്ച തുക", fontmalhead, EngFont)));
        cell.Colspan = 5;
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട്/ഗു.വി ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("വികസന ഫണ്ട്", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മെ.ഫ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("തനത് ഫണ്ട്/ഗു.വി ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("മറ്റുള്ളവ ", fontmalhead, EngFont)));
        table.AddCell((cell));

        cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ ", fontmalhead, EngFont)));
        table.AddCell((cell));


        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(standingcommitteetype);
        arr.Add(sectorID);

        ds = ClsGlobal.Fetch("SP_tb_ProjectDetailsSectorRuralRPT_Sel", CommandType.StoredProcedure, arr);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][3].ToString(), fontmal, EngFont)));
            table.AddCell((cell));


            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][16].ToString(), fontmal, EngFont)));

            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][17].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][18].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][19].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][20].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][21].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][22].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][23].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][24].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][25].ToString(), fontmal, EngFont)));
            table.AddCell((cell));

        }

        float[] width = new float[] { 6f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f, 2f };
        table.SetWidths(width);
        table.WidthPercentage = 95;
        table.SpacingBefore = 20f;
        return table;
    }
    public void PrintSurPlus(string filename, Int32 lb)
    {
        
        //int lb = Convert.ToInt32(Session["LBID"]);
        int yearid = Convert.ToInt32(Session["Year"]);
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 15f, 15f);

        Response.ContentType = "application/pdf";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        writer.Close();
        pdfDoc.Open();


        Paragraph ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("VI. മിച്ചഫണ്ട്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("എ)തനത് വരുമാനം(ഇന്‍കം & എക്സ്പെന്‍ഡിച്ചര്‍ അക്കൌണ്ട് പ്രകാരം)(ജനറല്‍ പര്‍പ്പസ് ഗ്രാന്റ് ഒഴികെ)", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(lb);
        arr.Add(yearid);
        ClsGlobal.Fetch("sp_SyncSaankhyarptfinSurplus", CommandType.StoredProcedure,arr);
        arr.Add(1);

        ds = ClsGlobal.Fetch("SP_rptfinSurplusRPT_Sel", CommandType.StoredProcedure, arr);
        PdfPTable table = new PdfPTable(3);
        PdfPCell cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഷെഡ്യുള്‍"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തുക"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        double totalamtA = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
            totalamtA = totalamtA + double.Parse(ds.Tables[0].Rows[i][5].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][5].ToString().Trim());
            if ((i + 1) == ds.Tables[0].Rows.Count)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmalhead, EngFont)));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.PaddingRight = 20f;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(totalamtA.ToString(), EngFontBold));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Colspan = 2;
                table.AddCell(cell);
            }
        }

        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);




        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("ബി) ചെലവ്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        table = new PdfPTable(3);

        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഷെഡ്യുള്‍"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("ഇനം"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        cell = new PdfPCell(new Phrase(objMal1.unicodetoMalayamFont("തുക"), fontmalhead));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        ds.Clear();
        ds.Dispose();
        arr.Clear();
        arr.Add(lb);
        arr.Add(yearid);
        arr.Add(2);
        ds = ClsGlobal.Fetch("SP_rptfinSurplusRPT_Sel", CommandType.StoredProcedure, arr);
        double totalamtB = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][1].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][4].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish(ds.Tables[0].Rows[i][5].ToString(), fontmal, EngFont)));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cell);
            totalamtB = totalamtB + double.Parse(ds.Tables[0].Rows[i][5].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][5].ToString().Trim());
            if ((i + 1) == ds.Tables[0].Rows.Count)
            {
                cell = new PdfPCell(new Phrase(objMal1.unicodetomalayalamenglish("ആകെ", fontmalhead, EngFont)));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.PaddingRight = 20f;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(totalamtB.ToString(), EngFontBold));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.Colspan = 2;
                table.AddCell(cell);
            }
        }


        table.SpacingBefore = 25f;
        table.WidthPercentage = 95;
        pdfDoc.Add(table);

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("സി മിച്ച ഫണ്ട്", fontmalhead, EngFontBold)));
        pdfDoc.Add(ph);

        ph = new Paragraph(new Phrase(objMal1.unicodetomalayalamenglish("എ -ബി  : ", fontmalhead, EngFontBold)));
        ph.Add(new Phrase((totalamtA - totalamtB).ToString() + "/-", EngFontU));
        pdfDoc.Add(ph);
        pdfDoc.Close();

        Response.Write(pdfDoc);
        Response.End();

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (Session["Year"].ToString() == "21")
        {
            PrintReport("Annual_Report", Convert.ToInt32(Session["LBID"]));
        }
        else 
        {
            PrintReportNew("Annual_Report", Convert.ToInt32(Session["LBID"]));
        }
    }
    protected void BtnSurPlus_Click(object sender, EventArgs e)
    {
        PrintSurPlus("Surplus", Convert.ToInt32(Session["LBID"]));
    }
    public string fillRemarks(int intMenu, int intSubMenu)
    {
        string Remarks = "";
        DataSet ds = new DataSet();
        ArrayList arr = new ArrayList();
        arr.Add(Session["LBID"].ToString());
        arr.Add(Session["Year"].ToString());
        arr.Add(intMenu);
        arr.Add(intSubMenu);
        ds = ClsGlobal.Fetch("SP_Remarks_Audit_S", CommandType.StoredProcedure, arr);
        if (ds.Tables[0].Rows.Count > 0)
        {

            Remarks = ds.Tables[0].Rows[0][2].ToString();
        }

        return Remarks;
    }
}
