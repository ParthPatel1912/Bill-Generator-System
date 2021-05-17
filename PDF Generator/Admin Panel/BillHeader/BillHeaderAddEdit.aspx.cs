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

public partial class PDF_Generator_Admin_Panel_BillHeader_BillHeaderAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["ItemID"] != null)
            {
                SearchItemNameByItemID();
                lblItemName.Text = "Select &nbsp;item &nbsp;is &nbsp;" + Session["ItemName"].ToString().Trim() + " ....";
            }

            if (Request.QueryString["BillHeaderID"] == null)
            {
                lblTitle.Text = "Bill Header Add";
            }
            else
            {
                lblTitle.Text = "Edit Bill Header";
                FillBillHeaderData(Convert.ToInt32(Request.QueryString["BillHeaderID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Save Button Load Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt32 PartyID = SqlInt32.Null;
        SqlDateTime OrderDate = SqlDateTime.Null;
        SqlDecimal Total = SqlDecimal.Null;
        SqlString Status = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)

        if (txtOrderDate.Text.Trim() == "")
        {
            Error += "Enter Order Date<br/>";
            txtOrderDate.Focus();
        }
        if (Error.ToString().Trim() != "")
        {
            lblError.Text = Error.ToString();
            return;
        }

        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        BillHeaderENT entBillHeader = new BillHeaderENT();

        if (txtPartyID.Text.Trim() != "")
            entBillHeader.PartyID = Convert.ToInt32(txtPartyID.Text.Trim());

        else
        {
            if (Session["PartyID"] != null)
            {
                txtPartyID.Text = Session["PartyID"].ToString().Trim();
                entBillHeader.PartyID = Convert.ToInt32(txtPartyID.Text.Trim());
            }
            else
                Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyGridViewList.aspx");
        }

        if (txtOrderDate.Text.Trim() != "")
            entBillHeader.OrderDateTime = Convert.ToDateTime(txtOrderDate.Text.ToString());

        if (txtTotal.Text.Trim() == "")
            entBillHeader.Total = Convert.ToDecimal("0.00");

        else
            entBillHeader.Total = Convert.ToDecimal(txtTotal.Text.ToString());

        if (rbPaid.Checked)
            entBillHeader.Status = rbPaid.Text.Trim();

        if (rbPending.Checked)
            entBillHeader.Status = rbPending.Text.Trim();

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

        //            if (Request.QueryString["BillHeaderID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_BillHeader_Insert";

        //                ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Direction = ParameterDirection.Output;
        //                ObjCmd.Parameters.Add("@OrderDateTime", SqlDbType.DateTime).Value = OrderDate;
        //                ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;
        //                ObjCmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;

        //                ObjCmd.Parameters["@Total"].Precision = 18;
        //                ObjCmd.Parameters["@Total"].Scale = 2;
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_BillHeader_UpdateByPK";
        //                ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = Request.QueryString["BillHeaderID"].ToString().Trim();

        //                ObjCmd.Parameters.Add("@OrderDateTime", SqlDbType.DateTime).Value = OrderDate;
        //                ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;
        //                ObjCmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;

        //                ObjCmd.Parameters["@Total"].Precision = 18;
        //                ObjCmd.Parameters["@Total"].Scale = 2;

        //            }

        //            ObjCmd.ExecuteNonQuery();
        //            Session["BillHeaderID"] = Convert.ToInt32(ObjCmd.Parameters["@BillHeaderID"].Value);


        //            if (Request.QueryString["BillHeaderID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtOrderDate.Text = "";
        //                txtPartyID.Text = "";
        //                txtTotal.Text = "";
        //                Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx");
        //            }

        //            else
        //            {
        //                if (Session["BillTeamID"] != null)
        //                    Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx?BillTeamID=" + Session["BillTeamID"].ToString().Trim());
        //                else
        //                    SearchBillTeamIDByBillHeaderID();
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

        #region Save of Edit

        BillHeaderBAL balBillHeader = new BillHeaderBAL();

        if (Request.QueryString["BillHeaderID"] == null)
        {
            if (balBillHeader.Insert(entBillHeader))
            {
                if (!entBillHeader.BillHeaderID.IsNull)
                    Session["BillHeaderID"] = entBillHeader.BillHeaderID.ToString().Trim();

                Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx");
            }
            else
                lblError.Text = balBillHeader.Message;
        }

        else
        {
            entBillHeader.BillHeaderID = Convert.ToInt32(Request.QueryString["BillHeaderID"].ToString().Trim());

            if (balBillHeader.Update(entBillHeader))
            {
                if (Session["BillTeamID"] != null)
                    Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx?BillTeamID=" + Session["BillTeamID"].ToString().Trim());
                else
                    SearchBillTeamIDByBillHeaderID();
            }
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

    #region Search Item Name By ItemID in session
    private void SearchItemNameByItemID()
    {
        if (Request.QueryString["ItemID"] != null)
        {
            #region Local Variable
            SqlString Error = SqlString.Null;
            #endregion Local Variable

            #region Check For Error
            if (Request.QueryString["ItemID"] == null)
                Error += "not available query string<br/>";
            if (Error != "")
            {
                lblError.Text = Error.ToString().Trim();
                return;
            }
            #endregion Check For Error

            #region Assign Value
            if (Request.QueryString["ItemID"] != null)
                Session["ItemID"] = Request.QueryString["ItemID"].ToString().Trim();
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
            //            ObjCmd.CommandText = "PR_Item_SelectByPK";
            //            ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = Session["ItemID"];

            //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
            //            {
            //                if (objSdr.HasRows)
            //                {
            //                    while (objSdr.Read())
            //                    {
            //                        if (!objSdr["ItemName"].Equals(DBNull.Value))
            //                            Session["ItemName"] = objSdr["ItemName"].ToString().Trim();
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

            ItemBAL balItem = new ItemBAL();
            ItemENT entItem = new ItemENT();

            entItem = balItem.SelectByPK(Convert.ToInt32(Session["ItemID"].ToString().Trim()));

            if (entItem != null)
            {
                if (!entItem.ItemName.IsNull)
                    Session["ItemName"] = entItem.ItemName.ToString().Trim();
            }

            #endregion
        }
    }
    #endregion Search PartyName By PartyID in session

    #region Fill data From Database
    private void FillBillHeaderData(SqlInt32 BillHeaderID)
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
        //            ObjCmd.CommandText = "PR_BillHeader_SelectByPK";

        //            ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = BillHeaderID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        //if (!ObjSdr["OrderDateTime"].Equals(DBNull.Value))
        //                        //    txtOrderDate.Text = ObjSdr["OrderDateTime"].ToString().Trim();

        //                        if (!ObjSdr["PartyID"].Equals(DBNull.Value))
        //                            txtPartyID.Text = ObjSdr["PartyID"].ToString().Trim();

        //                        if (!ObjSdr["Total"].Equals(DBNull.Value))
        //                            txtTotal.Text = ObjSdr["Total"].ToString().Trim();
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

        BillHeaderBAL balBillHeader = new BillHeaderBAL();
        BillHeaderENT entBillHeader = new BillHeaderENT();

        entBillHeader = balBillHeader.SelectByPK(BillHeaderID);

        if (!entBillHeader.PartyID.IsNull)
            txtPartyID.Text = entBillHeader.PartyID.ToString().Trim();

        if (!entBillHeader.Total.IsNull)
            txtTotal.Text = entBillHeader.Total.ToString().Trim();

        if (!entBillHeader.Status.IsNull)
        {
            if (entBillHeader.Status.ToString() == "Paid")
                rbPaid.Checked = true;
            if (entBillHeader.Status.ToString() == "Pending")
                rbPending.Checked = true;
        }
    }
    #endregion Fill Data from Database

    #region Search BillTeamID By BillHeaderID
    private void SearchBillTeamIDByBillHeaderID()
    {
        if (Request.QueryString["BillHeaderID"] != null)
        {
            #region Local Variable
            SqlString Error = SqlString.Null;
            #endregion Local Variable

            #region Check For Error
            if (Request.QueryString["BillHeaderID"] == null)
                Error += "not available query string<br/>";
            if (Error != "")
            {
                lblError.Text = Error.ToString().Trim();
                return;
            }
            #endregion Check For Error

            #region Assign Value
            if (Request.QueryString["BillHeaderID"] != null)
                Session["BillHeaderID"] = Request.QueryString["BillHeaderID"].ToString().Trim();
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
            //            ObjCmd.CommandText = "PR_BillTeam_SelectByBillHeaderID";
            //            ObjCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = Session["BillHeaderID"];

            //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
            //            {
            //                if (objSdr.HasRows)
            //                {
            //                    while (objSdr.Read())
            //                    {
            //                        if (!objSdr["BillTeamID"].Equals(DBNull.Value))
            //                            Session["BillTeamID"] = objSdr["BillTeamID"].ToString().Trim();
            //                    }
            //                }
            //            }

            //            Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx?BillTeamID=" + Session["BillTeamID"].ToString().Trim());
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

            BillTeamBAL balBillTeam = new BillTeamBAL();
            BillTeamENT entBillTeam = new BillTeamENT();

            entBillTeam = balBillTeam.SelectByBillHeaderID(Convert.ToInt32(Session["BillHeaderID"].ToString().Trim()));

            if (!entBillTeam.BillTeamID.IsNull)
                Session["BillTeamID"] = entBillTeam.BillTeamID.ToString().Trim();

            Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamAddEdit.aspx?BillTeamID=" + Session["BillTeamID"].ToString().Trim());

            #endregion
        }
    }
    #endregion Search BillTeamID By BillHeaderID
}