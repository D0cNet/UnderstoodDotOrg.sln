using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class CommentsTestControl : System.Web.UI.UserControl
    {
        string apiKey = "vr7sr63ehedv0gcxzlk8s71l1xrctb3";
        int blogId = 1;
        int blogPostId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Comment> dataSource = ReadComments(apiKey, blogId, blogPostId);

            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();

            if (!IsPostBack)
            {
                CommentEntryTextField.Text = "Add your comment...";
            }
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
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/comments/353B457F-38B8-42E1-ADC0-4D226C41C67D.xml";

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
            int commentCount = nodes.Count;
            List<Comment> commentList = new List<Comment>();
            int nodecount = 0;
            foreach (XmlNode xn in nodes)
            {
                string id = xn["CommentId"].InnerText;
                string body = xn["Body"].InnerText;
                string dateTime = xn["PublishedDate"].InnerText;
                string publishedDate = FormatDate(dateTime);
                string username = nodes2[nodecount]["Username"].InnerText;
                string likesCount = ReadLikes(apiKey, id);
                Comment comment = new Comment(id, body, username, publishedDate, likesCount);
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
            public string _body { get; set; }
            public string _username { get; set; }
            public string _date { get; set; }
            public string _likes { get; set; }

            public Comment(string id, string body, string username, string date, string likes)
            {
                _id = id;
                _body = body;
                _username = username;
                _date = date;
                _likes = likes;
            }

        }
    }
}