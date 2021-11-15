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

            if (Request.QueryString["PartyID"] != null)
            {
                SearchPartyNameByPartyID();
                FillGridViewListByPartyID();
                lblParty.Text = "All details of all Entered Bill of - " + Session["PartyNameBill"].ToString();
            }
            else
            {
                FillGridViewList();
                lblParty.Text = "All details of all Enterd Bill";
            }
        }
    }
    #endregion Page Load Event

    #region Search PartyName By PartyID
    private void SearchPartyNameByPartyID()
    {
        #region Open connection

        PartyBAL balParty = new PartyBAL();
        PartyENT entParty = new PartyENT();

        entParty = balParty.SelectByPK(Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim()));

        if (entParty != null)
        {
            if (!entParty.PartyName.IsNull)
                Session["PartyNameBill"] = entParty.PartyName.ToString().Trim();
        }

        #endregion
    }
    #endregion Search PartyName By PartyID in session

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

    #region Fill Grid View List from Database By PartyID
    private void FillGridViewListByPartyID()
    {
        BillTeamBAL balBillTeam = new BillTeamBAL();
        DataTable dtBillTeam = new DataTable();

        if (Session["UserID"].ToString().Trim() == "1")
            dtBillTeam = balBillTeam.SelectAllForGridViewByPartyID(Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim()));

        else
            dtBillTeam = balBillTeam.SelectAllForGridViewByUserIDPartyId(Convert.ToInt32(Session["UserID"].ToString().Trim()), Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim()));

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
        if (Session["UserID"].ToString().Trim() == "1")
            ExportExcel();

        else
            lblError.Text = "You are not Admin !!!";

    }
    #endregion

    #region ExportExcel Funnction
    private void ExportExcel()
    {
        BillTeamBAL balBillTeam = new BillTeamBAL();
        DataTable dt = null;

        try
        {
            if (Request.QueryString["PartyID"] != null)
                dt = balBillTeam.SelectAllForGridViewByPartyID(Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim()));
            else
                dt = balBillTeam.SelectAllForGridView();

            if (dt.Rows.Count == 0)
            {
                lblError.Text = "Data is Empty!! So you can not Download Excel file.";

                if (Request.QueryString["PartyID"] != null)
                    lblParty.Text = "All details of all Entered Bill of - " + Session["PartyNameBill"].ToString();
                else
                    lblParty.Text = "All details of all Enterd Bill";
            }

            else
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "BillBook");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    if (Request.QueryString["PartyID"] != null)
                        Response.AddHeader("content-disposition", "attachment;filename=Bill-List " + Session["PartyNameBill"].ToString() + ".xlsx");

                    else
                        Response.AddHeader("content-disposition", "attachment;filename=Bill-List.xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
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