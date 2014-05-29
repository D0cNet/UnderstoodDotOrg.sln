﻿using Sitecore.Configuration;
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
using UnderstoodDotOrg.Domain.Understood.Common;

using System.Text.RegularExpressions;
using Sitecore.Links;
using System.Collections.Specialized;

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
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
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
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                    }
                }
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
        public static XmlNode ReadUserComments(string username)
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
                //webClient.Headers.Add("Rest-Impersonate-User", userId);
                var requestUrl = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") + "api.ashx/v2/comments.xml?UserId=" + userId;
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response");
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

        public static List<Answer> GetAnswers(string wikiId, string wikiPageId)
        {
            List<Answer> answerList = new List<Answer>();
            using (var webClient = new WebClient())
            {

                var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var requestUrl = string.Format("{0}api.ashx/v2/wikis/{1}/pages/{2}/comments.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), wikiId, wikiPageId);

                var xml = webClient.DownloadString(requestUrl);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlNodeList nodes = xmlDoc.SelectNodes("Response/Comments/Comment");
                int count = 0;
                foreach (XmlNode xn in nodes)
                {
                    XmlNode user = xmlDoc.SelectSingleNode("Response/Comments/Comment/Author");
                    Answer answer = new Answer()
                    {
                        PublishedDate = DataFormatHelper.FormatDate(xn["PublishedDate"].InnerText),
                        Body = xn["Body"].InnerText,
                        Author = user["Username"].InnerText
                    };
                    answerList.Add(answer);
                    count++;
                }
            }
            return answerList;
        }
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
        public static List<BlogPost> ListBlogPosts(string blogId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = string.Format("{0}api.ashx/v2/blogs/posts.xml?BlogIds={1};", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId);

            var xml = webClient.DownloadString(requestUrl);

            List<BlogPost> blogPosts = new List<BlogPost>();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPosts/BlogPost");
            XmlNodeList nodes1 = xmlDoc.SelectNodes("Response/BlogPosts/BlogPost/Author");
            int count = 0;
            foreach (XmlNode node in nodes)
            {
                BlogPost blogPost = new BlogPost()
                {
                    Title = node["Title"].InnerText,
                    ContentId = node["ContentId"].InnerText,
                    Body = DataFormatHelper.FormatString100(node["Body"].InnerText),
                    PublishedDate = DataFormatHelper.FormatDate(node["PublishedDate"].InnerText),
                    BlogName = node["HtmlName"].InnerText,
                    Author = nodes1[count]["DisplayName"].InnerText,

                    ItemUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) + "/" + node["HtmlName"].InnerText + "/" + node["Title"].InnerText, ".aspx", "")
                };
                blogPosts.Add(blogPost);
                count++;

            }
            return blogPosts;

        }
        public static List<Blog> ListBlogs()
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", TelligentAuth());
            var requestUrl = string.Format("{0}api.ashx/v2/blogs.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

            var xml = webClient.DownloadString(requestUrl);

            List<Blog> blogs = new List<Blog>();

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Blogs/Blog");
            int count = 0;
            foreach (XmlNode node in nodes)
            {
                string title = node["Name"].InnerText;
                string description = DataFormatHelper.FormatString100(node["Description"].InnerText);
                Blog blogPost = new Blog(description, title);
                if (!title.Equals("Articles"))
                {
                    blogs.Add(blogPost);
                }
                count++;
            }
            return blogs;
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
        public static void PostReply(string forumID, string threadID, string body)
        {


            WebClient webClient = new WebClient();
            string adminKeyBase64 = TelligentAuth();
            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
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
                    ThreadModel t = new ThreadModel(childNode);
                    th.Add(t);
                }
            }
            catch (Exception ex)
            {
                th = null;
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
        public static List<ForumModel> ReadForumsList(string groupID)
        {
            List<ForumModel> fm = new List<ForumModel>();
            try
            {
                var node = ReadForums(groupID);
                foreach (XmlNode childNode in node)
                {
                    ForumModel f = new ForumModel(childNode);
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

        public static ThreadModel CreateForumThread(string forumID, string subject, string body)
        {
            ThreadModel model = null;
            if ((!string.IsNullOrEmpty(forumID) && !string.IsNullOrEmpty(subject)) && !string.IsNullOrEmpty(body))
            {
                WebClient client = new WebClient();
                try
                {
                    client.Headers.Add("Rest-User-Token", TelligentAuth());
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
                        model = new ThreadModel(childNode);
                    }
                }
                catch
                {
                    model = null;
                }

                
            }

            return model;


        }


        public static List<Message> GetMessages (string convID)
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
                    //webClient.Headers.Add("Rest-Impersonate-User", username);
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
                    messages = null;
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex);
                }
            }

            return messages;
        }

        public static List<Conversation> GetConversations(string username)
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
                    var requestUrl = String.Format("{0}api.ashx/v2/conversations.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));
                    var xml = webClient.DownloadString(requestUrl);

                    xmlDoc.LoadXml(xml);
                    node = xmlDoc.SelectSingleNode("Response/Conversations");

                    if(node!=null)
                    {
                        foreach (XmlNode item in node)
                        {
                            Conversation conv = new Conversation(item);
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

        public static string CreateConversation(string username,string subject,string body,string userlist)
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
                            convID = childNode.SelectSingleNode("Id").Value ;
                        }
                    }
                    catch
                    {
                        convID = String.Empty;
                    }
                }

            }
            return convID;
        }

        public static bool ReplyToMessage(string username,string convID,string body)
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

        public static bool DeleteConversation(string username,string convID)
        {
            bool success = false;
            if ((!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(convID)) )
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

    }

}
