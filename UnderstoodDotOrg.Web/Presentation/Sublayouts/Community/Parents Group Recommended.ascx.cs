using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parents_Group_Recommended : System.Web.UI.UserControl
    {
        GroupSummaryList rptGroupCards;
        protected void Page_Load(object sender, EventArgs e)
        {
            rptGroupCards = (GroupSummaryList)Page.LoadControl("~/Presentation/Sublayouts/Common/GroupSummaryList.ascx");
            rptGroupCards.ID = "rptGroupCards";
            groupList.Controls.Add(rptGroupCards);
            Item currItem = Sitecore.Context.Item;
            //TODO: To replace with actual data for production
            //MembershipManagerProxy mem = new MembershipManagerProxy();

            //List<Member> members = new List<Member>() { mem.GetMember(Guid.Empty) };
            //////////////////////////////////////////////////////////

            //List<MemberCardModel> memberCardSrc = members.Select(m => new MemberCardModel(m)).ToList<MemberCardModel>();

            //Session["members_parents"] = memberCardSrc;
            //rptMemberCards.DataSource = memberCardSrc.Take(25).ToList<MemberCardModel>();
            //Get all groups under parent folder
            List<GroupItem> groups =currItem.Parent.Children.Where(x => x.TemplateID.ToString().Equals(Constants.Groups.GroupTemplateID)).Select(x => new GroupItem(x)).ToList<GroupItem>();

            //Convert sitecore group items to GroupCardModels
            var grpItems = groups.Select(x => new GroupCardModel(x)).ToList<GroupCardModel>();
            Session["groupItems"] = grpItems;
            rptGroupCards.DataSource = FindRecommendedGroups(grpItems); ///TODO: To decide on logic for finding recommendations
            rptGroupCards.DataBind();
        }

        private List<GroupCardModel> FindRecommendedGroups(List<GroupCardModel> grpItems)
        {
            throw new NotImplementedException();
        }
    }
}