using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Quiz
{
    public class QuizItem
    {
        public Guid QuestionId { get; set; }
        public string AnswerValue { get; set; }
        public DateTime AnsweredOn { get; set; }
        public QuizItem()
        { 
        }
        public QuizItem(Guid Question, string Answer)
        {
            this.QuestionId = Question;
            this.AnswerValue = Answer;
            this.AnsweredOn = DateTime.Now;
        }


    }
    public class ChecklistItem : QuizItem
    {
        public bool Checked
        {
            get { return bool.Parse(base.AnswerValue); }
            set { base.AnswerValue = value.ToString(); }
        }

    }
}
