using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_YY;
using BOL_YY;

namespace SIMS_YY
{
    public partial class StudentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             SIMS view = new SIMS();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              

            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            
  PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);

            foreach (TableCell HeaderCell in GridView1.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GridView1.HeaderStyle.ForeColor);
                PdfPCell PdfCell = new PdfPCell(new Phrase(HeaderCell.Text, font));
                PdfCell.BackgroundColor = new BaseColor(GridView1.HeaderStyle.BackColor);
                pdfTable.AddCell(PdfCell);
            }

            foreach (GridViewRow gridViewRow in GridView1.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GridView1.RowStyle.ForeColor);
                    PdfPCell PdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    PdfCell.BackgroundColor = new BaseColor(GridView1.RowStyle.BackColor);
                    pdfTable.AddCell(PdfCell);
                }
            }
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Dept.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
        }
    }
}