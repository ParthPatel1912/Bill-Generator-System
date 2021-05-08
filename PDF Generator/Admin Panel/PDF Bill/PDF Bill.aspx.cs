using System;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using PartyBook.BAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
//using GemBox.Document;

public partial class PDF_Generator_Admin_Panel_PDF_Bill_PDF_Bill : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

        if (Request.QueryString["BillTeamID"] != null)
            Fill(Convert.ToInt32(Request.QueryString["BillTeamID"].ToString().Trim()));

        else
            Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
        //ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        //ComponentInfo.FreeLimitReached += (sen, ev) => ev.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
    }
    #endregion

    #region Btn PDF Download Event
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        if (Session["UserID"].ToString().Trim() == "1")
            ExportPDF();
        else
            lblError.Text = " &nbsp; &nbsp; &nbsp; &nbsp; You are not Admin !!!";
        //ExportPDFwithPassword();
        //ExportPdfWithGemBox();
    }
    #endregion

    #region ExportPDF Function using itextsharp

    //#region password protected PDF
    //private void ExportPDFwithPassword()
    //{
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter hw = new HtmlTextWriter(sw);
    //    pnlBill.RenderControl(hw);
    //    StringReader sr = new StringReader(sw.ToString());

    //    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //    HTMLWorker htmlworker = new HTMLWorker(pdfDoc);

    //    using (MemoryStream ObjememoryStream = new MemoryStream())
    //    {
    //        PdfWriter.GetInstance(pdfDoc, ObjememoryStream);
    //        pdfDoc.Open();
    //        htmlworker.Parse(sr);
    //        pdfDoc.Close();
    //        byte[] Filebytes = ObjememoryStream.ToArray();
    //        ObjememoryStream.Close();
    //        using (MemoryStream inputData = new MemoryStream(Filebytes))
    //        {
    //            using (MemoryStream outputData = new MemoryStream())
    //            {
    //                string PDFFileword = "1234";//you can also generate Dynamic word  
    //                PdfReader reader = new PdfReader(inputData);
    //                PdfEncryptor.Encrypt(reader, outputData, true, PDFFileword, PDFFileword, PdfWriter.ALLOW_SCREENREADERS);
    //                Filebytes = outputData.ToArray();
    //                Response.ContentType = "application/pdf";
    //                Response.AddHeader("content-disposition", "attachment;filename=" + lblPartyName.Text.ToString() + " " + lbldate.Text.ToString().Trim() + ".pdf");
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                Response.BinaryWrite(Filebytes);
    //                Response.End();
    //            }
    //        }
    //    }
    //}
    //#endregion

    #region simple pdf
    private void ExportPDF()
    {
        BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\arial.ttf", BaseFont.IDENTITY_H, true);
        //iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(lblPartyName.Text);
        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.NORMAL);
        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(13, Convert.ToString(lblPartyName.Text) , font));

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + lblPartyName.Text.ToString() + " " + lbldate.Text.ToString().Trim() + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnlBill.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 50f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    #endregion

    #endregion

    #region ExportPDF Function using gembox

    //private void ExportPdfWithGemBox()
    //{
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter htw = new HtmlTextWriter(sw);
    //    pnlBill.RenderControl(htw);

    //    // Load HTML text to DocumentModel.
    //    string html = sw.ToString();
    //    DocumentModel document = new DocumentModel();
    //    document.Content.LoadText(html, LoadOptions.HtmlDefault);

    //    // Convert ASPX to PDF by exporting, downloading,
    //    // DocumentModel in PDF format from ASP.NET application.
    //    document.Save(this.Response, "About.pdf");
    //}

    #endregion

    #region Fill Grid View
    private void Fill(SqlInt32 BillTeamID)
    {
        #region Open Connection 
        using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        {
            try
            {
                if (Objconn.State != ConnectionState.Open)
                    Objconn.Open();

                using (SqlCommand ObjCmd = Objconn.CreateCommand())
                {
                    ObjCmd.CommandType = CommandType.StoredProcedure;
                    ObjCmd.CommandText = "PR_BillTeam_SelectAll";

                    ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = BillTeamID;

                    using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
                    {
                        if (ObjSdr.HasRows)
                        {
                            gvData.DataSource = ObjSdr;
                            gvData.DataBind();

                            FillAllData(BillTeamID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (Objconn.State == ConnectionState.Open)
                    Objconn.Close();
            }
        }
        #endregion Open Connection
    }
    #endregion

    #region Fill All data
    private void FillAllData(SqlInt32 BillTeamID)
    {
        #region Open Connection
        using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        {
            try
            {
                if (Objconn.State != ConnectionState.Open)
                    Objconn.Open();

                using (SqlCommand ObjCmd = Objconn.CreateCommand())
                {
                    ObjCmd.CommandType = CommandType.StoredProcedure;
                    ObjCmd.CommandText = "PR_BillTeam_SelectAll";

                    ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = BillTeamID;

                    using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
                    {
                        if (ObjSdr.HasRows)
                        {
                            while (ObjSdr.Read())
                            {
                                if (!ObjSdr["OrderDateTime"].Equals(DBNull.Value))
                                    lbldate.Text = ObjSdr["OrderDateTime"].ToString().Trim();

                                if (!ObjSdr["PartyName"].Equals(DBNull.Value))
                                    lblPartyName.Text = ObjSdr["PartyName"].ToString().Trim();

                                if (!ObjSdr["Total"].Equals(DBNull.Value))
                                    lblGrandTotal.Text = ObjSdr["Total"].ToString().Trim();

                                if (!ObjSdr["BillTeamID"].Equals(DBNull.Value))
                                    lblInvoiveBillNo.Text = ObjSdr["BillTeamID"].ToString().Trim();

                                if (!ObjSdr["PartyMobileNumber"].Equals(DBNull.Value))
                                    lblPartyMobileNo.Text = ObjSdr["PartyMobileNumber"].ToString().Trim();

                                if (!ObjSdr["CityName"].Equals(DBNull.Value))
                                    lblPartyCity.Text = ObjSdr["CityName"].ToString().Trim();

                                if (!ObjSdr["StateName"].Equals(DBNull.Value))
                                    lblState.Text = ObjSdr["StateName"].ToString().Trim();

                                if (!ObjSdr["CountryName"].Equals(DBNull.Value))
                                    lblCountry.Text = ObjSdr["CountryName"].ToString().Trim();

                                if (!ObjSdr["Discount"].Equals(DBNull.Value))
                                    lblDiscount.Text = ObjSdr["Discount"].ToString().Trim();

                                if (!ObjSdr["CourierCharge"].Equals(DBNull.Value))
                                    lblCourierCharge.Text = ObjSdr["CourierCharge"].ToString().Trim();

                                if (!ObjSdr["Amount"].Equals(DBNull.Value))
                                    lblSubTotal.Text = ObjSdr["Amount"].ToString().Trim();

                                if (!ObjSdr["Status"].Equals(DBNull.Value))
                                {
                                    lblStatus.Text = ObjSdr["Status"].ToString().Trim();

                                    if (lblStatus.Text == "Pending")
                                        lblStatus.ForeColor = Color.Red;

                                    if (lblStatus.Text == "Paid")
                                        lblStatus.ForeColor = Color.Green;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (Objconn.State == ConnectionState.Open)
                    Objconn.Close();
            }
        }
        #endregion Open Connection
    }
    #endregion

    #region solve error for gridlist
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion

    #region cancle button event
    protected void btncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
    }
    #endregion
}