using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for RegularOrederBAL
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class RegularOrderBAL : RegularOrderBALBase
    {
        #region Product DropDownList
        public DataTable SelectDropDownList()
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.SelectDropDownList();
        }
        #endregion Product DropDownList

        #region FillCustomer
        public DataTable FillCustomer(SqlInt32 CustomerID)
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.FillCustomer(CustomerID);
        }
        #endregion FillCustomer

        #region SelectProductAmount
        public DataTable SelectProductAmount(SqlInt32 ProductID)
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.SelectProductAmount(ProductID);
        }
        #endregion SelectProductAmount

        #region RegularOrderSelectSearch
        public DataTable RegularOrderSelectSearch(RegularOrderENT entRegularOrder)
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.RegularOrderSelectSearch(entRegularOrder);
        }
        #endregion RegularOrderSelectSearch

        #region RegularOrderSelectCustomerWiseSearchInvoice
        public DataTable RegularOrderSelectCustomerWiseSearchInvoice(RegularOrderENT entRegularOrder)
        {
            RegularOrderDAL dalRegularOrder = new RegularOrderDAL();
            return dalRegularOrder.RegularOrderSelectCustomerWiseSearchInvoice(entRegularOrder);
        }
        #endregion RegularOrderSelectCustomerWiseSearchInvoice
    }
}