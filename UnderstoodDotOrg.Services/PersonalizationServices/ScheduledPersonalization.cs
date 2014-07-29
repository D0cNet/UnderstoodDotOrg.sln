using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Personalization;
namespace UnderstoodDotOrg.Services.PersonalizationServices
{


    public static class ScheduledPersonalization
    {

        public static void RunPersonalizationUpdate()
        {
            Sitecore.Diagnostics.Log.Debug("Scheduled Daily Personaliztion Update Starting." + DateTime.Now.ToString());
            try
            {
                string sql = "SELECT DISTINCT [ChildId] FROM [dbo].[PersonalizedContent] ";//GET all of the children in the system who already have personalized content

                  using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                  {
                      conn.Open();
                      using (SqlCommand cmd = new SqlCommand(sql, conn))
                      {
                
                          SqlDataReader reader = cmd.ExecuteReader();
                          if (reader.HasRows)
                          {
                             Guid childId = new Guid();
                              while (reader.Read())
                              {
                                  childId= reader.GetGuid(0);
                                  PersonalizationHelper.RefreshAndSavePersonalizedContent(childId);
                                  Sitecore.Diagnostics.Log.Debug("Finished Processing Personalization for Child: " + 
                                      childId.ToString() + " [" + DateTime.Now.ToShortDateString() +"]");
                              }
                          }
                      }
                  }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Debug("**** Error thrown while refreshing personalized content. **** " + Environment.NewLine 
                    + "Message: " +ex.Message + Environment.NewLine + 
                        "Stack Trace:" + ex.StackTrace );
        
            }
            Sitecore.Diagnostics.Log.Debug("Scheduled Daily Personaliztion Update Ending." + DateTime.Now.ToString());
     
        }
    }
}
