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
            ConnectButton btnConnect = e.FindControlAs<ConnectButton>("btnConnect");
            if (btnConnect != null)
            {
                if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
                {
                    if (!String.IsNullOrEmpty(((ReplyModel)e.Item.DataItem).Author.UserName))
                        btnConnect.LoadState(((ReplyModel)e.Item.DataItem).Author.UserName);
                }
            }

            HtmlAnchor hrefName = e.FindControlAs<HtmlAnchor>("hrefName");
            if(hrefName !=null)
            {
                hrefName.HRef = ((ReplyModel)e.Item.DataItem).Author.ProfileLink;
            }

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