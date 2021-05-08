using PartyBook.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartyBAL
/// </summary>

namespace PartyBook.BAL
{
    public class PartyBAL
    {
        #region Constructor
        public PartyBAL()
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

        public Boolean Insert(PartyENT entParty)
        {
            PartyDAL dalParty = new PartyDAL();

            if (dalParty.Insert(entParty))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(PartyENT entParty)
        {
            PartyDAL dalParty = new PartyDAL();

            if (dalParty.Update(entParty))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 PartyID)
        {
            PartyDAL dalParty = new PartyDAL();

            if (dalParty.Delete(PartyID))
            {
                return true;
            }
            else
            {
                Message = dalParty.Message;
                return false;
            }
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation

        public DataTable SelectAll()
        {
            PartyDAL dalParty= new PartyDAL();
            return dalParty.SelectAll();
        }
        #endregion selectAll Operation

        #region selectAll Operation for grid view

        public DataTable SelectAllForGridView()
        {
            PartyDAL dalParty = new PartyDAL();
            return dalParty.SelectAllForGridView();
        }
        #endregion selectAll Operation

        #region selectByPK Operation

        public PartyENT SelectByPK(SqlInt32 PartyID)
        {
            PartyDAL dalParty = new PartyDAL();
            return dalParty.SelectByPK(PartyID);
        }

        #endregion selectByPK Operation

        #endregion select Operation
    }
}