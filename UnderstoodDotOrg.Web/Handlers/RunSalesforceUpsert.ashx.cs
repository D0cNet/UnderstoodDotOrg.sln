using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnderstoodDotOrg.Domain.Salesforce;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// This file serves as an example as to how to use our salesforce Create website member function
    /// http://understood.org.local/Handlers/RunSalesforceUpsert.ashx?fname=MyfirstNameIsBrett&lname=MylastnameIsGarnier
    /// Bare Bones usage:
    ///        SalesforceManager sfMgr = new SalesforceManager("brettgarnier@outlook.com", "8f9C3Ayq", "hlY0jOIILtogz3sQlLUtmERlu");
    ///        if (sfMgr.LoggedIn)
    ///        {
	///		    try
    ///            {
	///				SalesforceActionResult result = sfMgr.UpsertWebsiteMemberToSalesforce(m);
    ///               if (result.Success == false)
    ///                {
	///					    //result.Message has info
	///				   }
	///			catch (Exception ex)
    ///            {
	///				//handle how you want
    ///            }
    ///		}
    /// </summary>
    public class RunSalesforceUpsert : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Connecting to salesforce");

            string fname = context.Request.QueryString["fname"];
            string lname = context.Request.QueryString["lname"];
            string email = context.Request.QueryString["email"];

            
            SalesforceManager sfMgr = new SalesforceManager("brettgarnier@outlook.com", "8f9C3Ayq", "hlY0jOIILtogz3sQlLUtmERlu");
            if (sfMgr.LoggedIn)
            {
                //we are logged into salesforce.
                Member m = new Member();
                m.MemberId = Guid.NewGuid(); //adding in a random guid
                m.UserId = Guid.NewGuid(); //add in a random user id guid
                
                m.allowConnections = true;
                m.allowNewsletter = false ;
                m.emailSubscription = true;
                m.FirstName = fname;
                m.hasOtherChildren = false;
                m.isFacebookUser = true;
                m.isPrivate = true;
                m.LastName = lname;
                m.PersonalityType = new Guid("8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983");//Optimisic Parent
              
                //m.Phone = 7811112222; //member phone & db need to be updated . int32 is too small for a phone number
               
                m.Role = new Guid("2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE");//Father
                
                Random random = new Random();
                int randomNumber = random.Next(0, 10000);
                m.ScreenName = "dummyuser_" + randomNumber.ToString();
                m.ZipCode = "01111";
                
                Journey j = new Journey();
                j.Key = new Guid( "0642E401-8E66-4C69-89C6-294C257456C8");
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
                Grade g2 = new Grade();
                g2.Key = new Guid("E0B459C0-548A-4E6C-854A-E8F475416F12");
                g2.Value = "Grade 10";
              
                //setting up status values for children
                Guid iepStatus = new Guid("FBE464C6-0E52-45C5-A1E9-660CB3C6B688");//yes
                Guid section504Status = new Guid("55F38A58-7506-454E-95E5-0ECE22A3B99C");//in progress
                Guid evaluationStatus = new Guid("990FB117-F12E-4E3C-898B-8A9EB217FCFD");//yes
                //------------------------------------------
                //test child 1
                //------------------------------------------
                Child childOne = new Child();
                childOne.ChildId = Guid.NewGuid();//random new child guid for testing purposes
                childOne.Gender = "boy";
                childOne.Nickname = "Bobby";
                childOne.IEPStatus = iepStatus;
                childOne.Section504Status = section504Status;
                childOne.EvaluationStatus = evaluationStatus;

                childOne.Issues.Add(issueOne);
                childOne.Issues.Add(issueTwo);
                childOne.Grades.Add(g1);
                childOne.Diagnoses.Add(d1);
                childOne.Diagnoses.Add(d2);
                m.Children.Add(childOne); 
                //------------------------------------------
                //test child 2
                //------------------------------------------
                Child childTwo = new Child();
                childTwo.ChildId = Guid.NewGuid();//random new guid for testing
                childTwo.Gender = "boy";
                childTwo.Nickname = "Tommy";
                childTwo.IEPStatus = iepStatus;
                childTwo.Section504Status = section504Status;
                childTwo.EvaluationStatus = evaluationStatus;

                childTwo.Grades.Add(g2);
                childTwo.Issues.Add(issueOne);
                childTwo.Issues.Add(issueTwo);
                m.Children.Add(childTwo); 

                try
                {
                    SalesforceActionResult result = sfMgr.CreateWebsiteMemberAsContact(m,email);
                 
                    if (result.Success == true)
                    {
                        context.Response.Write(Environment.NewLine + "Contact (" + fname + " " + lname + ") is 'saved' to salesforce at: (" + sfMgr.SalesforceURL + ")"
                             + Environment.NewLine + "Message: " + result.Message );
                    }
                    else
                    {
                        context.Response.Write(Environment.NewLine + "Contact (" + fname + " " + lname + ") is not saved to salesforce at: (" + sfMgr.SalesforceURL + ")"
                            + Environment.NewLine + "Message: " + result.Message );
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write(Environment.NewLine + "An error occured during in RunSalesfroceUpsert.ashx.cs " + 
                        Environment.NewLine + "Message: " +  ex.Message +
                        Environment.NewLine + "Stack Trace: " + ex.StackTrace);
                }                
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}