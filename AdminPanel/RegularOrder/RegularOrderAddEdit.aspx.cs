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

public partial class AdminPanel_RegularOrder_RegularOrderAddEdit : System.Web.UI.Page
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

            if (Request.QueryString["RegularOrderID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["RegularOrderID"]));
                CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));
                lblPageHeader.Text = "Edit RegularOrder Details";
            }
            else
            {
                lblPageHeader.Text = "Add New RegularOrder";

            }
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 RegularOrderID)
    {
            RegularOrderENT entRegularOrder = new RegularOrderENT();
            RegularOrderBAL balRegularOrder = new RegularOrderBAL();

            entRegularOrder = balRegularOrder.SelectByPK(RegularOrderID);

            if (!entRegularOrder.CustomerID.IsNull)
                ddlCustomerID.SelectedValue = entRegularOrder.CustomerID.Value.ToString();

            if (!entRegularOrder.BranchID.IsNull)
                ddlBranchID.SelectedValue = entRegularOrder.BranchID.Value.ToString();

            if (!entRegularOrder.DistributorID.IsNull)
                ddlDistributorID.SelectedValue = entRegularOrder.DistributorID.Value.ToString();

            if (!entRegularOrder.ProductID.IsNull)
                ddlProductID.SelectedValue = entRegularOrder.ProductID.Value.ToString();

            if (!entRegularOrder.Quantity.IsNull)
                txtQuantity.Text = entRegularOrder.Quantity.Value.ToString();

            if (ddlProductID.SelectedIndex > 0)
                ProductAutoSelect();

            if (!entRegularOrder.TotalAmount.IsNull)
                txtTotalAmount.Text = entRegularOrder.TotalAmount.Value.ToString();

            if (!entRegularOrder.BottleIn.IsNull)
                txtBottleIn.Text = entRegularOrder.BottleIn.Value.ToString();

            if (!entRegularOrder.OrderDate.IsNull)
                txtOrderDate.Text = entRegularOrder.OrderDate.Value.ToString("yyyy-MM-dd");
            
    }

    #endregion LoadControls

    #region Auto Sum Function
    private void BottleAmount_TextChanged()
    {
        decimal Amount;
        if (txtQuantity.Text != "")
        {
            Amount = Convert.ToDecimal(txtAmount.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim());
            txtTotalAmount.Text = Amount.ToString();
        }
    }
    private void Quantity_TextChanged()
    {
        decimal Amount;
        if (txtAmount.Text != "")
        {
            Amount = Convert.ToDecimal(txtAmount.Text.Trim()) * Convert.ToDecimal(txtQuantity.Text.Trim());
            txtTotalAmount.Text = Amount.ToString();
        }
    }
    #endregion Auto Sum Function

    #region Sum and Multiplay Amount
    protected void txtBottleAmount_TextChanged(object sender, EventArgs e)
        {
            BottleAmount_TextChanged();
        }
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Quantity_TextChanged();
        }
    #endregion

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Server Side Validation

            String strError = String.Empty;

            if (ddlCustomerID.SelectedIndex == 0)
                strError += "- Select Customer Name<br />";

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

            if (txtBottleIn.Text.Trim() == String.Empty)
                strError += "- Enter In Bottle<br />";

            if (txtOrderDate.Text.Trim() == String.Empty)
                strError += "- Enter Order Date<br />";

            #endregion Server Side Validation

            
                RegularOrderENT entRegularOrder = new RegularOrderENT();
                RegularOrderBAL balRegularOrder = new RegularOrderBAL();

                #region Gather Data

                if (ddlCustomerID.SelectedIndex > 0)
                    entRegularOrder.CustomerID = Convert.ToInt32(ddlCustomerID.SelectedValue);

                if (ddlBranchID.SelectedIndex > 0)
                    entRegularOrder.BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);

                if (ddlDistributorID.SelectedIndex > 0)
                    entRegularOrder.DistributorID = Convert.ToInt32(ddlDistributorID.SelectedValue);

                if (ddlProductID.SelectedIndex > 0)
                    entRegularOrder.ProductID = Convert.ToInt32(ddlProductID.SelectedValue);

                if (txtQuantity.Text.Trim() != String.Empty)
                    entRegularOrder.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());

                if (txtTotalAmount.Text.Trim() != String.Empty)
                    entRegularOrder.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());

                if (txtOrderDate.Text.Trim() != String.Empty)
                    entRegularOrder.OrderDate = Convert.ToDateTime(txtOrderDate.Text.Trim());

                if (txtBottleIn.Text.Trim() != String.Empty)
                    entRegularOrder.BottleIn = Convert.ToInt32(txtBottleIn.Text.Trim());

                entRegularOrder.UserID = Convert.ToInt32(Session["UserID"]);

                if (Request.QueryString["RegularOrderID"] == null)
                {
                    balRegularOrder.Insert(entRegularOrder);
                    lblMessage.Text = "Data Inserted Successfully";
                    ClearControls();
                }
                else
                {
                    entRegularOrder.RegularOrderID = Convert.ToInt32(Request.QueryString["RegularOrderID"]);
                    balRegularOrder.Update(entRegularOrder);
                    Response.Redirect("~/AdminPanel/RegularOrder/RegularOrderList.aspx");
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
        CommonFillMethod.FillDropDownListCustomerID(ddlCustomerID);
        CommonFillMethod.FillDropDownListBranchID(ddlBranchID);
        CommonFillMethod.FillDropDownListProductID(ddlProductID);
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));
    }
    #endregion FillDropDownList

    #region ddlCustomer_SelectedIndexChanged
    public void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        RegularOrderENT entRegularOrder = new RegularOrderENT();
        RegularOrderBAL balRegularOrder = new RegularOrderBAL();

        if (ddlCustomerID.SelectedIndex > 0)
        {
            DataTable dt = balRegularOrder.FillCustomer(Convert.ToInt32(ddlCustomerID.SelectedValue));

            if (dt != null && dt.Rows.Count > 0)
            {   
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr["BranchID"].Equals(DBNull.Value))
                        ddlBranchID.SelectedValue = Convert.ToInt32(dr["BranchID"]).ToString();

                    CommonFillMethod.FillDropDownListBranchToDistributor(ddlDistributorID, Convert.ToInt32(ddlBranchID.SelectedValue));

                    if (!dr["ProductID"].Equals(DBNull.Value))
                        ddlProductID.SelectedValue = Convert.ToInt32(dr["ProductID"]).ToString();

                    if (!dr["Quantity"].Equals(DBNull.Value))
                        txtQuantity.Text = Convert.ToInt32(dr["Quantity"]).ToString();

                    ProductAutoSelect();
                    BottleAmount_TextChanged();
                    Quantity_TextChanged();
                }
            }
        }
    }
    #endregion ddlCustomer_SelectedIndexChanged

    #region ddlProduct_SelectedIndexChanged
    public void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProductAutoSelect();
    }
    #endregion ddlProduct_SelectedIndexChanged

    #region Product Auto Select Function
    private void ProductAutoSelect()
    {
        try
        {
            RegularOrderENT entRegularOrder = new RegularOrderENT();
            RegularOrderBAL balRegularOrder = new RegularOrderBAL();

            if (ddlProductID.SelectedIndex > 0)
            {

                DataTable dt = balRegularOrder.SelectProductAmount(Convert.ToInt32(ddlProductID.SelectedValue));

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!dr["BottlePrice"].Equals(DBNull.Value))
                        {
                            txtAmount.Text = Convert.ToDecimal(dr["BottlePrice"]).ToString();
                            txtAmount.Enabled = false;
                        }
                        BottleAmount_TextChanged();
                        Quantity_TextChanged();

                        break;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message.ToString();
        }
    }
    #endregion Product Auto Select Function

    #region ClearControls
    private void ClearControls()
    {
        ddlCustomerID.SelectedIndex = 0;
        ddlBranchID.SelectedIndex = 0;
        ddlDistributorID.SelectedIndex = 0;
        ddlProductID.SelectedIndex = 0;
        txtQuantity.Text = "";
        txtTotalAmount.Text = "";
        txtOrderDate.Text = "";
        txtBottleIn.Text = "";
        ddlCustomerID.Focus();
    }

    #endregion ClearControls
}