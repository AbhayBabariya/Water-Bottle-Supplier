using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

/// <summary>
/// Summary description for BranchBALBase
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public abstract class BranchBALBase
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
        public Boolean Insert(BranchENT entBranch)
        {
            BranchDAL branchDAL = new BranchDAL();
            if (branchDAL.Insert(entBranch))
            {
                return true;
            }
            else
            {
                this.Message = branchDAL.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(BranchENT entBranch)
        {
            BranchDAL branchDAL = new BranchDAL();
            if (branchDAL.Update(entBranch))
            {
                return true;
            }
            else
            {
                this.Message = branchDAL.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 BranchID)
        {
            BranchDAL branchDAL = new BranchDAL();
            if (branchDAL.Delete(BranchID))
            {
                return true;
            }
            else
            {
                this.Message = branchDAL.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation
        public DataTable SelectAll()
        {
            BranchDAL dalBranch = new BranchDAL();
            return dalBranch.SelectAll();
        }
        public BranchENT SelectByPK(SqlInt32 BranchID)
        {
            BranchDAL dalBranch = new BranchDAL();
            return dalBranch.SelectByPK(BranchID);
        }
        public DataTable SelectDropDownList()
        {
            BranchDAL dalBranch = new BranchDAL();
            return dalBranch.SelectDropDownList();
        }
        #endregion Select Operation
    }
}