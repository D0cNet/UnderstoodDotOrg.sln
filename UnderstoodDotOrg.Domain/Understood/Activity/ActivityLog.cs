using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;

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
        public bool FoundItemHelpful(Guid ContentId, Guid MemberId)
        { 
            bool result = false;
            int i = GetActivityCountByValueAndUser(ContentId, MemberId, Constants.UserActivity_Values.FoundHelpful_True);
            // i should be either 0 or 1 at this point
            result = Convert.ToBoolean(i); //0 is false 1 is true
            return result; 
        }
         public bool FoundItemNotHelpful(Guid ContentId, Guid MemberId)
        {
            bool result = false;
            int i = GetActivityCountByValueAndUser(ContentId, MemberId, Constants.UserActivity_Values.FoundHelpful_False );
            // i should be either 0 or 1 at this point
            result = Convert.ToBoolean(i); //0 is false 1 is true
             return result;
        }
        private int GetActivityCountByValueAndUser(Guid ContentId, Guid MemberId, string ActivityValue)
        {
                
            int count = 0;
            string sql = " SELECT Count([rowId]) " +
                            " FROM [dbo].[MemberActivity] " +
                            " WHERE Value = @ActivityValue " +
                            " and [Key] = @ContentId " +
                            " and MemberId = @Memberid " +
                            " and [Deleted] = 0 ";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ActivityValue", ActivityValue);
                        cmd.Parameters.AddWithValue("@ContentId", ContentId);
                        cmd.Parameters.AddWithValue("@Memberid", MemberId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                             count = reader.GetInt32(0) ;//Count;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
   
        /// <summary>
        /// Pass in your search value (probably a constant) and get back a total count from the db.
        /// </summary>
        /// <param name="ActivityValue"></param>
        /// <returns></returns>
        public int GetActivityCountByValue(Guid ContentId, string ActivityValue)
        {
            int count = 0;
            string sql = " SELECT Count([rowId]) " +
                            " FROM [dbo].[MemberActivity] " +
                            " WHERE Value = @ActivityValue " +
                            " and [Key] = @ContentId " +
                            " and [Deleted] = 0 ";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ActivityValue", ActivityValue);
                        cmd.Parameters.AddWithValue("@ContentId", ContentId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                             count = reader.GetInt32(0) ;//Count;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }


        private void FillActivityLog (Guid MemberId, string ActivityValue)
        {
            string sql = " SELECT [Key] AS ContentId, Value AS ActivityValue, ActivityType, DateModified " +
                " FROM  MemberActivity " +
                " WHERE (MemberId = @MemberId) AND " +
                      " (Value = @ActivityValue) AND " + 
                      " (Deleted=0) ";
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
