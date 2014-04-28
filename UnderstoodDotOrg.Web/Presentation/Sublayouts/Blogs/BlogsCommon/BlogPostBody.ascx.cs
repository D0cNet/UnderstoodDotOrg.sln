using System;
using System.Net;
using System.Text;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogPostBody : System.Web.UI.UserControl
    {
        public static string apiKey = "vr7sr63ehedv0gcxzlk8s71l1xrctb3";
        public static int commentCount;
        public static int blogId = 2;
        public static int blogPostId = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogPost bp = ReadBlogBody(apiKey, blogId, blogPostId);
            BlogTitle.Text = bp._title;
            BlogBody.Text = bp._body;
            BlogDate.Text = bp._publishedDate;
            BlogAuthor.Text = bp._author;
        }
        public BlogPost ReadBlogBody(string apiKey, int blogId, int blogPostId)
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
            string publishedDate = FormatDate(dateTime);
            string author = nodes2[0]["DisplayName"].InnerText;
            BlogPost blogPost = new BlogPost(body, title, publishedDate, author);
            return blogPost;
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
        public class BlogPost
        {
            public string _body { get; set; }
            public string _title { get; set; }
            public string _publishedDate { get; set; }
            public string _author { get; set; }

            public BlogPost(string body, string title, string publishedDate, string author)
            {
                _body = body;
                _title = title;
                _publishedDate = publishedDate;
                _author = author;
            }
        }
    }
}