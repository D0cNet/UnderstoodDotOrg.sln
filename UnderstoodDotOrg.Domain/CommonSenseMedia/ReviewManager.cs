using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Importer;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia
{
    /// <summary>
    /// Class to add new Assistive Tool reviews to Sitecore
    /// </summary>
    public class ReviewManager
    {
        /// <summary>
        /// Want to add a new review? Fill an instance of ReviewModel, and put it here
        /// </summary>
        /// <param name="Review">New review to add to Sitecore</param>
        /// <returns>Sitecore Item that was added</returns>
        public Sitecore.Data.Items.Item Add(ReviewModel Review)
        {
            using (new SecurityDisabler())
            {
                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase(CommonSenseImportHelper.Settings.MasterDatabaseName);
                Sitecore.Data.Items.Item reviews = master.GetItem(CommonSenseImportHelper.Settings.ReviewsContainer);
                Sitecore.Data.Items.TemplateItem reviewTemplate = master.Templates[CommonSenseImportHelper.Settings.ReviewTemplate];
                Sitecore.Data.Items.Item newReview = reviews.Add(Review.Title, reviewTemplate);

                newReview.Editing.BeginEdit();

                // Single-line text
                newReview["title"] = Review.Title;

                // Multi-line text
                newReview["what kids can learn"] = Review.WhatKidsCanLearn;
                newReview["any good"] = Review.AnyGood;
                newReview["how parents can help"] = Review.HowParentsCanHelp;
                newReview["description"] = Review.Description;
                newReview["summary"] = Review.Summary;

                // External Link
                newReview["external link"] = Review.ExternalLink;

                // Numbers
                newReview["quality"] = Review.QualityRank;
                newReview["learning"] = Review.LearningRank;
                newReview["target grade"] = Review.TargetGrade;
                newReview["off grade"] = Review.OffGrade;
                newReview["on grade"] = Review.OnGrade;

                // Related to other items
                //csv of names of related items, then pointer to mapping
                newReview["genre"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Genres, CommonSenseImportHelper.Instance.Genre);
                newReview["subjects"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Subjects, CommonSenseImportHelper.Instance.Subject);
                newReview["skills"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Skills, CommonSenseImportHelper.Instance.Skill);
                newReview["categories"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Categories, CommonSenseImportHelper.Instance.Category);
                newReview["platforms"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Platforms, CommonSenseImportHelper.Instance.Platform);
                newReview["type"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Type, CommonSenseImportHelper.Instance.Type);

                // Related to Media
                //URL to image file, name to use. If no alt text is supplied, re-uses the name               
                newReview["screenshots"] = CommonSenseImportHelper.addMedia(Review.Screenshots);
                newReview["thumbnail image"] = CommonSenseImportHelper.addMedia(Review.Thumbnail);

                newReview.Editing.EndEdit();

                return newReview;
            }
        }
    }
}
