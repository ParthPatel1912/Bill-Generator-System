using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartyDAL
/// </summary>

namespace PartyBook.DAL
{
    public class PartyDAL: DatabaseConfig
    {
        #region Constructor
        public PartyDAL()
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

        public Boolean Insert(PartyENT entParty)
        {
            #region open connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_Insert";
                        objCmd.Parameters.Add("@PartyName", SqlDbType.NVarChar,100).Value = entParty.PartyName;
                        objCmd.Parameters.Add("@PartyMobileNumber", SqlDbType.VarChar,50).Value = entParty.PartyMobileNumber;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entParty.CityID;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entParty.StateID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entParty.CountryID;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion open connection
        }

        #endregion Insert Operation

        #region update Operation

        public Boolean Update(PartyENT entParty)
        {
            #region open connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@PartyName", entParty.PartyName);
                        objCmd.Parameters.AddWithValue("@PartyMobileNumber", entParty.PartyMobileNumber);
                        objCmd.Parameters.AddWithValue("@CityID", entParty.CityID);
                        objCmd.Parameters.AddWithValue("@PartyID", entParty.PartyID);
                        objCmd.Parameters.AddWithValue("@StateID", entParty.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entParty.CountryID);

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion open connection
        }

        #endregion update Operation

        #region delete Operation

        public Boolean Delete(SqlInt32 PartyID)
        {
            #region open connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_DeleteByPK";
                        objCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion open connection
        }

        #endregion delete Operation

        #region select Operation

        #region selectAll Operation

        public DataTable SelectAll()
        {
            #region Open Connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_SelectAll";

                        #endregion Prepare Command

                        #region read and set data

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }

                        #endregion read and set dat+a

                        return dt;
                    }
                }

                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion Open Connection
        }

        #endregion selectAll Operation

        #region selectAll Operation for GridView

        public DataTable SelectAllForGridView()
        {
            #region Open Connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_SelectForGridView";

                        #endregion Prepare Command

                        #region read and set data

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }

                        #endregion read and set dat+a

                        return dt;
                    }
                }

                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion Open Connection
        }

        #endregion selectAll Operation

        #region selectByPK Operation

        public PartyENT SelectByPK(SqlInt32 PartyID)
        {
            #region Open Connection

            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Party_SelectByPK";
                        objCmd.Parameters.AddWithValue("@PartyID", PartyID);

                        #endregion

                        #region read and set data

                        PartyENT entParty = new PartyENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["PartyID"].Equals(DBNull.Value))
                                    entParty.PartyID = Convert.ToInt32(objSDR["PartyID"].ToString());

                                if (!objSDR["PartyName"].Equals(DBNull.Value))
                                    entParty.PartyName= objSDR["PartyName"].ToString();

                                if (!objSDR["PartyMobileNumber"].Equals(DBNull.Value))
                                    entParty.PartyMobileNumber= objSDR["PartyMobileNumber"].ToString();

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entParty.CityID = Convert.ToInt32(objSDR["CityID"].ToString());

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entParty.StateID = Convert.ToInt32(objSDR["StateID"].ToString());

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entParty.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString());
                            }
                        }

                        #endregion read and set data

                        return entParty;
                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

            #endregion Open Connection
        }

        #endregion selectByPK Operation

        #endregion select Operation
    }
}