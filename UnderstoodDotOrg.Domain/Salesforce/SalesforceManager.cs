using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Protocols;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Salesforce;
using UnderstoodDotOrg.Domain.Membership;


namespace UnderstoodDotOrg.Domain.Salesforce
{
    /// <summary>
    /// This code is not pretty. It is functional and procedural still as "we" are still learning nuances about 
    /// HOW to get things to work with Salesforce.com
    /// IMPORTANT: Every single row created in a salesforce object is assigned an ID value in salesforce
    /// that is not visable anywhere in any of the salesforce UI screens that are easily accessible. 
    /// *THIS* ID field is the *REAL* primary key that has to be used when inserting related rows that you intend on using in 
    /// "Master-Detail" and "Lookup" relationships. We can not control this field, we can not use our own Sitecore Guid, it is always 
    /// and forever read only. 
    /// If you want to create a website member (Salesforce Contact) and assoicate a Child you MUST create the contact first.
    /// Then get the ID of the contact
    /// Then create the Child
    /// Then get the ID of the Child
    /// Then add in any lookup table rows for that child's issues
    /// ALL Forign key relationships are dependant on these Salesforce IDs. 
    /// The way that we lookup IDs of "dictionary values" such as grades, issues, parental interests etc is we have Dictionaries in the Constants.cs file
    /// You will lookup the Salesforce VALUE in the dictonary by handing the dictionary the Sitecore KEY (guid).
    /// </summary>
    public class SalesforceManager
    {
        private SforceService _sfs;
        public bool LoggedIn { get; set; }
        private string _salesforceUrl;
        //readonly
        public string SalesforceURL
        {
            get
            {
                return this._salesforceUrl;
            }
        }


        public SalesforceManager()
        {
            LoggedIn = false;
        }
        public SalesforceManager(string Username, string Password, string Token)
        {
            //setting up our class level sForceService 
            _sfs = SalesforceLogin(Username, Password, Token);
            if (_sfs == null)
            {
                LoggedIn = false;
            }
            else
            {
                LoggedIn = true;
            }
        }

        /// <summary>
        /// For expeidency we are currently using:
        /// Usernmae: "brettgarnier@outlook.com" 
        /// Password: "8f9C3Ayq" 
        /// Token: "hlY0jOIILtogz3sQlLUtmERlu"
        ///  combo: 8f9C3AyqhlY0jOIILtogz3sQlLUtmERlu
        /// We want to get an account assigned to us SPECIFICIALLY just for connecting to the API in the future.
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Token"></param>
        /// <returns></returns>
        private SforceService SalesforceLogin(string Username, string Password, string Token)
        {
            SforceService sfs = new SforceService();
            // Need to append password and security token together since we're logging in through the 
            // Salesforce API
            string passwordPlusSecurityToken = string.Format("{0}{1}", Password, Token);
            LoginResult loginResult;
            try
            {
                loginResult = sfs.login(Username, passwordPlusSecurityToken);
            }
            catch (SoapException ex)
            {
                // Write the fault code to the console 
                Console.WriteLine(ex.Code);

                // Write the fault message to the console 
                Console.WriteLine("An unexpected error has occurred: " + ex.Message);

                // Write the stack trace to the console 
                Console.WriteLine(ex.StackTrace);

                // Return False to indicate that the login was not successful 
                return null;
            }
            //now that you are logged in you must change the url from login to the server 
            sfs.Url = loginResult.serverUrl;
            //make readable from the outside
            _salesforceUrl = sfs.Url;

            //required so we can work with our session
            sfs.SessionHeaderValue = new SessionHeader();
            sfs.SessionHeaderValue.sessionId = loginResult.sessionId;

            return sfs;
        }

