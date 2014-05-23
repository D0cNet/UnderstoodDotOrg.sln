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
using UnderstoodDotOrg.Services.TelligentService;
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


            List<MemberCardModel> memberCardSrc = TelligentService.GetModerators();

            rptMemberCards.DataSource = memberCardSrc;
            rptMemberCards.DataBind();

        }

       
    }
}