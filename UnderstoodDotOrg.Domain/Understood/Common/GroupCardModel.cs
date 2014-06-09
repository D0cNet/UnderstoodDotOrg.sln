using Sitecore.Configuration;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class GroupCardModel
    {
        ///TODO: To populate sitecore object from Telligent XmlNode
        //public GroupCardModel(XmlNode grpNode)
        //{
        //    if (grpNode != null)
        //    {
        //        GroupID = grpNode.SelectSingleNode("Id").InnerText;
        //        Initialize(grpNode);
        //    }
        //}

        public GroupCardModel(GroupItem groupItem)
        {

            if (groupItem != null)
            {
                GrpItem = groupItem;

                GroupID = groupItem.GroupID.Text;
                XmlNode node = CommunityHelper.ReadGroup(GroupID);
               if(node!=null)
                 Initialize(node);
              
            }

        }

        private void Initialize(XmlNode groupNode)
        {
            
          

            if (groupNode != null)
            {

                ///TODO: Further refactor to Forum Class
                NumOfMembers = groupNode.SelectSingleNode("TotalMembers").InnerText;
                NumOfDiscussions = CommunityHelper.ReadForums(GroupID).ChildNodes.Count.ToString(); //node.SelectSingleNode("ThreadCount").InnerText; ///TODO:Number of Forums
                Description = groupNode.SelectSingleNode("Description").InnerText;
                Title = groupNode.SelectSingleNode("Name").InnerText;
                ModeratorAvatarUrl = groupNode.SelectSingleNode("AvatarUrl").InnerText;//Constants.Settings.AnonymousAvatar;

                ModeratorTitle = Constants.TelligentRole.Moderator.ToString();
                ModeratorName = "Moderator Screen Name";
            }
        }

        

       

      
        //Poses
        public string ModeratorAvatarUrl { get; set; }
        public string ModeratorName { get; set; }
        ///TODO:Get group moderator screen name
        private string UserID
        {
            get
            {
                return String.Empty;
            }
            //get
            //{
            //    var mem = (Member)HttpContext.Current.Session[Constants.currentMemberKey];
            //    if (mem != null)
            //        return mem.ScreenName;
            //    else
            //    {

            //        MembershipManagerProxy memprov = new MembershipManagerProxy();
            //        Member member = memprov.GetMember(Guid.Empty);
            //        HttpContext.Current.Session["username"] = member.ScreenName;
            //        return member.ScreenName;
                    
            //    }
            //}
        }
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
        public  string GroupID { get; protected set; }
        public string GroupItemID { get { return GrpItem.ID.ToString(); } }
        public string TemplateID { get { return Constants.Groups.GroupTemplateID; } }
        private GroupItem GrpItem { get; set; }
        public string ItemID { get { return GrpItem.ID.ToString(); } } 
       // List<Issue> RelatedIssues { get; set; }
    }


}
