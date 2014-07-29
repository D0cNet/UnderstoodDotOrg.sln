using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.ExactTarget;


namespace UnderstoodDotOrg.Services.ExactTarget
{
    public static class ScheduledJobs
    {

        public static void WeeklyGeneralNewsLetter()
        {
            Sitecore.Diagnostics.Log.Debug("Scheduled Weekly Newsletter Send Starting.");
            try
            {
                string sql = "member_GetNewsletterSubscribers";//stored procedure

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@DefaultName", "Parent"); //used as the value the reader should read when the first name is missing, null, etc

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {

                            string memberName = string.Empty;
                            string emailAddress = string.Empty;
                            int percentComplete = 0;
                            Guid memberId = new Guid();

                            
                            while (reader.Read())
                            {
                                emailAddress = reader.GetString(0);
                                memberName = reader.GetString(1);
                                //percentComplete = reader.GetInt16(2); //pulling this out of the sproc to make it more maintainable - nobody else works with stored procedures
                                memberId = reader.GetGuid(3);
                                //get the percent complete
                                percentComplete = PercentProfileComplete(memberId);
               
                                //send email logic
                                //-- for testing until its wired
                                /*Sitecore.Diagnostics.Log.Debug("General Email Newsletter for " + Environment.NewLine + 
                                                                "- Email:" + emailAddress + Environment.NewLine +
                                                                "- Name:" + memberName + Environment.NewLine +
                                                                "- MemberId: " + memberId.ToString() + Environment.NewLine + 
                                                                "- % Complete " + percentComplete.ToString());
                                */
                                Domain.ExactTarget.InvokeE1GeneralNewsLetterRequest newsletterRequest = new Domain.ExactTarget.InvokeE1GeneralNewsLetterRequest();
                                newsletterRequest.UserName = memberName;
                                newsletterRequest.ToEmail = emailAddress;
                                newsletterRequest.PreferredLanguage = Constants.Language_English_US;
                                // newsletterRequest.RequestUrl = whatsthis 
                                newsletterRequest.ProfilePercentCompletePlaceholder = percentComplete.ToString();  // where do i put in the profile percent complete html
                                //bg: this is the actual tag that was in the ET template and needs to be updated.
                                //<img src="img-1.png" style="vertical-align:top;" width="178" height="45" alt="" />


                                 BaseReply mailReply = ExactTargetService.InvokeE1GeneralNewsLetter(newsletterRequest );
                                 if (mailReply.Successful == false)
                                 {
                                     Sitecore.Diagnostics.Log.Debug("Newsletter Send Failed to (" + newsletterRequest.ToEmail + ") Message=" + mailReply.Message);
                                    //todo: log this failure so that this row can be rerun later
                                 }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
               // throw ex;
            }

            Sitecore.Diagnostics.Log.Debug("Scheduled Task ran");

        }

        private static int PercentProfileComplete(Guid MemberId)
        {
            int profileCompleteness = 0;
            MembershipManager mmgr = new MembershipManager();
            mmgr.GetMember(MemberId);
            Member m = mmgr.GetMember(MemberId);
                   
            /*
            
             * Show 0%, if the user has only given us their email. 
             * Show 25%, if the user has entered at least one child. 
             * Show 50%, if the user has a community name. 
             * Show 75%, if the user has entered at least one parent interest. 
             * Show 100%, if the user has completed their full profile.
        
             */

            //just so something is here until we get the rules nailed down 
            //I'm making these rules cumulative, as a score, so we don't 
            //end up with someone who has nothing but a parental interest come back at 75%
            if (m.Children.Count > 0)
            {
                profileCompleteness += 25;
            }
            if(!string.IsNullOrEmpty(m.ScreenName))
            {
                profileCompleteness += 25;
            }
            if (m.Interests.Count > 0)
            {
                profileCompleteness += 25;            
            }
            //not sure what next to add in. What means "complete"? 
            //- maybe if their score is 75, then check to see if they have also updated IEP/504 status questions?
            return profileCompleteness;
          }


    }
}
