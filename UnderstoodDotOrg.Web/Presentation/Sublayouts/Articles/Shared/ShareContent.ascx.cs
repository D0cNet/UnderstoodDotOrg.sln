using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class ShareContent : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null && DataSource.InheritsFromType(ContentPageItem.TemplateId))
            {
                BindData((ContentPageItem)DataSource);
            }
        }

        private void BindData(ContentPageItem page)
        {
            hlFacebook.NavigateUrl = SocialHelper.GetFacebookShareUrl(page);
            ltlFacebook.Text = DictionaryConstants.SocialSharingFacebook;

            hlGooglePlus.NavigateUrl = SocialHelper.GetGooglePlusShareUrl(page);
            ltlGooglePlus.Text = DictionaryConstants.SocialSharingGooglePlus;

            hlTwitter.NavigateUrl = SocialHelper.GetTwitterShareUrl(page, page.PageTitle.Raw);
            ltlTwitter.Text = DictionaryConstants.SocialSharingTwitter;
        }
    }
}