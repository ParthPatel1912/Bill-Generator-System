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

public partial class PDF_Generator_Admin_Panel_DeleteAccount : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load Event

    #region Delete Button Event
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString Password = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        string Error = "";
        int Check = 0;
        #endregion Local Variable

        #region Check For Error
        if (txtUserName.Text.Trim() == "")
            Error += "Enter User Name<br/>";
        if (txtPassword.Text.Trim() == "")
            Error += "Enter Password<br/>";
        if (txtPassword.Text.Length <= 7)
            Error += "Minimum 8 characters password required<br/>";
        if (txtPassword.Text.Length >= 13)
            Error += "Maximum 12 characters password required<br/>";
        if (txtMobileNo.Text.Trim() == "")
            Error += "Enter Mobile No<br/>";
        if (txtMobileNo.Text.Length >= 11 || txtMobileNo.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        if (Error != "")
        {
            lblErrorMessage.Text = Error.ToString().Trim();
            return;
        }
        #endregion Check For Error

        #region Assign Value
        if (txtUserName.Text.Trim() != "")
            UserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            Password = txtPassword.Text.Trim();
        if (txtMobileNo.Text.Trim() != "")
            MobileNo = txtMobileNo.Text.Trim();
        #endregion Assign Value

        CheckUserName(UserName, Password, MobileNo);

        #region Open Connection EXTRA
        //if (Check == -1)
        //{
        //    #region Open Connection EXTRA
        //    //using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
        //    //{
        //    //    try
        //    //    {
        //    //        if (Objconn.State != System.Data.ConnectionState.Open)
        //    //            Objconn.Open();

        //    //        using (SqlCommand ObjCmd = Objconn.CreateCommand())
        //    //        {
        //    //            ObjCmd.CommandType = CommandType.StoredProcedure;
        //    //            ObjCmd.CommandText = "PR_User_DeleteByUserNamePasswordMobileNo";
        //    //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
        //    //            ObjCmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
        //    //            ObjCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = MobileNo;

        //    //            ObjCmd.ExecuteNonQuery();
        //    //            lblErrorMessage.Text = "Data Deleted.......";

        //    //            txtMobileNo.Text = "";
        //    //            txtPassword.Text = "";
        //    //            txtUserName.Text = "";

        //    //            Response.Redirect("~/PDF Generator/Admin Panel/CreateAccount.aspx");
        //    //        }
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        lblErrorMessage.Text = ex.Message;
        //    //    }
        //    //    finally
        //    //    {
        //    //        if (Objconn.State == System.Data.ConnectionState.Open)
        //    //            Objconn.Close();
        //    //    }
        //    //}
        //    #endregion Open Connection


        //}
        #endregion

        #region Open Connection

        UserBAL balUser = new UserBAL();

        if (Session["UserID"] != null)
        {
            if (balUser.Delete(Convert.ToInt32(Session["UserID"].ToString().Trim())))
                Response.Redirect("~/PDF Generator/Admin Panel/CreateAccount.aspx");

            else
                lblErrorMessage.Text = balUser.Message;
        }

        else
            Response.Redirect("~/PDF Generator/Admin Panel/ForgetPassword.aspx");
        #endregion
    }
    #endregion Delete Button Event

    #region For Check User is valid or not
    private void CheckUserName(SqlString UserName, SqlString Password, SqlString MobileNo)
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
        //            ObjCmd.CommandText = "PR_User_SelectByUserNameMobileNoPassword";

        //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Username;
        //            ObjCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
        //            ObjCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;

        //            using (SqlDataReader objSDR = ObjCmd.ExecuteReader())
        //            {
        //                if (objSDR.HasRows)
        //                {
        //                    return -1;
        //                }
        //                else
        //                {
        //                    lblErrorMessage.Text = "User Name and Password does not match!!!!";
        //                    return 1;
        //                }
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblErrorMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (Objconn.State == ConnectionState.Open)
        //            Objconn.Close();
        //    }
        //}
        #endregion Open Connection
        //return 1;

        #region Open Connection
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByUserNameMobileNoPassword(UserName, MobileNo, Password);

        if (entUser != null)
        {
            if (!entUser.UserID.IsNull)
                Session["UserID"] = entUser.UserID.ToString().Trim();
        }

        else
            lblErrorMessage.Text = "User Name and Password does not match!!!!";
        #endregion

    }
    #endregion For Check User is valid or not
}