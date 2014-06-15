﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class MyNotificationsTabs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetEmailAndAlertPreferences().InnerItem.TemplateID.ToString())
                {
                    liEmailPreferencesTab.Attributes["class"] += "active";
                }

                if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetPrivateMessageTool().InnerItem.TemplateID.ToString())
                {
                    liMessagesTab.Attributes["class"] += "active";
                }

                if (Sitecore.Context.Item.TemplateID.ToString() == MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().InnerItem.TemplateID.ToString())
                {
                    liNotificationsTab.Attributes["class"] += "active";
                }
                hypWhatsHappening.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetUrl();
                hypEmailAndAlertPreferences.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetEmailAndAlertPreferences().InnerItem.GetUrl();
                hypPrivateMessages.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetPrivateMessageTool().InnerItem.GetUrl();
            }
        }
    }
}