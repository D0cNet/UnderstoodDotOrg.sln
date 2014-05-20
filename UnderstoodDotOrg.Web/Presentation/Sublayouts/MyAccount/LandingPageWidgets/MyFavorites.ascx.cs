using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyFavorites : BaseSublayout
    {
        private class FavoriteModel
        {
            public string Title { get; set; }
            public string TitleUrl { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountFavorites);
            hypFavoritesTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            //TO-DO Add call to get Favorites and cast them as FavoriteModel objects

            //Stub for one link
            List<FavoriteModel> favoritesDataSource = new List<FavoriteModel>();
            FavoriteModel stubFavorite = new FavoriteModel();
            stubFavorite.Title = "FavoriteLink1";
            stubFavorite.TitleUrl = "/";
            favoritesDataSource.Add(stubFavorite);
            litCount.Text = favoritesDataSource.Count.ToString();

            rptFavorites.DataSource = favoritesDataSource;
            rptFavorites.DataBind();
        }

        protected void rptFavorites_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (FavoriteModel)e.Item.DataItem as FavoriteModel;
            HyperLink hypFavoritesLink = (HyperLink)e.Item.FindControl("hypFavoritesLink");
            hypFavoritesLink.NavigateUrl = ((FavoriteModel)e.Item.DataItem).TitleUrl;
            hypFavoritesLink.Text = ((FavoriteModel)e.Item.DataItem).Title;
        }
    }
}