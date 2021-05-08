using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>

namespace PartyBook.BAL
{
    public class CityBAL
    {
        #region Constructor
        public CityBAL()
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

        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Delete(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectAll() == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectAll();
        }
        #endregion

        #region SelectAll Operation for GridView

        public DataTable SelectAllforGridView()
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectAllforGridView() == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectAllforGridView();
        }
        #endregion

        #region SelectByPK Operation
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.SelectByPK(CityID) == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectByPK(CityID);
        }
        #endregion

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectForDropDownList() == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectForDropDownList();

        }
        #endregion

        #region SelectForDropDown BY StateID Operation
        public DataTable SelectForDropDownCityByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectForDropDownCityByStateID(StateID) == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectForDropDownCityByStateID(StateID);

        }
        #endregion

        #endregion
    }
}