using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Services.MemberServices
{
    public static class User
    {
        public static List<UserBadgeModel> GetUserBadges(string username)
        {
            
        
            string imageUrl = String.Empty;
            List<UserBadgeModel> badges = new List<UserBadgeModel>();

            if (!String.IsNullOrEmpty(username))
            {
                string points = TelligentService.TelligentService.ReadUserPoints(username);
                //Search sitecore based on templateid and points
                Item[] currItems = Sitecore.Context.Database.SelectItems("fast:/sitecore/content/Globals//*[@@templateid = '" + UserBadgeModel.TemplateID + "' and @Number of Points Range Low >='" + points + "' and @Number of Points Range High <='" + points + "']");

                ///TODO: overload or modify to use different logic to return the list of userbadges
                foreach (var item in currItems)
                {
          
                    UserBadgeModel badge = new UserBadgeModel();
                   // Item item = currItems.OrderBy(x => Convert.ToInt32(x.Fields["Number of Points"].ToString())).First<Item>();
                    Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)item.Fields["Points Icon"]);

                    string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                    badge.ImageUrl = url;//item.Fields["Points Icon"].ToString();
                    badge.Name = item.DisplayName;
                    badge.Points_Low = Convert.ToInt32(item.Fields["Number of Points Range Low"].ToString());
                    badge.Point_High = Convert.ToInt32(item.Fields["Number of Points Range High"].ToString());
                    badges.Add(badge);
                }
            }
            return badges;
            
        }

    }
}
