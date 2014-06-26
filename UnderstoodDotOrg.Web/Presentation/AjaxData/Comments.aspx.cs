using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class Comments : System.Web.UI.Page
    {
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }
        private string BlogId
        {
            get { return Request.QueryString["blog"] ?? String.Empty; }
        }
        private string PostId
        {
            get { return Request.QueryString["post"] ?? String.Empty; }
        }
        private string SortBy
        {
            get { return Request.QueryString["sortBy"] ?? String.Empty; }
        }
        private string IsAscending
        {
            get { return Request.QueryString["ascending"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;
            bool isAscending = IsAscending == "1";

            // Temp
            string sortBy = "CreatedUtcDate";

            if (int.TryParse(ResultPage, out page))
            {
                int pageSize = Constants.ARTICLE_COMMENTS_PER_PAGE;
                int totalResults;
                bool hasMoreResults;

                var comments = CommunityHelper.ReadComments(BlogId, PostId, page, pageSize, sortBy, isAscending, out totalResults, out hasMoreResults);

                if (comments.Any())
                {
                    commentsControl.Comments = comments;
                    phMoreResults.Visible = hasMoreResults;
                }
            }
        }
    }
}