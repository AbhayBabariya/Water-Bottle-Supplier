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

public partial class AdminPanel_RegularOrder_RegularOrderList : System.Web.UI.Page
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
            FillRegularOrderGridView();
            FillDropDownList();
        }
    }
    #endregion Page_Load

    #region FillRegularOrderGridView

    private void FillRegularOrderGridView()
    {
        if (Session["UserID"] != null)
        {
            RegularOrderBAL balRegularOrder = new RegularOrderBAL();
            DataTable dtRegularOrder = balRegularOrder.SelectAll();
            if (dtRegularOrder != null && dtRegularOrder.Rows.Count > 0)
            {
                gvRegularOrder.DataSource = dtRegularOrder;
                gvRegularOrder.DataBind();
            }
        }
    }

    #endregion FillRegularOrderGridView

    #region gvRegularOrder_RowCommand
    protected void gvRegularOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                RegularOrderBAL balRegularOrder = new RegularOrderBAL();
                if (balRegularOrder.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillRegularOrderGridView();
                }
                else
                {
                    lblMessage.Text = balRegularOrder.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }

    #endregion gvRegularOrder_RowCommand

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListBranchID(ddlBranchID);
        CommonFillMethod.FillDropDownListCustomerID(ddlCustomerID);
        CommonFillMethod.FillDropDownListDistributorID(ddlDistributorID);
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
        SqlInt32 BranchID = SqlInt32.Null;
        SqlInt32 CustomerID = SqlInt32.Null;
        SqlInt32 DistributorID = SqlInt32.Null;
        SqlInt32 ProductID = SqlInt32.Null;
        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;

        RegularOrderENT entRegularOrder = new RegularOrderENT();
        if (ddlBranchID.SelectedIndex > 0)
            entRegularOrder.BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);

        if (ddlCustomerID.SelectedIndex > 0)
            entRegularOrder.CustomerID = Convert.ToInt32(ddlCustomerID.SelectedValue);

        if (ddlDistributorID.SelectedIndex > 0)
            entRegularOrder.DistributorID= Convert.ToInt32(ddlDistributorID.SelectedValue);

        if (ddlProductID.SelectedIndex > 0)
            entRegularOrder.ProductID = Convert.ToInt32(ddlProductID.SelectedValue);

        if (txtfromdate.Text.Trim() != "")
            entRegularOrder.FromDate = DateTime.Parse(txtfromdate.Text.Trim());

        if (txttodate.Text.Trim() != "")
            entRegularOrder.ToDate = DateTime.Parse(txttodate.Text.Trim());

        RegularOrderBAL balRegularOrder = new RegularOrderBAL();
        DataTable dtRegularOrder = balRegularOrder.RegularOrderSelectSearch(entRegularOrder);
        if (dtRegularOrder != null && dtRegularOrder.Rows.Count > 0)
        {
            gvRegularOrder.DataSource = dtRegularOrder;
            gvRegularOrder.DataBind();
        }
        else
        {
            gvRegularOrder.DataSource = null;
            gvRegularOrder.DataBind();
        }
    }
    #endregion FillGridViewOnSearch

    #region Clear Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlBranchID.SelectedValue = "-1";
        ddlCustomerID.SelectedValue = "-1";
        ddlDistributorID.SelectedValue = "-1";
        ddlProductID.SelectedValue = "-1";
        txtfromdate.Text = "";
        txttodate.Text = "";
        Search();
    }
    #endregion Clear Button

}