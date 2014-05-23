using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parents : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
            {
            Item parentItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.ParentsLikeMeAll));
            string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
            ref_allParents.HRef = itemHref;
            base.OnInit(e);
            }

        protected void Page_Load(object sender, EventArgs e)
        {
            Item currItem = Sitecore.Context.Item;
           // scImage.Item = currItem;
           // MembershipManager mem = new MembershipManager();
            
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //Redirect to All parents item
            Item parentItem = Sitecore.Context.Database.GetItem( Sitecore.Data.ID.Parse(Constants.Pages.ParentsLikeMeAll));
            string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
            Sitecore.Web.WebUtil.Redirect(itemHref);
        }

       
    }
}