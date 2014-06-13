using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Publishing;
using Sitecore.Resources.Media;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UnderstoodDotOrg.Domain.CommonSenseMedia;

namespace UnderstoodDotOrg.Domain.Importer
{
    /// <summary>
    /// Class containing helpers for importing content into Sitecore from CommonSenseMedia
    /// </summary>
    public class CommonSenseImportHelper
    {
        #region Singleton Constructor
        private static CommonSenseImportHelper instance;

        private CommonSenseImportHelper()
        {
            this.Settings = new ImportSettings();
            this.Skill = new Mapping(this.Settings.SkillsContainer);
            this.Subject = new Mapping(this.Settings.SubjectsContainer);
            this.Platform = new Mapping(this.Settings.PlatforomContainer);
            this.Genre = new Mapping(this.Settings.GenreContainer);
            this.Type = new Mapping(this.Settings.TypesContainer);
            this.Category = new Mapping(this.Settings.CategoriesContainer);
        }

        public static CommonSenseImportHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonSenseImportHelper();
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Class containing the various IDs and names needed for import. These are read from the app.config
        /// </summary>
        public class ImportSettings
        {
            /// <summary>
            /// Initializes the settings from the app.config
            /// </summary>
            public ImportSettings()
            {
                this.MasterDatabaseName = ConfigurationManager.AppSettings["MasterDatabaseName"];
                this.WebDatabaseName = ConfigurationManager.AppSettings["WebDatabaseName"];
                this.ReviewTemplate = ConfigurationManager.AppSettings["ReviewTemplateGUID"];
                this.MetadataTemplate = ConfigurationManager.AppSettings["MetadataTemplateGUID"];
                this.ReviewsContainer = ConfigurationManager.AppSettings["ReviewsContainerGUID"];
                this.ImagesPath = ConfigurationManager.AppSettings["ImagesPath"];
                this.CategoriesContainer = ConfigurationManager.AppSettings["CategoriesContainerGUID"];
                this.GenreContainer = ConfigurationManager.AppSettings["GenreContainerGUID"];
                this.PlatforomContainer = ConfigurationManager.AppSettings["PlatformContainerGUID"];
                this.SkillsContainer = ConfigurationManager.AppSettings["SkillsContainerGUID"];
                this.SubjectsContainer = ConfigurationManager.AppSettings["SubjectsContainerGUID"];
                this.TypesContainer = ConfigurationManager.AppSettings["TypesContainerGUID"];
            }

            // Databases
            /// <summary>
            /// Name of the Master database
            /// </summary>
            public string MasterDatabaseName;

            /// <summary>
            /// Name of the Web database
            /// </summary>
            public string WebDatabaseName;

            // Templates
            /// <summary>
            /// GUID for the Review Data Template in Sitecore
            /// </summary>
            public string ReviewTemplate;

            /// <summary>
            /// GUID for the Metadata Data Template in Sitecore
            /// </summary>
            public string MetadataTemplate;

            // Content Containers
            /// <summary>
            /// GUID for the folder that holds instances of the Review content
            /// </summary>
            public string ReviewsContainer;

            /// <summary>
            /// Sitecore path to the folder to hold screenshots and images
            /// </summary>
            public string ImagesPath;

            // Metadata Containers
            /// <summary>
            /// GUID for the folder that holds instances of Categories Metadata
            /// </summary>
            public string CategoriesContainer;

            /// <summary>
            /// GUID for the folder that holds instances of the Genre Metadata
            /// </summary>
            public string GenreContainer;

            /// <summary>
            /// GUID for the folder that holds instances of the Platform Metadata
            /// </summary>
            public string PlatforomContainer;

            /// <summary>
            /// GUID for the folder that holds instances of the Skill Metadata
            /// </summary>
            public string SkillsContainer;

            /// <summary>
            /// GUID for the folder that holds instances of the Subject Metadata
            /// </summary>
            public string SubjectsContainer;

            /// <summary>
            /// GUID for the folder that holds instances of the Types Metadata
            /// </summary>
            public string TypesContainer;
        }

        /// <summary>
        /// Class that handles the relationship for groups of Metadata
        /// </summary>
        public class Mapping
        {
            /// <summary>
            /// Each entry represents an instance of Metadata. Key is the name, Value is the GUID to use for creating relationships
            /// </summary>
            public Dictionary<string, string> Children { get; set; }

