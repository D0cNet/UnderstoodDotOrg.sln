using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Personalization
{
    class PersonalizedItemModel : Content.ContentItemModel
    {
        /// Display Order of the Content Item 
        /// </summary>
        public string DisplayOrder { get; set; }
    }
}
