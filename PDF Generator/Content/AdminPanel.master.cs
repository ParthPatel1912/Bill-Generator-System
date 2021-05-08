using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF_Generator_Content_AdminPanel : System.Web.UI.MasterPage
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserName"] != null)
                lblDisplayName.Text = "Hi,&nbsp;" + Session["UserName"].ToString().Trim();

            if (Session["PhotoPath"] != null)
                imgProfile.ImageUrl = Session["PhotoPath"].ToString().Trim();

            //else
            //    Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
        }
    }
    #endregion Page Load Event

    #region Logout Button Event
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/PDF Generator/Admin Panel/Login.aspx");
    }
    #endregion Logout Button Event
}
