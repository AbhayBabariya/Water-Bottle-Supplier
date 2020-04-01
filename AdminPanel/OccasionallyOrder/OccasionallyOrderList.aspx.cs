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

public partial class AdminPanel_OccasionallyOrder_OccasionallyOrderList : System.Web.UI.Page
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
            FillOccasionallyOrderGridView();
            FillDropDownList();
        }
    }
    #endregion Page_Load

    #region FillOccasionallyOrderGridView

    private void FillOccasionallyOrderGridView()
    {
        if (Session["UserID"] != null)
        {
            OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();
            DataTable dtOccasionallyOrder = balOccasionallyOrder.SelectAll();
            if (dtOccasionallyOrder != null && dtOccasionallyOrder.Rows.Count > 0)
            {
                gvOccasionallyOrder.DataSource = dtOccasionallyOrder;
                gvOccasionallyOrder.DataBind();
            }
        }
    }

    #endregion FillOccasionallyOrderGridView

    #region gvOccasionallyOrder_RowCommand
    protected void gvOccasionallyOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();
                if (balOccasionallyOrder.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillOccasionallyOrderGridView();
                }
                else
                {
                    lblMessage.Text = balOccasionallyOrder.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }

    #endregion gvOccasionallyOrder_RowCommand

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListBranchID(ddlBranchID);
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
        SqlString CustomerName = SqlString.Null;
        SqlInt32 DistributorID = SqlInt32.Null;
        SqlInt32 ProductID = SqlInt32.Null;
        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;


        if (ddlBranchID.SelectedIndex > 0)
            BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);

        if (ddlCustomerID.Text.Trim() != "")
            CustomerName = Convert.ToString(ddlCustomerID.Text.Trim());

        if (ddlDistributorID.SelectedIndex > 0)
            DistributorID = Convert.ToInt32(ddlDistributorID.SelectedValue);

        if (ddlProductID.SelectedIndex > 0)
            ProductID = Convert.ToInt32(ddlProductID.SelectedValue);

        if (txtfromdate.Text.Trim() != "")
            FromDate = DateTime.Parse(txtfromdate.Text.Trim());

        if (txttodate.Text.Trim() != "")
            ToDate = DateTime.Parse(txttodate.Text.Trim());

        OccasionallyOrderBAL balOccasionallyOrder = new OccasionallyOrderBAL();
        DataTable dtOccasionallyOrder = balOccasionallyOrder.OccasionallyOrderSelectSearch(BranchID, CustomerName, DistributorID, ProductID, FromDate, ToDate);
        if (dtOccasionallyOrder != null && dtOccasionallyOrder.Rows.Count > 0)
        {
            gvOccasionallyOrder.DataSource = dtOccasionallyOrder;
            gvOccasionallyOrder.DataBind();
        }
        else
        {
            gvOccasionallyOrder.DataSource = null;
            gvOccasionallyOrder.DataBind();
        }
    }
    #endregion FillGridViewOnSearch

    #region Cancle Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlBranchID.SelectedValue = "-1";
        ddlCustomerID.Text = "";
        ddlDistributorID.SelectedValue = "-1";
        ddlProductID.SelectedValue = "-1";
        txtfromdate.Text = "";
        txttodate.Text = "";
        Search();
    }
    #endregion Cancle Button

}