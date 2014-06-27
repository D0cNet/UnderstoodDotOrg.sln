using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews
{
    public class CSMReviewDBContext : DataContext
    {
        public CSMReviewDBContext()
            : base(global::System.Configuration.ConfigurationManager.ConnectionStrings["membership"].ConnectionString)
        {

        }
        public CSMReviewDBContext(string conn) : base(conn) { }
        
    }
}
