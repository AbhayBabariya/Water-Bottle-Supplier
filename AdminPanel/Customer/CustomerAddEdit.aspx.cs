using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier;
using WaterBottleSupplier.BAL;
using WaterBottleSupplier.ENT;

public partial class AdminPanel_Customer_CustomerAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect(CommonVariables.LoginURL);
        }
        if (!Page.IsPostBack)
        {
          
            FillDropDownList();

            if (Request.QueryString["CustomerID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["CustomerID"]));
                CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));
                lblPageHeader.Text = "Edit Customer Details";
            }
            else
            {
                lblPageHeader.Text = "Add New Customer";

            }
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 CustomerID)
    {
        
            CustomerENT entCustomer = new CustomerENT();
            CustomerBAL balCustomer = new CustomerBAL();

            entCustomer = balCustomer.SelectByPK(CustomerID);

            if (!entCustomer.CustomerName.IsNull)
                txtCustomerName.Text = entCustomer.CustomerName.Value.ToString();

            if (!entCustomer.MobileNo.IsNull)
                txtMobileNo.Text = entCustomer.MobileNo.Value.ToString();

            if (!entCustomer.Address.IsNull)
                txtCustomerAddress.Text = entCustomer.Address.Value.ToString();

            if (!entCustomer.BranchID.IsNull)
                ddlBranchID.SelectedValue = entCustomer.BranchID.Value.ToString();

            if (!entCustomer.DistributorID.IsNull)
                ddlDistributorID.SelectedValue = entCustomer.DistributorID.Value.ToString();

            if (!entCustomer.ProductID.IsNull)
                ddlProductID.SelectedValue = entCustomer.ProductID.Value.ToString();

            if (!entCustomer.Quantity.IsNull)
                txtQuantity.Text = entCustomer.Quantity.Value.ToString();

            if (!entCustomer.BottlePrice.IsNull)
                txtAmount.Text = entCustomer.BottlePrice.Value.ToString();
        
    }
    #endregion LoadControls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Server Side Validation

            String strError = String.Empty;

            if (txtCustomerName.Text.Trim() == String.Empty)
                strError += "- Enter Customer Name<br />";

            if (txtMobileNo.Text.Trim() == String.Empty)
                strError += "- Enter Mobile No<br />";

            if (txtCustomerAddress.Text.Trim() == String.Empty)
                strError += "- Enter Customer Address<br />";

            if (ddlBranchID.SelectedIndex == 0)
                strError += "- Select Branch<br />";

            if (ddlDistributorID.SelectedIndex == 0)
                strError += "- Select Distributor<br />";

            if (ddlProductID.SelectedIndex == 0)
                strError += "- Select Product<br />";

            if (txtQuantity.Text.Trim() == String.Empty)
                strError += "- Enter Quantity<br />";

            if (txtAmount.Text.Trim() == String.Empty)
                strError += "- Enter Bottle Amount<br />";

            #endregion Server Side Validation

            
            CustomerENT entCustomer = new CustomerENT();
            CustomerBAL balCustomer = new CustomerBAL();
            
            #region Gather Data
            
            if (txtCustomerName.Text.Trim() != String.Empty)
                entCustomer.CustomerName = txtCustomerName.Text.Trim();
            
            if (txtMobileNo.Text.Trim() != String.Empty)
                entCustomer.MobileNo = txtMobileNo.Text.Trim();
            
            if (txtCustomerAddress.Text.Trim() != String.Empty)
                entCustomer.Address = txtCustomerAddress.Text.Trim();
            
            if (ddlBranchID.SelectedIndex > 0)
                entCustomer.BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);
            
            if (ddlDistributorID.SelectedIndex > 0)
                entCustomer.DistributorID= Convert.ToInt32(ddlDistributorID.SelectedValue);
            
            if (ddlProductID.SelectedIndex > 0)
                entCustomer.ProductID = Convert.ToInt32(ddlProductID.SelectedValue);
            
            if (txtQuantity.Text.Trim() != String.Empty)
                entCustomer.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            
            if (txtAmount.Text.Trim() != String.Empty)
                entCustomer.BottlePrice = Convert.ToDecimal(txtAmount.Text.Trim());
            
            entCustomer.UserID = Convert.ToInt32(Session["UserID"]);
            
            if (Request.QueryString["CustomerID"] == null)
            {
                balCustomer.Insert(entCustomer);
                lblMessage.Text = "Data Inserted Successfully";
                ClearControls();
            }
            else
            {
                entCustomer.CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
                balCustomer.Update(entCustomer);
                Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
            }
            #endregion Gather Data
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message.ToString();
        }
    }
    #endregion Button : Save

    #region FillDropDownList

    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListBranchID(ddlBranchID);
        CommonFillMethod.FillDropDownListProductID(ddlProductID);
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));

    }
    #endregion FillDropDownList

    

    #region ddlProduct_SelectedIndexChanged
    public void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        CustomerENT entCustomer = new CustomerENT();
        CustomerBAL balCustomer = new CustomerBAL();

        if (ddlProductID.SelectedIndex > 0)
        {
            DataTable dtCustomer = balCustomer.SelectProductAmount(Convert.ToInt32(ddlProductID.SelectedValue));

          if (dtCustomer != null && dtCustomer.Rows.Count > 0)
          {
              foreach (DataRow dr in dtCustomer.Rows)
              {
                  if (!dr["BottlePrice"].Equals(DBNull.Value))
                      txtAmount.Text = Convert.ToDecimal(dr["BottlePrice"]).ToString();

                  break;
              }
          }
        }
    }
    #endregion ddlProduct_SelectedIndexChanged

    #region ClearControls

    private void ClearControls()
    {
        txtCustomerName.Text = "";
        txtMobileNo.Text = "";
        txtCustomerAddress.Text = "";
        ddlBranchID.SelectedIndex = 0;
        ddlDistributorID.SelectedIndex = 0;
        ddlProductID.SelectedIndex = 0;
        txtQuantity.Text = "";
        txtAmount.Text = "";
        txtCustomerName.Focus();
    }

    #endregion ClearControls
}