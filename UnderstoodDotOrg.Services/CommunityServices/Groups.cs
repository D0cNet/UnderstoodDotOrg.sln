using Sitecore.Data;
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
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.TelligentService;
namespace UnderstoodDotOrg.Services.CommunityServices
{
   public static class Groups
    {
       /// <summary>
       /// Function to return a list of GroupModels based on the search criteria for Groups
       /// </summary>
       /// <param name="issues"></param>
       /// <param name="topic"></param>
       /// <param name="grade"></param>
       /// <param name="states"></param>
       /// <param name="partner"></param>
       /// <returns></returns>
       public static List<GroupCardModel> FindGroups(string[] issues, string[] topics, string[] grades, string[] states, string[] partners)
       {
           List<GroupCardModel> results = new List<GroupCardModel>();
           StringBuilder strb = new StringBuilder();
           StringBuilder strValues = new StringBuilder();
           //if (Session["groupItems"] is List<GroupCardModel>)
           //{

           //    //throw new NotImplementedException();
           //    ///TODO: Implement search results
           //    results=(List<GroupCardModel>)Session["groupItems"] ;
           //}
           strb.Append("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Groups.GroupTemplateID + "'");
           string AndCondition = " and (";
           string OrCondition = " or ";
           if ((issues.Count() > 0) || topics.Count() >0 ||grades.Count() >0 || states.Count()>0 || partners.Count()>0)
           {

               strValues.Append(AndCondition);

               //Build search string based on parameters
               //Order matters according to Speckle UN-595
               foreach (string issue in issues)
               {

                   strValues.Append(" @Issues= '%" + issue + "%'").Append(OrCondition);

               }


               foreach (string grade in grades)
               {

                   strValues.Append(" @Grades= '%" + grade + "%'").Append(OrCondition);
               }

               foreach (string topic in topics)
               {

                   strValues.Append(" @Topic= '%" + topic + "%'").Append(OrCondition);
               }

               foreach (string state in states)
               {

                   strValues.Append(" @States= '%" + state + "%'").Append(OrCondition);
               }


               foreach (string partner in partners)
               {

                   strValues.Append(" @Partners= '%" + partner + "%'").Append(OrCondition);
               }

               //Clip " or " from last criteria
               strValues.Replace(OrCondition,")",strValues.Length-OrCondition.Length,OrCondition.Length);
           }

           strb.Append(strValues).Append("]") ;
           
           //Use sitecore fast query to perform search
           Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("web");
           Item[] grps = masterDb.SelectItems(strb.ToString());
           results = grps.Select(x => GroupCardModelFactory(new GroupItem(x))).OrderByDescending(x => x.NumOfMembers).ToList<GroupCardModel>();


           return results;
       }
       public static List<GroupCardModel> FindGroups()
       {
           return FindGroups(new string[0],new string[0],new string[0],new string[0],new string[0]);
       }
       public static Item ConvertGroupIDtoSitecoreItem(string id)
       {
           Item groupItem = null;
           Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
           groupItem = masterDb.SelectSingleItem("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Groups.GroupTemplateID + "' and @GroupID = '" + id + "']");

           return groupItem;
       }
       public static GroupCardModel GroupCardModelFactory(GroupItem grpItem)
       {
           Member owner = null;
           GroupCardModel grpModel = new GroupCardModel();
           if ((grpItem != null))
           {

               string address = String.Empty;
                string xml=String.Empty;
                   try
                   {
                       using (WebClient client = new WebClient())
                       {
                           client.Headers.Add("Rest-User-Token", TelligentService.TelligentService.TelligentAuth());
                           address = string.Format(TelligentService.TelligentService.GetApiEndPoint("groups/{0}/members/users.xml?MembershipType=Owner"), grpItem.GroupID.Text);

                           ///Approved??
                           //data["FriendshipState"] = Constants.TelligentFriendStatus.Approved.ToString();
                          xml = Encoding.UTF8.GetString(client.DownloadData(address));
                       }
                       XmlDocument document = new XmlDocument();
                       document.LoadXml(xml);
                       XmlNode childNode = document.SelectSingleNode("Response/Users");
                       if (childNode != null)
                       {
                           //Select first owner
                           string username = childNode.FirstChild.SelectSingleNode("Username").InnerText;
                           MembershipManager mem = new MembershipManager();
                           owner = mem.GetMemberByScreenName(username);
                           if (owner != null)
                           {
                               grpModel.ModeratorAvatarUrl = childNode.FirstChild.SelectSingleNode("AvatarUrl").InnerText;
                               grpModel.ModeratorName = owner.ScreenName;
                               grpModel.ModeratorTitle = Constants.TelligentRoles.Roles[Constants.TelligentRoles.Moderator];
                               grpModel.Owner = owner;
                           }
                           else //Use default values
                           {
                               grpModel.ModeratorAvatarUrl = childNode.FirstChild.SelectSingleNode("AvatarUrl").InnerText;
                               grpModel.ModeratorName = username;
                               grpModel.ModeratorTitle = Constants.TelligentRoles.Roles[Constants.TelligentRoles.Moderator];
                            }
                           grpModel.ForumFunc = TelligentService.TelligentService.ReadForumsList;
                          
                           grpModel.GrpItem = grpItem;
                           grpModel.NumOfMembers = int.Parse(childNode.FirstChild.SelectSingleNode("Group/TotalMembers").InnerText);
                           grpModel.Description = childNode.FirstChild.SelectSingleNode("Group/Description").InnerText;
                           grpModel.Title = childNode.FirstChild.SelectSingleNode("Group/Name").InnerText;
                           
                       }
                   }
                   catch (Exception ex)
                   {
                       Sitecore.Diagnostics.Error.LogError("Error in GetGroupOwner function.\nError:\n" + ex.Message);
                       grpModel = null;
                   }
              
           }
           return grpModel;
       }
   }
}
