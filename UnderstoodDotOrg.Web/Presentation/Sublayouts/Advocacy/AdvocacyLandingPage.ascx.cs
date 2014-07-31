using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class AdvocacyLandingPage : BaseSublayout<AdvocacyLandingPageItem>
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            SetupSidebarPromoLink();
            SetupSidebarSignupForm();
        }

        private void SetupSidebarPromoLink()
        {
            // Dynamically handle link to prevent wrapping image in link with no href
            if (!string.IsNullOrEmpty(Model.SidebarPromoLink.Url)
                && Model.SidebarPromoImage.MediaItem != null)
            {
                hlPromo.Visible = true;
                hlPromo.NavigateUrl = Model.SidebarPromoLink.Url;
                Page.Controls.Remove(frPromoImage);
                hlPromo.Controls.Add(frPromoImage);
            }
            else
            {
                hlPromo.Visible = false;
            }
        }

        private void SetupSidebarSignupForm()
        {
            InputAlertSignup.Attributes["placeholder"] = Model.SidebarSignupPlaceholder.Raw;
            SubmitAlertSignup.Text = Model.SidebarSignupButton.Raw;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var globalsItem = MainsectionItem.GetGlobals();
            var advocacyLinks = globalsItem.GetAdvocacyLinksFolder().GetAdvocacyLinks();

            rptArticles.DataSource = this.Model.GetAdvocacyArticles();
            rptArticles.DataBind();

            rptrActionAlerts.DataSource = advocacyLinks;
            rptrActionAlerts.DataBind();
        }

        protected void btnActNow_Click(object sender, EventArgs e)
        {
            var btnActNow = sender as HtmlButton;
            var url = btnActNow.Attributes["data-url"];
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
        }

        protected void SubmitAlertSignup_Click(object sender, EventArgs e)
        {
            var givenEmail = InputAlertSignup.Text;

            //src: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
            string emailGoodEnough = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            if (string.IsNullOrWhiteSpace(givenEmail) || !Regex.IsMatch(givenEmail, emailGoodEnough))
            {
                AddErrorForEmail();
            }
            else
            {
                AddEmailViaConvoApi(givenEmail);
            }
        }

        private void AddEmailViaConvoApi(string validEmail)
        {
            //todo waiting to hear back from NCLD (per bryan)
        }

        private void AddErrorForEmail()
        {
            placeholderError.Visible = true;
            literalSignupError.Text = DictionaryConstants.SomethingFailedError;
        }

        protected void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as AdvocacyArticlePageItem;

            HyperLink hypArticleThumbnailLink = (HyperLink)e.Item.FindControl("hypArticleThumbnailLink");
            hypArticleThumbnailLink.NavigateUrl = item.InnerItem.GetUrl();

            HyperLink hypArticleLink = (HyperLink)e.Item.FindControl("hypArticleLink");
            hypArticleLink.NavigateUrl = item.InnerItem.GetUrl();
            hypArticleLink.Text = item.DefaultArticlePage.ContentPage.BasePageNEW.NavigationTitle.Rendered;

            System.Web.UI.WebControls.Image articleThumbnail = (System.Web.UI.WebControls.Image)e.Item.FindControl("articleThumbnail");
            articleThumbnail.ImageUrl = item.DefaultArticlePage.GetArticleThumbnailUrl(351, 200);
        }

        protected void rptrActionAlerts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                AdvocacyLinkItem item = e.Item.DataItem as AdvocacyLinkItem;

                HyperLink hypLink = (HyperLink)e.Item.FindControl("hypLink");
                HyperLink hypActionTitleLink = (HyperLink)e.Item.FindControl("hypActionTitleLink");
                FieldRenderer frAbstract = (FieldRenderer)e.Item.FindControl("frAbstract");
                FieldRenderer frButtonText = (FieldRenderer)e.Item.FindControl("frButtonText");
                HtmlButton btnActNow = (HtmlButton)e.Item.FindControl("btnActNow");

                if (hypLink != null)
                {
                    hypLink.Text = item.DisplayName;
                    hypLink.NavigateUrl = item.Link;
                    if(!string.IsNullOrEmpty(item.Image.MediaUrl))
                        hypLink.ImageUrl = item.Image.MediaUrl;
                    else
                        hypLink.ImageUrl = String.Format("http://placehold.it/{0}x{1}", 290, 163);
                }

                if (hypActionTitleLink != null)
                {
                    hypActionTitleLink.Text = item.DisplayName;
                    hypActionTitleLink.NavigateUrl = item.Link;
                }

                if (btnActNow != null)
                {
                    btnActNow.Attributes.Add("data-url", item.Link);
                }

                frAbstract.Item = item;
                frButtonText.Item = item;
            }
        }

    }
}