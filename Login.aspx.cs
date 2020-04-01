using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier.BAL;

public partial class LogIn : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();
        if (!Page.IsPostBack)
        {
            Session.Clear();
            this.Page.Title = "Login - Water Bottle Supplier";
        }
    }
    #endregion Page Load Event

    #region Store Data in Session
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        MasterUserBAL balMasterUser = new MasterUserBAL();
        DataTable dtMasterUser = balMasterUser.SelectByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.ToString());
        if (dtMasterUser != null && dtMasterUser.Rows.Count > 0)
        {
            foreach (DataRow drow in dtMasterUser.Rows)
            {
                if (!drow["UserID"].Equals(System.DBNull.Value))
                    Session["UserID"] = drow["UserID"].ToString();

                if (!drow["UserName"].Equals(System.DBNull.Value))
                    Session["UserName"] = drow["UserName"].ToString();
            }
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid Username or Password";
            lblMessage.ForeColor = System.Drawing.Color.Red;

            txtPassword.Focus();
        }
    }
    #endregion Store Data in Session
}