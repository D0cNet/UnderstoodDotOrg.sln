namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    using System;
    using System.Collections.Generic;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Framework.UI;    

    public partial class Recommendation_Icons : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            if (this.CurrentMember != null && this.CurrentMember.Children != null && this.CurrentMember.Children.Count > 0)
            {
                lvChildren.DataSource = this.CurrentMember.Children;

                //testing code
                //List<Child> children = new List<Child>();

                //MembershipManagerProxy mmp = new MembershipManagerProxy();

                //for (int i = 0; i < 6; i++)
                //{
                //    children.Add(mmp.GetChild(Guid.NewGuid()));
                //}

                //lvChildren.DataSource = children;
                lvChildren.DataBind();
            }
        }
    }
}