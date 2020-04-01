using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for MasterUserDALBase
/// </summary>
namespace WaterBottleSupplier.DAL
{
    public class MasterUserDALBase : DataBaseConfig
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
        public Boolean Insert(MasterUserENT entMasterUser)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_MasterUser_Insert";
                        objCmd.Parameters.AddWithValue("@UserName", entMasterUser.UserName);
                        objCmd.Parameters.AddWithValue("@MobileNo", entMasterUser.MobileNo);
                        objCmd.Parameters.AddWithValue("@EmailID", entMasterUser.EmailID);
                        objCmd.Parameters.AddWithValue("@Password", entMasterUser.Password);
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

    }
}