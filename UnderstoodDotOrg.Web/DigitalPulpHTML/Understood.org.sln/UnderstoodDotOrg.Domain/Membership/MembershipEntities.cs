using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnderstoodDotOrg.Domain.Membership
{
    public partial class Membership : DbContext
    {
        public Membership(string connectionString)
            : base(connectionString)
        {
        }
    }
}
