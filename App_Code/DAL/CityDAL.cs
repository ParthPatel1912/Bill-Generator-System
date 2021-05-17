using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityDAL
/// </summary>

namespace PartyBook.DAL
{
    public class CityDAL: DatabaseConfig
    {
        #region Constructor
        public CityDAL()
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
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar, 100).Value = entCity.CityName;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entCity.StateID;

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

        public Boolean Update(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);

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

        public Boolean Delete(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_DeleteByPK";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;

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
                        objCmd.CommandText = "PR_City_SelectAll";

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

        #region selectAll Operation For GridView

        public DataTable SelectAllforGridView()
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
                        objCmd.CommandText = "PR_City_SelectForGridView";

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

        public CityENT SelectByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);

                        #endregion

                        #region read and set data

                        CityENT entCity = new CityENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entCity.CityID= Convert.ToInt32(objSDR["CityID"].ToString());

                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName= objSDR["CityName"].ToString();

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateID = Convert.ToInt32( objSDR["StateID"].ToString());
                            }
                        }

                        #endregion read and set data

                        return entCity;
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

        #region selectForDropDownList Operation

        public DataTable SelectForDropDownList()
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
                        objCmd.CommandText = "PR_City_SelectForDropDown";

                        #endregion

                        #region read and set data 

                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {

                            dt.Load(objSDR);

                            return dt;
                        }

                        #endregion

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

            #endregion open connection
        }

        #endregion selectForDropDownList Operation

        #region SelectForDropDown BY StateID Operation
        public DataTable SelectForDropDownCityByStateID(SqlInt32 StateID)
        {
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
                        objCmd.CommandText = "PR_City_SelectAllByStateID";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;

                        #endregion

                        #region read and set data
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {

                            dt.Load(objSDR);
                        }
                        #endregion

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
        }

        #endregion

        #endregion select Operation
    }
}