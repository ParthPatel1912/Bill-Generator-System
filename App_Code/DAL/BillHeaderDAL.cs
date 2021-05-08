using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillHeaderDAL
/// </summary>

namespace PartyBook.DAL
{
    public class BillHeaderDAL: DatabaseConfig
    {
        #region Constructor
        public BillHeaderDAL()
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

        public Boolean Insert(BillHeaderENT entBillHeader)
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
                        objCmd.CommandText = "PR_BillHeader_Insert";
                        objCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@OrderDateTime", SqlDbType.DateTime).Value = entBillHeader.OrderDateTime;
                        objCmd.Parameters.Add("@PartyID", SqlDbType.Int).Value = entBillHeader.PartyID;
                        objCmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = entBillHeader.Total;
                        objCmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = entBillHeader.Status;

                        objCmd.Parameters["@Total"].Precision = 18;
                        objCmd.Parameters["@Total"].Scale = 2;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        entBillHeader.BillHeaderID = Convert.ToInt32(objCmd.Parameters["@BillHeaderID"].Value);

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

        public Boolean Update(BillHeaderENT entBillHeader)
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
                        objCmd.CommandText = "PR_BillHeader_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@BillHeaderID", entBillHeader.BillHeaderID);
                        objCmd.Parameters.AddWithValue("@OrderDateTime", entBillHeader.OrderDateTime);
                        objCmd.Parameters.AddWithValue("@PartyID", entBillHeader.PartyID);
                        objCmd.Parameters.AddWithValue("@Total", entBillHeader.Total);
                        objCmd.Parameters.AddWithValue("@Amount", entBillHeader.Amount);
                        objCmd.Parameters.AddWithValue("@Status", entBillHeader.Status);

                        objCmd.Parameters["@Total"].Precision = 18;
                        objCmd.Parameters["@Total"].Scale = 2;
                        objCmd.Parameters["@Amount"].Precision = 18;
                        objCmd.Parameters["@Amount"].Scale = 2;

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

        #region update total Operation

        public Boolean UpdateTotal(BillHeaderENT entBillHeader)
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
                        objCmd.CommandText = "PR_BillHeader_UpdateByPKOnlyTotal";
                        objCmd.Parameters.AddWithValue("@BillHeaderID", entBillHeader.BillHeaderID);
                        objCmd.Parameters.AddWithValue("@Total", entBillHeader.Total);
                        objCmd.Parameters.AddWithValue("@Amount", entBillHeader.Amount);

                        objCmd.Parameters["@Total"].Precision = 18;
                        objCmd.Parameters["@Total"].Scale = 2;
                        objCmd.Parameters["@Amount"].Precision = 18;
                        objCmd.Parameters["@Amount"].Scale = 2;

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

        public Boolean Delete(SqlInt32 BillHeaderID)
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
                        objCmd.CommandText = "PR_BillHeader_DeleteByPK";
                        objCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = BillHeaderID;

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

        #region selectByPK Operation

        public BillHeaderENT SelectByPK(SqlInt32 BillHeaderID)
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
                        objCmd.CommandText = "PR_BillHeader_SelectByPK";
                        objCmd.Parameters.AddWithValue("@BillHeaderID", BillHeaderID);

                        #endregion

                        #region read and set data

                        BillHeaderENT entBillHeader= new BillHeaderENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BillHeaderID"].Equals(DBNull.Value))
                                    entBillHeader.BillHeaderID= Convert.ToInt32(objSDR["BillHeaderID"].ToString());

                                if (!objSDR["OrderDateTime"].Equals(DBNull.Value))
                                    entBillHeader.OrderDateTime = Convert.ToDateTime( objSDR["OrderDateTime"].ToString());

                                if (!objSDR["PartyID"].Equals(DBNull.Value))
                                    entBillHeader.PartyID= Convert.ToInt32( objSDR["PartyID"].ToString());

                                if (!objSDR["Total"].Equals(DBNull.Value))
                                    entBillHeader.Total = Convert.ToDecimal(objSDR["Total"].ToString());

                                if (!objSDR["Amount"].Equals(DBNull.Value))
                                    entBillHeader.Amount = Convert.ToDecimal(objSDR["Amount"].ToString());

                                if (!objSDR["Status"].Equals(DBNull.Value))
                                    entBillHeader.Status = Convert.ToString(objSDR["Status"].ToString());
                            }
                        }

                        #endregion read and set data

                        return entBillHeader;
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

        #region selectAll for gridview Operation

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
                        objCmd.CommandText = "PR_BillHeader_SelectForGridView";

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

        #endregion select Operation
    }
}