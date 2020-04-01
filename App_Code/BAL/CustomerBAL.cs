using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;

/// <summary>
/// Summary description for CustomerBAL
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class CustomerBAL : CustomerBALBase
    {
        #region Product DropDownList
        public DataTable SelectDropDownListByProduct()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectDropDownListByProduct();
        }
        #endregion Product DropDownList

        #region SelectProductAmount
        public DataTable SelectProductAmount(SqlInt32 ProductID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectProductAmount(ProductID);
        }
        #endregion SelectProductAmount

        #region CustomerSelectSearch
        public DataTable CustomerSelectSearch(SqlInt32 CustomerID, SqlString MobileNo, SqlInt32 ProductID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.CustomerSelectSearch(CustomerID, MobileNo, ProductID);
        }
        #endregion CustomerSelectSearch
    }
}