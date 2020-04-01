using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel : System.Web.UI.MasterPage
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
        }
        if (Session["UserName"] != null)
        {
            lblUserSession.Text = "Hi... " + Session["UserName"].ToString();
        }
    }
    #endregion Load Event

    #region button:logout
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Login.aspx");
    }
    #endregion button:logout
}
