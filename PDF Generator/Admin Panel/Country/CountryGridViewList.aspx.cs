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

public partial class PDF_Generator_Admin_Panel_Country_CountryGridViewList : System.Web.UI.Page
{
    #region Page Load Method
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
            FillGridViewList();
        }
    }
    #endregion Page Load Method

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
        //            ObjCmd.CommandText = "PR_Country_SelectForGridView";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    gvCountry.DataSource = ObjSdr;
        //                    gvCountry.DataBind();
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

        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if(dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion Fill Grid View List from Database

    #region Add Button Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Country/CountryAddEdit.aspx");
    }
    #endregion Add Button Event

    #region Delete/Edit Button Event
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteID")
        {
            if (e.CommandArgument != null)
            {
                DeleteID(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewList();
            }
        }

        else if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }
    }
    #endregion Delete/Edit Button Event

    #region Delete By ID Function
    public void DeleteID(Int32 CountryID)
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
        //            ObjCmd.CommandText = "PR_Country_DeleteByPK";

        //            ObjCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

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

        CountryBAL balCountry = new CountryBAL();

        if (balCountry.Delete(CountryID))
            FillGridViewList();
        else
            lblError.Text = balCountry.Message;
    }
    #endregion Delete By ID Function
}