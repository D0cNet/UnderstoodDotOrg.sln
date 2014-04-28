using System;
using System.Net;
using System.Text;
using System.Xml;

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
            blogBody.Text = ReadBlogBody(apiKey, blogId, blogPostId);
        }
        public static string ReadBlogBody(string apiKey, int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/blogs/" + blogId + "/posts/" + blogPostId + ".xml";

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPost");
                string body = nodes[0]["Body"].InnerText;
            return body;
        }
    }
}