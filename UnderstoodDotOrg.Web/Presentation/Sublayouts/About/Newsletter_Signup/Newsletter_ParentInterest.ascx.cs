using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter;
using UnderstoodDotOrg.Domain.Understood.Newsletter;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_ParentInterest : BaseSublayout<ParentInterestsPageItem>
    {
        private Submission _submission;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ParentInterestsPageItem.HasValidSession(out _submission))
            {
                Item previous = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterChildInfo);
                if (previous != null)
                {
                    Response.Redirect(previous.GetUrl());
                }
                // TODO: redirect elsewhere?
                return;
            }

            BindEvents();
            BindContent();

            if (!IsPostBack)
            {
                PopulateRepeaters();
            }
        }

        private List<ParentInterestItem> GetItemsWithin(Guid guid)
        {
            List<ParentInterestItem> results = new List<ParentInterestItem>();
            Item container = Sitecore.Context.Database.GetItem(guid);

            if (container != null)
            {
                return container.Children.FilterByContextLanguageVersion()
                            .Select(x => new ParentInterestItem(x))
                            .ToList();
            }

            return results;
        }

        private void PopulateRepeater(Repeater repeater, Guid container)
        {
            List<ParentInterestItem> results = GetItemsWithin(container);
            if (results.Any())
            {
                repeater.DataSource = results;
                repeater.DataBind();
            }
        }

        private List<Guid> GetSelectedItems(Repeater repeater)
        {
            List<Guid> selected = new List<Guid>();
            foreach (RepeaterItem ri in repeater.Items)
            {
                CheckBox cbInterest = (CheckBox)ri.FindControl("cbInterest");
                HiddenField hfInterest = (HiddenField)ri.FindControl("hfInterest");

                if (cbInterest.Checked)
                {
                    selected.Add(Guid.Parse(hfInterest.Value));
                }
            }
            return selected;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            List<Guid> interests = new List<Guid>();
            interests.AddRange(GetSelectedItems(rptSchoolIssuesLeft));
            interests.AddRange(GetSelectedItems(rptSchoolIssuesRight));
            interests.AddRange(GetSelectedItems(rptGrowingUp));
            interests.AddRange(GetSelectedItems(rptHomeLife));
            interests.AddRange(GetSelectedItems(rptSocial));
            interests.AddRange(GetSelectedItems(rptWaysToHelp));

            if (interests.Any())
            {
                _submission.Interests = interests;
            }

            // TODO: save member info

            Item next = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterConfirmation);
            if (next != null) 
            {
                Response.Redirect(next.GetUrl());
            }
        }

        void rptIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ParentInterestItem interest = (ParentInterestItem)e.Item.DataItem;
                Literal litInterest = e.FindControlAs<Literal>("litInterest");
                HiddenField hfInterest = e.FindControlAs<HiddenField>("hfInterest");

                litInterest.Text = interest.InterestName.Raw;
                hfInterest.Value = interest.ID.ToString();
            }
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
            rptGrowingUp.ItemDataBound += rptIssues_ItemDataBound;
            rptHomeLife.ItemDataBound += rptIssues_ItemDataBound;
            rptSchoolIssuesLeft.ItemDataBound += rptIssues_ItemDataBound;
            rptSchoolIssuesRight.ItemDataBound += rptIssues_ItemDataBound;
            rptSocial.ItemDataBound += rptIssues_ItemDataBound;
            rptWaysToHelp.ItemDataBound += rptIssues_ItemDataBound;
        }

        private void BindContent()
        {
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;
        }

        private void PopulateRepeaters()
        {
            PopulateRepeater(rptGrowingUp, Constants.GrowingUpContainer);
            PopulateRepeater(rptHomeLife, Constants.HomeLifeContainer);
            PopulateRepeater(rptSocial, Constants.SocialEmotionalContainer);
            PopulateRepeater(rptWaysToHelp, Constants.WaysToHelpContainer);

            var issues = GetItemsWithin(Constants.SchoolIssueContainer);
            if (issues.Any())
            {
                int leftSize = (int)Math.Ceiling(issues.Count / 2m);
                rptSchoolIssuesLeft.DataSource = issues.Take(leftSize);
                rptSchoolIssuesLeft.DataBind();
                rptSchoolIssuesRight.DataSource = issues.Skip(leftSize);
                rptSchoolIssuesRight.DataBind();
            }
        }
    }
}