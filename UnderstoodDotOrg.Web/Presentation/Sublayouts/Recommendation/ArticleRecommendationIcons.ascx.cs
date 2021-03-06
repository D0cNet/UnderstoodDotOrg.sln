﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Helpers;
using System.Text;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class ArticleRecommendationIcons : BaseSublayout //System.Web.UI.UserControl
    {
        public List<Guid> MatchingChildrenIds { get; set; }
        public bool HasMatchingParentInterest { get; set; }

        private string child = @"<i class=""child-{1}"" title=""{0}""></i>";
        static string myString = DictionaryConstants.Core_ParentLabel;
        private string parentList = @"<i>" + myString + "</i>";

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (this.CurrentMember != null && this.CurrentMember.Children.Count > 0)
            {
                for (int i = 0; i < this.CurrentMember.Children.Count(); i++)
                {
                    if (MatchingChildrenIds.Contains(this.CurrentMember.Children.ElementAt(i).ChildId))
                    {
                        var c = this.CurrentMember.Children.ElementAt(i);

                        sb.Append(string.Format(child, TextHelper.RemoveHTML(c.Nickname), DataFormatHelper.getLetter(i)));
                    }
                }    
            }

            if (HasMatchingParentInterest)
            {
                sb.Append(parentList);
            }

            litChild.Text = sb.ToString();
        }
    }
}