using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WaterBottleSupplier.BAL;
using WaterBottleSupplier.ENT;

public partial class SignUp : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load Event

    #region SignUp Button
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            MasterUserENT entMasterUser = new MasterUserENT();
            MasterUserBAL balMasterUser = new MasterUserBAL();

            #region Server Side Validation

            String strError = String.Empty;

            if (txtUserName.Text.Trim() == String.Empty)
                strError += "- Enter User Name<br />";

            if (txtMobileNo.Text.Trim() == String.Empty)
                strError += "- Enter Mobile No<br />";

            if (txtEmailId.Text.Trim() == String.Empty)
                strError += "- Enter EmailId<br />";

            if (txtPassword.Text.Trim() == String.Empty)
                strError += "- Enter Password<br />";

            #endregion Server Side Validation

            #region Gather Data

            if (txtUserName.Text.Trim() != String.Empty)
                entMasterUser.UserName = txtUserName.Text.Trim();

            if (txtMobileNo.Text.Trim() != String.Empty)
                entMasterUser.MobileNo = txtMobileNo.Text.Trim();

            if (txtEmailId.Text.Trim() != String.Empty)
                entMasterUser.EmailID = txtEmailId.Text.Trim();

            if (txtPassword.Text.Trim() != String.Empty)
                entMasterUser.Password = txtPassword.Text.Trim();

            #endregion Gather Data

            #region Insert User
            if (balMasterUser.Insert(entMasterUser))
            {
                lblError.Text = "Sign Up Successfully";
            }
            #endregion Insert User
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
        }
    }
    #endregion SignUp Button
}