using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Domain.Understood.Content
{
    class ContentItemModel
    {
        /// <summary>
        /// Sitecore GUID of the content item
        /// </summary>
        public string ContentID { get; set; }

        /// <summary>
        /// Title of the Content Item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type of the Content Item (Article, Infographic, etc)
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The IEP status of the Content Item
        /// </summary>
        public string IEPStatus { get; set; }

        /// <summary>
        /// The Section 508 Status of the Content Item
        /// </summary>
        public string Section508Status { get; set; }

        /// <summary>
        /// The Diagnosis Status that this Content Item relates to
        /// </summary>
        public string DiagnosisStatus { get; set; }

        /// <summary>
        /// Is this Content Item Tagged as Must Read
        /// </summary>
        public bool MustRead { get; set; }
        
        /// <summary>
        /// A list of all of the Grades that this content item is tagged for
        /// </summary>
        public List<GradeModel> Grades { get; set; }

        /// <summary>
        /// A list of all of the Issues that this content item is tagged for
        /// </summary>
        public List<IssueModel> Issues{ get; set; }


    }
}
