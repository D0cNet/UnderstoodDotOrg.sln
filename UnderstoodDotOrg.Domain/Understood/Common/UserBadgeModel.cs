using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class UserBadgeModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Points_Low { get; set; }
        public int Point_High { get; set; }

        public static string TemplateID { get { return "{F81DCD75-6489-4B56-B040-6FF7D6C00CB9}"; } }
        public UserBadgeModel()
        {
            
        }

        
    }
}
