using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Admin_Panel_User_Profile_UserProfile : System.Web.UI.Page
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
            lblUserName.Text = entUser.UserName.ToString().Trim();

        if(!entUser.MobileNo.IsNull)
            lblMobileNo.Text= entUser.MobileNo.ToString().Trim();

        if (!entUser.Password.IsNull)
            txtPassword.Attributes["value"] = entUser.Password.ToString().Trim();
    }

    #endregion

    #region Edit Button
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PDF Generator/Admin Panel/User Profile/UserProfileEdit.aspx");
    }
    #endregion

    #region Eye Button Event
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