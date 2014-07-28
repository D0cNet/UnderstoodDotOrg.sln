using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class WhatsHappeningNow : BaseSublayout //System.Web.UI.UserControl
    {

        private string MyUpcomingEvents = @"";
        private string MyFriends = @"~/Presentation/SubLayouts/Community/Whats Happening/MyFriends.ascx";
        private string MyGroups = @"~/Presentation/SubLayouts/Community/Whats Happening/MyGroups.ascx";
        private string RecommendedGroups = @"";
        private string RecommendedBlogs = @"~/Presentation/SubLayouts/Community/Whats Happening/RecommendedBlogs.ascx";
        private string RecommendedQuestions = @"~/Presentation/SubLayouts/Community/Whats Happening/RecommendedQuestions.ascx";
        private string BlogsIFollow = @"~/Presentation/SubLayouts/Community/Whats Happening/BlogsIFollow.ascx";

        //defaults 
        private string UpcomingEvents = @"~/Presentation/SubLayouts/Community/Whats Happening/UpcomingEvents.ascx";
        private string RecentQuestions = @"~/Presentation/SubLayouts/Community/Whats Happening/RecentQuestions.ascx";
        private string CommunityMembers = @"~/Presentation/SubLayouts/Community/Whats Happening/CommunityMembers.ascx";
        private string MostActiveGroups = @"~/Presentation/SubLayouts/Community/Whats Happening/MostActiveGroups.ascx";
        private string RecentBlogPosts = @"~/Presentation/SubLayouts/Community/Whats Happening/RecentBlogPosts.ascx";
        /// <summary>
        
        // for Haddad
        /// </summary>
        Database dbMaster = Database.GetDatabase("master"); //im sure this is being stored somewhere else, but whatever
        private string recommendedQuestionsItem = "/sitecore/content/pathtorecommendedqs";
        private string recentQuestionsItem = "/sitecore/content/pathstorecents";
        string renderingXml = "";
        LayoutDefinition layoutDefinition = new LayoutDefinition();
        string defaultDeviceId = "{FE5D7FDF-89C0-4D99-9AA3-B5FBD009C9F3}";
        //
        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.CurrentMember != null)
            {
                //logged in
                Item newItem;
                //upcoming events or my upcoming events --> fallback to upcoming events (default)
                //recent questions or recommended questions --> fallback to recent questions (default)
                //my friends --> fallback to community moderators (default)
                //recommended groups or my groups --> fallback to active groups (default)
                //recommended blogs or blogs i follow --> fallback to recent blogs (default)
               
                //should we display Recommended Questions?
                var reccommendedQuestions = SearchHelper.GetRecommendedContent(this.CurrentMember, QandADetailsItem.TemplateId)
                        .Where(a => a.GetItem() != null);
                if (reccommendedQuestions.Count() > 0)
                {
                    newItem = dbMaster.GetItem(recommendedQuestionsItem);
                  

                    sbQuestions.Path = this.RecommendedQuestions;
                }
                else
                {
                    newItem = dbMaster.GetItem(recentQuestionsItem);
                   

                    sbQuestions.Path = this.RecentQuestions;
                }
                //RenderingReference rendering = newItem.Visualization.GetRenderings(Sitecore.Context.Device, false).FirstOrDefault();
                //Sublayout sublayout = new Sublayout();
                //sublayout.DataSource = newItem.Paths.FullPath;
                //sublayout.Path = rendering.RenderingItem.InnerItem["Path"];
                //sublayout.Cacheable = rendering.RenderingItem.Caching.Cacheable;

                ////Not needed now but why not?
                ////if (rendering.RenderingItem.Caching.Cacheable)
                ////{
                ////    sublayout.VaryByData = rendering.RenderingItem.Caching.VaryByData;
                ////    sublayout.VaryByDevice = rendering.RenderingItem.Caching.VaryByDevice;
                ////    sublayout.VaryByLogin = rendering.RenderingItem.Caching.VaryByLogin;
                ////    sublayout.VaryByParm = rendering.RenderingItem.Caching.VaryByParm;
                ////    sublayout.VaryByQueryString = rendering.RenderingItem.Caching.VaryByQueryString;
                ////    sublayout.VaryByUser = rendering.RenderingItem.Caching.VaryByUser;
                ////}
                //phBlogs.Controls.Add(sublayout);


                //even bother with community features?
                if (!string.IsNullOrEmpty(this.CurrentMember.ScreenName))
                {
                    //should we display Blogs I Follow?
                    if (TelligentService.UserFollowsBlogs(this.CurrentMember.ScreenName))
                    {
                        sbBlogPosts.Path = this.BlogsIFollow;
                    }
                    else
                    {
                        sbBlogPosts.Path = this.RecentBlogPosts;
                    }

                    //should we display My Friends?
                    int friendCount = 0;
                    var friends = TelligentService.GetFriends(this.CurrentMember.ScreenName, 1, 1, out friendCount);

                    if (friendCount > 0)
                    {
                        sbCommunityMembers.Path = this.MyFriends;
                    }
                    else
                    {
                        sbCommunityMembers.Path = this.CommunityMembers;
                    }

                    //should we display My Groups?
                    var usersGroups = TelligentService.GetUserGroups(this.CurrentMember.ScreenName);
                    if (usersGroups.Count > 0)
                    {
                        sbGroups.Path = this.MyGroups;
                    }
                    else
                    {
                        sbGroups.Path = this.MostActiveGroups;
                    }
                }
                else
                {
                    //should we display Recommended Blogs?
                    var reccommnededBlogs = SearchHelper.GetRecommendedContent(this.CurrentMember, BlogsPostPageItem.TemplateId)
                        .Where(a => a.GetItem() != null);
                    if (reccommnededBlogs.Count() > 0)
                    {
                        sbBlogPosts.Path = this.RecommendedBlogs;
                    }
                    else
                    {
                        sbBlogPosts.Path = this.RecentBlogPosts;
                    }

                    sbGroups.Path = this.MostActiveGroups;
                    sbCommunityMembers.Path = this.CommunityMembers;

                    //TODO - implement Recommended Groups sublayout
                    //var recommendedGroups = SearchHelper.GetRecommendedContent(this.CurrentMember, GroupItem.TemplateId);
                    //if (reccommendedQuestions.Count > 0)
                    //{
                    //    sbGroups.Path = this.RecommendedGroups;
                    //}
                }
            }
            else
            {
                sbQuestions.Path = this.RecentQuestions;
                sbBlogPosts.Path = this.RecentBlogPosts;
                sbGroups.Path = this.MostActiveGroups;
                sbCommunityMembers.Path = this.CommunityMembers;
            }
        }
    }
}