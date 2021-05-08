using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartyENT
/// </summary>
public class PartyENT
{
    #region Constructor
    public PartyENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region PartyID

    protected SqlInt32 _PartyID;

    public SqlInt32 PartyID
    {
        get
        {
            return _PartyID;
        }
        set
        {
            _PartyID  = value;
        }
    }

    #endregion PartyID

    #region PartyName

    protected SqlString _PartyName;

    public SqlString PartyName
    {
        get
        {
            return _PartyName;
        }
        set
        {
            _PartyName = value;
        }
    }

    #endregion PartyName

    #region PartyMobileNumber

    protected SqlString _PartyMobileNumber;

    public SqlString PartyMobileNumber
    {
        get
        {
            return _PartyMobileNumber;
        }
        set
        {
            _PartyMobileNumber = value;
        }
    }

    #endregion PartyMobileNumber

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