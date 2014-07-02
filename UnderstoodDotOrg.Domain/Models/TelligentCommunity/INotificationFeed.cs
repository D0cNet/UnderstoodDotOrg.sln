using System;
namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public interface INotificationFeed
    {
        int CompareTo(NotificationFeed other);
        DateTime CustomDate { get; set; }
        string FriendlyDate { get; }
        System.Collections.Generic.IList<INotification> NotificationList { get; set; }
    }
}
