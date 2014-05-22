using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
	public partial class GlobalsItem
	{
		public static IEnumerable<ParentRoleItem> GetParentRoles()
		{
			return Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/Parent Related/Parent Roles/*")
											.Where(i => i.TemplateID.ToString() == ParentRoleItem.TemplateId)
											.Select(i => new ParentRoleItem(i));
		}

		public static IEnumerable<ParentInterestItem> GetParentJournies()
		{
			return Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/Parent Related/Parent Journey/*")
											.Where(i => i.TemplateID.ToString() == ParentInterestItem.TemplateId)
											.Select(i => new ParentInterestItem(i))
											.OrderBy(i => i.InterestName.Raw);
		}

		public static IEnumerable<ParentInterestItem> GetParentInterests()
		{
			return Sitecore.Context.Database.SelectItems("/sitecore/content/Globals/Content Taxonomies/#Parent Related#/#Parent Interest#//*")
											.Where(i => i.TemplateID.ToString() == ParentInterestItem.TemplateId)
											.Select(i => new ParentInterestItem(i))
											.OrderBy(i => i.InterestName.Raw);
		}
	}
}