using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.ExactTarget;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ShareNSave_SendEmail : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtYourname.Attributes.Add("placeholder", "Enter your name");
            txtYourEMailID.Attributes.Add("placeholder", "Enter your email");
            txtRecipentEMailID.Attributes.Add("placeholder", "Friend's Email");
            txtThoughts.Attributes.Add("placeholder", "I saw this and thought you might find it helpful");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DefaultArticlePageItem article = (DefaultArticlePageItem)Sitecore.Context.Item;

            InvokeEM24ContentSharedWithAFriendRequest message = new InvokeEM24ContentSharedWithAFriendRequest{};

            message.PMText = txtThoughts.Text.Trim();
            message.ToEmail = txtRecipentEMailID.Text.Trim();
            message.UserContactFirstName = txtYourname.Text.Trim();

            if (article != null)
                message.ReminderLink = article.GetUrl();

            BaseReply reply = ExactTargetService.InvokeEM24ContentSharedWithAFriend(message);
            MembershipManager mmgr = new MembershipManager();

            if (IsUserLoggedIn)
            {
                try
                {
                    bool success = mmgr.LogMemberActivity(CurrentMember.MemberId,
                            article.ID.ToGuid(),
                            Constants.UserActivity_Values.Shared,
                            Constants.UserActivity_Types.ContentRelated);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}