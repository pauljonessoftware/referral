#region Namespace References
using ReferralMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion

public partial class SysAdmin_RecruiterList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
        Business business = new Business(Utility.ConnectionString());
        DataTable dt = business.GetRecruiters();
        grdRecruiters.DataSource = dt;
        grdRecruiters.DataBind();
    }

    protected void grdRecruiters_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        Business business = new Business(Utility.ConnectionString());

        if (row.RowType == DataControlRowType.DataRow)
        {
            Label lblMiddleInitial = (Label)row.FindControl("lblMiddleInitial");
            Label lblMiddleInitialId = (Label)row.FindControl("lblMiddleInitialId");
            int id = int.Parse(lblMiddleInitialId.Text);
            lblMiddleInitial.Text = business.GetMiddleInitial(id);

            Label lblSuffix = (Label)row.FindControl("lblSuffix");
            Label lblSuffixId = (Label)row.FindControl("lblSuffixId");
            int suffixId = int.Parse(lblSuffixId.Text);
            lblSuffix.Text = business.GetSuffix(suffixId);
        }
    }

    protected void btnReferCandidate_Click(object sender, EventArgs e)
    {
        GridView grd = grdRecruiters;
        List<int> lstRecruiterId = new List<int>();
        int Id = 0;
        double amount = double.Parse(txtAmount.Text);
        string rate = ddlRate.SelectedValue;

        foreach (GridViewRow row in grd.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRecruiter = (CheckBox)row.FindControl("chkRecruiter");
                if (chkRecruiter.Checked)
                {
                    Label lbl = (Label)row.FindControl("lblRecruiterId");
                    Id = int.Parse(lbl.Text);
                    lstRecruiterId.Add(Id);
                }
            }
        }

        SendEmail(lstRecruiterId, amount, rate);
        Response.Redirect("EmailSent.aspx?MessageType=Referral");
    }

    private void SendEmail(List<int> lstRecruiterIds, double amount, string rate)
    {
        string name = string.Empty;
        string fileType = string.Empty;
        byte[] data = null;

        string from = ConfigurationManager.AppSettings["From"];
        string subject = ConfigurationManager.AppSettings["ReferralSubject"];
        Business business = new Business(Utility.ConnectionString());
        int Id = (int)Session["UserId"];

        // Move this code to Recruiterlist page
        DataTable dtCandidate = business.GetCandidate(Id);
        DataTable file = business.GetFile(Id);

        if (file.Rows.Count > 0)
        {
            DataRow row = file.Rows[0];

            name = row["Name"].ToString();
            fileType = row["FileType"].ToString();
            data = (byte[])row["Data"];

            business.SendMessageWithAttachment(lstRecruiterIds, dtCandidate, from, subject, data, name, fileType, amount);

            Response.Redirect("EmailSent.aspx?MessageType=Referral Acknowledgement");
        }
    }
}