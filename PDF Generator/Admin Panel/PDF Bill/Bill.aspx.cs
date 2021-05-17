using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_PDF_Bill_Bill : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

        if (Request.QueryString["BillTeamID"] != null)
            Fill(Convert.ToInt32(Request.QueryString["BillTeamID"].ToString().Trim()));

        else
            Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
    }
    #endregion

    #region Fill Grid View
    private void Fill(SqlInt32 BillTeamID)
    {
        #region Open Connection 
        using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        {
            try
            {
                if (Objconn.State != ConnectionState.Open)
                    Objconn.Open();

                using (SqlCommand ObjCmd = Objconn.CreateCommand())
                {
                    ObjCmd.CommandType = CommandType.StoredProcedure;
                    ObjCmd.CommandText = "PR_BillTeam_SelectAll";

                    ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = BillTeamID;

                    using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
                    {
                        if (ObjSdr.HasRows)
                        {
                            gvData.DataSource = ObjSdr;
                            gvData.DataBind();

                            FillAllData(BillTeamID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (Objconn.State == ConnectionState.Open)
                    Objconn.Close();
            }
        }
        #endregion Open Connection
    }
    #endregion

    #region Fill All data
    private void FillAllData(SqlInt32 BillTeamID)
    {
        #region Open Connection
        using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        {
            try
            {
                if (Objconn.State != ConnectionState.Open)
                    Objconn.Open();

                using (SqlCommand ObjCmd = Objconn.CreateCommand())
                {
                    ObjCmd.CommandType = CommandType.StoredProcedure;
                    ObjCmd.CommandText = "PR_BillTeam_SelectAll";

                    ObjCmd.Parameters.Add("@BillTeamID", SqlDbType.Int).Value = BillTeamID;

                    using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
                    {
                        if (ObjSdr.HasRows)
                        {
                            while (ObjSdr.Read())
                            {
                                if (!ObjSdr["OrderDateTime"].Equals(DBNull.Value))
                                    lbldate.Text = ObjSdr["OrderDateTime"].ToString().Trim();

                                if (!ObjSdr["PartyName"].Equals(DBNull.Value))
                                    lblPartyName.Text = ObjSdr["PartyName"].ToString().Trim();

                                if (!ObjSdr["Total"].Equals(DBNull.Value))
                                    lblGrandTotal.Text = ObjSdr["Total"].ToString().Trim();

                                if (!ObjSdr["BillTeamID"].Equals(DBNull.Value))
                                    lblInvoiveBillNo.Text = ObjSdr["BillTeamID"].ToString().Trim();

                                if (!ObjSdr["PartyMobileNumber"].Equals(DBNull.Value))
                                    lblPartyMobileNo.Text = ObjSdr["PartyMobileNumber"].ToString().Trim();

                                if (!ObjSdr["CityName"].Equals(DBNull.Value))
                                    lblPartyCity.Text = ObjSdr["CityName"].ToString().Trim();

                                if (!ObjSdr["StateName"].Equals(DBNull.Value))
                                    lblState.Text = ObjSdr["StateName"].ToString().Trim();

                                if (!ObjSdr["CountryName"].Equals(DBNull.Value))
                                    lblCountry.Text = ObjSdr["CountryName"].ToString().Trim();

                                if (!ObjSdr["Discount"].Equals(DBNull.Value))
                                    lblDiscount.Text = ObjSdr["Discount"].ToString().Trim();

                                if (!ObjSdr["CourierCharge"].Equals(DBNull.Value))
                                    lblCourierCharge.Text = ObjSdr["CourierCharge"].ToString().Trim();

                                if (!ObjSdr["Amount"].Equals(DBNull.Value))
                                    lblSubTotal.Text = ObjSdr["Amount"].ToString().Trim();

                                if (!ObjSdr["Status"].Equals(DBNull.Value))
                                {
                                    lblStatus.Text = "&nbsp;" + ObjSdr["Status"].ToString().Trim() + "&nbsp;";

                                    if (lblStatus.Text == "&nbsp;Pending&nbsp;")
                                    {
                                        lblStatus.ForeColor = Color.White;
                                        lblStatus.BackColor = Color.Red;
                                    }

                                    if (lblStatus.Text == "&nbsp;Paid&nbsp;")
                                    {
                                        lblStatus.ForeColor = Color.White;
                                        lblStatus.BackColor = Color.Green;
                                    }
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (Objconn.State == ConnectionState.Open)
                    Objconn.Close();
            }
        }
        #endregion Open Connection
    }
    #endregion

    #region solve error for gridlist
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion

    #region cancle button event
    protected void btncancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/BillTeam/BillTeamGridViewList.aspx");
    }
    #endregion
}