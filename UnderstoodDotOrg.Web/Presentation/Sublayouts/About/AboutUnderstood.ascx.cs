using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class AboutUnderstood : System.Web.UI.UserControl
    {
        AboutUnderstoodItem ObjAboutUnderstood;
        IEnumerable<PartnerInfoItem> AllPrtners;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAboutUnderstood = new AboutUnderstoodItem(Sitecore.Context.Item);

            if (ObjAboutUnderstood != null)
            {
                frSummary.Item = FrVideoTranscript.Item = ObjAboutUnderstood;
                frMissionHeadline.Item = frMissionSummary.Item = frMissionImage.Item = ObjAboutUnderstood;
                frTeamHeadline.Item = frTeamSummary.Item = frTeamImage.Item = ObjAboutUnderstood;
                frStoryHeadline.Item = frStorySummary.Item = frStoryImage.Item = ObjAboutUnderstood;
                frExpertPartnerHeadline.Item = frExpertpartnerImage.Item = frExpertpartnerSummary.Item = ObjAboutUnderstood;
                frPartnersListHeadline.Item = frPartnerListSummary.Item = ObjAboutUnderstood;
                hlPartnersListPage.NavigateUrl = Request.Url.Host.ToString() + ObjAboutUnderstood.LinktoPartnersPage;
                hlPartnersListPage.Visible = true;

                //get All Partners List to show
                AllPrtners = GetAllPArtners(ObjAboutUnderstood);
                if (AllPrtners != null)
                {
                    rptPartnerList.DataSource = AllPrtners;
                    rptPartnerList.DataBind();
                }
            }
        }

        public IEnumerable<PartnerInfoItem> GetAllPArtners(AboutUnderstoodItem CurrentPage)
        {
            IEnumerable<Item> _allpartners;
            List<PartnerInfoItem> _finalPartners;
            _allpartners = CurrentPage.PartnersContent.ListItems.Where(t => t.TemplateID.ToString() == PartnerInfoItem.TemplateId);

            _finalPartners = new List<PartnerInfoItem>(_allpartners.Count());
            foreach (PartnerInfoItem DefItem in _allpartners)
            {
                _finalPartners.Add(DefItem);
            }
            return _finalPartners;

        }

        protected void rptPartnerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                PartnerInfoItem _partnerItem = e.Item.DataItem as PartnerInfoItem;
                if (_partnerItem != null)
                {
                    FieldRenderer frPartnerLogo = e.FindControlAs<FieldRenderer>("frPartnerLogo");
                    if (frPartnerLogo != null)
                    {
                        frPartnerLogo.Item = _partnerItem;
                        HyperLink hlPartnerLogo = e.FindControlAs<HyperLink>("hlPartnerLogo");
                        if (hlPartnerLogo != null)
                        {
                            hlPartnerLogo.NavigateUrl = Request.Url.Host.ToString() + _partnerItem.InnerItem.GetUrl();
                            hlPartnerLogo.Visible = true;
                        }
                    }

                }
            }
        }
    }
}