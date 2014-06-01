using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Quiz
{
    public class Quiz
    {
        public Guid MemberId { get; set; }
        public Guid QuizID { get; set; }

        public virtual ICollection<QuizItem > MemberAnswers { get; set; }
    }

}
