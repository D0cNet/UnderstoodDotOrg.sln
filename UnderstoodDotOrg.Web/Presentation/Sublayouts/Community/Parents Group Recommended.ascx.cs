using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            //TODO: To replace with actual data for production
            //MembershipManagerProxy mem = new MembershipManagerProxy();

            //List<Member> members = new List<Member>() { mem.GetMember(Guid.Empty) };
            //////////////////////////////////////////////////////////

            //List<MemberCardModel> memberCardSrc = members.Select(m => new MemberCardModel(m)).ToList<MemberCardModel>();

            //Session["members_parents"] = memberCardSrc;
            //rptMemberCards.DataSource = memberCardSrc.Take(25).ToList<MemberCardModel>();

            rptGroupCards.DataBind();
        }
    }
}