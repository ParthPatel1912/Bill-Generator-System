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

public partial class PDF_Generator_Admin_Panel_PartyAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Request.QueryString["PartyID"] == null)
            {
                lblTitle.Text = "Party Add";
                FillDropDownListCountry();
            }
            else
            {
                lblTitle.Text = "Edit Party";
                FillDropDownListCountry();
                FillPartyData(Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim()));
            }
        }
    }
    #endregion Page Load Event

    #region Fill DropDown List of Country
    private void FillDropDownListCountry()
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
        //            ObjCmd.CommandText = "PR_Country_SelectAll";

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows == true)
        //                {
        //                    ddlCountry.DataValueField = "CountryID";
        //                    ddlCountry.DataTextField = "CountryName";

        //                    ddlCountry.DataSource = ObjSdr;
        //                    ddlCountry.DataBind();

        //                    ddlCountry.Items.Insert(0, new ListItem("-- Select Country --", "-1"));
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

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
    #endregion Fill DropDown List of Country

    #region Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString PartyName = SqlString.Null;
        SqlString PartyMobileNumber = SqlString.Null;
        SqlInt32 CityID = SqlInt32.Null;
        SqlInt32 StateID = SqlInt32.Null;
        SqlInt32 CountryID = SqlInt32.Null;
        string Error = "";
        #endregion Local Variable

        #region Check for Error(Server Side Validation)
        if (txtPartyName.Text.Trim() == "")
        {
            Error += "Enter Party Name<br/>";
            txtPartyName.Focus();
        }
        if (txtPartyMobileNumber.Text.Trim() == "")
        {
            Error += "Enter Party Mobile Number<br/>";
            txtPartyMobileNumber.Focus();
        }
        if (txtPartyMobileNumber.Text.Length >= 11 || txtPartyMobileNumber.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        if (ddlCity.SelectedIndex == 0)
        {
            Error += "Select City<br/>";
            ddlCity.Focus();
        }
        if (ddlState.SelectedIndex == 0)
        {
            Error += "Select State<br/>";
            ddlState.Focus();
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

        PartyENT entParty = new PartyENT();

        if (txtPartyName.Text.Trim() != "")
            entParty.PartyName = txtPartyName.Text.Trim();

        if (txtPartyMobileNumber.Text.Trim() != "")
            entParty.PartyMobileNumber = txtPartyMobileNumber.Text.Trim();

        if (ddlCity.SelectedIndex > 0)
            entParty.CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlState.SelectedIndex > 0)
            entParty.StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (ddlCountry.SelectedIndex > 0)
            entParty.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

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
        //                ObjCmd.CommandText = "PR_Party_Insert";
        //            }

        //            else
        //            {
        //                ObjCmd.CommandText = "PR_Party_UpdateByPK";
        //                ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = Request.QueryString["PartyID"].ToString().Trim();
        //            }

        //            ObjCmd.Parameters.Add("@PartyName", SqlDbType.NVarChar, 100).Value = PartyName;
        //            ObjCmd.Parameters.Add("@PartyMobileNumber", SqlDbType.VarChar, 50).Value = PartyMobileNumber;
        //            ObjCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
        //            ObjCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
        //            ObjCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

        //            ObjCmd.ExecuteNonQuery();

        //            if (Request.QueryString["PartyID"] == null)
        //            {
        //                lblError.Text = "Data Addes Successfully.....";
        //                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
        //                txtPartyName.Text = "";
        //                txtPartyMobileNumber.Text = "";
        //                ddlCity.SelectedIndex = 0;
        //                ddlState.SelectedIndex = 0;
        //                ddlCountry.SelectedIndex = 0;
        //            }

        //            else
        //            {
        //                Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyGridViewList.aspx");
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

        if (Session["UserID"].ToString().Trim() == "1")
        {
            #region Save or Edit

            PartyBAL balParty = new PartyBAL();

            if (Request.QueryString["PartyID"] == null)
            {
                if (balParty.Insert(entParty))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save()", true);
                    lblError.Text = "Data Addes Successfully.....";
                    Clearcontrol();
                }
                else
                    lblError.Text = balParty.Message;
            }

            else
            {
                entParty.PartyID = Convert.ToInt32(Request.QueryString["PartyID"].ToString().Trim());
                if (balParty.Update(entParty))
                    Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyGridViewList.aspx");
                else
                    lblError.Text = balParty.Message;
            }

            #endregion
        }
        else
        {
            lblError.Text = "You are not Admin !!!";
            Clearcontrol();
        }
    }
    #endregion Save Button Event

    #region Cancel Button Event
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/Party/PartyGridViewList.aspx");
    }
    #endregion Cancel Button Event

    #region Fill data From Database
    private void FillPartyData(SqlInt32 PartyID)
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
        //            ObjCmd.CommandText = "PR_Party_SelectByPK";

        //            ObjCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;

        //            using (SqlDataReader ObjSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (ObjSdr.HasRows)
        //                {
        //                    while (ObjSdr.Read())
        //                    {
        //                        if (!ObjSdr["PartyName"].Equals(DBNull.Value))
        //                            txtPartyName.Text = ObjSdr["PartyName"].ToString().Trim();

        //                        if (!ObjSdr["PartyMobileNumber"].Equals(DBNull.Value))
        //                            txtPartyMobileNumber.Text = ObjSdr["PartyMobileNumber"].ToString().Trim();

        //                        if (!ObjSdr["CountryID"].Equals(DBNull.Value))
        //                        {
        //                            ddlCountry.SelectedValue = ObjSdr["CountryID"].ToString().Trim();
        //                            FillDropDownListStateByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
        //                        }

        //                        if (!ObjSdr["StateID"].Equals(DBNull.Value))
        //                        {
        //                            ddlState.SelectedValue = ObjSdr["StateID"].ToString().Trim();
        //                            FillDropDownListCityByStateID(Convert.ToInt32(ddlState.SelectedValue));
        //                        }

        //                        if (!ObjSdr["CityID"].Equals(DBNull.Value))
        //                            ddlCity.SelectedValue = ObjSdr["CityID"].ToString().Trim();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception ex)
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

        PartyBAL balParty = new PartyBAL();
        PartyENT entParty = new PartyENT();

        entParty = balParty.SelectByPK(PartyID);

        if (!entParty.PartyName.IsNull)
            txtPartyName.Text = entParty.PartyName.ToString().Trim();
        if (!entParty.PartyMobileNumber.IsNull)
            txtPartyMobileNumber.Text = entParty.PartyMobileNumber.ToString().Trim();
        if (!entParty.CityID.IsNull)
            ddlCity.SelectedValue = entParty.CityID.ToString().Trim();
        if (!entParty.StateID.IsNull)
        {
            CommanFillMethod.FillStateDropDownListStateByCountryID(ddlState, Convert.ToInt32(entParty.CountryID.ToString().Trim()));
            ddlState.SelectedValue = entParty.StateID.ToString().Trim();
        }
        if (!entParty.CountryID.IsNull)
        {
            CommanFillMethod.FillCityDropDownListCityByStateID(ddlCity, Convert.ToInt32(entParty.StateID.ToString().Trim()));
            ddlCountry.SelectedValue = entParty.CountryID.ToString().Trim();
        }
    }
    #endregion Fill Data from Database

    #region ddlCountry Load Event
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            CommanFillMethod.FillStateDropDownListStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue));
            //FillDropDownListStateByCountryID(Convert.ToInt32(ddlCountry.SelectedValue));
        }
        else
        {
            ddlState.Items.Clear();
            ddlState.Items.Insert(0, new ListItem("-- Select State --", "-1"));

            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
        }
    }
    #endregion ddlCountry Load Event

    #region ddlState Load Event
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            CommanFillMethod.FillCityDropDownListCityByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue));
            //FillDropDownListCityByStateID(Convert.ToInt32(ddlState.SelectedValue));
        }
        else
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("-- Select City --", "-1"));
        }
    }
    #endregion ddlState Load Event

    #region ddlCity Load Event
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion ddlCity Load Event

    #region Clear Control
    private void Clearcontrol()
    {
        txtPartyName.Text = "";
        txtPartyMobileNumber.Text = "";
        ddlCity.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
    }
    #endregion
}