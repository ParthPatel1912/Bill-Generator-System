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

public partial class PDF_Generator_Admin_Panel_value_ItemValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ItemID"] != null)
        {
            SearchItemNameByItemID();
            lblTitle.Text = "Enter item Quantity & Price";
        }
    }

    #region Search Item Name By ItemID in session
    private void SearchItemNameByItemID()
    {
        if (Request.QueryString["ItemID"] != null)
        {
            #region Local Variable
            SqlString Error = SqlString.Null;
            #endregion Local Variable

            #region Check For Error
            if (Request.QueryString["ItemID"] == null)
                Error += "not available query string<br/>";
            if (Error != "")
            {
                lblError.Text = Error.ToString().Trim();
                return;
            }
            #endregion Check For Error

            #region Assign Value
            if (Request.QueryString["ItemID"] != null)
                Session["ItemID"] = Request.QueryString["ItemID"].ToString().Trim();
            #endregion Assign Value

            #region Open Connection
            using (SqlConnection Objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyConnectionString"].ConnectionString))
            {
                try
                {
                    if (Objconn.State != System.Data.ConnectionState.Open)
                        Objconn.Open();

                    using (SqlCommand ObjCmd = Objconn.CreateCommand())
                    {
                        ObjCmd.CommandType = CommandType.StoredProcedure;
                        ObjCmd.CommandText = "PR_Item_SelectByPK";
                        ObjCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = Session["ItemID"];

                        using (SqlDataReader objSdr = ObjCmd.ExecuteReader())
                        {
                            if (objSdr.HasRows)
                            {
                                while (objSdr.Read())
                                {
                                    if (!objSdr["ItemName"].Equals(DBNull.Value))
                                        Session["ItemName"] = objSdr["ItemName"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
                finally
                {
                    if (Objconn.State == System.Data.ConnectionState.Open)
                        Objconn.Close();
                }
            }
            #endregion Open Connection
        }
    }
    #endregion Search PartyName By PartyID in session



    protected void txtItem2Value_TextChanged(object sender, EventArgs e)
    {

        String strError = "";
        SqlInt32 txt1ItemQuantity = SqlInt32.Null;
        SqlInt32 txt1ItemValue = SqlInt32.Null;
        int answer;

        if (txtItem1Quantity.ToString().Trim() == "")
        {
            strError += "Enter quantity<br/>";
        }
        if (txtItem1Value.ToString().Trim() == "")
        {
            strError += "Enter value<br/>";
        }
        if (strError.Trim() != "")
        {
            lblError.Text = strError;
            return;
        }

        if (txtItem1Quantity.ToString().Trim() != "")
        {
            txt1ItemQuantity = Convert.ToInt32(txtItem1Quantity.Text.Trim());
        }
        if (txtItem1Value.ToString().Trim() != "")
        {
            txt1ItemValue = Convert.ToInt32(txtItem1Value.Text.Trim());
        }


        if (txt1ItemQuantity.ToString().Trim() != "" && txt1ItemValue.ToString().Trim() != "")
        {
            answer = Convert.ToInt32(txt1ItemQuantity * txt1ItemValue);

            txtItem1TotalRS.Text = answer.ToString().Trim();
        }
    }
}