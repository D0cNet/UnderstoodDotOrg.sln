using Sitecore.ContentSearch;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;
using System.Net;
using System.Xml;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.Cincopa;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class AudioArticle : BaseSublayout<AudioArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        void rptAudio_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                CincopaItem item = (CincopaItem)e.Item.DataItem;
                HyperLink hlAudio = (HyperLink)e.FindControlAs<HyperLink>("hlAudio");
                hlAudio.NavigateUrl = HttpUtility.HtmlDecode(item.content_url);
                hlAudio.Attributes.Add("data-audio-format", "mp3");
            }
        }

        private void BindContent()
        {
            //Show Reviewer Details
            if (Model.DefaultArticlePage.Reviewedby.Item != null 
                && Model.DefaultArticlePage.ReviewedDate.DateTime != null)
            {
                SBReviewedBy.Visible = true;
            }
            else
            {
                SBReviewedBy.Visible = false;
            }

            phPlayer.Visible = !String.IsNullOrEmpty(Model.CincopaID.Raw);
        }
    }
}
