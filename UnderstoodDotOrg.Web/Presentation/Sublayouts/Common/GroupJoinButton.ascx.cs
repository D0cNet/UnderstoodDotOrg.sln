using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using System.Text;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupJoinButton : BaseSublayout//System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
         
        }

        public string Class
        {
            get { return this.btnJoin.CssClass; }
            set { this.btnJoin.CssClass = value; }
        }
        private string GroupID
        {
            get
            {
                return ViewState["_groupId"].ToString();
            }
            set
            {
                ViewState["_groupId"] = value;
            }
        }
        private bool IsMember
        {
            get { return (bool)ViewState["_isMemberOfGroup"]; }
            set { ViewState["_isMemberOfGroup"] = value; }
        }

        public string Text
        {
            get { return btnJoin.Text; }
            set { btnJoin.Text = value; }
        }



        public void LoadState(string groupID)
        {
            if (!String.IsNullOrEmpty(groupID))
            {
                GroupID = groupID;
                Text = DictionaryConstants.JoinThisGroupLabel;
                IsMember = false;
                try
                {
                    if (CurrentMember != null)
                    {
                        if (CurrentMember.ScreenName != null)
                        {
                            //Check if user is already joined
                            if (TelligentService.IsUserInGroup(CurrentMember.ScreenName, groupID))
                            {
                                IsMember = true;
                                Text = DictionaryConstants.ViewDiscussionsLabel;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in LoadState function in Join Groups.\nError:\n" + ex.Message);
                }
            }
        }


        protected void btnJoin_Click(object sender, EventArgs e)
        {
            if (CurrentMember != null)
            {
                if (CurrentMember.ScreenName != null)
                {
                    if (IsMember)
                    {
                        try
                        {
                            Item grpItem = Groups.ConvertGroupIDtoSitecoreItem(GroupID);
                        
                            string itemUrl = grpItem.GetUrl();
                            Sitecore.Web.WebUtil.Redirect(itemUrl);
                        }
                        catch (Exception ex)
                        {
                            Sitecore.Diagnostics.Error.LogError("Error in btnJoin_Click for Join Group Button function.\nError:\n" + ex.Message);
                        }
                    }
                    else
                    {
                        if (TelligentService.JoinGroup(GroupID, CurrentMember.ScreenName))
                        {
                            //Send Email
                            GroupItem grpItem = new GroupItem(Groups.ConvertGroupIDtoSitecoreItem(GroupID));
                            GroupCardModel grpModel = Groups.GroupCardModelFactory(grpItem);

                           
                            BaseReply reply = ExactTargetService.InvokeEM9GroupWelcome(new InvokeEM9GroupWelcomeRequest
                            {
                                PreferredLanguage = CurrentMember.PreferredLanguage,
                                GroupLeaderEmail = grpModel.ModeratorEmail,
                                GroupLink = grpItem.GetUrl(),
                                GroupTitle = grpItem.DisplayName,
                                ToEmail = CurrentMember.Email,

                                GroupModerator = new Moderator
                                {
                                    groupModBioLink = grpModel.ModeratorBio,
                                    groupModImgLink = grpModel.ModeratorAvatarUrl, //owner.Avatar,
                                    groupModName = grpModel.ModeratorName
                                }
                            });

                            Text = DictionaryConstants.ViewDiscussionsLabel;

                        }
                    }

                }
            }
        }





    }
}