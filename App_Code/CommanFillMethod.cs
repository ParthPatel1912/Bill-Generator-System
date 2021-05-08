using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommanFillMethod
/// </summary>

namespace PartyBook
{
    public class CommanFillMethod
    {
        #region Constructor
        public CommanFillMethod()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region FillDropDownList  State
        public static void FillStateDropDownListState(DropDownList ddlState)
        {
            StateBAL balState = new StateBAL();
            ddlState.DataSource = balState.SelectForDropDown();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--   Select State   --", "-1"));
        }
        #endregion

        #region FillDropDownList  State By CountryID
        public static void FillStateDropDownListStateByCountryID(DropDownList ddlState, SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddlState.DataSource = balState.SelectForDropDownStateByCountryID(CountryID);
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--   Select State   --", "-1"));
        }
        #endregion

        #region FillDropDownList  Country
        public static void FillCountryDropDownListCountry(DropDownList ddlCountry)
        {
            CountryBAL balCountry = new CountryBAL();
            ddlCountry.DataSource = balCountry.SelectForDropDown();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--   Select Country   --", "-1"));
        }
        #endregion

        #region FillDropDownList  City
        public static void FillCityDropDownListCity(DropDownList ddlCity)
        {
            CityBAL balCity = new CityBAL();
            ddlCity.DataSource = balCity.SelectForDropDown();
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--   Select City   --", "-1"));

        }
        #endregion

        #region FillDropDownList  City by StateID
        public static void FillCityDropDownListCityByStateID(DropDownList ddlCity, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddlCity.DataSource = balCity.SelectForDropDownCityByStateID(StateID);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--   Select City   --", "-1"));

        }
        #endregion

        #region FillDropDownList  Category
        public static void FillCategoryDropDownListCategory(DropDownList ddlCategory)
        {
            CategoryBAL balCategory = new CategoryBAL();
            ddlCategory.DataSource = balCategory.SelectForDropDownList();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--   Select Category   --", "-1"));
        }
        #endregion
    }
}