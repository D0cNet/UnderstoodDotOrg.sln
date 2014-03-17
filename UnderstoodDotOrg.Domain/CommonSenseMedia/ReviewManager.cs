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
                Sitecore.Data.Items.TemplateItem reviewTemplate = master.Templates[CommonSenseImportHelper.Settings.ReviewTemplate];
                Sitecore.Data.Items.Item newReview = Get(CommonSenseImportHelper.Settings.ReviewsContainer).Add(Review.Title, reviewTemplate);

                newReview.Editing.BeginEdit();

                newReview = Map(newReview, Review);

                newReview.Editing.EndEdit();

                return newReview;
            }
        }

        /// <summary>
        /// Returns the desired Review
        /// </summary>
        /// <param name="GUID">Review to return</param>
        /// <returns>Desired Review</returns>
        public Sitecore.Data.Items.Item Get(string GUID)
        {
            Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase(CommonSenseImportHelper.Settings.MasterDatabaseName);
            return master.GetItem(GUID);
        }

        /// <summary>
        /// Updates the desired Review
        /// </summary>
        /// <param name="Review">ReviewModel instance to update</param>
        /// <returns>Updated Review</returns>
        public Sitecore.Data.Items.Item Update(ReviewModel Review)
        {
            Sitecore.Data.Items.Item updateReview = Get(CommonSenseImportHelper.Settings.ReviewsContainer);

            updateReview.Editing.BeginEdit();

            updateReview = Map(updateReview, Review);

            updateReview.Editing.EndEdit();

            return updateReview;
        }

        /// <summary>
        /// Maps the ReviewModel to a Sitecore Item
        /// </summary>
        /// <param name="mappedReview">Destination Sitecore Item to map</param>
        /// <param name="Review">Values to map</param>
        /// <returns>Updated Sitecore item</returns>
        private Sitecore.Data.Items.Item Map(Sitecore.Data.Items.Item mappedReview, ReviewModel Review)
        {          
            // Single-line text
            if (mappedReview["title"] != null && !string.IsNullOrEmpty(Review.Title))
            {
                mappedReview["title"] = Review.Title;
            }
            
            // Multi-line text
            if (mappedReview["what kids can learn"] != null && !string.IsNullOrEmpty(Review.WhatKidsCanLearn))
            {
                mappedReview["what kids can learn"] = Review.WhatKidsCanLearn;    
            }
            
            mappedReview["any good"] = Review.AnyGood;
            mappedReview["how parents can help"] = Review.HowParentsCanHelp;
            mappedReview["description"] = Review.Description;
            mappedReview["summary"] = Review.Summary;

            // Links
            mappedReview["external link"] = Review.ExternalLink;
            mappedReview["apple app store id"] = Review.AppleAppStoreID;
            mappedReview["google play store id"] = Review.GooglePlayStoreID;
            mappedReview["telligent id"] = Review.TelligentID;
            mappedReview["csm id"] = Review.CommonSenseMediaID;

            // Numbers
            mappedReview["quality"] = Review.QualityRank;
            mappedReview["learning"] = Review.LearningRank;
            mappedReview["target grade"] = Review.TargetGrade;
            mappedReview["off grade"] = Review.OffGrade;
            mappedReview["on grade"] = Review.OnGrade;

            // Related to other items
            //csv of names of related items, then pointer to mapping
            mappedReview["genre"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Genres, CommonSenseImportHelper.Instance.Genre);
            mappedReview["subjects"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Subjects, CommonSenseImportHelper.Instance.Subject);
            mappedReview["skills"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Skills, CommonSenseImportHelper.Instance.Skill);
            mappedReview["categories"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Categories, CommonSenseImportHelper.Instance.Category);
            mappedReview["platforms"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Platforms, CommonSenseImportHelper.Instance.Platform);
            mappedReview["type"] = CommonSenseImportHelper.Instance.getRelatedIds(Review.Type, CommonSenseImportHelper.Instance.Type);

            // Related to Media
            //URL to image file, name to use. If no alt text is supplied, re-uses the name               
            mappedReview["screenshots"] = CommonSenseImportHelper.addMedia(Review.Screenshots);
            mappedReview["thumbnail image"] = CommonSenseImportHelper.addMedia(Review.Thumbnail);

            return mappedReview;
        }
    }
}
