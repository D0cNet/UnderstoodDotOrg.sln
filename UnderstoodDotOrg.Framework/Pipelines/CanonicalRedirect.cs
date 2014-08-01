using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                if (!context.Request.RawUrl.Contains(url) || context.Request.RawUrl.Contains("/sitecore/"))
                {
                    context.Response.RedirectPermanent(url);
                }
            }
        }
    }
}
