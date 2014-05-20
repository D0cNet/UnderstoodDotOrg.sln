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
                HyperLink hypDownloadLink = e.FindControlAs<HyperLink>("hypDownloadLink");

                if (frTitle != null)
                    frTitle.Item = dataItem;
                if(hypDownloadLink != null)
                    hypDownloadLink.Text = dataItem.Fields["Action Text"].ToString();

                if (dataItem.IsOfType(PDFToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "pdf");

                    hypDownloadLink.NavigateUrl = ResolveMediaURL(dataItem);
                }
                else if (dataItem.IsOfType(VideoToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "video");

                    hypDownloadLink.NavigateUrl = ResolveMediaURL(dataItem);
                }
                else if (dataItem.IsOfType(AudioToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "audio");

                    hypDownloadLink.NavigateUrl = ResolveMediaURL(dataItem);
                }
                else if (dataItem.IsOfType(WordToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "word");

                    Sitecore.Data.Fields.FileField fileField = ((Sitecore.Data.Fields.FileField)dataItem.Fields["Link"]);

                    hypDownloadLink.NavigateUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(fileField.MediaItem);
                }
                else if (dataItem.IsOfType(ArticleToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "article");
                    fileSize.Visible = false;

                    LinkField lf = dataItem.Fields["Link"];

                    if (lf.TargetItem != null)
                        hypDownloadLink.NavigateUrl = LinkManager.GetItemUrl(lf.TargetItem);
                }
            }
        }

        private string ResolveMediaURL(Item item)
        {
            LinkField lf = item.Fields["Link"];

            if (lf.TargetItem != null)
                return Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem);
            else
                return "";
        }
    }
}