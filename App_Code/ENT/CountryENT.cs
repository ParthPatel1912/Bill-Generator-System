using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryENT
/// </summary>
public class CountryENT
{
    #region Constructor
    public CountryENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

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

    #region CountryName

    protected SqlString _CountryName;

    public SqlString CountryName
    {
        get
        {
            return _CountryName;
        }
        set
        {
            _CountryName = value;
        }
    }

    #endregion CountryName
}