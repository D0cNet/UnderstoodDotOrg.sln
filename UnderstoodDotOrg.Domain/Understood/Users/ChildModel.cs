using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Domain.Users
{
    class ChildModel
    {
        /// <summary>
        /// The Sitecore GUID of the Grade that this child is in
        /// </summary>
        public string GradeID  { get; set; }

        /// <summary>
        /// A list of all of the Issues that this child is tagged with
        /// </summary>
        public List<IssueModel> Issues { get; set; }

    }
}
