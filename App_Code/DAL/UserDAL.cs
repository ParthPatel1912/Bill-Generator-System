using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>

namespace PartyBook.DAL
{
    public class UserDAL: DatabaseConfig
    {
        #region Constructor
        public UserDAL()
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
                        objCmd.CommandText = "PR_User_CreateAccout";
                        objCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = entUser.UserName;
                        objCmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = entUser.Password;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 10).Value = entUser.MobileNo;
                        objCmd.Parameters.Add("@PhotoPath", SqlDbType.VarChar, 200).Value = entUser.PhotoPath;

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

        #region updateByPK Operation

        public Boolean Update(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@UserID", entUser.UserID);
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);

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

        #region UpdateByUserID Operation

        public Boolean UpdateByUserID(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_UpdateByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", entUser.UserID);
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);
                        objCmd.Parameters.AddWithValue("@PhotoPath", entUser.PhotoPath);

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

        #endregion

        #region delete Operation

        public Boolean Delete(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_DeleteByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;

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
                        objCmd.CommandText = "PR_User_SelectAll";

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

        #region SelectByUserID Operation

        public UserENT SelectByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_SelectByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion

                        #region read and set data

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = objSDR["UserName"].ToString();

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = objSDR["Password"].ToString();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entUser.MobileNo = objSDR["MobileNo"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entUser;
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

        #region SelectByUserNameMobileNo Operation

        public UserENT SelectByUserNameMobileNo(SqlString UserName, SqlString MobileNo)
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
                        objCmd.CommandText = "PR_User_SelectByUserNameMobileNo";
                        objCmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                        objCmd.Parameters.AddWithValue("@UserName", UserName);

                        #endregion

                        #region read and set data

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = objSDR["UserName"].ToString();

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = objSDR["Password"].ToString();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entUser.MobileNo= objSDR["MobileNo"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entUser;
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

        #region SelectByUserNameMobileNoPassword Operation

        public UserENT SelectByUserNameMobileNoPassword(SqlString UserName, SqlString MobileNo, SqlString Password)
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
                        objCmd.CommandText = "PR_User_SelectByUserNameMobileNoPassword";
                        objCmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", Password);

                        #endregion

                        #region read and set data

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = objSDR["UserName"].ToString();

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = objSDR["Password"].ToString();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entUser.MobileNo = objSDR["MobileNo"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entUser;
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

        #region SelectByUserNamePassword Operation

        public UserENT SelectByUserNamePassword(SqlString UserName, SqlString Password)
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
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("@UserName", UserName);
                        objCmd.Parameters.AddWithValue("@Password", Password);

                        #endregion

                        #region read and set data

                        UserENT entUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = objSDR["UserName"].ToString();

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = objSDR["Password"].ToString();

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entUser.MobileNo = objSDR["MobileNo"].ToString();

                                if (!objSDR["PhotoPath"].Equals(DBNull.Value))
                                    entUser.PhotoPath = objSDR["PhotoPath"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entUser;
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