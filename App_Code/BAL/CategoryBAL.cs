using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryBAL
/// </summary>

namespace PartyBook.BAL
{   
    public class CategoryBAL
    {
        #region Constructor
        public CategoryBAL()
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

        public Boolean Insert(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();

            if (dalCategory.Insert(entCategory))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(CategoryENT entCategory)
        {
            CategoryDAL dalCategory = new CategoryDAL();

            if (dalCategory.Update(entCategory))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();

            if (dalCategory.Delete(CategoryID))
            {
                return true;
            }
            else
            {
                Message = dalCategory.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation

        public DataTable SelectAll()
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectAll();
        }
        #endregion selectAll Operation

        #region selectByPK Operation

        public CategoryENT SelectByPK(SqlInt32 CategoryID)
        {
            CategoryDAL dalCategory = new CategoryDAL();
            return dalCategory.SelectByPK(CategoryID);
        }

        #endregion selectByPK Operation

        #region selectForDropDownList Operation

        public DataTable SelectForDropDownList()
        {
            CategoryDAL Dalcategory = new CategoryDAL();
            return Dalcategory.SelectForDropDownList();
        }

        #endregion selectForDropDownList Operation

        #endregion select Operation
    }

}