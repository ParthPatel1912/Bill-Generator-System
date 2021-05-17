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

public partial class PDF_Generator_Admin_Panel_BillTeam_BillTeamAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["BillTeamID"] == null)
            {
                lblTitle.Text = "Bill Team Add";
            }
            else
            {
                lblTitle.Text = "Edit Bill Team";
                FillBillTeamData(Convert.ToInt32(Request.QueryString["BillTeamID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Save Button Load Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt32 BillHeaderID = SqlInt32.Null;
        SqlInt32 ItemID = SqlInt32.Null;
        SqlInt32 CategoryID = SqlInt32.Null;
        SqlInt32 Quantity = SqlInt32.Null;
        SqlInt32 UserID = SqlInt32.Null;
        SqlInt32 CourierCharge = SqlInt32.Null;
        SqlDecimal Discount = SqlDecimal.Null;
        SqlDecimal Price = SqlDecimal.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)

        if (txtQuantity.Text.Trim() == "")
        {
            Error += "Enter Quantity<br/>";
            txtQuantity.Focus();
        }
        if (txtPrice.Text.Trim() == "")
        {
            Error += "Enter Per Piece Price<br/>";
            txtPrice.Focus();
        }
        if (txtDiscount.Text.Trim() == "")
        {
            Error += "Enter Discount<br/>";
            txtDiscount.Focus();
        }
        if (txtCourierCharge.Text.Trim() == "")
        {
            Error += "Enter Courier Charge<br/>";
            txtCourierCharge.Focus();
        }
        if (Error.ToString().Trim() != "")
        {
            lblError.Text = Error.ToString();
            return;
        }

        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        BillTeamENT entBillTeam = new BillTeamENT();

        if (txtQuantity.Text.Trim() != "")
            entBillTeam.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());

        if (txtCourierCharge.Text.Trim() != "")
            entBillTeam.CourierCharge = Convert.ToInt32(txtCourierCharge.Text.Trim());

        if (txtPrice.Text.Trim() != "")
            entBillTeam.Price = Convert.ToDecimal(txtPrice.Text.Trim());

        if (txtDiscount.Text.Trim() != "")
            entBillTeam.Discount = Convert.ToDecimal(txtDiscount.Text.Trim());

        if (txtUserID.Text.Trim() != "")
            entBillTeam.UserID = Convert.ToInt32(txtUserID.Text.Trim());

        else
        {
            if (Session["UserID"] != null)
            {
                txtUserID.Text = Session["UserID"].ToString().Trim();
                entBillTeam.UserID = Convert.ToInt32(txtUserID.Text.Trim());
            }
            else
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
        }

        if (txtBillHeaderID.Text.Trim() != "")
            entBillTeam.BillHeaderID = Convert.ToInt32(txtBillHeaderID.Text.Trim());

        else
        {
            if (Session["BillHeaderID"] != null)
            {
                txtBillHeaderID.Text = Session["BillHeaderID"].ToString().Trim();
                entBillTeam.BillHeaderID = Convert.ToInt32(txtBillHeaderID.Text.Trim());
            }
            else
                Response.Redirect("~/PDF Generator/Admin Panel/BillHeader/BillHeaderAddEdit.aspx");
        }

        if (txtItemID.Text.Trim() != "")
            entBillTeam.ItemID = Convert.ToInt32(txtItemID.Text.Trim());

        else
        {
            if (Session["ItemID"] != null)
            {
                txtItemID.Text = Session["ItemID"].ToString().Trim();
                entBillTeam.ItemID = Convert.ToInt32(txtItemID.Text.Trim());
            }
            else
                Response.Redirect("~/PDF Generator/Admin Panel/Item/ItemGridViewList.aspx");
        }

        if (txtCategoryID.Text.Trim() != "")
            entBillTeam.CategoryID = Convert.ToInt32(txtCategoryID.Text.Trim());

        else
        {
            if (Session["CategoryID"] != null)
            {
                txtCategoryID.Text = Session["CategoryID"].ToString().Trim();
                entBillTeam.CategoryID = Convert.ToInt32(txtCategoryID.Text.Trim());
            }
            else
                Response.Redirect("~/PDF Generator/Admin Panel/Category/CategoryGridViewList.aspx");
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

        //            if (Request.QueryString["BillTeamID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_BillTeam_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_BillTeam_UpdateByPK";
        //                ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = Session["BillTeamID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;
        //            ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
        //            ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = BillHeaderID;
        //            ObjCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        //            ObjCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
        //            ObjCmd.Parameters.Add("@CourierCharge", SqlDbType.Int).Value = CourierCharge;
        //            ObjCmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = Discount;
        //            ObjCmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;

        //            ObjCmd.Parameters["@Discount"].Precision = 18;
        //            ObjCmd.Parameters["@Discount"].Scale = 2;
        //            ObjCmd.Parameters["@Price"].Precision = 18;
        //            ObjCmd.Parameters["@Price"].Scale = 2;

        //            Session["Total"] = Quantity.Value * Price.Value - Discount.Value + CourierCharge.Value;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["BillTeamID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtBillHeaderID.Text = "";
        //                txtCategoryID.Text = "";
        //                txtCourierCharge.Text = "";
        //                txtDiscount.Text = "";
        //                txtItemID.Text = "";
        //                txtPrice.Text = "";
        //                txtQuantity.Text = "";
        //                txtUserID.Text = "";
        //            }
        //        }

        //        #region Fill Total By BillheaderID Using UpdateByPK
        //        using (SqlCommand ObjCmd2 = objConn.CreateCommand())
        //        {
        //            ObjCmd2.CommandType = System.Data.CommandType.StoredProcedure;

        //            ObjCmd2.CommandText = "PR_BillHeader_UpdateByPKOnlyTotal";
        //            ObjCmd2.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = Session["BillHeaderID"];

        //            ObjCmd2.Parameters.Add("@Total", SqlDbType.Decimal).Value = Session["Total"];

        //            ObjCmd2.Parameters["@Total"].Precision = 18;
        //            ObjCmd2.Parameters["@Total"].Scale = 2;

        //            ObjCmd2.ExecuteNonQuery();

        //            //Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
        //        }
        //        #endregion Fill Total By BillheaderID Using UpdateByPK
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

        BillTeamBAL balBillTeam = new BillTeamBAL();

        BillHeaderBAL balBillHeader = new BillHeaderBAL();
        BillHeaderENT entBillHeader = new BillHeaderENT();

        if (Request.QueryString["BillTeamID"] == null)
        {
            if (balBillTeam.Insert(entBillTeam))
            {
                Session["Total"] = entBillTeam.Quantity.Value * entBillTeam.Price.Value - entBillTeam.Discount.Value + entBillTeam.CourierCharge.Value;
                Session["Amount"] = entBillTeam.Quantity.Value * entBillTeam.Price.Value;
                lblError.Text = "Data Addes Successfully.....";
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);

                entBillHeader.BillHeaderID = Convert.ToInt32(Session["BillHeaderID"].ToString().Trim());
                entBillHeader.Total = Convert.ToDecimal(Session["Total"].ToString().Trim());
                entBillHeader.Amount = Convert.ToDecimal(Session["Amount"].ToString().Trim());

                balBillHeader.UpdateTotal(entBillHeader);

                ClearControl();
                SessionClear();

                Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
            }

            else
                lblError.Text = balBillTeam.Message;
        }

        else
        {
            entBillTeam.BillTeamID = Convert.ToInt32(Request.QueryString["BillTeamID"].ToString().Trim());

            if (balBillTeam.Update(entBillTeam))
            {
                Session["Total"] = entBillTeam.Quantity.Value * entBillTeam.Price.Value - entBillTeam.Discount.Value + entBillTeam.CourierCharge.Value;
                Session["Amount"] = entBillTeam.Quantity.Value * entBillTeam.Price.Value;

                entBillHeader.BillHeaderID = Convert.ToInt32(Session["BillHeaderID"].ToString().Trim());
                entBillHeader.Total = Convert.ToDecimal(Session["Total"].ToString().Trim());
                entBillHeader.Amount = Convert.ToDecimal(Session["Amount"].ToString().Trim());

                balBillHeader.UpdateTotal(entBillHeader);

                ClearControl();
                SessionClear();

                Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
            }

            else
                lblError.Text = balBillTeam.Message;
        }

        #endregion
    }
    #endregion Save Button Load Event

    #region Cancle Button Load Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
    }
    #endregion Cancle Button Load Event

    #region Fill data From Database
    private void FillBillTeamData(SqlInt32 BillTeamID)
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
        //            ObjCmd.CommandText = "PR_BillTeam_SelectByPK";

        //            ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = BillTeamID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["BillHeaderID"].Equals(DBNull.Value))
        //                            txtBillHeaderID.Text = ObjSdr["BillHeaderID"].ToString().Trim();

        //                        if (!ObjSdr["CategoryID"].Equals(DBNull.Value))
        //                            txtCategoryID.Text = ObjSdr["CategoryID"].ToString().Trim();

        //                        if (!ObjSdr["ItemID"].Equals(DBNull.Value))
        //                            txtItemID.Text = ObjSdr["ItemID"].ToString().Trim();

        //                        if (!ObjSdr["UserID"].Equals(DBNull.Value))
        //                            txtUserID.Text = ObjSdr["UserID"].ToString().Trim();

        //                        if (!ObjSdr["Quantity"].Equals(DBNull.Value))
        //                            txtQuantity.Text = ObjSdr["Quantity"].ToString().Trim();

        //                        if (!ObjSdr["Price"].Equals(DBNull.Value))
        //                            txtPrice.Text = ObjSdr["Price"].ToString().Trim();

        //                        if (!ObjSdr["Discount"].Equals(DBNull.Value))
        //                            txtDiscount.Text = ObjSdr["Discount"].ToString().Trim();

        //                        if (!ObjSdr["CourierCharge"].Equals(DBNull.Value))
        //                            txtCourierCharge.Text = ObjSdr["CourierCharge"].ToString().Trim();
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

        BillTeamBAL balBillTeam = new BillTeamBAL();
        BillTeamENT entBillTeam = new BillTeamENT();

        entBillTeam = balBillTeam.SelectByPK(BillTeamID);

        if (!entBillTeam.BillHeaderID.IsNull)
            txtBillHeaderID.Text = entBillTeam.BillHeaderID.ToString().Trim();
        if (!entBillTeam.CategoryID.IsNull)
            txtCategoryID.Text = entBillTeam.CategoryID.ToString().Trim();
        if (!entBillTeam.ItemID.IsNull)
            txtItemID.Text = entBillTeam.ItemID.ToString().Trim();
        if (!entBillTeam.UserID.IsNull)
            txtUserID.Text = entBillTeam.UserID.ToString().Trim();

        if (!entBillTeam.CourierCharge.IsNull)
            txtCourierCharge.Text = entBillTeam.CourierCharge.ToString().Trim();
        if (!entBillTeam.Discount.IsNull)
            txtDiscount.Text = entBillTeam.Discount.ToString().Trim();
        if (!entBillTeam.Price.IsNull)
            txtPrice.Text = entBillTeam.Price.ToString().Trim();
        if (!entBillTeam.Quantity.IsNull)
            txtQuantity.Text = entBillTeam.Quantity.ToString().Trim();
    }
    #endregion Fill Data from Database
    
    #region Clear Control

    private void ClearControl()
    {
        txtBillHeaderID.Text = "";
        txtCategoryID.Text = "";
        txtCourierCharge.Text = "";
        txtDiscount.Text = "";
        txtItemID.Text = "";
        txtPrice.Text = "";
        txtQuantity.Text = "";
        txtUserID.Text = "";
        txtQuantity.Focus();
    }

    #endregion

    #region Session Clear

    private void SessionClear()
    {
        Session["CategoryID"] = null;
        Session["ItemID"] = null;
        Session["BillHeaderID"] = null;
        Session["PartyID"] = null;
        Session["BillTeamID"] = null;
    }

    #endregion
}
