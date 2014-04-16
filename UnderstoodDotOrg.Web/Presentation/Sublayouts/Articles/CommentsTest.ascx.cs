using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class CommentsTest : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CommentButton_Click(object sender, EventArgs e)
        {
            string commentText = CommentText.Text;
            PostBlogComment(commentText);
        }

        public static string ReadBlogsBody(string apiKey, int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = "http://localhost/telligentevolution/api.ashx/v2/blogs/" + blogId + "/posts/" + blogPostId + ".xml";

            var xml = webClient.DownloadString(requestUrl);

            string[] b = xml.Split(new string[] { "<Body>" }, StringSplitOptions.None);

            for (int i = 1; i % 2 != 0; i++)
            {
                string[] blogposts = b[i].Split(new string[] { "</Body>" }, StringSplitOptions.None);

                for (int f = 0; f % 2 == 0; f++)
                {
                    return blogposts[f];
                }
            }
            return null;
        }

        public static void PostBlogComment(string body)
        {
            var webClient = new WebClient();

            var adminKey = string.Format("{0}:{1}", "vr7sr63ehedv0gcxzlk8s71l1xrctb3", "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var postUrl = "http://localhost/telligentevolution/api.ashx/v2/blogs/1/posts/1/comments.xml ";
            var data = "Body=" + body + "&PublishedDate=" + DateTime.Now + "&IsApproved=true&BlogId=1";

            webClient.UploadData(postUrl, "POST", Encoding.ASCII.GetBytes(data));
        }

    }
}