#region Namespace References
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ReferralMS
{
    public class Database
    {
        #region Members
        string connectionString;
        #endregion

        #region Constructors
        public Database() { }

        public Database(string ConnectionString)
        {
            connectionString = ConnectionString;
        }
        #endregion

        #region Methods

        public int Add(SqlCommand cmd)
        {
            int id = 0;
            using (SqlConnection conn = GetOpenConnection())
            {
                cmd.Connection = conn;
                cmd.ExecuteScalar();
                id = Convert.ToInt32(cmd.Parameters["@Id"].Value);
            }

            return id;
        }

        public int Update(SqlCommand cmd)
        {
            int id = 0;
            using (SqlConnection conn = GetOpenConnection())
            {
                cmd.Connection = conn;
                cmd.ExecuteScalar();
                id = Convert.ToInt32(cmd.Parameters["@RowsAffected"].Value);
            }

            return id;
        }

        public DataTable Read(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetOpenConnection())
            {
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        public SqlConnection GetOpenConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            return conn;
        }

        #endregion
    }
}
