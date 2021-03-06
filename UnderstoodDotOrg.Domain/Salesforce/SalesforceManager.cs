﻿using System;
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
        public SalesforceActionResult UpdateWebsiteMember(Member websiteMember)
        {
            SalesforceActionResult sfResult = new SalesforceActionResult();

            Contact salesforceContact = new Contact();
            //fill the contact with the current user's info
            //_sfs.retrieve(
            return sfResult;
        }
        /// <summary>
        /// We are not sure what kind of reports are going to be needed or newsletters are going to be produced
        /// but we can assume that if a user does something notable we may want to track that in sfdc as well
        /// </summary>
        /// <param name="WebsiteMemberId"></param>
        /// <param name="Activity"></param>
        /// <returns></returns>
        public SalesforceActionResult UploadMemberActivityData(Guid WebsiteMemberId, string Activity)
        {
            SalesforceActionResult sfResult = new SalesforceActionResult();

            return sfResult;
        }

        /// <summary>
        /// We have to track what donations are made into Luminate, by who, and for what campagin.
        /// This will need to be filled out after we know more about what kind of information is
        /// required when we make a donation
        /// </summary>
        /// <param name="WebsiteMemberId"></param>
        /// <param name="CampaignName"></param>
        /// <param name="DonationAmount"></param>
        /// <param name="LuminateId"></param>
        /// <returns></returns>
        public SalesforceActionResult UploadMemberDonationData(Guid WebsiteMemberId, string CampaignName, double DonationAmount, string LuminateId)
        {
            SalesforceActionResult sfResult = new SalesforceActionResult();

            return sfResult;
        }
        /// <summary>
        /// Pass a populated Member in and it will update salesforce.
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns>SalesforceSaveResult with success/fail bool & message if there was an error</returns>
        public SalesforceActionResult    CreateWebsiteMemberAsContact(Member newMember, string newMemberEmail) //member needs to be updated to have an email field
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
            if (string.IsNullOrEmpty(newMember.FirstName))
            {
                throw new Exception("First Name is required to save a new Contact Member to Service.");
            }
            else
            {
                newSalesforceContact.FirstName = newMember.FirstName;
                newSalesforceContact.member_FirstName__c = newMember.FirstName;
            }
            if (string.IsNullOrEmpty(newMember.LastName))
            {
                //last name will always be empty for now.
                //throw new Exception("Last Name is required to save a new Website Contact Member to Service.");
                newMember.LastName = "NotSpecified";
                newSalesforceContact.LastName = newMember.LastName;
                newSalesforceContact.member_LastName__c = newMember.LastName;
            }
            else
            {
                newSalesforceContact.LastName = newMember.LastName;
                newSalesforceContact.member_LastName__c = newMember.LastName;
            }
           
            newSalesforceContact.member_MemberId__c = newMember.MemberId.ToString(); //member_MemberId__c is our sfdc external uid on Contact
            newSalesforceContact.member_UserId__c = newMember.UserId.ToString();

            if (newMember.ScreenName == "Screen Name")//more garbage coming through
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 30000);
                newMember.ScreenName = "ScreenName_" + randomNumber.ToString(); 
            }
            newSalesforceContact.member_ScreenName__c = newMember.ScreenName;

            //Discovered that if you do not set both the field, and the specififed field, you don't update the checkbocx
            newSalesforceContact.member_allowConnections__c = newMember.allowConnections;
            newSalesforceContact.member_allowConnections__cSpecified = newMember.allowConnections;

            newSalesforceContact.member_allowNewsletter__c = newMember.allowNewsletter;
            newSalesforceContact.member_allowNewsletter__cSpecified = newMember.allowNewsletter;

            newSalesforceContact.member_emailSubscription__c = newMember.emailSubscription;
            newSalesforceContact.member_emailSubscription__cSpecified = newMember.emailSubscription;

            newSalesforceContact.member_hasOtherChildren__c = newMember.hasOtherChildren;
            newSalesforceContact.member_hasOtherChildren__cSpecified = newMember.hasOtherChildren;

            newSalesforceContact.member_isFacebookUser__c = newMember.isFacebookUser;
            newSalesforceContact.member_isFacebookUser__cSpecified = newMember.isFacebookUser;

            newSalesforceContact.member_isPrivate__c = newMember.isPrivate;
            newSalesforceContact.member_isPrivate__cSpecified = newMember.isPrivate;
            
            newSalesforceContact.member_ZipCode__c = newMember.ZipCode;
            newSalesforceContact.Email = newMemberEmail;            

            //garbage is getting in still. 
            if (newMember.Role != new Guid("{00000000-0000-0000-0000-000000000000}"))
            {
                newSalesforceContact.member_Role__c = Constants.SalesforceLookupDictionary[newMember.Role];
            }
            
            //Journey may be null 
            if (newMember.Journeys.Count >= 1)
            {
                newSalesforceContact.Journey__c = Constants.SalesforceLookupDictionary[newMember.Journeys.First().Key];
            }
            
            //ContactsPersonality
            //THERE IS ALSO A PERSONALITYTYPE IN THE WSDL. DO NOT USE IT.
            if(!string.IsNullOrEmpty(newMember.PersonalityType.ToString()))
            {
                //garbage is getting in. skip garbage.
                if(newMember.PersonalityType != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    newSalesforceContact.member_Personality__c = Constants.SalesforceLookupDictionary[newMember.PersonalityType];//.ToString();
         
                }

            }
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
                MemberToInterests__c sfdcMembertoInterest = new MemberToInterests__c();
                
                //i believe that I am going to need to get the ID of the user that was just created.
               // membertoInterest.MemberMaster__c = newMember.UserId.ToString();
                sfdcMembertoInterest.MemberMaster__c = SalesforceNewContactId; 
          
                //lookup the Salesforce Id from the Sitecore Guid
                sfdcMembertoInterest.MemberInterest__c = Constants.SalesforceLookupDictionary[i.Key];
                sfdcMembertoInterest.Name = i.Value;

                //NEED to use an exernal id for any upserted rows.... 
                //i think for masterdetail records we want to just do an INSERT
                SaveResult interestSaveResult = _sfs.create(new sObject[] { sfdcMembertoInterest })[0];
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
                Children__c sfdcChild = new Children__c();
                sfdcChild.ContactChild__c = SalesforceNewContactId;
                sfdcChild.Grade__c = Constants.SalesforceLookupDictionary[(c.Grades.First().Key)];

                //these are blowing up with garbage values getting through
                if (c.Section504Status != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    sfdcChild.ChildTo504Status__c = Constants.SalesforceLookupDictionary[c.Section504Status];
                }
                if (c.EvaluationStatus != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                   sfdcChild.ChildToEvaluationStatus__c = Constants.SalesforceLookupDictionary[c.EvaluationStatus];
                }
                if (c.IEPStatus != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    sfdcChild.ChildToIEPStatus__c = Constants.SalesforceLookupDictionary[c.IEPStatus];
                }
             
                sfdcChild.Nickname__c = c.Nickname;
                sfdcChild.Name = c.Nickname;
                
                //include a guid for the child's id
                sfdcChild.UnderstoodChildId__c = c.ChildId.ToString() ;
                SaveResult sfdcChildSaveResult = _sfs.create(new sObject[]{sfdcChild})[0];

                if(sfdcChildSaveResult.success == false)
                {
                    sfResult.Success = false;
                    sfResult.Message = "An error occured during the upsert to Salesforce. Upserting the Members Children did not succeed." +
                        Environment.NewLine + "Error Messages: " + Environment.NewLine;
                    foreach (Error e in sfdcChildSaveResult.errors)
                    {
                        sfResult.Message += "Status code: (" + e.statusCode + ") Message: " + e.message + Environment.NewLine;
                    }   
                    return sfResult;
                }
                //=====================================================================================================
             
                //with this child successfully created, we can now add rows to other objects that reference the child
                //get the new child's salesforce id and add in issues into the salesforce lookup object
                foreach (Issue childIssue in c.Issues)
                {
                    ChildToIssues__c sfdcforceChildIssues = new ChildToIssues__c();
                    sfdcforceChildIssues.ChildMaster__c = sfdcChildSaveResult.id; //we get back the ID that salesforce made during create
                    sfdcforceChildIssues.ChildIssue__c =Constants.SalesforceLookupDictionary[childIssue.Key];
                    sfdcforceChildIssues.Name = childIssue.Value;
                    SaveResult sr = _sfs.create(new sObject[] { sfdcforceChildIssues })[0];
                    if (sr.success == false)
                    {
                        sfResult.Success = false;
                        sfResult.Message = "An error occured during the upsert to Salesforce. Creating the Issues of Children did not succeed." +
                            Environment.NewLine + "Error Messages: " + Environment.NewLine;
                        foreach (Error e in sr.errors)
                        {
                            sfResult.Message += "Status code: (" + e.statusCode + ") Message: " + e.message + Environment.NewLine;
                        }
                        return sfResult;
                    }//-------------------
                    sfResult.Message= Environment.NewLine + 
                                                "Save Result for Issue (Name:" + sfdcforceChildIssues.Name + Environment.NewLine +
                                                                    "|Issue:" + sfdcforceChildIssues.ChildIssue__c + Environment.NewLine +
                                                                   " |Success:" + sr.success.ToString();                   
                }
                //save child diagnosis values
                foreach (Diagnosis childDiagnosis in c.Diagnoses)
                {
                    ChildToDiagnosis__c salesforceChildDiagnosis = new ChildToDiagnosis__c();
                    salesforceChildDiagnosis.ChildMaster__c = sfdcChildSaveResult.id;
                    salesforceChildDiagnosis.ChildDiagnosis__c = Constants.SalesforceLookupDictionary[childDiagnosis.Key];
                    salesforceChildDiagnosis.Name = childDiagnosis.Value;
                    SaveResult sr = _sfs.create(new sObject[] { salesforceChildDiagnosis })[0];
                    if (sr.success == false)
                    {
                        sfResult.Success = false;
                        sfResult.Message = "Error when saving child Diagnosis: " + sr.errors.First().message;
                        return sfResult;
                    }
                }
            }
            //          
            return sfResult;
        }
    }
}
