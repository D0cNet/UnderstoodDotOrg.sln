using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupDiscussionList : BaseSublayout//System.Web.UI.UserControl
    {
        public override void DataBind()
        {
            rptDiscussionList.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

        //    Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
        //    if (childIssues_repeater != null)
        //    {
        //        childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
        //        childIssues_repeater.DataBind();
        //    }
        //}
        protected void rptDiscussionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem is ReplyModel)
            {
                var item = e.Item.DataItem as ReplyModel;

                var ProfileCommentCard = e.FindControlAs<ProfileCommentCard>("ProfileCommentCard");
                if (ProfileCommentCard != null)
                {
                    ProfileCommentCard.Member = item.Author;

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

                    //if (btnThink != null)
                    //{
                    //    btnThink.LoadState(recipientScreenName);
                    //}
                }


                //HtmlAnchor hrefName = e.FindControlAs<HtmlAnchor>("hrefName");
                //if (hrefName != null)
                //{
                //    hrefName.HRef = ((ReplyModel)e.Item.DataItem).Author.ProfileLink;
                //}


                //Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
                //if (childModel_repeater != null)
                //{
                //    childModel_repeater.DataSource = ((ReplyModel)e.Item.DataItem).Author.Children;
                //    childModel_repeater.DataBind();
                //}
            }

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