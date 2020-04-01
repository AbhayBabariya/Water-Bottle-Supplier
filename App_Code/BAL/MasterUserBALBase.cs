using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for MasterUserBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class MasterUserBALBase
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

        #region Insert Operation
        public Boolean Insert(MasterUserENT entMasterUser)
        {
            MasterUserDAL masterUserDAL = new MasterUserDAL();
            if (masterUserDAL.Insert(entMasterUser))
            {
                return true;
            }
            else
            {
                this.Message = masterUserDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation
    }
}