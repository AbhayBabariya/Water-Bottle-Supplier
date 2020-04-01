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

public partial class AdminPanel_Distributor_DistributorList : System.Web.UI.Page
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
            FillDistributorGridView();
            FillDropDownList();
        }
    }
    #endregion Page_Load

    #region FillDistributorGridView

    private void FillDistributorGridView()
    {
        if (Session["UserID"] != null)
        {
            DistributorBAL balDistributor = new DistributorBAL();
            DataTable dtDistributor = balDistributor.SelectAll();
            if (dtDistributor != null && dtDistributor.Rows.Count > 0)
            {
                gvDistributor.DataSource = dtDistributor;
                gvDistributor.DataBind();
            }
        }
    }

    #endregion FillDistributorGridView

    #region gvDistributor_RowCommand
    protected void gvDistributor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                DistributorBAL balDistributor = new DistributorBAL();
                if (balDistributor.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillDistributorGridView();
                }
                else
                {
                    lblMessage.Text = balDistributor.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }

    #endregion gvDistributor_RowCommand

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListDistributorID(ddlDistributorID);
        CommonFillMethod.FillDropDownListBranchID(ddlBranchID);
    }
    #endregion FillDropDownList

    #region Search
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Search();
    }
    #endregion Search

    #region FillGridViewOnSearch
    private void Search()
    {
        SqlInt32 DistributorID = SqlInt32.Null;
        SqlString MobileNo = SqlString.Null;
        SqlInt32 BranchID = SqlInt32.Null;

        if (ddlDistributorID.SelectedIndex > 0)
            DistributorID = Convert.ToInt32(ddlDistributorID.SelectedValue);

        if (ddlBranchID.SelectedIndex > 0)
            BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);

        if (txtMobileSearch.Text.Trim() != "")
            MobileNo = Convert.ToString(txtMobileSearch.Text.Trim());

        DistributorBAL balDistributor = new DistributorBAL();
        DataTable dtDistributor = balDistributor.DistributorSelectSearch(DistributorID, BranchID, MobileNo);
        if (dtDistributor != null && dtDistributor.Rows.Count > 0)
        {
            gvDistributor.DataSource = dtDistributor;
            gvDistributor.DataBind();
        }
        else
        {
            gvDistributor.DataSource = null;
            gvDistributor.DataBind();
        }
    }
    #endregion FillGridViewOnSearch

    #region Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlDistributorID.SelectedValue = "-1";
        txtMobileSearch.Text = "";
        ddlBranchID.SelectedValue = "-1";
        Search();
    }
    #endregion Clear
}