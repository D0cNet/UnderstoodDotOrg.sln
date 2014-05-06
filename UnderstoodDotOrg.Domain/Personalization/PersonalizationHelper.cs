using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Domain.Personalization
{
    public class PersonalizationHelper
    {
        public static void SavePersonalizedContent(Member member, Child child, List<Article> articles)
        {
            using (var pc = new PersonalizationContext(System.Configuration.ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
            {
                var results = from entry in pc.PersonalizedContent
                              where entry.ChildId == child.ChildId
                              orderby entry.DisplayOrder
                              select entry;

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
