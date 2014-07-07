using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews
{
    public static class CSMUserReviewExtensions
    {
        public static List<CSMUserReview> GetReviews(Guid CSMItemId)
        {
            List<CSMUserReview> reviews = new List<CSMUserReview>();
            string sql = " SELECT ReviewId, " +
                                " MemberId, " +
                                " CSMItemId, " +
                                " Rating, " +
                                " RatedGradeId, " +
                                " GradeAppropriateness, " +
                                " Created, " +
                                " LastModified, " +
                                " TelligentCommentId, " +
                                " ReviewTitle " +
                                " FROM CSMUserReviews " +
                                " WHERE (CSMItemId = @CSMId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CSMId", CSMItemId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CSMUserReview review = new CSMUserReview();
                                review.ReviewId = reader.GetGuid(0);
                                review.MemberId = reader.GetGuid(1);
                                review.CSMItemId = reader.GetGuid(2);
                                review.Rating = reader.GetInt32(3);
                                review.RatedGradeId = reader.GetGuid(4);
                                review.GradeAppropriateness = reader.GetInt32(5);
                                review.Created = reader.GetDateTime(6);
                                review.LastModified = reader.GetDateTime(7);
                                review.TelligentCommentId = reader.GetGuid(8);
                                review.ReviewTitle = reader.GetString(9);
                                review.UserReviewIssues = GetSkills(review.ReviewId); 
                                reviews.Add(review);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reviews;
        }

        public static List<AssistiveToolsIssueItem> GetSkills(Guid reviewId)
        {
            List<AssistiveToolsIssueItem> skills = new List<AssistiveToolsIssueItem>();
            string sql = " SELECT RowId, " +
                                " ReviewId, " +
                                " SkillId " +
                                " FROM CSMReviewsToSkills " +
                                " WHERE (ReviewId = @ReviewId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReviewId", reviewId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                AssistiveToolsIssueItem skill = Sitecore.Context.Database.GetItem(reader.GetGuid(2).ToString());
                                skills.Add(skill);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return skills;
        }

        public static bool InsertNewReview(CSMUserReview review)
        {
            bool success = false;
            review.ReviewId = Guid.NewGuid();
            string commentId = CommunityHelper.PostComment(review.BlogId, review.BlogPostId, review.ReviewBody, review.UserScreenName);
            string sql = "INSERT INTO [CSMUserReviews] " +
                       "([ReviewId] " +
                       ",[MemberId] " +
                       ",[CSMItemId] " +
                       ",[Rating] " +
                       ",[RatedGradeId] " +
                       ",[GradeAppropriateness] " +
                       ",[Created] " +
                       ",[LastModified] " +
                       ",[TelligentCommentId] " +
                       ",[ReviewTitle] " +
                       ",[IThinkItIs]) " +
                 "VALUES " +
                       "(@ReviewId, " +
                       "@MemberId, " +
                       "@CSMId, " +
                       "@ReviewRating, " +
                       "@GradeId, " +
                       "@GradeNumber, " +
                       "CURRENT_TIMESTAMP, " +
                       "CURRENT_TIMESTAMP, " +
                       "@CommentId, " +
                       "@ReviewTitle, " +
                       "@IThinkItIs) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CSMId", review.CSMItemId);
                        cmd.Parameters.AddWithValue("@MemberId", review.MemberId);
                        cmd.Parameters.AddWithValue("@GradeId", review.RatedGradeId);
                        cmd.Parameters.AddWithValue("@ReviewRating", review.Rating);
                        cmd.Parameters.AddWithValue("@CommentId", commentId);
                        cmd.Parameters.AddWithValue("@ReviewId", review.ReviewId);
                        cmd.Parameters.AddWithValue("@ReviewTitle", review.ReviewTitle);
                        cmd.Parameters.AddWithValue("@IThinkItIs", review.IThinkItIs);
                        cmd.Parameters.AddWithValue("@GradeNumber", review.GradeAppropriateness);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }

                    if (success)
                    {
                        InsertAllIssues(review.UserReviewIssues, review.ReviewId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            success = true;
            return success;
        }

        private static void InsertAllIssues(List<AssistiveToolsIssueItem> skillList, Guid reviewId)
        {
            foreach (AssistiveToolsIssueItem skill in skillList)
            {
                InsertReviewSkill(skill.ID.ToGuid(), reviewId);
            }
        }

        public static bool InsertSkill(Guid skillId)
        {
            bool success = false;
            string sql = "INSERT INTO [CSMUserReviewSkills] " +
                       "([SkillId]) " +
                 "VALUES " +
                       "(@SkillId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SkillId", skillId);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            success = true;
            return success;
        }

        public static bool InsertReviewSkill(Guid skillId, Guid reviewId)
        {
            bool success = false;
            string sql = "INSERT INTO [CSMReviewsToSkills] " +
                       "([ReviewId], [SkillId]) " +
                 "VALUES " +
                       "(@ReviewId, @SkillId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SkillId", skillId);
                        cmd.Parameters.AddWithValue("@ReviewId", reviewId);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            success = true;
            return success;
        }

        public static bool SkillExists(Guid skillId)
        {
            List<AssistiveToolsSkillItem> skills = new List<AssistiveToolsSkillItem>();
            string sql = " SELECT SkillId " +
                                " FROM CSMUserReviewSkills " +
                                " WHERE (SkillId = @SkillId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SkillId", skillId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public static string GetAverageRating(Guid CSMId)
        {
            string sql = "SELECT AVG (Rating) as AverageRating " +
                          "FROM CSMUserReviews " +
                          "WHERE (CSMItemId = @CSMId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CSMId", CSMId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetInt32(0).ToString();
                        }
                        else
                            return "1";
                    }
                }
            }
            catch (Exception ex)
            {
                return "1";
            }
        }
    }
}
