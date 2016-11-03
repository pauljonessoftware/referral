#region Namespace References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReferralMS;
using System.Configuration;
using System.Data;
#endregion

public partial class SysAdmin_Recruiters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMiddleInitialDDL();
            BindSuffixDDL();
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

    private void BindSuffixDDL()
    {
        Business business = new Business(Utility.ConnectionString());

        ddlSuffix.DataTextField = "Suffix";
        ddlSuffix.DataValueField = "Id";
        ddlSuffix.DataSource = business.GetSuffixes();
        ddlSuffix.DataBind();
    }

    private void BindMiddleInitialDDL()
    {
        Business business = new Business(Utility.ConnectionString());

        ddlMiddleInitial.DataTextField = "MiddleInitial";
        ddlMiddleInitial.DataValueField = "Id";
        ddlMiddleInitial.DataSource = business.GetMiddleInitials();
        ddlMiddleInitial.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string firstName = txtFirstName.Text;
        int middleInitialId = int.Parse(ddlMiddleInitial.SelectedValue);
        string lastName = txtLastName.Text;
        int suffixId = int.Parse(ddlSuffix.SelectedValue);

        string companyName = txtCompanyName.Text;
        string url = txtURL.Text;
        string email = txtEmail.Text;
        string password = txtPassword.Text;
        string telephone = txtTelephone.Text;

        int userTypeId = int.Parse(hdnUserType.Value);
        int numberTypeId = int.Parse(hdnNumberType.Value);

        Business business = new Business(Utility.ConnectionString());
        business.AddRecruiterAccount(userTypeId, firstName, middleInitialId, lastName, suffixId, email, password, companyName, url, telephone, numberTypeId);

        Response.Redirect("Recruiters.aspx");
    }

    protected void grdRecruiters_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        Business business = new Business(Utility.ConnectionString());

        if (row.RowType == DataControlRowType.DataRow)
        {
            Label lblMiddleInitial = (Label)row.FindControl("lblMiddleInitial");
            Label lblMiddleInitialId = (Label)row.FindControl("lblMiddleInitialId");

            if (lblMiddleInitial.Text != string.Empty)
            {
                int id = int.Parse(lblMiddleInitialId.Text);
                lblMiddleInitial.Text = business.GetMiddleInitial(id);
            }

            Label lblSuffix = (Label)row.FindControl("lblSuffix");
            Label lblSuffixId = (Label)row.FindControl("lblSuffixId");

            if (lblSuffixId.Text != string.Empty)
            {
                int suffixId = int.Parse(lblSuffixId.Text);
                lblSuffix.Text = business.GetSuffix(suffixId);
            }
        }
    }
}