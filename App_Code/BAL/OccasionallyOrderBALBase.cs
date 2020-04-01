using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for OccasionallyOrderBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class OccasionallyOrderBALBase
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
        public Boolean Insert(OccasionallyOrderENT entOccasionallyOrder)
        {
            OccasionallyOrderDAL occasionallyOrderDAL = new OccasionallyOrderDAL();
            if (occasionallyOrderDAL.Insert(entOccasionallyOrder))
            {
                return true;
            }
            else
            {
                this.Message = occasionallyOrderDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(OccasionallyOrderENT entOccasionallyOrder)
        {
            OccasionallyOrderDAL occasionallyOrderDAL = new OccasionallyOrderDAL();
            if (occasionallyOrderDAL.Update(entOccasionallyOrder))
            {
                return true;
            }
            else
            {
                this.Message = occasionallyOrderDAL.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 OccasionallyOrderID)
        {
            OccasionallyOrderDAL occasionallyOrderDAL = new OccasionallyOrderDAL();
            if (occasionallyOrderDAL.Delete(OccasionallyOrderID))
            {
                return true;
            }
            else
            {
                this.Message = occasionallyOrderDAL.Message;
                return true;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            OccasionallyOrderDAL dalOccasionallyOrder = new OccasionallyOrderDAL();
            return dalOccasionallyOrder.SelectAll();
        }
        public OccasionallyOrderENT SelectByPK(SqlInt32 OccasionallyOrderID)
        {
            OccasionallyOrderDAL dalOccasionallyOrder = new OccasionallyOrderDAL();
            return dalOccasionallyOrder.SelectByPK(OccasionallyOrderID);
        }
        #endregion Select Operation
    }
}