using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for RegularOrderDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class RegularOrderDALBase : DataBaseConfig
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

        public Boolean Insert(RegularOrderENT entRegulrOrder)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_RegularOrder_Insert";
                        objCmd.Parameters.AddWithValue("@CustomerID", entRegulrOrder.CustomerID);
                        objCmd.Parameters.AddWithValue("@BranchID", entRegulrOrder.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entRegulrOrder.DistributorID);
                        objCmd.Parameters.AddWithValue("@ProductID", entRegulrOrder.ProductID);
                        objCmd.Parameters.AddWithValue("@Quantity", entRegulrOrder.Quantity);
                        objCmd.Parameters.AddWithValue("@TotalAmount", entRegulrOrder.TotalAmount);
                        objCmd.Parameters.AddWithValue("@BottleIn", entRegulrOrder.BottleIn);
                        objCmd.Parameters.AddWithValue("@OrderDate", entRegulrOrder.OrderDate);
                        objCmd.Parameters.AddWithValue("@UserID", entRegulrOrder.UserID);
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

        public Boolean Update(RegularOrderENT entRegulrOrder)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_RegularOrder_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@RegularOrderID", entRegulrOrder.RegularOrderID);
                        objCmd.Parameters.AddWithValue("@CustomerID", entRegulrOrder.CustomerID);
                        objCmd.Parameters.AddWithValue("@BranchID", entRegulrOrder.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entRegulrOrder.DistributorID);
                        objCmd.Parameters.AddWithValue("@ProductID", entRegulrOrder.ProductID);
                        objCmd.Parameters.AddWithValue("@Quantity", entRegulrOrder.Quantity);
                        objCmd.Parameters.AddWithValue("@TotalAmount", entRegulrOrder.TotalAmount);
                        objCmd.Parameters.AddWithValue("@BottleIn", entRegulrOrder.BottleIn);
                        objCmd.Parameters.AddWithValue("@OrderDate", entRegulrOrder.OrderDate);
                        objCmd.Parameters.AddWithValue("@UserID", entRegulrOrder.UserID);
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

        public Boolean Delete(SqlInt32 RegularOrderID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_RegularOrder_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@RegularOrderID", RegularOrderID);
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

        public RegularOrderENT SelectByPK(SqlInt32 RegularOrderID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_RegularOrder_SelectByPK";
                        objcmd.Parameters.AddWithValue("@RegularOrderID", RegularOrderID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        RegularOrderENT entRegularOrder = new RegularOrderENT();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["RegularOrderID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.RegularOrderID = Convert.ToInt32(objSDR["RegularOrderID"]);
                                }
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                }
                                if (!objSDR["BranchID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.BranchID = Convert.ToInt32(objSDR["BranchID"]);
                                }
                                if (!objSDR["DistributorID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.DistributorID = Convert.ToInt32(objSDR["DistributorID"]);
                                }
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.Quantity = Convert.ToInt32(objSDR["Quantity"]);
                                }
                                if (!objSDR["TotalAmount"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.TotalAmount = Convert.ToDecimal(objSDR["TotalAmount"]);
                                }
                                if (!objSDR["BottleIn"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.BottleIn = Convert.ToInt32(objSDR["BottleIn"]);
                                }
                                if (!objSDR["OrderDate"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.OrderDate = Convert.ToDateTime(objSDR["OrderDate"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entRegularOrder.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                            }
                        }
                        return entRegularOrder;
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
                        objCmd.CommandText = "PR_RegularOrder_SelectAll";
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