using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemENT
/// </summary>
public class ItemENT
{
    #region Constructor
    public ItemENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region ItemID

    protected SqlInt32 _ItemID;

    public SqlInt32 ItemID
    {
        get
        {
            return _ItemID;
        }
        set
        {
            _ItemID = value;
        }
    }

    #endregion ItemID

    #region ItemName

    protected SqlString _ItemName;

    public SqlString ItemName
    {
        get
        {
            return _ItemName;
        }
        set
        {
            _ItemName = value;
        }
    }

    #endregion ItemName

    #region CategoryID

    protected SqlInt32 _CategoryID;

    public SqlInt32 CategoryID
    {
        get
        {
            return _CategoryID;
        }
        set
        {
            _CategoryID = value;
        }
    }

    #endregion CategoryID

    #region ItemPhotoPath

    protected SqlString _ItemPhotoPath;

    public SqlString ItemPhotoPath
    {
        get
        {
            return _ItemPhotoPath;
        }
        set
        {
            _ItemPhotoPath = value;
        }
    }

    #endregion ItemPhotoPath
}