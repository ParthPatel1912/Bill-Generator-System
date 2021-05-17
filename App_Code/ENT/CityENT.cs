using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>
public class CityENT
{
    #region Constuctor
    public CityENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constuctor

    #region CityID

    protected SqlInt32 _CityID;

    public SqlInt32 CityID
    {
        get
        {
            return _CityID;
        }
        set
        {
            _CityID = value;
        }
    }

    #endregion CityID

    #region CityName

    protected SqlString _CityName;

    public SqlString CityName
    {
        get
        {
            return _CityName;
        }
        set
        {
            _CityName = value;
        }
    }

    #endregion CityName

    #region StateID

    protected SqlInt32 _StateID;

    public SqlInt32 StateID
    {
        get
        {
            return _StateID;
        }
        set
        {
            _StateID = value;
        }
    }

    #endregion StateID

    #region CountryID

    protected SqlInt32 _CountryID;

    public SqlInt32 CountryID
    {
        get
        {
            return _CountryID;
        }
        set
        {
            _CountryID = value;
        }
    }

    #endregion CountryID
}