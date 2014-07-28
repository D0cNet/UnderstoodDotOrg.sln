using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Services.CommunityServices;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupCardModelView : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            litMembersOnlyDiscussion.Text = DictionaryConstants.MembersOnlyDiscussionLabel;
            litFindConvoLabel.Text = DictionaryConstants.FindAConversationLabel;
            litDiscussionLabel.Text = DictionaryConstants.DiscussionsLabel;
            litSearchLabel.Text = DictionaryConstants.SearchLabel;
            litMembersLabel.Text = DictionaryConstants.MembersLabel;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Item currItem = Sitecore.Context.Item;
            if(currItem !=null){
                UnderstoodDotOrg.Domain.Understood.Common.GroupCardModel gm = Groups.GroupCardModelFactory(new GroupItem(currItem));
                InitializeView(gm);
            }
        }

        protected void InitializeView(UnderstoodDotOrg.Domain.Understood.Common.GroupCardModel gm)
        {
            if (gm != null)
            {
                imgModeratorImage.ImageUrl = gm.ModeratorAvatarUrl;
                litDesc.Text = gm.Description;
                litModeratorScreenName.Text = gm.ModeratorName;
                litModeratorTitle.Text = gm.ModeratorTitle;
                litTitle.Text = gm.Title;
                litNumMembers.Text = gm.NumOfMembers.ToString();
                litNumThreads.Text = gm.NumOfDiscussions.ToString();

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var qs = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            qs.Set("q", txtSearch.Text);
            qs.Set("g", Sitecore.Context.Item.ID.ToString());
            Response.Redirect(String.Format("{0}?{1}", LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{97CEFC40-892F-4E44-B94F-26522EB1F7B3}")), qs));
        }
    }
}