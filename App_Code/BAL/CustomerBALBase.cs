using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for CustomerBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class CustomerBALBase
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
        public Boolean Insert(CustomerENT entCustomer)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            if(customerDAL.Insert(entCustomer))
            {
                return true;
            }
            else
            {
                this.Message = customerDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CustomerENT entCustomer)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            if(customerDAL.Update(entCustomer))
            {
                return true;
            }
            else
            {
                this.Message = customerDAL.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 CustomerID)
        {
            CustomerDAL customerDAL = new CustomerDAL();
            if (customerDAL.Delete(CustomerID))
            {
                return true;
            }
            else
            {
                this.Message = customerDAL.Message;
                return true;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectAll();
        }
        public CustomerENT SelectByPK(SqlInt32 CustomerID)
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectByPK(CustomerID);
        }
        public DataTable SelectDropDownList()
        {
            CustomerDAL dalCustomer = new CustomerDAL();
            return dalCustomer.SelectDropDownList();
        }
        #endregion Select Operation
    }
}