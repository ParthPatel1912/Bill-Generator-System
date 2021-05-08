using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_User_Profile_UserProfileEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");

            if (Session["UserName"] != null)
                lblDisplayName.Text = Session["UserName"].ToString().Trim();

            if (Session["PhotoPath"] != null)
                imgProfile.ImageUrl = Session["PhotoPath"].ToString().Trim();

            FillData();
        }
    }
    #endregion

    #region Fill data from database

    private void FillData()
    {
        UserBAL balUser = new UserBAL();
        UserENT entUser = new UserENT();

        entUser = balUser.SelectByUserID(Convert.ToInt32(Session["UserID"].ToString().Trim()));

        if (!entUser.UserName.IsNull)
            txtUserName.Text = entUser.UserName.ToString().Trim();

        if (!entUser.MobileNo.IsNull)
            txtUserMobileNumber.Text = entUser.MobileNo.ToString().Trim();

        if (!entUser.Password.IsNull)
            txtPassword.Attributes["value"] = entUser.Password.ToString().Trim();
    }

    #endregion

    #region Save button Event
    protected void Save_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString UserName = SqlString.Null;
        SqlString Password = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        SqlString PhotoPath = SqlString.Null;
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
        if (txtUserMobileNumber.Text.Trim() == "")
            Error += "Enter Mobile No<br/>";
        if (txtUserMobileNumber.Text.Length >= 11 || txtUserMobileNumber.Text.Length <= 9)
            Error += "Enter 10 digit mobile number<br/>";
        if (Error != "")
        {
            lblError.Text = Error.ToString().Trim();
            return;
        }
        #endregion Check For Error

        #region Assign Value

        UserENT entUser = new UserENT();

        if (txtUserName.Text.Trim() != "")
            entUser.UserName = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            entUser.Password = txtPassword.Text.Trim();
        if (txtUserMobileNumber.Text.Trim() != "")
            entUser.MobileNo = txtUserMobileNumber.Text.Trim();

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

        else
        {
            if(Session["PhotoPath"] != null)
                entUser.PhotoPath = Session["PhotoPath"].ToString().Trim();
        }

        #region Open Connection

        UserBAL balUser = new UserBAL();
        if(Session["UserID"] != null)
            entUser.UserID = Convert.ToInt32( Session["UserID"].ToString().Trim());

        if (balUser.UpdateByUserID(entUser))
        {
            Session["UserName"] = entUser.UserName.ToString().Trim();
            Session["PhotoPath"] = entUser.PhotoPath.ToString().Trim();

            Response.Redirect("~/PDF Generator/Admin Panel/User Profile/UserProfile.aspx");
        }

        else
            lblError.Text = balUser.Message;

        #endregion

        #endregion Assign Value
    }
    #endregion

    #region cancel button event
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/User Profile/UserProfile.aspx");
    }
    #endregion

    #region Eye button event to show password
    protected void btnEyeImg_Click(object sender, EventArgs e)
    {
        if (txtPassword.TextMode == TextBoxMode.Password)
        {
            txtPassword.TextMode = TextBoxMode.SingleLine;
            btnEyeImg.CssClass = "fa fa-eye-slash";
        }

        else
        {
            txtPassword.TextMode = TextBoxMode.Password;
            btnEyeImg.CssClass = "fa fa-eye";
        }
    }
    #endregion
}