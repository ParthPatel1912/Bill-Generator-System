using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_Item_ItemGridViewList : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["CategoryID"] != null)
            {
                SearchCategoryNameByCategoryID();
                lblCategoryName.Text = "Select item from " + Session["CategoryName"].ToString().Trim() + " ....";
            }

            FillRepeterViewList();
        }
    }
    #endregion Page Load Event

    #region Fill Repeter View List from Database
    private void FillRepeterViewList()
    {
        #region Open Connection EXTRA
        //using (SqlConnection ObjConn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (ObjConn.State != System.Data.ConnectionState.Open)
        //            ObjConn.Open();

        //        if (Request.QueryString["CategoryID"] != null)
        //        {
        //            using (SqlCommand ObjCmd = ObjConn.CreateCommand())
        //            {
        //                ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                ObjCmd.CommandText = "PR_Item_SelectByCategoryID";

        //                if (Session["CategoryID"].ToString().Trim() != null)
        //                    ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Session["CategoryID"].ToString().Trim();

        //                using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //                {
        //                    if (ObjSdr.HasRows == true)
        //                    {
        //                        rptItem.DataSource = ObjSdr;
        //                        rptItem.DataBind();
        //                    }
        //                }
        //            }
        //        }

        //        else
        //        {
        //            using (SqlCommand ObjCmd = ObjConn.CreateCommand())
        //            {
        //                ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                ObjCmd.CommandText = "PR_Item_SelectForGridView";


        //                using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //                {
        //                    if (ObjSdr.HasRows == true)
        //                    {
        //                        rptItem.DataSource = ObjSdr;
        //                        rptItem.DataBind();
        //                    }
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

        ItemBAL balItem = new ItemBAL();
        DataTable dtItem = new DataTable();

        if (Request.QueryString["CategoryID"] != null)
        {

            dtItem = balItem.SelectGridViewItemByCategoryID(Convert.ToInt32(Request.QueryString["CategoryID"].ToString().Trim()));

            if (dtItem != null && dtItem.Rows.Count > 0)
            {
                rptItem.DataSource = dtItem;
                rptItem.DataBind();
            }
        }

        else
        {
            dtItem = balItem.SelectAll();

            if (dtItem != null && dtItem.Rows.Count > 0)
            {
                rptItem.DataSource = dtItem;
                rptItem.DataBind();
            }
        }
    }
    #endregion Fill Repeter View List from Database

    #region Search Category Name By CategoryID in session
    private void SearchCategoryNameByCategoryID()
    {
        if (Request.QueryString["CategoryID"] != null)
        {
            #region Local Variable
            string Error = "";
            #endregion Local Variable

            #region Check For Error
            if (Request.QueryString["CategoryID"] == null)
                Error += "not available query string<br/>";
            if (Error != "")
            {
                lblError.Text = Error.ToString().Trim();
                return;
            }
            #endregion Check For Error

            #region Assign Value
            if (Request.QueryString["CategoryID"] != null)
                Session["CategoryID"] = Request.QueryString["CategoryID"].ToString().Trim();

            else
            {
                Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx");
            }
            #endregion Assign Value

            #region Open Connection EXTRA
            //using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
            //{
            //    try
            //    {
            //        if (Objconn.State != System.Data.ConnectionState.Open)
            //            Objconn.Open();

            //        using (SqlCommand ObjCmd = Objconn.CreateCommand())
            //        {
            //            ObjCmd.CommandType = CommandType.StoredProcedure;
            //            ObjCmd.CommandText = "PR_Category_SelectByPK";
            //            ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Session["CategoryID"];

            //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
            //            {
            //                if (objSdr.HasRows)
            //                {
            //                    while (objSdr.Read())
            //                    {
            //                        if (!objSdr["CategoryName"].Equals(DBNull.Value))
            //                            Session["CategoryName"] = objSdr["CategoryName"].ToString().Trim();
            //                    }
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
            //        if (Objconn.State == System.Data.ConnectionState.Open)
            //            Objconn.Close();
            //    }
            //}
            #endregion Open Connection

            #region Open Connection

            CategoryBAL balCategory = new CategoryBAL();
            CategoryENT entCategory = new CategoryENT();

            entCategory = balCategory.SelectByPK(Convert.ToInt32(Session["CategoryID"]));

            if (entCategory != null)
            {
                if (!entCategory.CategoryName.IsNull)
                    Session["CategoryName"] = entCategory.CategoryName.ToString().Trim();
            }

            #endregion
        }
    }
    #endregion Search PartyName By PartyID in session

    #region Delete/Edit Button Event
    protected void rptItem_ItemCommand(object source, RepeaterCommandEventArgs e)
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
    public void DeleteID(Int32 ItemID)
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
        //            ObjCmd.CommandText = "PR_Item_DeleteByPK";

        //            ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;

        //            ObjCmd.ExecuteNonQuery();

        //            FillRepeterViewList();
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

        ItemBAL balItem = new ItemBAL();

        if (balItem.Delete(ItemID))
            FillRepeterViewList();
        else
            lblError.Text = balItem.Message;
    }
    #endregion Delete By ID Function

    #region Add Button Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Item/ItemAddEdit.aspx");
    }
    #endregion Add Button Event
}