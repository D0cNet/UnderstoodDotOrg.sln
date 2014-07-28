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
        public string Id { get; set; }
        public string Url { get; set; }
        public Blog(string description, string title,string id=null)
        {
            Description = description;
            Title = title;
            Id = id;
        }
        public Blog()
        {
            
        }
    }
}
