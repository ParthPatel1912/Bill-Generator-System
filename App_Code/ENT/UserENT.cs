using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENt
/// </summary>
public class UserENT
{
    #region Constructor
    public UserENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region UserID

    protected SqlInt32 _UserID;

    public SqlInt32 UserID
    {
        get
        {
            return _UserID;
        }
        set
        {
            _UserID = value;
        }
    }

    #endregion UserID

    #region UserName

    protected SqlString _UserName;

    public SqlString UserName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }

    #endregion UserName

    #region Password

    protected SqlString _Password;

    public SqlString Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }

    #endregion Password

    #region MobileNo

    protected SqlString _MobileNo;

    public SqlString MobileNo
    {
        get
        {
            return _MobileNo;
        }
        set
        {
            _MobileNo = value;
        }
    }

    #endregion MobileNo

    #region PhotoPath

    protected SqlString _PhotoPath;

    public SqlString PhotoPath
    {
        get
        {
            return _PhotoPath;
        }
        set
        {
            _PhotoPath = value;
        }
    }

    #endregion PhotoPath
}