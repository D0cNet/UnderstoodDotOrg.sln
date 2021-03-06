using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount
{
    public partial class PublicAccountItem
    {
        public PublicAccountProfileItem GetPublicAccountProfilePage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(PublicAccountProfileItem.TemplateId));
        }

        public PublicAccountCommentsItem GetPublicAccountCommentsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(PublicAccountCommentsItem.TemplateId));
        }

        public PublicAccountConnectionsItem GetPublicAccountConnectionsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(PublicAccountConnectionsItem.TemplateId));
        }
    }
}