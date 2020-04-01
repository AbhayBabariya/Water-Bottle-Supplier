using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for DistributorBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class DistributorBALBase
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
        public Boolean Insert(DistributorENT entDistributor)
        {
            DistributorDAL distributorDAL = new DistributorDAL();
            if (distributorDAL.Insert(entDistributor))
            {
                return true;
            }
            else
            {
                this.Message = distributorDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(DistributorENT entDistributor)
        {
            DistributorDAL distributorDAL = new DistributorDAL();
            if (distributorDAL.Update(entDistributor))
            {
                return true;
            }
            else
            {
                this.Message = distributorDAL.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 DistributorID)
        {
            DistributorDAL distributorDAL = new DistributorDAL();
            if (distributorDAL.Delete(DistributorID))
            {
                return true;
            }
            else
            {
                this.Message = distributorDAL.Message;
                return true;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            DistributorDAL dalDistributor = new DistributorDAL();
            return dalDistributor.SelectAll();
        }
        public DistributorENT SelectByPK(SqlInt32 DistributorID)
        {
            DistributorDAL dalDistributor = new DistributorDAL();
            return dalDistributor.SelectByPK(DistributorID);
        }
        public DataTable SelectDropDownList()
        {
            DistributorDAL dalDistributor = new DistributorDAL();
            return dalDistributor.SelectDropDownList();
        }
        #endregion Select Operation
    }
}