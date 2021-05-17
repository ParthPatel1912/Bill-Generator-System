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

public partial class PDF_Generator_Admin_Panel_Category_CategoryGridViewList : System.Web.UI.Page
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
                lblPartyName.Text = "Select Category for " + Session["PartyName"].ToString().Trim() + " ....";
            }

            FillRepeterViewList();
        }
    }
    #endregion Page Load Event

    #region Search PartyName By PartyID in session
    private void SearchPartyNameByPartyID()
    {
        if (Request.QueryString["PartyID"] != null)
        {
            #region Local Variable
            string Error = "";
            #endregion Local Variable

            #region Check For Error
            if (Request.QueryString["PartyID"] == null)
                Error += "not available query string<br/>";
            if (Error != "")
            {
                lblError.Text = Error.ToString().Trim();
                return;
            }
            #endregion Check For Error

            #region Assign Value
            if (Request.QueryString["PartyID"] != null)
                Session["PartyID"] = Request.QueryString["PartyID"].ToString().Trim();

            else
                Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyGridViewList.aspx");


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
            //            ObjCmd.CommandText = "PR_Party_SelectByPK";
            //            ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = Session["PartyID"];

            //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
            //            {
            //                if (objSdr.HasRows)
            //                {
            //                    while (objSdr.Read())
            //                    {
            //                        if (!objSdr["PartyName"].Equals(DBNull.Value))
            //                            Session["PartyName"] = objSdr["PartyName"].ToString().Trim();
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

            #region Open connection

            PartyBAL balParty = new PartyBAL();
            PartyENT entParty = new PartyENT();

            entParty = balParty.SelectByPK(Convert.ToInt32(Session["PartyID"]));

            if(entParty!=null)
            {
                if (!entParty.PartyName.IsNull)
                    Session["PartyName"] = entParty.PartyName.ToString().Trim();
            }

            #endregion
        }
    }
    #endregion Search PartyName By PartyID in session

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

        //        using (SqlCommand ObjCmd = ObjConn.CreateCommand())
        //        {
        //            ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            ObjCmd.CommandText = "PR_Category_SelectAll";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    rptCategory.DataSource = ObjSdr;
        //                    rptCategory.DataBind();
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

        CategoryBAL balCategory = new CategoryBAL();
        DataTable dtCategory = new DataTable();

        dtCategory = balCategory.SelectAll();

        if(dtCategory != null && dtCategory.Rows.Count > 0)
        {
            rptCategory.DataSource = dtCategory;
            rptCategory.DataBind();
        }
    }
    #endregion Fill Repeter View List from Database

    #region Delete/Edit Button Event
    protected void rptCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
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
    public void DeleteID(Int32 CategoryID)
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
        //            ObjCmd.CommandText = "PR_Category_DeleteByPK";

        //            ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;

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

        CategoryBAL balCategory = new CategoryBAL();

        if (balCategory.Delete(CategoryID))
            FillRepeterViewList();
        else
            lblError.Text = balCategory.Message;
    }
    #endregion Delete By ID Function

    #region Add Button Event
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryAddEdit.aspx");
    }
    #endregion Add Button Event
}