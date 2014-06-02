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

        public IEnumerable<string> GetTermAnchorList()
        {
            return AllGlossaryTerms
               .Select(x => x.GlossaryTermTitle.Text.Substring(0, 1).ToUpper())
               .Distinct();
        }

        public static IEnumerable<GlossaryTermItem> GetRelatedTermsInfo(GlossaryPageItem ObjGlossaryArt, string Termletter)
        {
            IEnumerable<GlossaryTermItem> AllRelatedterms = ObjGlossaryArt.InnerItem.GetChildren()
                         .Where(t => t.TemplateID.ToString() == GlossaryTermItem.TemplateId.ToString())
                         .Select(x => new GlossaryTermItem(x))
                         .Where(x => x.GlossaryTermTitle.Text.Substring(0, 1).ToUpper() == Termletter);
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