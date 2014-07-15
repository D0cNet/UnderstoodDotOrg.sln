using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;
//using UnderstoodDotOrg.Services.AccessControlServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class DidYouFindThisHelpful : BaseSublayout
    {
        Item context = Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                //ActivityLog log = new ActivityLog(CurrentMember.MemberId, Constants.UserActivity_Values.FoundHelpful_True);
                //ActivityItem temp = log.Activities.Where(i => i.ContentId == context.ID.ToGuid()).FirstOrDefault();
                ActivityLog log = new ActivityLog();
                if (log.FoundItemHelpful(context.ID.ToGuid(), CurrentMember.MemberId))
                {
                    btnYes.Attributes.Add("class", "button helpful-yes");
                    btnSmallYes.Attributes.Add("class", "button helpful-yes");
                    btnNo.Attributes.Add("class", "helpful-no");
                    btnSmallNo.Attributes.Add("class", "helpful-no");
                }
                else if (log.FoundItemNotHelpful(context.ID.ToGuid(), CurrentMember.MemberId))
                {
                    btnNo.Attributes.Add("class", "button helpful-no");
                    btnSmallNo.Attributes.Add("class", "button helpful-no");
                    btnYes.Attributes.Add("class", "helpful-yes");
                    btnSmallYes.Attributes.Add("class", "helpful-yes");
                }
                else
                {
                    btnNo.Attributes.Add("class", "helpful-no");
                    btnSmallNo.Attributes.Add("class", "helpful-no");
                    btnYes.Attributes.Add("class", "helpful-yes");
                    btnSmallYes.Attributes.Add("class", "helpful-yes");
           
                }

            }
            else
            {
                btnNo.Attributes.Add("class", "helpful-no");
                btnSmallNo.Attributes.Add("class", "helpful-no");
                btnYes.Attributes.Add("class", "helpful-yes");
                btnSmallYes.Attributes.Add("class", "helpful-yes");
            }
            ltlDidYouFindThisHelpful.Text = ltlDidYouFindThisHelpfulSmall.Text = DictionaryConstants.DidYouFindThisHelpful;
            btnNo.InnerText = btnSmallNo.InnerText = DictionaryConstants.NoButtonText;
            btnYes.InnerText = btnSmallYes.InnerText = DictionaryConstants.YesButtonText;
        }

        protected void btnYes_ServerClick(object sender, EventArgs e)
        {
            ActivityLog log = new ActivityLog();
            if (IsUserLoggedIn)
            {
                if (!(log.FoundItemHelpful(context.ID.ToGuid(), CurrentMember.MemberId)))
                {
                    VoteYes();
                }
                else
                {
                    VoteNeutral();
                }
            }
            else
            {
                Response.Redirect(SignUpPageItem.GetSignUpPage().GetUrl());
            }
        }

        private void VoteNeutral()
        {
            MembershipManager mmgr = new MembershipManager();
            try
            {
                //mmgr.LogMemberHelpfulVote

                bool success = mmgr.ClearHelpfulVote(CurrentMember.MemberId, context.ID.ToGuid(), 
                    Constants.UserActivity_Values.FoundHelpful_True, 
                    Constants.UserActivity_Types.FoundHelpfulVote);

                success = mmgr.ClearHelpfulVote(CurrentMember.MemberId, context.ID.ToGuid(), 
                    Constants.UserActivity_Values.FoundHelpful_False, 
                    Constants.UserActivity_Types.FoundHelpfulVote);

                if (success)
                {
                    btnNo.Attributes.Add("class", "helpful-no");
                    btnSmallNo.Attributes.Add("class", "helpful-no");
                    btnYes.Attributes.Add("class", "helpful-yes");
                    btnSmallYes.Attributes.Add("class", "helpful-yes");
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch
            {

            }
        }

        protected void VoteYes()
        {
            MembershipManager mmgr = new MembershipManager();
            try
            {
                //mmgr.LogMemberHelpfulVote

                bool success = mmgr.LogMemberHelpfulVote(CurrentMember.MemberId,
                    context.ID.ToGuid(),
                    Constants.UserActivity_Values.FoundHelpful_True,
                    Constants.UserActivity_Types.FoundHelpfulVote);

                if (success)
                {
                    btnYes.Attributes.Add("class", "button helpful-yes");
                    btnSmallYes.Attributes.Add("class", "button helpful-yes");
                    btnNo.Attributes.Add("class", "helpful-no");
                    btnSmallNo.Attributes.Add("class", "helpful-no");
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch
            {

            }
        }

        protected void VoteNo()
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
                    btnNo.Attributes.Add("class", "button helpful-no");
                    btnSmallNo.Attributes.Add("class", "button helpful-no");
                    btnYes.Attributes.Add("class", "helpful-yes");
                    btnSmallYes.Attributes.Add("class", "helpful-yes");
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch
            {

            }
        }

        protected void btnNo_ServerClick(object sender, EventArgs e)
        {
            
            ActivityLog log = new ActivityLog();
            if (IsUserLoggedIn)
            {
                if (!(log.FoundItemNotHelpful(context.ID.ToGuid(), CurrentMember.MemberId)))
                {
                    VoteNo();
                }
                else
                {
                    VoteNeutral();
                }
            }
            else
            {
                Response.Redirect(SignUpPageItem.GetSignUpPage().GetUrl());
            }
        }
    }
}