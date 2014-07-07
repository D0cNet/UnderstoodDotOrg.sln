﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Helpers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class ArticleRecommendationIcons : BaseSublayout //System.Web.UI.UserControl
    {
        public List<Guid> MatchingChildrenIds { get; set; }
        private string child = @"<i class=""child-{1}"" title=""{0}""></i>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentMember != null && this.CurrentMember.Children.Count > 0)
            {
                for (int i = 0; i < this.CurrentMember.Children.Count(); i++)
                {
                    if (MatchingChildrenIds.Contains(this.CurrentMember.Children.ElementAt(i).ChildId))
                    {
                        var c = this.CurrentMember.Children.ElementAt(i);

                        litChild.Text += string.Format(child, TextHelper.RemoveHTML(c.Nickname), DataFormatHelper.getLetter(i));
                    }
                }    
            }
        }
    }
}