using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ShareAndSaveTool : BaseSublayout
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
            hlFacebook.Text = DictionaryConstants.SocialSharingFacebook;

            hlGooglePlus.NavigateUrl = SocialHelper.GetGooglePlusShareUrl(page);
            hlGooglePlus.Text = DictionaryConstants.SocialSharingGooglePlus;

            hlTwitter.NavigateUrl = SocialHelper.GetTwitterShareUrl(page, page.PageTitle.Raw);
            hlTwitter.Text = DictionaryConstants.SocialSharingTwitter;
        }
    }
}