using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using Sitecore.Data.Items;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home
{
    public partial class YourParentToolkit : System.Web.UI.UserControl
    {
        int toolsCount = 0;
        int nextUlStart = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            HomePageItem ContextItem = Sitecore.Context.Item;
            List<Item> toolKititems = null;
            if (ContextItem.YourParentToolkitList != null)
            {
                toolKititems = ContextItem.YourParentToolkitList.Item.GetChildren().ToList();
                if (toolKititems.Any())
                {
                    toolsCount = toolKititems.Count();
                    rptEventCarousel.DataSource = toolKititems;
                    rptEventCarousel.DataBind();

                }
            }

        }

        protected void rptEventCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ParentToolkitFolderItem objParent = e.Item.DataItem as Item;
                Item objNav = e.Item.DataItem as Item;
                NavigationLinkItem objNavItem = new NavigationLinkItem(objNav);
                Link scLink = e.FindControlAs<Link>("scLink");
                Literal litDevStart = e.FindControlAs<Literal>("litDevStart");
                Literal litStartUL = e.FindControlAs<Literal>("litStartUL");
                Literal litEndUL = e.FindControlAs<Literal>("litEndUL");
                Literal litDivEnd = e.FindControlAs<Literal>("litDivEnd");
                HyperLink hlLink = e.FindControlAs<HyperLink>("hlLink");
                HtmlGenericControl divIcon = e.FindControlAs<HtmlGenericControl>("divIcon");

                if (litDevStart != null && litStartUL != null && litEndUL != null && litDivEnd != null)
                {
                    int cindex = e.Item.ItemIndex + 1;
                    if (cindex == 1)
                    {
                        litDevStart.Visible = litStartUL.Visible = true;
                    }
                    if ((cindex) % 2 == 0 && (cindex) != 1)
                    {
                        litEndUL.Visible = true;
                    }
                    //if ((cindex) % 3 == 0 && (cindex) != 1) {
                    //    litStartUL.Visible = true;
                    //}
                    //if ((cindex) == 3) {
                    //    litStartUL.Visible = true;
                    //    nextUlStart = cindex + 4;
                    //}
                    //if (cindex == nextUlStart) {
                    //    litStartUL.Visible = true;
                    //}

                    if ((cindex) % 2 == 1 && (cindex) != 1)
                    {
                        litStartUL.Visible = true;
                    }



                    if ((cindex) % 4 == 0 && (cindex) != 1)
                    {
                        litDivEnd.Visible = true;
                    }

                    //if ((cindex) % 5 == 0 && (cindex) != 1) {
                    //    litDevStart.Visible = true;
                    //    litStartUL.Visible = true;
                    //}
                    if ((cindex) % 4 == 1 && (cindex) != 1)
                    {
                        litDevStart.Visible = true;
                        //litStartUL.Visible = true;
                    }

                    //if (rptEventCarousel.Items.Count == cindex) {
                    if (toolsCount == cindex)
                    {
                        litEndUL.Visible = true;
                        litDivEnd.Visible = true;
                    }

                }
                if (objNav != null)
                {
                    if (divIcon != null)
                    {
                        //divIcon.Attributes.Add("style", "background: url(" + objNavItem.Image.MediaUrl + ") no-repeat scroll 0 0 / 100px 100px rgba(0, 0, 0, 0)");
                        divIcon.Attributes.Add("style", "background-image: url(" + objNavItem.Image.MediaUrl + ");background-repeat:no-repeat;");
                    }
                    if (scLink != null)
                    {
                        scLink.Item = objNav;
                    }
                }


            }

        }
    }
}