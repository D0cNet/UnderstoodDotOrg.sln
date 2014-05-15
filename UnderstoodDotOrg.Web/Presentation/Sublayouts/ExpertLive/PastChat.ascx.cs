using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class PastChat : System.Web.UI.UserControl
    {
        ChatEventPageItem ContextItem = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    ShowCommentOnChat();
                    this.Visible = true;
                }
                else {
                    this.Visible = false;
                }
            }
        }

        private void ShowCommentOnChat() {
            PageResourceFolderItem pageResourceFolder = ContextItem.GetPageResourceFolderItem();
            if (pageResourceFolder != null) {
                var results = pageResourceFolder.GetCommentItems();
                if (results != null && results.Any()) {
                    rptComments.DataSource = results;
                    rptComments.DataBind();
                }
            }
        }

        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem != null) {
                if (baseEventPageItem.EventDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }

        protected void rptComments_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                CommentItem commentItem = e.Item.DataItem as CommentItem;

                if (commentItem != null) {
                    FieldRenderer frTitle = e.FindControlAs<FieldRenderer>("frTitle");
                    FieldRenderer frContent = e.FindControlAs<FieldRenderer>("frContent");
                    if (frTitle != null) {
                        frTitle.Item = commentItem;
                    }

                    if (frContent != null) {
                        frContent.Item = commentItem;
                    }
                }
            }
        }
    }
}