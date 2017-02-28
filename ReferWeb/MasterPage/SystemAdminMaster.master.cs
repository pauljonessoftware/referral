#region Namespace References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class MasterPage_SystemAdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isLoggedIn = false;

        if (!IsPostBack)
        {
            if (Session["IsLoggedIn"] != null)
            {
                isLoggedIn = (bool)Session["IsLoggedIn"];
            }

            if (isLoggedIn == false)
            {
                // redirect to login screen
                Response.Redirect("default.aspx");
            }
        }
    }

    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        if (Session["IsLoggedIn"] != null)
        {
            Session["IsLoggedIn"] = null;

            // redirect to login screen
            Response.Redirect("default.aspx");
        }

    }
}
