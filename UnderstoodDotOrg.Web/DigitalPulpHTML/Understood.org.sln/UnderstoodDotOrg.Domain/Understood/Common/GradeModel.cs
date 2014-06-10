using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    class GradeModel
    {
        /// <summary>
        /// The Sitecore GUID used for this Grade
        /// </summary>
        public string GradeID { get; set; }

        /// <summary>
        /// The User Friendly name for this Grade
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The order that this grade should appear in when displayed
        /// </summary>
        public int DisplayOrder { get; set; }

     
     
    }
}
