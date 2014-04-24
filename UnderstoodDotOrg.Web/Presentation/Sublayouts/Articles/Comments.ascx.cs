using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : System.Web.UI.UserControl
    {
        public static string apiKey = "vr7sr63ehedv0gcxzlk8s71l1xrctb3";
        public static int commentCount;
        public static int blogId = 1;
        public static int blogPostId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Comment> dataSource = ReadComments(apiKey, blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
            CommentCountDisplay.Text = "Comments (" + commentCount + ")";

            if (!IsPostBack) { CommentEntryTextField.Text = "Add your comment..."; }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string body = CommentEntryTextField.Text;
            PostComment(apiKey, blogId, blogPostId, body);
            List<Comment> dataSource = ReadComments(apiKey, blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
        }

        protected void FlagButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Method", "PUT");
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/comments/" + id + ".xml";

            var values = new NameValueCollection();
            values.Add("CommentId", id);
            values.Add("IsApproved", "false");

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);
        }

        protected void ReplyButton_Click(object sender, EventArgs e)
        {
            CommentEntryTextField.Focus();
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ids = btn.CommandArgument;
            string[] s = ids.Split('&');

            string contentId = s[0];
            string contentTypeId = s[1];

            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/likes.xml";

            var values = new NameValueCollection();
            values.Add("ContentId", contentId);
            values.Add("ContentTypeId", contentTypeId);

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);

            List<Comment> dataSource = ReadComments(apiKey, blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();
        }

        protected static void PostComment(string apiKey, int blogId, int blogPostId, string body)
        {
            var webClient = new WebClient();

            var adminKey = string.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var postUrl = "http://localhost/telligentevolution/api.ashx/v2/blogs/" + blogId + "/posts/" + blogPostId + "/comments.xml ";
            var data = "Body=" + body + "&PublishedDate=" + DateTime.Now + "&IsApproved=true&BlogId=" + blogId;

            webClient.UploadData(postUrl, "POST", Encoding.ASCII.GetBytes(data));
        }

        static List<Comment> ReadComments(string apiKey, int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/blogs/" + blogId + "/posts/" + blogPostId + "/comments.xml";
            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");
            XmlNodeList nodes2 = xmlDoc.SelectNodes("Response/Comments/Comment/Author");
            commentCount = nodes.Count;
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
                string publishedDate = FormatDate(dateTime);
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
                //Console.WriteLine("Comment: {0} {1} {2}", username, id, body);
            }
            return commentList;
        }

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
                publishedDate = "Published yesterday";
            }
            if (timeSince.Equals("0"))
            {
                date = DateTime.Parse(d[1]);
                s = now.TimeOfDay.Subtract(date.TimeOfDay);
                span = (int)s.TotalSeconds;
                if (span < 60)
                {
                    return "Published just now";
                }
                if (span < 120)
                {
                    return "Published 1 minute ago";
                }
                if (span < 3600)
                {
                    return string.Format("Published {0} minutes ago",
                        Math.Floor((double)span / 60));
                }
                if (span < 7200)
                {
                    return "Published 1 hour ago";
                }
                if (span < 86400)
                {
                    return string.Format("Published {0} hours ago",
                        Math.Floor((double)span / 3600));
                }
            }
            return publishedDate;
        }

        public static string ReadLikes(string apiKey, string commentId)
        {
            var webClient = new WebClient();

            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/likes.xml?ContentId=" + commentId;

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Likes/Like");

            string likes = nodes.Count.ToString();

            return likes;
        }

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
                    string authorDisplayName, string authorProfileUrl, string likes)
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
            }
        }
    }
}