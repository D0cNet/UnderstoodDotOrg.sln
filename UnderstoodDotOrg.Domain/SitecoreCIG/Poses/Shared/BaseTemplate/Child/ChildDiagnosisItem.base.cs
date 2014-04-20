using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child
{
    public partial class ChildDiagnosisItem : CustomItem
    {

        public static readonly string TemplateId = "{C037EF93-CAE5-4265-8147-B45684572A93}";


        #region Boilerplate CustomItem Code

        public ChildDiagnosisItem(Item innerItem)
            : base(innerItem)
        {

        }

        public static implicit operator ChildDiagnosisItem(Item innerItem)
        {
            return innerItem != null ? new ChildDiagnosisItem(innerItem) : null;
        }

        public static implicit operator Item(ChildDiagnosisItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods


        public CustomTextField DiagnosisName
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Diagnosis Name"]);
            }
        }


        public CustomTextField DiagnosisDescription
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Diagnosis Description"]);
            }
        }


        #endregion //Field Instance Methods
    }
}