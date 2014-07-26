using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

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
           // this.MostPopularItems = new HashSet<Guid>();
        }

        public List<Guid?> MostPopularItems(Guid SubtopicId)
        {
             List<Guid?> items = new List<Guid?>();
            
            //Gets a list of all items recorded in the table's view of subtopic views where the item that was viewed was in this subtopic
            // grouping up the total number of views by content item, and ordering them so most popular is first
            string sql = "SELECT Count(MemberId) as TotalViews, ContentId " +
                         " FROM [dbo].[vw_SubtopicItemViews] " +
                         "WHERE Subtopic = @subtopicid " +
                         " GROUP BY ContentId " +
                         " ORDER BY TotalViews desc";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@subtopicid", SubtopicId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Guid g = new Guid();
                                g = Guid.Parse(reader.GetString(1)); //sql is going to give us a string/varchar back for this. deal with it.
                                items.Add(g);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return items;
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

        private List<Guid> GetSubtopicArticleIds(Item subtopic)
        {
            return subtopic.Children.FilterByContextLanguageVersion()
                                .Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                                .Select(i => i.ID.ToGuid())
                                .ToList();
        }

        public bool HasPopularArticlesBySubtopic(Item subtopic)
        {
            List<Guid> articleIds = GetSubtopicArticleIds(subtopic);

            try
            {
                using (var mc = new MemberActivityContext())
                {
                    string activityType = String.Concat(Constants.UserActivity_Values.SubtopicItemViewed, subtopic.ID.ToGuid().ToString());

                    var query = from ma in mc.MemberActivity
                                where ma.Value == activityType
                                    && articleIds.Contains(ma.Key.Value)
                                select ma.Key;

                    return query.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                // TODO: log
            }

            return false;
        }

        public List<Guid> GetMostPopularArticleIdsBySubtopic(Item subtopic, int page, int pageSize, out bool hasMoreResults)
        {
            List<Guid> results = new List<Guid>();
            hasMoreResults = false;

            // Grab guids for articles under this subtopic to restrict article search
            List<Guid> articleIds = GetSubtopicArticleIds(subtopic);

            try
            {
                using (var mc = new MemberActivityContext())
                {
                    string activityType = String.Concat(Constants.UserActivity_Values.SubtopicItemViewed, subtopic.ID.ToGuid().ToString());

                    var query = from ma in mc.MemberActivity
                                where ma.Value == activityType
                                    && articleIds.Contains(ma.Key.Value)
                                group ma by ma.Key into groupView
                                select new
                                {
                                    TotalViews = groupView.Count(),
                                    ContentId = groupView.Key
                                };

                    // Limit results that have at least one view
                    int totalArticles = query.Count();

                    int offset = (page - 1) * pageSize;

                    results = query.OrderByDescending(x => x.TotalViews)
                                    .Select(x => x.ContentId.Value)
                                    .Skip(offset)
                                    .Take(pageSize)
                                    .ToList();

                    hasMoreResults = results.Count() + offset < totalArticles;
                }
            }
            catch (Exception ex)
            {
                // TODO: log
            }

            return results;
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
