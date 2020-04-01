using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for CustomerDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class CustomerDALBase : DataBaseConfig
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

        public Boolean Insert(CustomerENT entCustomer)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Customer_Insert";
                        objCmd.Parameters.AddWithValue("@BranchID", entCustomer.BranchID);
                        objCmd.Parameters.AddWithValue("@ProductID", entCustomer.ProductID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entCustomer.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entCustomer.Address);
                        objCmd.Parameters.AddWithValue("@Quantity", entCustomer.Quantity);
                        objCmd.Parameters.AddWithValue("@BottlePrice", entCustomer.BottlePrice);
                        objCmd.Parameters.AddWithValue("@UserID", entCustomer.UserID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entCustomer.DistributorID);
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

        public Boolean Update(CustomerENT entCustomer)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Customer_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", entCustomer.CustomerID);
                        objCmd.Parameters.AddWithValue("@BranchID", entCustomer.BranchID);
                        objCmd.Parameters.AddWithValue("@ProductID", entCustomer.ProductID);
                        objCmd.Parameters.AddWithValue("@CustomerName", entCustomer.CustomerName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entCustomer.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entCustomer.Address);
                        objCmd.Parameters.AddWithValue("@Quantity", entCustomer.Quantity);
                        objCmd.Parameters.AddWithValue("@BottlePrice", entCustomer.BottlePrice);
                        objCmd.Parameters.AddWithValue("@UserID", entCustomer.UserID);
                        objCmd.Parameters.AddWithValue("@DistributorID", entCustomer.DistributorID);
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

        public Boolean Delete(SqlInt32 CustomerID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Customer_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@CustomerID", CustomerID);
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

        public CustomerENT SelectByPK(SqlInt32 CustomerID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Customer_SelectByPK";
                        objcmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        CustomerENT entCustomer = new CustomerENT();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CustomerID"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerID = Convert.ToInt32(objSDR["CustomerID"]);
                                }
                                if (!objSDR["BranchID"].Equals(DBNull.Value))
                                {
                                    entCustomer.BranchID = Convert.ToInt32(objSDR["BranchID"]);
                                }
                                if (!objSDR["DistributorID"].Equals(DBNull.Value))
                                {
                                    entCustomer.DistributorID = Convert.ToInt32(objSDR["DistributorID"]);
                                }
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                {
                                    entCustomer.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                }
                                if (!objSDR["CustomerName"].Equals(DBNull.Value))
                                {
                                    entCustomer.CustomerName = Convert.ToString(objSDR["CustomerName"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entCustomer.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entCustomer.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                {
                                    entCustomer.Quantity = Convert.ToInt32(objSDR["Quantity"]);
                                }
                                if (!objSDR["BottlePrice"].Equals(DBNull.Value))
                                {
                                    entCustomer.BottlePrice = Convert.ToDecimal(objSDR["BottlePrice"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entCustomer.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                            }
                        }
                        return entCustomer;
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
                        objCmd.CommandText = "PR_Customer_SelectAll";
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

        public DataTable SelectDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Customer_SelectDropDownList";
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