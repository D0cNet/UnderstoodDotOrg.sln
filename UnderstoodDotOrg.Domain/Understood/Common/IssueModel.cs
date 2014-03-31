using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    class IssueModel
    {
        /// <summary>
        /// The Sitecore GUID used for this Issue
        /// </summary>
        public string IssueID { get; set; }

        /// <summary>
        /// The User Friendly name for this Issue
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The order that this issue should appear in when displayed
        /// </summary>
        public int DisplayOrder { get; set; }

    }
}
