using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class GeoTargeting
    {
        public static string GetStateByZip(string zip)
        {
            string state = string.Empty;

            if (!zip.IsNullOrEmpty())
            {
                string stateAbv = string.Empty;
                string sql = "DECLARE @zip nchar(5)" +
                             "SELECT @zip = '" + zip + "'" +
                             "SELECT [state]" +
                             "FROM [dbo].[ZipCodes]" +
                             "WHERE zip = @zip";

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            stateAbv = reader.GetString(0);
                        }
                    }
                }
                if (!stateAbv.IsNullOrEmpty())
                {
                    state = Constants.StateByAbbreviation[stateAbv];
                }
            }
            return state;
        }
    }
}
