using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews
{
    public class CSMUserReviewSkill
    {
        public Guid ReviewId { get; set; }
        public virtual CSMUserReview Review { get; set; }
        public Guid SkillId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public CSMUserReviewSkill() 
        { 
        
        }
    }
}
