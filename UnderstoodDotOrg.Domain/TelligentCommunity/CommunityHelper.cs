using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Understood.Common;

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
                    return string.Format("{0} minutes ago", Math.Floor((double)span / 60));
                }

                if (span < 7200)
                {
                    return "Published 1 hour ago";
                }

                if (span < 86400)
                {
                    return string.Format("{0} hours ago", Math.Floor((double)span / 3600));
                }
            }
            return publishedDate;
        }

        /// <summary>
        /// Formats the input string to show only the first 100 characters
        /// </summary>
        /// <param name="inputString">String to be formatted</param>
        /// <returns></returns>
        public static string FormatString100(string inputString)
        {
            if (inputString.Length >= 100)
            {
                string myString = inputString.Substring(0, 100);

                int index = myString.LastIndexOf(' ');

                string outputString = myString.Substring(0, index);

                return outputString;
            }
            else
            {
                return inputString;
            }
        }

        public static List<Comment> ReadComments(int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

            var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts/{2}/comments.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);
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
                string likesCount = ReadLikes(commentId);
                string commentDate = xn["PublishedDate"].InnerText;
                string[] t = commentDate.Split('T');
                commentDate = t[0];
                Comment comment = new Comment(id, url, body, parentId, contentId, isApproved, replyCount, commentId,
                    commentContentTypeId, authorId, authorAvatarUrl, authorUsername, publishedDate, authorDisplayName,
                    authorProfileUrl, likesCount, commentDate);

                commentList.Add(comment);

                nodecount++;
            }
            return commentList;
        }

        public static BlogPost ReadBlogBody(int blogId, int blogPostId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts/{2}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPost");
            XmlNodeList nodes2 = xmlDoc.SelectNodes("Response/BlogPost/Author");
            string body = nodes[0]["Body"].InnerText;
            string title = nodes[0]["Title"].InnerText;
            string contentId = nodes[0]["ContentId"].InnerText;
            string dateTime = nodes[0]["PublishedDate"].InnerText;
            string blogName = CommunityHelper.BlogNameById(nodes[0]["BlogId"].InnerText);
            string publishedDate = CommunityHelper.FormatDate(dateTime);
            string author = nodes2[0]["DisplayName"].InnerText;
            BlogPost blogPost = new BlogPost(body, title, publishedDate, author, blogName, contentId);
            return blogPost;
        }

        public static void PostComment(int blogId, int blogPostId, string body)
        {
            var webClient = new WebClient();

            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var postUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts/{2}/comments.xml ", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId, blogPostId);
            var data = "Body=" + body + "&PublishedDate=" + DateTime.Now + "&IsApproved=true&BlogId=" + blogId;

            webClient.UploadData(postUrl, "POST", Encoding.ASCII.GetBytes(data));
        }

        public static string ReadLikes(string contentId)
        {
            var webClient = new WebClient();

            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = string.Format("{0}api.ashx/v2/likes.xml?ContentId={1}", Settings.GetSetting(Constants.Settings.TelligentConfig), contentId);

            var xml = webClient.DownloadString(requestUrl);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList nodes = xmlDoc.SelectNodes("Response/Likes/Like");

            string likes = nodes.Count.ToString();

            return likes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Unique username to be used in the Telligent Community</param>
        /// <param name="email">Unique email to be used in the Telligent Community</param>
        public static bool CreateUser(/*User user*/string username, string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("Required value is missing: Email");
                }
                if (string.IsNullOrEmpty(username))
                {
                    throw new Exception("Required value is missing: username");
                }

                var webClient = new WebClient();



                // replace the "admin" and "Admin's API key" with your valid user and apikey!
                var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var requestUrl = string.Format("{0}api.ashx/v2/users.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

                var values = new NameValueCollection();
                values["Username"] = username;
                values["Password"] = Guid.NewGuid().ToString();
                values["PrivateEmail"] = email;
                ////values["Username"] = user.username;
                ////values["Password"] = user.password;
                ////values["PrivateEmail"] = user.privateEmail;

                ////PropertyInfo[] ps = user.GetType().GetProperties();
                ////foreach (PropertyInfo pi in ps)
                ////{
                ////    string value = pi.GetValue(user, null).ToString();

                ////    if (!string.IsNullOrEmpty(value))
                ////    {
                ////        values[pi.Name] = value;
                ////    }
                ////}

                var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));
                return true;
            }
            catch (Exception)
            {
                Exception createException = new Exception("An error occurred when creating the user. Username may already be in use");
                throw createException;
            }
        }

        public static string BlogNameById(string blogId)
        {
            var webClient = new WebClient();
 
            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));
 
            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId);
 
            var xml = webClient.DownloadString(requestUrl);
 
            Console.WriteLine(xml);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var nodes = xmlDoc.SelectNodes("/Response/Blog");
            string blogName = nodes[0]["Name"].InnerText;
            return blogName;
        }

        public static List<MemberCardModel> GetModerators()
        {
            var webClient = new WebClient();
            string keyTest = Sitecore.Configuration.Settings.GetSetting("TelligentAdminApiKey");
            var apiKey = string.IsNullOrEmpty(keyTest) ? "d956up05xiu5l8fn7wpgmwj4ohgslp" : keyTest;

            var adminKey = string.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

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

        /// <summary>
        /// Gets a list of blog posts that a specified blog contains.
        /// </summary>
        /// <param name="blogId">As string, if multiple, separate with a comma. Ex:("1,2,4")</param>
        /// <returns></returns>
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
                string title = node["Title"].InnerText;
                string contentId = node["ContentId"].InnerText;
                string body = FormatString100(node["Body"].InnerText);
                string publishedDate = FormatDate(node["PublishedDate"].InnerText);
                string blogName = CommunityHelper.BlogNameById(node["BlogId"].InnerText);
                string author = nodes1[count]["DisplayName"].InnerText;
                BlogPost blogPost = new BlogPost(body, title, publishedDate, author, blogName, contentId);
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

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
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
                string description = FormatString100(node["Description"].InnerText);
                Blog blogPost = new Blog(description, title);

                blogs.Add(blogPost);
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
                string adminKeyBase64 = CommunityHelper.TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var xmlDoc = new XmlDocument();
                var requestUrl = String.Format("{0}api.ashx/v2/groups/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), groupID);
                var xml = webClient.DownloadString(requestUrl);

                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Group");
            }
            return node;
           
        }
        public static XmlNode ReadForum(string forumID)
        {
            XmlNode node = null;
            if (!String.IsNullOrEmpty(forumID))
            {
                WebClient webClient = new WebClient();
                string adminKeyBase64 = CommunityHelper.TelligentAuth();

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
                string adminKeyBase64 = CommunityHelper.TelligentAuth();

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
                string adminKeyBase64 = CommunityHelper.TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);

                var requestUrl = String.Format("{0}api.ashx/v2/forums/{1}/threads.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), forumID);
                var xml = webClient.DownloadString(requestUrl);
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                node = xmlDoc.SelectSingleNode("Response/Threads");
            }
            return node;
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
            }catch(Exception ex)
            {
                th = null;
            }
            return th;
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
            }
            return fm;
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
    }
}