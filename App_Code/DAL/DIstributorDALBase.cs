using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for DIstributorDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class DIstributorDALBase : DataBaseConfig
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

        public Boolean Insert(DistributorENT entDistributor)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Distributor_Insert";
                        objCmd.Parameters.AddWithValue("@BranchID", entDistributor.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorName", entDistributor.DistributorName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entDistributor.MobileNo);
                        objCmd.Parameters.AddWithValue("@VehicleType", entDistributor.VehicleType);
                        objCmd.Parameters.AddWithValue("@VehicleNo", entDistributor.VehicleNo);
                        objCmd.Parameters.AddWithValue("@UserID", entDistributor.UserID);
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

        public Boolean Update(DistributorENT entDistributor)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Distributor_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@DistributorID", entDistributor.DistributorID);
                        objCmd.Parameters.AddWithValue("@BranchID", entDistributor.BranchID);
                        objCmd.Parameters.AddWithValue("@DistributorName", entDistributor.DistributorName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entDistributor.MobileNo);
                        objCmd.Parameters.AddWithValue("@VehicleType", entDistributor.VehicleType);
                        objCmd.Parameters.AddWithValue("@VehicleNo", entDistributor.VehicleNo);
                        objCmd.Parameters.AddWithValue("@UserID", entDistributor.UserID);
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

        public Boolean Delete(SqlInt32 DistributorID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Distributor_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@DistributorID", DistributorID);
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

        public DistributorENT SelectByPK(SqlInt32 DistributorID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Distributor_SelectByPK";
                        objcmd.Parameters.AddWithValue("@DistributorID", DistributorID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        DistributorENT entDistributor = new DistributorENT();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["DistributorID"].Equals(DBNull.Value))
                                {
                                    entDistributor.DistributorID = Convert.ToInt32(objSDR["DistributorID"]);
                                }
                                if (!objSDR["BranchID"].Equals(DBNull.Value))
                                {
                                    entDistributor.BranchID = Convert.ToInt32(objSDR["BranchID"]);
                                }
                                if (!objSDR["DistributorName"].Equals(DBNull.Value))
                                {
                                    entDistributor.DistributorName = Convert.ToString(objSDR["DistributorName"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entDistributor.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["VehicleType"].Equals(DBNull.Value))
                                {
                                    entDistributor.VehicleType = Convert.ToString(objSDR["VehicleType"]);
                                }
                                if (!objSDR["VehicleNo"].Equals(DBNull.Value))
                                {
                                    entDistributor.VehicleNo = Convert.ToString(objSDR["VehicleNo"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entDistributor.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                            }
                        }
                        return entDistributor;
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
                        objCmd.CommandText = "PR_Distributor_SelectAll";
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
                        objCmd.CommandText = "PR_Distributor_SelectDropDownList";
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