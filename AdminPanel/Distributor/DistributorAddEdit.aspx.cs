using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier;
using WaterBottleSupplier.BAL;
using WaterBottleSupplier.ENT;

public partial class AdminPanel_Distributor_DistributorAddEdit : System.Web.UI.Page
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

            if (Request.QueryString["DistributorID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["DistributorID"]));
                lblPageHeader.Text = "Edit Distributor Details";
            }
            else
            {
                lblPageHeader.Text = "Add New Distributor";

            }
        }
        }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 DistributorID)
    {
            DistributorENT entDistributor = new DistributorENT();
            DistributorBAL balDistributor = new DistributorBAL();

            entDistributor = balDistributor.SelectByPK(DistributorID);

            if (!entDistributor.BranchID.IsNull)
                ddlBranchID.SelectedValue = entDistributor.BranchID.Value.ToString();

            if (!entDistributor.DistributorName.IsNull)
                txtDistributorName.Text = entDistributor.DistributorName.Value.ToString();

            if (!entDistributor.MobileNo.IsNull)
                txtMobileNo.Text = entDistributor.MobileNo.Value.ToString();

            if (!entDistributor.VehicleType.IsNull)
                txtVehicleType.Text = entDistributor.VehicleType.Value.ToString();

            if (!entDistributor.VehicleNo.IsNull)
                txtVehicleNo.Text = entDistributor.VehicleNo.Value.ToString();
    }

    #endregion LoadControls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Server Side Validation

            String strError = String.Empty;

            if (ddlBranchID.SelectedIndex == 0)
                strError += "- Select Branch<br />";

            if (txtDistributorName.Text.Trim() == String.Empty)
                strError += "- Enter Distributor Name<br />";

            if (txtMobileNo.Text.Trim() == String.Empty)
                strError += "- Enter Mobile No<br />";

            if (txtVehicleType.Text.Trim() == String.Empty)
                strError += "- Enter Vehicle Type<br />";

            if (txtVehicleNo.Text.Trim() == String.Empty)
                strError += "- Enter Vehicle No<br />";

            #endregion Server Side Validation

            DistributorENT entDistributor = new DistributorENT();
            DistributorBAL balDistributor = new DistributorBAL();
            
            #region Gather Data
            
            if (ddlBranchID.SelectedIndex > 0)
                entDistributor.BranchID = Convert.ToInt32(ddlBranchID.SelectedValue);
            
            if (txtDistributorName.Text.Trim() != String.Empty)
                entDistributor.DistributorName = txtDistributorName.Text.Trim();
            
            if (txtMobileNo.Text.Trim() != String.Empty)
                entDistributor.MobileNo = txtMobileNo.Text.Trim();
            
            if (txtVehicleType.Text.Trim() != String.Empty)
                entDistributor.VehicleType = txtVehicleType.Text.Trim();
            
            if (txtVehicleNo.Text.Trim() != String.Empty)
                entDistributor.VehicleNo = txtVehicleNo.Text.Trim();
            
            entDistributor.UserID = Convert.ToInt32(Session["UserID"]);
            
            if (Request.QueryString["DistributorID"] == null)
            {
                balDistributor.Insert(entDistributor);
                lblMessage.Text = "Data Inserted Successfully";
                ClearControls();
            }
            else
            {
                entDistributor.DistributorID = Convert.ToInt32(Request.QueryString["DistributorID"]);
                balDistributor.Update(entDistributor);
                Response.Redirect("~/AdminPanel/Distributor/DistributorList.aspx");
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
    }

    #endregion FillDropDownList

    #region ClearControls

    private void ClearControls()
    {
        ddlBranchID.SelectedIndex = 0;
        txtDistributorName.Text = "";
        txtMobileNo.Text = "";
        txtVehicleType.Text = "";
        txtVehicleNo.Text = "";
        ddlBranchID.Focus();
    }

    #endregion ClearControls
}