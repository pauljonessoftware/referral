#region Namespace References
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

        private SqlParameter GetParameter(string Name, ParameterDirection Direction, DbType ParamType, byte[] Value)
        {
            SqlParameter param = new SqlParameter();
            param.DbType = ParamType;
            param.Value = Value;
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

        public DataTable GetRecruiters(List<int> lstRecruiterIds)
        {
            string recruiterIds = GetCommaDelimitedList(lstRecruiterIds);

            try
            {
                //string commandText = "spGetRecruitersFromIds";

                //SqlParameter param0 = GetParameter("@RecruiterIds", ParameterDirection.Input, DbType.Int32, recruiterIds);
                //SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                //cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.StoredProcedure;

                //return db.Read(cmd);

                 
                string sql = "SELECT U.[UserId], U.[UserTypeId], U.[FirstName] ,U.[MiddleInitialId] ,U.[LastName] ,U.[SuffixId] ,U.[Active] ,A.Email ,C.Name Company ";
                sql += ",C.URL FROM [dbo].[TblUser] U INNER JOIN [dbo].TblAccount A ON U.UserId = A.UserId INNER JOIN Referral..xUserCompany xC ON ";
                sql += "U.UserId = xC.UserId INNER JOIN Referral..TblCompany C ON xC.CompanyId = c.Id WHERE U.UserTypeId = 3 AND u.UserId IN ("; 
                sql += recruiterIds + ")";

                string commandText = sql;

                SqlCommand cmd = GetCommand(new SqlParameter[] {  });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                return db.Read(cmd);


            }
            catch (Exception exc)
            {
                LogException(exc.Message, "spGetRecruitersFromIds");
                return null;
            }
        }

        private string GetCommaDelimitedList(List<int> lstRecruiterIds)
        {
            string lst = string.Empty;

            for (int i = 0; i < lstRecruiterIds.Count; i++)
            {
                lst += lstRecruiterIds[i].ToString();

                if (i < lstRecruiterIds.Count - 1)
                {
                    lst += ",";
                }
            }

            return lst;
        }

        public int AddRecruiterAccount(int UserTypeId, string FirstName, int MiddleInitialId, string LastName,
            int SuffixId, string Email, string Password, string CompanyName, string URL)
        {
            int rtn = -1;

            try
            {
                // Add user record
                int userId = AddUser(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId);

                // Add User account
                int businessId = AddAccount(Email, Password, userId);

                // Add Company
                int companyId = AddCompany(CompanyName, URL);

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

        public int AddNumber(string Number, int UserId, int NumberTypeId)
        {
            int rtn = -1;
            try
            {
                string commandText = "spAddNumber";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Number", ParameterDirection.Input, DbType.String, Number.ToString());
                SqlParameter param2 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId);
                SqlParameter param3 = GetParameter("@NumberTypeId", ParameterDirection.Input, DbType.Int32, NumberTypeId.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddNumber");
                return rtn;
            }
        }

        public int AddLocation(string Location, int UserId)
        {
            int rtn = -1;
            try
            {
                string commandText = "spAddLocation";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Location", ParameterDirection.Input, DbType.String, Location);
                SqlParameter param2 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "AddNumber");
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

        public int SendNotice(DataTable dtCandidate, string From, string Subject)
        {
            int rtn = -1;

            try
            {
                int candidateId = 0;
                if (dtCandidate.Rows.Count > 0)
                {
                    DataRow row = dtCandidate.Rows[0];
                    candidateId = Int32.Parse(row["UserId"].ToString());
                }

                int numberOfMessages = 0;
                string recruiterEmailAddress = string.Empty;

                MailMessage mm = new MailMessage();
                mm.From = GetMailAddress(From);
                mm.Subject = Subject;

                // Create body from candidate datatable parameter
                mm.Body = GetNoticeText(dtCandidate);
                mm.IsBodyHtml = true;
                mm.Bcc.Add(GetMailAddress(From));

                DataTable dtRecruiters = GetRecruiters();

                foreach (DataRow row in dtRecruiters.Rows)
                {
                    recruiterEmailAddress = row["email"].ToString();
                    mm.Bcc.Add(GetMailAddress(recruiterEmailAddress));
                    numberOfMessages++;
                }

                GetSMTPServer().Send(mm);

                LogNotice(candidateId, numberOfMessages);

                return numberOfMessages;

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "SendMessage");
                return rtn;
            }
        }

        public int SendMessageWithAttachment(List<int> lstRecruiterIds, DataTable dtCandidate, string From, 
            string Subject, byte[] Attachment, String FileName, String MediaType, double Amount)
        {
            int rtn = -1;

            try
            {
                int candidateId = 0;
                int numberOfMessages = 0;
                int recruiterId = 0;              
                string recruiterEmailAddress = string.Empty;

                if (dtCandidate.Rows.Count > 0)
                {
                    DataRow row = dtCandidate.Rows[0];
                    candidateId = Int32.Parse(row["UserId"].ToString());
                }

                MemoryStream ms = new MemoryStream(Attachment);

                MailMessage mm = new MailMessage();
                mm.From = GetMailAddress(From);
                mm.Subject = Subject;

                // Create body from candidate datatable parameter

                mm.Body = GetBody(dtCandidate);
                mm.IsBodyHtml = true;
                mm.Bcc.Add(GetMailAddress(From));
                mm.Attachments.Add(new Attachment(ms, FileName, MediaType));

                DataTable dtRecruiters = GetRecruiters(lstRecruiterIds);

                foreach (DataRow row in dtRecruiters.Rows)
                {
                    recruiterId = int.Parse(row["UserId"].ToString());
                    recruiterEmailAddress = row["email"].ToString();
                    mm.Bcc.Add(GetMailAddress(recruiterEmailAddress));
                    numberOfMessages++;

                    LogReferral(Amount, candidateId, recruiterId, null);
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

        private string GetNoticeText(DataTable dtCandidate)
        {
            DataRow row = dtCandidate.Rows[0];

            string experience = row["Experience"].ToString();
            string title = row["JobTitle"].ToString();
            string location = row["Location"].ToString();

            string body = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\">";
            body += "<head><title>Resource Availability Notice</title><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\">";
            body += "</head><body><table style=\"border-collapse:collapse; margin:3px; padding:3px; width:720px;\"><tr><td>";
            body += "Dear Recruiter,<br><br>";
            body += "Clearasoft Technology Solutions, LLC has identified a highly qualified " + title + " with " + experience + " ";
            body += "experience. He/she is looking for an exciting and challenging new opportunity in the " + location + " area. ";
            body += "If you are interested in this lead, please contact us at your earliest convenience. The referral fee is 10% negotiable. ";
            body += "<br><br>Regards,<p>&nbsp;</p>";
            body += "<div style=\"font-weight:bold; font-size:large; color:#303030;\">";
            body += "Paul A. Jones, Jr.</div><div>President &amp; Founder</div><div>Clearasoft Technology Solutions, LLC</div><div>";
            body += "<a href=\"mailto:pauljonessoftware@gmail.com\">clearasoftware@gmail.com</a></div><div>Mobile: ";
            body += "(803) 873-6472</div><div>Twitter: @clearasoftware</div></td></tr></table></body></html>";

            return body;
        }

        private string GetBody(DataTable dtCandidate)
        {
            DataRow row = dtCandidate.Rows[0];

            string firstName = row["FirstName"].ToString();
            string middleInitial = row["MiddleInitial"].ToString();
            string lastName = row["LastName"].ToString();
            string suffix = row["Suffix"].ToString();
            string email = row["Email"].ToString();
            string phone = row["Number"].ToString();
            string experience = row["Experience"].ToString();
            string title = row["JobTitle"].ToString();

            string body = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\">";
            body += "<head><title>Resource Availability Notice</title><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\">";
            body += "</head><body><table style=\"border-collapse:collapse; margin:3px; padding:3px;\"><tr><td><span style=\"font-size:20pt; font-weight:bold;\">DEAR RECRUITER,</span><p>";
            body += "The Information Technology Human Resource below is immediately available for a new assignment.<p>";
            body += "<b>CONTACT INFORMATION</b><p>";
            body += firstName + " " + middleInitial + ". " + lastName + " " + suffix;
            body += "<br />" + title + "<br />";
            body += phone + "<br>" + email + "<p/>";
            body += "Resume attached.<p/>";
            body += "Regards,<p>&nbsp;</>";
            body += "<div style=\"font-weight:bold; font-size:large; color:#303030;\">";
            body += "Paul A. Jones, Jr.</div><div>President &amp; Founder</div><div>Clearasoft Technology Solutions, LLC</div><div>";
            body += "<a href=\"mailto:pauljonessoftware@gmail.com\">pauljonessoftware@gmail.com</a></div><div>Mobile: ";
            body += "(803) 873-6472</div>";
            body += "<div><a href=\"https://twitter.com/paulajonesjr\" class=\"twitter-follow-button\" data-show-count=\"false\">Follow @paulajonesjr</a><script async src=\"//platform.twitter.com/widgets.js\" charset=\"utf-8\"></script></div>";
            body += "</td></tr></table></body></html>";

            return body;
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

        public DataTable GetMiddleInitials()
        {
            try
            {
                string commandText = "spGetMiddleInitials";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetMiddleInitials");
                return null;
            }
        }

        public string GetMiddleInitial(int Id)
        {
            string MiddleInitial = string.Empty;

            try
            {
                string commandText = "spGetMiddleInitial";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = db.Read(cmd);

                if (dt.Rows.Count > 0)
                {
                    MiddleInitial = dt.Rows[0]["MiddleInitial"].ToString();
                }

                return MiddleInitial;
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetUser");
                return null;
            }
        }

        public DataTable GetSuffixes()
        {
            try
            {
                string commandText = "spGetSuffixes";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetSuffixes");
                return null;
            }
        }

        public string GetSuffix(int Id)
        {
            string Suffix = string.Empty;

            try
            {
                string commandText = "spGetSuffix";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = db.Read(cmd);

                if (dt.Rows.Count > 0)
                {
                    Suffix = dt.Rows[0]["Suffix"].ToString();
                }

                return Suffix;
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetSuffix");
                return null;
            }
        }

        public object GetYearsExperience()
        {
            try
            {
                string commandText = "spGetExperiences";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetYearsExperience");
                return null;
            }
        }

        public int AddCandidate(int UserTypeId, string FirstName, int MiddleInitialId, string LastName,
            int SuffixId, string Email, string Password, string Number, int NumberTypeId,
            string JobTitle, int ExperienceId, string Location, DataTable Files)
        {
            // add user
            int UserId = AddUser(UserTypeId, FirstName, MiddleInitialId, LastName, SuffixId);

            // add account
            int accountId = AddAccount(Email, Password, UserId);

            // add number
            int numberId = AddNumber(Number, UserId, NumberTypeId);

            // add qualification
            int qualificationId = AddQualification(JobTitle, ExperienceId, UserId);

            // add location
            int locationId = AddLocation(Location, UserId);

            // add resume
            if (Files != null && Files.Rows.Count > 0)
            {
                DataRow row = Files.Rows[0];
                string fileName = row["Name"].ToString();
                string fileType = row["FileType"].ToString();
                byte[] data = (byte[])row["Data"];

                UpLoadFile(fileName, fileType, data, UserId);
            }

            return UserId;
        }

        public DataTable GetCandidates()
        {
            try
            {
                string commandText = "spGetCandidates";

                SqlCommand cmd = GetCommand(new SqlParameter[] { });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetCandidates");
                return null;
            }
        }

        public int UpLoadFile(string Name, string FileType, byte[] Data, int UserId)
        {
            using (Stream stream = new MemoryStream(Data))
            {
                stream.Read(Data, 0, Data.Length);

                int rtn = -1;

                try
                {
                    string commandText = "spUploadFile";

                    SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                    SqlParameter param1 = GetParameter("@Name", ParameterDirection.Input, DbType.String, Name);
                    SqlParameter param2 = GetParameter("@FileType", ParameterDirection.Input, DbType.String, FileType);
                    SqlParameter param3 = GetParameter("@Data", ParameterDirection.Input, DbType.Binary, Data);
                    SqlParameter param4 = GetParameter("@UserId", ParameterDirection.Input, DbType.Int32, UserId);

                    SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4 });
                    cmd.CommandText = commandText;
                    cmd.CommandType = CommandType.StoredProcedure;

                    return db.Add(cmd);
                }
                catch (Exception exc)
                {
                    LogException(exc.Message, "UpLoadFile");
                    return rtn;
                }
            }
        }

        public DataTable GetFilesTable()
        {
            DataTable dt = new DataTable("Files");
            DataColumn col1 = new DataColumn("Name", System.Type.GetType("System.String"));
            DataColumn col2 = new DataColumn("FileType", System.Type.GetType("System.String"));
            DataColumn col3 = new DataColumn("Data", System.Type.GetType("System.Byte[]"));
            DataColumn col4 = new DataColumn("UserId", System.Type.GetType("System.Int32"));

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);

            DataRow row = dt.NewRow();
            dt.Rows.Add(row);

            return dt;
        }

        public DataTable GetFile(int Id)
        {
            try
            {
                string commandText = "spGetResume";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetFile");
                return null;
            }
        }

        public DataTable GetCandidate(int Id)
        {
            try
            {
                string commandText = "spGetCandidate";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Input, DbType.Int32, Id.ToString());

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Read(cmd);
            }
            catch (Exception exc)
            {
                LogException(exc.Message, "GetCandidate");
                return null;
            }
        }

        public int LogReferral(double Amount, int CandidateId, int RecruiterId, string Comments)
        {
            int rtn = -1;
            try
            {
                string commandText = "spLogReferral";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@Amount", ParameterDirection.Input, DbType.Double, Amount);
                SqlParameter param2 = GetParameter("@CandidateId", ParameterDirection.Input, DbType.Int32, CandidateId);
                SqlParameter param3 = GetParameter("@RecruiterId", ParameterDirection.Input, DbType.Int32, RecruiterId);
                SqlParameter param4 = GetParameter("@Comments", ParameterDirection.Input, DbType.String, Comments);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2, param3, param4 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "LogReferral");
                return rtn;
            }
        }

        public int LogNotice(int CandidateId, int NumberOfMessagesSent)
        {
            int rtn = -1;
            try
            {
                string commandText = "spLogNotice";

                SqlParameter param0 = GetParameter("@Id", ParameterDirection.Output, DbType.Int32);
                SqlParameter param1 = GetParameter("@CandidateId", ParameterDirection.Input, DbType.Int32, CandidateId);
                SqlParameter param2 = GetParameter("@NumberOfMessagesSent", ParameterDirection.Input, DbType.Int32, NumberOfMessagesSent);

                SqlCommand cmd = GetCommand(new SqlParameter[] { param0, param1, param2 });
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                return db.Add(cmd);

            }
            catch (Exception exc)
            {
                LogException(exc.Message, "LogNotice");
                return rtn;
            }
        }
    }
}
