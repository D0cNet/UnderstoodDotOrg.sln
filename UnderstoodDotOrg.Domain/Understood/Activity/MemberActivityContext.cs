using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Activity
{
    public partial class MemberActivityContext : DataContext
    {
        public MemberActivityContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["membership"].ConnectionString)
        {

        }
        public MemberActivityContext(string conn) : base(conn) { }

        public Table<MemberActivity> MemberActivity
        {
            get
            {
                return this.GetTable<MemberActivity>();
            }
        }
    }
}
