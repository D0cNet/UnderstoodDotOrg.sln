﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parents_Recommended : System.Web.UI.UserControl
    {
        MemberCardList rptMemberCards;
        protected void Page_Load(object sender, EventArgs e)
        {

            rptMemberCards = (MemberCardList)Page.LoadControl("~/Presentation/Sublayouts/Common/MemberCardList.ascx");
            rptMemberCards.ID = "rptMemberCards";
            memberList.Controls.Add(rptMemberCards);

            //TODO: To replace with actual data for production
            MembershipManagerProxy mem = new MembershipManagerProxy();

            List<Member> members = new List<Member>() { mem.GetMember(Guid.Empty) };
            //////////////////////////////////////////////////////////

            List<MemberCardModel> memberCardSrc = members.Select(m => new MemberCardModel(m)).ToList<MemberCardModel>();

            Session["members_parents"] = memberCardSrc;
            rptMemberCards.DataSource = memberCardSrc.Take(25).ToList<MemberCardModel>();

            rptMemberCards.DataBind();


        }

        protected void ShowMore_ServerClick(object sender, EventArgs e)
        {
            List<MemberCardModel> m = rptMemberCards.DataSource as List<MemberCardModel>;
            if (m != null)
            {
                var mems =  (List<MemberCardModel>)Session["members_parents"] ;

                if (mems != null)
                {
                    rptMemberCards.DataSource = mems;
                    rptMemberCards.DataBind();

                    showmore.Visible = false;
                }
            }
        }

        
    }
}