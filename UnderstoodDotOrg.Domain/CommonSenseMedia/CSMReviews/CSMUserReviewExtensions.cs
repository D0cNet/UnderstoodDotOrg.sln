using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;

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
                                " LastModified " +
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
                            CSMUserReview review = new CSMUserReview();
                            while (reader.Read())
                            {
                                review.ReviewId = reader.GetGuid(0);
                                review.MemberId = reader.GetGuid(1);
                                review.CSMItemId = reader.GetGuid(2);
                                review.Rating = reader.GetInt32(3);
                                review.RatedGradeId = reader.GetGuid(4);
                                review.GradeAppropriateness = reader.GetInt32(5);
                                review.Created = reader.GetDateTime(6);
                                review.LastModified = reader.GetDateTime(7);
                            }

                            reviews.Add(review);
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

        public static bool InsertNewReview(CSMUserReview review)
        {
            bool success = false;
            string sql = "INSERT INTO [Understood.org.DEV.membership].[dbo].[CSMUserReviews] " +
                       "([ReviewId] " +
                       ",[MemberId] " +
                       ",[CSMItemId] " +
                       ",[Rating] " +
                       ",[RatedGradeId] " +
                       ",[GradeAppropriateness] " +
                       ",[Created] " +
                       ",[LastModified] " +
                       ",[TelligentCommentId]) " +
                 "VALUES " +
                       "(newid(), " +
                       "@MemberId, " +
                       "@CSMId, " +
                       "@ReviewRating, " +
                       "@GradeId, " +
                       "@GradeNumber, " +
                       "CURRENT_TIMESTAMP, " +
                       "CURRENT_TIMESTAMP, " +
                       "newid())";
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
                        cmd.Parameters.AddWithValue("@GradeNumber", review.GradeAppropriateness);
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
    }
}
