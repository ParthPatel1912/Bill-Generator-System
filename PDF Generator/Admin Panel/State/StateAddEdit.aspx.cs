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

public partial class PDF_Generator_Admin_Panel_State_StateAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["StateID"] == null)
            {
                lblTitle.Text = "State Add";
                FillDropDownListCountry();
            }
            else
            {
                lblTitle.Text = "Edit State";
                FillDropDownListCountry();
                FillStateData(Convert.ToInt32(Request.QueryString["StateID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Fill Drop Down List of Country
    private void FillDropDownListCountry()
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
        //            Objcmd.CommandText = "PR_Country_SelectAll";

        //            using (SqlDataReader Objsdr = Objcmd.ExecuteReader())
        //            {
        //                if (Objsdr.HasRows == true)
        //                {
        //                    ddlCountry.DataValueField = "CountryID";
        //                    ddlCountry.DataTextField = "CountryName";

        //                    ddlCountry.DataSource = Objsdr;
        //                    ddlCountry.DataBind();

        //                    ddlCountry.Items.Insert(0, new ListItem("--- Select Country Name ---", "-1"));
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

        CommanFillMethod.FillCountryDropDownListCountry(ddlCountry);
    }
    #endregion Fill Drop Down List of Country

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString StateName = SqlString.Null;
        SqlInt32 CountryID = SqlInt32.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtStateName.Text.Trim() == "")
        {
            Error += "Enter State Name<br/>";
            txtStateName.Focus();
        }
        if (ddlCountry.SelectedIndex == 0)
        {
            Error += "Select Country<br/>";
            ddlCountry.Focus();
        }
        if (Error.ToString().Trim() != "")
        {
            lblError.Text = Error.ToString();
            return;
        }
        #endregion Check for Error(Server Side Validation)

        #region Assign Value

        StateENT entState = new StateENT();

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (ddlCountry.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

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

        //            if (Request.QueryString["StateID"] == null)
        //            {
        //                ObjCmd.CommandText = "PR_State_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_State_UpdateByPK";
        //                ObjCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = Request.QueryString["StateID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@StateName", SqlDbType.NVarChar, 100).Value = StateName;
        //            ObjCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["StateID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtStateName.Text = "";
        //                ddlCountry.SelectedIndex = 0;
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/State/StateGridViewList.aspx");
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

        #region Save Or Edit

        StateBAL balState = new StateBAL();

        if(Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                lblError.Text = "Data Addes Successfully.....";
                ClearControl();
            }
            else
                lblError.Text = balState.Message;
        }

        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"].ToString().Trim());
            if (balState.Update(entState))
                Response.Redirect("~/PDF Generator/Admin Panel/State/StateGridViewList.aspx");
            else
                lblError.Text = balState.Message;
        }

        #endregion
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/State/StateGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillStateData(SqlInt32 StateID)
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
        //            ObjCmd.CommandText = "PR_State_SelectByPK";

        //            ObjCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["StateName"].Equals(DBNull.Value))
        //                            txtStateName.Text = ObjSdr["StateName"].ToString().Trim();

        //                        if (!ObjSdr["CountryID"].Equals(DBNull.Value))
        //                            ddlCountry.SelectedValue = ObjSdr["CountryID"].ToString().Trim();
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

        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();

        entState = balState.SelectByPK(StateID);

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.ToString().Trim();
        if (!entState.CountryID.IsNull)
            ddlCountry.SelectedValue = entState.CountryID.ToString().Trim();
    }
    #endregion Fill Data from Database

    #region Clear Control
    public void ClearControl()
    {
        txtStateName.Text = "";
        ddlCountry.SelectedIndex = 0;
        txtStateName.Focus();
        ddlCountry.Focus();
    }
    #endregion
}