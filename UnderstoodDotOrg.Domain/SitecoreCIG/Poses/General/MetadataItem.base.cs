using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class MetadataItem : CustomItem
    {

        public static readonly string TemplateId = "{B793F0F5-2857-4379-99B9-EC1D132C887F}";


        #region Boilerplate CustomItem Code

        public MetadataItem(Item innerItem)
            : base(innerItem)
        {

        }

        public static implicit operator MetadataItem(Item innerItem)
        {
            return innerItem != null ? new MetadataItem(innerItem) : null;
        }

        public static implicit operator Item(MetadataItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods


        public CustomTextField ContentTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Content Title"]);
            }
        }


        #endregion //Field Instance Methods
    }
}