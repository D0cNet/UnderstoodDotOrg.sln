using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.ListTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
    public partial class TyceVideoGradeSetsItem
    {
        #region Field Instance Methods (fields with search)
        public CustomMultiListField IntroductionWithSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Introduction With Subtitles"]);
            }
        }
        public CustomMultiListField IntroductionWithoutSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Introduction Without Subtitles"]);
            }
        }
        public CustomMultiListField ChildStoryWithSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Child Story With Subtitles"]);
            }
        }
        public CustomMultiListField ChildStoryWithoutSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Child Story Without Subtitles"]);
            }
        }
        public CustomMultiListField OnDemandWithSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["On Demand With Subtitles"]);
            }
        }
        public CustomMultiListField OnDemandWithoutSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["On Demand Without Subtitles"]);
            }
        }
        #endregion
    }
}