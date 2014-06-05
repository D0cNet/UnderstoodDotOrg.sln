using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Favorites : BaseSublayout<AccountFavoritesPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var favoritesList = CommunityHelper.GetFavorites(CurrentMember.MemberId);
            if ((favoritesList != null) && (favoritesList.Count != 0))
            {
                pnlFavorites.Visible = true;
                rptFavorites.DataSource = favoritesList;
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
            HyperLink hypFavoriteTitle = (HyperLink)e.Item.FindControl("hypFavoriteTitle");
            hypFavoriteTitle.NavigateUrl = item.Url;
            hypFavoriteTitle.Text = item.Title;
            Literal litType = (Literal)e.Item.FindControl("litType");
            litType.Text = item.Type;
            HyperLink hypReplyCount = (HyperLink)e.Item.FindControl("hypReplyCount");
            hypReplyCount.NavigateUrl = item.Url;
            hypReplyCount.Text = item.ReplyCount;
        }
    }
}