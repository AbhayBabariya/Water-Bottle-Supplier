using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for OccasionallyOrderDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class OccasionallyOrderDALBase : DataBaseConfig
    {
        #region Local Veriable

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

        #endregion Local Veriable

        #region Insert Operaction

        public Boolean Insert(OccasionallyOrderENT entOccasionallyOrder)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OccasionallyOrder_Insert";
                        objCmd.Parameters.AddWithValue("@BranchID", entOccasionallyOrder.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entOccasionallyOrder.DistributorID);
                        objCmd.Parameters.AddWithValue("@ProductID", entOccasionallyOrder.ProductID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entOccasionallyOrder.CustomerName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entOccasionallyOrder.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entOccasionallyOrder.Address);
                        objCmd.Parameters.AddWithValue("@Quantity", entOccasionallyOrder.Quantity);
                        objCmd.Parameters.AddWithValue("@TotalAmount", entOccasionallyOrder.TotalAmount);
                        objCmd.Parameters.AddWithValue("@OrderDate", entOccasionallyOrder.OrderDate);
                        objCmd.Parameters.AddWithValue("@BottleIn", entOccasionallyOrder.BottleIn);
                        objCmd.Parameters.AddWithValue("@Status", entOccasionallyOrder.Status);
                        objCmd.Parameters.AddWithValue("@UserID", entOccasionallyOrder.UserID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Insert Operaction

        #region Update Operaction

        public Boolean Update(OccasionallyOrderENT entOccasionallyOrder)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OccasionallyOrder_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@OccasionallyOrderID", entOccasionallyOrder.OccasionallyOrderID);
                        objCmd.Parameters.AddWithValue("@BranchID", entOccasionallyOrder.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entOccasionallyOrder.DistributorID);
                        objCmd.Parameters.AddWithValue("@ProductID", entOccasionallyOrder.ProductID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entOccasionallyOrder.CustomerName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entOccasionallyOrder.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entOccasionallyOrder.Address);
                        objCmd.Parameters.AddWithValue("@Quantity", entOccasionallyOrder.Quantity);
                        objCmd.Parameters.AddWithValue("@TotalAmount", entOccasionallyOrder.TotalAmount);
                        objCmd.Parameters.AddWithValue("@OrderDate", entOccasionallyOrder.OrderDate);
                        objCmd.Parameters.AddWithValue("@BottleIn", entOccasionallyOrder.BottleIn);
                        objCmd.Parameters.AddWithValue("@Status", entOccasionallyOrder.Status);
                        objCmd.Parameters.AddWithValue("@UserID", entOccasionallyOrder.UserID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }
        #endregion Update Operaction

        #region Delete Operaction

        public Boolean Delete(SqlInt32 OccasionallyOrderID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OccasionallyOrder_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@OccasionallyOrderID", OccasionallyOrderID);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }

        #endregion Delete Operaction

        #region Select Operaction

        public OccasionallyOrderENT SelectByPK(SqlInt32 OccasionallyOrderID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_OccasionallyOrder_SelectByPK";
                        objcmd.Parameters.AddWithValue("@OccasionallyOrderID", OccasionallyOrderID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        OccasionallyOrderENT entOccasionallyOrder = new OccasionallyOrderENT();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["OccasionallyOrderID"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.OccasionallyOrderID = Convert.ToInt32(objSDR["OccasionallyOrderID"]);
                                }
                                if (!objSDR["BranchID"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.BranchID = Convert.ToInt32(objSDR["BranchID"]);
                                }
                                if (!objSDR["DistributorID"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.DistributorID = Convert.ToInt32(objSDR["DistributorID"]);
                                }
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.Quantity = Convert.ToInt32(objSDR["Quantity"]);
                                }
                                if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.TotalAmount = Convert.ToDecimal(objSDR["TotalAmount"]);
                                }
                                if (!objSDR["OrderDate"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.OrderDate = Convert.ToDateTime(objSDR["OrderDate"]);
                                }
                                if (!objSDR["BottleIn"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.BottleIn = Convert.ToInt32(objSDR["BottleIn"]);
                                }
                                if (!objSDR["Status"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.Status = Convert.ToBoolean(objSDR["Status"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entOccasionallyOrder.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                            }
                        }
                        return entOccasionallyOrder;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }

        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_OccasionallyOrder_SelectAll";
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ReadData and Set Controls
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message.ToString();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message.ToString();
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
            }
        }

        #endregion Select Operaction
    }
}