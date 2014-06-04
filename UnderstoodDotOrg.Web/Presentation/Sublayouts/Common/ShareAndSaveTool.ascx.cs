using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Activity;

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
                    lbSave.Enabled = false;
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
                        lbSave.Enabled = false;
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