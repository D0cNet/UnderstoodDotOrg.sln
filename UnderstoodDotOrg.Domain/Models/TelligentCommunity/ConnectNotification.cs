using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class ConnectNotification: BaseNotification
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
                 UserName = node.SelectSingleNode("Actors/RestNotificationActor/User/DisplayName").InnerText;
                 NotificationDate =Convert.ToDateTime(node.SelectSingleNode("CreatedDate").InnerText);
                
                 TimeStamp = NotificationDate.ToString("hh:mm:tt");
                 
             }
        }

         public string FriendlyDate { get { return NotificationDate.ToString("MMMM dd yyyy"); } }
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

        public override string Action
        {
            get
            {
                return (String.Format(DictionaryConstants.ConnectAction, UserName, MembershipHelper.GetPublicProfileUrl(UserName)));
               
            }
           
        }


        

        public override string NotificationLink
        {
            get { return String.Format(DictionaryConstants.ConnectLink, TimeStamp); }
            
        }

       
    

        



    }
}
