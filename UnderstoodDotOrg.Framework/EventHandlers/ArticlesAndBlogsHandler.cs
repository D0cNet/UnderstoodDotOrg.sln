using Sitecore.Data.Items;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Framework.EventHandlers
{
    class ArticlesAndBlogsHandler
    {
        protected void OnItemSaved(object sender, EventArgs args)
        {
            var itm = Event.ExtractParameter(args, 0) as Item;
            if (itm != null)
            {
                
            }

        }
    }
}
