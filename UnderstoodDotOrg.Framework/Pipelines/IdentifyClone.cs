using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Framework.Pipelines
{
    public class IdentifyClone : Sitecore.Publishing.Pipelines.PublishItem.PerformAction
    {
        /// <summary>
        /// Store source value to use to determine if an item is cloned as value is removed when items are published
        /// http://www.sitecore.net/Community/Technical-Blogs/John-West-Sitecore-Blog/Posts/2013/02/Identify-Cloned-Items-Sitecore-ASPNET-CMS-Publishing-Target-Databases.aspx
        /// </summary>
        /// <param name="context"></param>
        public override void Process(Sitecore.Publishing.Pipelines.PublishItem.PublishItemContext context)
        {
            base.Process(context);
            Item versionToPublish = context.VersionToPublish;

            if (!context.Aborted 
                && versionToPublish != null
                && versionToPublish.InheritsTemplate(BasePageNEWItem.TemplateId)
                && versionToPublish.Source != null
                && versionToPublish.IsClone)
            {
                BasePageNEWItem target = context.PublishOptions.TargetDatabase.GetItem(
                    versionToPublish.ID,
                    versionToPublish.Language);

                if (target.InnerItem != null &&
                    target.SourceItem.Field.Value !=
                    versionToPublish.Source.ID.ToString())
                {
                    using (new Sitecore.Data.Items.EditContext(target.InnerItem, updateStatistics: false, silent: true))
                    {
                        target.InnerItem[target.SourceItem.Field.InnerField.Name] = versionToPublish.ID.ToString();
                    }
                }
            }
        }
    }
}
