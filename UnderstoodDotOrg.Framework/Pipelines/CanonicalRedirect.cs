using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Framework.Pipelines
{
    public class CanonicalRedirect : Sitecore.Pipelines.HttpRequest.ItemResolver
    {
        public override void Process(Sitecore.Pipelines.HttpRequest.HttpRequestArgs args)
        {
            base.Process(args);

            if (Sitecore.Context.Item != null && System.Web.HttpContext.Current != null)
            {
                var url = Sitecore.Context.Item.GetUrl();
                
                var context = System.Web.HttpContext.Current;
                var rawUrl = context.Request.RawUrl;

                if (!rawUrl.Contains(url) && !rawUrl.Contains("/sitecore/") && !url.Contains(Sitecore.Configuration.Settings.GetSetting(Constants.Settings.WildcardUrlPlaceholder)))
                {
                    if (!string.IsNullOrEmpty(context.Request.Url.Query))
                    {
                        url += context.Request.Url.Query;
                    }
                    context.Response.RedirectPermanent(url);
                }
            }
        }
    }
}