        /// <summary>
        /// Pass a populated Member in and it will update salesforce.
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns>SalesforceSaveResult with success/fail bool & message if there was an error</returns>
        public SalesforceActionResult    UpsertWebsiteMemberToSalesforce(Member newMember)
        {

            ////sf upserts have to happen in the proper order. upsert the member first
            //  each join / lookup value can be upsert after the member exists
            //  then we upsert child
            //  then we can upsert child lookup values

            SalesforceActionResult sfResult = new SalesforceActionResult();
            
            Contact newSalesforceContact = new Contact();
            //Created an account for Understood.org
            newSalesforceContact.AccountId = "001F0000014EhHtIAK"; //todo Move this and other similar values into a config
            
            //check required values
            if (newMember.FirstName == string.Empty)
            {
                throw new Exception("First Name is required to save a new Contact to Salesforce");
            }
            else
            {
                newSalesforceContact.FirstName = newMember.FirstName;
                newSalesforceContact.member_FirstName__c = newMember.FirstName;

            }
            if (newMember.LastName == string.Empty)
            {
                throw new Exception("Last Name is required to save a new Contact to Salesforce");
            }
            else
            {
                newSalesforceContact.LastName = newMember.LastName;
                newSalesforceContact.member_LastName__c = newMember.LastName;
            }
           
            newSalesforceContact.member_MemberId__c = newMember.MemberId.ToString(); //member_MemberId__c is our sfdc external uid on Contact
            newSalesforceContact.member_UserId__c = newMember.UserId.ToString();
            newSalesforceContact.member_ScreenName__c = newMember.ScreenName;
            newSalesforceContact.member_allowConnections__c = newMember.allowConnections;
            newSalesforceContact.member_allowNewsletter__c = newMember.allowNewsletter;
            newSalesforceContact.member_emailSubscription__c = newMember.emailSubscription;
            newSalesforceContact.member_hasOtherChildren__c = newMember.hasOtherChildren;
            newSalesforceContact.member_isFacebookUser__c = newMember.isFacebookUser;
            newSalesforceContact.member_isPrivate__c = newMember.isPrivate;
            newSalesforceContact.member_PersonalityType__c = newMember.PersonalityType.ToString();
           


            newSalesforceContact.member_ScreenName__c = newMember.ScreenName;
            newSalesforceContact.member_ZipCode__c = newMember.ZipCode;
            newSalesforceContact.Email = "bgarnier_noreply@agencyoasis.com";
            
            //mapped guid values from Sitecore to Salesforce id. Pass in GUID from sitecore. Get back string ID from salesforce.

            newSalesforceContact.member_Role__c = Constants.SitecoreRoleGuid_to_SalesforceRoleId[newMember.Role];
            newSalesforceContact.Journey__c = Constants.SitecoreJourneyGuid_to_SalesforceJourneyId[newMember.Journeys.First().Key];

                //((Journey)newMember.Journeys.First()).Key.ToString();

            //exernal id field name is not the value of the userid. its our guid for member. the name of the field/column in sfdc
            //sfdc needs to know the primary, unique key to look for when updating existing rows
            UpsertResult result = _sfs.upsert("member_MemberId__c", 
                                new sObject[] { newSalesforceContact })[0];
            string SalesforceNewContactId = string.Empty;

            if (result.success == false) //failed to create member. stop upserts. return.
            {

                sfResult.Success = false;
                sfResult.Message = "An error occured during the upsert to Salesforce." +
                    Environment.NewLine;
                foreach (Error e in result.errors)
                    sfResult.Message += "* " + e.message + Environment.NewLine;
                return sfResult;
            }
            else
            {
                SalesforceNewContactId = result.id ;// lets see if this was smart enough to update our contact 
            }
            //create entrires for Interests
            foreach (Interest i in newMember.Interests)
            {
                MemberToInterests__c membertoInterest = new MemberToInterests__c();
                
                //i believe that I am going to need to get the ID of the user that was just created.
               // membertoInterest.MemberMaster__c = newMember.UserId.ToString();
                membertoInterest.MemberMaster__c = SalesforceNewContactId; 
          
                //lookup the Salesforce Id from the Sitecore Guid
                membertoInterest.MemberInterest__c = Constants.SalesforceLookupDictionary[i.Key];
                membertoInterest.Name = i.Value;

                //NEED to use an exernal id for any upserted rows.... 
                //i think for masterdetail records we want to just do an INSERT
                SaveResult interestSaveResult = _sfs.create(new sObject[] { membertoInterest })[0];
                if (interestSaveResult.success == false)
                {
                    sfResult.Success = false;
                    sfResult.Message = "An error occured during the upsert to Salesforce. Upserting Interest entries did not succeed." +
                        Environment.NewLine + "Error Messages: " + Environment.NewLine;
                    foreach (Error e in interestSaveResult.errors)
                    {
                        sfResult.Message += "Status code: (" + e.statusCode + ") Message: " + e.message + Environment.NewLine;
                    }
                    
                    return sfResult;
                 }
    
            }

            //add children to salesforce
            foreach (Child c in newMember.Children)
            {
                Children__c salesforceChild = new Children__c();
                salesforceChild.ContactChild__c = SalesforceNewContactId;
                salesforceChild.Grade__c = Constants.SalesforceLookupDictionary[(c.Grades.First().Key)];
                salesforceChild.Nickname__c = c.Nickname;
                salesforceChild.Name = c.Nickname;
                //child to issues need to be added like interests are after the child is created        

                SaveResult childSaveResult = _sfs.create(new sObject[]{salesforceChild})[0];
                if(childSaveResult.success == false)
                {
                    sfResult.Success = false;
                    sfResult.Message = "An error occured during the upsert to Salesforce. Upserting the Members Children did not succeed." +
                        Environment.NewLine + "Error Messages: " + Environment.NewLine;
                    foreach (Error e in childSaveResult.errors)
                    {
                        sfResult.Message += "Status code: (" + e.statusCode + ") Message: " + e.message + Environment.NewLine;
                    }
                    
                    return sfResult;
                }//-------------------
                //with this child successfully created, get the new child's salesforce id and add in issues into the salesforce lookup object
               
                foreach (Issue childIssue in c.Issues)
                {
                    ChildToIssues__c salesforceChildIssues = new ChildToIssues__c();
                    salesforceChildIssues.ChildMaster__c = childSaveResult.id; //we get back the ID that salesforce made during create
                    salesforceChildIssues.ChildIssue__c =Constants.SalesforceLookupDictionary[(childIssue.Key)];
                    salesforceChildIssues.Name = childIssue.Value;
                    SaveResult childIssuesSaveResult = _sfs.create(new sObject[] { salesforceChildIssues })[0];
                    if (childIssuesSaveResult.success == false)
                    {
                        sfResult.Success = false;
                        sfResult.Message = "An error occured during the upsert to Salesforce. Creating the Issues of Children did not succeed." +
                            Environment.NewLine + "Error Messages: " + Environment.NewLine;
                        foreach (Error e in childIssuesSaveResult.errors)
                        {
                            sfResult.Message += "Status code: (" + e.statusCode + ") Message: " + e.message + Environment.NewLine;
                        }
                        return sfResult;
                    }//-------------------

                   sfResult.Message= Environment.NewLine + 
                       "Save Result for Issue (Name:" + salesforceChildIssues.Name + Environment.NewLine +
                                                                    "|Issue:" + salesforceChildIssues.ChildIssue__c + Environment.NewLine +
                                                                    " |Success:" + childIssuesSaveResult.success.ToString();
                   
                }
                
        


            }
            //          
            return sfResult;
        }





    }
}
