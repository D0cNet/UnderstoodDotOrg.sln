using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

/*
 * 1. Create Item base on Post and add default version item(en).
 * 2. Get language version item and create a new version for different language.
 * 3. If current post has child post then process to create item again.
 */
namespace UnderstoodDotOrg.Web.Presentation.data_import {
    public partial class wpdataimport : System.Web.UI.Page {
        HtmlAgilityPack.HtmlDocument hp = new HtmlAgilityPack.HtmlDocument();
        string MyConnectionString = "server=localhost;database=newdb;Uid=sa;Pwd=simple;Pooling=true;Min Pool Size=25;Max Pool Size=500; convert zero datetime=True";
        // Get the master database
        Sitecore.Data.Database master = Sitecore.Data.Database.GetDatabase("master");

        private string CurrentPostID { get; set; }
        private string ChildPostID { get; set; }
        private string DefaultLanguagePostID { get; set; }
        private string CurrentLanguage { get; set; }
        private string PageTitle { get; set; }
        private string BelongTo { get; set; }
        private string TopicCheckBoxes { get; set; }
        private string OptionCheckBoxName { get; set; }
        private bool HasChildPost { get; set; }
        private string CurrentReportType { get; set; }
        private string ArticleItemName { get; set; }
        // Article Type
        private string PostType { get; set; }
        private string NextPostType { get; set; }

        private string Location_Folder { get; set; }
        // Templates
        private string Template_Import { get; set; }

        const string KnowledgeQuizType = "Test your Knowledge";
        const string AssessmentQuizType = "Assessment Quiz";

        const string AuthorTemplate = "{3F153988-B0C9-4C5D-9234-D9ADC2A3D55A}";
        const string ReviewedByTemplate = "{D7FAD5BB-9D8B-40F0-9FC1-9C242B746BC4}";
        // Tag Templates
        const string ChildIssueTemplate = "{FB6B3A57-321D-4223-9C2E-4549E87A7EF6}";
        const string ChildGradesTemplate = "{8F66C22B-74C3-41C7-9250-78A84B80A114}";
        const string ChildDiagnosesTemplate = "{C037EF93-CAE5-4265-8147-B45684572A93}";
        const string ComplexityLevelsTemplate = "{80406B71-267C-4968-BE6D-C1F3BAF6E223}";
        const string DiagnosedConditionTemplate = "{921D963F-9F71-479A-82D5-520670B4B13C}";
        const string ApplicableInterestsTemplate = "{49DC2843-2B4B-4448-854E-811E73F02360}";
        const string ApplicablePersonalitiesTemplate = "{47A67037-5C69-4E77-8E24-0695638B0B62}";
        const string OtherApplicableEvaluationsTemplate = "{D82CEBBC-DD83-4EBF-8EC1-E46F8DD06713}";

        Dictionary<string, string> QuesAnsfields;

        protected void Page_Load(object sender, EventArgs e) {

            if (Request.QueryString["submit"] != null && !String.IsNullOrEmpty(Request.QueryString["submit"].ToString())) {
                switch (Request.QueryString["submit"].ToString()) {
                    case "1":
                        this.PostType = "basic_article_image";
                        break;
                    case "2":
                        this.PostType = "video";
                        break;
                    case "3":
                        this.PostType = "audio";
                        break;
                    case "4":
                        this.PostType = "slideshow";
                        break;
                    case "5":
                        this.PostType = "deep_dive_article";
                        break;
                    case "6":
                        this.PostType = "infographic";
                        break;
                    case "7":
                        this.PostType = "simple-expertart";
                        break;
                    case "8":
                        this.PostType = "tot_article";
                        break;
                    case "9":
                        this.PostType = "action_style_listing";
                        break;
                    case "10":
                        this.PostType = "toolkit";
                        break;
                    case "11":
                        this.PostType = "checklist";
                        break;
                    case "12":
                        this.PostType = "quiz";
                        break;
                    case "A":
                        this.PostType = "author";
                        this.GetUser();
                        break;
                    case "R":
                        this.PostType = "reviewer";
                        this.GetUser();
                        break;
                }

                this.GetPosts();
            }
        }

        private void GetUser() {
            Item parentItem = SetImportConfiguration();
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            string getPostQuery = "SELECT DISTINCT wp.meta_value  FROM wp_postmeta wp " +
                                  "WHERE wp.meta_key = '" + this.BelongTo + "'";
            connection.Open();
            cmd.CommandText = getPostQuery;
            cmd.CommandTimeout = 99900;

            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            DataTable datasource = ds.Tables[0];

            foreach (DataRow varrow in datasource.Rows) {
                this.PageTitle = varrow["meta_value"].ToString();
                this.CurrentLanguage = "en";

                CreateItem(parentItem);

            }
            cmd.Dispose();
            adap.Dispose();
            ds.Dispose();
        }

