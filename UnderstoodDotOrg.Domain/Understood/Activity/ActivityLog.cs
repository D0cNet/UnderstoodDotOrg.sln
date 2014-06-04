using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Activity
{

    public class ActivityLog
    {
        public virtual ICollection<ActivityItem> Activities { get; set; }
       
        /// <summary>
        /// Creates a new empty activity log
        /// </summary>
        public ActivityLog()
        {
            this.Activities = new HashSet<ActivityItem >();
        }
        /// <summary>
        /// Fills the activcity log based on the member and the value of the activity (see activity value constants)
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="ActivityValue"></param>
        public ActivityLog(Guid MemberId, String ActivityValue)
        {
            this.Activities = new HashSet<ActivityItem>();

            FillActivityLog(MemberId,ActivityValue );
     
        }
        
        private void FillActivityLog (Guid MemberId, string ActivityValue)
        {
            string sql = " SELECT [Key] AS ContentId, Value AS ActivityValue, ActivityType, DateModified " +
                " FROM  MemberActivity " +
                " WHERE (MemberId = @MemberId) AND (Value = @ActivityValue)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.Parameters.AddWithValue("@ActivityValue", ActivityValue);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                            //fill activity log with activity items
                            ActivityItem item = new ActivityItem();
                            item.ContentId = reader.GetGuid(0);//ContentId;
                            if (!reader.IsDBNull(1))//(1)=ActivityValue
                            {
                                item.ActivityValue = reader.GetString(1);//ActivityValue

                            }
                            else 
                            {
                                item.ActivityValue = string.Empty;
                            }
                            item.ActivityType = reader.GetInt32(2);//ActivityType
                            item.DateModified = reader.GetDateTime(3);//DateModified
                            this.Activities.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
              
        }
    }
}
