using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class BlogPost
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string BlogName { get; set; }
        public string ContentId { get; set; }
        public string ItemUrl { get; set; }
        public string AuthorUrl { get; set; }
        public string ContentTypeId { get; set; }
        public string Url { get; set; }
        public string ParentUrl { get; set; }
        public string CommentCount { get; set; }

        public BlogPost() { }

        public BlogPost(string body, string title, string publishedDate, string author, string blogName, string contentId)
        {
            Body = body;
            Title = title;
            PublishedDate = publishedDate;
            Author = author;
            BlogName = blogName;
        }
    }
}
