﻿using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
//using UnderstoodDotOrg.Services.AccessControlServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class FollowButton : BaseSublayout//System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            //Hookup the OnClick event
            lbtnFollow.Click += lbtnFollow_Click;
            
            base.OnInit(e);
        }
        private string ContentId
        {
            get
            {
                return (string)ViewState["content_id"];
            }

            set
            {
                ViewState["content_id"] = value;
            }
        }

        private string ContentTypeId { get; set; }

        private UnderstoodDotOrg.Common.Constants.TelligentContentType Type { get; set; }
        public string Text
        {
            get { return lbtnFollow.Text; }
            set { lbtnFollow.Text = value; }
        }
        
        protected void lbtnFollow_Click(object sender, EventArgs e)
        {
            this.ProfileRedirect(Constants.UserPermission.CommunityUser);
           
            switch (Type)
            {
                case Constants.TelligentContentType.BlogPost:
                    //Call Bookmarking functions
                    if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId, ContentTypeId, Type))
                    {
                        //Change Follow text
                        Text = DictionaryConstants.FollowingBlog;
                    }
                    break;
                case Constants.TelligentContentType.Forum:
                    break;
                case Constants.TelligentContentType.Group:
                    break;
                case Constants.TelligentContentType.Page:
                    break;
                case Constants.TelligentContentType.Weblog: //WIKI
                      //Call Bookmarking functions
                    if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId,ContentTypeId, Type))
                    {
                        Text = DictionaryConstants.YouAreFollowingLabel;
                    }
                    else
                    {
                        Text = DictionaryConstants.FollowThisQuestionLabel;
                    }
                    break;
                case Constants.TelligentContentType.Blog:
                    //Call Bookmarking functions
                    if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId, Type))
                    {
                        //Change Follow text
                        Text = DictionaryConstants.FollowingBlog;
                    }
                    break;
                default:
                    break;
            }

            //if (Type.Equals(UnderstoodDotOrg.Common.Constants.TelligentContentType.BlogPost))
            //{
            //    //Call Bookmarking functions
            //    if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId, ContentTypeId, Type))
            //    {
            //        //Change Follow text
            //        Text = DictionaryConstants.FollowingBlog;
            //    }
            //}
            //else
            //{
            //    //Call Bookmarking functions
            //    if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId, Type))
            //    {
            //        //Change Follow text
            //        Text = DictionaryConstants.FollowingBlog;
            //    }
            //}
        }

        //Load control state based on whether current user has bookmarked this blog
        public void LoadState(string contentId,Constants.TelligentContentType type)
        {
            LoadState(contentId,type,null);
            //ContentId = contentId;
            //Type = type;
            //Text = DictionaryConstants.FollowBlog;
            //if (CurrentMember != null)
            //{
            //    if (CurrentMember.ScreenName != null) //Additional check in case user bypasses redirect
            //    {
            //        //Should be called after properties are set
            //        switch (type)
            //        {
            //            case Constants.TelligentContentType.BlogPost:
            //                break;
            //            case Constants.TelligentContentType.Forum:
            //                break;
            //            case Constants.TelligentContentType.Group:
            //                break;
            //            case Constants.TelligentContentType.Page:
            //                break;
            //            case Constants.TelligentContentType.Weblog:
            //                break;
            //            case Constants.TelligentContentType.Blog:
            //                //Check if blog is bookmarked
            //                if (TelligentService.IsBookmarked(CurrentMember.ScreenName, contentId, type))
            //                {
            //                    Text = DictionaryConstants.FollowingBlog;
            //                }
            //                else
            //                    Text = DictionaryConstants.FollowBlog;
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}
        }
        public void LoadState(string contentId,  Constants.TelligentContentType type,string contentTypeId=null)
        {
            ContentId = contentId;
            ContentTypeId = contentTypeId;
            Type = type;

            //if (!IsPostBack)
            //{
                Text = DictionaryConstants.FollowBlog;

                switch (type)
                {
                    case Constants.TelligentContentType.BlogPost:
                        //Check if blog is bookmarked
                        if (CurrentMember != null)
                        {
                            if (CurrentMember.ScreenName != null)
                            {
                                if (!String.IsNullOrEmpty(contentTypeId))
                                {
                                    if (TelligentService.IsBookmarked(CurrentMember.ScreenName, contentId, contentTypeId, type))
                                    {
                                        Text = DictionaryConstants.FollowingBlogPost;
                                    }
                                    else
                                    {
                                        Text = DictionaryConstants.FollowBlogPost;
                                    }
                                }
                                else
                                    Text = DictionaryConstants.FollowBlogPost;
                            }
                        }
                        else
                            Text = DictionaryConstants.FollowBlogPost;
                        break;
                    case Constants.TelligentContentType.Forum:
                        break;
                    case Constants.TelligentContentType.Group:
                        break;
                    case Constants.TelligentContentType.Page:
                        break;
                    case Constants.TelligentContentType.Weblog:
                        if (CurrentMember != null)
                        {
                            if (CurrentMember.ScreenName != null)
                            {
                                if (!String.IsNullOrEmpty(contentTypeId))
                                {
                                    if (TelligentService.IsBookmarked(CurrentMember.ScreenName, contentId,contentTypeId, type ))
                                    {
                                        Text = DictionaryConstants.YouAreFollowingLabel;
                                    }
                                    else
                                    {
                                        Text = DictionaryConstants.FollowThisQuestionLabel;
                                    }
                                }
                                else
                                    Text = DictionaryConstants.FollowThisQuestionLabel;
                            }
                            
                        }
                        else
                            Text = DictionaryConstants.FollowThisQuestionLabel;
                        break;
                    case Constants.TelligentContentType.Blog:
                        //Check if blog is bookmarked
                        if (CurrentMember != null)
                        {
                            if (CurrentMember.ScreenName != null)
                            {
                                if (TelligentService.IsBookmarked(CurrentMember.ScreenName, contentId, type))
                                {
                                    Text = DictionaryConstants.FollowingBlog;
                                }
                                else
                                {
                                    Text = DictionaryConstants.FollowBlogPost;
                                }
                            }
                        }
                        else
                            Text = DictionaryConstants.FollowBlog;
                        break;
                    default:
                        break;
                }
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
    }
}