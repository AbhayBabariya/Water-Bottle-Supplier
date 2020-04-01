using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;

/// <summary>
/// Summary description for OccasionallyOrderBAL
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class OccasionallyOrderBAL : OccasionallyOrderBALBase
    {
        #region Product SelectDropDownList
        public DataTable SelectDropDownList()
        {
            OccasionallyOrderDAL dalOccasionallyOrder = new OccasionallyOrderDAL();
            return dalOccasionallyOrder.SelectDropDownList();
        }
        #endregion Product SelectDropDownList

        #region OccasionallyOrderSelectSearch
        public DataTable OccasionallyOrderSelectSearch(SqlInt32 BranchID, SqlString CustomerName, SqlInt32 DistributorID, SqlInt32 ProductID, SqlDateTime FromDate, SqlDateTime ToDate)
        {
            OccasionallyOrderDAL dalOccasionallyOrder = new OccasionallyOrderDAL();
            return dalOccasionallyOrder.OccasionallyOrderSelectSearch(BranchID, CustomerName, DistributorID, ProductID, FromDate, ToDate);
        }
        #endregion OccasionallyOrderCustomer DropDownList

        #region Product SelectDropDownList
        public DataTable OccasionallyOrderCustomerDropDownList()
        {
            OccasionallyOrderDAL dalOccasionallyOrder = new OccasionallyOrderDAL();
            return dalOccasionallyOrder.OccasionallyOrderCustomerDropDownList();
        }
        #endregion OccasionallyOrderCustomer DropDownList
    }
}