        private Item SetImportConfiguration() {
            switch (this.PostType) {
                case "author":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Shared/Base Template/Article/Author";
                    this.Location_Folder = "/sitecore/content/Globals/Content Taxonomies/Article/Authors";
                    this.HasChildPost = false;
                    this.BelongTo = "wpcf-author-byline";
                    break;
                case "reviewer":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Shared/Base Template/Article/Reviewer Bio";
                    this.Location_Folder = "/sitecore/content/Globals/Content Taxonomies/Article/Reviewers";
                    this.HasChildPost = false;
                    this.BelongTo = "wpcf-reviewed-by";
                    break;
                case "basic_article_image":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Basic Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/basic article page";
                    this.HasChildPost = false;
                    break;
                case "video":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Video Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/video";
                    this.HasChildPost = false;
                    break;
                case "audio":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Audio Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/audio";
                    this.HasChildPost = false;
                    break;
                case "infographic":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Infographic Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/infographic";
                    this.HasChildPost = false;
                    break;
                case "slideshow":
                    this.Location_Folder = "/sitecore/content/Home/Test Article/slide show";
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Slideshow Article Page";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_slideshow_id";
                    this.NextPostType = "slideshow-image-rep";
                    break;
                case "slideshow-image-rep":
                    Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Slideshow/Slides Page";
                    this.HasChildPost = false;
                    this.NextPostType = "slideshow";
                    break;
                case "deep_dive_article":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Deep Dive Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/deep dive";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_deep_dive_article_id";
                    this.NextPostType = "deep_dive_article_rp";
                    break;
                case "deep_dive_article_rp":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Deep Dive Article/Deep Dive Section Info Page";
                    this.HasChildPost = false;
                    this.NextPostType = "deep_dive_article";
                    break;
                case "tot_article":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Text Only Tips Article/Text Only Tips Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/text only tips article";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_tot_article_id";
                    this.NextPostType = "NextPostType";
                    break;
                case "tot_repeater":
                    Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Text Only Tips Article/Text Tip Page";
                    this.HasChildPost = false;
                    this.NextPostType = "tot_article";
                    break;
                case "simple-expertart":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Simple Expert Article/Simple Expert Article";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/expert article";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_simple-expertart_id";
                    this.NextPostType = "sea_repeater";
                    break;
                case "sea_repeater":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Simple Expert Article/Simple Expert Add Question Page";
                    this.NextPostType = "simple-expertart";
                    this.HasChildPost = false;

                    break;
                case "action_style_listing":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Action Style List Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/action style";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_action_style_listing_id";
                    this.NextPostType = "action-listing-rep";
                    break;
                case "action-listing-rep":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Action Style List Article/Action Page";
                    this.HasChildPost = false;
                    this.NextPostType = "action_style_listing";
                    break;
                case "toolkit":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Shared/Base Template/Parent/Parent Toolkit Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/toolkit";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_toolkit_id";
                    this.NextPostType = "toolkit-repeater";
                    break;
                case "toolkit-repeater":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Shared/Base Template/Parent/ToolKit List";
                    this.HasChildPost = false;
                    this.NextPostType = "toolkit";
                    break;
                case "checklist":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Checklist Article Page";
                    this.Location_Folder = "/sitecore/content/Home/Test Article/checklist";
                    this.BelongTo = "_wpcf_belongs_checklist_id";
                    this.HasChildPost = true;
                    this.NextPostType = "checklist_repeater";
                    break;
                case "checklist_repeater":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Checklist Article/Header Checkbox";
                    this.HasChildPost = true;
                    this.NextPostType = "topic-checkbox";
                    break;
                case "topic-checkbox":
                    this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Checklist Article/Topic Checkbox";
                    this.HasChildPost = false;
                    this.NextPostType = "checklist";
                    break;
                case "quiz":

                    this.Location_Folder = "/sitecore/content/Home/Test Article/quiz";
                    this.HasChildPost = true;
                    this.BelongTo = "_wpcf_belongs_quiz_id";
                    break;
            }

            return master.GetItem(this.Location_Folder);
        }

        private void GetPosts() {
            DataSet ds = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT WP1.ID AS 'PostID', wp1.post_author, wp1.post_title, wp1.post_content, " +
                                     "wp1.post_status, wp1.post_name, wp1.post_type, wp1.R1.slug AS 'language' FROM wp_posts wp1 " +
                                     "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                     "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                     "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                     "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                     "WHERE wtt1.taxonomy = 'language' AND wp1.post_type='" + this.PostType + "' ) R1 ON R1.ID = wp1.ID " +
                                     "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                     "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                     "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                     "WHERE wtt1.taxonomy = 'post_translations' AND wt1.slug  IN (  " +
                                     "SELECT " +
                                     "DISTINCT R1.slug " +
                                     "FROM wp_posts p " +
                                     "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                     "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                     "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                     "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                     "WHERE wtt1.taxonomy = 'post_translations' ) R1 ON R1.ID = p.ID " +
                                     "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                     "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                     "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                     "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id AND p.post_type = '" + this.PostType + "') " +
                                     "AND R1.slug = 'en'  ORDER BY wp1.ID;");

