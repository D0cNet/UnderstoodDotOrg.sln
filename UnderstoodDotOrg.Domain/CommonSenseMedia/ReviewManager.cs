using Sitecore.SecurityModel;
using UnderstoodDotOrg.Domain.Importer;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.AssistiveTools;
using Sitecore.Configuration;
using System;
using Sitecore.Data.Fields;
using Sitecore.Links;

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
        /// 

        public Item Add(ReviewModel Review)
        {
            try
            {

                using (new SecurityDisabler())
                {
                    TemplateItem reviewTemplate = Sitecore.Configuration.Factory.GetDatabase("master").GetTemplate(ReviewItem.TemplateId);

                    Item newReview = Get("{397EE1E4-F4BB-448E-B3CC-D1ED0F6FEE3D}").Add(CommonSenseImportHelper.removePunctuation(Review.Title), reviewTemplate);

                    newReview.Editing.BeginEdit();

                    newReview = Map(newReview, Review);

                    newReview.Editing.EndEdit();

                    return newReview;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the desired Review
        /// </summary>
        /// <param name="GUID">Review to return</param>
        /// <returns>Desired Review</returns>
        public Item Get(string GUID)
        {
            Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
            return master.GetItem(GUID);
        }

        /// <summary>
        /// Updates the desired Review
        /// </summary>
        /// <param name="Review">ReviewModel instance to update</param>
        /// <returns>Updated Review</returns>
        public Item Update(ReviewModel Review)
        {
            Item updateReview = Get(CommonSenseImportHelper.Instance.Settings.ReviewsContainer);

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
        private Item Map(Item mappedReview, ReviewModel Review)
        {
            try
            {
                // Single-line text
                if (mappedReview["title"] != null && !string.IsNullOrEmpty(Review.Title))
                {
                    mappedReview["title"] = Review.Title.Trim();
                }

                if (mappedReview["summary"] != null && Review.Summary != null)
                {
                    mappedReview["summary"] = Review.Summary.Trim();
                }

                if (mappedReview["description"] != null && Review.Description != null)
                {
                    mappedReview["description"] = Review.Description.Trim();
                }

                if (mappedReview["what parents need to know"] != null && Review.ParentsNeedToKnow != null)
                {
                    mappedReview["what parents need to know"] = Review.ParentsNeedToKnow.Trim();
                }

                if (mappedReview["what kids can learn"] != null && Review.WhatKidsCanLearn != null)
                {
                    mappedReview["what kids can learn"] = Review.WhatKidsCanLearn.Trim();
                }

                if (mappedReview["any good"] != null && !string.IsNullOrEmpty(Review.AnyGood))
                {
                    mappedReview["any good"] = Review.AnyGood.Trim();
                }

                if (mappedReview["target grade"] != null && !string.IsNullOrEmpty(Review.TargetGrade))
                {
                    mappedReview["target grade"] = Review.TargetGrade.Trim();
                }

                if (mappedReview["on grade"] != null && !string.IsNullOrEmpty(Review.OnGrade))
                {
                    mappedReview["on grade"] = Review.OnGrade.Trim();
                }

                if (mappedReview["off grade"] != null && !string.IsNullOrEmpty(Review.OffGrade))
                {
                    mappedReview["off grade"] = Review.OffGrade.Trim();
                }

                if (mappedReview["apple app store id"] != null && !string.IsNullOrEmpty(Review.AppleAppStoreID))
                {
                    mappedReview["apple app store id"] = Review.AppleAppStoreID.Trim();
                }

                if (mappedReview["google play store id"] != null && !string.IsNullOrEmpty(Review.GooglePlayStoreID))
                {
                    mappedReview["google play store id"] = Review.GooglePlayStoreID.Trim();
                }

                if (mappedReview["csm id"] != null && !string.IsNullOrEmpty(Review.CommonSenseMediaID))
                {
                    mappedReview["csm id"] = Review.CommonSenseMediaID.Trim();
                }

                if (mappedReview["external link"] != null && !string.IsNullOrEmpty(Review.ExternalLink))
                {
                    mappedReview["external link"] = "<link text=\"\" linktype=\"external\" url=\"" + Review.ExternalLink + "\" target=\"\" />";
                }

                if (mappedReview["price"] != null && !string.IsNullOrEmpty(Review.Price))
                {
                    mappedReview["price"] = Review.Price.Trim();
                }

                if (mappedReview["how parents can help"] != null && Review.HowParentsCanHelp != null)
                {
                    mappedReview["how parents can help"] = Review.HowParentsCanHelp.Trim();
                }

                if (mappedReview["learning"] != null && Review.LearningRank != null)
                {
                    mappedReview["learning"] = Review.LearningRank.Trim();
                }

                if (mappedReview["publish date"] != null && Review.Published != null)
                {
                    mappedReview["publish date"] = Review.Published.Trim();
                }

                if (mappedReview["screenshots"] != null && Review.Screenshots != null)
                {
                    mappedReview["screenshots"] = CommonSenseImportHelper.addMedia(Review.Screenshots).Trim();
                }

                if (mappedReview["platforms"] != null && Review.Platforms != null)
                {
                    mappedReview["platforms"] = CommonSenseImportHelper.MatchCSV(Review.Platforms, "{042EBC5C-CCA0-4758-823D-A07213A72434}").Trim();
                }

                if (mappedReview["skills"] != null && Review.Skills != null)
                {
                    mappedReview["skills"] = CommonSenseImportHelper.MatchCSV(Review.Skills, "{0AC054FE-599B-4B8A-B5A2-BA805260674B}").Trim();
                }

                if (mappedReview["subjects"] != null && Review.Subjects != null)
                {
                    mappedReview["subjects"] = CommonSenseImportHelper.MatchCSV(Review.Subjects, "{11AAE042-9BFA-43C4-A971-0AF140108921}").Trim();
                }

                if (mappedReview["issues"] != null && Review.Issues != null)
                {
                    mappedReview["issues"] = CommonSenseImportHelper.MatchCSV(Review.Issues, "{5CDC7D81-19CA-4CF6-8C58-A4D013823A05}").Trim();
                }

                if (mappedReview["genre"] != null && Review.Genres != null)
                {
                    mappedReview["genre"] = CommonSenseImportHelper.MatchCSV(Review.Genres, "{97908446-B312-4183-915E-2E43BA5A7693}").Trim();
                }

                if (mappedReview["thumbnail image"] != null && Review.Thumbnail != null)
                {
                    MediaItem temp = CommonSenseImportHelper.addMedia(Review.Thumbnail);
                    if(temp != null)
                        mappedReview["thumbnail image"] = "<image mediaid=\"" + temp.ID.ToString() + "\" mediapath=\"" + temp.MediaPath + "\" src=\"" + temp.FilePath + "\" />";
                }

                if (mappedReview["type"] != null && Review.Type != null)
                {
                    mappedReview["type"] = CommonSenseImportHelper.MatchCSV(Review.Type, "{88226E2B-BAFE-44E9-8EEE-95525458EA14}").Trim();
                }

                if (mappedReview["category"] != null && Review.Category != null)
                {
                    mappedReview["category"] = CommonSenseImportHelper.GetCategory(Review.Category).Trim();
                }
            }
            catch (Exception e)
            {
                return mappedReview;
            }

            //// Links
            //mappedReview["telligent id"] = Review.TelligentID;

            //// Numbers
            //mappedReview["quality"] = Review.QualityRank;

            return mappedReview;
        }
    }
}
