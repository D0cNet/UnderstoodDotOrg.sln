using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyFavorites : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountFavorites);
            hypFavoritesTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
            hypFavoritesTab.Text = context.SeeAllFavoritesText;

            var favoritesList = CommunityHelper.GetFavorites(CurrentMember.MemberId);

            litCount.Text = favoritesList != null ? favoritesList.Count.ToString() : "0";

            if ((favoritesList != null) && (favoritesList.Count != 0))
            {
                pnlFavorites.Visible = true;
                rptFavorites.DataSource = favoritesList.Count < 3 ? favoritesList.GetRange(0, favoritesList.Count) : favoritesList.GetRange(0, 3);
                rptFavorites.DataBind();
            }
            else
            {
                pnlNoFavorites.Visible = true;
            }
        }

        protected void rptFavorites_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as FavoritesModel;
            HyperLink hypFavoritesLink = (HyperLink)e.Item.FindControl("hypFavoritesLink");
            hypFavoritesLink.NavigateUrl = item.Url;
            hypFavoritesLink.Text = item.Title;
        }
    }
}