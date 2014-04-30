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
    public partial class AssessmentQuizArticlePage1Item : CustomItem
    {

        public static readonly string TemplateId = "{6AC5B76A-6EC6-4561-868C-9A0EBC3190D3}";

        #region Inherited Base Templates

        private readonly ContentPageItem _ContentPageItem;
        public ContentPageItem ContentPage { get { return _ContentPageItem; } }

        #endregion

        #region Boilerplate CustomItem Code

        public AssessmentQuizArticlePage1Item(Item innerItem)
            : base(innerItem)
        {
            _ContentPageItem = new ContentPageItem(innerItem);

        }

        public static implicit operator AssessmentQuizArticlePage1Item(Item innerItem)
        {
            return innerItem != null ? new AssessmentQuizArticlePage1Item(innerItem) : null;
        }

        public static implicit operator Item(AssessmentQuizArticlePage1Item customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods



        public CustomGeneralLinkField LinktoNextPage
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Next Page"]);
            }

        }


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
        #endregion //Field Instance Methods
    }
}