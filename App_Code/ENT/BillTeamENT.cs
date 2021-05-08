using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillTeamENT
/// </summary>
public class BillTeamENT
{
    #region Constructor
    public BillTeamENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region BillTeamID

    protected SqlInt32 _BillTeamID;

    public SqlInt32 BillTeamID
    {
        get
        {
            return _BillTeamID;
        }
        set
        {
            _BillTeamID = value;
        }
    }

    #endregion BillHeaderID

    #region BillHeaderID

    protected SqlInt32 _BillHeaderID;

    public SqlInt32 BillHeaderID
    {
        get
        {
            return _BillHeaderID;
        }
        set
        {
            _BillHeaderID  = value;
        }
    }

    #endregion BillHeaderID

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

    #region Quantity

    protected SqlInt32 _Quantity;

    public SqlInt32 Quantity
    {
        get
        {
            return _Quantity;
        }
        set
        {
            _Quantity = value;
        }
    }

    #endregion Quantity

    #region Price

    protected SqlDecimal _Price;

    public SqlDecimal Price
    {
        get
        {
            return _Price;
        }
        set
        {
            _Price = value;
        }
    }

    #endregion Price

    #region Discount

    protected SqlDecimal _Discount;

    public SqlDecimal Discount
    {
        get
        {
            return _Discount;
        }
        set
        {
            _Discount = value;
        }
    }

    #endregion Discount

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

    #region CourierCharge

    protected SqlInt32 _CourierCharge;

    public SqlInt32 CourierCharge
    {
        get
        {
            return _CourierCharge;
        }
        set
        {
            _CourierCharge = value;
        }
    }

    #endregion CourierCharge
}