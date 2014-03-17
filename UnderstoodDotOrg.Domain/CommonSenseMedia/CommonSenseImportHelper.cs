using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            this.Skill = new Mapping(Settings.SkillsContainer);
            this.Subject = new Mapping(Settings.SubjectsContainer);
            this.Platform = new Mapping(Settings.PlatforomContainer);
            this.Genre = new Mapping(Settings.GenreContainer);
            this.Type = new Mapping(Settings.TypesContainer);
            this.Category = new Mapping(Settings.CategoriesContainer);
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
        /// Static class containing the various IDs and names needed for import. These are read from the app.config
        /// </summary>
        static public class Settings
        {
            // Databases
            /// <summary>
            /// Name of the Master database
            /// </summary>
            public static string MasterDatabaseName = ConfigurationManager.AppSettings["MasterDatabaseName"];

            /// <summary>
            /// Name of the Web database
            /// </summary>
            public static string WebDatabaseName = ConfigurationManager.AppSettings["WebDatabaseName"];

            // Templates
            /// <summary>
            /// GUID for the Review Data Template in Sitecore
            /// </summary>
            public static string ReviewTemplate = ConfigurationManager.AppSettings["ReviewTemplateGUID"];

            /// <summary>
            /// GUID for the Metadata Data Template in Sitecore
            /// </summary>
            public static string MetadataTemplate = ConfigurationManager.AppSettings["MetadataTemplateGUID"];

            // Content Containers
            /// <summary>
            /// GUID for the folder that holds instances of the Review content
            /// </summary>
            public static string ReviewsContainer = ConfigurationManager.AppSettings["ReviewsContainerGUID"];

            /// <summary>
            /// Sitecore path to the folder to hold screenshots and images
            /// </summary>
            public static string ImagesPath = ConfigurationManager.AppSettings["ImagesPath"];

            // Metadata Containers
            /// <summary>
            /// GUID for the folder that holds instances of Categories Metadata
            /// </summary>
            public static string CategoriesContainer = ConfigurationManager.AppSettings["CategoriesContainerGUID"];

            /// <summary>
            /// GUID for the folder that holds instances of the Genre Metadata
            /// </summary>
            public static string GenreContainer = ConfigurationManager.AppSettings["GenreContainerGUID"];

            /// <summary>
            /// GUID for the folder that holds instances of the Platform Metadata
            /// </summary>
            public static string PlatforomContainer = ConfigurationManager.AppSettings["PlatformContainerGUID"];

            /// <summary>
            /// GUID for the folder that holds instances of the Skill Metadata
            /// </summary>
            public static string SkillsContainer = ConfigurationManager.AppSettings["SkillsContainerGUID"];

            /// <summary>
            /// GUID for the folder that holds instances of the Subject Metadata
            /// </summary>
            public static string SubjectsContainer = ConfigurationManager.AppSettings["SubjectsContainerGUID"];

            /// <summary>
            /// GUID for the folder that holds instances of the Types Metadata
            /// </summary>
            public static string TypesContainer = ConfigurationManager.AppSettings["TypesContainerGUID"];
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

                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase(Settings.MasterDatabaseName);
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

        /// <summary>
        /// Returns the pipe-deliminited list of GUIDs that match the provided list of names in the given mapping. If a value does not match, it will be created in Sitecore in the appropriate container
        /// </summary>
        /// <param name="Keys">Comma-seperated list of values to match in the Mapping</param>
        /// <param name="Mapping">Use CommonSenseImportHelper.Instance Mappings to define the appropriate mapping</param>
        /// <returns>Returns the pipe-deliminted list of GUIDs that match and/or were created</returns>
        public string getRelatedIds(string Keys, Mapping Mapping)
        {
            List<string> ret = new List<string>();

            foreach (var item in Keys.Split(','))
            {
                if (Mapping.Children.ContainsKey(item))
                {
                    ret.Add(Mapping.Children[item]);
                }
                else
                {
                    try
                    {
                        string id = addMetadata(item, Mapping);
                        ret.Add(id);
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
        public static string addMedia(ReviewImageModel image)
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
                ret.Add(addMedia(item));
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
        private static string addMedia(string URL, string Name, string alt = "")
        {
            using (new SecurityDisabler())
            {
                Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions();

                options.Database = Sitecore.Configuration.Factory.GetDatabase(Settings.MasterDatabaseName);
                options.Language = Sitecore.Globalization.Language.Parse(Sitecore.Configuration.Settings.DefaultLanguage);
                options.Versioned = Sitecore.Configuration.Settings.Media.UploadAsVersionableByDefault;
                options.Destination = Settings.ImagesPath;
                options.FileBased = Sitecore.Configuration.Settings.Media.UploadAsFiles;

                Sitecore.Resources.Media.MediaCreator creator = new Sitecore.Resources.Media.MediaCreator();
                Sitecore.Data.Items.MediaItem image = creator.CreateFromStream(getStream(URL), Name, options);

                image.InnerItem.Editing.BeginEdit();

                image.InnerItem.Name = removeExtensions(Name);
                image.InnerItem["title"] = Name;
                image.InnerItem["alt"] = !string.IsNullOrEmpty(alt) ? alt : Name;

                image.InnerItem.Editing.EndEdit();

                return image.ID.ToString();
            }
        }

        /// <summary>
        /// Private function used by the getRelatedIds method to create new metadata for lookup content that doesn't exist yet
        /// </summary>
        /// <param name="Name">Name/title to use for content</param>
        /// <param name="Mapping">Mapping to relate the new metadata to</param>
        /// <returns>GUID of the new Metadata</returns>
        private string addMetadata(string Name, Mapping Mapping)
        {
            using (new SecurityDisabler())
            {
                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase(Settings.MasterDatabaseName);
                Sitecore.Data.Items.Item container = master.GetItem(Mapping.Container);
                Sitecore.Data.Items.TemplateItem metadataTemplate = master.Templates[Settings.MetadataTemplate];
                Sitecore.Data.Items.Item newItem = container.Add(Name, metadataTemplate);

                newItem.Editing.BeginEdit();

                newItem["Content Title"] = Name;

                newItem.Editing.EndEdit();

                Mapping.updateMapping();

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

        /// <summary>
        /// Revmoes invalid punctionation from potential Sitecore names
        /// </summary>
        /// <param name="s">string to cleanse</param>
        /// <returns>string with invalid characters replaced</returns>
        public static string removePunctuation(string s)
        {
            return Regex.Replace(s, @"[^\w\.@-]", "");
        }

    }
}
