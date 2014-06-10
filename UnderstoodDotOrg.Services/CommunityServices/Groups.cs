using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;

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
           results = grps.Select(x => new GroupCardModel(new GroupItem(x))).ToList<GroupCardModel>();


           return results;
       }
       public static List<GroupCardModel> FindGroups()
       {
           return FindGroups(new string[0],new string[0],new string[0],new string[0],new string[0]);
       }

   }
}
