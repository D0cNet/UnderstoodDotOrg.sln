using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
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
           //  List<INotification> cnNotifs = new List<INotification>(){
           //                                             new ConnectNotification(){
           //                                                  NotificationDate=Convert.ToDateTime("6/13/2014"),
           //                                                   Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
           //                                                    UserName="Paul",
           //                                                   //  NotificationLink ="someLink",
           //                                                      TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
           //                                             }, new ConnectNotification(){
           //                                                  NotificationDate=Convert.ToDateTime("6/13/2014"),
           //                                                   Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
           //                                                    UserName="PaulX",
           //                                                    // NotificationLink ="someLinkX",
           //                                                      TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
           //                                             },new ConnectNotification(){
           //                                                  NotificationDate=Convert.ToDateTime("6/12/2014"),
           //                                                   Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
           //                                                    UserName="Paula",
           //                                                    // NotificationLink ="someLinkA",
           //                                                      TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
           //                                             },
           //                                             new ConnectNotification(){
           //                                                  NotificationDate=Convert.ToDateTime("6/11/2014"),
           //                                                   Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
           //                                                    UserName="PaulAnn",
           //                                                    // NotificationLink ="someLinkB",
           //                                                      TimeStamp = DateTime.Now.ToShortTimeString()
                                                                
           //                                             },
           //                                             new CommentNotification(){
           //                                                  NotificationDate=Convert.ToDateTime("6/11/2014"),
           //                                                   Type = UnderstoodDotOrg.Common.Constants.NotificationType.Connection,
           //                                                    UserName="PaulAnn",
           //                                                    // NotificationLink ="someLinkB",
           //                                                    BlogTitle="BlaBlaBla",
           //                                                      TimeStamp = DateTime.Now.ToShortTimeString(),
           //                                                       Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
           //                                             }
           //};
            //if (!IsPostBack)
            //{
                //TODO: Pull data from notification aggregator
                IList<INotification> cnNotifs = TelligentService.ReadFriendshipRequests(CurrentMember.ScreenName);
                FeedsCollection lnf = new FeedsCollection(cnNotifs);
                lvNotificationFeed.DataSource = lnf;
                lvNotificationFeed.DataBind();
            //}
        }

        protected void rptNotifications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item != null)
            {
                var aspxItem = e.Item;
                var dataItem = (INotification)e.Item.DataItem;

                if (dataItem is ConnectNotification)
                {
                    ConnectNotification conObj = (ConnectNotification)dataItem;
                   
                    var connectionNotifUC = LoadControl(Constants.NotificationElements.ConnectTemplatePath) as ConnectTemplate;
                   // connectionNotifUC. = (ConnectNotification)dataItem;
                    //LinkButton lbtn = (LinkButton)connectionNotifUC.FindControl("btnAccept");
                    //if (lbtn != null)
                    //{
                    //    lbtn.Click += (s, evt) =>
                    //                    {
                    //                        if (TelligentService.UpdateFriendRequest(conObj.UserName, CurrentMember.ScreenName, "Approved"))
                    //                        {
                    //                            //Push some Javascript notification that process complete
                    //                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowAcceptMessage", "alert('Request Accepted!');", true);
                    //                        }
                    //                    };
                    //}
                    connectionNotifUC.ConnectionObj = conObj;
                    aspxItem.Controls.Add(connectionNotifUC);
                   
                }
                else if (dataItem is CommentNotification)
                {
                    var commentNotifUC = LoadControl(Constants.NotificationElements.CommentTemplatePath) as CommentTemplate;
                   
                    aspxItem.Controls.Add(commentNotifUC);
                   
                }

                aspxItem.DataBind();
               
            }
        }

        
    }
}