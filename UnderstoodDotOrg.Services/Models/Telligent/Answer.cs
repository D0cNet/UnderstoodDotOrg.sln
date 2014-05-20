using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class Answer
    {
        public string Body { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string Likes { get; set; }

        public Answer() { }
    }
}
