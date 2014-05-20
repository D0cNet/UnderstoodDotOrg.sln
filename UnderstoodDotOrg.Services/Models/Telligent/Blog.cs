using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class Blog
    {
        public string Description { get; set; }
        public string Title { get; set; }

        public Blog(string description, string title)
        {
            Description = description;
            Title = title;
        }
    }
}
