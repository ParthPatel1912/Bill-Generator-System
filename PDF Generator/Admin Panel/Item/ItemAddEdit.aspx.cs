using PartyBook;
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

public partial class PDF_Generator_Admin_Panel_Item_ItemAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["ItemID"] == null)
            {
                lblTitle.Text = "Item Add";
                FillDropDownListCategory();
            }
            else
            {
                lblTitle.Text = "Edit Item";
                FillDropDownListCategory();
                FillItemData(Convert.ToInt32(Request.QueryString["ItemID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Fill Drop Down List of Item
    private void FillDropDownListCategory()
    {
        #region Open Connection EXTRA
        //using (SqlConnection ObjConn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //{
        //    try
        //    {
        //        if (ObjConn.State != System.Data.ConnectionState.Open)
        //            ObjConn.Open();

        //        using (SqlCommand Objcmd = ObjConn.CreateCommand())
        //        {
        //            Objcmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            Objcmd.CommandText = "PR_Category_SelectAll";

        //            using (SqlDataReader Objsdr = Objcmd.ExecuteReader())
        //            {
        //                if (Objsdr.HasRows == true)
        //                {
        //                    ddlCategory.DataValueField = "CategoryID";
        //                    ddlCategory.DataTextField = "CategoryName";

        //                    ddlCategory.DataSource = Objsdr;
        //                    ddlCategory.DataBind();

        //                    ddlCategory.Items.Insert(0, new ListItem("--- Select Category Name ---", "-1"));
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

        CommanFillMethod.FillCategoryDropDownListCategory(ddlCategory);
    }
    #endregion Fill Drop Down List of City

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString ItemName = SqlString.Null;
        SqlInt32 CategoryID = SqlInt32.Null;
        SqlString PhotoPath = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtItemName.Text.Trim() == "")
        {
            Error += "Enter Party Name<br/>";
            txtItemName.Focus();
        }
        if (ddlCategory.SelectedIndex == 0)
        {
            Error += "Select Category<br/>";
            ddlCategory.Focus();
        }
        if (fuPhoto.HasFile == false)
        {
            Error += "Select File of Photo";
            fuPhoto.Focus();
        }
        if(Error != "")
        {
            lblError.Text = Error.ToString();
            return;
        }
        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        ItemENT entItem = new ItemENT();

        if (txtItemName.Text.Trim() != "")
            entItem.ItemName = txtItemName.Text.Trim();

        if (ddlCategory.SelectedIndex > 0)
            entItem.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

        if (fuPhoto.HasFile)
        {
            String location = "~/PDF Generator/Content/img/Item/";
            location += fuPhoto.FileName;

            String locationPhysical = Server.MapPath(location);

            if (File.Exists(locationPhysical))
            {
                File.Delete(locationPhysical);
            }

            fuPhoto.SaveAs(locationPhysical);

            entItem.ItemPhotoPath = location;
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

        //            if (Request.QueryString["ItemID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_Item_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_Item_UpdateByPK";
        //                ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = Request.QueryString["ItemID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@ItemName", SqlDbType.NVarChar, 100).Value = ItemName;
        //            ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        //            ObjCmd.Parameters.Add("@ItemPhotopath", SqlDbType.VarChar, 200).Value = PhotoPath;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["ItemID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtItemName.Text = "";
        //                ddlCategory.SelectedIndex = 0;
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx");
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

        ItemBAL balItem = new ItemBAL();

        if (Request.QueryString["ItemID"] == null)
        {
            if (balItem.Insert(entItem))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                lblError.Text = "Data Addes Successfully.....";
                txtItemName.Text = "";
                txtItemName.Focus();
            }
            else
                lblError.Text = balItem.Message;
        }

        else
        {
            entItem.ItemID = Convert.ToInt32(Request.QueryString["ItemID"].ToString().Trim());

            if (balItem.Update(entItem))
                Response.Redirect("~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx");
            else
                lblError.Text = balItem.Message;
        }

            #endregion
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillItemData(SqlInt32 ItemID)
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
        //            ObjCmd.CommandText = "PR_Item_SelectByPK";

        //            ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["ItemName"].Equals(DBNull.Value))
        //                            txtItemName.Text = ObjSdr["ItemName"].ToString().Trim();

        //                        if (!ObjSdr["CategoryID"].Equals(DBNull.Value))
        //                            ddlCategory.SelectedValue = ObjSdr["CategoryID"].ToString().Trim();
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

        ItemBAL balItem = new ItemBAL();
        ItemENT entItem = new ItemENT();

        entItem = balItem.SelectByPK(ItemID);

        if (!entItem.ItemName.IsNull)
            txtItemName.Text = entItem.ItemName.ToString().Trim();
    }
    #endregion Fill Data from Database
}