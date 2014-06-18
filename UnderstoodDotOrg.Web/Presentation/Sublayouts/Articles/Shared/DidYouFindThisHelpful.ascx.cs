using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class DidYouFindThisHelpful : BaseSublayout
    {
        Item context = Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                ActivityLog log = new ActivityLog(CurrentMember.MemberId, Constants.UserActivity_Values.FoundHelpful_True);
                ActivityItem temp = log.Activities.Where(i => i.ContentId == context.ID.ToGuid()).FirstOrDefault();
                if (temp != null)
                {
                    btnYes.Attributes.Add("class", "helpful-yes selected");
                    btnSmallYes.Attributes.Add("class", "helpful-yes selected");
                }
            }

            ltlDidYouFindThisHelpful.Text = ltlDidYouFindThisHelpfulSmall.Text = DictionaryConstants.DidYouFindThisHelpful;
            btnNo.InnerText = btnSmallNo.InnerText = DictionaryConstants.NoButtonText + "test";
            btnYes.InnerText = btnSmallYes.InnerText = DictionaryConstants.YesButtonText;
        }

        protected void btnYes_ServerClick(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberActivity(CurrentMember.MemberId,
                        context.ID.ToGuid(),
                        Constants.UserActivity_Values.FoundHelpful_True ,
                        Constants.UserActivity_Types.FoundHelpfulVote );

                    if (success)
                    {
                        btnYes.Attributes.Add("class", "helpful-yes selected");
                        btnSmallYes.Attributes.Add("class", "helpful-yes selected");
                    }
                }
                catch
                {

                }
            }
        }
    }
}