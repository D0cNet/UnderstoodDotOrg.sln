using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
            string apiKey = "vr7sr63ehedv0gcxzlk8s71l1xrctb3";
            int blogId = 1;
            int blogPostId = 1;
            string body = CommentEntryTextField.Text;
            PostComment(apiKey, blogId, blogPostId, body);
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
            int commentCount = nodes.Count;
            List<Comment> commentList = new List<Comment>();
            int nodecount = 0;
            foreach (XmlNode xn in nodes)
            {
                string id = xn["Id"].InnerText;
                string body = xn["Body"].InnerText;
                string date = xn["PublishedDate"].InnerText;
                string[] d = date.Split('T');
                string publishedDate = d[0] + " " + d[1];
                string username = nodes2[nodecount]["Username"].InnerText;
                Comment comment = new Comment(id, body, username, publishedDate);
                commentList.Add(comment);
                //Console.WriteLine("Comment: {0} {1} {2}", username, id, body);
            }
            return commentList;
        }
        public class Comment
        {
            public string _id { get; set; }
            public string _body { get; set; }
            public string _username { get; set; }
            public string _date { get; set; }

            public Comment(string id, string body, string username, string date)
            {
                _id = id;
                _body = body;
                _username = username;
                _date = date;
            }

        }
    }
}