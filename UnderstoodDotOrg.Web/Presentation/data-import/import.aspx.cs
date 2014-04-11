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
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.data_import {
    public partial class import : System.Web.UI.Page {

        // Item Paths
        const string Article_Folder = "/sitecore/content/Home/Articles"; // Article_Folder


        // Templates
        const string Basic_Article_Page = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Basic Article Page"; // Product Symbols


        #region Create Item
        private Item CreateItem(string rootItempath, string templateItempath, string itemName, Dictionary<string, string> fieldsToUpdate, bool addVersion, Item defaultLanguageItem, string lang) {
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
                
                if (addVersion == false) {
                    newItem = CreateDefaultLanguageItem(itemName, fieldsToUpdate, newItem, template, parentItem);
                    AddLanguageVersionItem(itemName, fieldsToUpdate, template, newItem, master, lang);
                }

                if (newItem == null) {
                    newItem = defaultLanguageItem;
                }

                newItem = AddLanguageVersionItem(itemName, fieldsToUpdate, template, newItem, master, lang);
            }
            return newItem;
        }

        private Item AddLanguageVersionItem(string itemName, Dictionary<string, string> fieldsToUpdate, TemplateItem template, Item newItem, Sitecore.Data.Database master, string lang) {

            Item newLanguageVersionItem = master.GetItem(newItem.Paths.Path, Sitecore.Globalization.Language.Parse(lang));

            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                try {
                    if (0 == newLanguageVersionItem.Versions.Count) {
                        newLanguageVersionItem.Versions.AddVersion();
                    }

                    newLanguageVersionItem.Editing.BeginEdit();
                    // Assign values to the fields of the new item
                    foreach (var fields in fieldsToUpdate) {
                        newLanguageVersionItem.Fields[fields.Key].Value = fields.Value;
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
                        newItem.Fields[fields.Key].Value = fields.Value;
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

        private Item UpdateItem(string rootItempath, Dictionary<string, string> fieldsToUpdate) {
            Item editItem = GetItem(rootItempath);
            // The SecurityDisabler overrides the current security model, allowing you
            // to access the item without any security. It's like the user being an administrator
            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                // Set the new item in editing mode
                // Fields can only be updated when in editing mode
                // (It's like the begin tarnsaction on a database)
                editItem.Editing.BeginEdit();
                try {
                    // Assign values to the fields of the new item
                    foreach (var fields in fieldsToUpdate) {
                        editItem.Fields[fields.Key].Value = fields.Value;
                    }
                    // End editing will write the new values back to the Sitecore
                    // database (It's like commit transaction of a database)
                    editItem.Editing.EndEdit();
                }
                catch (System.Exception ex) {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + editItem.Paths.FullPath + ": " + ex.Message, this);

                    // Cancel the edit (not really needed, as Sitecore automatically aborts
                    // the transaction on exceptions, but it wont hurt your code)
                    editItem.Editing.CancelEdit();
                }
            }
            return editItem;
        }

        public static string RemoveSpecialCharacters(string str) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                if ((str[i] >= '0' && str[i] <= '9')
                    || (str[i] >= 'A' && str[i] <= 'z'
                        || (str[i] == '_' || str[i] == ' '))) {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }


        private Item[] GetItems(string rootItempath) {
            Item[] itemsToreturn = null;
            Sitecore.Data.Database db = Sitecore.Data.Database.GetDatabase("master");
            Item parentItem = db.GetItem(rootItempath);
            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                itemsToreturn = parentItem.Children.ToArray();
            }
            return itemsToreturn;
        }

        private Item GetItem(string rootItempath) {
            Sitecore.Data.Database db = Sitecore.Data.Database.GetDatabase("master");
            Item parentItem = db.GetItem(rootItempath);
            return parentItem;
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["submit"] != null && Request.QueryString["submit"].ToString() == "ok") {
                this.GetTexonomy();
            }
        }
        string MyConnectionString = "server=localhost;database=testf;Uid=sa;Pwd=simple;";
        private void GetTexonomy() {
            Item postItem = null;
            string posttype = "basic_article_image";
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT wtt.term_taxonomy_id,wtt.taxonomy,wtt.description FROM wp_term_taxonomy wtt " +
                              "INNER JOIN wp_terms wt ON wtt.term_id = wt.term_id " +
                              "WHERE wtt.taxonomy = 'post_translations' AND wtt.count > 0";
            connection.Open();

            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];
           
            foreach (DataRow dr in datasource.Rows) {
               
                string[] getpostsversion = dr["description"].ToString().Replace("a:2:{", "").Replace("}", "").Split(new string[] { "s:2:" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> languagePost = new Dictionary<string, string>();
                foreach (string pair in getpostsversion) {
                    string[] paramvalue = pair.Replace("i:", "").Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries );
                    string langu = paramvalue[0].Replace("\"", "");
                    string postid = paramvalue[1];
                    languagePost.Add(langu, postid);
                }

                string englishVerstion = languagePost["en"];
                if (!string.IsNullOrEmpty(englishVerstion)) {
                    postItem = this.GetPostContent("en", englishVerstion, posttype, false, null);

                    if (postItem != null) {
                        foreach (KeyValuePair<string, string> varkey in languagePost) {
                            if (varkey.Key != "en") {
                                this.GetPostContent(varkey.Key, varkey.Value, posttype, true, postItem);
                            }
                        }
                    }

                }
            }

            connection.Close();
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
               
               // Response.Write(dr["ID"].ToString() + " | " + langu + " | " + dr["post_title"].ToString() + "<br/>");
                page_title = String.IsNullOrEmpty(Convert.ToString(dr["post_content"])) ? string.Empty : Convert.ToString(dr["post_content"]);
                post_alternatename = String.Format("{0}-{1}", String.IsNullOrEmpty(Convert.ToString(dr["post_type"])) ? string.Empty : Convert.ToString(dr["post_type"]), dr["ID"].ToString());
                post_name = String.IsNullOrEmpty(Convert.ToString(dr["post_name"])) ? post_alternatename : Convert.ToString(dr["post_name"]);
                postItem = this.GetPostDetail(dr["ID"].ToString(), langu, post_name, page_title, addVersion, defaultLanguageItem);
                break;
            }

            connection.Close();
            return postItem;
        }

        private Item GetPostDetail(string postid, string lang, string itemname, string page_title, bool addVersion, Item defaultLanguageItem) {
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

            foreach (DataRow varrow in datasource.Rows) {
               
                if (!string.IsNullOrEmpty(itemname)) {
                    switch (varrow["meta_key"].ToString()) {
                        case "wpcf-content-thumbnail":
                            ids.Add("Page Title", varrow["meta_key"].ToString());
                            break;
                        case "wpcf-feature-image":
                           // ids.Add("Page Title", varrow["meta_key"].ToString());
                            break;
                        case "wpcf-primary-categorization":
                            break;
                        case "wpcf-secondary-category":
                            break;
                        case "wpcf-tertiary-categorization":
                            break;
                        case "wpcf-meta-title":
                            break;
                        case "wpcf-meta-keywords":
                            break;
                        case "wpcf-meta-description":
                            break;
                        case "wpcf-article-content":
                            break;
                        case "wpcf-pull-quote-image":
                            break;
                        case "wpcf-pull-quote-by":
                            break;
                        case "wpcf-pull-quote-title":
                            break;
                        case "wpcf-image":
                            break;
                        case "wpcf-reviewed-date":
                            break;
                        case "wpcf-reviewed-by":
                            break;
                        case "wpcf-key-takeaway":
                            break;
                        case "wpcf-at-a-glance":
                            break;
                        case "wpcf-author-byline":
                            break;
                        case "wpcf-author-byline-image":
                            break;
                        case "wpcf-author-biography":
                            break;
                    }
                    //string itemname = varrow["Brand Tags"];
                    //if (string.IsNullOrEmpty(itemname)) {
                    //    itemname = varrow["Page Title"];
                    //}
                    //itemname = RemoveSpecialCharacters(itemname.ToString().Replace("&", "and"));
                    //ids.Add("Page Title", varrow["Page Title"]);
                    //ids.Add("Body Content", varrow["Body Content"]);
                    //ids.Add("Meta Title", varrow["Meta Title"]);
                    //ids.Add("Meta Description", varrow["Meta Description"]);
                    //ids.Add("Meta Keywords", varrow["Meta Keywords"]);
                    //ids.Add("Include In Sitemap", varrow["Include in Sitemap"].ToString() == "Yes" ? "1" : "0");
                    //ids.Add("Robots No Index", varrow["NoIndex "].ToString() == "Yes" ? "1" : "0");
                    //ids.Add("Robots No Follow", varrow["NoFollow "].ToString() == "Yes" ? "1" : "0");

                    //ids.Add("Brand Summary", varrow["Short Description"]);
                    //ids.Add("Short Title", varrow["Short Title"]);



                }

               

            }

            newItem = CreateItem(Article_Folder, Basic_Article_Page, itemname, ids, addVersion, defaultLanguageItem, lang);
            //throw new NotImplementedException();



            //foreach (DataRow dr in datasource.Rows) {
            //Response.Write(dr["meta_key"].ToString() + "|" + dr["meta_value"].ToString() + "<br/>");



         
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");

            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");
            //Response.Write(dr[""].ToString() + "<br/>");

            // }

            connection.Close();
            return newItem;
            //  Response.Write("<br/><br/><br/><br/>");

        }

    }
}