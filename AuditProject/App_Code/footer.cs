using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
/// <summary>
/// Summary description for footer
/// </summary>
public class Footer : PdfPageEventHelper
{
    // write on top of document
    //public override void OnOpenDocument(PdfWriter writer, Document document)
    //{
    //    base.OnOpenDocument(writer, document);
    //    PdfPTable tabFot = new PdfPTable(new float[] { 1F });
    //    tabFot.SpacingAfter = 10F;
    //    PdfPCell cell;
    //    tabFot.TotalWidth = 300F;
    //    cell = new PdfPCell(new Phrase("Header"));
    //    tabFot.AddCell(cell);
    //    tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
    //}

    // write on start of each page
    static String fontpatheng = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Fonts\\trebuc.TTF";
    static BaseFont eng = iTextSharp.text.pdf.BaseFont.CreateFont(fontpatheng, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    Font fonteng = new Font(eng, 8, Font.NORMAL, CMYKColor.BLACK);
    public override void OnStartPage(PdfWriter writer, Document document)
    {
        base.OnStartPage(writer, document);
    }

    // write on end of each page
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        base.OnEndPage(writer, document);
        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        tabFot.DefaultCell.Border = Rectangle.NO_BORDER;
        int pageN = writer.PageNumber;
  
        
        //PdfPCell cell;
        //cell.Border= 0;
        tabFot.TotalWidth = 700F;
      
        //cell = new PdfPCell(new Phrase("Footer"));
        tabFot.AddCell(new Phrase("Page:" + pageN.ToString() + "    Report is generated from http://audit.lsgkerala.gov.in  designed and developed by Information Kerala Mission" + " " + DateTime.Now, fonteng));
        tabFot.SpacingBefore = 2f;
        tabFot.WriteSelectedRows(0, -1, 2, document.Bottom +4, writer.DirectContent);
    }

    //write on close of document
    public override void OnCloseDocument(PdfWriter writer, Document document)
    {
        base.OnCloseDocument(writer, document);
    }
} 
