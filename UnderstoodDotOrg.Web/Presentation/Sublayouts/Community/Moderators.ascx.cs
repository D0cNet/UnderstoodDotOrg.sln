using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
   

     
    public partial class Moderators : System.Web.UI.UserControl
    {
        MemberCardList rptMemberCards;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMemberCards = (MemberCardList)Page.LoadControl("~/Presentation/Sublayouts/Common/MemberCardList.ascx");
            rptMemberCards.ID = "rptMemberCards";
            memberList.Controls.Add(rptMemberCards);

            var webClient = new WebClient();
            string keyTest = Sitecore.Configuration.Settings.GetSetting("TelligentAdminApiKey");
            var apiKey = String.IsNullOrEmpty(keyTest) ? "2vptamj4g2m3jvb62y" : keyTest;

            List<MemberCardModel> memberCardSrc = CommunityHelper.GetModerators();

            rptMemberCards.DataSource = memberCardSrc;
            rptMemberCards.DataBind();

        }

       
    }
}