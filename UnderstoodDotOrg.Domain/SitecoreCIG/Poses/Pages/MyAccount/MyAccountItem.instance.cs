using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
    public partial class MyAccountItem
    {
        public AccountCommentsPageItem GetAccountCommentsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AccountCommentsPageItem.TemplateId));
        }

        public AccountConnectionsPageItem GetAccountConnectionsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AccountConnectionsPageItem.TemplateId));
        }

        public AccountEventsPageItem GetAccountEventsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AccountEventsPageItem.TemplateId));
        }

        public AccountFavoritesPageItem GetAccountFavoritesPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AccountFavoritesPageItem.TemplateId));
        }

        public AccountGroupsPageItem GetAccountGroupsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AccountGroupsPageItem.TemplateId));
        }
    }
}