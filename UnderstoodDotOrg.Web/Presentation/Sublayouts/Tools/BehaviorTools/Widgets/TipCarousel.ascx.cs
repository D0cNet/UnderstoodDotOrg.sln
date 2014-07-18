using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets
{
    public partial class TipCarousel : BaseSublayout
    {
        protected int StartSlideIndex { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            rptTips.ItemDataBound += rptTips_ItemDataBound;
        }

        void rptTips_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                BehaviorAdvicePageItem item = (BehaviorAdvicePageItem)e.Item.DataItem;
                HyperLink hlTip = e.FindControlAs<HyperLink>("hlTip");
                hlTip.NavigateUrl = item.GetUrl();
                hlTip.Text = item.TipTitle;
            }
        }

        private void BindControls()
        {
            if (Session[Constants.SessionBehaviorSearchKey] == null)
            {
                return;
            }

            SessionSearchResult ssr = (SessionSearchResult)Session[Constants.SessionBehaviorSearchKey];

            bool hasResults = ssr.Results.Any();
   
            if (hasResults)
            {
                List<BehaviorAdvice> results = ssr.GetResultsExcluding(Sitecore.Context.Item.ID);
                if (!results.Any()) 
                {
                    return;
                }

                var tips = results
                    .Select(r => r.GetItem())
                    .Where(item => item != null)
                    .Select(item => (BehaviorAdvicePageItem)item);

                if (tips.Any())
                {
                    var currentTipIdIndexMapping = tips
                        .Select((item, i) => new
                        {
                            Id = item.ID,
                            Index = i
                        })
                        .FirstOrDefault(iid => iid.Id == Sitecore.Context.Item.ID);

                    StartSlideIndex = currentTipIdIndexMapping != null ? currentTipIdIndexMapping.Index : 0;

                    rptTips.DataSource = tips;
                    rptTips.DataBind();
                }
            }
            
        }
    }
}