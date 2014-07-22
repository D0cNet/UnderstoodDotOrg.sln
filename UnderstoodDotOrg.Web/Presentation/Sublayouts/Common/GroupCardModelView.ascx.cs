﻿using Sitecore.Data.Items;
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
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{B1EFCAA6-C79A-4908-84D0-B4BDFA5E25A3}")) + "?q=" + query + "&a=" + Constants.TelligentSearchParams.Group);
        }
    }
}