using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for RegularOrderBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class RegularOrderBALBase
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
        public Boolean Insert(RegularOrderENT entRegularOrder)
        {
            RegularOrderDAL regularOrderDAL = new RegularOrderDAL();
            if (regularOrderDAL.Insert(entRegularOrder))
            {
                return true;
            }
            else
            {
                this.Message = regularOrderDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(RegularOrderENT entRegularOrder)
        {
            RegularOrderDAL regularOrderDAL = new RegularOrderDAL();
            if (regularOrderDAL.Update(entRegularOrder))
            {
                return true;
            }
            else
            {
                this.Message = regularOrderDAL.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 RegularOrderID)
        {
            RegularOrderDAL regularOrderDAL = new RegularOrderDAL();
            if (regularOrderDAL.Delete(RegularOrderID))
            {
                return true;
            }
            else
            {
                this.Message = regularOrderDAL.Message;
                return true;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.SelectAll();
        }
        public RegularOrderENT SelectByPK(SqlInt32 RegularOrderID)
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.SelectByPK(RegularOrderID);
        }
        #endregion Select Operation
    }
}