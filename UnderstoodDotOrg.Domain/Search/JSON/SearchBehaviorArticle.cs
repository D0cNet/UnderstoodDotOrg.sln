using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search.JSON
{
    public class SearchBehaviorArticle
    {
        public string Title { get; set; }
        public int CommentCount { get; set; }
        public string Url { get; set; }
        public int HelpfulCount { get; set; }
    }
}
