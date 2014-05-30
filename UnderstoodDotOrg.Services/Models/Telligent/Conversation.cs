using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;
using System.Xml;
using UnderstoodDotOrg.Services;
namespace UnderstoodDotOrg.Services.Models.Telligent
    {
    public class Conversation
        {
        public string ID { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public List<Message> Messages { get; set; }
        public Message FirstMessage { get; set; }
        public List<MemberCardModel> Participants { get; set; }
        public Boolean HasMessages { get { return (Messages !=null && Messages.Count >0); } }
        public Conversation(XmlNode node,string username=null)
            {
                Messages = new List<Message>();
                if(node!=null)
                    {
                    ID = node.SelectSingleNode("Id").InnerText;
                    CreatedDate = Convert.ToDateTime(node.SelectSingleNode("CreatedDate").InnerText);
                    //Messages.Add(new Message(node.SelectSingleNode("FirstMessage")));
                    
                        Messages.AddRange(TelligentService.TelligentService.GetMessages(ID,username));
                    
                   
                    // var users = from u in node.SelectSingleNode("Participants").SelectNodes("User")
                    //            select new MemberCardModel(u.
                    
                    
                    }
            }
        }

   
   }
