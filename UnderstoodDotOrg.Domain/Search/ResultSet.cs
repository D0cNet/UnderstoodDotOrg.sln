using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Search
{
    public class ResultSet
    {
        public List<SearchArticle> Articles { get; set; }
        public bool HasMoreResults { get; set; }
    }
}
