using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class UpComingWebinar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebinarEventPageItem contextItem = Sitecore.Context.Item;
            if (!Page.IsPostBack)
            {


                if (contextItem != null)
                {
                    if (frPageTItle != null)
                    {

                        frPageTItle.Item = contextItem;
                    }
                    if (hlLink != null)
                    {
                        hlLink.NavigateUrl = contextItem.InnerItem.GetUrl();
                        //hlLink.Text=contextItem.
                    }

                }
            }

        }
    }
}