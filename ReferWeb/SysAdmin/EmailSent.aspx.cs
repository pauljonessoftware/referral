﻿#region Namespace References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class SysAdmin_Template : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string messageType = Request.QueryString["MessageType"];
            lblPageTitle.Text = messageType;
        }
    }
}