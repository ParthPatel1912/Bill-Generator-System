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

public partial class PDF_Generator_Admin_Panel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["CountryID"] == null)
            {
                lblTitle.Text = "Country Add";
            }
            else
            {
                lblTitle.Text = "Edit Country";
                FillCountryData(Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString CountryName = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtCountryName.Text.Trim() == "")
        {
            Error += "Enter Country Name<br/>";
            txtCountryName.Focus();
        }
        if (Error.ToString().Trim() != "")
        {
            lblError.Text = Error.ToString();
            return;
        }
        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

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

        //            if (Request.QueryString["CountryID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_Country_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_Country_UpdateByPK";
        //                ObjCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = Request.QueryString["CountryID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@CountryName", SqlDbType.NVarChar, 100).Value = CountryName;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["CountryID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtCountryName.Text = "";
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/Country/CountryGridViewList.aspx");
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

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                lblError.Text = "Data Addes Successfully.....";
                txtCountryName.Text = "";
                txtCountryName.Focus();
            }

            else
                lblError.Text = balCountry.Message;
        }

        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim());

            if (balCountry.Update(entCountry))
                Response.Redirect("~/PDF Generator/Admin Panel/Country/CountryGridViewList.aspx");

            else
                lblError.Text = balCountry.Message;
        }

        #endregion
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Country/CountryGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillCountryData(SqlInt32 CountryID)
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
        //            ObjCmd.CommandText = "PR_Country_SelectByPK";

        //            ObjCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["CountryName"].Equals(DBNull.Value))
        //                            txtCountryName.Text = ObjSdr["CountryName"].ToString().Trim();
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

        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = new CountryENT();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.ToString();
    }
    #endregion Fill Data from Database
}