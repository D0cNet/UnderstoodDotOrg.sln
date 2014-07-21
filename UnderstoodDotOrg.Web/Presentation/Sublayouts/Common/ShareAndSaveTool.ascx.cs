using Sitecore.Data.Items;
using System;
using System.Linq;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ShareAndSaveTool : BaseSublayout
    {
        public string LoggedInStatus;
        public Item context = Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInStatus = IsUserLoggedIn.ToString();

            if (DataSource != null && DataSource.InheritsFromType(ContentPageItem.TemplateId))
            {
                BindData((ContentPageItem)DataSource);
            }

            UpdatePanel1.Attributes.Add("style", "display: inline-block;");

            if (IsUserLoggedIn)
            {
                ActivityLog log = new ActivityLog(CurrentMember.MemberId, Constants.UserActivity_Values.Favorited);
                ActivityItem temp = log.Activities.Where(i => i.ContentId == context.ID.ToGuid()).FirstOrDefault();
                if (temp != null)
                {
                    lbSave.CssClass = "icon icon-save active";
                    lbSave.Click += lbUnsave_Click;
                    lbSave.Click -= lbSave_Click;
                }
            }
        }

        private void BindData(ContentPageItem page)
        {
            hlFacebook.NavigateUrl = SocialHelper.GetFacebookShareUrl(page);
            hlFacebook.Text = DictionaryConstants.SocialSharingFacebook;

            hlGooglePlus.NavigateUrl = SocialHelper.GetGooglePlusShareUrl(page);
            hlGooglePlus.Text = DictionaryConstants.SocialSharingGooglePlus;

            hlTwitter.NavigateUrl = SocialHelper.GetTwitterShareUrl(page, page.PageTitle.Raw);
            hlTwitter.Text = DictionaryConstants.SocialSharingTwitter;

            hlPinterest.NavigateUrl = SocialHelper.GetPinterestShareUrl(page);
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberActivity(CurrentMember.MemberId,
                        context.ID.ToGuid(),
                        Constants.UserActivity_Values.Favorited,
                        Constants.UserActivity_Types.ContentRelated);

                    if(success)
                    {
                        lbSave.CssClass = "icon icon-save active";
                        lbSave.Click += lbUnsave_Click;
                        lbSave.Click -= lbSave_Click;
                    }
                }
                catch
                {
                    
                }
            }
            else
            {
                string url = SignUpPageItem.GetSignUpPage().GetUrl();
                this.ProfileRedirect(UnderstoodDotOrg.Common.Constants.UserPermission.RegisteredUser);
            }
        }

        protected void lbUnsave_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberActivity_AsDeleted(CurrentMember.MemberId,
                        context.ID.ToGuid(),
                        Constants.UserActivity_Values.Favorited,
                        Constants.UserActivity_Types.ContentRelated);

                    if (success)
                    {
                        lbSave.CssClass = "icon icon-save";
                        lbSave.Click += lbSave_Click;
                        lbSave.Click -= lbUnsave_Click;
                    }
                }
                catch
                {

                }
            }
            else
            {
                string url = SignUpPageItem.GetSignUpPage().GetUrl();
                this.ProfileRedirect(UnderstoodDotOrg.Common.Constants.UserPermission.RegisteredUser);
            }
        }
    }
}