#region Namespace References
using ReferralMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
#endregion

public partial class SysAdmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        Business business = new Business(Utility.ConnectionString());

        bool isLoggedIn = business.Login(email, password);

        Session["IsLoggedIn"] = isLoggedIn;

        Response.Redirect("Switchboard.aspx");
    }
}