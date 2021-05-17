using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryDAL
/// </summary>

namespace PartyBook.DAL
{
    public class CountryDAL: DatabaseConfig
    {
        #region Constructor
        public CountryDAL()
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
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar, 100).Value = entCountry.CountryName;
                
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

        public Boolean Update(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);

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

        public Boolean Delete(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_DeleteByPK";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;

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
                        objCmd.CommandText = "PR_Country_SelectAll";

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
                        objCmd.CommandText = "PR_Country_SelectForGridView";

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

        public CountryENT SelectByPK(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);

                        #endregion

                        #region read and set data

                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCountry.CountryID= Convert.ToInt32(objSDR["CountryID"].ToString());

                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    entCountry.CountryName = objSDR["CountryName"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entCountry;
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
                        objCmd.CommandText = "PR_Country_SelectForDropDown";

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

        #endregion select Operation
    }
}