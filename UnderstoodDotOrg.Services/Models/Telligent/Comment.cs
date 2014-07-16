using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using System.Data;
using System.Xml;

namespace UnderstoodDotOrg.Services.Models.Telligent
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
        public Guid SitecoreId { get; set; }

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
        public Comment(XmlNode xn)
        {
            if (xn != null)
            {
                XmlNode author = xn.SelectSingleNode("User");

                string commentId = xn["CommentId"].InnerText;
                string commentDate = xn["CreatedDate"].InnerText;
                DateTime parsedDate = DateTime.Parse(commentDate);

                // Id = xn["Id"].InnerText;
                //Url = xn["Url"].InnerText;
                //   ParentId = xn["ParentId"].InnerText;
                //   ContentId = xn["ContentId"].InnerText;
                IsApproved = xn["IsApproved"].InnerText;
                ReplyCount = xn["ReplyCount"].InnerText;
                CommentId = commentId;
                CommentContentTypeId = xn["CommentContentTypeId"].InnerText;
                Body = xn["Body"].InnerText;
                PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(commentDate);
                AuthorId = author["Id"].InnerText;
                AuthorAvatarUrl = author["AvatarUrl"].InnerText;
                AuthorDisplayName = author["DisplayName"].InnerText;
                AuthorProfileUrl = author["ProfileUrl"].InnerText;
                AuthorUsername = author["Username"].InnerText;
                Likes = TelligentService.TelligentService.GetTotalLikes(commentId).ToString();
                //ParentTitle = xn["Content"]["Application"]["Container"]["HtmlName"].InnerText;
                //CommentTitle = xn["Content"]["HtmlName"].InnerText;
                Guid sitecoreGuid = Guid.Empty;
                // NOTE: telligent adds HTML that needs to be stripped
                Guid.TryParse(Sitecore.StringUtil.RemoveTags(xn["Content"]["HtmlDescription"].InnerText), out sitecoreGuid);
                SitecoreId = sitecoreGuid;
                CommentDate = parsedDate;
            }

        }
    }
}
