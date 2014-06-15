using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Helpers;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class NotificationFeed: IComparable<NotificationFeed>
    {
        public DateTime CustomDate { get; set; }
        public string FriendlyDate { get { return DataFormatHelper.FormatDate(CustomDate.ToString()); } }
        public IList<INotification> NotificationList{get;set;}

        public NotificationFeed(IEnumerable<INotification> notifications,DateTime date)
        {
            if(notifications!=null && date!=null)
            {
                CustomDate = date;
                NotificationList = notifications.ToList();
            }
        }
        
        public NotificationFeed()
        {
            
        }


        public int CompareTo(NotificationFeed other)
        {
            return this.CustomDate.Date.CompareTo(other.CustomDate.Date);
        }
    }
}
