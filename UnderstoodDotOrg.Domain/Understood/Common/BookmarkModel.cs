using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class BookmarkModel
    {
        public string ContentTypeId { get; set; }
        public string ContentId { get; set; }
        public Constants.TelligentContentType Type { get; set; }
        
        //Refactor to contain type internally instead of default
        public BookmarkModel(XmlNode node,Constants.TelligentContentType type= Constants.TelligentContentType.Blog)
        {
            if(node!=null)
            {
                ContentTypeId = node.SelectSingleNode("Content/ContentTypeId").InnerText;
                ContentId = node.SelectSingleNode("Content/ContentId").InnerText;
                Type = type;

            }
        }
    }
}
