using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve {
    public partial class PastChat : System.Web.UI.UserControl {
        ChatEventPageItem ContextItem = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e) {
            BaseEventDetailPageItem baseEventDetailpage = new BaseEventDetailPageItem(ContextItem);
            ExpertDetailPageItem expert = baseEventDetailpage.Expert.Item;

            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    ShowCommentOnChat();
                    this.Visible = true;
                }
                else {
                    this.Visible = false;
                }
            }

            if (!Page.IsPostBack) {

                if (ContextItem != null) {
                    if (frPageTitle != null) {

                        frPageTitle.Item = ContextItem;
                    }
                    if (hlLink != null) {
                        hlLink.NavigateUrl = expert.InnerItem.GetUrl();
                    }
                    FieldRenderer scThumbImg = FindControl("scThumbImg") as FieldRenderer;
                    if (expert != null && expert.ExpertImage.MediaItem != null && scThumbImg != null) {
                        scThumbImg.Item = expert.InnerItem;
                    }
                    else {
                        imgExpertDefault.Visible = true;
                    }
                    if (litGuest != null) {
                        litGuest.Text = expert.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                    }

                    if (ltEventDate != null && !baseEventDetailpage.EventDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = baseEventDetailpage.Timezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }

                        ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventDetailpage.EventDate.DateTime.ToString("ddd MMM dd"), baseEventDetailpage.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }

                    if (frHeading != null) {
                        frHeading.Item = ContextItem;
                    }
                    if (frSubHeading != null) {
                        frSubHeading.Item = ContextItem;
                    }
                    if (frBodyContent != null) {
                        frBodyContent.Item = ContextItem;
                    }
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

        //ChatEventPageItem ContextItem = Sitecore.Context.Item;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (ContextItem != null) {
        //        if (IsArchiveItem(ContextItem)) {
        //            ShowCommentOnChat();
        //            this.Visible = true;
        //        }
        //        else {
        //            this.Visible = false;
        //        }
        //    }
        //}

        //private void ShowCommentOnChat() {
        //    PageResourceFolderItem pageResourceFolder = ContextItem.GetPageResourceFolderItem();
        //    if (pageResourceFolder != null) {
        //        var results = pageResourceFolder.GetCommentItems();
        //        if (results != null && results.Any()) {
        //            rptComments.DataSource = results;
        //            rptComments.DataBind();
        //        }
        //    }
        //}

        //private bool IsArchiveItem(Item item) {
        //    bool isArchiveItem = false;
        //    BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
        //    if (baseEventPageItem != null) {
        //        if (baseEventPageItem.EventDate.DateTime < DateTime.Today) {
        //            isArchiveItem = true;
        //        }
        //    }

        //    return isArchiveItem;
        //}

        //protected void rptComments_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e) {
        //    if (e.IsItem()) {
        //        CommentItem commentItem = e.Item.DataItem as CommentItem;

        //        if (commentItem != null) {
        //            FieldRenderer frTitle = e.FindControlAs<FieldRenderer>("frTitle");
        //            FieldRenderer frContent = e.FindControlAs<FieldRenderer>("frContent");
        //            if (frTitle != null) {
        //                frTitle.Item = commentItem;
        //            }

        //            if (frContent != null) {
        //                frContent.Item = commentItem;
        //            }
        //        }
        //    }
        //}
    }
}