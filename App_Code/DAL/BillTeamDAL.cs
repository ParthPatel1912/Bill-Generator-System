using PartyBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillTeamDAL
/// </summary>

namespace PartyBook.DAL
{
    public class BillTeamDAL: DatabaseConfig
    {
        #region Constructor
        public BillTeamDAL()
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
                        objCmd.CommandText = "PR_BillTeam_Insert";
                        objCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entBillTeam.CategoryID;
                        objCmd.Parameters.Add("@ItemID", SqlDbType.Int).Value = entBillTeam.ItemID;
                        objCmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = entBillTeam.Discount;
                        objCmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = entBillTeam.Price;
                        objCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = entBillTeam.Quantity;
                        objCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = entBillTeam.BillHeaderID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = entBillTeam.UserID;
                        objCmd.Parameters.Add("@CourierCharge", SqlDbType.Int).Value = entBillTeam.CourierCharge;

                        objCmd.Parameters["@Discount"].Precision = 18;
                        objCmd.Parameters["@Discount"].Scale = 2;
                        objCmd.Parameters["@Price"].Precision = 18;
                        objCmd.Parameters["@Price"].Scale = 2;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        #region Fill Total By BillheaderID Using UpdateByPK

                        BillHeaderBAL balBillHeader = new BillHeaderBAL();
                        BillHeaderENT entBillHeader = new BillHeaderENT();

                        balBillHeader.UpdateTotal(entBillHeader);

                        #endregion Fill Total By BillheaderID Using UpdateByPK

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

        public Boolean Update(BillTeamENT entBillTeam)
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
                        objCmd.CommandText = "PR_BillTeam_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@BillTeamID", entBillTeam.BillTeamID);
                        objCmd.Parameters.AddWithValue("@CategoryID", entBillTeam.CategoryID);
                        objCmd.Parameters.AddWithValue("@ItemID", entBillTeam.ItemID);
                        objCmd.Parameters.AddWithValue("@Discount", entBillTeam.Discount);
                        objCmd.Parameters.AddWithValue("@Price", entBillTeam.Price);
                        objCmd.Parameters.AddWithValue("@Quantity", entBillTeam.Quantity);
                        objCmd.Parameters.AddWithValue("@BillHeaderID", entBillTeam.BillHeaderID);
                        objCmd.Parameters.AddWithValue("@UserID", entBillTeam.UserID);
                        objCmd.Parameters.AddWithValue("@CourierCharge", entBillTeam.CourierCharge);

                        objCmd.Parameters["@Discount"].Precision = 18;
                        objCmd.Parameters["@Discount"].Scale = 2;
                        objCmd.Parameters["@Price"].Precision = 18;
                        objCmd.Parameters["@Price"].Scale = 2;

                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        #region Fill Total By BillheaderID Using UpdateByPK

                        BillHeaderBAL balBillHeader = new BillHeaderBAL();
                        BillHeaderENT entBillHeader = new BillHeaderENT();

                        balBillHeader.UpdateTotal(entBillHeader);

                        #endregion Fill Total By BillheaderID Using UpdateByPK

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

        public Boolean Delete(SqlInt32 BillTeamID)
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
                        objCmd.CommandText = "PR_BillTeam_DeleteByPK";
                        objCmd.Parameters.Add("@BillHeaderID", SqlDbType.Int).Value = BillTeamID;

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
                        objCmd.CommandText = "PR_BillTeam_SelectForGridView";

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

        #endregion selectAll Operation for GridView

        #region selectByPK Operation

        public BillTeamENT SelectByPK(SqlInt32 BillTeamID)
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
                        objCmd.CommandText = "PR_BillTeam_SelectByPK";
                        objCmd.Parameters.AddWithValue("@BillTeamID", BillTeamID);

                        #endregion

                        #region read and set data

                        BillTeamENT entBillTeam = new BillTeamENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BillHeaderID"].Equals(DBNull.Value))
                                    entBillTeam.BillHeaderID= Convert.ToInt32(objSDR["BillHeaderID"].ToString());

                                if (!objSDR["BillTeamID"].Equals(DBNull.Value))
                                    entBillTeam.BillTeamID= Convert.ToInt32( objSDR["BillTeamID"].ToString());

                                if (!objSDR["CategoryID"].Equals(DBNull.Value))
                                    entBillTeam.CategoryID= Convert.ToInt32( objSDR["CategoryID"].ToString());

                                if (!objSDR["Discount"].Equals(DBNull.Value))
                                    entBillTeam.Discount = Convert.ToDecimal(objSDR["Discount"].ToString());

                                if (!objSDR["ItemID"].Equals(DBNull.Value))
                                    entBillTeam.ItemID = Convert.ToInt32(objSDR["ItemID"].ToString());

                                if (!objSDR["Price"].Equals(DBNull.Value))
                                    entBillTeam.Price = Convert.ToDecimal(objSDR["Price"].ToString());

                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                    entBillTeam.Quantity = Convert.ToInt32(objSDR["Quantity"].ToString());

                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entBillTeam.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["CourierCharge"].Equals(DBNull.Value))
                                    entBillTeam.CourierCharge = Convert.ToInt32(objSDR["CourierCharge"].ToString());

                            }
                        }

                        #endregion read and set data

                        return entBillTeam;
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

        #region SelectAllForGridViewByUserID Operation for GridView

        public DataTable SelectAllForGridViewByUserID(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_BillTeam_SelectAllByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);

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

        #endregion selectAll Operation for GridView

        #region SelectByBillHeaderID Operation

        public BillTeamENT SelectByBillHeaderID(SqlInt32 BillHeaderID)
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
                        objCmd.CommandText = "PR_BillTeam_SelectByBillHeaderID";
                        objCmd.Parameters.AddWithValue("@BillHeaderID", BillHeaderID);

                        #endregion

                        #region read and set data

                        BillTeamENT entBillTeam = new BillTeamENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BillHeaderID"].Equals(DBNull.Value))
                                    entBillTeam.BillHeaderID = Convert.ToInt32(objSDR["BillHeaderID"].ToString());

                                if (!objSDR["BillTeamID"].Equals(DBNull.Value))
                                    entBillTeam.BillTeamID = Convert.ToInt32(objSDR["BillTeamID"].ToString());

                                if (!objSDR["CategoryID"].Equals(DBNull.Value))
                                    entBillTeam.CategoryID = Convert.ToInt32(objSDR["CategoryID"].ToString());

                                if (!objSDR["Discount"].Equals(DBNull.Value))
                                    entBillTeam.Discount = Convert.ToDecimal(objSDR["Discount"].ToString());

                                if (!objSDR["ItemID"].Equals(DBNull.Value))
                                    entBillTeam.ItemID = Convert.ToInt32(objSDR["ItemID"].ToString());

                                if (!objSDR["Price"].Equals(DBNull.Value))
                                    entBillTeam.Price = Convert.ToDecimal(objSDR["Price"].ToString());

                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                    entBillTeam.Quantity = Convert.ToInt32(objSDR["Quantity"].ToString());

                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                    entBillTeam.UserID = Convert.ToInt32(objSDR["UserID"].ToString());

                                if (!objSDR["CourierCharge"].Equals(DBNull.Value))
                                    entBillTeam.CourierCharge = Convert.ToInt32(objSDR["CourierCharge"].ToString());
                            }
                        }

                        #endregion read and set data

                        return entBillTeam;
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