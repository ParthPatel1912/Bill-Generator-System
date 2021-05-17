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

public partial class PDF_Generator_Admin_Panel_CreateAccount : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    #endregion Page Load Event

    #region Create Button Event
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString Password = SqlString.Null;
        SqlString ConfirmPassword = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        SqlString PhotoPath = SqlString.Null;
        string Error = "";
        #endregion Local Variable

        #region Check For Error
        if (txtUserName.Text.Trim() == "")
            Error += "Enter User Name<br/>";
        if (txtPassword.Text.Trim() == "")
            Error += "Enter Password<br/>";
        if (txtConfirmPassword.Text.Trim() == "")
            Error += "Enter confirm Password<br/>";
        if (txtPassword.Text.Length <= 7)
            Error += "Minimum 8 characters password required<br/>";
        if (txtPassword.Text.Length >= 13)
            Error += "Maximum 12 characters password required<br/>";
        if (txtConfirmPassword.Text.Length <= 7)
            Error += "Minimum 8 characters password required<br/>";
        if (txtConfirmPassword.Text.Length >= 13)
            Error += "Maximum 12 characters password required<br/>";
        if (txtMobileNo.Text.Trim() == "")
            Error += "Enter Mobile No<br/>";
        if (txtMobileNo.Text.Length >= 11 || txtMobileNo.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        if (fuProfile.HasFile == false)
        {
            Error += "Select File of Photo";
        }
        if (Error != "")
        {
            lblErrorMessage.Text = Error.ToString().Trim();
            return;
        }
        #endregion Check For Error

        #region Assign Value

        UserENT entUser = new UserENT();

        if (txtUserName.Text.Trim() != "")
            entUser.UserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            entUser.Password = txtPassword.Text.Trim();
        if (txtMobileNo.Text.Trim() != "")
            entUser.MobileNo = txtMobileNo.Text.Trim();

        if (fuProfile.HasFile)
        {
            String location = "~/PDF Generator/Content/img/User Profile/";
            location += fuProfile.FileName;

            String locationPhysical = Server.MapPath(location);

            if (File.Exists(locationPhysical))
            {
                File.Delete(locationPhysical);
            }

            fuProfile.SaveAs(locationPhysical);

            PhotoPath = location;
            entUser.PhotoPath = PhotoPath;
        }

        #endregion Assign Value

        if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
        {
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
            //            ObjCmd.CommandText = "PR_User_CreateAccout";
            //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
            //            ObjCmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;
            //            ObjCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = MobileNo;

            //            ObjCmd.ExecuteNonQuery();

            //            Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
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

            if (balUser.Insert(entUser))
            {
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
            }

            else
                lblErrorMessage.Text = balUser.Message;

            #endregion
        }
        else
            lblErrorMessage.Text = "Confirm password is not matched with password..?";
    }
    #endregion Create Button Event
}