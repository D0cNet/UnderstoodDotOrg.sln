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
    public partial class DidYouFindThisHelpfulOther : BaseSublayout
    {
        Item context = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                ActivityLog log = new ActivityLog();
                if (log.FoundItemHelpful(context.ID.ToGuid(), CurrentMember.MemberId))
                {
                    btnYes.Attributes.Add("class", "helpful-yes selected");
                    btnNo.Attributes.Add("class", "helpful-no");
                }
                else if (log.FoundItemNotHelpful(context.ID.ToGuid(), CurrentMember.MemberId))
                {
                    btnNo.Attributes.Add("class", "helpful-no selected");
                    btnYes.Attributes.Add("class", "helpful-yes");
                }
                else
                {
                    btnNo.Attributes.Add("class", "helpful-no");
                    btnYes.Attributes.Add("class", "helpful-yes");
           
                }

            }
            else
            {
                btnNo.Attributes.Add("class", "helpful-no");
                btnYes.Attributes.Add("class", "helpful-yes");
            }
        

            ltlDidYouFindThisHelpful.Text = DictionaryConstants.DidYouFindThisHelpful;
            btnNo.InnerText = DictionaryConstants.NoButtonText;
            btnYes.InnerText = DictionaryConstants.YesButtonText;
        }
       

        protected void btnYes_ServerClick(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberHelpfulVote(CurrentMember.MemberId,
                        context.ID.ToGuid(),
                        Constants.UserActivity_Values.FoundHelpful_True,
                        Constants.UserActivity_Types.FoundHelpfulVote );

                    if (success)
                    {
                        btnYes.Attributes.Add("class", "helpful-yes selected");
                        btnNo.Attributes.Add("class", "helpful-no");
                        Response.Redirect(Request.RawUrl);
                    }
                }
                catch
                {

                }
            }
        }
        protected void btnNo_ServerClick(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberHelpfulVote(CurrentMember.MemberId,
                        context.ID.ToGuid(),
                        Constants.UserActivity_Values.FoundHelpful_False,
                        Constants.UserActivity_Types.FoundHelpfulVote);

                    if (success)
                    {
                        btnNo.Attributes.Add("class", "helpful-no selected");
                        btnYes.Attributes.Add("class", "helpful-yes");
                        Response.Redirect(Request.RawUrl);

                    }
                }
                catch
                {

                }
            }
        }
    }
}