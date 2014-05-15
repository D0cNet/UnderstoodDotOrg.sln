using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class ReplyModel
    {
        public ReplyModel(XmlNode node)
        {
            this.AuthorName = node.SelectSingleNode("Author/Username").InnerText;
            this.Body = CommunityHelper.FormatString100(node.SelectSingleNode("Body").InnerText);
            this.ReplyDate = CommunityHelper.FormatDate(node.SelectSingleNode("Date").InnerText);
            this.Date = Convert.ToDateTime((node.SelectSingleNode("Date").InnerText));
        }
        private MemberCardModel _author = null;
        public string Body { get; set; }
        public string ReplyDate { get; set; } 
        public DateTime Date { get; set; }
        public string AuthorName {get;set;}
        public MemberCardModel Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new MemberCardModel(AuthorName);
                    return _author;
                }
                else return _author;
            }
        }
    }
}
