﻿using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData {
    public partial class WelcomeTour : System.Web.UI.Page {
        /// <summary>
        /// Gets footer item from global
        /// </summary>
        /// <returns></returns>
        public static WelcomeTourFolderItem GetWelcomeTourFolder() {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            WelcomeTourFolderItem objWelcomeTourFolderItem = null;
            if (objSiteItem != null) {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null) {
                    objWelcomeTourFolderItem = objGlobalItem.GetWelcomeTourFolder();
                }
            }
            return objWelcomeTourFolderItem;
        }

        protected void Page_Load(object sender, EventArgs e) {
            WelcomeTourFolderItem welcomeTourFolder = GetWelcomeTourFolder();
            if (welcomeTourFolder != null)
                frHeader.Item = frSubHeader.Item = welcomeTourFolder.InnerItem;

            var result = GetWelcomeTourItem(welcomeTourFolder);
            if (result != null && result.Any()) {
                rptWelcomeSlider.DataSource = result;
                rptWelcomeSlider.DataBind();
            }
            else {
                this.Visible = true;
            }
            //Response.Write(result.Count());
            //Response.End();
        }

        private IEnumerable<WelcomeTourItem> GetWelcomeTourItem(WelcomeTourFolderItem welcomeTourFolder) {
            return welcomeTourFolder.InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(WelcomeTourItem.TemplateId)).Select(i => (WelcomeTourItem)i);
        }

        protected void rptWelcomeSlider_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                WelcomeTourItem item = e.Item.DataItem as WelcomeTourItem;
                if (item != null) {
                    Sitecore.Web.UI.WebControls.Image scBackgroundImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scBackgroundImage");
                    FieldRenderer frContent = e.FindControlAs<FieldRenderer>("frContent");
                    Link scLinkJoin = e.FindControlAs<Link>("scLinkJoin");
                    Link scLinkNotNow = e.FindControlAs<Link>("scLinkNotNow");

                    if (frContent != null) {
                        frContent.Item = item;
                    }

                    if (scBackgroundImage != null) {
                        scBackgroundImage.Item = item;
                    }

                    if (scLinkJoin != null) {
                        scLinkJoin.Item = item;
                    }

                    if (scLinkNotNow != null) {
                        scLinkNotNow.Item = item;
                    }
                }
            }
        }
    }


}