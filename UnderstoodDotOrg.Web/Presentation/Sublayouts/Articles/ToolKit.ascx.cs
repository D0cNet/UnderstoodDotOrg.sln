using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General.ToolkitArticlePageTools;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class ToolKit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptDownloads.DataSource = Sitecore.Context.Item.Children;
            rptDownloads.DataBind();

            DefaultArticlePageItem context = Sitecore.Context.Item;

        }

        protected void rptDownloads_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item dataItem = e.Item.DataItem as Item;
                FieldRenderer frTitle = e.FindControlAs<FieldRenderer>("frTitle");
                HtmlGenericControl iconType = e.FindControlAs<HtmlGenericControl>("iconType");
                HtmlGenericControl fileSize = e.FindControlAs<HtmlGenericControl>("fileSize");
                HyperLink hypActionLink = e.FindControlAs<HyperLink>("hypActionLink");
                HyperLink hypTitle = e.FindControlAs<HyperLink>("hypTitle");
                LinkField lf = dataItem.Fields["Link"];

                if (frTitle != null)
                {
                    frTitle.Item = dataItem;
                }

                if (hypActionLink != null)
                {
                    hypActionLink.Text = dataItem.Fields["Action Text"].ToString();
                }

                string itemLink = string.Empty;

                if (dataItem.IsOfType(PDFToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "pdf");

                    itemLink = ResolveMediaURL(dataItem);
                }
                else if (dataItem.IsOfType(VideoToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "video");

                    //itemLink = ResolveMediaURL(dataItem);
                    if (lf.TargetItem != null)
                        itemLink = LinkManager.GetItemUrl(lf.TargetItem);
                }
                else if (dataItem.IsOfType(AudioToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "audio");

                    //itemLink = ResolveMediaURL(dataItem);
                    if (lf.TargetItem != null)
                        itemLink = LinkManager.GetItemUrl(lf.TargetItem);
                }
                else if (dataItem.IsOfType(WordToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "word");

                    Sitecore.Data.Fields.FileField fileField = ((Sitecore.Data.Fields.FileField)dataItem.Fields["Link"]);

                    itemLink = ResolveMediaURL(fileField.MediaItem);
                }
                else if (dataItem.IsOfType(ArticleToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "article");
                    fileSize.Visible = false;

                    //LinkField lf = dataItem.Fields["Link"];

                    if (lf.TargetItem != null)
                        itemLink = LinkManager.GetItemUrl(lf.TargetItem);
                }

                hypActionLink.NavigateUrl = hypTitle.NavigateUrl = itemLink;
            }
        }

        private string ResolveMediaURL(Item item)
        {
            LinkField lf = item.Fields["Link"];

            if (lf != null && lf.TargetItem != null)
                return Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem);
            else
                return "#";
        }
    }
}