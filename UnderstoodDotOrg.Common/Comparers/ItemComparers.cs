using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Common.Comparers
{
    public class BaseItemComparer : EqualityComparer<Item>
    {
        public override bool Equals(Item x, Item y)
        {
            return x.ID == y.ID;
        }

        public override int GetHashCode(Item obj)
        {
            return obj.ID.Guid.GetHashCode();
        }
    }

    public class CustomItemComparer<T> : EqualityComparer<T> where T : CustomItem
    {
        public override bool Equals(T x, T y)
        {
            return x.InnerItem.ID == y.InnerItem.ID;
        }

        public override int GetHashCode(T obj)
        {
            return obj.InnerItem.ID.Guid.GetHashCode();
        }
    }
}
