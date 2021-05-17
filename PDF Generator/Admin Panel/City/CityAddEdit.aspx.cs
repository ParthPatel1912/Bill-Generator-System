using PartyBook;
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

public partial class PDF_Generator_Admin_Panel_City_CityAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["CityID"] == null)
            {
                lblTitle.Text = "City Add";
                FillDropDownListState();
            }
            else
            {
                lblTitle.Text = "Edit City";
                FillDropDownListState();
                FillCityData(Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Fill Drop Down List of City
    private void FillDropDownListState()
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
        //            Objcmd.CommandText = "PR_State_SelectAll";

        //            using (SqlDataReader Objsdr = Objcmd.ExecuteReader())
        //            {
        //                if (Objsdr.HasRows == true)
        //                {
        //                    ddlState.DataValueField = "StateID";
        //                    ddlState.DataTextField = "StateName";

        //                    ddlState.DataSource = Objsdr;
        //                    ddlState.DataBind();

        //                    ddlState.Items.Insert(0, new ListItem("--- Select State Name ---", "-1"));
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

        CommanFillMethod.FillStateDropDownListState(ddlState);
    }
    #endregion Fill Drop Down List of City

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString CityName = SqlString.Null;
        SqlInt32 StateID = SqlInt32.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtCityName.Text.Trim() == "")
        {
            Error += "Enter City Name<br/>";
            txtCityName.Focus();
        }
        if (ddlState.SelectedIndex == 0)
        {
            Error += "Select State<br/>";
            ddlState.Focus();
        }
        if (Error.ToString().Trim() != "")
        {
            lblError.Text = Error.ToString();
            return;
        }
        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        CityENT entCity = new CityENT();

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();
        if (ddlState.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);

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

        //            if (Request.QueryString["CityID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_City_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_City_UpdateByPK";
        //                ObjCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = Request.QueryString["CityID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@CityName", SqlDbType.NVarChar, 100).Value = CityName;
        //            ObjCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["CityID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtCityName.Text = "";
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/City/CityGridViewList.aspx");
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

        CityBAL balCity = new CityBAL();

        if(Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                lblError.Text = "Data Addes Successfully.....";
                ClearControl();
            }
            else
                lblError.Text = balCity.Message;
        }

        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim());
            if (balCity.Update(entCity))
                Response.Redirect("~/PDF Generator/Admin Panel/City/CityGridViewList.aspx");
        }

        #endregion
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/City/CityGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillCityData(SqlInt32 CityID)
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
        //            ObjCmd.CommandText = "PR_City_SelectByPK";

        //            ObjCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["CityName"].Equals(DBNull.Value))
        //                            txtCityName.Text = ObjSdr["CityName"].ToString().Trim();

        //                        if (!ObjSdr["StateID"].Equals(DBNull.Value))
        //                            ddlState.SelectedValue = ObjSdr["StateID"].ToString().Trim();
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

        CityBAL balCity = new CityBAL();
        CityENT entCity = new CityENT();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.ToString().Trim();
        if (!entCity.StateID.IsNull)
            ddlState.SelectedValue = entCity.StateID.ToString().Trim();
    }
    #endregion Fill Data from Database

    #region Clear Control

    private void ClearControl()
    {
        txtCityName.Text = "";
        ddlState.SelectedIndex = 0;
        txtCityName.Focus();
        ddlState.Focus();
    }

    #endregion
}