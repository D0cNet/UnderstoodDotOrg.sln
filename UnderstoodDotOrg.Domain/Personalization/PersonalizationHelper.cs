using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Personalization;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Domain.Personalization
{
    public class PersonalizationHelper
    {
        private static IOrderedQueryable<PersonalizedContent> GetOrderedChildContent(PersonalizationContext dataContext, Child child)
        {
            return from entry in dataContext.PersonalizedContent
                   where entry.ChildId == child.ChildId
                   orderby entry.DisplayOrder
                   select entry;
        }

        public static List<DefaultArticlePageItem> GetChildPersonalizedContents(Child child)
        {
            List<DefaultArticlePageItem> results = new List<DefaultArticlePageItem>();

            using (var pc = new PersonalizationContext(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.ConnectionStringMembership].ConnectionString))
            {
                var guids = from c in GetOrderedChildContent(pc, child)
                            where c.ContentId != Constants.ContentItem.PersonalizedContentNotFound
                            select c.ContentId;

                foreach (Guid g in guids)
                {
                    var item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(g));
                    if (item != null)
                    {
                        results.Add(new DefaultArticlePageItem(item));
                    }
                }
            }

            return results;
        }

        public static void SavePersonalizedContent(Member member, Child child, List<Article> articles)
        {
            using (var pc = new PersonalizationContext(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.ConnectionStringMembership].ConnectionString))
            {
                var results = GetOrderedChildContent(pc, child);

                if (!results.Any())
                {
                    return;
                }

                int i = 0;
                foreach (var r in results)
                {
                    Article article = articles.ElementAtOrDefault(i);
                    if (article == null)
                    {
                        // Not found id
                        r.ContentId = Constants.ContentItem.PersonalizedContentNotFound;
                    }
                    else
                    {
                        r.ContentId = Guid.Parse(article.ItemId.ToString());
                    }
                    r.DateModified = DateTime.Now;
                    i++;
                }

                try
                {
                    pc.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(
                        String.Format("Error saving personalization to database for child", child.ChildId.ToString()), ex);
                }
            }
        }
    }
}
