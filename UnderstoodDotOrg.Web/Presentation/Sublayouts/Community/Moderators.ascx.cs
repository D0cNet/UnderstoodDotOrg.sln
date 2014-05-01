using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public class MemberCard
    {
        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public string UserLocation { get; set; }
        public string UserLabel { get; set; }

    }

     
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
                        avaturl.ImageUrl = ((MemberCard)e.Item.DataItem).AvatarUrl;
                        

                    }

                    Literal username = (Literal)e.Item.FindControl("UserName");
                    if (username != null)
                    {
                        username.Text= ((MemberCard)e.Item.DataItem).UserName;


                    }

                    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                    if (userlbl != null)
                    {
                        userlbl.Text = ((MemberCard)e.Item.DataItem).UserLabel;


                    }

                    Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                    if (userloc != null)
                    {
                        userloc.Text = ((MemberCard)e.Item.DataItem).UserLocation;


                    }
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            var apiKey = CommunityManager.apiKey ??"d956up05xiu5l8fn7wpgmwj4ohgslp";

            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var roleid = Sitecore.Configuration.Settings.GetSetting("TelligentModeratorRoleID")??"3";
            var serverHost = Sitecore.Configuration.Settings.GetSetting("TelligentConfig")??"localhost/telligent.com";
            var requestUrl = serverHost  + "/api.ashx/v2/roles/"+roleid+"/users.xml";
            
            var xml = webClient.DownloadString(requestUrl);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var nodes = xmlDoc.SelectNodes("/Response/Users/User");
            // PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
           // lblCount.Text = nodes.Count.ToString();
            List<MemberCard> memberCardSrc = new List<MemberCard>();
            foreach (XmlNode item in nodes)
            {

                MemberCard cm = new MemberCard();
                cm.AvatarUrl = item.SelectSingleNode("AvatarUrl").InnerText;

                //TODO: This is to change once we figure out retrieving users by roleid
                cm.UserLabel = "Moderator";

                cm.UserLocation = item.SelectSingleNode("Location").InnerText;
                cm.UserName = item.SelectSingleNode("Username").InnerText;
       
                memberCardSrc.Add(cm);
                cm = null;
            }

            rptMemberCards.DataSource = memberCardSrc;
            rptMemberCards.DataBind();

        }
    }
}