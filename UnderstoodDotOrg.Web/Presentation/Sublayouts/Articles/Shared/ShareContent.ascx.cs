using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Understood.Activity;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class ShareContent : BaseSublayout
    {
        public Item context = Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    lbSave.Attributes.Add("class", "icon-plus active");
                    lbSave.ServerClick += lbUnsave_Click;
                    lbSave.ServerClick -= lbSave_Click;
                }
            }
        }

        private void BindData(ContentPageItem page)
        {
            hlFacebook.NavigateUrl = SocialHelper.GetFacebookShareUrl(page);
            ltlFacebook.Text = DictionaryConstants.SocialSharingFacebook;

            hlGooglePlus.NavigateUrl = SocialHelper.GetGooglePlusShareUrl(page);
            ltlGooglePlus.Text = DictionaryConstants.SocialSharingGooglePlus;

            hlTwitter.NavigateUrl = SocialHelper.GetTwitterShareUrl(page, page.PageTitle.Raw);
            ltlTwitter.Text = DictionaryConstants.SocialSharingTwitter;
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

                    if (success)
                    {
                        lbSave.Attributes.Add("class", "icon-plus active");
                        lbSave.ServerClick += lbUnsave_Click;
                        lbSave.ServerClick -= lbSave_Click;
                    }
                }
                catch
                {

                }
            }
            else
            {
                string url = MyAccountFolderItem.GetSignUpPage();
                Response.Redirect(url);
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
                        lbSave.Attributes.Add("class", "icon-plus");
                        lbSave.ServerClick += lbSave_Click;
                        lbSave.ServerClick -= lbUnsave_Click;
                    }
                }
                catch
                {

                }
            }
            else
            {
                string url = MyAccountFolderItem.GetSignUpPage();
                Response.Redirect(url);
            }
        }
    }
}