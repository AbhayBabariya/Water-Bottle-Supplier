using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for BranchDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class  BranchDALBase : DataBaseConfig
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

        public Boolean Insert(BranchENT entBranch)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Branch_Insert";
                        objCmd.Parameters.AddWithValue("@BranchName", entBranch.BranchName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entBranch.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entBranch.Address);
                        objCmd.Parameters.AddWithValue("@UserID", entBranch.UserID);
                        objCmd.Parameters.AddWithValue("@ManagerName", entBranch.ManagerName);
                        objCmd.Parameters.AddWithValue("@ManagerMobileNo", entBranch.ManagerMobileNo);

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

        public Boolean Update(BranchENT entBranch)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Branch_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@BranchID", entBranch.BranchID);
                        objCmd.Parameters.AddWithValue("@BranchName", entBranch.BranchName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entBranch.MobileNo);
                        objCmd.Parameters.AddWithValue("@Address", entBranch.Address);
                        objCmd.Parameters.AddWithValue("@UserID", entBranch.UserID);
                        objCmd.Parameters.AddWithValue("@ManagerName", entBranch.ManagerName);
                        objCmd.Parameters.AddWithValue("@ManagerMobileNo", entBranch.ManagerMobileNo);
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

        public Boolean Delete(SqlInt32 BranchID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Banch_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@BranchID", BranchID);
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

        public BranchENT SelectByPK(SqlInt32 BranchID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objcmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepar Command

                        objcmd.CommandType = CommandType.StoredProcedure;
                        objcmd.CommandText = "PR_Branch_SelectByPK";
                        objcmd.Parameters.AddWithValue("@BranchID", BranchID);

                        #endregion Prepar Command

                        #region ReadData and Set Controls

                        BranchENT entBranch = new BranchENT();
                        using (SqlDataReader objSDR = objcmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BranchID"].Equals(DBNull.Value))
                                {
                                    entBranch.BranchID = Convert.ToInt32(objSDR["BranchID"]);
                                }
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    entBranch.UserID = Convert.ToInt32(objSDR["UserID"]);
                                }
                                if (!objSDR["BranchName"].Equals(DBNull.Value))
                                {
                                    entBranch.BranchName = Convert.ToString(objSDR["BranchName"]);
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    entBranch.MobileNo = Convert.ToString(objSDR["MobileNo"]);
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    entBranch.Address = Convert.ToString(objSDR["Address"]);
                                }
                                if (!objSDR["ManagerName"].Equals(DBNull.Value))
                                {
                                    entBranch.ManagerName = Convert.ToString(objSDR["ManagerName"]);
                                }
                                if (!objSDR["ManagerMobileNo"].Equals(DBNull.Value))
                                {
                                    entBranch.ManagerMobileNo = Convert.ToString(objSDR["ManagerMobileNo"]);
                                }
                            }
                        }
                        return entBranch;
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
                        objCmd.CommandText = "PR_Branch_SelectAll";
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
                        objCmd.CommandText = "PR_Branch_SelectDropDownList";
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