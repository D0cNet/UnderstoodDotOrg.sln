using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Common.Extensions {
    public static class RepeaterExtensions {
        /// <summary>
        /// Determines if a repeater item is a list item or alternating list item
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool IsItem(this RepeaterItemEventArgs e) {
            return (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item);
        }

        /// <summary>
        /// Finds a control by its given id and casts to the provided generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T FindControlAs<T>(this RepeaterItemEventArgs e, string id) where T : System.Web.UI.Control {
            return (T)e.Item.FindControl(id);
        }
    }
}
