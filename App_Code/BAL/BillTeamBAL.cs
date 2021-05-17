using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillTeamBAL
/// </summary>

namespace PartyBook.BAL
{
    public class BillTeamBAL
    {
        #region Constructor
        public BillTeamBAL()
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

        public Boolean Insert(BillTeamENT entBillTeam)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();

            if (dalBillTeam.Insert(entBillTeam))
            {
                return true;
            }
            else
            {
                Message = dalBillTeam.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(BillTeamENT entBillTeam)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();

            if (dalBillTeam.Update(entBillTeam))
            {
                return true;
            }
            else
            {
                Message = dalBillTeam.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 BillHeaderID)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();

            if (dalBillTeam.Delete(BillHeaderID))
            {
                return true;
            }
            else
            {
                Message = dalBillTeam.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation For GridView

        public DataTable SelectAllForGridView()
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();
            return dalBillTeam.SelectAllForGridView();
        }
        #endregion selectAll Operation For GridView

        #region selectByPK Operation

        public BillTeamENT SelectByPK(SqlInt32 BillTeamID)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();
            return dalBillTeam.SelectByPK(BillTeamID);
        }

        #endregion selectByPK Operation

        #region SelectAllForGridViewByUserID Operation For GridView

        public DataTable SelectAllForGridViewByUserID(SqlInt32 UserID)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();
            return dalBillTeam.SelectAllForGridViewByUserID(UserID);
        }
        #endregion selectAll Operation For GridView

        #region SelectByBillHeaderID Operation

        public BillTeamENT SelectByBillHeaderID(SqlInt32 BillHeaderID)
        {
            BillTeamDAL dalBillTeam = new BillTeamDAL();
            return dalBillTeam.SelectByBillHeaderID(BillHeaderID);
        }

        #endregion selectByPK Operation

        #endregion select Operation
    }
}