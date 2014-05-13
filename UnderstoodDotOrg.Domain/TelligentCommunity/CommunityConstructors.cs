using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.TelligentCommunity
{
    public class Comment
    {
        public string _id { get; set; }
        public string _url { get; set; }
        public string _body { get; set; }
        public string _parentId { get; set; }
        public string _publishedDate { get; set; }
        public string _likes { get; set; }
        public string _commentId { get; set; }
        public string _contentId { get; set; }
        public string _commentContentTypeId { get; set; }
        public string _authorId { get; set; }
        public string _authorAvatarUrl { get; set; }
        public string _authorDisplayName { get; set; }
        public string _authorProfileUrl { get; set; }
        public string _replyCount { get; set; }
        public string _isApproved { get; set; }
        public string _authorUsername { get; set; }

        public Comment(string id, string url, string body, string parentId, string contentId, string isApproved, string replyCount,
            string commentId, string commentContentTypeId, string authorId, string authorAvatarUrl, string authorUsername, string publishedDate,
                string authorDisplayName, string authorProfileUrl, string likes, string commentDate)
        {
            _id = id;
            _url = url;
            _body = body;
            _parentId = parentId;
            _contentId = contentId;
            _isApproved = isApproved;
            _replyCount = replyCount;
            _commentId = commentId;
            _commentContentTypeId = commentContentTypeId;
            _publishedDate = publishedDate;
            _authorId = authorId;
            _authorAvatarUrl = authorAvatarUrl;
            _authorDisplayName = authorDisplayName;
            _authorProfileUrl = authorProfileUrl;
            _authorUsername = authorUsername;
            _likes = likes;
            _commentDate = DateTime.Parse(commentDate);
        }

        public DateTime _commentDate { get; set; }
    }

    public class BlogPost
    {
        public string _body { get; set; }
        public string _title { get; set; }
        public string _publishedDate { get; set; }
        public string _author { get; set; }
        public string _blogName { get; set; }
        public string _contentId { get; set; }
        public string _sitecoreUrl { get; set; }

        public BlogPost(string body, string title, string publishedDate, string author, string blogName, string contentId)
        {
            _body = body;
            try
            {
                string[] url = Regex.Split(body.ToLower(), "/sitecore/content/home");
                url[1].Replace(' ', '-');
                _sitecoreUrl = url[0];
            }
            catch
            {

            }
            _title = title;
            _publishedDate = publishedDate;
            _author = author;
            _blogName = blogName;
        }
    }

    public class Blog
    {
        public string _description { get; set; }
        public string _title { get; set; }

        public Blog(string description, string title)
        {
            _description = description;
            _title = title;
        }
    }

    public class User
    {
        public string username { get; set; }
        public string displayName { get; set; }
        public string password { get; set; }
        public string privateEmail { get; set; }
        public bool allowSiteToContact { get; set; }
        public DateTime birthday { get; set; }
        public string editorType { get; set; }
        public bool receiveEmails { get; set; }
        public bool enableTracking { get; set; }
        public string gender { get; set; }
        public string language { get; set; }
        public string location { get; set; }
        public double timeZone { get; set; }
        public string webUrl { get; set; }

        public User()
        {
            this.password = Guid.NewGuid().ToString();
        }
    }

    public class Question
    {
        public string _title { get; set; }
        public string _body { get; set; }
        public string _publishedDate { get; set; }
        public string _author { get; set; }
        public string _group { get; set; }

        public Question(string title, string body, string publishedDate, string author, string group)
        {
            _title = title;
            _body = body;
            _publishedDate = publishedDate;
            _author = author;
        }
    }

    public class Answer
    {
        public string _body { get; set; }
        public string _publishedDate { get; set; }
        public string _author { get; set; }
        public string _likes { get; set; }


        public Answer(string body, string publishedDate, string author)
        {
            _body = body;
            _publishedDate = publishedDate;
            _author = author;
        }
    }

    //public class Group
    //{
    //    public string TelligentGroupID { get; set; }
    //    public string GroupID { get; set; }
    //    public string ModeratorID { get; set; }
    //    public string NumOfMembers {get;set;}
    //    public string NumOfDiscussions { get; set; }
    //    public string Description { get; set; }
    //}
}
