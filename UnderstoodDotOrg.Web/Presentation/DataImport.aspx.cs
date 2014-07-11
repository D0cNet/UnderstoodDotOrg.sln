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


namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class DataImport : System.Web.UI.Page
    {
        public static string ConnectionString = "Data Source=AODEV02\\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A";

        protected void Page_Load(object sender, EventArgs e)
        {
            int totalEntries = 0;

            //XmlTextReader apps = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=app&special_needs=1");
            //XmlTextReader games = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=game&special_needs=1");
            //XmlTextReader websites = new XmlTextReader("http://api.commonsensemedia.org/api/v2/reviews/browse?api_key=534823b372928738c93803b534a7a770&channel=website&special_needs=1");

            string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            string exeDir = System.IO.Path.GetDirectoryName(exeLocation);

            XmlTextReader apps = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/apps.xml"));
            XmlTextReader games = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/games.xml"));
            XmlTextReader websites = new XmlTextReader(Path.Combine(exeDir, "../Presentation/XML/websites.xml"));

            totalEntries += ImportCategory(apps);
            totalEntries += ImportCategory(games);
            totalEntries += ImportCategory(websites);

            litCount.Text = "Completed " + totalEntries.ToString() + " total imports.";
        }

        public int ImportCategory(XmlTextReader reader)
        {
            ReviewManager reviewManager = new ReviewManager();
            bool insideEntry = false;

            int count = 0;
            while (reader.ReadToFollowing("entry"))
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    ReviewModel newItem = new ReviewModel();
                    if (reader.Name == "entry")
                    {
                        insideEntry = true;
                        reader.ReadToFollowing("id");
                    }

                    if (insideEntry)
                    {
                        if (reader.Name == "id")
                        {
                            newItem.CommonSenseMediaID = reader.ReadElementContentAsString();
                        }
                        reader.ReadToNextSibling("link");

                        if (reader.Name == "link")
                        {
                            newItem.ExternalLink = reader.GetAttribute("href");
                        }
                        reader.ReadToNextSibling("category");

                        if (reader.Name == "category")
                        {
                            newItem.Type = reader.GetAttribute("term");
                        }
                        reader.ReadToNextSibling("published");

                        if (reader.Name == "published")
                        {
                            newItem.Published = Sitecore.DateUtil.ToIsoDate(DateTime.Parse(reader.ReadElementContentAsString()));
                        }
                        reader.ReadToNextSibling("title");

                        if (reader.Name == "title")
                        {
                            newItem.Title = reader.ReadElementContentAsString();
                        }
                        reader.ReadToNextSibling("summary");

                        if (reader.Name == "summary")
                        {
                            newItem.Summary = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:references");

                        if (reader.Name == "csm:references")
                        {
                            reader.ReadToDescendant("csm:reference");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:reference")
                            {
                                while (reader.Depth == depth)
                                {
                                    if (reader.GetAttribute("type") == "itunes")
                                    {
                                        newItem.AppleAppStoreID = reader.ReadElementContentAsString();
                                    }
                                    else if (reader.GetAttribute("type") == "googleplay")
                                    {
                                        newItem.GooglePlayStoreID = reader.ReadElementContentAsString();
                                    }

                                    reader.Read();
                                }
                            }
                        }
                        reader.ReadToFollowing("csm:images");

                        if (reader.Name == "csm:images")
                        {
                            List<ReviewImageModel> images = new List<ReviewImageModel>();
                            reader.ReadToDescendant("csm:image");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:image")
                            {
                                while (reader.Depth == depth)
                                {
                                    if (reader.GetAttribute("type") == "screenshot")
                                    {
                                        ReviewImageModel image = new ReviewImageModel();
                                        image.URL = reader.ReadElementContentAsString();
                                        image.Name = newItem.Title+"-screenshot-"+(images.Count+1).ToString();
                                        image.AltText = "Screenshot";
                                        images.Add(image);
                                    }
                                    else if (reader.GetAttribute("type") == "product")
                                    {
                                        ReviewImageModel image = new ReviewImageModel();
                                        image.URL = reader.ReadElementContentAsString();
                                        image.Name = newItem.Title + "-screenshot-" + (images.Count + 1).ToString();
                                        image.AltText = "Screenshot";
                                        newItem.Thumbnail = image;
                                    }

                                    reader.ReadToNextSibling("csm:image");
                                }
                            }

                            newItem.Screenshots = images;
                        }
                        reader.ReadToFollowing("csm:genre");

                        if (reader.Name == "csm:genre")
                        {
                            newItem.Genres = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:platforms");

                        if (reader.Name == "csm:platforms")
                        {
                            reader.ReadToDescendant("csm:platform");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:platform")
                            {
                                while (reader.Depth == depth)
                                {
                                    newItem.Platforms += reader.ReadElementContentAsString()+",";

                                    reader.ReadToNextSibling("csm:platform");
                                }
                            }
                        }
                        reader.ReadToFollowing("csm:prices");

                        if (reader.Name == "csm:prices")
                        {
                            reader.ReadToDescendant("csm:price");
                            newItem.Price = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:review");

                        if (reader.Name == "csm:review")
                        {
                            newItem.QualityRank = reader.GetAttribute("star_rating");
                        }
                        reader.ReadToFollowing("csm:slider");

                        if (reader.Name == "csm:slider")
                        {
                            newItem.TargetGrade = ResolveGrade(reader.GetAttribute("target_age"));
                            newItem.OffGrade = ResolveGrade(reader.GetAttribute("off_age"));
                            newItem.OnGrade = ResolveGrade(reader.GetAttribute("on_age"));
                        }
                        reader.ReadToFollowing("csm:parents_need_to_know");

                        if (reader.Name == "csm:parents_need_to_know")
                        {
                            newItem.ParentsNeedToKnow = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:description");

                        if (reader.Name == "csm:description")
                        {
                            newItem.Description = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:any_good");

                        if (reader.Name == "csm:any_good")
                        {
                            newItem.AnyGood = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:learning_rating");

                        if (reader.Name == "csm:learning_rating")
                        {
                            newItem.LearningRank = reader.GetAttribute("value");
                        }
                        reader.ReadToFollowing("csm:what_kids_can_learn");

                        if (reader.Name == "csm:what_kids_can_learn")
                        {
                            newItem.WhatKidsCanLearn = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:how_parents_help");

                        if (reader.Name == "csm:how_parents_help")
                        {
                            newItem.HowParentsCanHelp = reader.ReadElementContentAsString();
                        }
                        reader.ReadToFollowing("csm:subjects");

                        if (reader.Name == "csm:subjects")
                        {
                            reader.ReadToDescendant("csm:category");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:category")
                            {
                                while (reader.Depth == depth)
                                {
                                    newItem.Subjects += reader.GetAttribute("name") + ",";

                                    reader.ReadToNextSibling("csm:category");
                                }
                            }
                        }
                        reader.ReadToFollowing("csm:skills");

                        if (reader.Name == "csm:skills")
                        {
                            reader.ReadToDescendant("csm:category");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:category")
                            {
                                while (reader.Depth == depth)
                                {
                                    newItem.Skills += reader.GetAttribute("name")+ ",";

                                    reader.ReadToNextSibling("csm:category");
                                }
                            }
                        }
                        reader.ReadToFollowing("csm:special_needs");

                        if (reader.Name == "csm:special_needs")
                        {
                            newItem.Category = reader.GetAttribute("assistive");
                            reader.ReadToDescendant("csm:category");
                            int depth = reader.Depth;
                            if (reader.Name == "csm:category")
                            {
                                while (reader.Depth == depth)
                                {
                                    newItem.Issues += reader.GetAttribute("name") + ",";

                                    reader.ReadToNextSibling("csm:category");
                                }
                            }
                        }

                        count++;
                        reviewManager.Add(newItem);
                        insideEntry = false;
                    }
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