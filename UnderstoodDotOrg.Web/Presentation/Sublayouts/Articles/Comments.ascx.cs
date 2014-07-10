using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;
using System.Web.UI.HtmlControls;
//using UnderstoodDotOrg.Services.AccessControlServices;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : BaseSublayout
    {
        protected string BlogId
        {
            get { return _blogId.ToString(); }
        }
        protected string BlogPostId
        {
            get { return _blogPostId.ToString(); }
        }
        protected string AjaxPath
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.CommentsListEndpoint); }
        }
        protected string ContentServicePath
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.ContentServiceEndpoint); }
        }

        private int _blogId = 0;
        private int _blogPostId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;

            // TODO: convert to dictionary -- Done
            txtComment.Attributes.Add("placeholder", DictionaryConstants.Articles_AddCommentText);

            Item currentItem = Sitecore.Context.Item;

            // TODO: refactor so pages all inherit a shared template item type
            var fieldBlogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId];
            var fieldBlogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId];
            rfvComment.ErrorMessage = DictionaryConstants.CommentErrorMessage;

            if (fieldBlogId == null || fieldBlogPostId == null)
            {
                LogMissingCommentFields();
                this.Visible = false;
                return;
            }

            string blogId = fieldBlogId.Value ?? String.Empty;
            string blogPostId = fieldBlogPostId.Value ?? String.Empty;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId))
            {
                LogMissingCommentFields();
                this.Visible = false;
                return;
            }

            if (Int32.TryParse(blogId, out _blogId) && Int32.TryParse(blogPostId, out _blogPostId))
            {
                if (!IsPostBack)
                {
                    PopulateSortOptions();
                    PopulateComments();
                }
            }
        }

        private void PopulateSortOptions()
        {
            var options = CommunityHelper.GetCommentSortOptions();
            if (options.Any())
            {
                rptSortOptions.DataSource = options;
                rptSortOptions.DataBind();
            }
        }

        private void LogMissingCommentFields()
        {
            Sitecore.Diagnostics.Log.Info(
                    String.Format("Item missing blog/blogpost values for comments, {0}", Sitecore.Context.Item.ID), this);
        }

        private void PopulateComments()
        {
            bool hasMoreResults;
            int totalComments;

            List<UnderstoodDotOrg.Services.Models.Telligent.Comment> dataSource = TelligentService.ReadComments(
                _blogId.ToString(), _blogPostId.ToString(), 1, Constants.ARTICLE_COMMENTS_PER_PAGE, "CreatedUtcDate", true, out totalComments, out hasMoreResults);
            commentsControl.Comments = dataSource;

            pnlShowMore.Visible = hasMoreResults;

            litCommentCount.Text = totalComments.ToString();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            //this.ProfileRedirect(Constants.UserPermission.CommunityUser);

            if (CurrentMember.ScreenName.IsNullOrEmpty())
            {
                Sitecore.Diagnostics.Log.Error(
                    String.Format("Member has empty screen name, member id: {0}", CurrentMember.MemberId), this);
            }

            if (TelligentService.PostComment(_blogId, _blogPostId, txtComment.Text.Trim(), CurrentMember.ScreenName))
            {
                PopulateComments();
            }
            else
            {
                // TODO: display error;
            }
        }
    }
}