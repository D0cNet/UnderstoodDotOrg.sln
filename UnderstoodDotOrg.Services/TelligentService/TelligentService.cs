using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Common.Helpers;

namespace UnderstoodDotOrg.Services.TelligentService
{
    public class TelligentService
    {
        private static string GetApiEndPoint(string path)
        {
            // Normalize path
            if (path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            return String.Format("{0}api.ashx/v2/{1}",
                            Settings.GetSetting(Constants.Settings.TelligentConfig),
                            path);
        }

        public static string TelligentAuth()
        {
            //Telligent Forum info
            string adminKeyBase64 = String.Empty;
            string keyTest = Settings.GetSetting(Constants.Settings.TelligentAdminApiKey);
            var apiKey = String.IsNullOrEmpty(keyTest) ? "d956up05xiu5l8fn7wpgmwj4ohgslp" : keyTest;

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));
            return adminKeyBase64;
        }

        public static List<Comment> ReadComments(string blogId, string blogPostId)
        {
            List<Comment> commentList = new List<Comment>();

            int id = 0;
            int postId = 0;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId)
                || !Int32.TryParse(blogId, out id) || !Int32.TryParse(blogPostId, out postId))
            {
                return commentList;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts/{2}/comments.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), id, postId);
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");

                    int nodecount = 0;
                    foreach (XmlNode xn in nodes)
                    {

                        XmlNode author = xn.SelectSingleNode("Author");

                        string commentId = xn["CommentId"].InnerText;
                        string commentDate = xn["PublishedDate"].InnerText;
                        DateTime parsedDate = DateTime.Parse(commentDate);

                        Comment comment = new Comment
                        {
                            Id = xn["Id"].InnerText,
                            Url = xn["Url"].InnerText,
                            ParentId = xn["ParentId"].InnerText,
                            ContentId = xn["ContentId"].InnerText,
                            IsApproved = xn["IsApproved"].InnerText,
                            ReplyCount = xn["ReplyCount"].InnerText,
                            CommentId = commentId,
                            CommentContentTypeId = xn["CommentContentTypeId"].InnerText,
                            Body = xn["Body"].InnerText,
                            PublishedDate = DataFormatHelper.FormatDate(commentDate),
                            AuthorId = author["Id"].InnerText,
                            AuthorAvatarUrl = author["AvatarUrl"].InnerText,
                            AuthorDisplayName = author["DisplayName"].InnerText,
                            AuthorProfileUrl = author["ProfileUrl"].InnerText,
                            AuthorUsername = author["Username"].InnerText,
                            Likes = GetTotalLikes(commentId).ToString(),
                            CommentDate = parsedDate
                        };
                        // Comment comment = new Comment(xn);
                        commentList.Add(comment);

                        nodecount++;
                    }
                }
                catch { } // TODO: add logging
            }
            return commentList;
        }

        public static int GetTotalLikes(string contentId)
        {
            int count = 0;
            Guid guid = Guid.Empty;

            if (Guid.TryParse(contentId, out guid))
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        // TODO: add validation for invalid content id

                        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                        var requestUrl = GetApiEndPoint(string.Format("likes.xml?ContentId={0}&PageSize=1",
                            guid.ToString()));

                        var xml = webClient.DownloadString(requestUrl);

                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/Likes");

                        if (node != null)
                        {
                            count = Convert.ToInt32(node.Attributes["TotalCount"].Value);
                        }

                    }
                    catch { }
                }
            }

            return count;
        }
    }
}
