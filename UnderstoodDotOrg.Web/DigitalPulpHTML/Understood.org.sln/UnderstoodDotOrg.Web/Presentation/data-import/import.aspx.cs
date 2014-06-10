using MySql.Data.MySqlClient;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Text;

using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace UnderstoodDotOrg.Web.Presentation.data_import {
    public partial class import : System.Web.UI.Page {

        #region variables
        // Item Paths
        const string Article_Folder = "/sitecore/content/Home/Test Article/basic article page"; // Article_Folder

        // Templates
        const string Basic_Article_Page = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Basic Article Page";

        // Tag Templates
        const string ChildIssueTemplate = "{FB6B3A57-321D-4223-9C2E-4549E87A7EF6}";
        const string ChildGradesTemplate = "{8F66C22B-74C3-41C7-9250-78A84B80A114}";
        const string ChildDiagnosesTemplate = "{C037EF93-CAE5-4265-8147-B45684572A93}";
        const string ComplexityLevelsTemplate = "{80406B71-267C-4968-BE6D-C1F3BAF6E223}";
        const string DiagnosedConditionTemplate = "{921D963F-9F71-479A-82D5-520670B4B13C}";
        const string ApplicableInterestsTemplate = "{49DC2843-2B4B-4448-854E-811E73F02360}";
        const string ApplicablePersonalitiesTemplate = "{47A67037-5C69-4E77-8E24-0695638B0B62}";
        const string OtherApplicableEvaluationsTemplate = "{D82CEBBC-DD83-4EBF-8EC1-E46F8DD06713}";
        #endregion

        // Product Symbols


        #region Create Item
        private Item CreateItem(string rootItempath, string templateItempath, string itemName, Dictionary<string, string> fieldsToUpdate, bool addVersion, Item defaultLanguageItem, string lang, string postid, string posttype) {
            Item newItem = null;
            // The SecurityDisabler overrides the current security model, allowing you
            // to access the item without any security. It's like the user being an administrator
            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                // Get the master database
                Sitecore.Data.Database master = Sitecore.Data.Database.GetDatabase("master");
                // Get the template to base the new item on
                TemplateItem template = master.GetItem(templateItempath);


                // Get the place in the site tree where the new item must be inserted
                Item parentItem = master.GetItem(rootItempath);
                //  itemName = itemName + "-" + postid;
                //  itemName = RemoveSpecialCharacters(itemName);
                if (addVersion == false) {
                    newItem = CreateDefaultLanguageItem(itemName + postid, fieldsToUpdate, newItem, template, parentItem);
                    //AddLanguageVersionItem(posttype, itemName, fieldsToUpdate, template, newItem, master, lang, postid);
                }

                if (newItem == null) {
                    newItem = defaultLanguageItem;
                }

                newItem = AddLanguageVersionItem(posttype, itemName, fieldsToUpdate, template, newItem, master, lang, postid);
            }
            return newItem;
        }

        private Item AddLanguageVersionItem(string posttype, string itemName, Dictionary<string, string> fieldsToUpdate, TemplateItem template, Item newItem, Sitecore.Data.Database master, string lang, string postid) {

            Item newLanguageVersionItem = master.GetItem(newItem.Paths.Path, Sitecore.Globalization.Language.Parse(lang));

            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                try {
                    if (0 == newLanguageVersionItem.Versions.Count) {
                        newLanguageVersionItem.Versions.AddVersion();
                    }

                    newLanguageVersionItem.Editing.BeginEdit();
                    // Assign values to the fields of the new item
                    foreach (var fields in fieldsToUpdate) {
                        if (fields.Key == "Content Thumbnail") {
                            MediaItem mediaItem = DownloadImage(fields.Value);

                            Sitecore.Data.Fields.ImageField image = newLanguageVersionItem.Fields[fields.Key];
                            image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                            image.Alt = mediaItem.Alt;
                            image.MediaID = mediaItem.ID;

                        }
                        else {
                            if (fields.Key == "Page Title") {
                                Response.Write(postid + " | " + lang + " | <b>" + fields.Value + "</b><br/>");
                            }
                            newLanguageVersionItem.Fields[fields.Key].Value = fields.Value;

                        }
                        string tagids = string.Empty;
                        string source = string.Empty;
                        switch (fields.Key) {
                            case "Child Issues":
                                tagids = GetTags(posttype, "child-issue", postid, ChildIssueTemplate, "Issue Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Child Grades":
                                tagids = GetTags(posttype, "grade_level", postid, ChildGradesTemplate, "Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Child Diagnoses":
                                tagids = GetTags(posttype, "child-diagnosis", postid, ChildDiagnosesTemplate, "Diagnosis Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Complexity Levels":

                                tagids = GetTags(posttype, "content-complexity", postid, ComplexityLevelsTemplate, "Complexity Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Diagnosed Condition":
                                tagids = GetTags(posttype, "diagnosed-undiagnosed", postid, DiagnosedConditionTemplate, "Diagnosis Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }

                                break;
                            case "Applicable Interests":
                                tagids = GetTags(posttype, "parent-interests", postid, ApplicableInterestsTemplate, "Applicable Interests");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Applicable Personalities":
                                tagids = GetTags(posttype, "personality-type", postid, ApplicablePersonalitiesTemplate, "Personality Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;
                            case "Other Applicable Evaluations":
                                tagids = GetTags(posttype, "other-evaluations", postid, OtherApplicableEvaluationsTemplate, "Evaluation Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    newLanguageVersionItem[fields.Key] = tagids;
                                }
                                break;


                            //case "Reviewed by":
                            //    source = "/sitecore/content/Globals/Content Taxonomies/Article/Reviewers";
                            //    tagids = GetTags(posttype, "child-diagnosis", newLanguageVersionItem.Fields["Reviewed by"].Source, postid, source);
                            //    if(!string.IsNullOrEmpty(tagids)){
                            //        newLanguageVersionItem[fields.Key] = tagids;
                            //    }
                            //    break;
                        }
                        // newLanguageVersionItem.Fields[fields.Key].Value = fields.Value;
                    }
                    newLanguageVersionItem.Editing.EndEdit();
                    newLanguageVersionItem.Editing.AcceptChanges();

                }
                catch (Exception ex) {
                    newLanguageVersionItem.Editing.CancelEdit();

                }
            }

            return newLanguageVersionItem;
        }

        private Item CreateDefaultLanguageItem(string itemName, Dictionary<string, string> fieldsToUpdate, Item newItem, TemplateItem template, Item parentItem) {
            // Add the item to the site tree
            newItem = parentItem.Add(RemoveSpecialCharacters(itemName.Trim()), template);
            //addVersion.
            // Set the new item in editing mode
            // Fields can only be updated when in editing mode
            // (It's like the begin tarnsaction on a database)
            if (fieldsToUpdate != null) {
                newItem.Editing.BeginEdit();
                try {
                    // Assign values to the fields of the new item
                    foreach (var fields in fieldsToUpdate) {
                        if (fields.Key == "Content Thumbnail") {
                            MediaItem mediaItem = DownloadImage(fields.Value);

                            Sitecore.Data.Fields.ImageField image = newItem.Fields[fields.Key];
                            image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                            image.Alt = mediaItem.Alt;
                            image.MediaID = mediaItem.ID;

                        }
                        else {
                            newItem.Fields[fields.Key].Value = fields.Value;
                        }
                    }
                    // End editing will write the new values back to the Sitecore
                    // database (It's like commit transaction of a database)
                    newItem.Editing.EndEdit();
                }
                catch (System.Exception ex) {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.Message, this);

                    // Cancel the edit (not really needed, as Sitecore automatically aborts
                    // the transaction on exceptions, but it wont hurt your code)
                    newItem.Editing.CancelEdit();
                    Response.Write(newItem.Paths.FullPath);
                    Response.Write(ex.Message);
                    Response.End();
                }
            }

            return newItem;
        }

        public static string RemoveSpecialCharacters(string str) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                if ((str[i] >= '0' && str[i] <= '9')
                    || (str[i] >= 'A' && str[i] <= 'z'
                        || (str[i] == '_' || str[i] == '-' || str[i] == ' '))) {

                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["submit"] != null && Request.QueryString["submit"].ToString() == "ok") {
                this.GetTexonomy();
            }
            if (Request.QueryString["submit"] != null && Request.QueryString["submit"].ToString() == "user") {
                this.GetUser();
            }

        }

        private void GetUser() {
            Item newItem = null;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT wu.id, CONCAT(ss.FirstName,' ' ,ss1.LastName) as UserName,ss2.Description " +
                                "FROM wp_users wu  " +
                                "INNER JOIN (SELECT wum.user_id, wum.meta_value AS FirstName  FROM wp_usermeta wum WHERE wum.meta_key = 'first_name') ss ON " +
                                "ss.user_id = wu.ID " +
                                "INNER JOIN (SELECT wum.user_id, wum.meta_value AS LastName  FROM wp_usermeta wum WHERE wum.meta_key = 'last_name') ss1 ON " +
                                "ss1.user_id = wu.ID " +
                                "INNER JOIN (SELECT wum.user_id, wum.meta_value AS Description  FROM wp_usermeta wum WHERE wum.meta_key = 'description') ss2 ON " +
                                "ss2.user_id = wu.ID " +
                                "ORDER BY wu.display_name";
            connection.Open();
            cmd.CommandText = getPostQuery;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];



            foreach (DataRow varrow in datasource.Rows) {
                Dictionary<string, string> ids = new Dictionary<string, string>();
                ids.Add("Revierwer Name", varrow["UserName"].ToString());
                ids.Add("Revierwer Bio", varrow["Description"].ToString());
                string userloc = "/sitecore/content/Globals/Content Taxonomies/Article/Reviewers";
                string reviewerTemplate = "/sitecore/templates/User Defined/Poses/Shared/Base Template/Article/Reviewer Bio";
                if (!string.IsNullOrEmpty(Convert.ToString(varrow["UserName"]).Trim())) {
                    CreateItem(userloc, reviewerTemplate, varrow["UserName"].ToString(), ids, false, null, "en", null, null);
                }
            }


        }

        public MediaItem AddFile(string fileName, string mediaItemName) {
            string sitecorePath = "/sitecore/media library/Images/Poses/wordpress";
            // Create the options
            Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions();
            // Store the file in the database, not as a file
            options.FileBased = false;
            // Remove file extension from item name
            options.IncludeExtensionInItemName = false;
            // Overwrite any existing file with the same name
            options.KeepExisting = false;
            // Do not make a versioned template
            options.Versioned = false;
            // set the path
            options.Destination = sitecorePath + "/" + mediaItemName;
            // Set the database
            options.Database = Sitecore.Configuration.Factory.GetDatabase("master");

            // Now create the file
            Sitecore.Resources.Media.MediaCreator creator = new Sitecore.Resources.Media.MediaCreator();
            string mediaitempath = sitecorePath + "/" + fileName;
            Item posesMediaItem = Sitecore.Context.Database.GetItem(mediaitempath);
            MediaItem mediaItem = null;
            if (posesMediaItem == null) {
                mediaItem = creator.CreateFromFile(fileName, options);
            }
            return mediaItem;
        }

        private MediaItem DownloadImage(string img) {
            string imageUrl = @"http://wordpress.webstagesite.com.php53-9.dfw1-1.websitetestlink.com" + img;
            string filename = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1);
            string saveLocation = Server.MapPath("~/Presentation/Includes/wordpressimg/") + filename;
            //@"C:\temp\" + filename;

            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream)) {
                imageBytes = br.ReadBytes(500000);
                //test(responseStream, filename);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            using (FileStream fs = new FileStream(saveLocation, FileMode.Create)) {
                BinaryWriter bw = new BinaryWriter(fs);
                try {
                    bw.Write(imageBytes);

                }
                finally {
                    fs.Close();
                    bw.Close();
                }
            }
            return AddFile(saveLocation, RemoveSpecialCharacters(filename.Split(new char[] { '.' })[0]));
        }
        string MyConnectionString = "server=localhost;database=testf;Uid=sa;Pwd=simple;pooling = false; convert zero datetime=True";
        private void GetTexonomy() {
            Item postItem = null;
            string posttype = "basic_article_image";
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT wt.slug " +
                                  "FROM testf.wp_posts p " +
                                  "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                  "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                  "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                  "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id " +
                                  "WHERE p.post_type = 'basic_article_image' AND wtt.taxonomy = 'post_translations' AND wtt.count > 0";

            connection.Open();

            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];
            //DataTable tops = datasource.Rows.Cast<System.Data.DataRow>().Take(40).CopyToDataTable();
            foreach (DataRow dr in datasource.Rows) {
                this.GetLanguagePosts(dr["slug"].ToString(), posttype);
            }

            connection.Close();
        }

        private void GetLanguagePosts(string translationid, string posttype) {
            Item postItem = null;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT " +
                                  "DISTINCT p.ID, R1.slug " +
                                  "FROM testf.wp_posts p " +
                                  "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                  "              INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                  "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                  "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id" +
                                  "               WHERE wtt1.taxonomy = 'language') R1 ON R1.ID = p.ID " +
                                  "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                  "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                  "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                  "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id " +
                                  "WHERE  p.post_type = 'basic_article_image' AND " +
                                  " wt.slug = '" + translationid + "' " +
                                  "AND wtt.taxonomy = 'post_translations' AND wtt.count > 0 ";

            connection.Open();
            cmd.CommandText = getPostQuery;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];
            //throw new NotImplementedException();
            string page_title = string.Empty;
            string post_name = string.Empty;
            string post_alternatename = string.Empty;



            foreach (DataRow dr in datasource.Rows) {

                if (dr["slug"].ToString().Equals("en")) {
                    postItem = this.GetPostContent("en", dr["ID"].ToString(), posttype, false, null);
                }
                else {
                    this.GetPostContent(dr["slug"].ToString(), dr["ID"].ToString(), posttype, true, postItem);
                }
            }
        }

        private Item GetPostContent(string langu, string postid, string posttype, bool addVersion, Item defaultLanguageItem) {
            Item postItem = null;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT ID,  post_author,  post_content,  post_title, post_name,  post_status, " +
                                  "comment_status, post_name,  post_content_filtered,  post_parent,  guid,  menu_order,  post_type, " +
                                  "post_mime_type,  comment_count FROM testf.wp_posts Where ID = " + postid + " And post_type='" + posttype + "'";
            connection.Open();
            cmd.CommandText = getPostQuery;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];
            //throw new NotImplementedException();
            string page_title = string.Empty;
            string post_name = string.Empty;
            string post_alternatename = string.Empty;



            foreach (DataRow dr in datasource.Rows) {

                //  Response.Write(dr["ID"].ToString() + " | " + langu + " | <b>" + dr["post_title"].ToString() + "</b><br/>");
                page_title = String.IsNullOrEmpty(Convert.ToString(dr["post_title"]).Trim()) ? string.Empty : Convert.ToString(dr["post_title"]);
                post_alternatename = String.Format("{0}-{1}", String.IsNullOrEmpty(Convert.ToString(dr["post_type"])) ? string.Empty : Convert.ToString(dr["post_type"]), dr["ID"].ToString());
                //   post_name = String.IsNullOrEmpty(Convert.ToString(dr["post_name"])) ? post_alternatename : Convert.ToString(dr["post_name"]);
                postItem = this.GetPostDetail(dr["ID"].ToString(), langu, page_title.Replace(" ", "-"), page_title, addVersion, defaultLanguageItem, posttype);
                // Response.Write("<br/><div style=\"border:1px solid red; width:100%;\" ></div><br/>");
                break;
            }

            connection.Close();
            return postItem;
        }

        private Item GetPostDetail(string postid, string lang, string itemname, string page_title, bool addVersion, Item defaultLanguageItem, string posttype) {
            Item newItem = null;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT pm.*, t.slug " +
                                  "FROM wp_posts p " +
                                  "INNER JOIN wp_postmeta pm ON p.ID = pm.post_id " +
                                  "INNER JOIN wp_term_relationships tr ON p.ID = tr.object_id " +
                                  "INNER JOIN wp_term_taxonomy tt ON tr.term_taxonomy_id = tt.term_taxonomy_id " +
                                  "INNER JOIN wp_terms t ON tt.term_id = t.term_id " +
                                  "WHERE p.ID =" + postid + " AND t.slug ='" + lang + "'";
            connection.Open();
            cmd.CommandText = getPostQuery;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];
            Dictionary<string, string> ids = new Dictionary<string, string>();
            ids.Add("Page Title", page_title);
            ids.Add("Post", postid);

            foreach (DataRow varrow in datasource.Rows) {
                //Response.Write(varrow["meta_key"].ToString() + "|" + varrow["meta_value"].ToString() + "<br/>");
                switch (varrow["meta_key"].ToString()) {
                    case "wpcf-content-thumbnail":
                        if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {

                            ids.Add("Content Thumbnail", varrow["meta_value"].ToString());
                        }
                        break;
                    case "wpcf-feature-image":
                      
                        break;
                    case "wpcf-meta-title":
                        ids.Add("Meta Title", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-meta-keywords":
                        ids.Add("Meta Keywords", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-meta-description":
                        ids.Add("Meta Description", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-article-content":
                        ids.Add("Body Content", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-at-a-glance":

                        ids.Add("Headline Text", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-key-takeaway":
                        ids.Add("Key Takeaway Data", varrow["meta_value"].ToString());
                        break;
                }


            }
            ids.Add("Child Issues", "");
            ids.Add("Child Grades", "");
            ids.Add("Child Diagnoses", "");
            ids.Add("Complexity Levels", "");
            ids.Add("Diagnosed Condition", "");
            ids.Add("Applicable Interests", "");
            ids.Add("Applicable Personalities", "");
            ids.Add("Other Applicable Evaluations", "");

            newItem = CreateItem(Article_Folder, Basic_Article_Page, itemname, ids, addVersion, defaultLanguageItem, lang, postid, posttype);
            connection.Close();
            return newItem;
        }

        private string GetTags(string articleType, string tagType, string postId, string templateId, string fieldName) {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT wt.slug,wt.name, wtt.taxonomy, wtt.term_id, wtt.term_taxonomy_id, wtr.object_id " +
             "FROM testf.wp_posts p " +
             "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
             "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
             "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id " +
             "WHERE p.post_type = '" + articleType + "' AND wtt.taxonomy = '" + tagType + "'  " +
             "AND wtr.object_id IN (" + postId + ") " +
             "ORDER BY wtr.object_id";
            connection.Open();
            cmd.CommandText = getPostQuery;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];


            String tagIds = String.Empty;


            foreach (DataRow varrow in datasource.Rows) {
                //GetTagItem(varrow["name"].ToString(), "{FB6B3A57-321D-4223-9C2E-4549E87A7EF6}", "Issue Name");
                Item child = GetTagItem(varrow["name"].ToString(), templateId, fieldName);
                //sourceItem.GetChildren().Where(t => t.Fields[fieldName].Value == varrow["name"].ToString()).FirstOrDefault();
                if (child != null) {
                    tagIds = tagIds + "|" + child.ID.ToString();
                }
            }


            connection.Close();
            if (tagIds.Length > 0) {
                tagIds = tagIds.Substring(1);
            }
            return tagIds;
        }


        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public Item GetTagItem(string keyword, string templateId, string field) {
            //"Issue Name"
            Item searchItem = null;
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {

                List<Item> searchResultItems = new List<Item>();
                searchResultItems = context.GetQueryable<SearchResultItem>().
                   Where(i => i.TemplateId == Sitecore.Data.ID.Parse(templateId)).

                   Select(i => (Item)i.GetItem()).ToList();

                if (searchResultItems.Any()) {
                    searchItem = searchResultItems.Where(t => t.Fields[field].Value == keyword).FirstOrDefault();
                }
            }
            return searchItem;
        }
    }
}