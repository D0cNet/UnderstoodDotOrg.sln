using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.AssistiveTools;
using UnderstoodDotOrg.Domain.Importer;
using Sitecore.Security.Accounts;
using System.Net;
using System.IO;
using Sitecore.SecurityModel;
using UnderstoodDotOrg.Domain.CommonSenseMedia;


namespace UnderstoodDotOrg.Web
{
    public partial class test : System.Web.UI.Page
    {
        //protected string MasterDatabaseName = "master";
        //protected string WebDatabaseName = "web";
        //protected string ReviewsContentGUID = "{03877E4C-8EDD-42CE-B94A-E27621C16745}";
        //protected string ReviewsTemplateGUID = "{C9DFC576-7750-4A84-9A79-61F16585E64E}";
        protected string imageURL = "http://cdn2-d71.ec.commonsensemedia.org/sites/default/files/styles/api_product_large/public/product-images/csm-website/funology.jpg?itok=JRaQLPwQ";

        protected void Page_Load(object sender, EventArgs e)
        {
            var review = new ReviewModel();

            review.Title = "Pokemon Z";
            review.Description = "super awesome kawaii!!";
            review.Subjects = "one line summary!";
            review.WhatKidsCanLearn = "A whole bunch of awesome stuff";
            review.AnyGood = "totes";
            review.HowParentsCanHelp = "just buy the thing!";
            review.ExternalLink = "http://wwww.nintendo.com";
            review.QualityRank = "5";
            review.LearningRank = "5";
            review.TargetGrade = "11";
            review.OnGrade = "3";
            review.OffGrade = "12";

            review.Genres = "Action,Adventure";
            review.Type = "Games";
            review.Subjects = "";

            ReviewManager reviewManager = new ReviewManager();

            Response.Write(reviewManager.Add(review).ID.ToString());

                // Related to other items
                //csv of names of related items, then pointer to mapping
                //newReview["genre"] = CommonSenseImportHelper.Instance.getRelatedIds("Action,Racing", CommonSenseImportHelper.Instance.Genre);
                //newReview["subjects"] = CommonSenseImporter.Subjects.Arts;
                //newReview["skills"] = CommonSenseImporter.Skills.Communication;
                //newReview["categories"] = CommonSenseImporter.Categories.Math;
                //newReview["platforms"] = CommonSenseImporter.Platforms.Android;
                //newReview["type"] = CommonSenseImporter.Types.Games;

                // Related to Media
                //URL to image file, name to use. If no alt text is supplied, re-uses the name
                //newReview["screenshots"] = CommonSenseImportHelper.addMedia(imageURL, "screenshot123.jpg");
                //newReview["thumbnail image"] = 

                // Publish
                //Sitecore.Data.Database[] target = { CommonSenseImportHelper.Settings.WebDatabaseName };
                //Sitecore.Globalization.Language[] languages = master.Languages;
                //bool deep = false;
                //bool compareRevisions = true;

                //Sitecore.Publishing.PublishManager.PublishItem(newReview, target, languages, deep, compareRevisions);
            
        }
    }
}