using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class AboutPartner_Details : System.Web.UI.UserControl
    {
        PartnerInfoItem ObjPartnerInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjPartnerInfo = new PartnerInfoItem(Sitecore.Context.Item);
            if (ObjPartnerInfo != null)
            {
                if (string.IsNullOrEmpty(ObjPartnerInfo.Link) == false)
                {
                    hlPartnerSiteLink.Text = ObjPartnerInfo.Link.Text;
                    hlPartnerSiteLink.NavigateUrl = ObjPartnerInfo.Link.Text;
                    hlPartnerSiteLink.Visible = true;
                }
            }
        }
    }
}