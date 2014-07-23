using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using Sitecore.Links;
using Sitecore.Data.Items;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class MyAccountHeader : BaseSublayout
    {
        protected MyProfileItem MyProfilePage { get; set; }
        protected MyAccountItem MyAccountPage { get; set; }
        protected String MyNotifications
        {
            get
            {
                return MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetUrl();
            }
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            litNotificationsLabel.Text = DictionaryConstants.NotificationsButtonLabel;
            if (IsUserLoggedIn)
            {
                MyProfilePage = MyProfileItem.GetMyProfilePage();
                MyAccountPage = MyAccountItem.GetMyAccountPage();

                var accountPages = MyAccountPage.GetAccountPages();

                rptrAccountNav.DataSource = accountPages;
                rptrAccountNav.DataBind();

                hlSectionTitle.NavigateUrl = MainsectionItem.GetHomePageItem().GetUrl();
                frSectionTitle.Item = MainsectionItem.GetHomePageItem();

                if (CurrentMember.ZipCode != null)
                {
                    if(!string.IsNullOrEmpty(CurrentMember.ScreenName))
                        litLocation.Text = Services.CommunityServices.GeoTargeting.GetStateByZip(CurrentMember.ZipCode);
                }
                
                    if (!String.IsNullOrEmpty(CurrentMember.ScreenName))
                    {
                        List<INotification> notifs =new  List<INotification>();
                        List<Conversation> checkConvos =new List<Conversation>();
                        if (Notifications == null)
                        {
                            notifs = TelligentService.GetNotifications(CurrentMember.ScreenName);
                            if (notifs != null && notifs.Count() > 0)
                            {
                                //spnCount.Visible = true;
                                //litNotifCount.Text = notifs.Count().ToString();
                                Notifications = notifs;

                            }
                            else
                            {
                                notifs = new List<INotification>();
                                Notifications = notifs;
                            }
                        }
                        else
                        {
                            notifs = Notifications;
                        }

                        if (Conversations==null)
                        {
                            checkConvos = TelligentService.GetConversations(CurrentMember.ScreenName, Constants.TelligentConversationStatus.Unread);
                            if (checkConvos != null && checkConvos.Count() > 0)
                            {
                                Conversations = checkConvos;
                            }
                            else
                            {
                                checkConvos = new List<Conversation>();
                                Conversations = checkConvos;
                            }
                        }
                        else
                        {
                            checkConvos = Conversations;
                            
                        }
                        int totalNotifs = notifs.Count() + checkConvos.Count();
                        if (totalNotifs > 0)
                        {
                            spnCount.Visible = true;
                            litNotifCount.Text = totalNotifs.ToString();
                        }
                        else
                        {
                            spnCount.Visible = false;

                        }


                    }
                
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomePageItem().GetUrl());
            }

            if (CurrentMember != null && !string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                try
                {
                    User user = TelligentService.GetUser(this.CurrentMember.ScreenName);
                    if (user != null)
                    {
                        userAvatar.Src = user.AvatarUrl;
                    }
                }
                catch { }
            }

            //if (!IsPostBack)
            //{
            //    try
            //    {
            //        if (CurrentMember.ScreenName != null)
            //        {
            //            userAvatar.Src = TelligentService.GetUser(this.CurrentMember.ScreenName).AvatarUrl;
            //        }
            //    }
            //    catch { }
            //}
        }

        protected void rptrAccountNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var currentItemId = Sitecore.Context.Item.ID.ToString();
            HyperLink hlNavLink = (HyperLink)e.Item.FindControl("hlNavLink");
            var currentUrl = Sitecore.Context.Database.GetItem(currentItemId).GetUrl();
            var item = e.Item.DataItem as MyAccountBaseItem;

            if (currentItemId != null)
            {
                // Highlight the selected tab
                switch (currentItemId)
                {
                    case "{1041DF93-81A2-46FD-910F-8927F22DA4F1}":
                        if (item.AccountNavigationTitle.Text.Equals("Groups"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{355E4A54-A133-4FD4-B796-8C515F194751}":
                        if (item.AccountNavigationTitle.Text.Equals("Events"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{E092EB37-B488-4A42-97CC-7EA875CCF877}":
                        if (item.AccountNavigationTitle.Text.Equals("Comments"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{2A5936E4-1C1A-4F4C-8DDE-EB768BD43E81}":
                        if (item.AccountNavigationTitle.Text.Equals("Saved"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{840AEEF4-5294-4A0D-8D1C-6839E39FE3FE}":
                        if (item.AccountNavigationTitle.Text.Equals("Connections"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                }
            }
        }

        protected void FileUpload(object sender, EventArgs e)
        {
            if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
            {
                FileUpload fuUserAvatar = (FileUpload)FindControl("fuUserAvatar");
                if (fuUserAvatar.HasFile)
                {
                    string imageTempLocation = Path.GetTempPath() + fuUserAvatar.PostedFile.FileName;
                    fuUserAvatar.PostedFile.SaveAs(imageTempLocation);

                    string userId = TelligentService.ReadUserId(this.CurrentMember.ScreenName);

                    using (var webClient = new WebClient())
                    {
                        webClient.Headers.Add("Rest-User-Token", TelligentService.TelligentAuth());
                        webClient.Headers.Add("Rest-Method", "PUT");
                        var requestUrl = String.Format("{0}api.ashx/v2/users/{1}/avatar.xml", Sitecore.Configuration.Settings.GetSetting("TelligentConfig"), userId);

                        webClient.UploadFile(requestUrl, "POST", imageTempLocation);
                    }
                    Response.Redirect(Request.RawUrl);
                }
            }
            else 
            {
                Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{907EAD93-A2AB-48ED-886C-2DF985375803}")) + "#community");
            }
        }
    }
}