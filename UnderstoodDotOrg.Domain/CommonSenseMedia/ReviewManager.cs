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
            // Single-line text
            if (mappedReview["title"] != null && !string.IsNullOrEmpty(Review.Title))
            {
                mappedReview["title"] = Review.Title;
            }

            if (mappedReview["summary"] != null && !string.IsNullOrEmpty(Review.Summary))
            {
                mappedReview["summary"] = Review.Summary;
            }

            if (mappedReview["description"] != null && !string.IsNullOrEmpty(Review.Description))
            {
                mappedReview["description"] = Review.Description;
            }

            if (mappedReview["what parents need to know"] != null && !string.IsNullOrEmpty(Review.ParentsNeedToKnow))
            {
                mappedReview["what parents need to know"] = Review.ParentsNeedToKnow;
            }

            if (mappedReview["what kids can learn"] != null && !string.IsNullOrEmpty(Review.WhatKidsCanLearn))
            {
                mappedReview["what kids can learn"] = Review.WhatKidsCanLearn;
            }

            if (mappedReview["any good"] != null && !string.IsNullOrEmpty(Review.AnyGood))
            {
                mappedReview["any good"] = Review.AnyGood;
            }

            if (mappedReview["target grade"] != null && !string.IsNullOrEmpty(Review.TargetGrade))
            {
                mappedReview["target grade"] = Review.TargetGrade;
            }

            if (mappedReview["on grade"] != null && !string.IsNullOrEmpty(Review.OnGrade))
            {
                mappedReview["on grade"] = Review.OnGrade;
            }

            if (mappedReview["off grade"] != null && !string.IsNullOrEmpty(Review.OffGrade))
            {
                mappedReview["off grade"] = Review.OffGrade;
            }

            if (mappedReview["apple app store id"] != null && !string.IsNullOrEmpty(Review.AppleAppStoreID))
            {
                mappedReview["apple app store id"] = Review.AppleAppStoreID;
            }

            if (mappedReview["google play store id"] != null && !string.IsNullOrEmpty(Review.GooglePlayStoreID))
            {
                mappedReview["google play store id"] = Review.GooglePlayStoreID;
            }

            if (mappedReview["csm id"] != null && !string.IsNullOrEmpty(Review.CommonSenseMediaID))
            {
                mappedReview["csm id"] = Review.CommonSenseMediaID;
            }

            if (mappedReview["external link"] != null && !string.IsNullOrEmpty(Review.ExternalLink))
            {
                mappedReview["external link"] = "<link text=\"\" linktype=\"external\" url=\""+Review.ExternalLink+"\" target=\"\" />";
            }

            if (mappedReview["price"] != null && !string.IsNullOrEmpty(Review.Price))
            {
                mappedReview["price"] = Review.Price;
            }

            if (mappedReview["how parents can help"] != null && !string.IsNullOrEmpty(Review.HowParentsCanHelp))
            {
                mappedReview["how parents can help"] = Review.HowParentsCanHelp;
            }

            if (mappedReview["learning"] != null && !string.IsNullOrEmpty(Review.LearningRank))
            {
                mappedReview["learning"] = Review.LearningRank;
            }

            if (mappedReview["publish date"] != null && !string.IsNullOrEmpty(Review.Published))
            {
                mappedReview["publish date"] = Review.Published;
            }

            if (mappedReview["screenshots"] != null && Review.Screenshots != null)
            {
                mappedReview["screenshots"] = CommonSenseImportHelper.addMedia(Review.Screenshots);
            }

            if (mappedReview["platforms"] != null && !string.IsNullOrEmpty(Review.Platforms))
            {
                mappedReview["platforms"] = CommonSenseImportHelper.MatchCSV(Review.Platforms, "{042EBC5C-CCA0-4758-823D-A07213A72434}");
            }

            if (mappedReview["skills"] != null && !string.IsNullOrEmpty(Review.Skills))
            {
                mappedReview["skills"] = CommonSenseImportHelper.MatchCSV(Review.Skills, "{0AC054FE-599B-4B8A-B5A2-BA805260674B}");
            }

            if (mappedReview["subjects"] != null && !string.IsNullOrEmpty(Review.Subjects))
            {
                mappedReview["subjects"] = CommonSenseImportHelper.MatchCSV(Review.Subjects, "{11AAE042-9BFA-43C4-A971-0AF140108921}");
            }

            if (mappedReview["issues"] != null && !string.IsNullOrEmpty(Review.Issues))
            {
                mappedReview["issues"] = CommonSenseImportHelper.MatchCSV(Review.Issues, "{5CDC7D81-19CA-4CF6-8C58-A4D013823A05}");
            }

            if (mappedReview["genre"] != null && !string.IsNullOrEmpty(Review.Genres))
            {
                mappedReview["genre"] = CommonSenseImportHelper.MatchCSV(Review.Genres, "{97908446-B312-4183-915E-2E43BA5A7693}");
            }

            if (mappedReview["thumbnail image"] != null && Review.Thumbnail != null)
            {
                MediaItem temp = CommonSenseImportHelper.addMedia(Review.Thumbnail);
                mappedReview["thumbnail image"] = "<image mediaid=\""+temp.ID.ToString()+"\" mediapath=\""+temp.MediaPath+"\" src=\""+temp.FilePath+"\" />";
            }

            if (mappedReview["type"] != null && !string.IsNullOrEmpty(Review.Type))
            {
                mappedReview["type"] = CommonSenseImportHelper.MatchCSV(Review.Type, "{88226E2B-BAFE-44E9-8EEE-95525458EA14}");
            }

            if (mappedReview["category"] != null && !string.IsNullOrEmpty(Review.Category))
            {
                mappedReview["category"] = CommonSenseImportHelper.GetCategory(Review.Category);
            }

            //// Links
            //mappedReview["telligent id"] = Review.TelligentID;

            //// Numbers
            //mappedReview["quality"] = Review.QualityRank;

            return mappedReview;
        }
    }
}