            /// <summary>
            /// GUID for the container to load
            /// </summary>
            public string Container { get; set; }

            /// <summary>
            /// Clears and updates the Children dictionary
            /// </summary>
            public void updateMapping()
            {
                if (this.Children != null && this.Children.Count > 0)
                {
                    this.Children.Clear();
                }

                this.Children = new Dictionary<string, string>();
                this.Children = this.getChildren(this.Container);
            }

            /// <summary>
            /// Called when loading or reloading the mapping
            /// </summary>
            /// <param name="Container">GUID of the container to load</param>
            /// <returns>Dictionary that represents the children of the container. Key is the name of the item, Value is the GUID</returns>
            private Dictionary<string, string> getChildren(string Container)
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();

                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase(Instance.Settings.MasterDatabaseName);
                Sitecore.Data.Items.Item container = master.GetItem(Container);

                foreach (Sitecore.Data.Items.Item item in container.Children)
                {
                    ret.Add(item.Name, item.ID.ToString());
                }

                return ret;
            }

            /// <summary>
            /// Creates a new instance of the Mapping class
            /// </summary>
            /// <param name="Container">GUID for the container to load</param>
            public Mapping(string Container)
            {
                this.Container = Container;
                this.updateMapping();
            }
        }

        public ImportSettings Settings { get; set; }

        /// <summary>
        /// Mapping instance for Skill relations
        /// </summary>
        public Mapping Skill { get; set; }

        /// <summary>
        /// Mapping instance for Subject relations
        /// </summary>
        public Mapping Subject { get; set; }

        /// <summary>
        /// Mapping instance for Platform relations
        /// </summary>
        public Mapping Platform { get; set; }

        /// <summary>
        /// Mapping instance for Genre relations
        /// </summary>
        public Mapping Genre { get; set; }

        /// <summary>
        /// Mapping instance for Type relations
        /// </summary>
        public Mapping Type { get; set; }

        /// <summary>
        /// Mapping instance for the Category relations
        /// </summary>
        public Mapping Category { get; set; }

