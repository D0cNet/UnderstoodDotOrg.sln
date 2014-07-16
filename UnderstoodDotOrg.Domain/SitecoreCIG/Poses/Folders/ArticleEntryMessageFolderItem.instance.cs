using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class ArticleEntryMessageFolderItem 
{
    public Item GetArticleEntryMessageContentItem()
    {
        return InnerItem.GetChildren().FirstOrDefault();
    }
}
}