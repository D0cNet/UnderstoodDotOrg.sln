using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Services;
using UnderstoodDotOrg.Services.TelligentService;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;
            int sortBy;

            if (int.TryParse(ResultPage, out page) && int.TryParse(SortBy, out sortBy))
            {
                int pageSize = Constants.ARTICLE_COMMENTS_PER_PAGE;
                int totalResults;
                bool hasMoreResults;

                var sortOptions = CommunityHelper.GetCommentSortOptions();
                CommentSortOption sortOption = null;
                try
                {
                    sortOption = sortOptions[sortBy];
                }
                catch
                {
                    return;
                }

                // Fallback for no sorting
                if (sortBy == 0)
                {
                    sortOption = new CommentSortOption
                    {
                        Value = Constants.TelligentCommentSort.CreateDate,
                        SortAscending = true
                    };
                }

                var comments = TelligentService.ReadComments(BlogId, PostId, page, pageSize, sortOption, out totalResults, out hasMoreResults);

                if (comments.Any())
                {
                    commentsControl.Comments = comments;
                    phMoreResults.Visible = hasMoreResults;
                }
            }
        }
    }
}