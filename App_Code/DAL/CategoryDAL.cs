using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryDAL
/// </summary>

namespace PartyBook.DAL
{
    public class CategoryDAL : DatabaseConfig
    {
        #region Constructor
        public CategoryDAL()
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

        public Boolean Insert(CategoryENT entCategory)
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
                        objCmd.CommandText = "PR_Category_Insert";
                        objCmd.Parameters.Add("@CategoryName", SqlDbType.VarChar, 100).Value = entCategory.CategoryName;
                        objCmd.Parameters.Add("@CategoryPhotoPath", SqlDbType.VarChar, 200).Value = entCategory.CategoryPhotoPath;

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

        public Boolean Update(CategoryENT entCategory)
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
                        objCmd.CommandText = "PR_Category_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CategoryID", entCategory.CategoryID);
                        objCmd.Parameters.AddWithValue("@CategoryName", entCategory.CategoryName);
                        objCmd.Parameters.AddWithValue("@CategoryPhotoPath", entCategory.CategoryPhotoPath);

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

        public Boolean Delete(SqlInt32 CategoryID)
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
                        objCmd.CommandText = "PR_Category_DeleteByPK";
                        objCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = CategoryID;

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
                        objCmd.CommandText = "PR_Category_SelectAll";

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

        public CategoryENT SelectByPK(SqlInt32 CategoryID)
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
                        objCmd.CommandText = "PR_Category_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                        #endregion

                        #region read and set data

                        CategoryENT entCategory = new CategoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CategoryID"].Equals(DBNull.Value))
                                    entCategory.CategoryID = Convert.ToInt32(objSDR["CategoryID"].ToString());

                                if (!objSDR["CategoryName"].Equals(DBNull.Value))
                                    entCategory.CategoryName = objSDR["CategoryName"].ToString();

                                if (!objSDR["CategoryPhotoPath"].Equals(DBNull.Value))
                                    entCategory.CategoryPhotoPath = objSDR["CategoryPhotoPath"].ToString();
                            }
                        }

                        #endregion read and set data

                        return entCategory;
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
                        objCmd.CommandText = "PR_Category_SelectForDropDown";

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