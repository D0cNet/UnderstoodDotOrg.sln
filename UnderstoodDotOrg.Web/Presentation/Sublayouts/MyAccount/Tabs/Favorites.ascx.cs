using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
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

        public Item context = Sitecore.Context.Item;

        protected void lbUnsave_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem ritem = (RepeaterItem)btn.NamingContainer;
            var item = ritem.DataItem as FavoritesModel;
            
            if (IsUserLoggedIn)
            {
                MembershipManager mmgr = new MembershipManager();
                try
                {
                    bool success = mmgr.LogMemberActivity_AsDeleted(CurrentMember.MemberId,
                        item.ContentId,
                        Constants.UserActivity_Values.Favorited,
                        Constants.UserActivity_Types.ContentRelated);

                    if (success)
                    {
                        Response.Redirect(Request.RawUrl);
                    }
                }
                catch
                {

                }
            }
            else
            {
                string url = SignUpPageItem.GetSignUpPage().GetUrl();
                Response.Redirect(url);
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
            hypReplyCount.Text = "<span>" + item.ReplyCount + "</span>";

            HtmlButton lbUnSave = (HtmlButton)e.Item.FindControl("lbUnSave");
            lbUnSave.ServerClick += new EventHandler(lbUnsave_Click);

            HyperLink hlFacebook = (HyperLink)e.Item.FindControl("hlFacebook");
            hlFacebook.NavigateUrl = SocialHelper.GetFacebookShareUrl(Sitecore.Context.Database.GetItem(item.ContentId));

            Literal ltlFacebook = (Literal)e.Item.FindControl("ltlFacebook");
            ltlFacebook.Text = DictionaryConstants.SocialSharingFacebook;

            HyperLink hlGooglePlus = (HyperLink)e.Item.FindControl("hlGooglePlus");
            hlGooglePlus.NavigateUrl = SocialHelper.GetGooglePlusShareUrl(Sitecore.Context.Database.GetItem(item.ContentId));

            Literal ltlGooglePlus = (Literal)e.Item.FindControl("ltlGooglePlus");
            ltlGooglePlus.Text = DictionaryConstants.SocialSharingGooglePlus;

            HyperLink hlTwitter = (HyperLink)e.Item.FindControl("hlTwitter");
            hlTwitter.NavigateUrl = SocialHelper.GetTwitterShareUrl(Sitecore.Context.Database.GetItem(item.ContentId), item.Title);

            Literal ltlTwitter = (Literal)e.Item.FindControl("ltlTwitter");
            ltlTwitter.Text = DictionaryConstants.SocialSharingTwitter;
        }
    }
}