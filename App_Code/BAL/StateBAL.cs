using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>

namespace PartyBook.BAL
{
    public class StateBAL
    {
        #region Constructor
        public StateBAL()
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

        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Delete(StateID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            if (dalState.SelectAll() == null)
            {
                Message = dalState.Message;

            }
            return dalState.SelectAll();
        }
        #endregion

        #region SelectAll Operation for GridView

        public DataTable SelectAllforGridView()
        {
            StateDAL dalState = new StateDAL();
            if (dalState.SelectAllforGridView() == null)
            {
                Message = dalState.Message;

            }
            return dalState.SelectAllforGridView();
        }
        #endregion

        #region SelectByPK Operation
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.SelectByPK(StateID) == null)
            {
                Message = dalState.Message;

            }
            return dalState.SelectByPK(StateID);
        }
        #endregion

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
        {
            StateDAL dalState = new StateDAL();
            if (dalState.SelectForDropDownList() == null)
            {
                Message = dalState.Message;

            }
            return dalState.SelectForDropDownList();

        }
        #endregion

        #region SelectForDropDown BY CountryID Operation
        public DataTable SelectForDropDownStateByCountryID(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.SelectForDropDownStateByCountryID(CountryID) == null)
            {
                Message = dalState.Message;

            }
            return dalState.SelectForDropDownStateByCountryID(CountryID);

        }
        #endregion

        #endregion
    }
}