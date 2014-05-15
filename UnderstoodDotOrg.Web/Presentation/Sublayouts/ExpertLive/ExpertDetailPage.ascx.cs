using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class ExpertDetailPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExpertDetailPageItem contextItem = Sitecore.Context.Item;
            BaseEventDetailPageItem baseEventDetailpage = new BaseEventDetailPageItem(contextItem);
            ExpertDetailPageItem expert = baseEventDetailpage.Expert.Item;
            if (!Page.IsPostBack)
            {
                if (scBioImage != null)
                {
                    scBioImage.Item = contextItem;
                }
                if (litHours != null)
                {
                    litHours.Text = DictionaryConstants.OnlineOfficeHours;
                }
                if (frHours != null)
                {
                    frHours.Item = contextItem;
                }
                if (scFollowTwittLink != null)
                {
                    scFollowTwittLink.Item = contextItem;
                }
                if (scFollowBlogLink != null)
                {
                    scFollowBlogLink.Item = contextItem;
                }
                if (scBioLink != null)
                {
                    scBioLink.Item = contextItem;
                }
                if (frBodyContent != null)
                {
                    frBodyContent.Item = contextItem;
                }
            }

        }
    }
}