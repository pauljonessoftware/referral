using ReferralMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysAdmin_Candidates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMiddleInitialDDL();
            BindSuffixDDL();
            BindGetExperienceDDL();
            BindGridView();
        }
    }

    private void BindGridView()
    {
        Business business = new Business(Utility.ConnectionString());
        DataTable dt = business.GetCandidates();
        grdCandidates.DataSource = dt;
        grdCandidates.DataBind();
    }

    private void BindGetExperienceDDL()
    {
        Business business = new Business(Utility.ConnectionString());

        ddlExperience.DataTextField = "YearsExperience";
        ddlExperience.DataValueField = "Id";
        ddlExperience.DataSource = business.GetYearsExperience();
        ddlExperience.DataBind();
    }

    private void BindMiddleInitialDDL()
    {
        Business business = new Business(Utility.ConnectionString());

        ddlMiddleInitial.DataTextField = "MiddleInitial";
        ddlMiddleInitial.DataValueField = "Id";
        ddlMiddleInitial.DataSource = business.GetMiddleInitials();
        ddlMiddleInitial.DataBind();
    }

    private void BindMiddleInitialDDL(DropDownList ddl)
    {
        Business business = new Business(Utility.ConnectionString());

        ddl.DataTextField = "MiddleInitial";
        ddl.DataValueField = "Id";
        ddl.DataSource = business.GetMiddleInitials();
        ddl.DataBind();
    }

    private void BindSuffixDDL()
    {
        Business business = new Business(Utility.ConnectionString());

        ddlSuffix.DataTextField = "Suffix";
        ddlSuffix.DataValueField = "Id";
        ddlSuffix.DataSource = business.GetSuffixes();
        ddlSuffix.DataBind();
    }

    private void BindSuffixDDL(DropDownList ddl)
    {
        Business business = new Business(Utility.ConnectionString());

        ddl.DataTextField = "Suffix";
        ddl.DataValueField = "Id";
        ddl.DataSource = business.GetSuffixes();
        ddl.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Business business = new Business(Utility.ConnectionString());

        int userTypeId = Int32.Parse(hdnUserType.Value);
        string firstName = txtFirstName.Text;
        int middleInitialId = int.Parse(ddlMiddleInitial.SelectedValue);
        string lastName = txtLastName.Text;
        int suffixId = int.Parse(ddlSuffix.SelectedValue);
        string email = txtEmail.Text;
        string password = txtPassword.Text;
        string number = txtPhone.Text;
        int numberTypeId = int.Parse(hdnNumberTypeId.Value);
        string jobTitle = txtJobTitle.Text;
        int experienceId = int.Parse(ddlExperience.SelectedValue);
        string location = txtLocation.Text;
        string comments = txtComments.Text;
        DataTable Files = null;

        if (Session["Files"] != null)
        {
            Files = (DataTable)Session["Files"];
        }

        int UserId = business.AddCandidate(userTypeId, firstName, middleInitialId, lastName, suffixId, email,
            password, number, numberTypeId, jobTitle, experienceId, location, Files);

        Files = null;
        Session["Files"] = null;

        Response.Redirect("Candidates.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Business business = new Business(Utility.ConnectionString());
        DataTable dt = business.GetFilesTable();

        string FileType = string.Empty;

        if (fileUploadControl.HasFile)
        {
            try
            {
                long fileSize = fileUploadControl.FileContent.Length;

                // limit file upload size to 100K
                if (fileSize < 100000)
                {
                    // file name
                    string Name = Path.GetFileName(fileUploadControl.FileName);

                    // file data
                    byte[] Data = fileUploadControl.FileBytes;

                    // file extension
                    string extension = Name.Substring(Name.LastIndexOf(".") + 1);

                    switch (extension)
                    {
                        case "doc":
                            FileType = "application/vnd.ms-word";
                            break;
                        case "docx":
                            FileType = "application/vnd.ms-word";
                            break;
                        case "xls":
                            FileType = "application/vnd.ms-excel";
                            break;
                        case "xlsx":
                            FileType = "application/vnd.ms-excel";
                            break;
                        case "pdf":
                            FileType = "application/pdf";
                            break;
                        default:
                            lblStatus.Text = "ERROR: Invalid file type. Resume uploads are limited to Word, Excel and PDFs.";
                            break;
                    }

                    DataRow row = dt.Rows[0];
                    row["Name"] = Name;
                    row["FileType"] = FileType;
                    row["Data"] = Data;

                    Session["Files"] = dt;

                    lblStatus.Text = Name + " uploaded";
                    lblStatus.Visible = true;
                }
                else
                {
                    lblStatus.Text = "ERROR: The file is too large. Resume uploads are limited to 100K bytes.";
                    lblStatus.Visible = true;
                }
            }
            catch (Exception exc)
            {
                lblStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + exc.Message;
                lblStatus.Visible = true;
            }
        }
    }

    protected void btnAddAndCAN_Click(object sender, EventArgs e)
    {

    }

    protected void grdCandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        int middleInitialId = 0;
        int suffixId = 0;

        if (row.RowType == DataControlRowType.DataRow)
        {
            Label lblMiddleInitialId = (Label)row.FindControl("lblMiddleInitialId");
            if (lblMiddleInitialId.Text.Length > 0)
            {
                middleInitialId = int.Parse(lblMiddleInitialId.Text);
            }
            DropDownList ddlMiddleInitial = (DropDownList)row.FindControl("ddlMiddleInitial");
            BindMiddleInitialDDL(ddlMiddleInitial);


            Label lblSuffixId = (Label)row.FindControl("lblSuffixId");
            if (lblSuffixId.Text.Length > 0)
            {
                suffixId = int.Parse(lblSuffixId.Text);
            }
            DropDownList ddlSuffix = (DropDownList)row.FindControl("ddlSuffix");
            BindSuffixDDL(ddlSuffix);
        }
    }

    protected void grdCandidates_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
        grdCandidates.EditIndex = index;
        BindGridView();
    }

    protected void grdCandidates_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdCandidates.EditIndex = -1;
        BindGridView();
    }

    protected void grdCandidates_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

}