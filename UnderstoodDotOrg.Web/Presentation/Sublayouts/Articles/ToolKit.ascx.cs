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
                Literal litFileSize = e.FindControlAs<Literal>("litFileSize");
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
                    hypActionLink.Attributes.Add("download", "download");
                }
                else if (dataItem.IsOfType(VideoToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "video");

                    if (lf.TargetItem != null)
                        itemLink = LinkManager.GetItemUrl(lf.TargetItem);
                }
                else if (dataItem.IsOfType(AudioToolkitResourceItem.TemplateId))
                {
                    iconType.Attributes.Add("class", "audio");

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

                    itemLink = ResolveMediaURL(dataItem);
                }

                string fileSizeText = GetFileSize(dataItem);
                if (fileSizeText != "")
                    litFileSize.Text = fileSizeText;

                hypActionLink.NavigateUrl = hypTitle.NavigateUrl = itemLink;
            }
        }

        private string GetFileSize(Item item)
        {
            LinkField lf = item.Fields["Link"];

            if (lf.LinkType.ToLower() == "media")
            {
                MediaItem mediaItem = new MediaItem(lf.TargetItem);
                return Math.Round((mediaItem.Size / 1000.0), 0).ToString()+"k";
            }

            return "";
        }

        private string ResolveMediaURL(Item item)
        {
            LinkField lf = item.Fields["Link"];

            if (lf != null)
            {
                if (lf.LinkType.ToLower() == "external")
                    return lf.Url;
                else if(lf.LinkType.ToLower() == "internal")
                    return lf.TargetItem.GetUrl();
                else
                    return Sitecore.Resources.Media.MediaManager.GetMediaUrl(lf.TargetItem);
            }
            else
                return "#";
        }
    }
}