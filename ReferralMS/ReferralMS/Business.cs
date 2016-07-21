﻿#region Namespace References
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ReferralMS
{
    public class Business
    {
        #region Members
        Database db;
        #endregion

        #region Constructors
        public Business()
        {
            db = new Database();
        }

        public Business(string ConnectionString)
        {
            db = new Database(ConnectionString);
        }
        #endregion

        #region Database Methods
        private SqlCommand GetCommand(SqlParameter[] SqlParameter)
        {
            SqlCommand cmd = new SqlCommand();

            foreach (SqlParameter parm in SqlParameter)
            {
                cmd.Parameters.Add(parm);
            }

            return cmd;
        }

        private static SqlParameter GetParameter(string Name, ParameterDirection Direction, DbType ParamType, string Value)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = ParamType;
            param.Value = Value;
            param.ParameterName = Name;
            param.Direction = Direction;

            return param;
        }

        private SqlParameter GetParameter(string Name, ParameterDirection Direction, DbType ParamType, double? Value)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = ParamType;
            param.Value = Value;
            param.ParameterName = Name;
            param.Direction = Direction;

            return param;
        }

        private SqlParameter GetParameter(string Name, ParameterDirection Direction, DbType ParamType)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = ParamType;
            param.ParameterName = Name;
            param.Direction = Direction;

            return param;
        }
        #endregion

        #region Opportunity Methods
        public int AddOpportunity(string Title, string Description, double Amount, string City, int StateId, int UserId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddOpportunity";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Title", ParameterDirection.Input, DbType.String, Title);
                SqlParameter param2 = GetParameter("@Description", ParameterDirection.Input, DbType.String, Description);
                SqlParameter param3 = GetParameter("@Amount", ParameterDirection.Input, DbType.Double, Amount.ToString());
                SqlParameter param4 = GetParameter("@City", ParameterDirection.Input, DbType.String, City);
                SqlParameter param5 = GetParameter("@StateId", ParameterDirection.Input, DbType.String, StateId.ToString());
                SqlParameter param6 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4, param5, param6 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddOpportunity");
                return rtn;
            }
        }

        public int EditOpportunity(int Id, string Title, string Description, double Amount, string City, int StateId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditOpportunity";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id);
                SqlParameter param1 = GetParameter("@Title", ParameterDirection.Input, DbType.String, Title);
                SqlParameter param2 = GetParameter("@Description", ParameterDirection.Input, DbType.String, Description);
                SqlParameter param3 = GetParameter("@Amount", ParameterDirection.Input, DbType.Double, Amount);
                SqlParameter param4 = GetParameter("@City", ParameterDirection.Input, DbType.String, City);
                SqlParameter param5 = GetParameter("@StateId", ParameterDirection.Input, DbType.String, StateId);
                SqlParameter param6 = GetParameter("@RowsAffected", ParameterDirection.Output, DbType.Int32);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4, param5, param6 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Update(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditOpportunity");
                return rtn;
            }
        }

        public DataTable GetOpportunity(int OpportunityId)
        {
            try
            {
                string commandText = "spGetOpportunity";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, OpportunityId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetOpportunity");
                return null;
            }
        }

        public DataTable GetOpportunities()
        {
            try
            {
                string commandText = "spGetOpportunities";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });

                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetOpportunities");
                return null;
            }
        }
        #endregion

        #region User Methods
        public int AddUser(int UserTypeId, string FirstName, int MiddleInitialId, string LastName, int SuffixId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddUser";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@UserTypeId", ParameterDirection.Input, DbType.String, UserTypeId.ToString());
                SqlParameter param2 = GetParameter("@FirstName", ParameterDirection.Input, DbType.String, FirstName);
                SqlParameter param3 = GetParameter("@MiddleInitialId", ParameterDirection.Input, DbType.Int32, MiddleInitialId.ToString());
                SqlParameter param4 = GetParameter("@LastName", ParameterDirection.Input, DbType.String, LastName);
                SqlParameter param5 = GetParameter("@SuffixId", ParameterDirection.Input, DbType.String, SuffixId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4, param5 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddUser");
                return rtn;
            }
        }

        public int EditUser(int Id, int UserTypeId, string FirstName, int MiddleInitialId, string LastName, int SuffixId, bool Active)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditUser";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id);
                SqlParameter param1 = GetParameter("@UserTypeId", ParameterDirection.Input, DbType.Int32, UserTypeId.ToString());
                SqlParameter param2 = GetParameter("@FirstName", ParameterDirection.Input, DbType.String, FirstName);
                SqlParameter param3 = GetParameter("@MiddleInitialId", ParameterDirection.Input, DbType.Int32, MiddleInitialId.ToString());
                SqlParameter param4 = GetParameter("@LastName", ParameterDirection.Input, DbType.String, LastName);
                SqlParameter param5 = GetParameter("@SuffixId", ParameterDirection.Input, DbType.String, SuffixId.ToString());
                SqlParameter param6 = GetParameter("@Active", ParameterDirection.Input, DbType.Boolean, Active.ToString());
                SqlParameter param7 = GetParameter("@RowsAffected", ParameterDirection.Output, DbType.Int32);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4, param5, param6, param7 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Update(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditUser");
                return rtn;
            }
        }

        public DataTable GetUser(int UserId)
        {
            try
            {
                string commandText = "spGetUser";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetUser");
                return null;
            }
        }

        public DataTable GetUsers()
        {
            try
            {
                string commandText = "spGetUsers";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetUsers");
                return null;
            }
        }

        public DataTable GetUserTypes()
        {
            try
            {
                string commandtext = "spusertypes";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandtext;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetUserTypes");
                throw;
            }
        }

        public DataTable GetUserType(int UserTypeId)
        {
            try
            {
                string commandText = "spGetUserType";

                SqlParameter param0 = GetParameter("@UserTypeId", ParameterDirection.Input, DbType.Int32, UserTypeId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetUserType");
                return null;
            }
        }

        public int AddUserCompany(int UserId, int CompanyId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddUserCompany";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());
                SqlParameter param2 = GetParameter("@CompanyId", ParameterDirection.Input, DbType.Int32, CompanyId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddUserCompany");
                return rtn;
            }
        }

        public DataTable GetRecruiters()
        {
            try
            {
                string commandText = "spGetRecruiters";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetRecruiters");
                return null;
            }
        }

        public int AddRecruiterAccount(int UserTypeId, string FirstName, int MiddleInitialId, string LastName,
            int SuffixId, string Username, string Password, int UserId, string Name, string URL)
        {
            int rtn = -1;

            try
            {
                // Add user record
                int userId = AddUser(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId);

                // Add User account
                int businessId = AddAccount(Username, Password, userId);

                // Add Company
                int companyId = AddCompany(Name, URL);

                // Add User Company Record
                int UserCompanyId = AddUserCompany(userId, companyId);

                rtn = 1;
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddRecruiterAccount");
            }

            return rtn;
        }

        #endregion

        #region Contact Methods
        public int AddContact(string Value, int ContactTypeId, int UserId)
        {
            int rtn = -1;
            try
            {
                string commandText = "spAddContact";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Value", ParameterDirection.Input, DbType.String, Value.ToString());
                SqlParameter param2 = GetParameter("@ContactTypeId", ParameterDirection.Input, DbType.Int32, ContactTypeId);
                SqlParameter param3 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddContact");
                return rtn;
            }
        }

        public int EditContact(int ContactId, string Value)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditContact";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, ContactId.ToString());
                SqlParameter param1 = GetParameter("@Value", ParameterDirection.Input, DbType.String, Value.ToString());
                SqlParameter param2 = GetParameter("@RowsAffected", ParameterDirection.Output, DbType.Int32);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditContact");
                return rtn; ;
            }
        }

        public DataTable GetContacts(int UserId)
        {
            try
            {
                string commandText = "spGetContacts";

                SqlParameter param0 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetContacts");
                return null;
            }
        }

        public DataTable GetContact(int ContactId)
        {
            try
            {
                string commandText = "spGetContact";

                SqlParameter param0 = GetParameter("@ContactId", ParameterDirection.Input, DbType.Int32, ContactId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetContact");
                return null;
            }
        }

        public int AddAccount(string Email, string Password, int UserId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddAccount";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Email", ParameterDirection.Input, DbType.String, Email);
                SqlParameter param2 = GetParameter("@Password", ParameterDirection.Input, DbType.String, Password);
                SqlParameter param3 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AccAccount");
                return rtn;
            }
        }

        public int EditAccount(int Id, string Email, string Password)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditAccount";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());
                SqlParameter param1 = GetParameter("@Email", ParameterDirection.Input, DbType.String, Email.ToString());
                SqlParameter param2 = GetParameter("@Password", ParameterDirection.Input, DbType.String, Password.ToString());
                SqlParameter param3 = GetParameter("@RowsAffected", ParameterDirection.Output, DbType.Int32);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Update(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditAccount");
                return rtn;
            }
        }
        #endregion

        #region Company Methods
        public int AddCompany(string Name, string URL)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddCompany";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Name", ParameterDirection.Input, DbType.String, Name);
                SqlParameter param2 = GetParameter("@URL", ParameterDirection.Input, DbType.String, URL);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddCompany");
                return rtn;
            }
        }

        public int EditCompany(int Id, string Name, bool Active, string URL)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditCompany";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());
                SqlParameter param1 = GetParameter("@Name", ParameterDirection.Input, DbType.String, Name);
                SqlParameter param2 = GetParameter("@Active", ParameterDirection.Input, DbType.Boolean, Active.ToString());
                SqlParameter param3 = GetParameter("@URL", ParameterDirection.Input, DbType.String, URL);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditCompany");
                return rtn;
            }
        }

        public DataTable GetCompany(int Id)
        {
            try
            {
                string commandText = "spGetCompany";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetCompany");
                return null;
            }
        }

        public DataTable GetCompanies()
        {
            try
            {
                string commandText = "spGetCompanies";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetCompanies");
                return null;
            }
        }
        #endregion

        #region Qualification Methods
        public int AddQualification(string JobTitle, int ExperienceId, int UserId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spAddQualification";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@JobTitle", ParameterDirection.Input, DbType.String, JobTitle);
                SqlParameter param2 = GetParameter("@ExperienceId", ParameterDirection.Input, DbType.Int32, ExperienceId.ToString());
                SqlParameter param3 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddQualification");
                return rtn;
            }
        }

        public int EditQualification(int QualificationsId, string JobTitle, int ExperienceId, int UserId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spEditQualification";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, QualificationsId.ToString());
                SqlParameter param1 = GetParameter("@JobTitle", ParameterDirection.Input, DbType.String, JobTitle);
                SqlParameter param2 = GetParameter("@ExperienceId", ParameterDirection.Input, DbType.Int32, ExperienceId.ToString());
                SqlParameter param3 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId.ToString());
                SqlParameter param4 = GetParameter("@RowsAffected", ParameterDirection.Output, DbType.Int32);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "EditQualification");
                return rtn;
            }
        }

        public int GetQualification(int QualificationsId)
        {
            int rtn = -1;

            try
            {
                string commandText = "spGetQualification";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, QualificationsId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetQualification");
                return rtn;
            }
        }

        public DataTable GetQualifications()
        {
            try
            {
                string commandText = "spGetQualifications";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetQualifications");
                return null;
            }
        }
        #endregion

        #region Mail Methods

        public int SendMessage(string From, string Subject, string To, string Body)
        {
            int rtn = -1;

            try
            {
                int numberOfMessages = 0;
                string recruiterEmailAddress = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;

                MailMessage mm = new MailMessage();
                mm.From = GetMailAddress(From); ;
                mm.Subject = Subject;
                mm.Body = Body;
                mm.IsBodyHtml = false;
                mm.Bcc.Add(GetMailAddress(From));

                DataTable dtRecruiters = GetRecruiters();

                foreach (DataRow row in dtRecruiters.Rows)
                {
                    recruiterEmailAddress = row["email"].ToString();
                    firstName = row["firstName"].ToString();
                    lastName = row["lastName"].ToString();
                    mm.Bcc.Add(GetMailAddress(recruiterEmailAddress));
                    numberOfMessages++;
                }

                GetSMTPServer().Send(mm);

                return numberOfMessages;

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "SendMessage");
                return rtn;
            }
        }

        private SmtpClient GetSMTPServer()
        {
            try
            {
                string username = string.Empty;
                string password = string.Empty;

                DataTable dt = GetCredentials();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    username = row["username"].ToString();
                    password = row["password"].ToString();
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(username, password);

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                return smtp;
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetSMTPServer");
                return null;
            }
        }

        public DataTable GetCredentials()
        {
            try
            {
                string commandText = "spGetCredentials";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetCredentials");
                return null;
            }
        }

        private MailAddress GetMailAddress(string Address)
        {
            MailAddress address = new MailAddress(Address);
            return address;
        }

        #endregion

        #region Utility Methods

        public bool Login(string Email, string Password)
        {
            bool loginSuccessful = false;

            string commandText = "spLogin";

            SqlParameter param0 = GetParameter("@Email", ParameterDirection.Input, DbType.String, Email.ToString());
            SqlParameter param1 = GetParameter("@Password", ParameterDirection.Input, DbType.String, Password.ToString());

            SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1 });
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = db.Read(cmd);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int userId = int.Parse(row["UserId"].ToString());

                if (userId > 0)
                {
                    loginSuccessful = true;
                }
            }

            return loginSuccessful;
        }

        public int LogException(string message, string method)
        {
            string commandText = "spLogError";

            SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
            SqlParameter param1 = GetParameter("@Message", ParameterDirection.Input, DbType.String, message);
            SqlParameter param2 = GetParameter("@Method", ParameterDirection.Input, DbType.String, method);

            SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.StoredProcedure;

            return db.Add(cmd);
        }

        #endregion
    }
}
