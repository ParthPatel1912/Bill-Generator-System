using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBAL
/// </summary>

namespace PartyBook.BAL
{
    public class UserBAL
    {
        #region Constructor
        public UserBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

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

        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        #region updateByPk Operation

        public Boolean Update(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Update(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion update Operation

        #region updateByUserID Operation

        public Boolean UpdateByUserID(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.UpdateByUserID(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion update Operation

        #endregion

        #region delete Operation

        public Boolean Delete(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation

        public DataTable SelectAll()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectAll();
        }
        #endregion selectAll Operation

        #region SelectByUserID Operation

        public UserENT SelectByUserID(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserID(UserID);
        }

        #endregion selectByPK Operation

        #region SelectByUserNameMobileNo Operation

        public UserENT SelectByUserNameMobileNo(SqlString UserName, SqlString MobileNo)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserNameMobileNo(UserName, MobileNo);
        }

        #endregion selectByPK Operation

        #region SelectByUserNameMobileNoPassword Operation

        public UserENT SelectByUserNameMobileNoPassword(SqlString UserName, SqlString MobileNo, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserNameMobileNoPassword(UserName, MobileNo, Password);
        }

        #endregion selectByPK Operation

        #region SelectByUserNamePassword Operation

        public UserENT SelectByUserNamePassword(SqlString UserName, SqlString Password)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByUserNamePassword(UserName, Password);
        }

        #endregion selectByPK Operation

        #endregion select Operation
    }
}