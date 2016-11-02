using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysAdmin_NoticeTemplate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string experience = "10 years";
            string title = "SQL Server DBA";
            string location = "Columbia, SC; Charlotte, NC";

            string body = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\">";
            body += "<head><title>Resource Availability Notice</title><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\">";
            body += "</head><body><table style=\"border-collapse:collapse; margin:3px; padding:3px; width:720px;\"><tr><td>";
            body += "Dear Recruiter,<br><br>";
            body += "Clearasoft Technology Solutions, LLC has identified a highly qualified " + title + " with " + experience + " ";
            body += "experience. He/she is looking for an exciting and challenging new opportunity in the " + location + " area. ";
            body += "If you are interested in this lead, please contact us at your earliest convenience. The referral fee is <span style=\"color:#C36900; text-decoration:underline;\">10% negotiable</span>. ";
            body += "<br><br>Regards,<p>&nbsp;</p>";
            body += "<div style=\"color:#C36900; font-size:18pt; font-weight:bold; font-family:Segoe Script, Verdana, Sans-Serif;\">Paul A. Jones, Jr.</div>";
            body += "<div style=\"color:#909090; font-size:12pt;\">President &amp; Founder</div>";
            body += "<div>Clearasoft Technology Solutions, LLC</div>";
            body += "<div><a href=\"mailto:pauljonessoftware@gmail.com\">clearasoftware@gmail.com</a></div>";
            body += "<div>Mobile: (803) 873-6472</div>";
            body += "<div>Twitter: @clearasoftware</div></td></tr></table></body></html>";

            divHtml.InnerHtml = body;
        }
    }
}