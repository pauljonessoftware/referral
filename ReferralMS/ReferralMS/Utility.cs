#region Namespace References
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ReferralMS
{
    public class Utility
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Referral"].ToString();
        }    
    }
}
