using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class Parent_Group_Board : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item currItem = Sitecore.Context.Item;
            ForumItem frmItem = new ForumItem(currItem);

            if (frmItem != null)
            {
                ForumModel frmModel = new ForumModel(frmItem);

                litForumName.Text = frmModel.Name;
                if (frmModel != null)
                {
                    rptThread.DataSource = frmModel.Threads;
                    rptThread.DataBind();
                }
            }
        }
    }
}