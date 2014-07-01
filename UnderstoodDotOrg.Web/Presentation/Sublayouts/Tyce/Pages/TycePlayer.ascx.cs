﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages
{
    public partial class TycePlayer : BaseSublayout<TycePlayerPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hypLogoLink.NavigateUrl = MainsectionItem.GetHomeItem().GetUrl();
            hypLogoLink.ImageUrl = Model.HeaderLogo.GetImageUrl();

            backLink.Attributes.Add("href", Model.InnerItem.Parent.GetUrl());
        }
    }
}