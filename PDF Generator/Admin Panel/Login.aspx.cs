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

public partial class PDF_Generator_Admin_Panel_Login : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    #endregion Page Load Event

    #region Save Button Event
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString Password = SqlString.Null;
        string Error = "";
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

        #endregion

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
        //            ObjCmd.CommandText = "PR_User_SelectByUserNamePassword";
        //            ObjCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = UserName;
        //            ObjCmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = Password;

        //            using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
        //            {
        //                if (objSdr.HasRows)
        //                {
        //                    while (objSdr.Read())
        //                    {
        //                        if (!objSdr["UserID"].Equals(DBNull.Value))
        //                            Session["UserID"] = objSdr["UserID"].ToString().Trim();
        //                        if (!objSdr["UserName"].Equals(DBNull.Value))
        //                            Session["UserName"] = objSdr["UserName"].ToString().Trim();
        //                    }
        //                    Response.Redirect("~/PDF Generator/Admin Panel/Home/Home.aspx");
        //                }
        //                else
        //                    lblErrorMessage.Text = "User Name or Password not mathched....";
        //            }
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

        #region Open connection

        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByUserNamePassword(UserName, Password);

        if(entUser != null)
        {
            if (!entUser.UserID.IsNull)
                Session["UserID"] = entUser.UserID.ToString().Trim();

            if (!entUser.UserName.IsNull)
                Session["UserName"] = entUser.UserName.ToString().Trim();

            if (!entUser.PhotoPath.IsNull)
                Session["PhotoPath"] = entUser.PhotoPath.ToString().Trim();
        }

        if(!entUser.UserName.IsNull  && !entUser.Password.IsNull)
            Response.Redirect("~/PDF Generator/Admin Panel/Home/Home.aspx");

        else
            lblErrorMessage.Text = "User Name or Password not mathched....";

        #endregion
    }
    #endregion Save Button Event

    #region SignUp Button Event
    protected void btnSignUP_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/CreateAccount.aspx");
    }
    #endregion SignUp Button Event
}