        public static string MatchCSV(string Keys, string folder)
        {
            List<string> ret = new List<string>();

            foreach (string s in Keys.Split(','))
            {
                Item folderItem = Sitecore.Context.Database.GetItem(folder);
                bool added = false;
                string itemTemplateID = "";
                ChildList children = folderItem.Children;
                foreach (Item i in children)
                {
                    itemTemplateID = i.TemplateID.ToString();
                    if (i.Fields["Content Title"].ToString().ToLower().Trim() == s.ToLower().Trim())
                    {
                        ret.Add(i.ID.ToString());
                        added = true;
                    }
                }
                if (!added)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(itemTemplateID))
                        {
                            string id = addMetadata(s, folder, itemTemplateID);
                            ret.Add(id);
                        }
                    }
                    catch
                    {
                        // failed to add
                    }
                }
            }

            // Sitecore loves it's pipe-deliminated lists...
            return string.Join("|", ret.ToArray());
        }

        /// <summary>
        /// Adds a single instace of ReviewImage to Sitecore. Inserts into the container defined in Settings.ImagePath
        /// </summary>
        /// <param name="image">Image to add to Sitecore</param>
        /// <returns>Returns GUID of the image that was added to Sitecore</returns>
        public static MediaItem addMedia(ReviewImageModel image)
        {
            return addMedia(image.URL, image.Name, image.AltText);
        }

        /// <summary>
        /// Process a list of ReviewImages to add to Sitecore. Inserts into the container defined in Settings.ImagePath
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public static string addMedia(List<ReviewImageModel> images)
        {
            List<string> ret = new List<string>();

            foreach (var item in images)
            {
                ret.Add(addMedia(item).ID.ToString());
            }

            return string.Join("|", ret.ToArray());
        }

        /// <summary>
        /// Private backer used by the other addMedia calls
        /// </summary>
        /// <param name="URL">URL path to the image to insert</param>
        /// <param name="Name">Name to use for the image</param>
        /// <param name="alt">Alt text to use for the image</param>
        /// <returns>GUID of the new image</returns>
        private static MediaItem addMedia(string URL, string Name, string alt = "")
        {
            try
            {
                using (new SecurityDisabler())
                {
                    Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions();

                    options.Database = Sitecore.Configuration.Factory.GetDatabase("master");
                    options.Language = Sitecore.Globalization.Language.Parse(Sitecore.Configuration.Settings.DefaultLanguage);
                    options.Versioned = false;
                    Item mediaFolder = Sitecore.Context.Database.GetItem("{7EEDCF55-DFC8-4BF1-8AD2-672B18E46763}");
                    options.Destination = string.Format("{0}/{1}", mediaFolder.Paths.FullPath, Name);
                    options.FileBased = Sitecore.Configuration.Settings.Media.UploadAsFiles;

                    MediaCreator creator = new MediaCreator();
                    MediaItem image = creator.CreateFromStream(getStream(URL), Name + getExtension(URL), options);

                    image.InnerItem.Editing.BeginEdit();

                    image.InnerItem["title"] = Name;
                    image.InnerItem["alt"] = !string.IsNullOrEmpty(alt) ? alt : Name;

                    image.InnerItem.Editing.EndEdit();

                    return image;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Private function used by the getRelatedIds method to create new metadata for lookup content that doesn't exist yet
        /// </summary>
        /// <param name="Name">Name/title to use for content</param>
        /// <param name="Mapping">Mapping to relate the new metadata to</param>
        /// <returns>GUID of the new Metadata</returns>
        public static string addMetadata(string Name, string folderID, string itemTemplateID)
        {
            using (new SecurityDisabler())
            {
                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
                Sitecore.Data.Database web = Sitecore.Configuration.Factory.GetDatabase("web");
                Item container = master.GetItem(folderID);
                TemplateItem metadataTemplate = master.Templates[itemTemplateID];
                Item newItem = container.Add(Name, metadataTemplate);

                newItem.Editing.BeginEdit();

                newItem["Content Title"] = Name;

                newItem.Editing.EndEdit();

                PublishItem(newItem, master);
                PublishItem(newItem, web);

                return newItem.ID.ToString();
            }
        }

        /// <summary>
        /// Used to retrieve an Image from the URL and return as a memory stream
        /// </summary>
        /// <param name="URL">URL of image to retrieve</param>
        /// <returns>Stream of bytes of the image</returns>
        private static System.IO.Stream getStream(string URL)
        {
            WebClient wc = new WebClient();
            byte[] image = wc.DownloadData(URL);
            return new MemoryStream(image);
        }

        /// <summary>
        /// Normalizes names of content and follow Sitecore's naming convention - no punction
        /// </summary>
        /// <param name="s">string to trim</param>
        /// <returns>trimmed string</returns>
        private static string removeExtensions(string s)
        {
            return s.Remove(s.LastIndexOf('.'));
        }

        private static string getExtension(string s)
        {
            String pattern = @"\.([^(\s|.)]+)$";

            Regex r = new Regex(pattern);
            Match m = r.Match(s);
            if (m.Success)
            {
                string ext = m.Groups[1].Value;
                //int questionMarkIndex = ext.IndexOf("?");
                //if (questionMarkIndex != -1)
                //{
                //    if (questionMarkIndex == 3)
                //        return ext.Substring(0, 3);
                //    else
                //        return ext.Substring(0, 4)
                //}
                return removeCertainCharacters("." + ext.Substring(0, 4));
            }

            return "";
        }

        /// <summary>
        /// Revmoes invalid punctionation from potential Sitecore names
        /// </summary>
        /// <param name="s">string to cleanse</param>
        /// <returns>string with invalid characters replaced</returns>
        public static string removePunctuation(string s)
        {
            return Regex.Replace(s, @"[^\w\.@-]", " ");
        }

        public static string removeCertainCharacters(string s)
        {
            return s.Replace("?", "").Replace("-", "");
        }

        private static void PublishItem(Item item, Database database)
        {
            PublishOptions publishOptions = new PublishOptions
            (
                item.Database,
                database,
                Sitecore.Publishing.PublishMode.SingleItem,
                item.Language,
                DateTime.Now
            );

            Publisher publisher = new Publisher(publishOptions);
            publisher.Options.RootItem = item;
            publisher.Publish();
        }

        public static string GetCategory(string category)
        {
            ChildList categories = Sitecore.Context.Database.GetItem("{8DE67A64-0E64-47A5-87FD-5096F3979F55}").Children;

            if (category == "1")
                return categories[0].ID.ToString();
            else
                return categories[1].ID.ToString();
        }
    }
}
