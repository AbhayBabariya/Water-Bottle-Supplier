using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using WaterBottleSupplier.DAL;

/// <summary>
/// Summary description for DistributorBAL
/// </summary>
namespace WaterBottleSupplier.BAL
{
    public class DistributorBAL : DistributorBALBase
    {
        #region Distributor SelectDropDownList
        public DataTable SelectDropDownList(SqlInt32 BranchID)
        {
            DistributorDAL dalDistributor = new DistributorDAL();
            return dalDistributor.SelectDropDownBranchToDistributorList(BranchID);
        }
        #endregion Distributor SelectDropDownList

        #region DistributorSelectSearch
        public DataTable DistributorSelectSearch(SqlInt32 DistributorID, SqlInt32 BranchID, SqlString MobileNo)
        {
            DistributorDAL dalDistributor = new DistributorDAL();
            return dalDistributor.DistributorSelectSearch(DistributorID, BranchID, MobileNo);
        }
        #endregion DistributorSelectSearch
    }
}