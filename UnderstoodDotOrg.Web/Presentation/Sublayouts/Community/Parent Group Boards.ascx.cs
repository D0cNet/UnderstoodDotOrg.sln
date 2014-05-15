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
    public partial class Parent_Group_Boards : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            
            if (Page.Request.QueryString["groupsearch"] != null)
            {
                pnlDefaultSection.Visible = false;
                pnlSearchSection.Visible = true;

            }
            else
            {
                Item currItem = Sitecore.Context.Item;
                GroupItem grpItem = new GroupItem(currItem);
                pnlDefaultSection.Visible = true;
                pnlSearchSection.Visible = false;
                if (grpItem != null)
                {
                    GroupCardModel grpModel = new GroupCardModel(grpItem);
                    if (grpModel != null)
                    {
                        rptForums.DataSource = grpModel.Forums;
                        rptForums.DataBind();
                    }
                }

              
            }

           
        }

        protected void rptForums_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptThreads");
            if (childModel_repeater != null)
            {
                childModel_repeater.DataSource = ((ForumModel)e.Item.DataItem).Threads;
                childModel_repeater.DataBind();
            }

        }

        protected void rptThreads_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}