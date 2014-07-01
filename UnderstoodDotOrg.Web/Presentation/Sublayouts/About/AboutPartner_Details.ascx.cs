using System;
using System.Linq;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;

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

            pnlNewsletter.Visible = Model.PartnerNewsletterLink.Url.IsNullOrEmpty();
            pnlDonate.Visible = Model.PartnerDonationLink.Url.IsNullOrEmpty();

            // Featured links
            var collections = new List<dynamic>();

            if (!Model.FirstFeaturedItemLink.Url.IsNullOrEmpty())
            {
                collections.Add(new { Url = Model.FirstFeaturedItemLink.Url, Title = Model.FirstFeaturedItemTitle.Rendered });
            }
            if (!Model.SecondFeaturedItemLink.Url.IsNullOrEmpty())
            {
                collections.Add(new { Url = Model.SecondFeaturedItemLink.Url, Title = Model.SecondFeaturedItemTitle.Rendered });
            }

            if (collections.Any())
            {
                rptFeatured.DataSource = collections;
                rptFeatured.DataBind();
            }

            FacebookUrl = Model.FacebookUrl.Url;
            FacebookLinkText = Model.FacebookCallToAction.Rendered;
            hlFacebook.NavigateUrl = FacebookUrl;
            phFacebook.Visible = !string.IsNullOrEmpty(FacebookUrl);

            TwitterUrl = Model.TwitterUrl.Url;
            TwitterLinkText = Model.TwitterCallToAction.Rendered;
            hlTwitter.NavigateUrl = TwitterUrl;
            phTwitter.Visible = !string.IsNullOrEmpty(TwitterUrl);
        }
    }
}