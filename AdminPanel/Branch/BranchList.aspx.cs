using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier.BAL;
using WaterBottleSupplier.ENT;

public partial class Admin_Panel_Branch_BranchList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect(CommonVariables.LoginURL);
        }
        if (!Page.IsPostBack)
        {
            FillBranchGridView();
        }
    }
    #endregion Load Event

    #region FillBranchGridView
    private void FillBranchGridView()
    {
        if (Session["UserID"] != null)
        {
            BranchBAL balBranch = new BranchBAL();
            DataTable dtBranch = balBranch.SelectAll();
            if (dtBranch != null && dtBranch.Rows.Count > 0)
            {
                gvBranch.DataSource = dtBranch;
                gvBranch.DataBind();
            }
        }
    }
    #endregion FillBranchGridView

    #region gvBranch_RowCommand
    protected void gvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            try
            {
                BranchBAL balBranch = new BranchBAL();
                if (balBranch.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillBranchGridView();
                }
                else
                {
                    lblMessage.Text = balBranch.Message;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
            }
        }
    }

    #endregion gvBranch_RowCommand
}