                //AND wp1.ID=4134
                sb.Append(" SELECT A.ID AS 'PostID', A.post_author, A.post_title, A.post_content, " +
                  "A.post_status, A.post_name, A.post_type, 'en' AS 'language' FROM wp_posts AS A WHERE A.post_type='" + this.PostType + "' AND A.ID NOT IN ( " +
                  "SELECT DISTINCT WP1.ID " +
                  "FROM wp_posts wp1 INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                  "INNER JOIN wp_term_relationships wtr1 " +
                  "ON Wp1.ID = wtr1.object_id " +
                  "INNER JOIN wp_term_taxonomy wtt1 " +
                  "ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                  "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                  "WHERE wtt1.taxonomy = 'language' AND wp1.post_type='" + this.PostType + "') " +
                  "R1 ON R1.ID = wp1.ID INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                  "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                  "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                  "WHERE wtt1.taxonomy = 'post_translations' AND wt1.slug " +
                  "IN (SELECT DISTINCT R1.slug FROM wp_posts p " +
                  "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                  "INNER JOIN wp_term_relationships wtr1 ON  " +
                  "Wp1.ID = wtr1.object_id " +
                  "INNER JOIN wp_term_taxonomy wtt1 " +
                  "ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                  "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                  "WHERE wtt1.taxonomy = 'post_translations' ) R1 ON R1.ID = p.ID " +
                  "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                  "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                  "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                  "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id AND p.post_type = '" + this.PostType + "') " +
                  "AND R1.slug = 'en' ) ORDER BY A.ID; ");
                //AND A.ID=4134
                connection.Open();
                cmd.CommandTimeout = 99999;
                cmd.CommandText = sb.ToString();
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);

                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            if (ds != null && ds.Tables.Count > 0) {
                int i = 0;
                int assessment = 0;
                int knowledge = 0;
                foreach (DataTable dt in ds.Tables) {
                    DataTable datasource = dt;
                    DataTable tops = null;
                    if (datasource.Rows.Count > 0) {
                        tops = datasource.Rows.Cast<System.Data.DataRow>().CopyToDataTable();
                        //tops = datasource.Rows.Cast<System.Data.DataRow>().Take(1).CopyToDataTable();
                    }

                    if (tops != null && tops.Rows.Count > 0) {

						using (new BulkUpdateContext()) {
							foreach (DataRow dr in tops.Rows) {
								i++;
								this.DefaultLanguagePostID = this.CurrentPostID = dr["PostID"].ToString();
								this.CurrentLanguage = dr["language"].ToString();
								this.PageTitle = dr["post_title"].ToString().Trim();
								Item newItem = null;
								if (this.PostType == "quiz") {
									this.CurrentReportType = GetQuizType(this.CurrentPostID);
									if (CurrentReportType == AssessmentQuizType) {
										assessment++;
										this.ArticleItemName = string.Format("Assessment Quiz-{0}", assessment);
										this.Template_Import = "/sitecore/templates/User Defined/Poses/Folders/Assessment Quiz Folder";
										newItem = this.CreateItem(SetImportConfiguration());
									}
									else {
										knowledge++;
										this.ArticleItemName = string.Format("Knowledge Quiz-{0}", knowledge);
										this.Template_Import = "/sitecore/templates/User Defined/Poses/Folders/Knowledge Quiz Folder";
										newItem = this.CreateItem(SetImportConfiguration());
									}
									if (newItem != null) {
										this.AddDifferentLanguageVerstion(newItem);
										if (HasChildPost) {
											this.GetChilds(newItem);
										}
									}
								}
								else {
									newItem = this.CreateItem(SetImportConfiguration());

									if (newItem != null) {
										this.AddDifferentLanguageVerstion(newItem);
										if (HasChildPost) {
											this.GetChilds(newItem);
										}
									}
								}
							}
						}
                    }
                }
                Response.Write(this.PostType + "- Record count: " + i + "<br/>");
            }
            ds.Dispose();

        }

        int itemCount = 0;
        private Item CreateItem(Item parentItem) {
            Item newItem = null;
            // The SecurityDisabler overrides the current security model, allowing you
            // to access the item without any security. It's like the user being an administrator
            using (new Sitecore.SecurityModel.SecurityDisabler()) {

                // Get the template to base the new item on
                TemplateItem template = master.GetItem(Template_Import);

                if (template == null) {
                    Response.Write("Error Message : Template type is invalid");
                    return null;
                }

                if (parentItem == null) {
                    Response.Write("Error Message : Location folder item is invalid");
                    return null;
                }

                // Get the place in the site tree where the new item must be inserted
                Item itm = master.GetItem(parentItem.ID);

                if (itm == null) {
                    Response.Write("Error Message : Location folder item is invalid");
                    return null;
                }

                itemCount++;
                string itemname = string.Empty;
                if (this.PostType == "topic-checkbox") {
                    itemname = this.OptionCheckBoxName;
                }
                else if (this.PostType == "quiz") {
                    itemname = this.ArticleItemName;
                }
                else {
                    itemname = this.PageTitle = string.IsNullOrEmpty(this.PageTitle) ? string.Format("{0}-{1}", this.PostType, this.CurrentPostID) : CleanString(this.PageTitle);
                }
                try {
                    // Add the item to the site tree
                    newItem = itm.Add(ItemUtil.ProposeValidItemName(itemname), template);

                    if (newItem == null) {
                        Response.Write("Error Message : New item could not be created.");
                        return null;
                    }

                    this.AddItemVerstion(newItem);
                }
                catch (System.Exception ex) {
                    // The update failed, write a message to the log
                    Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.ToString(), this);

                    Response.Write(newItem.Paths.FullPath);
                    Response.Write(ex.Message);
                }
            }

            return newItem;
        }

        String CleanString(string line) {
            if ((!String.IsNullOrEmpty(line)) && (line.Length > 0)) {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(line.Length);
                foreach (char c in line) {
                    if (char.IsSymbol(c)) continue;

                    sb.Append(char.IsControl(c) ? ' ' : c);
                }
                String newLine = sb.ToString().Trim();//.Substring(2).Trim();
                return newLine;
            }
            else
                return String.Empty;
        }

        private void GetChilds(Item newItem) {
            DataSet ds = new DataSet();
            Dictionary<string, string> fields = new Dictionary<string, string>();

            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                string getPostQuery = string.Empty;

                getPostQuery = "SELECT wp1.post_id as 'PostID', wp.post_type " +
                                       "FROM wp_posts wp " +
                                       "INNER JOIN wp_postmeta wp1 ON wp.ID = wp1.post_id " +
                                       "WHERE wp1.meta_key = '" + this.BelongTo + "' AND wp1.meta_value = '" + this.DefaultLanguagePostID + "' ";

                connection.Open();
                cmd.CommandTimeout = 99999;

                cmd.CommandText = getPostQuery;
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];
                if (this.PostType == "quiz") {
                    CreateQuestionAnswer(datasource, newItem);
                }
                else {
                    if (datasource != null && datasource.Rows.Count > 0) {
                        foreach (DataRow dr in datasource.Rows) {
                            this.PostType = dr["post_type"].ToString();
                            SetImportConfiguration();
                            this.ChildPostID = dr["PostID"].ToString();
                            AddChilds(newItem);
                        }
                    }
                    this.PostType = this.NextPostType;

                }
            }
            ds.Dispose();

        }

        private void CreateQuestionAnswer(DataTable datasource, Item parentItem) {
            var resultques = datasource.AsEnumerable().Where(t => t.Field<string>("post_type") == "quiz-question-repeat").ToList();
            var resultans = datasource.AsEnumerable().Where(t => t.Field<string>("post_type") == "quiz-answ-repeat").ToList();
            int i = 0;
            Item quizArticleFolder = null;
            bool isArticle1Added = false;
            bool isArticle2Added = false;
            bool isArticleEndAdded = false;
            int quesIndex = 0;
            foreach (DataRow drRow in resultques) {
                quesIndex++;
                if (CurrentReportType == AssessmentQuizType) {
                    i++;

                    if (i <= resultques.Count / 2) {
                        if (!isArticle1Added) {
                            this.ArticleItemName = "Assessment Quiz Article Page 1";
                            this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Assessment Quiz Article Page 1";
                            quizArticleFolder = this.CreateItem(parentItem);
                            this.AddDifferentLanguageVerstion(quizArticleFolder);
                        }
                        isArticle1Added = true;
                    }
                    else {
                        if (!isArticle2Added) {
                            this.ArticleItemName = "Assessment Quiz Article Page 2";
                            this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Assessment Quiz Article Page 2";
                            quizArticleFolder = this.CreateItem(parentItem);
                            this.AddDifferentLanguageVerstion(quizArticleFolder);
                        }
                        isArticle2Added = true;
                    }
                }
                else {
                    if (!isArticle1Added) {
                        this.ArticleItemName = "Knowledge Quiz Article Page 1";
                        this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Knowledge Quiz Question Article Page";
                        quizArticleFolder = this.CreateItem(parentItem);
                        this.AddDifferentLanguageVerstion(quizArticleFolder);
                    }
                    isArticle1Added = true;
                }
                this.ArticleItemName = string.Format("Question-{0}", quesIndex);
                this.AddQuestion(quizArticleFolder, drRow["PostID"].ToString());
            }
            isArticle1Added = false;
            int resultCount = 0;
            foreach (DataRow drRow in resultans) {
                resultCount++;
                if (!isArticleEndAdded) {
                    if (CurrentReportType == AssessmentQuizType) {
                        this.ArticleItemName = string.Format("Assessment Quiz Article Page End");
                        this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Assessment Quiz Article Page End";
                    }
                    else {
                        this.ArticleItemName = "Knowledge Quiz Result Article Page";
                        this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Knowledge Quiz Results Article Page";
                    }
                    quizArticleFolder = this.CreateItem(parentItem);
                    this.AddDifferentLanguageVerstion(parentItem);
                }
                isArticleEndAdded = true;
                if (CurrentReportType == AssessmentQuizType) {
                    this.ArticleItemName = string.Format("Assessment Quiz Result-{0}", resultCount);
                }
                else {
                    this.ArticleItemName = string.Format("Knowledge Quiz Result-{0}", resultCount);
                }
                this.AddResult(quizArticleFolder, drRow["PostID"].ToString());
            }
        }

        private void AddQuestion(Item ParentRootItem, string postId) {
            this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Base for Quiz/Quiz Question";
            Item questionItem = this.CreateItem(ParentRootItem);
            this.AddDifferentLanguageVerstion(questionItem);

            DataSet ds = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT wp1.post_id, wp1.meta_key, wp1.meta_value " +
                            "FROM wp_posts wp " +
                            "INNER JOIN wp_postmeta wp1 ON wp.ID = wp1.post_id " +
                            "WHERE wp.ID = " + postId);
                cmd.CommandText = sb.ToString();
                connection.Open();
                MySqlDataAdapter adap;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];

                this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Base for Quiz/Quiz Answers";
                //QuesAnsfields
                QuesAnsfields = new Dictionary<string, string>();
                Dictionary<string, string> Quesfields = new Dictionary<string, string>();
                Dictionary<string, string> Ansfields1 = new Dictionary<string, string>();
                Dictionary<string, string> Ansfields2 = new Dictionary<string, string>();
                Dictionary<string, string> Ansfields3 = new Dictionary<string, string>();
                Dictionary<string, string> Ansfields4 = new Dictionary<string, string>();
                Dictionary<string, string> Ansfields5 = new Dictionary<string, string>();
                foreach (DataRow varrow in datasource.Rows) {
                    switch (varrow["meta_key"].ToString()) {
                        case "wpcf-question-field-type":
                            Quesfields.Add("Question Type", varrow["meta_value"].ToString());
                            break;

                        case "wpcf-points-for-this-answer-option-1":
                            Ansfields1.Add("Score", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-correct-answer-option-1":
                            Ansfields1.Add("True Answer", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-incorrect-answer-option-1":
                            Ansfields1.Add("False Answer", varrow["meta_value"].ToString());
                            break;

                        case "wpcf-points-for-this-answer-option-2":
                            Ansfields2.Add("Score", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-correct-answer-option-2":
                            Ansfields2.Add("True Answer", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-incorrect-answer-option-2":
                            Ansfields2.Add("False Answer", varrow["meta_value"].ToString());
                            break;

                        case "wpcf-points-for-this-answer-option-3":
                            Ansfields3.Add("Score", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-correct-answer-option-3":
                            Ansfields3.Add("True Answer", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-incorrect-answer-option-3":
                            Ansfields3.Add("False Answer", varrow["meta_value"].ToString());
                            break;

                        case "wpcf-points-for-this-answer-option-4":
                            Ansfields4.Add("Score", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-correct-answer-option-4":
                            Ansfields4.Add("True Answer", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-incorrect-answer-option-4":
                            Ansfields4.Add("False Answer", varrow["meta_value"].ToString());
                            break;

                        case "wpcf-points-for-this-answer-option-5":
                            Ansfields5.Add("Score", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-correct-answer-option-5":
                            Ansfields5.Add("True Answer", varrow["meta_value"].ToString());
                            break;
                        case "wpcf-message-with-incorrect-answer-option-5":
                            Ansfields5.Add("False Answer", varrow["meta_value"].ToString());
                            break;
                    }
                }

                foreach (DataRow varrow in datasource.Rows) {
                    switch (varrow["meta_key"].ToString()) {

                        //wpcf-question-field-type
                        //wpcf-is-correct-option
                        //wpcf-question-image

                        //break;
                        case "wpcf-answer-text-option-1":
                            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {
                                this.ArticleItemName = "Answer-1";
                                Item ans1 = this.CreateItem(questionItem);
                                this.AddDifferentLanguageVerstion(ans1);
                            }
                            break;
                        //wpcf-points-for-this-answer-option-1
                        //wpcf-message-with-correct-answer-option-1
                        //wpcf-message-with-incorrect-answer-option-1
                        case "wpcf-answer-text-option-2":
                            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {
                                this.ArticleItemName = "Answer-2";
                                Item ans2 = this.CreateItem(questionItem);
                                this.AddDifferentLanguageVerstion(ans2);
                            }
                            break;
                        //wpcf-points-for-this-answer-option-2
                        //wpcf-message-with-correct-answer-option-2
                        //wpcf-message-with-incorrect-answer-option-2
                        case "wpcf-answer-text-option-3":
                            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {
                                this.ArticleItemName = "Answer-3";
                                Item ans3 = this.CreateItem(questionItem);
                                this.AddDifferentLanguageVerstion(ans3);
                            }
                            break;
                        //wpcf-message-with-correct-answer-option-3
                        //wpcf-message-with-incorrect-answer-option-3
                        //wpcf-points-for-this-answer-option-3
                        case "wpcf-answer-text-option-4":
                            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {
                                this.ArticleItemName = "Answer-4";
                                Item ans4 = this.CreateItem(questionItem);
                                this.AddDifferentLanguageVerstion(ans4);
                            }
                            break;
                        //wpcf-points-for-this-answer-option-4
                        //wpcf-message-with-correct-answer-option-4
                        //wpcf-message-with-incorrect-answer-option-4
                        case "wpcf-answer-text-option-5":
                            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {
                                this.ArticleItemName = "Answer-5";
                                Item ans5 = this.CreateItem(questionItem);
                                this.AddDifferentLanguageVerstion(ans5);
                            }
                            break;
                        //wpcf-points-for-this-answer-option-5
                        //wpcf-message-with-correct-answer-option-5
                        //wpcf-message-with-incorrect-answer-option-5
                    }
                }
            }
            ds.Dispose();

        }

        private void AddResult(Item ParentRootItem, string postid) {

            this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Base for Quiz/Quiz Result";

            Item nItem = this.CreateItem(ParentRootItem);
            this.AddDifferentLanguageVerstion(nItem);
        }

        private string GetQuizType(string postID) {
            DataSet ds = new DataSet();
            string quizType = string.Empty;
            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT wp1.post_id, wp1.meta_key, wp1.meta_value " +
                            "FROM wp_posts wp " +
                            "INNER JOIN wp_postmeta wp1 ON wp.ID = wp1.post_id " +
                            "WHERE wp.ID IN (" + postID + ") AND wp1.meta_key ='wpcf-quiz-type'");
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 99990;

                connection.Open();
                MySqlDataAdapter adap;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];

                foreach (DataRow varrow in datasource.Rows) {
                    quizType = varrow["meta_value"].ToString();

                }
            }
            ds.Dispose();

            return quizType;
        }


        private void AddChilds(Item newItem) {
            DataSet ds = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT WP1.ID AS 'PostID', wp1.post_author, wp1.post_title, wp1.post_content, " +
                                   "wp1.post_status, wp1.post_name, wp1.post_type, wp1.R1.slug AS 'language' FROM wp_posts wp1 " +
                                   "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                   "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                   "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                   "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                   "WHERE wtt1.taxonomy = 'language' AND wp1.post_type='" + this.PostType + "'  ) R1 ON R1.ID = wp1.ID " +
                                   "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                   "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                   "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                   "WHERE wtt1.taxonomy = 'post_translations' AND wt1.slug  IN (  " +
                                   "SELECT " +
                                   "DISTINCT R1.slug " +
                                   "FROM wp_posts p " +
                                   "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                   "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                   "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                   "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                   "WHERE wtt1.taxonomy = 'post_translations' ) R1 ON R1.ID = p.ID " +
                                   "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                   "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                   "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                   "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id AND p.ID =" + ChildPostID + " And p.post_type = '" + this.PostType + "') " +
                                   "AND wp1.ID =" + ChildPostID + " AND R1.slug = 'en' " +
                                   "ORDER BY wp1.ID;");
                sb.Append(" SELECT A.ID AS 'PostID', A.post_author, A.post_title, A.post_content, " +
                                    "A.post_status, A.post_name, A.post_type, 'en' AS 'language' FROM wp_posts AS A WHERE A.post_type='" + this.PostType + "' AND A.ID NOT IN ( " +
                                    "SELECT DISTINCT WP1.ID AS 'PostID' " +
                                    "FROM wp_posts wp1 " +
                                    "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'language' AND wp1.post_type='" + this.PostType + "'  ) R1 ON R1.ID = wp1.ID " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'post_translations' AND wt1.slug  IN (  " +
                                    "SELECT " +
                                    "DISTINCT R1.slug " +
                                    "FROM wp_posts p " +
                                    "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'post_translations' ) R1 ON R1.ID = p.ID " +
                                    "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                    "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id AND p.ID =" + ChildPostID + " And p.post_type = '" + this.PostType + "') " +
                                    "AND R1.slug = 'en') AND A.ID = " + ChildPostID + " ORDER BY A.ID;");
               
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 99900;

                connection.Open();
                MySqlDataAdapter adap;
                adap = new MySqlDataAdapter(cmd);
                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            if (ds != null && ds.Tables.Count > 0) {
                foreach (DataTable dt in ds.Tables) {
                    DataTable datasource = dt;

                    foreach (DataRow dr in datasource.Rows) {
                        this.DefaultLanguagePostID = this.CurrentPostID = dr["PostID"].ToString();
                        this.CurrentLanguage = dr["language"].ToString();
                        this.PageTitle = dr["post_title"].ToString().Trim();

                        Item newChildItem = this.CreateItem(newItem);
                        this.AddDifferentLanguageVerstion(newChildItem);
                        if (this.PostType == "checklist_repeater") {
                            this.CreateTopicCheckBoxItem(newChildItem);
                        }
                    }
                }
            }
            ds.Dispose();

        }

        private void CreateTopicCheckBoxItem(Item currentItem) {
            if (!string.IsNullOrEmpty(this.TopicCheckBoxes)) {
                hp.LoadHtml(this.TopicCheckBoxes);
                HtmlNodeCollection nodes = hp.DocumentNode.SelectNodes("//li");
                if (nodes != null && nodes.Count > 0) {
                    int i = 0;
                    foreach (var item in nodes) {
                        i++;
                        this.PostType = "topic-checkbox";
                        this.PageTitle = item.InnerText;
                        this.OptionCheckBoxName = "Topic Option " + i;
                        // this.Template_Import = "/sitecore/templates/User Defined/Poses/Pages/Article Pages/Checklist Article/Topic Checkbox";
                        // this.HasChildPost = false;
                        SetImportConfiguration();
                        this.CreateItem(currentItem);
                    }
                }
            }
        }

        private void AddItemVerstion(Item newItem) {
            Dictionary<string, string> fieldsToUpdate = FillContent();

            Item contentItem = master.GetItem(newItem.Paths.Path, Sitecore.Globalization.Language.Parse(this.CurrentLanguage));

            using (new Sitecore.SecurityModel.SecurityDisabler()) {
                string field = string.Empty;
                try {
                    if (0 == contentItem.Versions.Count) {
                        contentItem.Versions.AddVersion();
                    }

                    contentItem.Editing.BeginEdit();

                    // Assign values to the fields of the new item
                    foreach (var fields in fieldsToUpdate) {

                        if (fields.Key == "Page Title") {
							Response.Write("SC Item: " + contentItem.Paths.Path + " | " + fields.Key + "=>" + this.CurrentPostID + " | " + this.CurrentLanguage + " | <b>" + fields.Value + "</b><br/>");
                        }
                        field = fields.Key;
                        string tagids = string.Empty;
                        Item tagItem = null;
                        MediaItem mediaItem = null;
                        switch (fields.Key) {
                            case "Video File":
                                break;
                            case "Audio File":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    mediaItem = DownloadImage(fields.Value);
                                    if (mediaItem != null) {
                                        Sitecore.Data.Fields.FileField file = contentItem.Fields[fields.Key];
                                        file.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                                        file.MediaID = mediaItem.ID;
                                    }
                                }
                                break;
                            case "Image":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    mediaItem = DownloadImage(fields.Value);
                                    if (mediaItem != null) {
                                        Sitecore.Data.Fields.ImageField image = contentItem.Fields[fields.Key];
                                        image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                                        image.Alt = mediaItem.Alt;
                                        image.MediaID = mediaItem.ID;
                                    }
                                }
                                break;
                            case "Slide Image":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    mediaItem = DownloadImage(fields.Value);
                                    if (mediaItem != null) {
                                        Sitecore.Data.Fields.ImageField image = contentItem.Fields[fields.Key];
                                        image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                                        image.Alt = mediaItem.Alt;
                                        image.MediaID = mediaItem.ID;
                                    }
                                }
                                break;
                            case "Content Thumbnail":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    mediaItem = DownloadImage(fields.Value);
                                    if (mediaItem != null) {
                                        Sitecore.Data.Fields.ImageField image = contentItem.Fields[fields.Key];
                                        image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                                        image.Alt = mediaItem.Alt;
                                        image.MediaID = mediaItem.ID;
                                    }
                                }
                                break;
                            case "Feature Image":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    mediaItem = DownloadImage(fields.Value);
                                    if (mediaItem != null) {
                                        Sitecore.Data.Fields.ImageField image = contentItem.Fields[fields.Key];
                                        image.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                                        image.Alt = mediaItem.Alt;
                                        image.MediaID = mediaItem.ID;
                                    }
                                }
                                break;
                            case "Reviewed Date":
                                if (!string.IsNullOrEmpty(fields.Value)) {
                                    double timespan = System.Convert.ToDouble(fields.Value);
                                    contentItem[fields.Key] = String.Format("{0:yyyyMMddTHHmmss}", new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timespan));
                                }
                                break;
                            case "Author Name":
                                tagItem = GetTagItem(fields.Value, AuthorTemplate, "Author Name");
                                if (tagItem != null) {
                                    contentItem[fields.Key] = tagItem.ID.ToString();
                                }
                                break;
                            case "Reviewed by":
                                tagItem = GetTagItem(fields.Value, ReviewedByTemplate, "Revierwer Name");
                                if (tagItem != null) {
                                    contentItem[fields.Key] = tagItem.ID.ToString();
                                }
                                break;
                            case "Child Issues":
                                tagids = GetTags("child-issue", ChildIssueTemplate, "Issue Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Child Grades":
                                tagids = GetTags("grade_level", ChildGradesTemplate, "Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Child Diagnoses":
                                tagids = GetTags("child-diagnosis", ChildDiagnosesTemplate, "Diagnosis Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Complexity Levels":
                                tagids = GetTags("content-complexity", ComplexityLevelsTemplate, "Complexity Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Diagnosed Condition":
                                tagids = GetTags("diagnosed-undiagnosed", DiagnosedConditionTemplate, "Diagnosis Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Applicable Interests":
                                tagids = GetTags("parent-interests", ApplicableInterestsTemplate, "Applicable Interests");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Applicable Personalities":
                                tagids = GetTags("personality-type", ApplicablePersonalitiesTemplate, "Personality Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            case "Other Applicable Evaluations":
                                tagids = GetTags("other-evaluations", OtherApplicableEvaluationsTemplate, "Evaluation Name");
                                if (!string.IsNullOrEmpty(tagids)) {
                                    contentItem[fields.Key] = tagids;
                                }
                                break;
                            default:
                                contentItem.Fields[fields.Key].Value = fields.Value;
                                break;
                        }

                    }
                    contentItem.Editing.EndEdit();
                    contentItem.Editing.AcceptChanges();
                }
                catch (Exception ex) {
                    contentItem.Editing.CancelEdit();
                    Response.Write("<span style='color:red;'><b>Error on this field: (" + field + ") </b>" + ex.ToString() + "</span><br/>");
                }
            }
        }

        private string GetTags(string tagType, string templateId, string fieldName) {
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                string getPostQuery = "SELECT wt.slug,wt.name, wtt.taxonomy, wtt.term_id, wtt.term_taxonomy_id, wtr.object_id " +
                 "FROM wp_posts p " +
                 "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                 "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                 "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id " +
                 "WHERE p.post_type = '" + this.PostType + "' AND wtt.taxonomy = '" + tagType + "'  " +
                 "AND wtr.object_id IN (" + this.CurrentPostID + ") " +
                 "ORDER BY wtr.object_id";
                connection.Open();
                cmd.CommandText = getPostQuery;
                cmd.CommandTimeout = 99900;

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);

                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }

            String tagIds = String.Empty;
            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];

                foreach (DataRow varrow in datasource.Rows) {
                    Item child = GetTagItem(varrow["name"].ToString(), templateId, fieldName);

                    if (child != null) {
                        tagIds = tagIds + "|" + child.ID.ToString();
                    }
                }

                if (tagIds.Length > 0) {
                    tagIds = tagIds.Substring(1);
                }
            }
            ds.Dispose();

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
                    searchItem = searchResultItems.Where(t => t.Fields[field].Value == RemoveSpecialCharacters(keyword)).FirstOrDefault();
                }
            }
            return searchItem;
        }

        public static string RemoveSpecialCharacters(string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str) {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_') {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private MediaItem DownloadImage(string img) {
            MediaItem mediaItem = null;
            if (string.IsNullOrEmpty(img))
                return null;

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
            mediaItem = AddFile(saveLocation, ItemUtil.ProposeValidItemName(filename.Split(new char[] { '.' })[0]));

            return mediaItem;
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
            options.Database = master;

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

        private Dictionary<string, string> FillContent() {
            DataSet ds = new DataSet();
            Dictionary<string, string> fields = new Dictionary<string, string>();

            fields.Add("Page Title", CleanString(this.PageTitle));
            fields.Add("Post", this.CurrentPostID);

            if (this.PostType == "topic-checkbox") {
                fields.Add("Topic Title", this.PageTitle);
                fields.Add("Show Checkbox", "1");
            }
            else if (this.PostType == "author") {
                fields.Add("Author Name", this.PageTitle);
            }
            else if (this.PostType == "reviewer") {
                fields.Add("Revierwer Name", this.PageTitle);
            }
            else {
                fields = GetPostContents(ds, fields);
            }
            ds.Dispose();
            return fields;
        }

        private Dictionary<string, string> GetPostContents(DataSet ds, Dictionary<string, string> fields) {
            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                string getPostQuery = "SELECT pm.*, t.slug " +
                                      "FROM wp_posts p " +
                                      "INNER JOIN wp_postmeta pm ON p.ID = pm.post_id " +
                                      "INNER JOIN wp_term_relationships tr ON p.ID = tr.object_id " +
                                      "INNER JOIN wp_term_taxonomy tt ON tr.term_taxonomy_id = tt.term_taxonomy_id " +
                                      "INNER JOIN wp_terms t ON tt.term_id = t.term_id " +
                                      "WHERE p.ID =" + this.CurrentPostID + " AND t.slug ='" + this.CurrentLanguage + "'";
                connection.Open();
                cmd.CommandText = getPostQuery;
                cmd.CommandTimeout = 99900;

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);

                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }
            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];
                //fields.Add("Page Title", CleanString(this.PageTitle));
                //fields.Add("Post", this.CurrentPostID);

                foreach (DataRow varrow in datasource.Rows) {
                    if (varrow["meta_key"].ToString() == "wpcf-checklists-text") {
                        this.TopicCheckBoxes = varrow["meta_value"].ToString();
                    }
                    //  Response.Write(varrow["meta_key"].ToString() + "-" + varrow["meta_value"].ToString() + "<br/>");

                    ContentMapping(ref fields, varrow);
                }

                fields.Add("Child Issues", "");
                fields.Add("Child Grades", "");
                fields.Add("Child Diagnoses", "");
                fields.Add("Complexity Levels", "");
                fields.Add("Diagnosed Condition", "");
                fields.Add("Applicable Interests", "");
                fields.Add("Applicable Personalities", "");
                fields.Add("Other Applicable Evaluations", "");
            }

            ds.Dispose();
            return fields;
        }

        private void ContentMapping(ref Dictionary<string, string> fields, DataRow varrow) {
            if (!string.IsNullOrEmpty(varrow["meta_value"].ToString())) {

                #region map key with sitecore
                switch (varrow["meta_key"].ToString()) {
                    case "wpcf-content-thumbnail":
                        fields.Add("Content Thumbnail", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-feature-image":
                        fields.Add("Feature Image", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-meta-title":
                        fields.Add("Meta Title", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-meta-keywords":
                        fields.Add("Meta Keywords", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-meta-description":
                        fields.Add("Meta Description", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-article-content":
                        fields.Add("Body Content", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-at-a-glance":
                        fields.Add("At-a-glance Content", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-key-takeaway":
                        if (this.PostType == "deep_dive_article") {
                            fields.Add("Key Take away Details", varrow["meta_value"].ToString());
                        }
                        else {
                            fields.Add("Key Takeaway Data", varrow["meta_value"].ToString());
                        }
                        break;
                    case "wpcf-reviewed-date":
                        fields.Add("Reviewed Date", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-author-byline":
                        fields.Add("Author Name", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-reviewed-by":
                        fields.Add("Reviewed by", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-article-intro":
                        if (this.PostType != "basic_article_image") {
                            fields.Add("Body Content", varrow["meta_value"].ToString());
                        }
                        break;
                    case "wpcf-transcript-text":
                        fields.Add("Transcript", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-video-link":
                        fields.Add("Video File", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-audio":
                        fields.Add("Audio File", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-audio-intro":
                        fields.Add("Intro Text", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-audio-quote":
                        fields.Add("Quote", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-image-captions":
                        fields.Add("Slide Text", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-slideshow-image":
                        fields.Add("Slide Image", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-section-content":
                        fields.Add("Content", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-image":
                        fields.Add("Image", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-infographics-summary":
                        fields.Add("Intro Text", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-question-answer":
                        fields.Add("Question", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-tip-content":
                        fields.Add("Tip text", varrow["meta_value"].ToString());
                        break;
                    case "wpcf-action-step-content":
                        fields.Add("Introduction", varrow["meta_value"].ToString());
                        break;
                }
                #endregion
            }
        }

        private void AddDifferentLanguageVerstion(Item newItem) {
            DataSet ds = new DataSet();
            Dictionary<string, string> fields = new Dictionary<string, string>();

            using (MySqlConnection connection = new MySqlConnection(MyConnectionString)) {
                MySqlCommand cmd = connection.CreateCommand();
                string getPostQuery = "SELECT WP1.ID, wp1.post_author, wp1.post_title, wp1.post_content, wp1.post_status, wp1.post_name, wp1.post_type, R1.slug AS 'language' FROM wp_posts wp1 " +
                                    "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'language' AND wp1.post_type='" + this.PostType + "' ) R1 ON R1.ID = wp1.ID " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'post_translations' AND wt1.slug  IN (  " +
                                    "SELECT " +
                                    "DISTINCT R1.slug " +
                                    "FROM wp_posts p " +
                                    "INNER JOIN (SELECT WP1.ID, wt1.slug FROM wp_posts wp1 " +
                                    "INNER JOIN wp_term_relationships wtr1 ON Wp1.ID = wtr1.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt1 ON wtr1.term_taxonomy_id = wtt1.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt1 ON wt1.term_id = wtt1.term_id " +
                                    "WHERE wtt1.taxonomy = 'post_translations' ) R1 ON R1.ID = p.ID " +
                                    "INNER JOIN wp_postmeta wp ON p.ID = wp.post_id " +
                                    "INNER JOIN wp_term_relationships wtr ON p.ID = wtr.object_id " +
                                    "INNER JOIN wp_term_taxonomy wtt ON wtr.term_taxonomy_id = wtt.term_taxonomy_id " +
                                    "INNER JOIN wp_terms wt ON wt.term_id = wtt.term_id AND p.post_type = '" + this.PostType + "' AND " +
                                    "p.ID = " + DefaultLanguagePostID + ") " +
                                    "AND R1.slug  <> 'en' AND  wp1.post_type = '" + this.PostType + "'" +
                                    "ORDER BY wp1.ID";
                connection.Open();
                cmd.CommandText = getPostQuery;
                cmd.CommandTimeout = 99900;

                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);

                adap.Fill(ds);
                cmd.Dispose();
                adap.Dispose();
                connection.Close();
            }
            if (ds != null && ds.Tables.Count > 0) {
                DataTable datasource = ds.Tables[0];

                foreach (DataRow dr in datasource.Rows) {
                    this.CurrentPostID = dr["ID"].ToString();
                    this.CurrentLanguage = dr["language"].ToString();
                    this.PageTitle = dr["post_title"].ToString();
                    this.AddItemVerstion(newItem);
                }
            }
            ds.Dispose();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Response.Redirect("http://" + Request.Url.Host + "/presentation/data-import/wpdataimport.aspx?submit=" + rblArticleType.SelectedValue);
        }
    }
}