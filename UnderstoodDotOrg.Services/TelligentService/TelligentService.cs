using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Domain.Understood.Services;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Common.Extensions;
using System.IO;
using UnderstoodDotOrg.Services.CommunityServices;
using Sitecore.Data.Items;
using System.Xml.Serialization;
namespace UnderstoodDotOrg.Services.TelligentService
{
    public class TelligentService
    {
        public static string FormatString100(string inputString)
        {
            if (inputString.Length >= 100)
            {
                string myString = inputString.Substring(0, 100);

                int index = myString.LastIndexOf(' ');
                //Have to check the value for index
                if (index > -1)
                    myString = myString.Substring(0, index);

                return myString;
            }
            else
            {
                return inputString;
            }
        }

        public static string FormatString160(string inputString)
        {
            if (inputString.Length >= 160)
            {
                string myString = inputString.Substring(0, 160);

                int index = myString.LastIndexOf(' ');
                //Have to check the value for index
                if (index > -1)
                    myString = myString.Substring(0, index);

                return myString;
            }
            else
            {
                return inputString;
            }
        }

        internal static string GetApiEndPoint(string path)
        {
            // Normalize path
            if (path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            return String.Format("{0}/api.ashx/v2/{1}",
                            Settings.GetSetting(Constants.Settings.TelligentConfig).TrimEnd('/'),
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
        public static Question CreateQuestion(string title, string body, string grade, string topic, List<string> issues, string currentUser)
        {
            String wikiId = "2";

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                    currentUser = currentUser.Trim().ToLower();
                    webClient.Headers.Add("Rest-Impersonate-User", currentUser.ToLower());

                    // TODO: change to constant
                    var requestUrl = GetApiEndPoint(String.Format("wikis/{0}/pages.xml", wikiId));

                    var values = new NameValueCollection();
                    values["Title"] = title;
                    values["Body"] = body;

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Console.WriteLine(xml);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/WikiPage");
                    string contentId = node["ContentId"].InnerText;
                    string wikiPageId = node["Id"].InnerText;
                    string queryString = "?wikiId=2&wikiPageId=" + wikiPageId + "&contentId=" + contentId;

                    var question = new Question()
                    {
                        Title = node["Title"].InnerText,
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(node["CreatedDate"].InnerText),
                        Body = node["Body"].InnerText,
                        //Author = user["Username"].InnerText,
                        //Group = app["HtmlName"].InnerText,
                        CommentCount = node["CommentCount"].InnerText,
                        WikiId = wikiId,
                        WikiPageId = wikiPageId,
                        ContentId = contentId,
                        QueryString = queryString
                    };

                    return question;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static void PostAnswer(string wikiId, string wikiPageId, string body, string currentUser)
        {
            using (var webClient = new WebClient())
            {
                if (!currentUser.Equals("admin"))
                {
                    try
                    {
                        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                        currentUser = currentUser.Trim().ToLower();
                        webClient.Headers.Add("Rest-Impersonate-User", currentUser);

                        var postUrl = GetApiEndPoint(String.Format("wikis/{0}/pages/{1}/comments.xml", wikiId, wikiPageId));

                        var data = new NameValueCollection()
                        {
                            { "Body", body },
                            { "PublishedDate", DateTime.Now.ToString() },
                            { "IsApproved", "true" },
                            { "BlogId", wikiId }
                        };

                        byte[] result = webClient.UploadValues(postUrl, data);
                        // TODO: handle errors
                        string response = webClient.Encoding.GetString(result);
                    }
                    catch { } //TODO: Add logging
                }
            }
        }

        public static bool PostComment(int blogId, int blogPostId, string body, string currentUser)
        {
            if (currentUser == "admin")
            {
                return false;
            }

            var postUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml", blogId, blogPostId));

            var data = new NameValueCollection()
            {
                { "Body", body },
                { "PublishedDate", DateTime.Now.ToString() },
                { "IsApproved", "true" },
                { "BlogId", blogId.ToString() }
            };

            try
            {
                MakeApiRequest(wc =>
                {
                    currentUser = currentUser.Trim().ToLower();
                    wc.Headers.Add("Rest-Impersonate-User", currentUser);

                    byte[] result = wc.UploadValues(postUrl, data);

                    string response = wc.Encoding.GetString(result);
                });

                return true;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Error posting comment: {0}", postUrl), ex);
                return false;
            }
        }

        public static List<Comment> ReadComments(string blogId, string blogPostId, int page, int pageSize, CommentSortOption sortOption, out int totalComments, out bool hasMoreResults)
        {
            return ReadComments(blogId, blogPostId, page, pageSize, sortOption.Value, sortOption.SortAscending, out totalComments, out hasMoreResults);
        }

        public static List<Comment> ReadComments(string blogId, string blogPostId, int page, int pageSize, string sortBy, bool sortAscending, out int totalComments, out bool hasMoreResults)
        {
            List<Comment> commentList = new List<Comment>();

            hasMoreResults = false;
            totalComments = 0;

            int id = 0;
            int postId = 0;

            int pageIndex = (page >= 1) ? page - 1 : 0;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId)
                || !Int32.TryParse(blogId, out id) || !Int32.TryParse(blogPostId, out postId))
            {
                return commentList;
            }

            string baseUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml",
                            id, postId));

            var sortOrder = sortAscending ? "Ascending" : "Descending";

            var query = new Dictionary<string, string>
            {
                { "PageIndex", pageIndex.ToString() },
                { "PageSize", pageSize.ToString() },
                { "SortBy", sortBy },
                { "SortOrder", sortOrder }
            };

            var requestUrl = HttpHelper.AssembleUrl(baseUrl, query);

            int commentCount = 0;

            try
            {
                MakeApiRequest(wc =>
                {
                    var xml = wc.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode commentsNode = xmlDoc.SelectSingleNode("Response/Comments");

                    if (commentsNode != null)
                    {
                        commentCount = Convert.ToInt32(commentsNode.Attributes["TotalCount"].Value);

                        XmlNodeList nodes = commentsNode.SelectNodes("Comment");

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

                            commentList.Add(comment);
                        }
                    }
                });

                totalComments = commentCount;
                hasMoreResults = (pageIndex * pageSize) + commentList.Count() < totalComments;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Error retrieving comments: {0}", requestUrl), ex);
            }

            return commentList;
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
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return commentList;
        }

        public static bool LikeContent(string screenName, string contentId, string contentTypeId)
        {
            var requestUrl = GetApiEndPoint("likes.xml");
            var values = new NameValueCollection
            {
                { "ContentId", contentId },
                { "ContentTypeId", contentTypeId }
            };

            try
            {
                MakeApiRequest(wc =>
                {
                    wc.Headers.Add("Rest-Impersonate-User", screenName);

                    string response = Encoding.UTF8.GetString(wc.UploadValues(requestUrl, values));
                });

                return true;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Error liking comment: {0}", contentId), ex);
                return false;
            }
        }

        public static bool FlagComment(string contentId)
        {
            var requestUrl = GetApiEndPoint(String.Format("comments/{0}.xml", contentId));
            var values = new NameValueCollection
            {
                { "CommentId", contentId },
                { "IsApproved", "false" }
            };

            try
            {
                MakeApiRequest(wc =>
                {
                    wc.Headers.Add("Rest-Method", "PUT");
                    string response = Encoding.UTF8.GetString(wc.UploadValues(requestUrl, values));
                });

                return true;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Error flagging comment: {0}", contentId), ex);
                return false;
            }
        }

        private static void MakeApiRequest(Action<WebClient> action)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Rest-User-Token", TelligentAuth());

