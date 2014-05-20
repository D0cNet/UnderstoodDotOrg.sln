using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Sitecore.Data.Managers;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Common;

namespace UnderstoodDotOrg.Common.Extensions
{
    public static class ItemExtensions
    {
        /// <summary>
        /// Resolve the item URL
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetUrl(this Item item)
        {
            return Sitecore.Links.LinkManager.GetItemUrl(item);
        }

        /// <summary>
        /// Resolve the item URL
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static string GetUrl(this CustomItem item)
        {
            return Sitecore.Links.LinkManager.GetItemUrl(item.InnerItem);
        }

        /// <summary>
        /// Check if item has context language version
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool VersionExists(this Item item)
        {
            return item != null && item.Versions.Count > 0;
        }

        /// <summary>
        /// Determines if this item is of the provided TemplateId
        /// </summary>
        /// <param name="item"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static bool IsOfType(this Item item, string templateId)
        {
            return item.TemplateID.ToString().Equals(templateId, System.StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines if this item is of the provided TemplateId
        /// </summary>
        /// <param name="item"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static bool IsOfType(this Item item, ID templateId)
        {
            return item.TemplateID.Equals(templateId);
        }

        public static bool InheritsFromType(this Item item, string templateId)
        {
            return InheritsFromType(item, ID.Parse(templateId));
        }

        public static bool InheritsFromType(this Item item, ID templateId)
        {
            return GetTemplate(item).InheritsFrom(templateId);
        }

        public static bool InheritsTemplate(this Item item, string templateID)
        {
            return item.GetTemplate().InheritsFrom(new ID(templateID));
        }

        /// <summary>
        /// Gets the Template of an item (which is different than the TemplateItem)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Template GetTemplate(this Item item)
        {
            return TemplateManager.GetTemplate(item);
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static Item GetItem(this Database database, Guid id)
        {
            return database.GetItem(new ID(id));
        }

        /// <summary>
        /// Gets the item cast to the specified CustomItem type.
        /// </summary>
        /// <typeparam name="T">The CustomItem type the returned item will be cast to</typeparam>
        /// <param name="database">The database.</param>
        /// <param name="selector">The string path, ID, etc for selecting the item from Sitecore.</param>
        /// <returns></returns>
        public static T GetItemAs<T>(this Database database, string selector) where T : CustomItem
        {
            return (T)(Activator.CreateInstance(typeof(T), database.GetItem(selector)));
        }

        /// <summary>
        /// Gets the item cast to the specified CustomItem type.
        /// </summary>
        /// <typeparam name="T">The CustomItem type the returned item will be cast to</typeparam>
        /// <param name="database">The database.</param>
        /// <param name="id">The Guid ID of the item.</param>
        /// <returns></returns>
        public static T GetItemAs<T>(this Database database, Guid id) where T : CustomItem
        {
            return (T)(Activator.CreateInstance(typeof(T), database.GetItem(id)));
        }

        /// <summary>
        /// Filter Item collection by context language version
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<Item> FilterByContextLanguageVersion(this IEnumerable<Item> collection)
        {
            return collection.Where(i => i != null && i.Versions.Count > 0);
        }
        /// <summary>
        /// Checks if item has version in context language or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool HasContextLanguageVersion(this Item item)
        {
            return item != null && item.Versions.Count > 0;
        }

        //public static string GetCroppedImageUrl(this Item currentItem, string fieldName, int width, int height) {
        //    return GetImageUrl(currentItem, fieldName, width, height, crop: true);
        //}

        /// <summary>
        /// This returns a list of child items based on a list of templates names provided
        /// </summary>
        /// <param name="Parent">
        /// Parent Item to search for children
        /// </param>
        /// <param name="Templatenames">
        /// The list of template names to look for
        /// </param>
        /// <returns>
        /// Returns a list of items that match the templatenames provided
        /// </returns>
        public static List<Item> ChildrenByTemplates(this Item Parent, List<string> Templatenames)
        {

            try
            {
                return (from child in Parent.GetChildren().ToArray()
                        where Templatenames.Contains(child.TemplateName)
                        select child).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
