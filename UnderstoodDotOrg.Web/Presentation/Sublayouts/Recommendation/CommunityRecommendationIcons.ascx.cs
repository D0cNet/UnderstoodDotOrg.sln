using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class CommunityRecommendationIcons : BaseSublayout //System.Web.UI.UserControl
    {
        public List<Guid> MatchingChildrenIds { get; set; }
        public bool HasMatchingParentInterest { get; set; }

        private string child = @"<li><i class=""child-{1}"" title=""{0}""></i></li>";
        static string myString = DictionaryConstants.Core_ParentLabel;
        private string parentList = @"<li><i>" + myString + "</i></li>";

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