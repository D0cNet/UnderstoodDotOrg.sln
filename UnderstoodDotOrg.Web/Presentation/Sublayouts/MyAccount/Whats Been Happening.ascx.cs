using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class Whats_Been_Happening : BaseSublayout//System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            lvNotificationFeed.ItemDataBound += lvNotificationFeed_ItemDataBound;
           
            base.OnInit(e);
        }

        protected void lvNotificationFeed_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            Repeater Notifications_repeater = (Repeater)e.Item.FindControl("rptNotifications");
            if (Notifications_repeater != null)
            {
                Notifications_repeater.DataSource = ((NotificationFeed)e.Item.DataItem).NotificationList;
                Notifications_repeater.DataBind();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
             List<INotification> cnNotifs = new List<INotification>(){
                                                        new ConnectNotification(){
                                                             NotificationDate=Convert.ToDateTime("6/13/2014"),
                                                              Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
                                                               UserName="Paul",
                                                              //  NotificationLink ="someLink",
                                                                 TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
                                                        }, new ConnectNotification(){
                                                             NotificationDate=Convert.ToDateTime("6/13/2014"),
                                                              Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
                                                               UserName="PaulX",
                                                               // NotificationLink ="someLinkX",
                                                                 TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
                                                        },new ConnectNotification(){
                                                             NotificationDate=Convert.ToDateTime("6/12/2014"),
                                                              Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
                                                               UserName="Paula",
                                                               // NotificationLink ="someLinkA",
                                                                 TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
                                                        },
                                                        new ConnectNotification(){
                                                             NotificationDate=Convert.ToDateTime("6/11/2014"),
                                                              Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
                                                               UserName="PaulAnn",
                                                               // NotificationLink ="someLinkB",
                                                                 TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
                                                        },
                                                        new CommentNotification(){
                                                             NotificationDate=Convert.ToDateTime("6/11/2014"),
                                                              Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
                                                               UserName="PaulAnn",
                                                               // NotificationLink ="someLinkB",
                                                               BlogTitle="BlaBlaBla",
                                                                 TimeStamp = DateTime.Now.ToShortTimeString(),
                                                                  Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                                                        }
           };

             FeedsCollection lnf = new FeedsCollection(cnNotifs);
             lvNotificationFeed.DataSource = lnf;
             lvNotificationFeed.DataBind();
        }

        protected void rptNotifications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item != null)
            {
                var aspxItem = e.Item;
                var dataItem = (INotification)e.Item.DataItem;

                if (dataItem is ConnectNotification)
                {
                    var connectionNotifUC = LoadControl("~/Presentation/Sublayouts/MyAccount/Notification Templates/ConnectTemplate.ascx") as ConnectTemplate;
                   // connectionNotifUC. = (ConnectNotification)dataItem;
                    aspxItem.Controls.Add(connectionNotifUC);
                    aspxItem.DataBind();
                }
                else if (dataItem is CommentNotification)
                {
                    var connectionNotifUC = LoadControl("~/Presentation/Sublayouts/MyAccount/Notification Templates/CommentTemplate.ascx") as CommentTemplate;
                    //connectionNotifUC.item = (ConnectNotification)dataItem;
                    aspxItem.Controls.Add(connectionNotifUC);
                    aspxItem.DataBind();
                }
            }
        }
    }
}