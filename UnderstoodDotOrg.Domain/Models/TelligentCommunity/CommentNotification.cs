using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class CommentNotification : INotification
    {
        public event EventHandler evtOk;

        public event EventHandler evtCancel;

        public string BlogTitle {get;set;}

        public string Action
        {
            get
            {
                return (String.Format(DictionaryConstants.CommentAction, UserName, "REPLACE"));

            }
           
        }

        public string Text
        {
            get;
            set;
        }

        public string TimeStamp
        {
            get;
            set;
        }

        public string NotificationLink
        {
            get;
            set;
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


        public string UserName
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
