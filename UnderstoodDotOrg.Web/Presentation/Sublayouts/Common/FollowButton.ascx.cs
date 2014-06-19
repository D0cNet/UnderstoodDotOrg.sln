﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

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
                return ViewState["content_id"].ToString();
            }

            set
            {
                ViewState["content_id"] = value;
            }
        }

        private UnderstoodDotOrg.Common.Constants.TelligentContentType Type { get; set; }
        public string Text
        {
            get { return lbtnFollow.Text; }
            set { lbtnFollow.Text = value; }
        }
        
        protected void lbtnFollow_Click(object sender, EventArgs e)
        {
            if (CurrentMember != null)
            {
                //Call Bookmarking functions
                if (TelligentService.CreateFavorite(CurrentMember.ScreenName, ContentId, Type))
                {
                    //Change Follow text
                    Text = DictionaryConstants.FollowingBlog;
                }
            }
            else
            {
                ///TODO: send to registration page
            }
        }

        //Load control state based on whether current user has bookmarked this blog
        public void LoadState(string contentId,Constants.TelligentContentType type)
        {
            ContentId = contentId;
            Type = type;
            Text = DictionaryConstants.FollowBlog;
            if (CurrentMember != null)
            {
                //Should be called after properties are set
                switch (type)
                {
                    case Constants.TelligentContentType.BlogPost:
                        break;
                    case Constants.TelligentContentType.Forum:
                        break;
                    case Constants.TelligentContentType.Group:
                        break;
                    case Constants.TelligentContentType.Page:
                        break;
                    case Constants.TelligentContentType.Weblog:
                        break;
                    case Constants.TelligentContentType.Blog:
                        //Check if blog is bookmarked
                        if (TelligentService.IsBookmarked(CurrentMember.ScreenName, contentId, type))
                        {
                            Text = DictionaryConstants.FollowingBlog;
                        }
                        else
                            Text = DictionaryConstants.FollowBlog;
                        break;
                    default:
                        break;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
    }
}