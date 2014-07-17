using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupDiscussionList : BaseSublayout//System.Web.UI.UserControl
    {
        protected void rptDiscussionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem is ReplyModel)
                {
                    var item = e.Item.DataItem as ReplyModel;

                    var ProfileCommentCard = e.FindControlAs<ProfileCommentCard>("ProfileCommentCard");
                    if (ProfileCommentCard != null)
                    {
                        ProfileCommentCard.Member = item.Author;
                    }

                    LikeButton btnLikes = e.FindControlAs<LikeButton>("btnLikes");
                    if (btnLikes != null)
                    {
                       // btnLikes.ContentId = item.ContentId;
                      //  btnLikes.ContentTypeId=item.ContentTypeId;
                        btnLikes.LoadState(item.ContentId, item.ContentTypeId);
                        
                    }

                    ThanksButton btnThanks = e.FindControlAs<ThanksButton>("btnThanks");
                    ThinkingOfYouButton btnThink = e.FindControlAs<ThinkingOfYouButton>("btnThinkingOfYou");

                    if (btnThanks != null && btnThink != null)
                    {
                        if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
                        {
                            if (!String.IsNullOrEmpty(item.Author.UserName))
                            {
                                btnThanks.LoadState(item.Author.UserName);
                                btnThink.LoadState(item.Author.UserName);
                            }
                        }
                    }
                }
            }
        }

        public override void DataBind()
        {
            rptDiscussionList.DataBind();
        }

        public List<ReplyModel> DataSource
        {
            set
            {
                rptDiscussionList.DataSource = value;
            }
            get
            {
                return rptDiscussionList.DataSource as List<ReplyModel>;
            }
        }
    }
}