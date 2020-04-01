using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WaterBottleSupplier.BAL;

/// <summary>
/// Summary description for CommonFillMethod
/// </summary>
namespace WaterBottleSupplier
{
public class CommonFillMethod
{
		#region FillDropDownList BranchID
        public static void FillDropDownListBranchID(DropDownList ddl)
        {
            BranchBAL balBranch = new BranchBAL();
            ddl.DataSource = balBranch.SelectDropDownList();
            ddl.DataTextField = "BranchName";
            ddl.DataValueField = "BranchID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Branch", "-1"));
        }
        #endregion FillDropDownList BranchID

        #region FillDropDownList DistributorID
        public static void FillDropDownListDistributorID(DropDownList ddl)
        {
            DistributorBAL balDistributor = new DistributorBAL();
            ddl.DataSource = balDistributor.SelectDropDownList();
            ddl.DataTextField = "DistributorName";
            ddl.DataValueField = "DistributorID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Distributor", "-1"));
        }
        #endregion FillDropDownList DistributorID

        #region FillDropDownList BranchToDistributor
        public static void FillDropDownListBranchToDistributor(DropDownList ddl, SqlInt32 BranchID)
        {
            DistributorBAL balDistributor = new DistributorBAL();
            ddl.DataSource = balDistributor.SelectDropDownList(BranchID);
            ddl.DataTextField = "DistributorName";
            ddl.DataValueField = "DistributorID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Distributor", "-1"));
        }

        #endregion FillDropDownList BranchToDistributor

        #region FillDropDownList CustomerID
        public static void FillDropDownListCustomerID(DropDownList ddl)
        {
            CustomerBAL balCustomer = new CustomerBAL();
            ddl.DataSource = balCustomer.SelectDropDownList();
            ddl.DataTextField = "CustomerName";
            ddl.DataValueField = "CustomerID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Customer", "-1"));
        }
        #endregion FillDropDownList CustomerID

        #region FillDropDownList CustomerID
        public static void OccasionallyOrderCustomerDropDownList(DropDownList ddl)
        {
            OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();
            ddl.DataSource = balOccasionallyOrder.OccasionallyOrderCustomerDropDownList();
            ddl.DataTextField = "CustomerName";
            ddl.DataValueField = "OccasionallyOrderID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Customer", "-1"));
        }
        #endregion FillDropDownList CustomerID

        #region FillDropDownList ProductID
        public static void FillDropDownListProductID(DropDownList ddl)
        {
            CustomerBAL balCustomer = new CustomerBAL();
            ddl.DataSource = balCustomer.SelectDropDownListByProduct();
            ddl.DataTextField = "WaterLtr";
            ddl.DataValueField = "ProductID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Product", "-1"));
        }
        #endregion FillDropDownList ProductID
    }
}
