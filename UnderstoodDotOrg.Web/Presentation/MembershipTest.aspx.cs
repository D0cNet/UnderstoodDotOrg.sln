using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using System.Text;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var un = string.Empty;

            if (!string.IsNullOrEmpty(Request.QueryString["un"]))
            {
                un = Request.QueryString["un"];
            }
            else
            {
                un = "everythingisawesome";
            }


            //litRoles.Text = MembershipManager.isOpenToConnect(un).ToString();
            var membershipManager = new MembershipManager();
            var sb = new StringBuilder();
            var output = @"Method: {0}:{1}</br>";
            var member = membershipManager.GetMemberByScreenName(un);
            var memberId = member.MemberId;

            sb.Append(string.Format(output, "membershipManager.GetMemberByScreenName(un).Email", membershipManager.GetMemberByScreenName(un).Email));
            sb.Append(string.Format(output, "membershipManager.GetMember(memberId).Email", membershipManager.GetMember(memberId).Email));
            sb.Append(string.Format(output, "membershipManager.GetMember('q1q1q1@q1.q1').Email", membershipManager.GetMember("q1q1q1@q1.q1").Email));
            //sb.Append(string.Format(output, "membershipManager.GetMember('q1q1q1@q1.q1').Email", membershipManager.GetMembers().FirstOrDefault(x => x.Email == "q1q1q1@q1.q1").Email));
            sb.Append(string.Format(output, "membershipManager.GetMembers().FirstOrDefault(x => x.MemberId == memberId).Email", membershipManager.GetMembers().FirstOrDefault(x => x.MemberId == memberId).Email));
            sb.Append(string.Format(output, "membershipManager.GetUser(memberId).Email", membershipManager.GetUser(memberId).Email));

            litRoles.Text = sb.ToString();
        }

    }
}