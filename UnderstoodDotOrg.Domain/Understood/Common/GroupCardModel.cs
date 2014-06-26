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

        public GroupCardModel()
        {
            ForumFunc = null;
            Owner = null;
        }
        //public GroupCardModel(GroupItem groupItem)
        //{

        //    if (groupItem != null)
        //    {
        //        GrpItem = groupItem;

        //        GroupID = groupItem.GroupID.Text;
        //        XmlNode node = CommunityHelper.ReadGroup(GroupID);
        //       if(node!=null)
        //         Initialize(node);
              
        //    }

        //}

        //private void Initialize(XmlNode groupNode)
        //{
            
          

        //    if (groupNode != null)
        //    {

        //        ///TODO: Further refactor to Forum Class
        //        NumOfMembers = groupNode.SelectSingleNode("TotalMembers").InnerText;
        //        NumOfDiscussions = CommunityHelper.ReadForums(GroupID).ChildNodes.Count.ToString(); //node.SelectSingleNode("ThreadCount").InnerText; ///TODO:Number of Forums
        //        Description = groupNode.SelectSingleNode("Description").InnerText;
        //        Title = groupNode.SelectSingleNode("Name").InnerText;

               

        //        ModeratorAvatarUrl =groupNode.SelectSingleNode("AvatarUrl").InnerText;//Constants.Settings.AnonymousAvatar;

        //        ModeratorTitle = Constants.TelligentRole.Moderator.ToString();
        //        ModeratorName = "Moderator Screen Name";
        //    }
        //}



        /// <summary>
        /// Function to populate forums
        /// </summary>
        public Func<string, List<ForumModel>> ForumFunc { get; set; }
      
        //Poses
        public string ModeratorAvatarUrl { get; set; }
        public string ModeratorName { get; set; }
        public string ModeratorEmail
        {
            get
            {
                if (Owner != null)
                    return Owner.Email;
                else
                    return String.Empty;
            }
        }
        public string ModeratorBio
        {
            get
            {
                if (Owner != null)
                {
                    return Owner.GetMemberPublicProfile();
                }
                else
                    return String.Empty;
            }
        }
        public Member Owner { get; set; }
       
        List<Child> ChildrenWithIssues { get; set; } //TODO:Related through Group issues
        public string ModeratorTitle { get; set; }
        private List<ForumModel> fModel = null;
        public List<ForumModel> Forums
        {
            get
            {
                if (fModel == null)
                {
                    if (ForumFunc != null)
                        fModel = ForumFunc(GroupID);//CommunityHelper.ReadForumsList(GroupID);
                }
                return fModel;
            }
            set{fModel = value;}
        }

        //Telligent
        public string Title { get; set; }
        public string Description { get; set; } //Group Description
        public string NumOfMembers { get; set; }
        public string NumOfDiscussions
        {
            get
            {
                if (Forums != null)
                    return Forums.Select(x => x.Threads.Count()).Sum().ToString();
                else
                    return "0";
            }
        }
        public string JoinUrl { get; set; } //TODO: point create Group Item
        public string GroupID { get { return GrpItem.GroupID; } }
       // public string GroupItemID { get { return GrpItem.ID.ToString(); } }
        public string TemplateID { get { return GrpItem.InnerItem.TemplateID.ToString(); } }
        public GroupItem GrpItem { get; set; }
        public string ItemID { get { return GrpItem.ID.ToString(); } } 
       // List<Issue> RelatedIssues { get; set; }
    }


}
