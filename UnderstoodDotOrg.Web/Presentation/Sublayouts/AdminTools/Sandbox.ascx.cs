using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Understood.Quiz;

using UnderstoodDotOrg.Domain.Understood.Activity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
    public partial class Sandbox : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivityLog throwawaylog = new ActivityLog();
            //ContentId, ActivityValue
            lblActivityCount.Text = throwawaylog.GetActivityCountByValue(new Guid("ECEFA524-93F5-4CE3-817B-A6DBBDA7640F"),  
                                                                          Constants.UserActivity_Values.Favorited).ToString();

            //i read this page. now record it.
           // Guid MemberId = new Guid();
           // Guid ContentId = new Guid();
            /*
            //Create an instance of the Membership Manager
            MembershipManager mgr = new MembershipManager();
            //log that this member has skipped a blog:
            mgr.LogMemberActivity(MemberId, ContentId,
                Constants.UserActivity_Values.Skipped_Blog,
                Constants.UserActivity_Types.ContentSkipped);

            //log that this member has skipped a blog post:
            mgr.LogMemberActivity(MemberId, ContentId,
                Constants.UserActivity_Values.Skipped_BlogPost ,
                Constants.UserActivity_Types.ContentSkipped);

            //log that this member has skipped a :
            mgr.LogMemberActivity(MemberId, ContentId,
                Constants.UserActivity_Values.Skipped_Group ,
                Constants.UserActivity_Types.ContentSkipped);

            //log that this member has viewed this page 
            //bg: note: we are going to need views for some things and consider how this will behave when we have hundreds of millions of rows
            mgr.LogMemberActivity(MemberId, ContentId,
                Constants.UserActivity_Values.ItemViewed,
                Constants.UserActivity_Types.ContentRelated);


            mgr.LogMemberActivity(new Guid(), new Guid(), 
                                Constants.UserActivity_Values.ItemViewed , 
                                Constants.UserActivity_Types.Type_Blog);

            mgr.LogMemberActivity(new Guid(), new Guid(), 
                        Constants.UserActivity_Values.SharedWithTwitter, 
                        Constants.UserActivity_Types.Type_BlogPost);
           
            
   
            */
            /*
            mgr.LogMemberHelpfulVote(MemberIdValue, 
                ContentIdValue, 
                Constants.UserActivity_Values.FoundHelpful_True, 
                Constants.UserActivity_Types.FoundHelpfulVote);
            */

            //     MembershipManager mgr = new MembershipManager();
      
            ////to say something was helpful
            //mgr.LogMemberHelpfulVote(MemberId, ContentId, Constants.UserActivity_Values.FoundHelpful_True, Constants.UserActivity_Types.FoundHelpfulVote);
            //// to say something was not helpful
            //mgr.LogMemberHelpfulVote(MemberId, ContentId, Constants.UserActivity_Values.FoundHelpful_False , Constants.UserActivity_Types.FoundHelpfulVote);

            ////to get IF a content item was helpful to this user
            //ActivityLog log = new ActivityLog();
            //bool washelpful = log.FoundItemHelpful(ContentId, MemberId);
            ////to get if the content was NOT helpful
            //bool wasNOThelpful = log.FoundItemNotHelpful(ContentId, MemberId);




            ActivityLog log = new ActivityLog(new Guid("810EBB87-14E1-4DAF-8EAE-F69E1754C640"), Constants.UserActivity_Values.Favorited);

            foreach (ActivityItem item in log.Activities)
            {
                Response.Write("ContentId: " + item.ContentId  + Environment.NewLine);
                Response.Write("ActivityValue: " + item.ActivityValue + Environment.NewLine + "------------------" + Environment.NewLine);
            }

            string targetUrl = "http://www.somethinghostedonconvio.com/myarticle.php";
            txtActivityValue.Text  = targetUrl  ;
            txtActivityType.Text = UnderstoodDotOrg.Common.Constants.UserActivity_Types.Advocacy_Page.ToString();

            /*
            Quiz quiz = new Quiz();
            quiz.QuizID = new Guid();

            QuizItem answer = new QuizItem();

            answer.QuestionId = Guid.NewGuid();
            answer.AnswerValue = "I am the answer.";
            quiz.MemberAnswers.Add(answer);

            quiz.MemberAnswers.Add(new QuizItem(Guid.NewGuid(), "I am also an answer"));
            quiz.MemberAnswers.Add(new QuizItem(Guid.NewGuid(), "I am a third answer"));

            this.CurrentMember.CompletedQuizes.Add(quiz);
            */
             //member contains data. member manager will save data.

            //           this.CurrentMember.AgreedToSignUpTerms;


            /*

            Checklist cl = new Checklist();
            cl.MemberId = CurrentMember.MemberId ;
            ChecklistItem clItem  = new ChecklistItem();
            
            clItem.QuestionId = Guid.NewGuid();
            clItem.Checked = true;

            cl.MemberAnswers.Add(clItem);
            mgr = new MembershipManager();
            mgr.ChecklistResults_SaveToDb(cl.MemberId, cl);
            */
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.MemberId = Guid.NewGuid(); //adding in a random guid
            m.UserId = Guid.NewGuid(); //add in a random user id guid
            
            m.allowConnections = false; //no community.
            //-------------------
            m.allowNewsletter = true;            
            m.emailSubscription = true; // - what are our flags for personalized email


            m.FirstName = Constants.UnauthenticatedMember_FirstName;
            m.hasOtherChildren = false;
            m.isFacebookUser = false;
            m.isPrivate = true;
            m.LastName = string.Empty;
            m.PersonalityType = new Guid("8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983");//Optimisic Parent
            m.Role = new Guid("2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE");//Father

            m.Email = txtEmail.Text;

            m.Password = Constants.UnauthenticatedMember_Password;
            
            Random random = new Random();
            int randomNumber = random.Next(0, 10000);
            m.ScreenName = "dummyuser_" + randomNumber.ToString();
            m.ZipCode = "01111";

            Journey j = new Journey();
            j.Key = new Guid("0642E401-8E66-4C69-89C6-294C257456C8");
            j.Value = "Still Figuring it Out";
            m.Journeys.Add(j);

            Interest intr = new Interest();
            intr.Key = new Guid("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9");
            intr.Value = "Assisted Living";
            m.Interests.Add(intr);

            Interest intr2 = new Interest();
            intr2.Key = new Guid("3C185099-76B4-49DD-80D4-A069A3F55FA1");
            intr2.Value = "Homework and Study Skills";
            m.Interests.Add(intr2);

            //setting up a couple of issues for children
            Issue issueOne = new Issue();
            issueOne.Key = new Guid("3390C210-0B22-48FD-A411-881F956EDC0C");
            issueOne.Value = "Listening";
            Issue issueTwo = new Issue();
            issueTwo.Key = new Guid("1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0");
            issueTwo.Value = "Math";

            //setting up a couple of diagnosis values for children
            Diagnosis d1 = new Diagnosis();
            d1.Key = new Guid("A66286A0-CD70-4FDD-9D13-9CF1C90EFC4A");
            d1.Value = "Receptive Language Disorder";
            Diagnosis d2 = new Diagnosis();
            d2.Key = new Guid("7A035CC2-D6BD-4332-9518-7AB22083F652");
            d2.Value = "ADHD";

            //setting up a couple of grade values for children
            Grade g1 = new Grade();
            g1.Key = new Guid("E26222FB-07CD-413B-9127-9050B6D2D037");
            g1.Value = "Grade 1";
       
            //setting up status values for children
            Guid iepStatus = new Guid("FBE464C6-0E52-45C5-A1E9-660CB3C6B688");//yes
            Guid section504Status = new Guid("55F38A58-7506-454E-95E5-0ECE22A3B99C");//in progress
            Guid evaluationStatus = new Guid("990FB117-F12E-4E3C-898B-8A9EB217FCFD");//yes
            //------------------------------------------
            //test child 1 -- for the purposes of newsletter we only have 1 child. 
            //------------------------------------------
            Child childOne = new Child();
            childOne.ChildId = Guid.NewGuid();//random new child guid for testing purposes
            childOne.Gender = "boy";
            childOne.Nickname = "C1";
            childOne.IEPStatus = iepStatus;
            childOne.Section504Status = section504Status;
            childOne.EvaluationStatus = evaluationStatus;

            childOne.Issues.Add(issueOne);
            childOne.Issues.Add(issueTwo);
            childOne.Grades.Add(g1);
            childOne.Diagnoses.Add(d1);
            childOne.Diagnoses.Add(d2);
            m.Children.Add(childOne);

            MembershipManager mmgr = new MembershipManager();
            Member unauthMember = mmgr.AddUnauthorizedMember(m);
            //we should now have a "real" unauthorized member with comments and all
            
        }

        protected void btnActivityInsert_Click(object sender, EventArgs e)
        {
            // *** to log a user making a reminder request:
            //   txtActivityValue.Text  = UnderstoodDotOrg.Common.Constants.UserActivity_Values.SetReminder  ;
            //   txtActivityType.Text = UnderstoodDotOrg.Common.Constants.UserActivity_Types.ContentRelated.ToString();

            // *** to log a user browsing to a convio luminate hosted page:
            // string targetUrl = "http://www.somethinghostedonconvio.com/myarticle.php";
            // txtActivityValue.Text = targetUrl;
            // txtActivityType.Text = UnderstoodDotOrg.Common.Constants.UserActivity_Types.Advocacy_Page.ToString();

            MembershipManager mmgr = new MembershipManager();
            try
            {
                bool success = mmgr.LogMemberActivity(Guid.Parse(txtMemberGuid.Text),
                                                      Guid.Parse(txtContentId.Text),
                                                      txtActivityValue.Text,
                                                      int.Parse(txtActivityType.Text));
                lblSuccess.Text = success.ToString();
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Exception! " + ex.Message ;
            }
        }

        protected void btnQuizReader_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.MemberId = Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e543"); //throw away user
            MembershipManager mgr = new MembershipManager();
            
            //to load up quizes and all of their answer values
            m = mgr.QuizResults_FillMember(m);

            Quiz quiz = new Quiz();
            quiz.QuizID = Guid.NewGuid();
            quiz.MemberAnswers.Add(new QuizItem(Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e333"),"JUNKANSWER1"));
            quiz.MemberAnswers.Add(new QuizItem(Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e444"), "JUNKANSWER2"));
            //to save a quiz to the db
            mgr.QuizResults_SaveToDb(m.MemberId, quiz);

        }

        protected void btnLogSub_Click(object sender, EventArgs e)
        {
            MembershipManager mgr = new MembershipManager();

            mgr.LogSubtopicPageView(Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e543"),  Guid.NewGuid() , new Guid());
            mgr.LogSubtopicPageView(Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e543"), Guid.NewGuid(), new Guid());

        }

        protected void btnShowItems_Click(object sender, EventArgs e)
        {
            ActivityLog log = new ActivityLog();          
            List<Guid?> stuff = log.MostPopularItems(Guid.Parse("00000000-0000-0000-0000-000000000000"));

            foreach (Guid g in stuff)
            {
                Response.Write("<h1>" + g.ToString() + "</h1>" + Environment.NewLine);
            }

        }

        protected void btnLogHelpfulQuestion_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.MemberId = Guid.Parse("93e4c02c-3d3d-4ccd-95a3-180bb513e543"); //throw away user
            
            MembershipManager mgr = new MembershipManager();
            mgr.LogMemberHelpfulVote(m.MemberId , Guid.NewGuid(), 
                Constants.UserActivity_Values.FoundHelpful_True, 
                Constants.UserActivity_Types.FoundHelpfulVote,
                Constants.UserActivity_SpecialFilters.QA_QuestionWasHelpful );
            

        }
    }
}