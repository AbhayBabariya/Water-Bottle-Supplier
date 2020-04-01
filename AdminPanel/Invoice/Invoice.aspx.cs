using Microsoft.Reporting.WebForms;
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

public partial class AdminPanel_Invoice_Invoice : System.Web.UI.Page
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
        }
    }
    #endregion Page_Load

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListCustomerID(ddlCustomerID);
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
        RegularOrderENT entRegularOrder = new RegularOrderENT();
        RegularOrderBAL balRegularOrder = new RegularOrderBAL();

        if (ddlCustomerID.SelectedIndex > 0)
            entRegularOrder.CustomerID = Convert.ToInt32(ddlCustomerID.SelectedValue);

        if (txtfromdate.Text.Trim() != String.Empty)
            entRegularOrder.FromDate = Convert.ToDateTime(txtfromdate.Text.Trim());

        if (txttodate.Text.Trim() != String.Empty)
            entRegularOrder.ToDate = Convert.ToDateTime(txttodate.Text.Trim());

        DataTable dtInvoice = balRegularOrder.RegularOrderSelectCustomerWiseSearchInvoice(entRegularOrder);

        rvInvoice.LocalReport.DataSources.Add(new ReportDataSource("RegularOrderSelectCustomerWiseSearchInvoice", dtInvoice));
        rvInvoice.LocalReport.ReportPath = Server.MapPath("~/AdminPanel/Invoice/Report.rdlc");
        rvInvoice.LocalReport.DisplayName = ddlCustomerID.SelectedItem.Text + " Invoice Sheet";
    }
    #endregion FillGridViewOnSearch

    #region Clear Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlCustomerID.SelectedValue = "-1";
        txtfromdate.Text = "";
        txttodate.Text = "";
        Search();
    }
    #endregion Clear Button
}