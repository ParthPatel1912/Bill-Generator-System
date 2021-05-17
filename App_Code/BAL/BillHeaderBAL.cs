using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillHeaderBAL
/// </summary>

namespace PartyBook.BAL
{
    public class BillHeaderBAL
    {
        #region Constructor
        public BillHeaderBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local Variable

        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Local Variable

        #region Insert Operation

        public Boolean Insert(BillHeaderENT entBillHeader)
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();

            if (dalBillHeader.Insert(entBillHeader))
            {
                return true;
            }
            else
            {
                Message = dalBillHeader.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(BillHeaderENT entBillHeader)
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();

            if (dalBillHeader.Update(entBillHeader))
            {
                return true;
            }
            else
            {
                Message = dalBillHeader.Message;
                return false;
            }
        }

        #endregion update Operation

        #region update total Operation

        public Boolean UpdateTotal(BillHeaderENT entBillHeader)
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();

            if (dalBillHeader.UpdateTotal(entBillHeader))
            {
                return true;
            }
            else
            {
                Message = dalBillHeader.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 BillHeaderID)
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();

            if (dalBillHeader.Delete(BillHeaderID))
            {
                return true;
            }
            else
            {
                Message = dalBillHeader.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation for GridView

        public DataTable SelectAllForGridView()
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();
            return dalBillHeader.SelectAllForGridView();
        }
        #endregion selectAll Operation for GridView

        #region selectByPK Operation

        public BillHeaderENT SelectByPK(SqlInt32 BillHeaderID)
        {
            BillHeaderDAL dalBillHeader = new BillHeaderDAL();
            return dalBillHeader.SelectByPK(BillHeaderID);
        }

        #endregion selectByPK Operation

        #endregion select Operation
    }
}