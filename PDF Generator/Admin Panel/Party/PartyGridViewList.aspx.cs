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

public partial class PDF_Generator_Admin_Panel_PartyGridViewList : System.Web.UI.Page
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
        //            ObjCmd.CommandText = "PR_Party_SelectForGridView";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    gvParty.DataSource = ObjSdr;
        //                    gvParty.DataBind();
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

        PartyBAL balParty = new PartyBAL();
        DataTable dtParty = new DataTable();

        dtParty = balParty.SelectAllForGridView();

        if(dtParty != null && dtParty.Rows.Count > 0)
        {
            gvParty.DataSource = dtParty;
            gvParty.DataBind();
        }
    }
    #endregion Fill Grid View List from Database

    #region Add Button Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyAddEdit.aspx");
    }
    #endregion Add Button Event

    #region Delete/Edit Button Event
    protected void gvParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteID")
        {
            if (e.CommandArgument != null)
            {
                DeleteID(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
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
    public void DeleteID(Int32 PartyID)
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
        //            ObjCmd.CommandText = "PR_Party_DeleteByPK";

        //            ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;

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

        PartyBAL balParty = new PartyBAL();

        if (balParty.Delete(PartyID))
            FillGridViewList();
        else
            lblError.Text = balParty.Message;
    }
    #endregion Delete By ID Function
    
}