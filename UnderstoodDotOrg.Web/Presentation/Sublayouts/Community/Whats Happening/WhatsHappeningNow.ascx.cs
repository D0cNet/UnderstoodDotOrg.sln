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
        /// <summary>
        /// Private POCO to store references to sublayouts to load into page as it renders
        /// </summary>
        private class WhatsHappeningAreas
        {
            public string Events { get; set; }
            public string Questions { get; set; }
            public string CommunityMembers { get; set; }
            public string Groups { get; set; }
            public string Blogs { get; set; }

            public WhatsHappeningAreas()
            {
                this.Events = WhatsHappeningSublayouts.UpcomingEvents;
                this.Questions = WhatsHappeningSublayouts.RecentQuestions;
                this.CommunityMembers = WhatsHappeningSublayouts.CommunityMembers;
                this.Groups = WhatsHappeningSublayouts.MostActiveGroups;
                this.Blogs = WhatsHappeningSublayouts.RecentBlogPosts;
            }

            /// <summary>
            /// Public class to contain static paths to What's Happening composite sublayouts
            /// </summary>
            public class WhatsHappeningSublayouts
            {
                //public static string MyUpcomingEvents = @"";
                public static string MyFriends = @"~/Presentation/Sublayouts/Community/Whats Happening/MyFriends.ascx";
                public static string MyGroups = @"~/Presentation/Sublayouts/Community/Whats Happening/MyGroups.ascx";
                //public static string RecommendedGroups = @"";
                public static string RecommendedBlogs = @"~/Presentation/SubLayouts/Community/Whats Happening/RecommendedBlogs.ascx";
                public static string RecommendedQuestions = @"~/Presentation/SubLayouts/Community/Whats Happening/RecommendedQuestions.ascx";
                public static string BlogsIFollow = @"~/Presentation/SubLayouts/Community/Whats Happening/BlogsIFollow.ascx";

                //defaults 
                public static string UpcomingEvents = @"~/Presentation/SubLayouts/Community/Whats Happening/UpcomingEvents.ascx";
                public static string RecentQuestions = @"~/Presentation/SubLayouts/Community/Whats Happening/RecentQuestions.ascx";
                public static string CommunityMembers = @"~/Presentation/SubLayouts/Community/Whats Happening/CommunityMembers.ascx";
                public static string MostActiveGroups = @"~/Presentation/SubLayouts/Community/Whats Happening/MostActiveGroups.ascx";
                public static string RecentBlogPosts = @"~/Presentation/SubLayouts/Community/Whats Happening/RecentBlogPosts.ascx";
            }
        }
        
        protected void Page_Init(object sender, EventArgs e)
        {
            var pageAreas = new WhatsHappeningAreas();

            if (this.CurrentMember != null)
            {
                //should we display Recommended Questions?
                var reccommendedQuestions = SearchHelper.GetRecommendedContent(this.CurrentMember, QandADetailsItem.TemplateId)
                        .Where(a => a.GetItem() != null);
                if (reccommendedQuestions.Count() > 0)
                {
                    pageAreas.Questions = WhatsHappeningAreas.WhatsHappeningSublayouts.RecommendedQuestions;
                }

                //even bother with community features?
                if (!string.IsNullOrEmpty(this.CurrentMember.ScreenName))
                {
                    //should we display Blogs I Follow?
                    if (TelligentService.UserFollowsBlogs(this.CurrentMember.ScreenName))
                    {
                        pageAreas.Blogs = WhatsHappeningAreas.WhatsHappeningSublayouts.BlogsIFollow;
                    }
                    else
                    {
                        var reccommnededBlogs = SearchHelper.GetRecommendedContent(this.CurrentMember, BlogsPostPageItem.TemplateId)
                        .Where(a => a.GetItem() != null);
                        if (reccommnededBlogs.Count() > 0)
                        {
                            pageAreas.Blogs = WhatsHappeningAreas.WhatsHappeningSublayouts.RecommendedBlogs;
                        }
                    }

                    //should we display My Friends?
                    int friendCount = 0;
                    var friends = TelligentService.GetFriends(this.CurrentMember.ScreenName, 1, 1, out friendCount);

                    if (friendCount > 0)
                    {
                        pageAreas.CommunityMembers = WhatsHappeningAreas.WhatsHappeningSublayouts.MyFriends;
                    }

                    //should we display My Groups?
                    var usersGroups = TelligentService.GetUserGroups(this.CurrentMember.ScreenName);
                    if (usersGroups.Count > 0)
                    {
                        pageAreas.Groups = WhatsHappeningAreas.WhatsHappeningSublayouts.MyGroups;
                    }
                }
                else
                {
                    //should we display Recommended Blogs?
                    var reccommnededBlogs = SearchHelper.GetRecommendedContent(this.CurrentMember, BlogsPostPageItem.TemplateId)
                        .Where(a => a.GetItem() != null);
                    if (reccommnededBlogs.Count() > 0)
                    {
                        pageAreas.Blogs = WhatsHappeningAreas.WhatsHappeningSublayouts.RecommendedBlogs;
                    }

                    //TODO - implement Recommended Groups sublayout
                    //var recommendedGroups = SearchHelper.GetRecommendedContent(this.CurrentMember, GroupItem.TemplateId)
                    //.Where(a => a.GetItem() != null);
                    //if (reccommendedQuestions.Count > 0)
                    //{
                    //    sbGroups.Path = this.RecommendedGroups;
                    //}
                }
            }
            
            ProcessAreas(pageAreas);
        }

        private void ProcessAreas(WhatsHappeningAreas areas)
        {
            BindSublayout(areas.Events);
            BindSublayout(areas.Questions);
            BindSublayout(areas.CommunityMembers);
            BindSublayout(areas.Groups);
            BindSublayout(areas.Blogs);
        }

        private void BindSublayout(string path)
        {
            Sublayout sublayout = new Sublayout();
            sublayout.Path = path;
            phWhatsHappening.Controls.Add(sublayout);
        }
    }
}