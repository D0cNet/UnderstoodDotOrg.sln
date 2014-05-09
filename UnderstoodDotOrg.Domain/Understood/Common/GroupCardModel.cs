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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class GroupCardModel
    {
        public GroupCardModel()
        {
            
        }

        public GroupCardModel(GroupItem groupItem)
        {

            if (groupItem != null)
            {
                GrpItem = groupItem;
                //Poses info
                ///TODO: Ensure that moderator member is in userID
              string userID = GrpItem.UserID.Text;
               // if (!String.IsNullOrEmpty(userID))
               // {
                   UserID = String.IsNullOrEmpty(userID) ? Guid.Empty : new Guid(userID);
                    // MembershipManager mem = new MembershipManager();
                   MembershipManagerProxy mem = new MembershipManagerProxy();
                   

                    Member member = mem.GetMember(UserID);



                
                    GroupID = groupItem.GroupID.Text;

                    var node = CommunityHelper.ReadGroup(GroupID);
                    if (node!=null)
                    {
                        ///TODO: Further refactor to Forum Class
                        NumOfMembers = node.SelectSingleNode("TotalMembers").InnerText;
                        NumOfDiscussions = CommunityHelper.ReadForums(GroupID).ChildNodes.Count.ToString(); //node.SelectSingleNode("ThreadCount").InnerText; ///TODO:Number of Forums
                        Description = node.SelectSingleNode("Description").InnerText;
                        Title = node.SelectSingleNode("Name").InnerText;
                        ModeratorAvatarUrl = node.SelectSingleNode("AvatarUrl").InnerText;//Constants.Settings.AnonymousAvatar;

                        ModeratorTitle = Constants.TelligentRole.Moderator.ToString();
                        ModeratorName = member.ScreenName;
                    }
               // }
            }

        }

        

       

      
        //Poses
        public string ModeratorAvatarUrl { get; set; }
        public string ModeratorName { get; set; }
        private Guid UserID { get; set; }
        List<Child> ChildrenWithIssues { get; set; } //TODO:Related through Group issues
        public string ModeratorTitle { get; set; }
        private List<ForumModel> fModel = null;
        public List<ForumModel> Forums
        {
            get
            {
                if (fModel == null)
                {
                    fModel = CommunityHelper.ReadForumsList(GroupID);
                }
                return fModel;
            }
            set{fModel = value;}
        }

        //Telligent
        public string Title { get; set; }
        public string Description { get; set; } //Group Description
        public string NumOfMembers { get; set; }
        public string NumOfDiscussions { get; set; }
        public string JoinUrl { get; set; } //TODO: point create Group Item
        private string GroupID { get; set; }
        private GroupItem GrpItem { get; set; }
       // List<Issue> RelatedIssues { get; set; }
    }


}
