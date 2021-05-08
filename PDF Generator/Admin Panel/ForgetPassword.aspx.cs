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

public partial class PDF_Generator_Admin_Panel_ForgetPassword : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load Event

    #region Submit Button Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check For Error
        if (txtUserName.Text.Trim() == "")
            Error += "Enter User Name<br/>";
        if (txtMobileNo.Text.Trim() == "")
            Error += "Enter Mobile No<br/>";
        if (txtMobileNo.Text.Length >= 11 || txtMobileNo.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        //if (txtMobileNo.Text.Length <= 9)
        //    Error += "Enter 10 digit mobile number";
        if (Error != "")
        {
            lblErrorMessage.Text = Error.ToString().Trim();
            return;
        }
        #endregion Check For Error

        #region Assign Value
        if (txtMobileNo.Text.Trim() != "")
            MobileNo = txtMobileNo.Text.Trim();
        if (txtUserName.Text.Trim() != "")
            UserName = txtUserName.Text.Trim();
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
        //            ObjCmd.CommandText = "PR_User_SelectByUserNameMobileNo";

        //            ObjCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = MobileNo;
        //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;

        //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (objSdr.HasRows)
        //                {
        //                    while (objSdr.Read())
        //                    {
        //                        if (!objSdr["UserName"].Equals(DBNull.Value))
        //                            txtNewUserName.Text = objSdr["UserName"].ToString().Trim();
        //                        if (!objSdr["Password"].Equals(DBNull.Value))
        //                            txtNewPassword.Attributes["value"] = objSdr["Password"].ToString().Trim();
        //                        if (!objSdr["MobileNo"].Equals(DBNull.Value))
        //                            txtNewMobileNo.Text = objSdr["MobileNo"].ToString().Trim();
        //                        if (!objSdr["UserID"].Equals(DBNull.Value))
        //                            Session["UserID"] = objSdr["UserID"].ToString().Trim();
        //                    }
        //                    lblErrorMessage.Text = "Data found successfully.......";
        //                }
        //                else
        //                    lblErrorMessage.Text = "Data not found.......";
        //            }
        //            txtUserName.Text = "";
        //            txtMobileNo.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblErrorMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        if (Objconn.State == System.Data.ConnectionState.Open)
        //            Objconn.Close();
        //    }
        //}
        #endregion Open Connection

        #region Open Connection

        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByUserNameMobileNo(UserName, MobileNo);

        if (entUser != null)
        {
            if (!entUser.UserName.IsNull)
                txtNewUserName.Text = entUser.UserName.ToString().Trim();

            if (!entUser.MobileNo.IsNull)
                txtNewMobileNo.Text = entUser.MobileNo.ToString().Trim();

            if (!entUser.Password.IsNull)
                txtNewPassword.Attributes["value"] = entUser.Password.ToString().Trim();

            if (!entUser.UserID.IsNull)
                Session["UserID"] = entUser.UserID.ToString().Trim();

            lblErrorMessage.Text = "Data found successfully.......";
        }

        if (entUser.UserID.IsNull && entUser.UserName.IsNull && entUser.Password.IsNull && entUser.MobileNo.IsNull)
            lblErrorMessage.Text = "Data not found.......";

        #endregion
    }
    #endregion Submit Button Event

    #region Change Button Event
    protected void btnChange_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        SqlString Password = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check For Error
        if (txtNewUserName.Text.Trim() == "")
            Error += "Enter User Name<br/>";
        if (txtNewMobileNo.Text.Trim() == "")
            Error += "Enter Mobile No<br/>";
        if (txtNewMobileNo.Text.Length >= 11 || txtNewMobileNo.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        if (txtNewPassword.Text.Trim() == "")
            Error += "Enter Password<br/>";
        if (txtNewPassword.Text.Length <= 7)
            Error += "Minimum 8 characters password required<br/>";
        if (txtNewPassword.Text.Length >= 13)
            Error += "Maximum 12 characters password required<br/>";
        if (Error != "")
        {
            lblErrorMessage.Text = Error.ToString().Trim();
            return;
        }
        #endregion Check For Error

        #region Assign Value

        UserENT entUser = new UserENT();

        if (txtNewMobileNo.Text.Trim() != "")
            entUser.MobileNo = txtNewMobileNo.Text.Trim();
        if (txtNewUserName.Text.Trim() != "")
            entUser.UserName = txtNewUserName.Text.Trim();
        if (txtNewPassword.Text.Trim() != "")
            entUser.Password = txtNewPassword.Text.Trim();

        if (Session["UserID"] != null)
            entUser.UserID = Convert.ToInt32( Session["UserID"].ToString().Trim());

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
        //            ObjCmd.CommandText = "PR_User_UpdateByPK";

        //            ObjCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = MobileNo;
        //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
        //            ObjCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
        //            ObjCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];

        //            ObjCmd.ExecuteNonQuery();
        //            lblErrorMessage.Text = "Data successfully Updated.......";

        //            txtNewMobileNo.Text = "";
        //            txtNewPassword.Text = "";
        //            txtNewUserName.Text = "";

        //            Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblErrorMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        Session.Clear();
        //        if (Objconn.State == System.Data.ConnectionState.Open)
        //            Objconn.Close();
        //    }
        //}
        #endregion Open Connection

        #region Open Connection

        UserBAL balUser = new UserBAL();

        if (balUser.Update(entUser))
        {
            Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
        }

        else
            lblNewErrorMessage.Text = balUser.Message;

        #endregion
    }
    #endregion Change Button Event
}