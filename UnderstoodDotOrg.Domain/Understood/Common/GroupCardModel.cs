using Sitecore.Configuration;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class GroupCardModel
    {
        public GroupCardModel()
        {
            
        }

        public GroupCardModel(Item groupItem)
        {

            if (groupItem != null)
            {
                //Poses info
                ///TODO: Ensure that moderator member is in userID
                string userID = groupItem.Fields["UserID"].ToString();
                UserID = new Guid(userID);

                MembershipManager mem= new MembershipManager();

                Member member = mem.GetMember(UserID);

                ModeratorAvatarUrl = Constants.Settings.AnonymousAvatar;
              
                ModeratorTitle = Constants.TelligentRole.Moderator.ToString();
                ModeratorName = member.ScreenName;
                TelligentGroupID = groupItem.Fields["TelligentGroupID"].ToString();
                GroupID = groupItem.Fields["GroupID"].ToString();

                //Telligent Forum info
                var webClient = new WebClient();
                string keyTest = Settings.GetSetting(Constants.Settings.TelligentAdminApiKey);
                var apiKey = String.IsNullOrEmpty(keyTest) ? "d956up05xiu5l8fn7wpgmwj4ohgslp" : keyTest;
           
                // replace the "admin" and "Admin's API key" with your valid user and apikey!
                var adminKey = String.Format("{0}:{1}", apiKey, "admin");
                var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), GroupID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                var node = xmlDoc.SelectSingleNode("Response/Forum");
                ///
                NumOfMembers = node.SelectSingleNode("//Group/TotalGroupMembers").InnerText;
                NumOfDiscussions = node.SelectSingleNode("//Group/ThreadCount").InnerText;
                Quote = node.SelectSingleNode("//Group/Description").InnerText;
                Title = node.SelectSingleNode("/Title").InnerText;
            }

        }

      
        //Poses
        public string ModeratorAvatarUrl { get; set; }
        public string ModeratorName { get; set; }
        private Guid UserID { get; set; }
        List<Child> ChildrenWithIssues { get; set; } //TODO:Related through Group issues
        public string ModeratorTitle { get; set; }

        //Telligent
        public string Title { get; set; }
        public string Quote { get; set; } //Group Description
        public string NumOfMembers { get; set; }
        public string NumOfDiscussions { get; set; }
        public string JoinUrl { get; set; } //TODO: point create Group Item
        private string TelligentGroupID { get; set; }
        private string GroupID { get; set; }
      
       // List<Issue> RelatedIssues { get; set; }
    }


}
