using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class ConnectNotification: INotification
    {

       
         public ConnectNotification()
        {
            
        }
         public ConnectNotification(XmlNode node)
        {
            // throw new NotImplementedException(); 
             if(node!=null)
             {
                 Type = Common.Constants.NotificationElements.NotificationType.Connection;
                 UserName = node.SelectSingleNode("User/Username").InnerText;
                 NotificationDate =Convert.ToDateTime(node.SelectSingleNode("CreatedDate").InnerText);
                 TimeStamp = NotificationDate.ToString("hh:mm");
             }
        }
        public event EventHandler evtOk;

        public event EventHandler evtCancel;

        
        public virtual void OnAccept(object sender, EventArgs args)
        {
            if(evtOk != null)
            {
               evtOk(this, args);
            }
        }

        public virtual void OnDecline(object sender, EventArgs args)
        {
            if (evtCancel != null)
            {
                evtCancel(this, args);
            }
        }

        public string Action
        {
            get
            {
               return (String.Format(DictionaryConstants.ConnectAction,UserName,"REPLACE"));
               
            }
           
        }


        public string TimeStamp
        {
            get;
            set;
        }

        public string NotificationLink
        {
            get { return String.Format(DictionaryConstants.ConnectLink, TimeStamp); }
            
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
	          get ;
	          set ;
        }



        public int CompareTo(INotification other)
        {
            return this.NotificationDate.CompareTo(other.NotificationDate);
        }
    }
}
