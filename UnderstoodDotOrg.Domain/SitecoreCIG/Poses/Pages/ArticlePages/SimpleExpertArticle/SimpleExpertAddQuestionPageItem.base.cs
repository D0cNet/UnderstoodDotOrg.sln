using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle
{
    public partial class SimpleExpertAddQuestionPageItem : CustomItem
    {

        public static readonly string TemplateId = "{76EB14F9-CD7C-472C-9CAE-E0470BA471F0}";


        #region Boilerplate CustomItem Code

        public SimpleExpertAddQuestionPageItem(Item innerItem)
            : base(innerItem)
        {

        }

        public static implicit operator SimpleExpertAddQuestionPageItem(Item innerItem)
        {
            return innerItem != null ? new SimpleExpertAddQuestionPageItem(innerItem) : null;
        }

        public static implicit operator Item(SimpleExpertAddQuestionPageItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods


        public CustomTextField Question
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Question"]);
            }
        }


        public CustomTextField Answer
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Answer"]);
            }
        }


        public CustomLookupField AnsweredExpertDetails
        {
            get
            {
                return new CustomLookupField(InnerItem, InnerItem.Fields["Answered Expert Details"]);
            }
        }


        #endregion //Field Instance Methods
    }
}