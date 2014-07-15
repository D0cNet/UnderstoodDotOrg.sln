using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class ForumModel
    {
        Func<string,List<ThreadModel>> readThreadFunc;

        public ForumModel(ForumItem forumItem,Func<string,List<ThreadModel>> readThreads)
        {
            ForumID = forumItem.ForumID.Text;
            GroupID = forumItem.GroupID.Text;
            Description = forumItem.Description.Text;
            Name = forumItem.InnerItem.Name;// Name.Text;
            readThreadFunc = readThreads;
        }

        public ForumModel(System.Xml.XmlNode childNode, Func<string, List<ThreadModel>> readThreads)
        {
            // TODO: Complete member initialization
           // this.childNode = childNode;
            ForumID = childNode.SelectSingleNode("Id").InnerText;
            Name = childNode.SelectSingleNode("Name").InnerText;
           // Description = childNode.SelectSingleNode("Description").ToString();
            GroupID = childNode.SelectSingleNode("Group/Id").InnerText;
            readThreadFunc = readThreads;
        }

        public string ForumID { get; set; }
        public string GroupID { get; set; }
        private List<ThreadModel> thModel=null;
        private System.Xml.XmlNode childNode;
        public string Description { get; set; }
        public string Name { get; set; }
        public string ThreadCount
        {
            get
            {
                if (this.thModel == null)
                {
                    return Threads.Count.ToString();
                }
                else
                    return thModel.Count.ToString();
            }
        }
        public static string TemplateID { get { return UnderstoodDotOrg.Common.Constants.Forums.ForumTemplateID; } }
        public List<ThreadModel> Threads
        {
            get
            {
                if (thModel == null)
                {
                    thModel = readThreadFunc(ForumID);  //CommunityHelper.ReadThreadList(ForumID);

                }
               

                return thModel;
            }
        }


    }
}
