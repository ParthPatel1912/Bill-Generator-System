using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>

namespace PartyBook.BAL
{
    public class CountryBAL
    {
        #region Constructor
        public CountryBAL()
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

        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
        
            if (dalCountry.Delete(CountryID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.SelectAll() == null)
            {
                Message = dalCountry.Message;

            }
            return dalCountry.SelectAll();
        }
        #endregion

        #region SelectAll Operation for GridView

        public DataTable SelectAllforGridView()
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.SelectAllforGridView() == null)
            {
                Message = dalCountry.Message;

            }
            return dalCountry.SelectAllforGridView();
        }
        #endregion

        #region SelectByPK Operation
        public CountryENT SelectByPK(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.SelectByPK(CountryID) == null)
            {
                Message = dalCountry.Message;

            }
            return dalCountry.SelectByPK(CountryID);
        }
        #endregion

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.SelectForDropDownList() == null)
            {
                Message = dalCountry.Message;

            }
            return dalCountry.SelectForDropDownList();

        }
        #endregion

        #endregion
    }
}