using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public abstract class BaseNotification:INotification
    {
        public event EventHandler evtOk;

        public event EventHandler evtCancel;

        public string UserName
        {
            get;
            set;
        }

        public abstract string Action
        {
            get;
        }

        public string TimeStamp
        {
            get;
            set;
        }

        public abstract string NotificationLink
        {
            get;
        }

        public DateTime NotificationDate
        {
            get;
            set;
        }

        public Common.Constants.NotificationElements.NotificationType Type
        {
            get;
            set;
        }

        public int CompareTo(INotification other)
        {
            return this.NotificationDate.CompareTo(other.NotificationDate);
        }
    }
}
