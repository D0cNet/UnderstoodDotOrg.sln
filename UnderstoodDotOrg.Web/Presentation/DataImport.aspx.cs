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
            while (reader.ReadToFollowing("entry") && count < 2)
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

            if (kidAge >= 2 && kidAge <= 4)
                return "0";
            else if (kidAge < 17)
                return (kidAge - 5).ToString();
            else if (kidAge <= 17 && kidAge >= 18)
                return "12";

            return "0";
        }

        public static void InsertToDB(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                        new SqlConnection(DataImport.ConnectionString))
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItem_Temp (ItemName, ItemValue, CSMReviewItemID, ImportStatusID, ReviewID) 
                        VALUES (@name, @value, @csmRev, @importStatus, @reviewId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@csmRev", csmId);
                        cmd.Parameters.AddWithValue("@importStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@reviewId", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }

            }
        }

        public static void InsertAttrubuteToDB(string attName, string attValue, string id)
        {
            using (SqlConnection conn =
                        new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                if (attValue == null)
                {
                    attValue = string.Empty;
                }
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItemAttribute_Temp (ParentItemID, AttributeName, AttributeValue, ImportStatusID) 
                        VALUES (@id, @name, @value, @importStatus)", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", attName);
                        cmd.Parameters.AddWithValue("@value", attValue);
                        cmd.Parameters.AddWithValue("@importStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }
            }
        }

        public static void InsertChildToDB(string pItemId, string cItemName, string cItemValue, string importStatusId)
        {
            using (SqlConnection conn =
                        new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"INSERT tbl_MediaReviewItemChildren_Temp (ParentItemID, ChildItemName, ChildItemValue, ImportStatusID) 
                        VALUES (@pItemId, @cItemName, @cItemValue, @importStatusId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@pItemId", pItemId);
                        cmd.Parameters.AddWithValue("@cItemName", cItemName);
                        cmd.Parameters.AddWithValue("@cItemValue", cItemValue);
                        cmd.Parameters.AddWithValue("@importStatusId", importStatusId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Insert Failed
                }

            }
        }

        public static void UpdateDB(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand(@"UPDATE tbl_MediaReviewItem_Temp SET ItemName=@NewName, ItemValue=@NewValue,
                                    CSMReviewItemID=@NewCsmRev, ImportStatusID=@NewImportStatus, ReviewID=@NewReviewID 
                                    WHERE ItemName=@NewName AND ItemValue=@NewValue AND CSMReviewItemID=@NewCsmRev", conn))
                    {
                        cmd.Parameters.AddWithValue("@NewName", name);
                        cmd.Parameters.AddWithValue("@NewValue", value);
                        cmd.Parameters.AddWithValue("@NewCsmRev", csmId);
                        cmd.Parameters.AddWithValue("@NewImportStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@NewReviewID", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Update Failed
                }
            }
        }

        public static void UpdateDBChild(string name, string value, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                        new SqlCommand(@"UPDATE tbl_MediaReviewItem_Temp SET ItemName=@NewName, ItemValue=@NewValue,
                                    CSMReviewItemID=@NewCsmRev, ImportStatusID=@NewImportStatus, ReviewID=@NewReviewID 
                                    WHERE ItemName=@NewName AND ItemValue=@NewValue AND CSMReviewItemID=@NewCsmRev", conn))
                    {
                        cmd.Parameters.AddWithValue("@NewName", name);
                        cmd.Parameters.AddWithValue("@NewValue", value);
                        cmd.Parameters.AddWithValue("@NewCsmRev", csmId);
                        cmd.Parameters.AddWithValue("@NewImportStatus", "A080CB47-D017-40C4-A6D9-6E86BAA1CD18");
                        cmd.Parameters.AddWithValue("@NewReviewID", "B77B8C7D-B89C-4E6E-9CCE-1FAA2C092941");

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    //Update Failed
                }
            }
        }

        public static string GetDBItem(string item, string table, string name, string csmId)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=AODEV02\SQL2008R2;Initial Catalog=Poses_Understood_DataImport;User ID=sa;Password=OasisD8A"))
            {
                string itemId = string.Empty;

                conn.Open();

                try
                {
                    using (SqlCommand cmd =
                new SqlCommand(@"SELECT " + item + @" FROM " + table +
                    " WHERE ItemName='" + name + "' AND CSMReviewItemID='" + csmId + "'", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();

                        itemId = reader["ItemID"].ToString();

                        reader.Close();

                        return itemId;
                    }
                }
                catch (SqlException ex)
                {
                    //Get Item Failed
                    return null;
                }
            }
        }
    }
}