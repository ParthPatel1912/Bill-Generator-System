using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_Category_CategoryAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["CategoryID"] == null)
            {
                lblTitle.Text = "Category Add";
            }
            else
            {
                lblTitle.Text = "Edit Category";
                FillCategoryData(Convert.ToInt32(Request.QueryString["CategoryID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString CategoryName = SqlString.Null;
        SqlString PhotoPath = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtCategoryName.Text.Trim() == "")
        {
            Error += "Enter Category Name<br/>";
            txtCategoryName.Focus();
        }
        if (fuPhoto.HasFile == false)
        {
            Error += "Select File of Photo";
            fuPhoto.Focus();
        }
        if (Error != "")
        {
            lblError.Text = Error.ToString();
            return;
        }
        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        CategoryENT entCategory = new CategoryENT();

        if (txtCategoryName.Text.Trim() != "")
            entCategory.CategoryName = txtCategoryName.Text.Trim();

        if (fuPhoto.HasFile)
        {
            String location = "~/PDF Generator/Content/img/Category/";
            location += fuPhoto.FileName;

            String locationPhysical = Server.MapPath(location);

            if (File.Exists(locationPhysical))
            {
                File.Delete(locationPhysical);
            }

            fuPhoto.SaveAs(locationPhysical);

            entCategory.CategoryPhotoPath = location;
        }
        #endregion Assign Value

        #region Open Connection EXTRA
        //using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (objConn.State != System.Data.ConnectionState.Open)
        //            objConn.Open();

        //        using (SqlCommand ObjCmd = objConn.CreateCommand())
        //        {
        //            ObjCmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            if (Request.QueryString["PartyID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_Category_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_Category_UpdateByPK";
        //                ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = Request.QueryString["CategoryID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 100).Value = CategoryName;
        //            ObjCmd.Parameters.Add("@CategoryPhotoPath", SqlDbType.VarChar, 200).Value = PhotoPath;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["CategoryID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtCategoryName.Text = "";
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (objConn.State == System.Data.ConnectionState.Open)
        //            objConn.Close();
        //    }
        //}
        #endregion Open Connection

        #region Save or Edit

        CategoryBAL balCategory = new CategoryBAL();

        if (Request.QueryString["CategoryID"] == null)
        {
            if (balCategory.Insert(entCategory))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                lblError.Text = "Data Addes Successfully.....";
                txtCategoryName.Text = "";
                txtCategoryName.Focus();
            }
            else
                lblError.Text = balCategory.Message;
        }

        else
        {
            entCategory.CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"].ToString().Trim());

            if (balCategory.Update(entCategory))
                Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx");
        }

        #endregion
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillCategoryData(SqlInt32 CategoryID)
    {
        #region Open Connection EXTRA
        //using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (Objconn.State != ConnectionState.Open)
        //            Objconn.Open();

        //        using (SqlCommand ObjCmd = Objconn.CreateCommand())
        //        {
        //            ObjCmd.CommandType = CommandType.StoredProcedure;
        //            ObjCmd.CommandText = "PR_Category_SelectByPK";

        //            ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["CategoryName"].Equals(DBNull.Value))
        //                            txtCategoryName.Text = ObjSdr["CategoryName"].ToString().Trim();
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
        //        if (Objconn.State == ConnectionState.Open)
        //            Objconn.Close();
        //    }
        //}
        #endregion Open Connection

        CategoryBAL balCategory = new CategoryBAL();
        CategoryENT entCategory = new CategoryENT();

        entCategory = balCategory.SelectByPK(CategoryID);

        if (!entCategory.CategoryName.IsNull)
            txtCategoryName.Text = entCategory.CategoryName.ToString().Trim();
    }
    #endregion Fill Data from Database
}