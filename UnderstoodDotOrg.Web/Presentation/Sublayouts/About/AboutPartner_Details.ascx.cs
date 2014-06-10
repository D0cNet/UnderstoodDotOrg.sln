using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using System.Configuration;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class AboutPartner_Details : BaseSublayout<PartnerInfoItem>
    {
        protected string FacebookUrl { get; set; }
        protected string TwitterUrl { get; set; }
        protected string TwitterLinkText { get; set; }
        protected string FacebookLinkText { get; set; }
        protected string FacebookAppId
        {
            get { return ConfigurationManager.AppSettings[Constants.Settings.FacebookAppId]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            AboutPartnersItem parent = Model.InnerItem.Parent;
            if (parent != null) 
            {
                hlPartnersLanding.NavigateUrl = parent.GetUrl();
                hlPartnersLanding.Text = parent.ContentPage.PageTitle;
            }

            InitFeaturedLink(hlFeaturedFirst, Model.FirstFeaturedItemLink.Url, Model.FirstFeaturedItemTitle.Rendered);
            InitFeaturedLink(hlFeaturedSecond, Model.SecondFeaturedItemLink.Url, Model.SecondFeaturedItemTitle.Rendered);

            FacebookUrl = Model.FacebookUrl.Url;
            FacebookLinkText = Model.FacebookCallToAction.Rendered;
            hlFacebook.NavigateUrl = FacebookUrl;
            phFacebook.Visible = !string.IsNullOrEmpty(FacebookUrl);

            TwitterUrl = Model.TwitterUrl.Url;
            TwitterLinkText = Model.TwitterCallToAction.Rendered;
            hlTwitter.NavigateUrl = TwitterUrl;
            phTwitter.Visible = !string.IsNullOrEmpty(TwitterUrl);
        }

        private void InitFeaturedLink(HyperLink hl, string url, string title)
        {
            hl.NavigateUrl = url;
            hl.Text = title;
            hl.Visible = !string.IsNullOrEmpty(url);
        }
    }
}