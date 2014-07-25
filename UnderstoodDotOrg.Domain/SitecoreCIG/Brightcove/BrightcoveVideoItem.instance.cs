using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Brightcove
{
    public partial class BrightcoveVideoItem
    {
        private string _videoStillUrl;
        public string VideoStillUrl
        {
            get
            {
                return _videoStillUrl ?? (_videoStillUrl = InnerItem["VideoStillURL"]);
            }
        }
    }
}