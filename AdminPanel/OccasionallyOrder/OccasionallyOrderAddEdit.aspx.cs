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

public partial class AdminPanel_OccasionallyOrder_OccasionallyOrderAddEdit : System.Web.UI.Page
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

            if (Request.QueryString["OccasionallyOrderID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["OccasionallyOrderID"]));
                CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));
                lblPageHeader.Text = "Edit OccasionallyOrder Details";
            }
            else
            {
                lblPageHeader.Text = "Add New OccasionallyOrder";

            }
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 OccasionallyOrderID)
    {
        
            OccasionallyOrderENT entOccasionallyOrder = new OccasionallyOrderENT();
            OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();

            entOccasionallyOrder = balOccasionallyOrder.SelectByPK(OccasionallyOrderID);

            if (!entOccasionallyOrder.CustomerName.IsNull)
                txtCustomerName.Text = entOccasionallyOrder.CustomerName.Value.ToString();

            if (!entOccasionallyOrder.MobileNo.IsNull)
                txtMobileNo.Text = entOccasionallyOrder.MobileNo.Value.ToString();

            if (!entOccasionallyOrder.Address.IsNull)
                txtCustomerAddress.Text = entOccasionallyOrder.Address.Value.ToString();

            if (!entOccasionallyOrder.BranchID.IsNull)
                ddlBranchID.SelectedValue = entOccasionallyOrder.BranchID.Value.ToString();

            if (!entOccasionallyOrder.DistributorID.IsNull)
                ddlDistributorID.SelectedValue = entOccasionallyOrder.DistributorID.Value.ToString();

            if (!entOccasionallyOrder.ProductID.IsNull)
                ddlProductID.SelectedValue = entOccasionallyOrder.ProductID.Value.ToString();

            if (!entOccasionallyOrder.Quantity.IsNull)
                txtQuantity.Text = entOccasionallyOrder.Quantity.Value.ToString();

            if (!entOccasionallyOrder.TotalAmount.IsNull)
                txtTotalAmount.Text = entOccasionallyOrder.TotalAmount.Value.ToString();

            if (!entOccasionallyOrder.OrderDate.IsNull)
                txtOrderDate.Text = entOccasionallyOrder.OrderDate.Value.ToString("yyyy-MM-dd");

            if (!entOccasionallyOrder.BottleIn.IsNull)
                txtBottleIn.Text = entOccasionallyOrder.BottleIn.Value.ToString();

            if (!entOccasionallyOrder.Status.IsNull)
                ckbStatus.Checked = entOccasionallyOrder.Status.Value;

    }

    #endregion LoadControls

    #region Sum and Multiplay Amount
    protected void txtBottleAmount_TextChanged(object sender, EventArgs e)
    {
        decimal Amount;
        if (txtQuantity.Text != "")
        {
            Amount = Convert.ToDecimal(txtAmount.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim());
            txtTotalAmount.Text = Amount.ToString();
        }
    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        decimal Amount;
        if (txtAmount.Text != "")
        {
            Amount = Convert.ToDecimal(txtAmount.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim());
            txtTotalAmount.Text = Amount.ToString();
        }
    }
    #endregion

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

            if (txtTotalAmount.Text.Trim() == String.Empty)
                strError += "- Enter Total Amount<br />";

            if (txtOrderDate.Text.Trim() == String.Empty)
                strError += "- Enter Order Date<br />";

            if (txtBottleIn.Text.Trim() == String.Empty)
                strError += "- Enter In Bottle<br />";

            #endregion Server Side Validation

            
                OccasionallyOrderENT entOccasionallyOrder = new OccasionallyOrderENT();
                OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();

                #region Gather Data

                if (txtCustomerName.Text.Trim() != String.Empty)
                    entOccasionallyOrder.CustomerName = txtCustomerName.Text.Trim();

                if (txtMobileNo.Text.Trim() != String.Empty)
                    entOccasionallyOrder.MobileNo = txtMobileNo.Text.Trim();

                if (txtCustomerAddress.Text.Trim() != String.Empty)
                    entOccasionallyOrder.Address = txtCustomerAddress.Text.Trim();

                if (ddlBranchID.SelectedIndex > 0)
                    entOccasionallyOrder.BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);

                if (ddlDistributorID.SelectedIndex > 0)
                    entOccasionallyOrder.DistributorID = Convert.ToInt32(ddlDistributorID.SelectedValue);

                if (ddlProductID.SelectedIndex > 0)
                    entOccasionallyOrder.ProductID = Convert.ToInt32(ddlProductID.SelectedValue);

                if (txtQuantity.Text.Trim() != String.Empty)
                    entOccasionallyOrder.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());

                if (txtTotalAmount.Text.Trim() != String.Empty)
                    entOccasionallyOrder.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());

                if (txtOrderDate.Text.Trim() != String.Empty)
                    entOccasionallyOrder.OrderDate = Convert.ToDateTime(txtOrderDate.Text.Trim());

                if (txtBottleIn.Text.Trim() != String.Empty)
                    entOccasionallyOrder.BottleIn = Convert.ToInt32(txtBottleIn.Text.Trim());

                entOccasionallyOrder.Status = Convert.ToBoolean(ckbStatus.Checked);

                entOccasionallyOrder.UserID = Convert.ToInt32(Session["UserID"]);

                if (Request.QueryString["OccasionallyOrderID"] == null)
                {
                    balOccasionallyOrder.Insert(entOccasionallyOrder);
                    lblMessage.Text = "Data Inserted Successfully";
                    ClearControls();
                }
                else
                {
                    entOccasionallyOrder.OccasionallyOrderID = Convert.ToInt32(Request.QueryString["OccasionallyOrderID"]);
                    balOccasionallyOrder.Update(entOccasionallyOrder);
                    Response.Redirect("~/AdminPanel/OccasionallyOrder/OccasionallyOrderList.aspx");
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
            DataTable dt = balCustomer.SelectProductAmount(Convert.ToInt32(ddlProductID.SelectedValue));

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr["BottlePrice"].Equals(DBNull.Value))
                        txtAmount.Text = Convert.ToDecimal(dr["BottlePrice"]).ToString();
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
        txtTotalAmount.Text = "";
        txtOrderDate.Text = "";
        txtBottleIn.Text = "";
        txtCustomerName.Focus();
    }

    #endregion ClearControls
}