using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class UserComments : System.Web.UI.Page
    {
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }
        private string ScreenName
        {
            get { return Request.QueryString["screenName"] ?? String.Empty; }
        }
        private string Lang
        {
            get { return Request.QueryString["lang"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;
            Sitecore.Globalization.Language language;

            if (Sitecore.Globalization.Language.TryParse(Lang, out language))
            {
                Sitecore.Context.SetLanguage(language, false);
            }

            if (int.TryParse(ResultPage, out page))
            {
                int totalComments;

                var comments = TelligentService.GetUserCommentsByScreenName(ScreenName, page, Constants.PUBLIC_PROFILE_COMMENTS_PER_PAGE, out totalComments);
                ucCommentList.Comments = comments;

                phMoreResults.Visible = ((page - 1) * Constants.PUBLIC_PROFILE_COMMENTS_PER_PAGE) + comments.Count() < totalComments;
            }
        }
    }
}