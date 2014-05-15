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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupDiscussionList : System.Web.UI.UserControl
    {
        public override void DataBind()
        {
            rptDiscussionList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Item currItem = Sitecore.Context.Item;
            //if (currItem != null)
            //{
            //    GroupDiscussionItem grpDItem = new GroupDiscussionItem(currItem);
            //    if (grpDItem != null)
            //    {
            //        string forumID = grpDItem.ForumID.Text;
            //        string threadID = grpDItem.ThreadID.Text;

            //        //ThreadModel thModel = new ThreadModel(forumID, threadID);
            //        List<ReplyModel> replies = CommunityHelper.ReadReplies(forumID, threadID);
            //        if (replies != null)
            //        {
            //            rptDiscussionList.DataSource = replies;
            //            rptDiscussionList.DataBind();
            //        }

            //    }
            //}
        }
        protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
            if (childIssues_repeater != null)
            {
                childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
                childIssues_repeater.DataBind();
            }
        }
        protected void rptDiscussionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
            if (childModel_repeater != null)
            {
                childModel_repeater.DataSource = ((ReplyModel)e.Item.DataItem).Author.Children;
                childModel_repeater.DataBind();
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