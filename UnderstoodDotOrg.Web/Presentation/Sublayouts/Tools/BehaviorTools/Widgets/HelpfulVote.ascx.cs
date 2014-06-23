using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets
{
    public partial class HelpfulVote : BaseSublayout<BehaviorAdvicePageItem>
    {
        private Guid? MemberId { get; set; }
        private Guid? ContentId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();

            if (CurrentMember != null)
            {
                MemberId = CurrentMember.MemberId;
            }
            ContentId = Model.ContentId.Raw.AsNGuid();
        }

        private void BindContent()
        {
            btnLike.Text = DictionaryConstants.YesButtonText;
            btnUnlike.Text = DictionaryConstants.NoButtonText;
        }

        protected void btnThisHelped_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                ActivityLog log = new ActivityLog();
                
                if (ContentId.HasValue && !log.FoundItemHelpful(ContentId.Value, MemberId.Value))
                {
                    // instantiate MM
                    MembershipManager mgr = new MembershipManager();
                    // write to the DB
                    mgr.LogMemberHelpfulVote(MemberId.Value, ContentId.Value, Constants.UserActivity_Values.FoundHelpful_True, Constants.UserActivity_Types.FoundHelpfulVote);
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                Response.Redirect("/my-account/sign-in");
            }
        }

        protected void btnDidntHelp_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                ActivityLog log = new ActivityLog();
                Guid? ContentId = Model.ContentId.Raw.AsNGuid();
                if (ContentId.HasValue && !log.FoundItemHelpful(ContentId.Value, MemberId.Value))
                {
                    // instantiate MM
                    MembershipManager mgr = new MembershipManager();
                    // write to the DB
                    mgr.LogMemberHelpfulVote(MemberId.Value, ContentId.Value, Constants.UserActivity_Values.FoundHelpful_False, Constants.UserActivity_Types.FoundHelpfulVote);
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                Response.Redirect("/my-account/sign-in");
            }
        }
    }
}