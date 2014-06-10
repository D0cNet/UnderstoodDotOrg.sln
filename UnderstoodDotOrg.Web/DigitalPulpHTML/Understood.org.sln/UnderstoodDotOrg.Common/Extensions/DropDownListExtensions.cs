using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Common.Extensions
{
    public static class DropDownListExtensions
    {
        public static int GetSelectedIndex(this DropDownList ddl, string value)
        {
            return ddl.Items.IndexOf(ddl.Items.FindByValue(value));
        }
    }
}
