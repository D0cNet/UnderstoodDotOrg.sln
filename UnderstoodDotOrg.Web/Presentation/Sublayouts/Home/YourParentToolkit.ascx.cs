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
using UnderstoodDotOrg.Framework.UI;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home
{
    public partial class YourParentToolkit : BaseSublayout<HomePageItem>
    {
        int toolsCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<NavigationLinkItem> toolkitItems = Enumerable.Empty<NavigationLinkItem>();
            HomePageItem ContextItem = Sitecore.Context.Item;
            if (Model.YourParentToolkitList != null && Model.YourParentToolkitList.Item != null)
            {
                toolkitItems = Model.YourParentToolkitList.Item.GetChildren()
                                    .Select(x => new NavigationLinkItem(x));

                // Exclude nav items which require login
                if (!IsUserLoggedIn)
                {
                    toolkitItems = toolkitItems.Where(i => !i.DisplayOnlyForLoggedInUsers.Checked);
                }

                if (toolkitItems.Any())
                {
                    toolsCount = toolkitItems.Count();
                    rptEventCarousel.DataSource = toolkitItems;
                    rptEventCarousel.DataBind();
                }
            }

            if (ContextItem.WidgetLink.Item != null && ContextItem.WidgetLink.Item.IsOfType(WidgetItem.TemplateId))
            {
                Item widgetItem = ContextItem.WidgetLink.Item;
                frWidgetTitle.Item = widgetItem;
                frWidgetDetail.Item = widgetItem;

                if (!IsPostBack)
                {
                    BindDDL();
                }
            }
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;
        }

        public void BindDDL()
        {

            var challenges = FormHelper.GetChallenges(DictionaryConstants.SelectChallenge);
            if (challenges.Any())
            {
                ddlChallenges.DataSource = challenges;
                ddlChallenges.DataTextField = "Text";
                ddlChallenges.DataValueField = "Value";
                ddlChallenges.DataBind();
            }

            var grades = FormHelper.GetGrades(DictionaryConstants.SelectGradeLabel);
            if (grades.Any())
            {
                ddlGrades.DataSource = grades;
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();
            }
        }

        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (btnSubmit != null)
            {
                Response.Redirect(FormHelper.GetBehaviorResultsUrl(ddlChallenges.SelectedValue, ddlGrades.SelectedValue));
            }
        }

        protected void rptEventCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem navItem = (NavigationLinkItem)e.Item.DataItem;
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

                    //if ((toolsCount == cindex) && ((cindex) % 2 == 1)) {
                    //    //LI PADDING ADD  
                    //    liItem.Attributes.Add("style", "padding-right:25px;");

                    //}

                }
                if (divIcon != null && navItem.Image.MediaItem != null)
                {
                    //divIcon.Attributes.Add("style", "background: url(" + objNavItem.Image.MediaUrl + ") no-repeat scroll 0 0 / 100px 100px rgba(0, 0, 0, 0)");
                    divIcon.Attributes.Add("style", "background-image: url(" + navItem.Image.MediaUrl + ");background-repeat:no-repeat;");
                }
                if (scLink != null)
                {
                    scLink.Item = navItem;
                }


            }

        }
    }
}