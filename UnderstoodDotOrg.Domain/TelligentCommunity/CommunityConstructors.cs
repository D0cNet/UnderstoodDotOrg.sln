using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace UnderstoodDotOrg.Domain.TelligentCommunity
{
    public class Comment
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string ParentId { get; set; }
        public string ParentTitle { get; set; }
        public string ParentTitleUrl { get; set; }
        public string PublishedDate { get; set; }
        public string Likes { get; set; }
        public string CommentId { get; set; }
        public string CommentGroup { get; set; }
        public string CommentGroupUrl { get; set; }
        public string CommentTitle { get; set; }
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
        public string Type { get; set; }

        public Comment() { }

        public Comment(XmlNode xn)
        {
            if (xn != null)
            {
                XmlNode author = xn.SelectSingleNode("User");

                string commentId = xn["CommentId"].InnerText;
                string commentDate = xn["CreatedDate"].InnerText;
                DateTime parsedDate = DateTime.Parse(commentDate);

                Id = commentId;
                
                

                //Url = xn["Url"].InnerText;
             //   ParentId = xn["ParentId"].InnerText;
             //   ContentId = xn["ContentId"].InnerText;
                IsApproved = xn["IsApproved"].InnerText;
                ReplyCount = xn["ReplyCount"].InnerText;
                CommentId = commentId;
                CommentContentTypeId = xn["CommentContentTypeId"].InnerText;
                Body = xn["Body"].InnerText;
                PublishedDate = CommunityHelper.FormatDate(commentDate);
                AuthorId = author["Id"].InnerText;
                AuthorAvatarUrl = author["AvatarUrl"].InnerText;
                AuthorDisplayName = author["DisplayName"].InnerText;
                AuthorProfileUrl = author["ProfileUrl"].InnerText;
                AuthorUsername = author["Username"].InnerText;
                Likes = CommunityHelper.GetTotalLikes(commentId).ToString();
                CommentDate = parsedDate;
                ParentTitle = xn["Content"]["Application"]["Container"]["HtmlName"].InnerText;
                CommentTitle = xn["Content"]["HtmlName"].InnerText;
                Type = xn["Content"]["Application"]["HtmlName"].InnerText;

                if (Type.Equals("Articles"))
                {
                    Url = "/";
                }
                else
                {
                    Url = "/Community and Events/Blogs/" + Type + "/" + CommentTitle;
                }
            }
        
        }
    }

    public class BlogPost
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string BlogName { get; set; }
        public string ContentId { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentUrl { get; set; }
        public string Url { get; set; }
        public string ParentUrl { get; set; }

        public BlogPost() { }
    }

    public class Blog
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string BlogId { get; set; }
        public string Url { get; set; }

        public Blog() { }
    }

    public class User
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string PrivateEmail { get; set; }
        public bool AllowSiteToContact { get; set; }
        public DateTime Birthday { get; set; }
        public string EditorType { get; set; }
        public bool ReceiveEmails { get; set; }
        public bool EnableTracking { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public double TimeZone { get; set; }
        public string WebUrl { get; set; }
        public string AvatarUrl { get; set; }

        public User()
        {

        }
    }

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
        public string Url { get; set; }

        public Question() { }
    }

    public class Answer
    {
        public string Body { get; set; }
        public string PublishedDate { get; set; }
        public string Author { get; set; }
        public string Likes { get; set; }
        public string Count { get; set; }

        public Answer() { }
    }

    public class Notification
    {
        public string Username { get; set; }
        public string Author { get; set; }
        public string NotificationId { get; set; }
        public string ContentId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string Url { get; set; }

        public Notification() { }
    }

    public class GroupModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        
        public GroupModel() { }
    }

    public class FavoritesModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string ReplyCount { get; set; }
        public Guid ContentId { get; set; }
        public string ContentTypeId { get; set; }
        public string Url { get; set; }
        
        public FavoritesModel() { }
    }

    public class LikeModel
    {
        public string ContentUrl { get; set; }
        public string ContentTypeId { get; set; }

        public LikeModel() { }
    }

    public class BookmarkModel
    {
        public string Username { get; set; }
        public string TelligentUrl { get; set; }

        public BookmarkModel() { }
    }
}