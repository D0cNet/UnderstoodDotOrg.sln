using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Glossarypage;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
    public partial class GlossaryPageItem
    {

        public static IEnumerable<string> GetTermAnchorList(GlossaryPageItem ObjGlossArt)
        {
            //IEnumerable<string> Allterms = ObjGlossArt.InnerItem.GetChildren()
            //    .Where(t => t.TemplateID.ToString() == GlossaryTermItem.TemplateId)
            //    .Select(x => new GlossaryTermItem(x))
            //    .Select(x => x.GlossaryTermTitle.Text.Substring(0, 1))
            //    .Distinct();
            IEnumerable<string> Allterms = ObjGlossArt.AllGlossaryTerms
               .Select(x => x.GlossaryTermTitle.Text.Substring(0, 1))
               .Distinct();
            return Allterms;

        }
        public static IEnumerable<GlossaryTermItem> GetRelatedTermsInfo(GlossaryPageItem ObjGlossaryArt, string Termletter)
        {
            IEnumerable<GlossaryTermItem> AllRelatedterms = ObjGlossaryArt.InnerItem.GetChildren()
                         .Where(t => t.TemplateID.ToString() == GlossaryTermItem.TemplateId.ToString())
                         .Select(x => new GlossaryTermItem(x))
                         .Where(x => x.GlossaryTermTitle.Text.Substring(0, 1) == Termletter);
            return AllRelatedterms;
        }

        private IEnumerable<GlossaryTermItem> _allGlossaryTerms;
        private IEnumerable<GlossaryTermItem> AllGlossaryTerms
        {
            get
            {
                if (_allGlossaryTerms == null)
                {
                    _allGlossaryTerms = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == GlossaryTermItem.TemplateId.ToString())
                        .Select(x => new GlossaryTermItem(x));
                }

                return _allGlossaryTerms;
            }
        }
    }



}