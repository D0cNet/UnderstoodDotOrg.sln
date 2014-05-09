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
    public partial class AboutPartners : System.Web.UI.UserControl
    {
        AboutPartnersItem ObjAboutPartner;
        IEnumerable<PartnerInfoItem> AllPartners;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAboutPartner = new AboutPartnersItem(Sitecore.Context.Item);
            if (ObjAboutPartner != null)
            {
                AllPartners = AboutPartnersItem.GetAllPartners(ObjAboutPartner);
                if (AllPartners != null)
                {
                    rptPartnerInfo.DataSource = AllPartners;
                    rptPartnerInfo.DataBind();
                }
            }
        }

        protected void rptPartnerInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                PartnerInfoItem _partneritem = e.Item.DataItem as PartnerInfoItem;
                
                if (_partneritem != null)
                {
                    var itemLink = _partneritem.InnerItem.GetUrl();
                    FieldRenderer frPartnerName = e.FindControlAs<FieldRenderer>("frPartnerName");
                    
                    if (frPartnerName != null)
                    {
                        frPartnerName.Item = _partneritem;
                        HyperLink hlPartnerNameLink = e.FindControlAs<HyperLink>("hlPartnerNameLink");
                        if (hlPartnerNameLink != null)
                        {
                            //hlPartnerNameLink.NavigateUrl = string.Concat(Request.Url.Host.ToString(), "/", _partneritem.InnerItem.GetUrl());

                            hlPartnerNameLink.NavigateUrl = itemLink;
                            hlPartnerNameLink.Visible = true;
                        }
                    }
                    //FieldRenderer frPartnerLogo = e.FindControlAs<FieldRenderer>("frPartnerLogo");
                    //if (frPartnerLogo != null)
                    //{
                    //    frPartnerLogo.Item = _partneritem;
                    //    HyperLink hlPartnerLogo = e.FindControlAs<HyperLink>("hlPartnerLogo");
                    //    if (hlPartnerLogo != null)
                    //    {
                    //        //hlPartnerLogo.NavigateUrl = Request.Url.Host.ToString() + "/" + _partneritem.InnerItem.GetUrl();

                    //        hlPartnerLogo.NavigateUrl = _partneritem.InnerItem.GetUrl();
                    //        hlPartnerLogo.Visible = true;
                    //    }
                    //} //imgPartnerLogo

                    Sitecore.Web.UI.WebControls.Image imgPartnerLogo = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("imgPartnerLogo");
                    if (imgPartnerLogo != null)
                    {
                        imgPartnerLogo.Item = _partneritem;
                        HyperLink hlPartnerLogo = e.FindControlAs<HyperLink>("hlPartnerLogo");
                        if (hlPartnerLogo != null)
                        {
                            //hlPartnerLogo.NavigateUrl = Request.Url.Host.ToString() + "/" + _partneritem.InnerItem.GetUrl();

                            hlPartnerLogo.NavigateUrl = itemLink;
                            hlPartnerLogo.Visible = true;
                        }
                    } //imgPartnerLogo


                    FieldRenderer frPartnerDescription = e.FindControlAs<FieldRenderer>("frPartnerDescription");
                    if (frPartnerDescription != null)
                    {
                        frPartnerDescription.Item = _partneritem;
                    }
                    HyperLink hlPartnerSite = e.FindControlAs<HyperLink>("hlPartnerSite");
                    if (hlPartnerSite != null)
                    {
                        //hlPartnerSite.NavigateUrl = _partneritem.Link; // no, just no. Use the link manager to link to this item.

                        hlPartnerSite.NavigateUrl = itemLink;
                    }
                }
            }
        }
    }
}