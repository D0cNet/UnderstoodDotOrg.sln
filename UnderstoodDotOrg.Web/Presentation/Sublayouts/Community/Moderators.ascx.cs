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
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
   

     
    public partial class Moderators : System.Web.UI.UserControl
    {

        protected override void OnInit(EventArgs e)
        {
            rptMemberCards.ItemDataBound += rptMemberCards_ItemDataBound;
            base.OnInit(e);
        }

        void rptMemberCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    Image avaturl = (Image)e.Item.FindControl("UserAvatar");
                    if (avaturl != null)
                    {
                        avaturl.ImageUrl = ((MemberCardModel)e.Item.DataItem).AvatarUrl;
                        

                    }

                    Literal username = (Literal)e.Item.FindControl("UserName");
                    if (username != null)
                    {
                        username.Text = ((MemberCardModel)e.Item.DataItem).UserName;


                    }
                    HtmlControl divImg = (HtmlControl)e.Item.FindControl("lblImg"); 
                    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                    if (userlbl != null)
                    {

                        userlbl.Text = ((MemberCardModel)e.Item.DataItem).UserLabel;
                        divImg.Visible = true;

                    }

                    Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                    if (userloc != null)
                    {
                        userloc.Text = ((MemberCardModel)e.Item.DataItem).UserLocation;


                    }
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< .mine
            var webClient = new WebClient();
            string keyTest = Sitecore.Configuration.Settings.GetSetting("TelligentAdminApiKey");
            var apiKey = String.IsNullOrEmpty(keyTest) ? "2vptamj4g2m3jvb62y" : keyTest;
=======
            List<MemberCardModel> memberCardSrc = CommunityHelper.GetModerators();
>>>>>>> .r291

            rptMemberCards.DataSource = memberCardSrc;
            rptMemberCards.DataBind();

        }

       
    }
}