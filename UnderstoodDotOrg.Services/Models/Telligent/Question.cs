using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class Question
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string Group { get; set; }
        public string CommentCount { get; set; }
        public string WikiId { get; set; }
        public string WikiPageId { get; set; }
        public string ContentId { get; set; }
        public string QueryString { get; set; }
        public string AuthorAvatarUrl { get; set; }
        public string Url { get; set; }
        public string Grade { get; set; }
        public List<String> Issues { get; set; }

        public Question() 
        {
            Issues = new List<string>();
        }

        public Question(string title, string body, string publishedDate, string author, string group, string grade, List<String> issues, string commentCount, string wikiId, string wikiPageId, string contentId)
        {
            Title = title;
            Body = body;
            PublishedDate = publishedDate;
            Author = author;
            Group = group;
            CommentCount = commentCount;
            WikiId = wikiId;
            WikiPageId = wikiPageId;
            ContentId = contentId;
            Grade = grade;
            Issues = issues;
            QueryString = "?wikiId=" + WikiId + "&wikiPageId=" + WikiPageId + "&contentId=" + ContentId;
        }
    }
}