                action(wc);
            }
        }

        public static int GetTotalLikes(string contentId)
        {
            int count = 0;

            var requestUrl = GetApiEndPoint(
                string.Format("likes.xml?ContentId={0}&PageSize=1", contentId));

            try
            {
                MakeApiRequest(wc =>
                {
                    var response = wc.DownloadString(requestUrl);
                    var xml = new XmlDocument();
                    xml.LoadXml(response);

                    XmlNode node = xml.SelectSingleNode("Response/Likes");
                    if (node != null)
                    {
                        count = Convert.ToInt32(node.Attributes["TotalCount"].Value);
                    }
                });
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Error retrieving likes: {0}", contentId), ex);
            }

            return count;
        }

        public static Comment ReadComment(string commentId)
        {
            var webClient = new WebClient();

            Comment comment = null;

            string adminKeyBase64 = TelligentAuth();
            if (!String.IsNullOrEmpty(commentId))
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var requestUrl = String.Format("{0}api.ashx/v2/comments/{1}.xml", Sitecore.Configuration.Settings.GetSetting("TelligentConfig"), commentId);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    var node = xmlDoc.SelectSingleNode("Response/Comment");
                    if (node != null)
                        comment = new Comment(node);
                }
                catch (Exception ex)
                {
                    comment = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return comment;
        }
        public static XmlNode ReadUserComments(string username, string contentId = null, string commentUser = null)
        {
            var webClient = new WebClient();
            XmlNode node = null;
            username = username.Trim();
            string adminKeyBase64 = TelligentAuth();
            try
            {
                //TODO: retrieve current logged in user
                var userId = ReadUserId(username);

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                webClient.Headers.Add("Rest-Impersonate-User", username);
                string requestUrl = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") + "api.ashx/v2/comments.xml";

                if (contentId != null)
                    requestUrl = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") + "api.ashx/v2/comments.xml?ContentId=" + contentId;


                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response");
                if (commentUser != null)
                {
                    var selectedNode = node.SelectSingleNode("Comments/Comment[ User/Username='" + commentUser + "'][last()]");
                    node = selectedNode;
                }
            }
            catch (Exception ex)
            {
                node = null;
                Sitecore.Diagnostics.Log.Error(ex.Message, ex);
            }
            return node;

        }

        public static int GetTotalComments(string blogId, string blogPostId)
        {
            int count = 0;
            int id = 0;
            int postId = 0;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId)
                || !Int32.TryParse(blogId, out id) || !Int32.TryParse(blogPostId, out postId))
            {
                return count;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                    // TODO: Add error handling for invalid ids

                    var requestUrl = GetApiEndPoint(String.Format("blogs/{0}/posts/{1}/comments.xml?PageSize=1",
                        blogId, blogPostId));
                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/Comments");

                    if (node != null)
                    {
                        count = Convert.ToInt32(node.Attributes["TotalCount"].Value);
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }

            return count;
        }
        public static BlogPost ReadBlogBody(int blogId, int blogPostId)
        {
            int id = 0;
            int postId = 0;
            BlogPost blogPost = new BlogPost();

            if (String.IsNullOrEmpty(blogId.ToString()) || String.IsNullOrEmpty(blogPostId.ToString())
                || !Int32.TryParse(blogId.ToString(), out id) || !Int32.TryParse(blogPostId.ToString(), out postId))
            {
                return blogPost;
            }

            using (var webClient = new WebClient())
            {
                try
                {
                    // replace the "admin" and "Admin's API key" with your valid user and apikey!
                    var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                    var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts/{2}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/BlogPost");

                    XmlNode auth = xmlDoc.SelectSingleNode("Response/BlogPost/Author");


                    blogPost = new BlogPost
                    {
                        Body = node["Body"].InnerText,
                        Title = node["Title"].InnerText,
                        ContentId = node["ContentId"].InnerText,
                        BlogName = node["HtmlName"].InnerText,
                        PublishedDate = DataFormatHelper.FormatDate(node["PublishedDate"].InnerText),
                        Author = auth["DisplayName"].InnerText
                    };

                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return blogPost;
        }

        public static Blog ReadBlog(string blogId)
        {
            Blog blog = null;
            XmlNode node = null;
            using (var webClient = new WebClient())
            {
                try
                {
                    // replace the "admin" and "Admin's API key" with your valid user and apikey!
                    var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                    var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId);

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    node = xmlDoc.SelectSingleNode("Response/Blog");

                    if (node != null)
                    {

                        blog = new Blog()
                        {
                            Description = node.SelectSingleNode("Description").InnerText,
                            Id = node.SelectSingleNode("Id").InnerText,
                            Title = node.SelectSingleNode("Name").InnerText

                        };
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return blog;
        }
        //public static List<Answer> GetAnswers(string wikiId, string wikiPageId, string contentId)
        //{
        //    string likes = GetTotalLikes(contentId).ToString();
        //    List<Answer> answerList = new List<Answer>();
        //    using (var webClient = new WebClient())
        //    {
        //        webClient.Headers.Add("Rest-User-Token", TelligentAuth());
        //        var requestUrl = GetApiEndPoint(string.Format("wikis/{0}/pages/{1}/comments.xml", wikiId, wikiPageId));

        //        var xml = webClient.DownloadString(requestUrl);

        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(xml);

        //        XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");
        //        int count = 0;
        //        foreach (XmlNode xn in nodes)
        //        {
        //            XmlNode user = xn.SelectSingleNode("Author");
        //            Answer answer = new Answer()
        //            {
        //                PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(xn["PublishedDate"].InnerText),
        //                Body = xn["Body"].InnerText,
        //                Author = user["Username"].InnerText,
        //                AuthorAvatar = user["AvatarUrl"].InnerText,
        //                Count = nodes.Count.ToString(),
        //                Likes = likes,
        //            };
        //            answerList.Add(answer);
        //            count++;
        //        }
        //    }
        //    return answerList;
        //}
        public static List<MemberCardModel> GetModerators()
        {
            var webClient = new WebClient();
            string adminKeyBase64 = TelligentAuth();


            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var roleid = Sitecore.Configuration.Settings.GetSetting("TelligentModeratorRoleID") ?? "3";
            var serverHost = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") ?? "localhost/telligent.com";
            var requestUrl = serverHost + "/api.ashx/v2/roles/" + roleid + "/users.xml";

            var xml = webClient.DownloadString(requestUrl);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var nodes = xmlDoc.SelectNodes("/Response/Users/User");
            //// PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
            //// lblCount.Text = nodes.Count.ToString();
            List<MemberCardModel> memberCardSrc = new List<MemberCardModel>();
            foreach (XmlNode item in nodes)
            {
                MemberCardModel cm = new MemberCardModel();
                cm.AvatarUrl = item.SelectSingleNode("AvatarUrl").InnerText;

                // TODO: This is to change once we figure out retrieving users by roleid
                cm.UserLabel = "Moderator";

                cm.UserLocation = item.SelectSingleNode("Location").InnerText;
                cm.UserName = item.SelectSingleNode("Username").InnerText;

                memberCardSrc.Add(cm);
                cm = null;
            }
            return memberCardSrc;

        }

        public static int GetTotalUserComments(string userName)
        {
            List<Comment> comments = new List<Comment>();

            // TODO: revise user model to store user id instead of doing an extra lookup
            string userId = ReadUserId(userName);
            int totalEntries = 0;

            MakeApiRequest(wc =>
            {
                string address = GetApiEndPoint(String.Format("comments.xml?PageSize=1&UserId={0}", userId));
                NameValueCollection data = new NameValueCollection();

                string xml = wc.DownloadString(address);
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);

                XmlNode container = document.SelectSingleNode("Response/Comments");

                totalEntries = Convert.ToInt32(container.Attributes["TotalCount"].Value);
            });

            return totalEntries;
        }

        public static List<Comment> GetUserCommentsByUserId(string userId, int page, int pageSize, out int totalComments)
        {
            List<Comment> comments = new List<Comment>();

            int totalEntries = 0;
            int pageIndex = page - 1;

            MakeApiRequest(wc =>
            {
                string address = GetApiEndPoint(String.Format("comments.xml?PageIndex={0}&PageSize={1}&UserId={2}&SortBy=CreatedUtcDate&SortOrder=Descending",
                    pageIndex, pageSize, userId));

                string xml = wc.DownloadString(address);
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);

                XmlNode container = document.SelectSingleNode("Response/Comments");

                totalEntries = Convert.ToInt32(container.Attributes["TotalCount"].Value);

                foreach (XmlNode xn in container.SelectNodes("Comment"))
                {
                    Comment comment = new Comment(xn);
                    comments.Add(comment);
                }
            });

            totalComments = totalEntries;

            return comments;
        }

        // TODO: we shouldn't have to look up user id, refactor member model to store user id
        public static List<Comment> GetUserCommentsByScreenName(string userName, int page, int pageSize, out int totalComments)
        {
            string userId = ReadUserId(userName);

            return GetUserCommentsByUserId(userId, page, pageSize, out totalComments);
        }

        public static List<int> GetUserRoles(string Username)
        {
            //GET api.ashx/v2/roles/permissions/user/{username}.xml 

            var webClient = new WebClient();
            string adminKeyBase64 = TelligentAuth();
            string apiFragment = @"{0}/api.ashx/v2/roles/permissions/user/{1}.xml";

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var serverHost = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") ?? "localhost/telligent.com";
            var requestUrl = string.Format(apiFragment, serverHost, Username);

            var xml = webClient.DownloadString(requestUrl);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var nodes = xmlDoc.SelectNodes("/Response/Roles/Role");

            var response = new List<int>();
            foreach (XmlNode item in nodes)
            {
                response.Add(int.Parse(item.SelectSingleNode("Id").InnerText));
            }

            return response;
        }

        /// <summary>
        /// Gets a list of blog posts that a specified blog contains.
        /// </summary>
        /// <param name="blogId">As string, if multiple, separate with a comma. Ex:("1,2,4")</param>
        /// <param name="count">As string, this is the number of records to be returned.</param>
        /// <returns></returns>
        public static List<BlogPost> ListBlogPosts(string blogId, string count)
        {
            using (var webClient = new WebClient())
            {

                webClient.Headers.Add("Rest-User-Token", TelligentAuth());

                var requestUrl = GetApiEndPoint(string.Format("blogs/posts.xml?BlogIds={0}&PageSize={1}", blogId, count));

                var xml = webClient.DownloadString(requestUrl);

                List<BlogPost> blogPosts = new List<BlogPost>();

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPosts/BlogPost");
                foreach (XmlNode node in nodes)
                {
                    XmlNode author = node.SelectSingleNode("Author");
                    var blogName = TelligentService.BlogNameById(node["BlogId"].InnerText);
                    string title = string.Empty;
                    string sitecoreId = string.Empty;
                    string url = string.Empty;
                    if (node["Title"].InnerText.Contains("{"))
                    {
                        string[] s = node["Title"].InnerText.Split('{');
                        title = s[0];
                        url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{" + s[1]));
                    }
                    else
                    {
                        url = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) +
                        "/" + blogName + "/" + node["Title"].InnerText, ".aspx", "");
                    }
                    BlogPost blogPost = new BlogPost()
                    {
                        Title = node["Title"].InnerText,
                        ContentId = node["ContentId"].InnerText,
                        Body = FormatString100(node["Body"].InnerText),
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(node["PublishedDate"].InnerText),
                        BlogName = blogName,
                        Author = author["DisplayName"].InnerText,
                        // TODO: Fix this logic a lot
                        Url = url,
                        ParentUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) +
                        "/" + blogName, ".aspx", ""),
                        CommentCount = node["CommentCount"].InnerText,
                    };
                    blogPosts.Add(blogPost);
                }
                return blogPosts;
            }
        }

        public static string BlogNameById(string blogId)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                var requestUrl = GetApiEndPoint(string.Format("blogs/{0}.xml", blogId));

                var xml = webClient.DownloadString(requestUrl);

                Console.WriteLine(xml);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                var nodes = xmlDoc.SelectNodes("/Response/Blog");
                string blogName = nodes[0]["Name"].InnerText;
                return blogName;
            }
        }
        
        public static XmlNode ReadGroup(string groupID)
        {
            XmlNode node = null;

            if (!String.IsNullOrEmpty(groupID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    var xmlDoc = new XmlDocument();
                    var requestUrl = String.Format("{0}api.ashx/v2/groups/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), groupID);
                    var xml = webClient.DownloadString(requestUrl);

                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Group");
                }
                catch (Exception ex)
                {
                    node = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return node;

        }
        public static XmlNode ReadForum(string forumID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Forum");
            }
            return node;
        }
        public static XmlNode ReadForums(string groupID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(groupID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                var requestUrl = String.Format("{0}api.ashx/v2/groups/{1}/forums.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), groupID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Forums");
            }
            return node;
        }
        public static XmlNode ReadThreads(string forumID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}/threads.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Threads");
            }
            return node;
        }
        public static XmlNode ReadThread(string forumID, string threadID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID) && !String.IsNullOrEmpty(threadID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}/threads/{2}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID, threadID);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Thread");
                }
                catch (Exception ex)
                {
                    node = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            return node;
        }
        public static XmlNode ReadReply(string replyID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(replyID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                var requestUrl = String.Format("{0}api.ashx/v2/forums/threads/replies/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), replyID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Reply");
            }
            return node;
        }

        public static List<INotification> ReadFriendshipRequests(string username)
        {
            XmlNodeList node = null;
            List<INotification> notifications = new List<INotification>();
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/users/{1}/friends/pending.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), username);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectNodes("Response/Friendships/Friendship");
                    if (node != null)
                    {
                        foreach (XmlNode friend in node)
                        {
                            if (!friend.SelectSingleNode("RequestorId").InnerText.Equals(username))
                            {
                                notifications.Add(new ConnectNotification(friend));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    notifications = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }

            return notifications;

        }
        public static List<INotification> GetNotifications(string username)
        {
            Dictionary<string, Constants.NotificationElements.NotificationType> NotificationTypes = new Dictionary<string, Constants.NotificationElements.NotificationType>()
            {
                {"d0e2bf58-74b3-4090-8ff0-0d9a11188f0b",Constants.NotificationElements.NotificationType.Comment}, //Also commented on
              {"b005f46c-55c2-4f7b-afb0-d699fa8d33aa",Constants.NotificationElements.NotificationType.ForumAuthorReply},
                {"bb2f90fb-5630-4d0b-b1be-06e4a1307d35",Constants.NotificationElements.NotificationType.ForumReply},
                {"bb196c30-fad3-4ad8-a644-2a0187fc5617",Constants.NotificationElements.NotificationType.Connection} //Connection request

            };
            List<INotification> notifList = new List<INotification>();
            //Header info

            XmlNodeList node = null;
            // List<INotification> notifications = new List<INotification>();
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                webClient.Headers.Add("Rest-Impersonate-User", username);
                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/notifications.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectNodes("Response/Notifications/RestNotification");
                    if (node != null)
                    {
                        //Call last 5 Notifications for user

                        //Determine the type of notification using dictionary
                        foreach (XmlNode notification in node)
                        {
                            INotification notif = null;
                            if (NotificationTypes.ContainsKey(notification.SelectSingleNode("NotificationTypeId").InnerText))
                            {
                                Constants.NotificationElements.NotificationType notifType = NotificationTypes[notification.SelectSingleNode("NotificationTypeId").InnerText];
                                switch (notifType)
                                {
                                    case Constants.NotificationElements.NotificationType.ForumReply:
                                    case Constants.NotificationElements.NotificationType.ForumAuthorReply:
                                        var forumName = notification.SelectSingleNode("Content/Application/HtmlName").InnerText;
                                        var forumId = System.IO.Path.GetFileNameWithoutExtension(notification.SelectSingleNode("Content/Application/Url").InnerText);
                                        var replyId = notification.SelectSingleNode("TargetUrl").InnerText.Split('#')[1];
                                        var replyUser = notification.SelectSingleNode("Actors/RestNotificationActor[last()]/User/DisplayName").InnerText;
                                        //var createdDate = notification.SelectSingleNode("Actors/RestNotificationActor[last()]/Date").InnerText.Split('.')[0];
                                        if (replyId != null)
                                        {
                                            var replyBody = ReadReply(replyId);
                                            notif = new ForumReplyNotification(notification);
                                            if (replyBody != null)
                                            {
                                                ((ForumReplyNotification)notif).Text = replyBody.SelectSingleNode("Body").InnerText;
                                            }
                                        }
                                        Item frm = UnderstoodDotOrg.Services.CommunityServices.Forum.ConvertForumIDtoSitecoreItem(forumId);
                                        ((ForumReplyNotification)notif).ForumUrl = frm.GetUrl();
                                        ((ForumReplyNotification)notif).ForumTitle = frm.Name;
                                        notifList.Add(notif);
                                        break;
                                    case Constants.NotificationElements.NotificationType.Comment:
                                        var BlogName = notification.SelectSingleNode("Content/Application/HtmlName").InnerText;
                                        var contentId = notification.SelectSingleNode("Content/ContentId").InnerText;
                                        var commentUser = notification.SelectSingleNode("Actors/RestNotificationActor[last()]/User/DisplayName").InnerText;
                                        //var createdDate = notification.SelectSingleNode("Actors/RestNotificationActor[last()]/Date").InnerText.Split('.')[0];
                                        var comment = ReadUserComments(username, contentId, commentUser);
                                        notif = new CommentNotification(notification);
                                        if (comment != null)
                                        {
                                            ((CommentNotification)notif).Text = comment.SelectSingleNode("Body").InnerText;
                                        }
                                        // ((CommentNotification)notif).BlogUrl = UnderstoodDotOrg.Services.CommunityServices.Blogs.ConvertForumNametoSitecoreItem(forumName).GetUrl();
                                        notifList.Add(notif);
                                        break;
                                    case Constants.NotificationElements.NotificationType.Connection:
                                        notif = new ConnectNotification(notification);
                                        //Wire up Accept
                                        ((ConnectNotification)notif).evtOk += (o, e) =>
                                        {

                                            string friendshipstate = "Approved";
                                            if (TelligentService.UpdateFriendRequest(notif.UserName, username, friendshipstate))
                                            {
                                                //Push some Javascript notification that process complete
                                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowAcceptMessage", "alert('Request Accepted!');", true);
                                            }
                                        };

                                        //Wire up decline
                                        ((ConnectNotification)notif).evtCancel += (o, e) =>
                                            {
                                                string friendshipstate = "NotSpecified";
                                                if (TelligentService.UpdateFriendRequest(notif.UserName, username, friendshipstate))
                                                {

                                                }
                                            };
                                        notifList.Add(notif);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        //call respective notification type funtion and use contentid contenttypeid to get details of notification type

                        //Populate notification list
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in GetNotifications.\nError:\n" + ex.Message);
                    notifList = null;
                }
            }


            return notifList;
        }
        public static void PostReply(string forumID, string threadID, string body, string username)
        {


            WebClient webClient = new WebClient();
            string adminKeyBase64 = TelligentAuth();
            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Impersonate-User", username);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            try
            {
                var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}/threads/{2}/replies.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID, threadID);
                var values = new NameValueCollection();
                values["Body"] = body;

                var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex);
            }
        }
        public static List<ReplyModel> ReadReplies(string forumID, string threadID)
        {
            List<ReplyModel> replies = new List<ReplyModel>();
            if (!String.IsNullOrEmpty(forumID) && !String.IsNullOrEmpty(threadID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}/threads/{2}/replies.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID, threadID);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/Replies");

                    if (node != null)
                    {
                        foreach (XmlNode reply in node)
                        {
                            ReplyModel rpm = new ReplyModel(reply);
                            replies.Add(rpm);
                            rpm = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    replies = null;
                    Sitecore.Diagnostics.Error.LogError("Error in TelligentServices.ReadReplies. Error:\n" + ex.Message);
                }
            }
            return replies;
        }
        public static List<ThreadModel> ReadThreadList(string forumID)
        {
            List<ThreadModel> th = new List<ThreadModel>();
            try
            {
                var node = ReadThreads(forumID);
                foreach (XmlNode childNode in node)
                {
                    ThreadModel t = new ThreadModel(childNode, DataFormatHelper.FormatDate, FormatString100, ReadReplies);
                    th.Add(t);
                }
            }
            catch (Exception ex)
            {
                // th = null;
                Sitecore.Diagnostics.Log.Error(ex.Message, ex);
            }
            return th;
        }
        public static string ReadUserId(string username)
        {
            string Userid = null;
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();

                try
                {

                    XmlNode node = GetTelligentUserNode(username);
                    if (node != null)
                    {
                        //Read user id
                        Userid = node.SelectSingleNode("Id").InnerText;
                        //return Userid;
                    }
                }
                catch (Exception ex)
                {
                    Userid = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return Userid;
        }
        public static string ReadUserPoints(string username)
        {
            string strPoints = String.Empty;
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();

                try
                {

                    XmlNode node = GetTelligentUserNode(username);
                    if (node != null)
                    {
                        //Read user id
                        strPoints = node.SelectSingleNode("Points").InnerText;
                        //return Userid;
                    }
                }
                catch (Exception ex)
                {
                    strPoints = String.Empty;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return strPoints;
        }
        public static XmlNode GetTelligentUserNode(string username)
        {
            XmlNode User = null;
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/users/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), username);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/User");
                    if (node != null)
                    {
                        User = node;
                    }
                }
                catch (Exception ex)
                {
                    User = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return User;
        }
        public static List<ForumModel> ReadForumsList(string groupID)
        {
            List<ForumModel> fm = new List<ForumModel>();
            try
            {
                var node = ReadForums(groupID);
                foreach (XmlNode childNode in node)
                {
                    ForumModel f = new ForumModel(childNode, ReadThreadList);
                    fm.Add(f);
                }
            }
            catch (Exception ex)
            {
                fm = null;
                Sitecore.Diagnostics.Log.Error(ex.Message, ex);
            }
            return fm;
        }
        public static bool IsUserInGroup(string userScreenName, string groupID)
        {
            bool val = false;
            userScreenName = userScreenName.Trim();
            groupID = groupID.Trim();
            if (!String.IsNullOrEmpty(userScreenName) && !String.IsNullOrEmpty(groupID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/groups/{1}/members/users/{2}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), groupID, userScreenName);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/User/Group");

                    if (node != null)
                        val = true;
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                    return false;
                }
            }
            return val;

        }
        public static bool JoinGroup(string groupID, string userScreenName)
        {
            bool success = false;
            userScreenName = userScreenName.Trim();
            groupID = groupID.Trim();
            if (!String.IsNullOrEmpty(userScreenName) && !String.IsNullOrEmpty(groupID.Trim()))
            {
                string userid = ReadUserId(userScreenName);
                if (userid != null)
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        string adminKeyBase64 = TelligentAuth();
                        webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                        var requestUrl = string.Format("{0}api.ashx/v2/groups/{1}/members/users.xml ", Settings.GetSetting(Constants.Settings.TelligentConfig), groupID);

                        var values = new NameValueCollection();
                        values["UserId"] = userid;


                        var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        XmlNode node = xmlDoc.SelectSingleNode("Response/Errors");
                        if (node != null || !node.HasChildNodes)
                            success = true;
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                        return false;
                    }
                }
            }
            return success;
        }

        public static ThreadModel CreateForumThread(string username, string forumID, string subject, string body)
        {
            ThreadModel model = null;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(forumID) && !string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(body))
            {
                WebClient client = new WebClient();
                try
                {
                    client.Headers.Add("Rest-User-Token", TelligentAuth());
                    client.Headers.Add("Rest-Impersonate-User", username);
                    string address = string.Format(GetApiEndPoint("forums/{0}/threads.xml"), forumID);
                    NameValueCollection data = new NameValueCollection();
                    data["Subject"] = subject;
                    data["Body"] = body;
                    string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(xml);
                    XmlNode childNode = document.SelectSingleNode("Response/Thread");
                    if (childNode != null)
                    {
                        model = new ThreadModel(childNode, DataFormatHelper.FormatDate, FormatString100, ReadReplies);
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in TelligentService.CreateForumThread.\nError:\n" + ex.Message);
                    model = null;
                }


            }

            return model;


        }
        public static bool DeleteForumThread(string forumID, string threadId)
        {
            bool success = false;
            if ((!string.IsNullOrEmpty(forumID) && !string.IsNullOrEmpty(threadId)))
            {
                WebClient client = new WebClient();
                try
                {
                    client.Headers.Add("Rest-User-Token", TelligentAuth());
                    client.Headers.Add("Rest-Method", "DELETE");
                    string address = string.Format(GetApiEndPoint("forums/{0}/threads/{1}.xml "), forumID, threadId);
                    NameValueCollection data = new NameValueCollection();

                    string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(xml);
                    XmlNode childNode = document.SelectSingleNode("Response/Errors");
                    if (childNode == null)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in TelligentService.DeleteForum.\nError:\n" + ex.Message);
                    success = false;
                }


            }
            return success;

        }
        public static bool DeleteForum(string forumID)
        {
            bool success = false;
            if ((!string.IsNullOrEmpty(forumID)))
            {
                WebClient client = new WebClient();
                try
                {
                    client.Headers.Add("Rest-User-Token", TelligentAuth());
                    client.Headers.Add("Rest-Method", "DELETE");
                    string address = string.Format(GetApiEndPoint("forums/{id}.xml"), forumID);
                    NameValueCollection data = new NameValueCollection();

                    string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(xml);
                    XmlNode childNode = document.SelectSingleNode("Response/Errors");
                    if (childNode == null)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in TelligentService.DeleteForum.\nError:\n" + ex.Message);
                    success = false;
                }


            }
            return success;
        }
        public static ForumModel CreateForum(string username, string groupID, string name)
        {
            ForumModel model = null;
            if ((!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(groupID) && !string.IsNullOrEmpty(name)))
            {
                string response = String.Empty;
                WebClient client = new WebClient();
                try
                {
                    //TODO: Need to check if username has permission to create a forum

                    client.Headers.Add("Rest-User-Token", TelligentAuth());
                    client.Headers.Add("Rest-Impersonate-User", "admin");
                    string address = string.Format(GetApiEndPoint("forums.xml"));
                    NameValueCollection data = new NameValueCollection();
                    data["GroupId"] = groupID;
                    data["Name"] = name;
                    string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(xml);
                    XmlNode childNode = document.SelectSingleNode("Response/Forum");
                    if (childNode != null)
                    {
                        model = new ForumModel(childNode, ReadThreadList);
                    }
                }
                catch (WebException webex)
                {
                    // an error has occured, let's figure out what
                    // REST returns:
                    // 404 -- If the *endpoint* cannot be found
                    // 403 -- If the credentials are invalid
                    // 500 -- Any errors are in the errors collection (as in this case)
                    // 200 -- The request is processed successfully without errors

                    var responseCode = ((HttpWebResponse)webex.Response).StatusCode;

                    // if it is a 404 we know the endpoint URL is wrong
                    if (responseCode == HttpStatusCode.NotFound)
                    {
                        // log it
                    }
                    // if it is a 403 then know something is wrong with our authentication / credentials
                    else if (responseCode == HttpStatusCode.Forbidden)
                    {
                        // log / handle it
                    }
                    // if it is a 500 then we should go ahead and get the response body and examine it
                    // to determine what the issue is
                    else if (responseCode == HttpStatusCode.InternalServerError)
                    {
                        using (var reader = new StreamReader(webex.Response.GetResponseStream()))
                        {
                            response = reader.ReadToEnd();
                            Sitecore.Diagnostics.Error.LogError("Error in TelligentService.CreateForum.\nError:\n" + response);
                        }
                    }
                    else
                    {
                        // otherwise log/handle the error
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in TelligentService.CreateForum.\nError:\n" + ex.Message);
                    model = null;
                }


            }

            return model;
        }

        public static List<Message> GetMessages(string convID, string username = null)
        {
            List<Message> messages = new List<Message>();
            XmlNode node = null;

            if (!String.IsNullOrEmpty(convID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    if (!String.IsNullOrEmpty(username))
                        webClient.Headers.Add("Rest-Impersonate-User", username);


                    var xmlDoc = new XmlDocument();
                    var requestUrl = String.Format("{0}api.ashx/v2/conversations/{1}/messages.xml ", Settings.GetSetting(Constants.Settings.TelligentConfig), convID);
                    var xml = webClient.DownloadString(requestUrl);

                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Messages");

                    if (node != null)
                    {
                        foreach (XmlNode item in node)
                        {
                            Message msg = new Message(item);
                            messages.Add(msg);

                            msg = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    messages = new List<Message>();
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }

            return messages;
        }

        public static List<Conversation> GetConversations(string username, string read_status = null)
        {

            List<Conversation> conversations = new List<Conversation>();

            XmlNode node = null;

            if (!String.IsNullOrEmpty(username))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();
                try
                {
                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    webClient.Headers.Add("Rest-Impersonate-User", username);
                    var xmlDoc = new XmlDocument();
                    string requestUrl = String.Empty;
                    if (String.IsNullOrEmpty(read_status))
                        requestUrl = String.Format("{0}api.ashx/v2/conversations.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));
                    else
                        requestUrl = String.Format("{0}api.ashx/v2/conversations.xml?ReadStatus=" + read_status, Settings.GetSetting(Constants.Settings.TelligentConfig));

                    var xml = webClient.DownloadString(requestUrl);

                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Conversations");

                    if (node != null)
                    {
                        foreach (XmlNode item in node)
                        {
                            Conversation conv = new Conversation(item, username);
                            conversations.Add(conv);

                            conv = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    conversations = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }
            // return node;
            return conversations;
        }

        public static List<String> GetUserNames()
        {
            List<String> usernames = new List<String>();

            XmlNode node = null;


            WebClient webClient = new WebClient();
            string adminKeyBase64 = TelligentAuth();
            try
            {
                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                //webClient.Headers.Add("Rest-Impersonate-User", username);
                var xmlDoc = new XmlDocument();
                var requestUrl = String.Format("{0}api.ashx/v2/users.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));
                var xml = webClient.DownloadString(requestUrl);

                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Users");

                if (node != null)
                {
                    foreach (XmlNode item in node)
                    {
                        MembershipManager man = new MembershipManager();
                        var user = man.GetMember(item.SelectSingleNode("PrivateEmail").InnerText);
                        if (user != null)
                        {
                            if (user.allowConnections)
                            {

                                usernames.Add(item.SelectSingleNode("Username").InnerText);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                usernames = null;
                Sitecore.Diagnostics.Log.Error(ex.Message, ex);
            }

            // return node;
            return usernames;
        }

        public static List<String> GetUserNames(string conversation)
        {
            ///TODO: Implement retrieving username from conversation
            return null;
        }

        public static Member GetPosesMember(string screenName)
        {
            Member User = null;
            string userEmail = String.Empty;
            MembershipManager memMan = new MembershipManager();
            if (!String.IsNullOrEmpty(screenName))
            {
                screenName = screenName.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                try
                {
                    var requestUrl = String.Format("{0}api.ashx/v2/users/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), screenName);
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/User");
                    if (node != null)
                    {
                        //Read user email
                        userEmail = node.SelectSingleNode("PrivateEmail").InnerText;
                        if (!String.IsNullOrEmpty(userEmail))
                        {
                            //Resolve User into Member
                            User = memMan.GetMember(userEmail);

                            User.CommunityRoles = GetUserRoles(screenName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    User = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return User;
        }

        public static string GetMemberEmail(string screenName)
        {
            Member user = null;
            String email = String.Empty;
            user = GetPosesMember(screenName);
            if (user != null)
                email = user.Email;

            return email;


        }
        public static string CreateConversation(string username, string subject, string body, string userlist)
        {
            string convID = String.Empty;
            if ((!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(subject)) && !string.IsNullOrEmpty(body) && !string.IsNullOrEmpty(userlist))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);
                        string address = string.Format(GetApiEndPoint("conversations.xml"));
                        NameValueCollection data = new NameValueCollection();

                        data["Body"] = body;
                        data["Subject"] = subject;
                        data["Usernames"] = userlist;
                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Conversation");
                        if (childNode != null)
                        {
                            convID = childNode.SelectSingleNode("Id").InnerText;
                        }
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Error.LogError("CreateConversation Error:\n" + ex.Message);
                        convID = String.Empty;
                    }
                }

            }
            return convID;
        }

        public static bool ReplyToMessage(string username, string convID, string body)
        {
            bool success = false;

            if ((!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(convID)) && !string.IsNullOrEmpty(body))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);
                        string address = string.Format(GetApiEndPoint("conversations/{0}/messages.xml "), convID);
                        NameValueCollection data = new NameValueCollection();

                        data["Body"] = body;
                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/ConversationMessage");
                        if (childNode != null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }


            return success;
        }

        public static bool DeleteConversation(string username, string convID)
        {
            bool success = false;
            if ((!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(convID)))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);
                        client.Headers.Add("Rest-Method", "DELETE");
                        string address = string.Format(GetApiEndPoint("conversations/{0}.xml "), convID);
                        NameValueCollection data = new NameValueCollection();


                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Errors").FirstChild;
                        if (childNode == null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }
            return success;
        }


        public static bool CreateFavorite(string username, string contentId, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType, bool delete = false)
        {
            bool success = false;
            string address = String.Empty;
            if ((!string.IsNullOrEmpty(username) && contentId != null))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);
                        NameValueCollection nv = new NameValueCollection();
                        if (delete)
                            client.Headers.Add("Rest-Method", "DELETE");
                        switch (contentType)
                        {
                            case Constants.TelligentContentType.Blog:
                                address = string.Format(GetApiEndPoint("blogs/{0}/favorites.xml"), contentId);
                                break;
                            case Constants.TelligentContentType.BlogPost:

                                break;
                            case Constants.TelligentContentType.Forum:
                                break;
                            case Constants.TelligentContentType.Group:
                                break;
                            case Constants.TelligentContentType.Page:
                                break;
                            case Constants.TelligentContentType.Weblog:
                                address =String.Format( GetApiEndPoint("wikis/{0}/favorites.xml"),contentId);
                                
                                break;
                            default:
                              
                                break;
                        }

                     
                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, nv));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Errors").FirstChild;
                        if (childNode == null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }
            return success;
        }

        public static bool CreateFavorite(string username, string contentId, string contentTypeId, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType, bool delete = false)
        {
            bool success = false;
            var values = new NameValueCollection();
            string address = String.Empty;
            if ((!string.IsNullOrEmpty(username) && contentId != null && contentTypeId != null))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);

                        ///With ContentId and ContentTypeId, you can potentially bookmark any content
                        ///TODO: Refactor bookmarking to only bookmark.xml with contentId and contentTypeId
                        switch (contentType)
                        {
                            case Constants.TelligentContentType.Blog:
                                address = string.Format(GetApiEndPoint("blogs/{0}/favorites.xml"), contentId);
                                break;
                            case Constants.TelligentContentType.BlogPost:
                                address = string.Format(GetApiEndPoint("bookmark.xml"));
                                values = new NameValueCollection()
                                {
                                    { "ContentId", contentId },
                                    { "ContentTypeId", contentTypeId }
                                };
                                break;
                            case Constants.TelligentContentType.Forum:
                                break;
                            case Constants.TelligentContentType.Group:
                                break;
                            case Constants.TelligentContentType.Page:
                                break;
                            case Constants.TelligentContentType.Weblog:
                                 address = string.Format(GetApiEndPoint("bookmark.xml"));
                                values = new NameValueCollection()
                                {
                                    { "ContentId", contentId },
                                    { "ContentTypeId", contentTypeId }
                                };
                                break;
                            default:
                                break;
                        }

                        var xml = Encoding.UTF8.GetString(client.UploadValues(address, values));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Bookmark").FirstChild;
                        if (childNode != null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }
            return success;
        }

        public static bool RemoveFavorite(string username, string contentId, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType)
        {
            bool success = false;
            success = CreateFavorite(username, contentId, contentType, true);
            return success;

        }

        public static List<BookmarkModel> GetBookMarks(string username, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType)
        {
            //GET api.ashx/v2/users/{id}/favorites.xml
            List<BookmarkModel> bookmarks = new List<BookmarkModel>();
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                webClient.Headers.Add("Rest-Impersonate-User", username);
                string requestUrl = String.Empty;
                try
                {
                    switch (contentType)
                    {
                        case Constants.TelligentContentType.Blog:
                            requestUrl = String.Format("{0}api.ashx/v2/bookmarks.xml?ContentTypeIds=ca0e7c80-8686-4d2f-a5a8-63b9e212e922", Settings.GetSetting(Constants.Settings.TelligentConfig));
                            break;
                        case Constants.TelligentContentType.Forum:
                            break;
                        case Constants.TelligentContentType.Group:
                            break;
                        case Constants.TelligentContentType.Page:
                            break;
                        case Constants.TelligentContentType.Weblog:
                            break;
                        case Constants.TelligentContentType.BlogPost:
                            break;
                        default:
                            break;
                    }

                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/Bookmarks");
                    if (node != null)
                    {
                        foreach (XmlNode item in node)
                        {
                            BookmarkModel b = new BookmarkModel(item, contentType);
                            bookmarks.Add(b);
                            b = null;
                        }


                    }
                }
                catch (Exception ex)
                {
                    bookmarks = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return bookmarks;
        }
        public static bool IsBookmarked(string username, string contentId, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType)
        {
            bool success = false;
            string address = String.Empty;
            string xpath = String.Empty;
            if ((!string.IsNullOrEmpty(username) && contentId != null ))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);

                        switch (contentType)
                        {
                            case Constants.TelligentContentType.Blog:
                                address = string.Format(GetApiEndPoint("blogs/{0}/favorites.xml"), contentId);
                                xpath = "Response/BlogFavorite";
                                break;
                            case Constants.TelligentContentType.BlogPost:

                                break;
                            case Constants.TelligentContentType.Forum:
                                break;
                            case Constants.TelligentContentType.Group:
                                break;
                            case Constants.TelligentContentType.Page:
                                break;
                            case Constants.TelligentContentType.Weblog:
                              
                                break;
                            default:
                                break;
                        }


                        string xml = Encoding.UTF8.GetString(client.DownloadData(address));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode(xpath).FirstChild;
                        if (childNode != null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }
            return success;
        }

        public static bool IsBookmarked(string username, string contentId, string contentTypeId, UnderstoodDotOrg.Common.Constants.TelligentContentType contentType)
        {
            bool success = false;
            var values = new NameValueCollection();
            string address = String.Empty;
            if ((!string.IsNullOrEmpty(username) && contentId != null &&  contentTypeId != null))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", username);

                        switch (contentType)
                        {
                            case Constants.TelligentContentType.Blog:
                                address = string.Format(GetApiEndPoint("blogs/{0}/favorites.xml"), contentId);
                                break;
                            case Constants.TelligentContentType.BlogPost:
                                address = string.Format(GetApiEndPoint("bookmark.xml?ContentId={0}"), contentId);
                                break;
                            case Constants.TelligentContentType.Forum:
                                break;
                            case Constants.TelligentContentType.Group:
                                break;
                            case Constants.TelligentContentType.Page:
                                break;
                            case Constants.TelligentContentType.Weblog:
                               address = string.Format(GetApiEndPoint("bookmark.xml?ContentId={0}"), contentId);
                                break;
                            default:
                                break;
                        }


                        var xml = client.DownloadString(address);
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Bookmark").FirstChild;
                        if (childNode != null)
                        {
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }
            return success;
        }
        public static bool CreateFriendRequest(string requestor, string requestee, string message)
        {
            bool success = false;
            string requesteeID = ReadUserId(requestee);
            if ((!string.IsNullOrEmpty(requestor) && !string.IsNullOrEmpty(requesteeID)) && !string.IsNullOrEmpty(message))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", requestor);

                        string address = string.Format(GetApiEndPoint("users/{0}/friends.xml"), requestor);
                        NameValueCollection data = new NameValueCollection();

                        data["RequesteeId"] = requesteeID;
                        data["RequestMessage"] = message;
                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Friendship");
                        if (childNode != null)
                        {
                            //Send mail to user 
                            success = true;
                        }
                    }
                    catch
                    {
                        success = false;
                    }
                }

            }


            return success;
        }
        public static bool DeleteFriendRequest(string requestor, string requestee)
        {
            bool success = false;

            MakeApiRequest(wc =>
                {
                    wc.Headers.Add("Rest-Method", "DELETE");

                    string address = string.Format(GetApiEndPoint("users/{0}/friends/{1}.xml"), requestor, requestee);
                    NameValueCollection data = new NameValueCollection();

                    string xml = Encoding.UTF8.GetString(wc.UploadValues(address, data));
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(xml);

                    success = true;
                });

            return success;
        }

        public static bool UpdateFriendRequest(string requestor, string requestee, string friendshipstate)
        {
            bool success = false;

            if ((!string.IsNullOrEmpty(requestor) && !string.IsNullOrEmpty(requestee)) && !string.IsNullOrEmpty(friendshipstate))
            {
                var requestorID = ReadUserId(requestor);
                var requesteeID = ReadUserId(requestee);
                string address = String.Empty;
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        client.Headers.Add("Rest-Impersonate-User", requestee);
                        client.Headers.Add("Rest-Method", "PUT");
                        address = string.Format(GetApiEndPoint("users/{0}/friends/{1}.xml"), requestorID, requesteeID);
                        NameValueCollection data = new NameValueCollection();

                        data["FriendshipState"] = friendshipstate;
                        string xml = Encoding.UTF8.GetString(client.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Friendship");
                        if (childNode != null)
                        {
                            success = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Error.LogError("Error in UpdateFriendRequest.\nError:\n" + ex.Message);
                        success = false;
                    }
                }

            }


            return success;
        }
        public static Constants.TelligentFriendStatus IsFriend(string requestor, string requestee)
        {
            Constants.TelligentFriendStatus stat = Constants.TelligentFriendStatus.NotSpecified;
            //Two API calls required: Friend or Pending, otherwise not connected as default
            if ((!string.IsNullOrEmpty(requestor) && !string.IsNullOrEmpty(requestee)))
            {
                var requestorID = ReadUserId(requestor);
                var requesteeID = ReadUserId(requestee);

                //Same user ?
                //if (requesteeID.Equals(requestorID))
                //    return Constants.TelligentFriendStatus.Approved;

                string address = String.Empty;
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Rest-User-Token", TelligentAuth());
                        address = string.Format(GetApiEndPoint("users/{0}/friends.xml?FriendshipState={1}"), requestorID, Constants.TelligentFriendStatus.Approved.ToString());

                        ///Approved??
                        //data["FriendshipState"] = Constants.TelligentFriendStatus.Approved.ToString();
                        string xml = Encoding.UTF8.GetString(client.DownloadData(address));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response/Friendships");
                        if (childNode != null)
                        {
                            //Check child node if requesteeID is in the list
                            foreach (XmlNode friend in childNode)
                            {
                                if (friend.SelectSingleNode("RequestorId").InnerText.Trim() == requesteeID
                                    || friend.SelectSingleNode("RequesteeId").InnerText.Trim() == requesteeID)
                                {
                                    stat = Constants.TelligentFriendStatus.Approved;
                                    break;
                                }
                            }
                        }

                        if (stat != Constants.TelligentFriendStatus.Approved)
                        {
                            ///Pending
                            address = string.Format(GetApiEndPoint("users/{0}/friends.xml?FriendshipState={1}"), requestorID, Constants.TelligentFriendStatus.Pending.ToString());

                            xml = Encoding.UTF8.GetString(client.DownloadData(address));
                            document = new XmlDocument();
                            document.LoadXml(xml);
                            childNode = document.SelectSingleNode("Response/Friendships");
                            if (childNode != null)
                            {
                                //Check child node if requesteeID is in the list
                                foreach (XmlNode friend in childNode)
                                {
                                    if (friend.SelectSingleNode("RequestorId").InnerText.Trim() == requesteeID)
                                    {
                                        stat = Constants.TelligentFriendStatus.Recieved;
                                        break;
                                    }
                                    if (friend.SelectSingleNode("RequesteeId").InnerText.Trim() == requesteeID)
                                    {
                                        stat = Constants.TelligentFriendStatus.Pending;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        //success = false;
                        stat = Constants.TelligentFriendStatus.NotSpecified;
                        Sitecore.Diagnostics.Error.LogError("Error in IsFriend function.\nError:\n" + ex.Message);
                    }
                }

            }


            return stat;
        }
        public static List<GroupCardModel> GetUserGroups(string username)
        {
            List<GroupCardModel> groups = new List<GroupCardModel>();
            if (!String.IsNullOrEmpty(username))
            {
                username = username.Trim();
                WebClient webClient = new WebClient();
                string adminKeyBase64 = TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                //   webClient.Headers.Add("Rest-Impersonate-User", username);
                string requestUrl = String.Empty;

                requestUrl = String.Format("{0}api.ashx/v2/users/{1}/groups.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), username);
                try
                {
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNode node = xmlDoc.SelectSingleNode("Response/Groups");
                    if (node != null)
                    {
                        foreach (XmlNode group in node)
                        {
                            GroupItem item = Groups.ConvertGroupIDtoSitecoreItem(group.SelectSingleNode("Id").InnerText);
                            GroupCardModel b = Groups.GroupCardModelFactory(item);
                            groups.Add(b);
                            b = null;
                        }



                    }
                }
                catch (Exception ex)
                {
                    groups = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }


            }
            return groups;


        }
        public static User GetUser(string username)
        {
            User user = null;
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentService.TelligentAuth());
                    var requestUrl = String.Format("{0}api.ashx/v2/users/{1}.xml", Sitecore.Configuration.Settings.GetSetting("TelligentConfig"), username);

                    var xml = webClient.DownloadString(requestUrl);
                    var doc = new XmlDocument();
                    doc.LoadXml(xml);

                    XmlNode node = doc.SelectSingleNode("Response/User");
                    user = new User()
                    {
                        AvatarUrl = node["AvatarUrl"].InnerText,
                        Username = node["Username"].InnerText
                    };
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error retrieving telligent user", ex);
            }
            return user;
        }

        public static List<User> GetFriends(string userName, int page, int pageSize, out int totalFriends)
        {
            List<User> friends = new List<User>();
            int friendsCount = 0;

            if (!userName.IsNullOrEmpty())
            {
                try
                {
                    MakeApiRequest(wc =>
                    {
                        int pageIndex = page - 1;

                        string url = GetApiEndPoint(String.Format("users/{0}/friends.xml?PageIndex={1}&PageSize={2}", userName, pageIndex, pageSize));

                        string response = wc.DownloadString(url);

                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(response);

                        var container = xml.SelectSingleNode("Response/Friendships");
                        friendsCount = Convert.ToInt32(container.Attributes["TotalCount"].InnerText);

                        XmlNodeList nodes = container.SelectNodes("Friendship");
                        foreach (XmlNode node in nodes)
                        {
                            XmlNode friend = node.SelectSingleNode("User");

                            // TODO: why isn't entire user being populated
                            User user = new User()
                            {
                                AvatarUrl = friend["AvatarUrl"].InnerText,
                                DisplayName = friend["DisplayName"].InnerText,
                                Username = friend["Username"].InnerText,
                            };

                            friends.Add(user);
                        }
                    });
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Error retrieving friends from Telligent", ex, typeof(TelligentService));
                }
            }

            totalFriends = friendsCount;
            return friends;
        }

        /// <summary>
        /// Performs a search on the Telligent database, returns a list of results.
        /// </summary>
        /// <param name="q">The string that will be used to search the database.</param>
        /// <param name="param">Application type to limit the search.
        /// Options: blog, group, question, expert, all</param>
        /// <returns></returns>
        public static List<SearchResult> CommunitySearch(string q, string param)
        {
            // TODO: store guids in constants file
            var searchResultsList = new List<SearchResult>();
            try
            {
                using (var webClient = new WebClient())
                {

                    webClient.Headers.Add("Rest-User-Token", TelligentService.TelligentAuth());
                    var requestUrl = string.Format(GetApiEndPoint("search.xml?Query={0}&PageSize=100&Category={1}"), q, param);

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList xn = xmlDoc.SelectNodes("Response/SearchResults/SearchResult");
                    foreach (XmlNode result in xn)
                    {
                        XmlNode content = result.SelectSingleNode("Content");
                        XmlNode application = result.SelectSingleNode("Content/Application");
                        XmlNode container = result.SelectSingleNode("Group/Container");
                        XmlNode group = result.SelectSingleNode("Group");
                        XmlNode user = result.SelectSingleNode("User");
                        if (!application["HtmlName"].InnerText.Equals("Articles")
                            && !application["HtmlName"].InnerText.Equals("Assistive Tools")
                            && !result["ContentType"].InnerText.Equals("status")
                            && !result["ContentType"].InnerText.Equals("fileapp")
                            && !result["ContentType"].InnerText.Equals("wikiapp")
                            && !result["ContentType"].InnerText.Equals("forumapp"))
                        {
                            string id = result["Id"].InnerText;
                            string bestMatchTitle = result["BestMatchTitle"].InnerText;
                            string title = result["Title"].InnerText;
                            string bestMatch = result["BestMatch"].InnerText;
                            string body = result["Body"].InnerText;
                            string type = result["ContentType"].InnerText;
                            string typeTransformed = string.Empty;
                            string date = DataFormatHelper.FormatDate(result["Date"].InnerText);
                            string url = string.Empty;
                            string groupName = container["HtmlName"].InnerText;
                            string author = user["Username"].InnerText;
                            bestMatchTitle = Regex.Replace(title, "<em>", "<strong>");
                            bestMatchTitle = Regex.Replace(title, "</em>", "</strong>");
                            bestMatch = Regex.Replace(bestMatch, "<em>", "<strong>");
                            bestMatch = Regex.Replace(bestMatch, "</em>", "</strong>");

                            if (body != string.Empty)
                            {
                                body = "&ldquo;" + body + "&rdquo;";
                            }

                            switch (type)
                            {
                                case "comment":
                                    typeTransformed = "Blog Comment";
                                    url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) + "/" + application["HtmlName"].InnerText + "/" + Regex.Replace(title, "Comment on ", "");
                                    if (param == "wiki")
                                    {
                                        typeTransformed = "Question Answer";
                                    }
                                    break;
                                case "blog":
                                    typeTransformed = "Blog Post";
                                    url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) + "/" + application["HtmlName"].InnerText + "/" + title;
                                    break;
                                case "blogapp":
                                    typeTransformed = "Blog";
                                    url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{E486F071-8B5F-42B9-91C1-CC8A61A8622E}")) + "?BlogId=" + result["SectionId"].InnerText;
                                    break;
                                case "wiki":
                                    typeTransformed = "Question";
                                    url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{7356A32F-1795-4EAE-BE24-EBBD79B3093C}")) + String.Format("?wikiId={0}&wikiPageId={1}&contentId={2}", result["WikiId"].InnerText, result["ContentId"].InnerText, id);
                                    break;
                                case "forum":
                                    typeTransformed = "Discussion Post";
                                    break;
                                case "forumreply":
                                    typeTransformed = "Discussion Reply";
                                    break;
                                case "group":
                                    typeTransformed = "Group";
                                    break;
                            }
                            var searchResult = new SearchResult()
                            {
                                Id = id,
                                BestMatchTitle = bestMatchTitle,
                                BestMatchBody = bestMatch,
                                Type = type,
                                TypeTransformed = typeTransformed,
                                Date = date,
                                Title = title,
                                Body = body,
                                Url = url,
                                Author = author,
                                GroupName = groupName,
                            };
                            searchResultsList.Add(searchResult);
                        }
                    }
                }
            }
            catch { }
            return searchResultsList;
        }

        public static List<SearchResult> GroupSearch(string q, string param, string groupId, GroupItem groupItem)
        {
            // TODO: store guids in constants file
            var searchResultsList = new List<SearchResult>();
            try
            {
                using (var webClient = new WebClient())
                {

                    webClient.Headers.Add("Rest-User-Token", TelligentService.TelligentAuth());
                    var requestUrl = string.Format(GetApiEndPoint("search.xml?Query={0}&PageSize=100&Category={1}"), q, param);

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList xn = xmlDoc.SelectNodes("Response/SearchResults/SearchResult");
                    foreach (XmlNode result in xn)
                    {
                        XmlNode content = result.SelectSingleNode("Content");
                        XmlNode application = result.SelectSingleNode("Content/Application");
                        XmlNode container = result.SelectSingleNode("Group/Container");
                        XmlNode group = result.SelectSingleNode("Group");
                        XmlNode user = result.SelectSingleNode("Users/User");

                        string id = result["Id"].InnerText;
                        string bestMatchTitle = result["BestMatchTitle"].InnerText;
                        string title = result["Title"].InnerText;
                        string bestMatch = result["BestMatch"].InnerText;
                        string body = result["Body"].InnerText;
                        string type = result["ContentType"].InnerText;
                        string typeTransformed = string.Empty;
                        string date = DataFormatHelper.FormatDate(result["Date"].InnerText);
                        string url = string.Empty;
                        string groupName = string.Empty;
                        try { groupName = container["HtmlName"].InnerText; }
                        catch { groupName = string.Empty; }
                        string author = user["Username"].InnerText;

                        bestMatchTitle = Regex.Replace(title, "<em>", "<strong>");
                        bestMatchTitle = Regex.Replace(title, "</em>", "</strong>");
                        bestMatch = Regex.Replace(bestMatch, "<em>", "<strong>");
                        bestMatch = Regex.Replace(bestMatch, "</em>", "</strong>");

                        if (body != string.Empty)
                        {
                            body = "&ldquo;" + body + "&rdquo;";
                        }
                        if (groupName.Trim().ToLower().Equals(groupItem.Name.Trim().ToLower())){
                        var searchResult = new SearchResult()
                        {
                            Id = id,
                            BestMatchTitle = bestMatchTitle,
                            BestMatchBody = FormatString100(bestMatch),
                            Type = type,
                            TypeTransformed = typeTransformed,
                            Date = date,
                            Title = title,
                            Body = FormatString100(body),
                            Url = url,
                            Author = author,
                            GroupName = groupName,
                        };
                        searchResultsList.Add(searchResult);
                        }
                    }
                }
            }

            catch { }
            return searchResultsList;
        }

        public static bool IsApprovedFriend(string requestorUserName, string requesteeUserName)
        {
            // Requires paging logic to check friendship as there is no direct way to check friends
            bool isFriend = false;

            bool hasMoreResults = true;
            int currentIndex = 0;
            int pageSize = 100;

            try
            {
                MakeApiRequest(wc =>
                {
                    while (hasMoreResults)
                    {
                        var url = GetApiEndPoint(
                            String.Format("users/{0}/friends.xml?PageIndex={1}&PageSize={2}",
                                requestorUserName,
                                currentIndex,
                                pageSize));

                        var response = wc.DownloadString(url);

                        var xml = new XmlDocument();
                        xml.LoadXml(response);

                        var container = xml.SelectSingleNode("Response/Friendships");

                        int totalFriends = Convert.ToInt32(container.Attributes["TotalCount"].Value);
                        int resultSize = container.SelectNodes("Friendship").Count;

                        hasMoreResults = (currentIndex * pageSize) + resultSize < totalFriends;

                        isFriend = container.SelectSingleNode(String.Format("Friendship/User/Username[text()='{0}']", requesteeUserName)) != null;

                        if (isFriend)
                        {
                            break;
                        }

                        currentIndex++;
                    }
                });
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error checking friendship status in IsApprovedFriend", ex, typeof(TelligentService));
            }

            return isFriend;
        }

        public static List<Question> GetQuestionsList(int wikiId, int pageSize)
        {
            int id = 0;
            List<Question> questionList = new List<Question>();

            if (wikiId == null || pageSize == null)
            {
                return questionList;
            }

            using (var webClient = new WebClient())
            {

                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                var requestUrl = GetApiEndPoint(String.Format("wikis/{0}/pages.xml?PageSize={1}", wikiId.ToString(), pageSize.ToString()));

                var xml = webClient.DownloadString(requestUrl);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlNodeList nodes = xmlDoc.SelectNodes("Response/WikiPages/WikiPage");
                foreach (XmlNode xn in nodes)
                {
                    XmlNode user = xn.SelectSingleNode("User");
                    XmlNode app = xn.SelectSingleNode("Content/Application");

                    var queryString = "?wikiId=" + wikiId + "&wikiPageId=" + xn["Id"].InnerText + "&contentId=" + xn["ContentId"].InnerText;

                    Question question = new Question()
                    {
                        Title = xn["Title"].InnerText,
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(xn["CreatedDate"].InnerText),
                        Body = xn["Body"].InnerText,
                        WikiPageId = xn["Id"].InnerText,
                        ContentId = xn["ContentId"].InnerText,
                        ContentTypeId = xn["ContentTypeId"].InnerText,
                        Author = user["Username"].InnerText,
                        Group = app["HtmlName"].InnerText,
                        CommentCount = xn["CommentCount"].InnerText,
                        AuthorAvatarUrl = user["AvatarUrl"].InnerText,
                        QueryString = queryString,
                        WikiId = wikiId.ToString(),
                        // TODO: replace this with constant or guid lookup
                        Url = "/en/community and events/q and a/q and a details.aspx" + queryString,
                    };
                    questionList.Add(question);
                }
            }
            return questionList;
        }

        public static Question GetQuestion(string wikiId, string wikiPageId, string contentId)
        {
            Question question = new Question();


            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                    var requestUrl = GetApiEndPoint(string.Format("wikis/{0}/pages/{1}.xml", wikiId, wikiPageId));

                    var xml = webClient.DownloadString(requestUrl);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode page = xmlDoc.SelectSingleNode("Response/WikiPage");
                    XmlNode user = xmlDoc.SelectSingleNode("Response/WikiPage/User");
                    XmlNode app = xmlDoc.SelectSingleNode("Response/WikiPage/Content/Application");

                    question = new Question()
                    {
                        Title = page["Title"].InnerText,
                        PublishedDate = UnderstoodDotOrg.Common.Helpers.DataFormatHelper.FormatDate(page["CreatedDate"].InnerText),
                        Body = page["Body"].InnerText,
                        Author = user["Username"].InnerText,
                        Group = app["HtmlName"].InnerText,
                        CommentCount = page["CommentCount"].InnerText
                    };
                }
            }
            catch { } // TODO: Add Logging
            return question;
        }

        public static bool MarkConversationRead(string conversationOwner, string conversationID)
        {
            bool success = false;
            string address = String.Empty;
            if (!conversationID.IsNullOrEmpty() && !String.IsNullOrEmpty(conversationOwner))
            {
                try
                {
                    MakeApiRequest(wc =>
                    {
                        wc.Headers.Add("Rest-Method", "PUT");
                        wc.Headers.Add("Rest-Impersonate-User", conversationOwner);

                        address = string.Format(GetApiEndPoint("conversations/{0}/read.xml "), conversationID);
                        NameValueCollection data = new NameValueCollection();

                        data["HasRead"] = "True";
                        string xml = Encoding.UTF8.GetString(wc.UploadValues(address, data));
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xml);
                        XmlNode childNode = document.SelectSingleNode("Response");
                        if (childNode != null)
                        {
                            if (!childNode.SelectSingleNode("HasRead").InnerText.Equals("true"))
                            {
                                success = false;
                            }
                        }

                    });
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error("Error retrieving Marking Conversations as Read in Telligent", ex, typeof(TelligentService));
                }
            }


            return success;

        }

        public static bool UserFollowsBlogs(string username)
        {
            if (username.IsNullOrEmpty())
            {
                return false;
            }
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                webClient.Headers.Add("Rest-Impersonate-User", username.Trim());
                var requestUrl = GetApiEndPoint("bookmarks.xml?PageSize=100");
                try
                {
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList xn = xmlDoc.SelectNodes("Response/Bookmarks/Bookmark");
                    foreach (XmlNode item in xn)
                    {
                        XmlNode node = item.SelectSingleNode("Content");
                        if (node["ContentTypeId"].InnerText.Equals("ca0e7c80-8686-4d2f-a5a8-63b9e212e922"))
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(String.Format("Error retrieving user blog bookmarks: "), ex);
                }

                return false;
            }
        }

        public static List<Blog> GetFollowedBlogs(string username)
        {
            var followedBlogs = new List<Blog>();
            if (username.IsNullOrEmpty())
            {
                return followedBlogs;
            }
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Rest-User-Token", TelligentAuth());
                webClient.Headers.Add("Rest-Impersonate-User", username.Trim());
                var requestUrl = GetApiEndPoint("bookmarks.xml?PageSize=100&ContentTypeIds=ca0e7c80-8686-4d2f-a5a8-63b9e212e922");
                try
                {
                    var xml = webClient.DownloadString(requestUrl);
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNodeList xn = xmlDoc.SelectNodes("Response/Bookmarks/Bookmark");
                    foreach (XmlNode item in xn)
                    {
                        XmlNode node = item.SelectSingleNode("Content");
                        var blog = new Blog()
                        {
                            Title = node["HtmlName"].InnerText,
                        };
                        followedBlogs.Add(blog);
                    }
                    return followedBlogs;
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(String.Format("Error retrieving user blog bookmarks: "), ex);
                }
                return followedBlogs;
            }
        }

        public static List<Blog> ListBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add("Rest-User-Token", TelligentService.TelligentAuth());
                    var requestUrl = GetApiEndPoint("blogs.xml");

                    var xml = webClient.DownloadString(requestUrl);

                    blogs = new List<Blog>();

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);
                    XmlNodeList nodes = xmlDoc.SelectNodes("Response/Blogs/Blog");
                    int count = 0;
                    foreach (XmlNode node in nodes)
                    {
                        string title = node["Name"].InnerText;
                        string description = FormatString100(node["Description"].InnerText);
                        string blogId = node["Id"].InnerText;
                        Blog blogPost = new Blog()
                        {
                            Title = title,
                            Description = description,
                            Url = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("/sitecore/content/Home/Community and Events/Blogs/" + title))
                        };
                        if (!title.Equals("Articles") && !title.Equals("Assistive Tools") && !title.Equals("Behavior Tools"))
                        {
                            blogs.Add(blogPost);
                        }
                        count++;
                    }
                }
            }
            catch { } //TODO: Add Logging
            return blogs;
        }
    }
}
