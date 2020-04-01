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

public partial class AdminPanel_Customer_CustomerList : System.Web.UI.Page
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
            FillCustomerGridView();
            FillDropDownList();
        }
    }
    #endregion Page_Load

    #region FillCustomerGridView

    private void FillCustomerGridView()
    {
        if (Session["UserID"] != null)
        {
            CustomerBAL balCustomer = new CustomerBAL();
            DataTable dtCustomer = balCustomer.SelectAll();
            if (dtCustomer != null && dtCustomer.Rows.Count > 0)
            {
                gvCustomer.DataSource = dtCustomer;
                gvCustomer.DataBind();
            }
        }
    }

    #endregion FillCustomerGridView

    #region gvCustomer_RowCommand
    protected void gvCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                CustomerBAL balCustomer = new CustomerBAL();
                if (balCustomer.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillCustomerGridView();
                }
                else
                {
                    lblMessage.Text = balCustomer.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }

    #endregion gvCustomer_RowCommand

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListCustomerID(ddlCustomerID);
        CommonFillMethod.FillDropDownListProductID(ddlProductID);
    }
    #endregion FillDropDownList

    #region Search Button
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Search();
    }
    #endregion Search Button

    #region FillGridViewOnSearch
    private void Search()
    {
        SqlInt32 CustomerID = SqlInt32.Null;
        SqlString MobileNo = SqlString.Null;
        SqlInt32 ProductID = SqlInt32.Null;

        if (ddlCustomerID.SelectedIndex > 0)
            CustomerID = Convert.ToInt32(ddlCustomerID.SelectedValue);

        if (txtMobileSerch.Text.Trim() != "")
            MobileNo = Convert.ToString(txtMobileSerch.Text.Trim());

        if (ddlProductID.SelectedIndex > 0)
            ProductID = Convert.ToInt32(ddlProductID.SelectedValue);

        CustomerBAL balCustomer = new CustomerBAL();
        DataTable dtCustomer = balCustomer.CustomerSelectSearch(CustomerID, MobileNo, ProductID);
        if (dtCustomer != null && dtCustomer.Rows.Count > 0)
        {
            gvCustomer.DataSource = dtCustomer;
            gvCustomer.DataBind();
        }
        else
        {
            gvCustomer.DataSource = null;
            gvCustomer.DataBind();
        }
    }
    #endregion FillGridViewOnSearch

    #region Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlCustomerID.SelectedValue = "-1";
        txtMobileSerch.Text = "";
        ddlProductID.SelectedValue = "-1";
    }
    #endregion Clear
}