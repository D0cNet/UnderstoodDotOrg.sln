using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
    public partial class MyNotificationsPageItem
    {
        public EmailandAlertPreferencesPageItem GetEmailAndAlertPreferences()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(EmailandAlertPreferencesPageItem.TemplateId));
        }

        public PrivateMessageToolItem GetPrivateMessageTool()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(PrivateMessageToolItem.TemplateId));
        }
        public WhatsBeenHappeningItem GetWhatsBeenHappening()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(WhatsBeenHappeningItem.TemplateId));
        }
    }
}