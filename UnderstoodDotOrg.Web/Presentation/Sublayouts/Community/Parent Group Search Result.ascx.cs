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
    public partial class Parent_Group_Search_Result : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
             string _grpSrch = String.Empty;
             Item currItem = Sitecore.Context.Item;
             GroupItem grpItem = new GroupItem(currItem);

            //Retrieve group item id from session 
             if (Page.Request.QueryString != null)
             {
                 _grpSrch = Page.Request.QueryString["q"]; //Session["group_search"].ToString();

                 //Perform search


                 Session["group_search"] = null;
             }
           

            //Populate control



        }
    }
}