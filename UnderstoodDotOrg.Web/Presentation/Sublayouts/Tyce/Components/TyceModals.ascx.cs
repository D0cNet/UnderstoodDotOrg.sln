using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TyceModals : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbLetsGo.Click += lbLetsGo_Click;
            //TODO: Wire up "let me customize" link to my profile
        }

        protected void lbLetsGo_Click(object sender, EventArgs e)
        {
            var questionsPageItem = Sitecore.Context.Item.Children
                .FirstOrDefault(i => i.IsOfType(TyceQuestionsPageItem.TemplateId));

            if (questionsPageItem != null)
            {
                Response.Redirect(questionsPageItem.GetUrl());
                //TODO: Add logic for handling passing selected child to questions page
            }
        }
    }
}