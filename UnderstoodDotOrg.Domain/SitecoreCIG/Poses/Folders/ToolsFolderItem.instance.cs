using System.Collections.Generic;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;


namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
public partial class ToolsFolderItem 
{
    public AssistiveToolsLandingPageItem GetAssistiveToolsLandingPage()
    {
        return InnerItem.Children.FirstOrDefault(i => i.IsOfType(AssistiveToolsLandingPageItem.TemplateId));
    }
}
}