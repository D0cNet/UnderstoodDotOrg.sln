using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace UnderstoodDotOrg.Domain.Personalization
{
    public partial class PersonalizationContext : DataContext
    {
        public PersonalizationContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["membership"].ConnectionString)
        {

        }
        public PersonalizationContext(string conn) : base(conn) { }
        public Table<PersonalizedContent> PersonalizedContent
        {
            get
            {
                return this.GetTable<PersonalizedContent>();
            }
        }
    }
}
