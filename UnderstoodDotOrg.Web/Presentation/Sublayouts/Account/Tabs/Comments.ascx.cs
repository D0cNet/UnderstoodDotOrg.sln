using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs
{
    public partial class Comments : BaseSublayout<PublicAccountCommentsItem>
    {
        public List<Child> TempList = new List<Child>();
        public int ListTotal;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var viewMode = Request.QueryString[Constants.VIEW_MODE].IsNullOrEmpty() ? "" : Request.QueryString[Constants.VIEW_MODE];

            string userScreenName = "";

            if (!Request.QueryString[Constants.ACCOUNT_EMAIL].IsNullOrEmpty())
            {
                userScreenName = Request.QueryString[Constants.ACCOUNT_EMAIL];
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }

            var membershipManager = new MembershipManager();
            var thisMember = new Member();
            thisMember = membershipManager.GetMemberByScreenName(userScreenName);
            //var thisUser = membershipManager.GetUser(thisMember.MemberId, true);
            if (IsUserLoggedIn)
            {
                if ((IsUserLoggedIn) && (CommunityHelper.CheckFriendship(CurrentMember.ScreenName, thisMember.ScreenName)) || (((CurrentMember.ScreenName == thisMember.ScreenName) && (viewMode == Constants.VIEW_MODE_FRIEND))))
                {
                    var commentsList = CommunityHelper.ListUserComments(thisMember.ScreenName);

                    if ((commentsList != null) && (commentsList.Count != 0))
                    {
                        rptComments.DataSource = commentsList;
                        rptComments.DataBind();
                    }
                }
                else
                {
                    //redirect to home page
                }
            }
        }

        

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = e.Item.DataItem as Comment;
                if (e.Item.ItemIndex == 0)
                {
                    HtmlGenericControl divUserInfo = (HtmlGenericControl)e.Item.FindControl("divUserInfo");
                    divUserInfo.Visible = true;
                    Literal litUserName = (Literal)e.Item.FindControl("litUserName");
                    litUserName.Text = CurrentMember.ScreenName;
                    Literal litLastUpdated = (Literal)e.Item.FindControl("litLastUpdated");
                    litLastUpdated.Text = item.CommentDate.ToLocalTime().ToString();
                }
                else
                {
                    HtmlGenericControl divComment = (HtmlGenericControl)e.Item.FindControl("divComment");
                    divComment.Attributes["class"] += " offset-6";
                }
                HyperLink hypTitle = (HyperLink)e.Item.FindControl("hypTitle");
                hypTitle.Text = item.CommentTitle;
                hypTitle.NavigateUrl = item.Url;

                Literal litLikes = (Literal)e.Item.FindControl("litLikes");
                litLikes.Text = item.Likes;

                Literal litCommentBody = (Literal)e.Item.FindControl("litCommentBody");
                litCommentBody.Text = Regex.Replace(Regex.Replace(item.Body, @"<[^>]+>|&nbsp;", "").Trim(), @"\s{2,}", " ");

                Literal litTime = (Literal)e.Item.FindControl("litTime");
                litTime.Text = item.PublishedDate;
            }
            
        }
    }
}