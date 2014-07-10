using System;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Author_Bio : BaseSublayout<AuthorItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            imgExpert.ImageUrl = Model.GetThumbnailUrl(189, 189);
        }
    }
}