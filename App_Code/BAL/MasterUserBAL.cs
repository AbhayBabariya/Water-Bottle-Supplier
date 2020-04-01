using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;

/// <summary>
/// Summary description for MasterUserBAL
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class MasterUserBAL :  MasterUserBALBase
    {
        #region SelectByUserNameAndPassword

        public DataTable SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            MasterUserDAL dalMasterUser = new MasterUserDAL();
            return dalMasterUser.SelectByUserNamePassword(UserName, Password);
        }

        #endregion SelectByUserNameAndPassword
    }
}