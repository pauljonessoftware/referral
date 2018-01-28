#region Namespace References
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReferralMS;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.Net.Mail;
#endregion

namespace TestHarness
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class UnitTests
    {
        #region Members
        Database database;
        String connectionString;
        #endregion

        #region Constructor
        [TestInitialize]
        public void Init()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Referral"].ConnectionString;
            database = new Database(connectionString);
        }
        #endregion

        #region Opportunity Tests
        [TestMethod]
        public void AddOpportunityTest()
        {
            string Title = "ASP.Net Developer";
            string Description = "C#, SQL Server, ASP.Net Webforms, ASP.Net MVC";
            double Amount = 2000.00;
            string City = "Columbia";
            int StateId = 42;
            int UserId = 1;

            Business business = new Business(connectionString);
            int id = business.AddOpportunity(Title, Description, Amount, City, StateId, UserId);

            Assert.IsTrue(id > 0, "FAIL: Invalid id");
        }

        [TestMethod]
        public void EditOpportunityTest()
        {
            int OpportunityId = 1;
            string Title = ".Net Engineer";
            string Description = ".Net Web Applications Developer; Web Services; WCF";
            double Amount = 2500.00;
            string City = "Charlotte";
            int StateId = 34;

            Business business = new Business(connectionString);
            int id = business.EditOpportunity(OpportunityId, Title, Description, Amount, City, StateId);

            Assert.IsTrue(id > 0, "FAIL: Invalid id");
        }

        [TestMethod]
        public void GetOpportunityTest()
        {
            int OpportunityId = 1;
            Business business = new Business(connectionString);

            DataTable dt = business.GetOpportunity(OpportunityId);

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: Read failed");
        }

        [TestMethod]
        public void GetOpportunitiesTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetOpportunities();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: Read failed");
        }
        #endregion

        #region User Tests
        [TestMethod]
        public void AddUserTest()
        {
            int UserTypeId = 3;     // user type
            string FirstName = "Paul";
            int MiddleInitialId = 0;
            string LastName = "Jones";
            int SuffixId = 0;

            Business business = new Business(connectionString);
            int id = business.AddUser(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId);

            Assert.IsTrue(id > 0, "FAIL: Invalid id");
        }

        [TestMethod]
        public void AddRecruiterTest()
        {
            int UserTypeId = 3;
            string FirstName = "Robert";
            int? MiddleInitialId = null;
            string LastName = "Half";
            int? SuffixId = null;
            string Username = "president@roberthalf.com";
            string Password = "rhalf!";
            string Name = "Robert Half, Inc.";
            string URL = "www.roberthalf.com";
            int UserCompanyId = 0;

            Business business = new Business(connectionString);

            // Add User
            int userId = business.AddUser(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId);

            Assert.IsTrue(userId > 0, "FAIL: Invalid id");

            // Add User account
            int businessId = business.AddAccount(Username, Password, userId);

            Assert.IsTrue(businessId > 0, "FAIL: No account added");

            // Add Company
            int companyId = business.AddCompany(Name, URL);

            Assert.IsTrue(companyId > 0, "FAIL: No company added");

            // Add User Company Record
            UserCompanyId = business.AddUserCompany(userId, companyId);

            Assert.IsTrue(UserCompanyId > 0, "FAIL: Invalid id");
        }

        //[TestMethod]
        //public void AddCandidateTest()
        //{
        //    string Email = "robertfrost@yahoo.com";
        //    string Password = "Jacob12!";
        //    int UserTypeId = 2;
        //    string FirstName = "Rob";
        //    int MiddleInitialId = 1;
        //    string LastName = "Frost";
        //    int SuffixId = 2;
        //    string Number = "(803) 873-0392";
        //    int NumberTypeId = 1;
        //    string JobTitle = "Sr. .Net Engineer";
        //    int ExperienceId = 4;
        //    string Location = "Charlotte, NC";

        //    Business business = new Business(connectionString);

        //    int userId = business.AddCandidate(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId, Email, Password, Number, NumberTypeId, JobTitle, ExperienceId, Location);

        //    Assert.IsTrue(userId > 0, "Error: No candidated added");
        //}

        [TestMethod]
        public void AddLocationTest()
        {
            string Location = "New York, Manhattan";
            int UserId = 1;

            Business business = new Business(connectionString);
            int id = business.AddLocation(Location, UserId);

            Assert.IsTrue(id > 0, "FAIL: location id");
        }

        [TestMethod]
        public void AddUserCompanyTest()
        {
            int UserId = 10;
            int CompanyId = 2;
            int UserCompanyId = 0;

            Business business = new Business(connectionString);
            UserCompanyId = business.AddUserCompany(UserId, CompanyId);

            Assert.IsTrue(UserCompanyId > 0, "FAIL: Invalid id");
        }

        [TestMethod]
        public void AddNumberTest()
        {
            Business business = new Business(connectionString);
            string Number = "(803) 873-6472";
            int UserId = 1;
            int NumberTypeId = 1;
            int Id = business.AddNumber(Number, UserId, NumberTypeId);

            Assert.IsTrue(Id > 0, "FAIL: No number added");
        }

        [TestMethod]
        public void GetUserTest()
        {
            int UserId = 1;

            Business business = new Business(connectionString);
            DataTable dt = business.GetUser(UserId);

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No user found");
        }

        [TestMethod]
        public void EditUserTest()
        {
            int UserId = 1;
            int UserTypeId = 1;
            string FirstName = "Paul";
            int MiddleInitialId = 0;
            string LastName = "Jones";
            int SuffixId = 0;
            bool Active = true;

            Business business = new Business(connectionString);
            int id = business.EditUser(UserId, UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId, Active);

            Assert.IsTrue(id > 0, "FAIL: Invalid id");
        }

        [TestMethod]
        public void GetUsersTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetUsers();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No users found");
        }

        [TestMethod]
        public void GetUserTypesTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetUserTypes();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No user types found");
        }

        [TestMethod]
        public void GetUserTypeTest()
        {
            int UserTypeId = 1;
            Business business = new Business(connectionString);
            DataTable dt = business.GetUserType(UserTypeId);

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No user type found");
        }

        [TestMethod]
        public void GetRecruitersTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetRecruiters();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No recruiters found");
        }

        [TestMethod]
        public void GetCandidatesTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetCandidates();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No candidates found");
        }


        [TestMethod]
        public void GetMiddleInitialsTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetMiddleInitials();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No middle initial found");
        }

        [TestMethod]
        public void GetMiddleInitialTest()
        {
            int Id = 1;
            Business business = new Business(connectionString);

            string initial = business.GetMiddleInitial(Id);

            Assert.IsTrue(initial.Length > 0, "FAIL: No middle initial found");
        }

        [TestMethod]
        public void GetSuffixesTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetSuffixes();

            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No suffixes found");
        }

        [TestMethod]
        public void GetSuffixTest()
        {
            int Id = 1;
            Business business = new Business(connectionString);

            string initial = business.GetSuffix(Id);

            Assert.IsTrue(initial.Length > 0, "FAIL: No suffix found");

        }
        #endregion

        #region Company Tests
        [TestMethod]
        public void AddCompanyTest()
        {
            string Name = "Robert Half Technology, Inc.";
            string URL = "www.roberthalf.com";

            Business business = new Business(connectionString);
            int companyId = business.AddCompany(Name, URL);

            Assert.IsTrue(companyId > 0, "ERROR: No company added");
        }

        [TestMethod]
        public void EditCompanyTest()
        {
            int Id = 1;
            string Name = "Find Great People, Inc.";
            bool Active = true;
            string URL = "www.findgreatpeople.com";

            Business business = new Business(connectionString);
            int rowsAffected = business.EditCompany(Id, Name, Active, URL);

            Assert.IsTrue(rowsAffected > 0, "ERROR: No company edited");
        }

        [TestMethod]
        public void GetCompanyTest()
        {
            int Id = 1;

            Business business = new Business(connectionString);
            DataTable dt = business.GetCompany(Id);

            Assert.IsTrue(dt.Rows.Count > 0, "ERROR: No companies found");
        }

        [TestMethod]
        public void GetCompanyiesTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetCompanies();

            Assert.IsTrue(dt.Rows.Count > 0, "ERROR: No companies found");
        }
        #endregion

        #region Contact Tests

        [TestMethod]
        public void AddContactTest()
        {
            int ContactTypeId = 4;
            string Value = "pauljonessoftware@gmail.com";
            int UserId = 1;
            Business business = new Business(connectionString);
            int contactId = business.AddContact(Value, ContactTypeId, UserId);

            Assert.IsTrue(contactId > 0, "FAIL: No contact added");
        }

        [TestMethod]
        public void EditContactTest()
        {
            int ContactId = 1;
            string Value = "Job1212!";
            Business business = new Business(connectionString);
            int contactId = business.EditContact(ContactId, Value);

            Assert.IsTrue(contactId > 0, "FAIL: No contact added");
        }

        // Get all contact data except password
        [TestMethod]
        public void GetContactsTest()
        {
            int UserId = 1;
            Business business = new Business(connectionString);

            DataTable dt = business.GetContacts(UserId);
            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No contacts found");
        }

        [TestMethod]
        public void GetContactTest()
        {
            int ContactId = 1;
            Business business = new Business(connectionString);

            DataTable dt = business.GetContact(ContactId);
            Assert.IsTrue(dt.Rows.Count > 0, "FAIL: No contact found");
        }

        #endregion

        #region Account Tests

        [TestMethod]
        public void AddAccountTest()
        {
            string Email = "pauljonessoftware@gmail.com";
            string Password = "purple1!";
            int UserId = 1;
            Business business = new Business(connectionString);
            int contactId = business.AddAccount(Email, Password, UserId);

            Assert.IsTrue(contactId > 0, "FAIL: No login added");
        }

        [TestMethod]
        public void EditAccountTest()
        {
            int Id = 1;
            string Email = "pjones@referralis.com";
            string Password = "Psalm147!";
            Business business = new Business(connectionString);
            int contactId = business.EditAccount(Id, Email, Password);

            Assert.IsTrue(contactId > 0, "FAIL: No account edited");
        }

        [TestMethod]
        public void LoginTest()
        {
            string Email = "pjones@referralis.com";
            string Password = "Psalm147!";
            Business business = new Business(connectionString);
            bool validLogin = business.Login(Email, Password);

            Assert.IsTrue(validLogin == true, "FAIL: Login failed");
        }

        #endregion

        #region Qualifications
        [TestMethod]
        public void AddQualification()
        {
            string JobTitle = ".Net Engineer";
            int ExperienceId = 1;
            int UserId = 1;

            Business business = new Business(connectionString);
            int qualificationId = business.AddQualification(JobTitle, ExperienceId, UserId);

            Assert.IsTrue(qualificationId > 0, "ERROR: No qualification added");
        }

        [TestMethod]
        public void EditQualificationTest()
        {
            int QualificationsId = 1;
            string JobTitle = "Senior C# Programmer";
            int ExperienceId = 1;
            int UserId = 1;

            Business business = new Business(connectionString);
            int rowsAffected = business.EditQualification(QualificationsId, JobTitle, ExperienceId, UserId);

            Assert.IsTrue(rowsAffected > 0, "ERROR: No qualification added");
        }

        [TestMethod]
        public void GetQualificationTest()
        {
            int QualificationsId = 1;

            Business business = new Business(connectionString);
            int rowsAffected = business.GetQualification(QualificationsId);

            Assert.IsTrue(rowsAffected == 1, "ERROR: No qualification found");
        }

        [TestMethod]
        public void GetQualificationsTest()
        {
            Business business = new Business(connectionString);
            DataTable dt = business.GetQualifications();

            Assert.IsTrue(dt.Rows.Count > 0, "ERROR: No qualifications found");
        }
        #endregion

        #region Mail Tests

        //[TestMethod]
        //public void SendReferralTest()
        //{
        //    Business business = new Business(connectionString);
        //    string from = "pauljonessoftware@gmail.com";
        //    string to = "recruiter@recruiter.com";
        //    string subject = "Resource Available";
        //    string body = ".Net Engineer for new assignment";

        //    int numberOfMessagesSent = business.SendMessage(from, subject, to, body);

        //    Assert.IsTrue(numberOfMessagesSent > 0, "ERROR: No messages sent");
        //}

        //[TestMethod]
        //public void GetCredentials()
        //{
        //    Business business = new Business(connectionString);
        //    DataTable dt = business.GetCredentials();

        //    Assert.IsTrue(dt.Rows.Count > 0, "ERROR: No credentials found");
        //}

        #endregion

        #region UtilityTests
        [TestMethod]
        public void LogErrorTest()
        {
            string message = "ERROR message";
            string method = "LogError";

            Business business = new Business(connectionString);
            int errorLogId = business.LogException(message, method);

            Assert.IsTrue(errorLogId > 0, "ERROR: Logging failed.");
        }

        [TestMethod]
        public void GetFileTest()
        {
            int id = 1;

            Business business = new Business(Utility.ConnectionString());

            DataTable dt = business.GetFile(id);

            Assert.IsTrue(dt.Rows.Count > 0, "file record found");

            DataRow row = dt.Rows[0];
            Byte[] data = (Byte[])row["Data"];

            Assert.IsTrue(data.Length > 0, "No resume found");
        }


        [TestMethod]
        public void SendReferralWithAttachmentTest()
        {
            Business business = new Business(connectionString);
            string from = "pjones@refermicro.com";
            string to = "recruiter@recruiter.com";
            string subject = "Resource Available";
            string body = ".Net Engineer for new assignment";

            //int numberOfMessagesSent = business.SendMessage(from, subject, to, body);

            //Assert.IsTrue(numberOfMessagesSent > 0, "ERROR: No messages sent");
        }

        #endregion

        #region Referral Tests
        [TestMethod]
        public void LogReferralTest()
        {
            Business business = new Business(Utility.ConnectionString());
            double Rate = 5.0;
            int CandidateId = 1;
            int RecruiterId = 2;
            string Comments = "Candidate referred to So&So Technologies, Inc.";

            int id = business.LogReferral(Rate, CandidateId, RecruiterId, Comments);

            Assert.IsTrue(id > 0, "ERROR: Failed to log referral");
        }

        [TestMethod]
        public void LogNoticeTest()
        {
            Business business = new Business(Utility.ConnectionString());
            
            int CandidateId = 1;
            int NumberOfMessagesSent = 56;

            int id = business.LogNotice(CandidateId, NumberOfMessagesSent);

            Assert.IsTrue(id > 0, "ERROR: Failed to log referral");
        }
        #endregion

        #region Database Tests

        [TestMethod]
        public void GetOpenDatabaseConnectionTest()
        {
            SqlConnection conn = database.GetOpenConnection();

            Assert.IsTrue(conn.State == ConnectionState.Open, "FAIL: No connection");
        }

        [TestMethod]
        public void CreateDataTableTest()
        {
            Business business = new Business(connectionString);

            DataTable dt = business.GetFilesTable();
        }
        #endregion
    }
}
