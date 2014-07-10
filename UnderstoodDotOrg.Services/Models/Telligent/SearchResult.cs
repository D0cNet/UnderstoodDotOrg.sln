using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BestMatchTitle { get; set; }
        public string Body { get; set; }
        public string BestMatchBody { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string TypeTransformed { get; set; }
        public string Url { get; set; }

        public SearchResult() { }
    }
}
