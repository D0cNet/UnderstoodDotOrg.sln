using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Helper;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsArticleTopNavigation : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (Session[Constants.SessionBehaviorSearchKey] != null)
            {
                SessionSearchResult ssr = (SessionSearchResult)Session[Constants.SessionBehaviorSearchKey];

                bool hasResults = ssr.Results.Any();

                hlBackToSearch.Visible = phResultNav.Visible = hasResults;

                if (hasResults)
                {
                    Item item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(ssr.Challenge));
                    ChildChallengeItem challenge = item;
                    litSearchChallenge.Text = String.Format("{0} {1}", DictionaryConstants.BackToFragment, challenge.ChallengeName.Text.ToLower());

                    hlBackToSearch.Visible = true;
                    hlBackToSearch.NavigateUrl = FormHelper.GetBehaviorResultsUrl(ssr.Challenge, ssr.Grade);

                    var currentItem = Sitecore.Context.Item;
                    var next = ssr.GetNextResult(currentItem.ID);
                    var prev = ssr.GetPreviousResult(currentItem.ID);

                    PopulateLink(next, hlNext);
                    PopulateLink(prev, hlPrev);

                    phNavLabel.Visible = hlNext.Visible || hlPrev.Visible;
                }
            }
        }

        private void PopulateLink(BehaviorAdvice article, HyperLink hl)
        {
            if (article == null)
            {
                return;
            }

            var item = article.GetItem();
            if (item != null)
            {
                hl.Visible = true;
                hl.NavigateUrl = item.GetUrl();
            }
            else
            {
                hl.Visible = false;
            }
        }
    }
}