using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class AboutPartnersItem
    {
        /// <summary>
        /// Get All partners List
        /// </summary>
        /// <param name="ObjSlideArticle"></param>
        /// <returns></returns>
        public static IEnumerable<PartnerInfoItem> GetAllPartners(AboutPartnersItem ObjPartnerList)
        {
            IEnumerable<PartnerInfoItem> Allpartners = ObjPartnerList.AllPartners;
            return Allpartners;
        }
        private IEnumerable<PartnerInfoItem> _allpartners;
        private IEnumerable<PartnerInfoItem> AllPartners
        {
            get
            {
                if (_allpartners == null)
                {
                    _allpartners = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == PartnerInfoItem.TemplateId.ToString())
                        .Select(x => new PartnerInfoItem(x));
                }

                return _allpartners;
            }
        }

    }
}