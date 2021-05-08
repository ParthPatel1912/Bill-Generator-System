using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_BillHeader_BillHeaderGridViewList : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
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
        //            ObjCmd.CommandText = "PR_BillHeader_SelectForGridView";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    gvBillHeader.DataSource = ObjSdr;
        //                    gvBillHeader.DataBind();
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

        BillHeaderBAL balBillHeader = new BillHeaderBAL();
        DataTable dtBillHeader = new DataTable();

        dtBillHeader = balBillHeader.SelectAllForGridView();

        if (dtBillHeader != null && dtBillHeader.Rows.Count > 0)
        {
            gvBillHeader.DataSource = dtBillHeader;
            gvBillHeader.DataBind();

            foreach (GridViewRow row in gvBillHeader.Rows)
            {
                if (String.Equals(row.Cells[6].Text.ToString(), "Paid"))
                {
                    row.Cells[6].BackColor = Color.FromName("#228b22");
                    
                }
                else
                {
                    row.Cells[6].BackColor = Color.FromName("#D2042D");
                    row.Cells[6].ForeColor = Color.White;
                }
            }

            //foreach (GridViewRow row in gvPayment.Rows)
            //{
            //    if (String.Equals(row.Cells[2].Text.ToString(), "Debit"))
            //    {
            //        row.ForeColor = Color.FromName("#D2042D");
            //    }
            //    else
            //    {
            //        row.ForeColor = Color.FromName("#228b22 ");
            //    }
            //}
        }
    }
    #endregion Fill Grid View List from Database
}