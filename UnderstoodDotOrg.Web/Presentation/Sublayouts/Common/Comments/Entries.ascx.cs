using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Comments
{
    public partial class Entries : System.Web.UI.UserControl
    {
        public List<Comment> Comments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            if (Comments != null && Comments.Any())
            {
                rptComments.DataSource = Comments;
                rptComments.DataBind();
            }
        }
    }
}