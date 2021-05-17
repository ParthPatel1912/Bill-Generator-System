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

public partial class PDF_Generator_Admin_Panel_User_UserGridViewList : System.Web.UI.Page
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
        //            ObjCmd.CommandText = "PR_User_SelectAll";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    gvUser.DataSource = ObjSdr;
        //                    gvUser.DataBind();
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

        if (Session["UserID"].ToString().Trim() == "1")
        {
            UserBAL balUser = new UserBAL();
            DataTable dtUser = new DataTable();

            dtUser = balUser.SelectAll();

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                gvUser.DataSource = dtUser;
                gvUser.DataBind();
            }
        }

        else
            lblError.Text = "You are not Admin !!!";
    }
    #endregion Fill Grid View List from Database
}