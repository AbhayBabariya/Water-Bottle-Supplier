using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier.BAL;
using WaterBottleSupplier.DAL;
using WaterBottleSupplier.ENT;

public partial class Admin_Panel_Branch_BranchAddEdit : System.Web.UI.Page
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

            if (Request.QueryString["BranchID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["BranchID"]));
                lblPageHeader.Text = "Edit Branch Details";
            }
            else
            {
                lblPageHeader.Text = "Add New Branch";

            }

        }
    }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 BranchID)
    {
            BranchENT entBranch = new BranchENT();
            BranchBAL balBranch = new BranchBAL();

            entBranch = balBranch.SelectByPK(BranchID);

            if (!entBranch.BranchName.IsNull)
                txtBranchName.Text = entBranch.BranchName.Value.ToString();

            if (!entBranch.MobileNo.IsNull)
                txtMobileNo.Text = entBranch.MobileNo.Value.ToString();

            if (!entBranch.Address.IsNull)
                txtBranchAddress.Text = entBranch.Address.Value.ToString();

            if (!entBranch.ManagerName.IsNull)
                txtManagerName.Text = entBranch.ManagerName.Value.ToString();

            if (!entBranch.ManagerMobileNo.IsNull)
                txtManagerMobileNo.Text = entBranch.ManagerMobileNo.Value.ToString();
    }

    #endregion LoadControls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Server Side Validation

            String strError = String.Empty;

            if (txtBranchName.Text.Trim() == String.Empty)
                strError += "- Enter Branch Name<br />";

            if (txtMobileNo.Text.Trim() == String.Empty)
                strError += "- Enter Mobile No<br />";

            if (txtBranchAddress.Text.Trim() == String.Empty)
                strError += "- Enter Branch Address<br />";

            if (txtManagerName.Text.Trim() == String.Empty)
                strError += "- Enter Manager Name<br />";

            if (txtManagerMobileNo.Text.Trim() == String.Empty)
                strError += "- Enter Manager MobileNo<br />";

            #endregion Server Side Validation

            
            BranchENT entBranch = new BranchENT();
            BranchBAL balBranch = new BranchBAL();

            #region Gather Data

            if (txtBranchName.Text.Trim() != String.Empty)
                entBranch.BranchName = txtBranchName.Text.Trim();

            if (txtMobileNo.Text.Trim() != String.Empty)
                entBranch.MobileNo = txtMobileNo.Text.Trim();

            if (txtBranchAddress.Text.Trim() != String.Empty)
                entBranch.Address = txtBranchAddress.Text.Trim();

            if (txtManagerName.Text.Trim() != String.Empty)
                entBranch.ManagerName = txtManagerName.Text.Trim();

            if (txtManagerMobileNo.Text.Trim() != String.Empty)
                entBranch.ManagerMobileNo = txtManagerMobileNo.Text.Trim();

            entBranch.UserID = Convert.ToInt32(Session["UserID"]);

            if (Request.QueryString["BranchID"] == null)
            {
                balBranch.Insert(entBranch);
                lblMessage.Text = "Data Inserted Successfully";
                ClearControls();
            }
            else
            {
                entBranch.BranchID = Convert.ToInt32(Request.QueryString["BranchID"]);
                balBranch.Update(entBranch);
                Response.Redirect("~/AdminPanel/Branch/BranchList.aspx");
            }

            #endregion Gather Data
            
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.Message.ToString();
        }
    }
    #endregion Button : Save

    #region ClearControls

    private void ClearControls()
    {
        txtBranchName.Text = "";
        txtMobileNo.Text = "";
        txtBranchAddress.Text = "";
        txtManagerName.Text = "";
        txtManagerMobileNo.Text = "";
        txtBranchName.Focus();
    }

    #endregion ClearControls
}