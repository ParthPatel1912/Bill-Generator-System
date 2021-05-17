using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillHeaderENT
/// </summary>
public class BillHeaderENT
{
    #region Constructor
    public BillHeaderENT()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

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
            _BillHeaderID = value;
        }
    }

    #endregion BillHeaderID

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
            _PartyID = value;
        }
    }

    #endregion BillHeaderID

    #region OrderDateTime

    protected SqlDateTime _OrderDateTime;

    public SqlDateTime OrderDateTime
    {
        get
        {
            return _OrderDateTime;
        }
        set
        {
            _OrderDateTime = value;
        }
    }

    #endregion BillHeaderID

    #region Total

    protected SqlDecimal _Total;

    public SqlDecimal Total
    {
        get
        {
            return _Total;
        }
        set
        {
            _Total = value;
        }
    }

    #endregion BillHeaderID

    #region Amount

    protected SqlDecimal _Amount;

    public SqlDecimal Amount
    {
        get
        {
            return _Amount;
        }
        set
        {
            _Amount = value;
        }
    }

    #endregion 

    #region Status

    protected SqlString _Status;

    public SqlString Status
    {
        get
        {
            return _Status;
        }
        set
        {
            _Status = value;
        }
    }

    #endregion 
}