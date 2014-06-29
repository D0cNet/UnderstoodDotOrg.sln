using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews
{
    public class CSMUserReview
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid ReviewId { get; set; }
        public Guid TelligentCommentId { get; set; }

        public Guid? MemberId { get; set; }
        public virtual UnderstoodDotOrg.Domain.Membership.Member Member { get; set; }

        public Guid CSMItemId { get; set; }
        public int Rating { get; set; }
        public Guid RatedGradeId { get; set; }
        public int GradeAppropriateness { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewBody { get; set; }
        public string BlogId { get; set; }
        public string BlogPostId { get; set; }
        public string ContentId { get; set; }
        public string UserScreenName { get; set; }

        public virtual List<AssistiveToolsSkillItem> UserReviewSkills { get; set; }

        public CSMUserReview()
        {
            UserReviewSkills = new List<AssistiveToolsSkillItem>();
        }
    }
}

