using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Domain.Users
{
    /// <summary>
    /// Used for storing temporary information about children during the registration process. All other data is stored directly in Entity Child Model
    /// </summary>
    public class ChildModel
    {
        public string Grade { get; set; }
        public string Pronoun { get; set; }
    }

}
