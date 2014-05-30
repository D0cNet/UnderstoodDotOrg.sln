using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseRegistration<T> : BaseRegistration where T : CustomItem
    {
        private T _model;
        public T Model
        {
            get
            {
                return _model ?? (_model = (T)Activator.CreateInstance(typeof(T), DataSource));
            }
        }
    }
}
