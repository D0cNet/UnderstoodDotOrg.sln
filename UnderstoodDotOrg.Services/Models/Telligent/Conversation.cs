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
        public List<MemberCardModel> Participants { get; set; }

        public Conversation(XmlNode node)
            {
                if(node!=null)
                    {
                    ID = node.SelectSingleNode("Id").InnerText;
                    CreatedDate = Convert.ToDateTime(node.SelectSingleNode("CreatedDate").InnerText);
                   Messages = TelligentService.TelligentService.GetMessages( ID);
                   // var users = from u in node.SelectSingleNode("Participants").SelectNodes("User")
                    //            select new MemberCardModel(u.

                    
                    }
            }
        }

   
   }
