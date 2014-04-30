using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
    public partial class KnowledgeQuizQuestionArticlePageItem : CustomItem
    {

        public static readonly string TemplateId = "{28A9E7F1-9265-4F10-B288-19A254E0F64D}";

        #region Inherited Base Templates

        private readonly ContentPageItem _ContentPageItem;
        public ContentPageItem ContentPage { get { return _ContentPageItem; } }

        #endregion

        #region Boilerplate CustomItem Code

        public KnowledgeQuizQuestionArticlePageItem(Item innerItem)
            : base(innerItem)
        {
            _ContentPageItem = new ContentPageItem(innerItem);

        }

        public static implicit operator KnowledgeQuizQuestionArticlePageItem(Item innerItem)
        {
            return innerItem != null ? new KnowledgeQuizQuestionArticlePageItem(innerItem) : null;
        }

        public static implicit operator Item(KnowledgeQuizQuestionArticlePageItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods


        //Could not find Field Type for Link to Result Page

        public CustomTextField KeepReadingHeadline
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Keep Reading Headline"]);
            }
        }


        public CustomTreeListField KeepReadingContent
        {
            get
            {
                return new CustomTreeListField(InnerItem, InnerItem.Fields["Keep Reading Content"]);
            }
        }

        public CustomCheckboxField ShowPromotionalControl
        {
            get
            {
                return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Promotional Control"]);
            }
        }


        public CustomTextField PromotionalHeadline
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Promotional Headline"]);
            }
        }


        public CustomTreeListField PromotionalContent
        {
            get
            {
                return new CustomTreeListField(InnerItem, InnerItem.Fields["Promotional Content"]);
            }
        }

        public CustomGeneralLinkField LinktoResultPage
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Result Page"]);
            }
        }

   
        #endregion //Field Instance Methods
    }
}