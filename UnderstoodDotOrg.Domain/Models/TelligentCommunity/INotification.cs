using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public interface INotification:IComparable<INotification>
    {
        #region Events
         event EventHandler evtOk;
         event EventHandler evtCancel;

        #endregion

        #region Body
         string UserName { get; set; }
         string Action { get; }
        #endregion

        #region Header
         string TimeStamp { get; set; }
         string NotificationLink { get;  }
        #endregion

         DateTime NotificationDate { get; set; }
         Constants.NotificationType Type { get; set; }
        

    }
}
