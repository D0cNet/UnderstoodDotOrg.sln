using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.CSS;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.JS;
namespace UnderstoodDotOrg.Web.Presentation.Layouts
{
    public partial class Browser : System.Web.UI.Page
    {
        private BasePageNEWItem _pageItem;
        protected BasePageNEWItem PageItem
        {
            get
            {
                return (_pageItem = _pageItem ?? Sitecore.Context.Item);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
                RedirectIfRequiresSecure();

                if (Request.Cookies["ShowWelcomeTour"] == null || string.IsNullOrEmpty(Request.Cookies["ShowWelcomeTour"].Value))
                {
                    Response.Cookies["ShowWelcomeTour"].Value = Guid.NewGuid().ToString();
                    Response.Cookies["ShowWelcomeTour"].Expires = DateTime.MaxValue;
                    if (!PageItem.ShowWelcomeTour.Raw.IsNullOrEmpty())
                    {
                        ltWelcomeTour.Text = "<div data-show-welcome-tour=\"true\" id=\"community-page\"></div>";
                    }
                }

                if (!PageItem.MetaTitle.Raw.IsNullOrEmpty())
                {
                    this.Title = PageItem.MetaTitle.Raw; // do not use Rendered since this will make the <title> a mess in Page Editor
                }

				//if (ContextItem != null && ContextItem.InheritsTemplate(CSSTemplateItem.TemplateId))
				//{
				CSSTemplateItem cssTemplate = PageItem.InnerItem;

				string cssInsert = "<link href=\"{0}\" rel=\"stylesheet\" />";
				var css = this.FindControl("headerSectionCSS") as Literal;

				if (css != null && cssTemplate != null && cssTemplate.CSSInclude.ListItems.Count > 0)
				{
					foreach (var item in cssTemplate.CSSInclude.ListItems)
					{
						CSSItem cssItem = item;

						if (cssItem != null && !string.IsNullOrEmpty(cssItem.CSSFilename.Text) && !string.IsNullOrEmpty(cssItem.CSSFilepath.Text))
						{
							css.Text += string.Format(cssInsert, cssItem.CSSFilepath.Text + cssItem.CSSFilename.Text);
						}
					}
				}
				//}

				//if (ContextItem != null && ContextItem.InheritsTemplate(JSTemplateItem.TemplateId))
				//{
				JSTemplateItem jsTemplate = PageItem.InnerItem;

				string jsInsert = "<script src=\"{0}\"></script>";
				var js = this.FindControl("footerSectionJS") as Literal;

				if (js != null && jsTemplate != null && jsTemplate.JSInclude.ListItems.Count > 0)
				{
					foreach (var item in jsTemplate.JSInclude.ListItems)
					{
						JSItem jsItem = item;

						if (jsItem != null && !string.IsNullOrEmpty(jsItem.JSFilename.Text) && !string.IsNullOrEmpty(jsItem.JSFilepath.Text))
						{
							js.Text += string.Format(jsInsert, jsItem.JSFilepath.Text + jsItem.JSFilename.Text);
						}
					}
				}
			}

            //}
        }

        private void RedirectIfRequiresSecure()
        {
            if (PageItem.IsSecurePage.Checked)
            {
                if (!Request.IsLocal && !Request.IsSecureConnection)
                {
                    Response.Redirect(Uri.UriSchemeHttps + Uri.SchemeDelimiter + Request.Url.Authority + Request.Url.PathAndQuery, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}