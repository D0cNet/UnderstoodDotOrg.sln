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
            litEmptyText.Text = DictionaryConstants.EmptyNotifications;
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
         
            //if (!IsPostBack)
            //{
                //TODO: Pull data from notification aggregator
               // IList<INotification> cnNotifs = TelligentService.ReadFriendshipRequests(CurrentMember.ScreenName);
            IList<INotification> cnNotifs= new List<INotification>();

            if (Notifications != null)
                cnNotifs = Notifications;
            else
                cnNotifs = TelligentService.GetNotifications(CurrentMember.ScreenName); //TelligentService.ReadFriendshipRequests("PosesTony");

            if (cnNotifs != null && cnNotifs.Count() >0)
            {
                pnlPolulatedNotifs.Visible = true;
                pnlEmptyNotifs.Visible = false;
                  
            }
            else
            {
                pnlPolulatedNotifs.Visible = false;
                pnlEmptyNotifs.Visible = true;
                   
            }
            FeedsCollection lnf = new FeedsCollection(cnNotifs);
            lvNotificationFeed.DataSource = lnf;
            lvNotificationFeed.DataBind();
            //}
        }

        protected void rptNotifications_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item != null)
            {
                if (e.Item.ItemType == ListItemType.Item)
                {
                    var aspxItem = e.Item;
                    var dataItem = (INotification)e.Item.DataItem;

                    if (dataItem is ConnectNotification)
                    {
                        ConnectNotification conObj = (ConnectNotification)dataItem;

                        var connectionNotifUC = LoadControl(Constants.NotificationElements.ConnectTemplatePath) as ConnectTemplate;

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
}