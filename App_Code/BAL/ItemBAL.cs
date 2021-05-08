using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemBAL
/// </summary>

namespace PartyBook.BAL
{
    public class ItemBAL
    {
        #region Constructor
        public ItemBAL()
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

        public Boolean Insert(ItemENT entItem)
        {
            ItemDAL dalItem = new ItemDAL();

            if (dalItem.Insert(entItem))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(ItemENT entItem)
        {
            ItemDAL dalItem = new ItemDAL();

            if (dalItem.Update(entItem))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 ItemID)
        {
            ItemDAL dalItem = new ItemDAL();

            if (dalItem.Delete(ItemID))
            {
                return true;
            }
            else
            {
                Message = dalItem.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation for Grid View

        public DataTable SelectAll()
        {
            ItemDAL dalItem = new ItemDAL();
            return dalItem.SelectAllForGridView();
        }
        #endregion selectAll Operation for Grid View

        #region selectByPK Operation

        public ItemENT SelectByPK(SqlInt32 ItemID)
        {
            ItemDAL dalItem = new ItemDAL();
            return dalItem.SelectByPK(ItemID);
        }

        #endregion selectByPK Operation

        #region Selectgridview BY categoryID Operation
        public DataTable SelectGridViewItemByCategoryID(SqlInt32 CategoryID)
        {
            ItemDAL dalItem = new ItemDAL();
            if (dalItem.SelectGridViewItemByCategoryID(CategoryID) == null)
            {
                Message = dalItem.Message;

            }
            return dalItem.SelectGridViewItemByCategoryID(CategoryID);

        }
        #endregion

        #endregion select Operation
    }
}