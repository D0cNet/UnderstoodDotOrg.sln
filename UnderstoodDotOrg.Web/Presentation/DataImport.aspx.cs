using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.CommonSenseMedia;
using Sitecore.ContentSearch;
using Sitecore.Buckets.Client;
using System.Xml.Linq;


namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class DataImport : System.Web.UI.Page
    {
        public static string ConnectionString = "Data Source=AODEV02\\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A";
        public string Log = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int totalEntries = 0;

            //XmlTextReader apps = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=app&special_needs=1");
            //XmlTextReader games = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=game&special_needs=1");
            //XmlTextReader websites = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=website&special_needs=1");

            string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            string exeDir = System.IO.Path.GetDirectoryName(exeLocation);

            using (var webClient = new WebClient())
            {
                try
                {
                    XmlTextReader apps = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/apps.xml"));
                    XmlTextReader games = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/games.xml"));
                    XmlTextReader websites = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/websites.xml"));

                    totalEntries += ImportCategory(GetEntries(apps));
                    totalEntries += ImportCategory(GetEntries(games));
                    totalEntries += ImportCategory(GetEntries(websites));
                }
                catch
                { 
                    
                }
            }

            litCount.Text = "Completed " + totalEntries.ToString() + " total imports.";
            litLog.Text = Log;
        }

        public XmlNodeList GetEntries(XmlTextReader xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("bk", "http://www.w3.org/2005/Atom");

            //Select the book node with the matching attribute value.
            XmlElement root = doc.DocumentElement;
            return root.SelectNodes("//bk:entry", nsmgr);
        }

        public int ImportCategory(XmlNodeList nodes)
        {
            ReviewManager reviewManager = new ReviewManager();

            int count = 0;

            foreach (XmlNode x in nodes)
            {
                ReviewModel newItem = new ReviewModel();
                try
                {
                    XmlNodeList temp;
                    if (x["id"] != null)
                        newItem.CommonSenseMediaID = x["id"].InnerText;
                    if (x["link"] != null)
                        newItem.ExternalLink = x["link"].GetAttribute("href");
                    if (x["category"] != null)
                        newItem.Type = x["category"].GetAttribute("term");
                    if (x["published"] != null)
                        newItem.Published = Sitecore.DateUtil.ToIsoDate(DateTime.Parse(x["published"].InnerText));
                    if (x["title"] != null)
                        newItem.Title = x["title"].InnerText;
                    if (x["summary"] != null)
                        newItem.Summary = x["summary"].InnerText;
                    if (x["csm:product"] != null)
                    {
                        if (x["csm:product"]["csm:references"] != null)
                        {
                            temp = x["csm:product"]["csm:references"].ChildNodes;
                            foreach (XmlNode t in temp)
                            {
                                if (t.Attributes["type"].InnerText == "itunes")
                                {
                                    newItem.AppleAppStoreID = t.InnerText;
                                }
                                else if (t.Attributes["type"].InnerText == "googleplay")
                                {
                                    newItem.GooglePlayStoreID = t.InnerText;
                                }
                            }
                        }

                        if (x["csm:product"]["csm:images"] != null)
                        {
                            temp = x["csm:product"]["csm:images"].ChildNodes;
                            List<ReviewImageModel> images = new List<ReviewImageModel>();
                            foreach (XmlNode t in temp)
                            {
                                if (t.Attributes["type"].InnerText == "screenshot")
                                {
                                    ReviewImageModel image = new ReviewImageModel();
                                    image.URL = t.InnerText;
                                    image.Name = newItem.Title + "-screenshot-" + (images.Count + 1).ToString();
                                    image.AltText = "Screenshot";
                                    images.Add(image);
                                }
                                else if (t.Attributes["type"].InnerText == "product")
                                {
                                    ReviewImageModel image = new ReviewImageModel();
                                    image.URL = t.InnerText;
                                    image.Name = newItem.Title + "-screenshot-" + (images.Count + 1).ToString();
                                    image.AltText = "Screenshot";
                                    newItem.Thumbnail = image;
                                }
                            }

                            newItem.Screenshots = images;
                        }

                        if (x["csm:product"]["csm:platforms"] != null)
                        {
                            temp = x["csm:product"]["csm:platforms"].ChildNodes;
                            foreach (XmlNode t in temp)
                            {
                                newItem.Platforms += t.InnerText + ",";
                            }
                        }

                        if (x["csm:product"]["csm:prices"] != null && x["csm:product"]["csm:prices"]["csm:price"] != null)
                            newItem.Price = x["csm:product"]["csm:prices"]["csm:price"].InnerText;
                        if (x["csm:product"]["csm:genre"] != null)
                            newItem.Genres = x["csm:product"]["csm:genre"].InnerText;
                    }

                    if (x["csm:review"] != null)
                    {
                        newItem.QualityRank = x["csm:review"].GetAttribute("star_rating");
                        if (x["csm:review"]["csm:slider"] != null)
                        {
                            newItem.TargetGrade = ResolveGrade(x["csm:review"]["csm:slider"].GetAttribute("target_age"));
                            newItem.OffGrade = ResolveGrade(x["csm:review"]["csm:slider"].GetAttribute("off_age"));
                            newItem.OnGrade = ResolveGrade(x["csm:review"]["csm:slider"].GetAttribute("on_age"));
                        }
                        if (x["csm:review"]["csm:parents_need_to_know"] != null)
                            newItem.ParentsNeedToKnow = x["csm:review"]["csm:parents_need_to_know"].InnerText;
                        if (x["csm:review"]["csm:description"] != null)
                            newItem.Description = x["csm:review"]["csm:description"].InnerText;
                        if (x["csm:review"]["csm:any_good"] != null)
                            newItem.AnyGood = x["csm:review"]["csm:any_good"].InnerText;
                        if (x["csm:review"]["csm:learning_rating"] != null)
                        {
                            newItem.LearningRank = x["csm:review"]["csm:learning_rating"].GetAttribute("value");
                            if (x["csm:review"]["csm:learning_rating"]["csm:what_kids_can_learn"] != null)
                                newItem.WhatKidsCanLearn = x["csm:review"]["csm:learning_rating"]["csm:what_kids_can_learn"].InnerText;
                            if (x["csm:review"]["csm:learning_rating"]["csm:how_parents_help"] != null)
                                newItem.HowParentsCanHelp = x["csm:review"]["csm:learning_rating"]["csm:how_parents_help"].InnerText;

                            if (x["csm:review"]["csm:learning_rating"]["csm:subjects"] != null)
                            {
                                temp = x["csm:review"]["csm:learning_rating"]["csm:subjects"].ChildNodes;
                                foreach (XmlNode t in temp)
                                {
                                    newItem.Subjects += t.Attributes["name"].InnerText + ",";
                                }
                            }

                            if (x["csm:review"]["csm:learning_rating"]["csm:skills"] != null)
                            {
                                temp = x["csm:review"]["csm:learning_rating"]["csm:skills"].ChildNodes;
                                foreach (XmlNode t in temp)
                                {
                                    newItem.Skills += t.Attributes["name"].InnerText + ",";
                                }
                            }
                        }

                        if (x["csm:review"]["csm:special_needs"] != null)
                        {
                            temp = x["csm:review"]["csm:special_needs"].ChildNodes;
                            foreach (XmlNode t in temp)
                            {
                                newItem.Issues += t.Attributes["name"].InnerText + ",";
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Log += e.Message+"<br><br><b>";
                }

                try
                {
                    reviewManager.Add(newItem);
                    count++;
                }
                catch
                { 
                    
                }
            }

            return count;
        }

        private string ResolveGrade(string age)
        {
            int kidAge = Int32.Parse(age);

            if (kidAge >= 2 && kidAge <= 5)
                return "1";
            else if (kidAge < 17)
                return (kidAge - 5).ToString();
            else if (kidAge >= 17)
                return "12";

            return "1";
        }
    }
}