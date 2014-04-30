using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts
{
    public partial class AboutExperts : System.Web.UI.UserControl
    {
        AboutExpertsItem ObjAboutExperts;
        IEnumerable<ExpertPersonItem> Allexperts;
        static int _rowCnt = 1, _expertat = 1, RowCounter = 0;
        object[][] _jaggedArray;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAboutExperts = new AboutExpertsItem(Sitecore.Context.Item);
            if (ObjAboutExperts != null)
            {
                frAboutExpertIntroduction.Item = frExpertsDetailsHeadline.Item = ObjAboutExperts;
                //get List of Experts
                Allexperts = AboutExpertsItem.GetAllExperts(ObjAboutExperts);
                
                if (Allexperts != null)
                {
                    _rowCnt = _expertat = 1;

                    if (Allexperts.Count() > 3)
                    {
                        if (Allexperts.Count() % 3 != 0)
                        {
                            RowCounter = (Allexperts.Count() / 3) + 1;
                        }
                        else
                        {
                            RowCounter = Allexperts.Count() / 3;
                        }
                    }

                    List<ExpertPersonItem> _listExpert = new List<ExpertPersonItem>(Allexperts.Count());
                    foreach (ExpertPersonItem expert in Allexperts)
                    {
                        _listExpert.Add(expert);
                    }
                    int _objectat = 0;
                    if (RowCounter != 0)
                    {
                        _jaggedArray = new object[RowCounter][];

                        for (int i = 0; i < RowCounter; i++)
                        {
                            _jaggedArray[i] = new object[3];
                            for (int j = 0; j < 3; j++)
                            {
                                _jaggedArray[i][j] = _listExpert[_objectat];
                                _objectat++;
                            }
                        }

                    }

                    string[] SetCss = new string[RowCounter];
                    SetCss[0] = "  skiplink-content";
                    for (int i=1 ; i<=RowCounter-1;i++)
                        {
                            SetCss[1] = "Simple";
                        }
                    
                    rptSetCss.DataSource = SetCss;
                    rptSetCss.DataBind();
                    // rptExperts.DataSource = Allexperts;
                    //rptExperts.DataBind();

                }
            }
        }

        //protected void rptExperts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.IsItem())
        //    {
        //        Panel pnlRowList = e.FindControlAs<Panel>("pnlRowList");
        //        if (pnlRowList != null)
        //        {
        //            if (_rowCnt <= 3)
        //            {
        //                pnlRowList.CssClass += "  skiplink-content";
        //                _rowCnt += 1;
        //            }

        //            Panel pnlExprtAt = e.FindControlAs<Panel>("pnlExprtAt");
        //            if (pnlExprtAt != null)
        //            {
        //                if (_expertat <= 1)
        //                {
        //                    pnlExprtAt.CssClass += "1";
        //                }
        //                if (_expertat == 2)
        //                {
        //                    pnlExprtAt.CssClass += "2";
        //                }
        //                if (_expertat >= 3)
        //                {
        //                    pnlExprtAt.CssClass += "2";
        //                    _expertat = 1;
        //                }
        //            }
        //            ExpertPersonItem _expertPerson = e.Item.DataItem as ExpertPersonItem;
        //            if (_expertPerson != null)
        //            {
        //                FieldRenderer frExpertImage = e.FindControlAs<FieldRenderer>("frExpertImage");
        //                if (frExpertImage != null)
        //                {
        //                    frExpertImage.Item = _expertPerson;
        //                }
        //                FieldRenderer frFullName = e.FindControlAs<FieldRenderer>("frFullName");
        //                if (frFullName != null)
        //                {
        //                    frFullName.Item = _expertPerson;
        //                }
        //                FieldRenderer frTitleandInstitution = e.FindControlAs<FieldRenderer>("frTitleandInstitution");
        //                if (frTitleandInstitution != null)
        //                {
        //                    frTitleandInstitution.Item = _expertPerson;
        //                }
        //                if (string.IsNullOrEmpty(_expertPerson.TwitterLink.Text) == false)
        //                {
        //                    HyperLink hlTwitterLink = e.FindControlAs<HyperLink>("hlTwitterLink");
        //                    if (hlTwitterLink != null)
        //                    {
        //                        hlTwitterLink.NavigateUrl = _expertPerson.TwitterLink;
        //                        hlTwitterLink.Visible = true;
        //                    }
        //                }
        //                if (_expertPerson.ShowBioPage.Checked == true)
        //                {
        //                    HyperLink hlBioPageLink = e.FindControlAs<HyperLink>("hlBioPageLink");
        //                    if (hlBioPageLink != null)
        //                    {
        //                        hlBioPageLink.NavigateUrl = _expertPerson.InnerItem.GetUrl();
        //                        hlBioPageLink.Visible = true;
        //                    }
        //                }
        //                if (string.IsNullOrEmpty(_expertPerson.BlogPageLink) == false)
        //                {
        //                    HyperLink hlBlogPageLink = e.FindControlAs<HyperLink>("hlBlogPageLink");
        //                    if (hlBlogPageLink != null)
        //                    {
        //                        hlBlogPageLink.NavigateUrl = _expertPerson.BlogPageLink;
        //                        hlBlogPageLink.Visible = true;
        //                    }

        //                }
        //                Repeater rptParticipations = e.FindControlAs<Repeater>("rptParticipations");
        //                if (rptParticipations != null)
        //                {
        //                    IEnumerable<Item> _ParticipationList = _expertPerson.Participation.ListItems.Where(t => t.TemplateID.ToString() == MetadataItem.TemplateId);
        //                    if (_ParticipationList != null)
        //                    {
        //                        rptParticipations.DataSource = _ParticipationList;
        //                        rptParticipations.DataBind();
        //                    }
        //                }

        //            }
        //        }
        //        _expertat += 1;

        //    }
        //}

        protected void rptParticipations_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                MetadataItem _Participation = e.Item.DataItem as MetadataItem;
                if (_Participation != null)
                {
                    FieldRenderer frParticipation = e.FindControlAs<FieldRenderer>("frParticipation");
                    if (frParticipation != null)
                    {
                        frParticipation.Item = _Participation;
                    }
                }
            }
        }

        protected void rpt3Expert_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Panel pnlExprtAt = e.FindControlAs<Panel>("pnlExprtAt");
            if (pnlExprtAt != null)
            {
                if (_expertat <= 1)
                {
                    pnlExprtAt.CssClass += "1";
                }
                if (_expertat == 2)
                {
                    pnlExprtAt.CssClass += "2";
                }
                if (_expertat >= 3)
                {
                    pnlExprtAt.CssClass += "2";
                    _expertat = 1;
                }
                if ( _expertat!=1)
                {
                 _expertat += 1;
                }
            }
           
            ExpertPersonItem _expertPerson = e.Item.DataItem as ExpertPersonItem;
            if (_expertPerson != null)
            {
                FieldRenderer frExpertImage = e.FindControlAs<FieldRenderer>("frExpertImage");
                if (frExpertImage != null)
                {
                    frExpertImage.Item = _expertPerson;
                }
                FieldRenderer frFullName = e.FindControlAs<FieldRenderer>("frFullName");
                if (frFullName != null)
                {
                    frFullName.Item = _expertPerson;
                }
                FieldRenderer frTitleandInstitution = e.FindControlAs<FieldRenderer>("frTitleandInstitution");
                if (frTitleandInstitution != null)
                {
                    frTitleandInstitution.Item = _expertPerson;
                }
                if (string.IsNullOrEmpty(_expertPerson.TwitterLink.Text) == false)
                {
                    HyperLink hlTwitterLink = e.FindControlAs<HyperLink>("hlTwitterLink");
                    if (hlTwitterLink != null)
                    {
                        hlTwitterLink.NavigateUrl = _expertPerson.TwitterLink;
                        hlTwitterLink.Visible = true;
                    }
                }
                if (_expertPerson.ShowBioPage.Checked == true)
                {
                    HyperLink hlBioPageLink = e.FindControlAs<HyperLink>("hlBioPageLink");
                    if (hlBioPageLink != null)
                    {
                        hlBioPageLink.NavigateUrl = _expertPerson.InnerItem.GetUrl();
                        hlBioPageLink.Visible = true;
                    }
                }
                if (string.IsNullOrEmpty(_expertPerson.BlogPageLink) == false)
                {
                    HyperLink hlBlogPageLink = e.FindControlAs<HyperLink>("hlBlogPageLink");
                    if (hlBlogPageLink != null)
                    {
                        hlBlogPageLink.NavigateUrl = _expertPerson.BlogPageLink;
                        hlBlogPageLink.Visible = true;
                    }

                }
                Repeater rptParticipations = e.FindControlAs<Repeater>("rptParticipations");
                if (rptParticipations != null)
                {
                    IEnumerable<Item> _ParticipationList = _expertPerson.Participation.ListItems.Where(t => t.TemplateID.ToString() == MetadataItem.TemplateId);
                    if (_ParticipationList != null)
                    {
                        rptParticipations.DataSource = _ParticipationList;
                        rptParticipations.DataBind();
                    }
                }

            }

        }

        protected void rptSetCss_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string _cssname = e.Item.DataItem as string;
            if (_cssname != "") 
            
            {
                if (_cssname == "  skiplink-content")
                {
                    Panel PnlRawCss = e.FindControlAs<Panel>("PnlRawCss");
                    if (PnlRawCss != null)
                    {
                        PnlRawCss.CssClass += _cssname;
                        Repeater rpt3Expert = e.FindControlAs<Repeater>("rpt3Expert");
                        if(rpt3Expert!=null)
                        {
                            rpt3Expert.DataSource=_jaggedArray[0];
                            rpt3Expert.DataBind();
                        }


                        _rowCnt = 1; 
                    }

                }
                else
                {
                    if (_rowCnt <= RowCounter - 1)
                    {
                        Panel PnlRawCss = e.FindControlAs<Panel>("PnlRawCss");
                        if (PnlRawCss != null)
                        {
                            PnlRawCss.CssClass += "";
                            Repeater rpt3Expert = e.FindControlAs<Repeater>("rpt3Expert");
                            if (rpt3Expert != null)
                            {
                                rpt3Expert.DataSource = _jaggedArray[_rowCnt];
                                rpt3Expert.DataBind();
                            }

                            _rowCnt += 1;
                        }
                    }
                }

            }
        }
    }


}