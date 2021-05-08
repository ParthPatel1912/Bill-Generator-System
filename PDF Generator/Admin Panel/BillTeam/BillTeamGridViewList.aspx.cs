using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClosedXML.Excel;
using System.IO;
using System.Drawing;

public partial class PDF_Generator_Admin_Panel_BillTeam_BillTeamGridViewList : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
            FillGridViewList();
        }
    }
    #endregion Page Load Event

    #region Fill Grid View List from Database
    private void FillGridViewList()
    {
        #region Open Connection EXTRA
        //using (SqlConnection ObjConn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (ObjConn.State != System.Data.ConnectionState.Open)
        //            ObjConn.Open();

        //        using (SqlCommand ObjCmd = ObjConn.CreateCommand())
        //        {
        //            ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            ObjCmd.CommandText = "PR_BillTeam_SelectForGridView";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    gvBillTeam.DataSource = ObjSdr;
        //                    gvBillTeam.DataBind();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (ObjConn.State == System.Data.ConnectionState.Open)
        //            ObjConn.Close();
        //    }
        //}
        #endregion Open Connection

        BillTeamBAL balBillTeam = new BillTeamBAL();
        DataTable dtBillTeam = new DataTable();

        if (Session["UserID"].ToString().Trim() == "1")
            dtBillTeam = balBillTeam.SelectAllForGridView();

        else
            dtBillTeam = balBillTeam.SelectAllForGridViewByUserID(Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (dtBillTeam != null && dtBillTeam.Rows.Count > 0)
        {
            gvBillTeam.DataSource = dtBillTeam;
            gvBillTeam.DataBind();

            foreach (GridViewRow row in gvBillTeam.Rows)
            {
                if (String.Equals(row.Cells[7].Text.ToString(), "Paid"))
                {
                    row.Cells[7].BackColor = Color.FromName("#228b22");
                }
                else
                {
                    row.Cells[7].BackColor = Color.FromName("#D2042D");
                    row.Cells[7].ForeColor = Color.White;
                }
            }
        }
    }
    #endregion Fill Grid View List from Database

    #region Grid View DataTable
    protected void gvBillTeam_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.TableSection = TableRowSection.TableHeader;
    }
    #endregion Grid View DataTable

    #region Delete/Edit Button Event
    protected void gvBillTeam_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }

        if (e.CommandName == "Download")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }

        if (e.CommandName == "DeleteID")
        {
            if (e.CommandArgument != null)
            {
                DeleteID(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion Delete/Edit Button Event

    #region btn for Excel File Event
    protected void btnExcelFile_Click(object sender, EventArgs e)
    {
        ExportExcel();

    }
    #endregion

    #region ExportExcel Funnction
    private void ExportExcel()
    {
        BillTeamBAL balBillTeam = new BillTeamBAL();
        DataTable dt = null;
        try
        {
            dt = balBillTeam.SelectAllForGridView();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "BillBook");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Download.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception Ex)
        {
            lblError.Text = Ex.Message;
        }
        finally
        {
            dt = null;
        }
    }
    #endregion

    #region Delete By ID Function
    public void DeleteID(Int32 BillHeaderID)
    {
        #region Open Connection EXTRA
        //using (SqlConnection ObjSdr = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (ObjSdr.State != System.Data.ConnectionState.Open)
        //            ObjSdr.Open();

        //        using (SqlCommand ObjCmd = ObjSdr.CreateCommand())
        //        {
        //            ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            ObjCmd.CommandText = "PR_BillTeam_DeleteByPK";

        //            ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = BillHeaderID;

        //            ObjCmd.ExecuteNonQuery();

        //            FillGridViewList();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }

        //    finally
        //    {
        //        if (ObjSdr.State == System.Data.ConnectionState.Open)
        //            ObjSdr.Close();
        //    }
        //}
        #endregion Open Connection

        BillTeamBAL balBillTeam = new BillTeamBAL();
        BillHeaderBAL balBillHeader = new BillHeaderBAL();

        if (balBillTeam.Delete(BillHeaderID))
        {
            balBillHeader.Delete(BillHeaderID);
            FillGridViewList();
        }
        else
            lblError.Text = balBillTeam.Message;
    }
    #endregion Delete By ID Function
}