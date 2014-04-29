using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Importer;

namespace UnderstoodDotOrg.Domain.TelligentCommunity
{
    public class CommunityHelper
    {
        public static string FormatDate(string dateTime)
        {
            string[] d = dateTime.Split('T');
            DateTime date = DateTime.Parse(d[0]);
            DateTime now = DateTime.Now;
            TimeSpan s = now.Subtract(date);
            int span = (int)s.TotalDays;
            string timeSince = span.ToString();
            string publishedDate = "Published " + timeSince + " days ago";
            if (timeSince.Equals("1"))
            {
                publishedDate = "yesterday";
            }
            if (timeSince.Equals("0"))
            {
                date = DateTime.Parse(d[1]);
                s = now.TimeOfDay.Subtract(date.TimeOfDay);
                span = (int)s.TotalSeconds;
                if (span < 60)
                {
                    return "just now";
                }
                if (span < 120)
                {
                    return "1 minute ago";
                }
                if (span < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)span / 60));
                }
                if (span < 7200)
                {
                    return "Published 1 hour ago";
                }
                if (span < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)span / 3600));
                }
            }
            return publishedDate;
        }

        public static List<Comment> ReadComments(string apiKey, int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var requestUrl = String.Format("{0}/api.ashx/v2/blogs/{1}/posts/{2}/comments.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);
            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");
            XmlNodeList nodes2 = xmlDoc.SelectNodes("Response/Comments/Comment/Author");
            List<Comment> commentList = new List<Comment>();
            int nodecount = 0;
            foreach (XmlNode xn in nodes)
            {
                string id = xn["Id"].InnerText;
                string url = xn["Url"].InnerText;
                string parentId = xn["ParentId"].InnerText;
                string contentId = xn["ContentId"].InnerText;
                string isApproved = xn["IsApproved"].InnerText;
                string replyCount = xn["ReplyCount"].InnerText;
                string commentId = xn["CommentId"].InnerText;
                string commentContentTypeId = xn["CommentContentTypeId"].InnerText;
                string body = xn["Body"].InnerText;
                string dateTime = xn["PublishedDate"].InnerText;
                string publishedDate = CommunityHelper.FormatDate(dateTime);
                string authorId = nodes2[nodecount]["Id"].InnerText;
                string authorAvatarUrl = nodes2[nodecount]["AvatarUrl"].InnerText;
                string authorDisplayName = nodes2[nodecount]["DisplayName"].InnerText;
                string authorProfileUrl = nodes2[nodecount]["ProfileUrl"].InnerText;
                string authorUsername = nodes2[nodecount]["Username"].InnerText;
                string likesCount = ReadLikes(apiKey, commentId);
                Comment comment = new Comment(id, url, body, parentId, contentId, isApproved, replyCount, commentId,
                    commentContentTypeId, authorId, authorAvatarUrl, authorUsername, publishedDate, authorDisplayName,
                    authorProfileUrl, likesCount);
                commentList.Add(comment);
                nodecount++;
            }
            return commentList;
        }

        public static BlogPost ReadBlogBody(string apiKey, int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = string.Format("{0}/api.ashx/v2/blogs/{1}/posts/{2}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPost");
            XmlNodeList nodes2 = xmlDoc.SelectNodes("Response/BlogPost/Author");
            string body = nodes[0]["Body"].InnerText;
            string title = nodes[0]["Title"].InnerText;
            string dateTime = nodes[0]["PublishedDate"].InnerText;
            string publishedDate = CommunityHelper.FormatDate(dateTime);
            string author = nodes2[0]["DisplayName"].InnerText;
            BlogPost blogPost = new BlogPost(body, title, publishedDate, author);
            return blogPost;
        }

        public static void PostComment(string apiKey, int blogId, int blogPostId, string body)
        {
            var webClient = new WebClient();

            var adminKey = string.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Impersonate-User", "BobbyTestUser");
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var postUrl = String.Format("{0}/api.ashx/v2/blogs/{1}/posts/{2}/comments.xml ", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);
            var data = "Body=" + body + "&PublishedDate=" + DateTime.Now + "&IsApproved=true&BlogId=" + blogId;

            webClient.UploadData(postUrl, "POST", Encoding.ASCII.GetBytes(data));
        }

        public static string ReadLikes(string apiKey, string commentId)
        {
            var webClient = new WebClient();

            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = String.Format("{0}/api.ashx/v2/likes.xml?ContentId={1}", Settings.GetSetting(Constants.Settings.TelligentConfig), commentId);

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Likes/Like");

            string likes = nodes.Count.ToString();

            return likes;
        }

    }
}
