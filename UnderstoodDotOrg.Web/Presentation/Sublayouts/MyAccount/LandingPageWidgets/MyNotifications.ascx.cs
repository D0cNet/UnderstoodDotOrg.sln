using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyNotifications : BaseSublayout
    {
        protected override void OnInit(EventArgs e)
        {
           // lvNotifications.ItemDataBound += lvNotifications_ItemDataBound;
            litEmptyText.Text = DictionaryConstants.EmptyNotifications;
            base.OnInit(e);
        }
        protected void lvNotifications_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item != null)
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    var aspxItem = e.Item;
                    var dataItem = (INotification)e.Item.DataItem;

                    if (dataItem is ConnectNotification)
                    {
                        ConnectNotification conObj = (ConnectNotification)dataItem;

                        var connectionNotifUC = LoadControl(Constants.NotificationElements.ConnectTemplateFrontPath) as ConnectTemplateFront;

                        connectionNotifUC.ConnectionObj = conObj;
                        aspxItem.Controls.Add(connectionNotifUC);

                    }
                    else if (dataItem is CommentNotification)
                    {
                        var commentNotifUC = LoadControl(Constants.NotificationElements.CommentTemplateFrontPath) as CommentTemplateFront;

                        aspxItem.Controls.Add(commentNotifUC);

                    }

                    aspxItem.DataBind();

                }
             
            }
            
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            litSeeAllNotificationsLabel.Text = DictionaryConstants.SeeAllNotificationsLabel;
            hrefNotificationsLink.HRef =   MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetUrl();
            if (Notifications != null)
            {
                litNotifCount.Text = Notifications.Count().ToString();
                pnlEmptyText.Visible = false;
            }
            else
                pnlEmptyText.Visible = true;

             var filterNotifs = Notifications;
            if (Notifications != null)
            {
                filterNotifs= Notifications.OrderByDescending(x => x.NotificationDate).Take(3).ToList();
            }

            lvNotifications.DataSource = filterNotifs;
            lvNotifications.DataBind();
           
        }
    }
}