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
        public string Id { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string ParentId { get; set; }
        public string PublishedDate { get; set; }
        public string Likes { get; set; }
        public string CommentId { get; set; }
        public string ContentId { get; set; }
        public string CommentContentTypeId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorAvatarUrl { get; set; }
        public string AuthorDisplayName { get; set; }
        public string AuthorProfileUrl { get; set; }
        public string ReplyCount { get; set; }
        public string IsApproved { get; set; }
        public string AuthorUsername { get; set; }
        public DateTime CommentDate { get; set; }

        public Comment() { }

        public Comment(string id, string url, string body, string parentId, string contentId, string isApproved, string replyCount,
            string commentId, string commentContentTypeId, string authorId, string authorAvatarUrl, string authorUsername, string publishedDate,
                string authorDisplayName, string authorProfileUrl, string likes, string commentDate)
        {
            Id = id;
            Url = url;
            Body = body;
            ParentId = parentId;
            ContentId = contentId;
            IsApproved = isApproved;
            ReplyCount = replyCount;
            CommentId = commentId;
            CommentContentTypeId = commentContentTypeId;
            PublishedDate = publishedDate;
            AuthorId = authorId;
            AuthorAvatarUrl = authorAvatarUrl;
            AuthorDisplayName = authorDisplayName;
            AuthorProfileUrl = authorProfileUrl;
            AuthorUsername = authorUsername;
            Likes = likes;
            CommentDate = DateTime.Parse(commentDate);
        }
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
                string[] u = url[1].Split('<');
                _sitecoreUrl = u[0];
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
        public string _commentCount { get; set; }
        public string _wikiId { get; set; }
        public string _wikiPageId { get; set; }
        public string _contentId { get; set; }
        public string _queryString { get; set; }

        public Question(string title, string body, string publishedDate, string author, string group, string commentCount, string wikiId, string wikiPageId, string contentId)
        {
            _title = title;
            _body = body;
            _publishedDate = publishedDate;
            _author = author;
            _group = group;
            _commentCount = commentCount;
            _wikiId = wikiId;
            _wikiPageId = wikiPageId;
            _contentId = contentId;
            _queryString = "?wikiId=" + _wikiId + "&wikiPageId=" + _wikiPageId + "&contentId=" + _contentId;
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
