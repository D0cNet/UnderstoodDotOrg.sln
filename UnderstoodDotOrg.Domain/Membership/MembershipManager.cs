using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.Security;
using UnderstoodDotOrg.Domain.Understood.Quiz;
using UnderstoodDotOrg.Common.Helpers;
using MembershipProvider = System.Web.Security.Membership;
using System.Data;


namespace UnderstoodDotOrg.Domain.Membership
{
    public class MembershipManager : IMembershipManager, IDisposable
    {
        /// <summary>
        /// Global reference to DB Context
        /// </summary>
        Membership _db;

        /// <summary>
        /// Entity-specific connection string, injects in correct database from connectionstrings collection in settings
        /// </summary>
        //private static string connString = string.Format("metadata=res://*/Membership.MembershipModel.csdl|res://*/Membership.MembershipModel.ssdl|res://*/Membership.MembershipModel.msl;provider=System.Data.SqlClient;provider connection string='{0}persist security info=True;MultipleActiveResultSets=True;App=EntityFramework'", "data source=162.209.22.3;initial catalog=Understood.org.DEV.membership;user id=understood_org;password=dahyeSDf;");
        private static string connString = string.Format("metadata=res://*/Membership.MembershipModel.csdl|res://*/Membership.MembershipModel.ssdl|res://*/Membership.MembershipModel.msl;provider=System.Data.SqlClient;provider connection string='{0};persist security info=True;MultipleActiveResultSets=True;App=EntityFramework'", ConfigurationManager.ConnectionStrings["membership"].ConnectionString);

        #region Constructors
        public MembershipManager()
            : this(new Membership(connString))
        { }

        public MembershipManager(Membership db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        #endregion

        #region Adds
        /// <summary>
        /// Adds a new member to the database
        /// </summary>
        /// <param name="Member">Member to add</param>
        /// <returns>Member that was added</returns>
        public Member AddMember(Member Member)
        {
            try
            {
                //using (_db)
                //{
                #region here lies crap that could work but looks like crap
                //var changes = new Dictionary<Guid, string>();

                //for (int i = 0; i < Member.Interests.Count; i++)
                //{
                //    var m = Member.Interests.ElementAt(i);
                //    m = this.GetInterest(m.Key);

                //    if (!changes.ContainsKey(m.Key))
                //    {
                //        db.Entry(m).State = EntityState.Unchanged;
                //        changes.Add(m.Key, m.Value);
                //    }

                //}

                //var interests = new List<Interest>();
                //var journeys = new List<Journey>();
                //var children = new List<Child>();


                //var tempMember = new Member();
                //tempMember.Interests = db.Interests.Where(i => Member.Interests.Contains) )

                //foreach (var item in Member.Interests)
                //{
                //    var t = this.GetInterest(item.Key);
                //    t.Members.Add(Member);

                //    interests.Add(t);
                //}

                //foreach (var item in Member.Journeys)
                //{
                //    var t = this.GetJourney(item.Key);
                //    t.Members.Add(Member);

                //    journeys.Add(t);
                //}

                //Member.Journeys.Clear();
                //Member.Interests.Clear();

                //foreach (var child in Member.Children)
                //{
                //for (int i = 0; i < child.Issues.Count; i++)
                //{
                //    var issue = child.Issues.ElementAt(i);
                //    issue = this.GetIssue(issue.Key);

                //    if (!changes.ContainsKey(issue.Key))
                //    {
                //        _db.Entry(issue).State = EntityState.Unchanged;
                //        changes.Add(issue.Key, issue.Value);                                
                //    }
                //}

                //var tempChild = new Child();

                ////issue mapping
                //foreach (var issue in child.Issues)
                //{
                //    var t = this.GetIssue(issue.Key);
                //    t.Children.Add(child);

                //    tempChild.Issues.Add(t);
                //}

                ////grade mapping
                //foreach (var grade in child.Grades)
                //{
                //    var t = this.GetGrade(grade.Key);
                //    t.Children.Add(child);

                //    tempChild.Grades.Add(t);
                //}

                ////diagnosis mapping
                //foreach (var diagnosis in child.Diagnoses)
                //{
                //    var t = this.GetDiagnosis(diagnosis.Key);
                //    t.Children.Add(child);

                //    tempChild.Diagnoses.Add(t);
                //}

                //children.Add(tempChild);

                //child.Issues.Clear();
                //child.Diagnoses.Clear();
                //child.Grades.Clear();
                //}

                //_db.Members.Add(Member);

                //foreach (var item in interests)
                //{
                //    db.Interests.Attach(item);
                //}

                //foreach (var item in journeys)
                //{
                //    db.Journeys.Attach(item);
                //}

                //foreach (var child in children)
                //{
                //    foreach (var issue in child.Issues)
                //    {
                //        db.Issues.Attach(issue);
                //    }

                //    foreach (var grade in child.Grades)
                //    {
                //        db.Grades.Attach(grade);
                //    }

                //    foreach (var diagnosis in child.Diagnoses)
                //    {
                //        db.Diagnoses.Attach(diagnosis);
                //    }
                //}
                #endregion

                var tMember = this.mapMember(Member);

                _db.Members.Add(tMember);
                _db.SaveChanges();
                //seed a row in the alert preferences table
                SeedMemberAlertPrefernceTable(tMember.MemberId);


                return tMember;
                //}
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw ex;
            }
        }

        /// <summary>
        /// Adds a new "shadow user" to the database
        /// </summary>
        /// <param name="Member"></param>
        /// <returns></returns>
        public Member AddUnauthorizedMember(Member Member)
        {
            //throw this out if there is no email 
            if (string.IsNullOrEmpty(Member.Email))
            {
                throw new Exception("Error in MembershipManager.cs. An email address must be provided to add a member.");
            }
            //bg: Note. We are going to use the ASP.Net Membership database's comment field
            //          to include a flag that can be used to identify users who only exist  in order 
            //          for us to generate content sent for Nebased on "The Algorithim" 
            //-- Setting up some values so that we know that this is not a standard website member
            //this member is probably only ever going to be created just so that we can generate personalized emails
            Member.Password = UnderstoodDotOrg.Common.Constants.UnauthenticatedMember_Password;
            Member.Comment = UnderstoodDotOrg.Common.Constants.UnauthenticatedMember_Flag;
            Member.ScreenName = UnderstoodDotOrg.Common.Constants.UnauthenticatedMember_ScreeName;

            Member m = new Member();
            try
            {
                m = this.AddMember(Member, Member.Email, Member.Password); //Need to refactor some code to account for Member having an email and password
            }

            catch (Exception e)
            {
                Exception e2 = new Exception("An Error occured when trying to create a new Unauthorized Member. Check InnerException", e);
                e2.Source = "MembershiopManager.cs In AddUnauthorizedMember(Member Member)";
                throw e2;
            }
            //now update the member to add the flag to let us know it is a unauthorized user
            AddMemberComment(m, UnderstoodDotOrg.Common.Constants.UnauthenticatedMember_Flag);

            return m;
        }

        /// <summary>
        /// Adds a new user to the authentication database, and then adds a new member to the membership database. 
        /// When in doubt, you probably want to use this one
        /// </summary>
        /// <param name="Member">Member to add</param>
        /// <param name="Username">Username (email addess) for ASP.Net Authentication</param>
        /// <param name="Password">Password for the user</param>
        /// <returns>Member that was added</returns>
        public Member AddMember(Member Member, string Username, string Password)
        {
            try
            {
                // use custom provider for authentication
                var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];

                int existingUserCount;
                var isExistingUser = provider.FindUsersByEmail(Username, 0, 1, out existingUserCount);

                if (existingUserCount == 0)
                {
                    if (Member.MemberId == null || Member.MemberId == Guid.Empty)
                    {
                        Member.MemberId = Guid.NewGuid();
                    }

                    var status = new MembershipCreateStatus();

                    var user = provider.CreateUser(Username, Password, Username, null, null, true, Member.MemberId, out status);

                    if (status != MembershipCreateStatus.Success)
                    {
                        throw new Exception("Unable to create user. Reason: " + status);
                    }

                    Member = this.AddMember(Member);


                    return Member;
                }
                else
                {
                    throw new Exception("Username is not unique");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds a new child to the membership database
        /// </summary>
        /// <param name="Child">Child to add</param>
        /// <param name="MemberId">Guid of Member that the child should be linked to</param>
        /// <returns>Child that was added</returns>
        public Child AddChild(Child Child, Guid MemberId)
        {
            try
            {
                //using (_db)
                //{
                Child = mapChild(Child);
                Child.Members.Add(_db.Members.Where(x => x.MemberId == MemberId).First());

                _db.Children.Add(Child);
                _db.SaveChanges();

                return Child;
                //}
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw ex;
            }
        }

        #endregion

        #region Gets
        /// <summary>
        /// Returns custom Member object
        /// </summary>
        /// <param name="MemberId">Member ID of member</param>
        /// <returns>Member object that was requested, or null</returns>
        public Member GetMember(Guid MemberId)
        {
            //using (_db)
            //{
            var member = _db.Members
                .Where(x => x.MemberId == MemberId)
                .Include(x => x.Children)
                .Include(x => x.Children.Select(c => c.Issues))
                .Include(x => x.Children.Select(c => c.Diagnoses))
                .Include(x => x.Children.Select(c => c.Grades))
                .Include(x => x.Journeys)
                .Include(x => x.Interests)
                .ToList()
                .FirstOrDefault();

            if (member != null)
            {
                //bg: update the member with property values that are not included in entity
                member = FillMember_ExtendedPropertiesFromDb(member);
                member = FillMember_AlertPreferences(member);

                //now with email!
                var user = this.GetUser(member.MemberId);
                if (user != null)
                {
                    member.Email = user.Email;
                }
                //refactor this later, move email to first-class citizen in the Membership database

                return trimFields(member);
            }

            return member;
        }

        /// <summary>
        /// Returns custom Member object
        /// </summary>
        /// <param name="EmailAddress">Email address of member</param>
        /// <returns>Member object that was requested, or null</returns>
        public Member GetMember(string EmailAddress)
        {
            var user = this.GetUser(EmailAddress, true);
            // TODO: refactor this using LINQ once we add Email to entity model

            if (user == null)
            {
                return null;
            }

            return this.GetMember(Guid.Parse(user.ProviderUserKey.ToString()));
        }

        public Member GetMemberByScreenName(string ScreenName)
        {
            var member = _db.Members.FirstOrDefault(x => x.ScreenName == ScreenName);

            if (member == null)
            {
                return null;
            }

            //might be able to shortcut by just returning the member we have...but what if...?
            return this.GetMember(member.MemberId);
        }

        /// <summary>
        /// Returns ASP.Net MembershipUser object by Member Guid
        /// </summary>
        /// <param name="MemberId">Guid of member to return</param>
        /// <param name="updateIsOnline">Tells ASP.Net Membership if it should modify the UserLastActive value</param>
        /// <returns>MembershipUser that was requested</returns>
        public MembershipUser GetUser(Guid MemberId, bool updateIsOnline = false)
        {
            var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];

            return provider.GetUser(MemberId, updateIsOnline);
        }

        /// <summary>
        /// Returns the ASP.Net MembershipUser object by Email Address
        /// </summary>
        /// <param name="EmailAddress">Email Address (username) of the requested user</param>
        /// <param name="updateIsOnline">Tells ASP.Net Membership if it should modify the UserLastActive value</param>
        /// <returns></returns>
        public MembershipUser GetUser(string EmailAddress, bool updateIsOnline = false)
        {
            var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];

            return provider.GetUser(EmailAddress, updateIsOnline);
        }

        /// <summary>
        /// Returns Child by Child Guid
        /// </summary>
        /// <param name="ChildId">Guid of child to return</param>
        /// <returns>Child that was requested</returns>
        public Child GetChild(Guid ChildId)
        {
            Child child = new Child();

            //using (_db)
            //{
            child = _db.Children
                .Where(c => c.ChildId == ChildId)
                .Include(c => c.Diagnoses)
                .Include(c => c.Issues)
                .Include(c => c.Members)
                .Include(c => c.Members.Select(m => m.Interests))
                .Include(c => c.Members.Select(m => m.Journeys))
                .Include(c => c.Grades)
                .FirstOrDefault();
            //}

            if (child != null)
            {
                child = trimFields(child);
            }

            return child;
        }

        /// <summary>
        /// Returns a list of all Members
        /// </summary>
        /// <returns>List of all Members in the database</returns>
        public List<Member> GetMembers()
        {
            //List<Member> members = null; 
            //using (var db = new Membership(connString))
            //{
            //    var query = from m in db.Members
            //                select m;
            //    members = query.ToList<Member>();             
            //}
            //return members;

            return _db.Members.ToList();
        }

        #endregion

        #region Updates
        /// <summary>
        /// Updates information about an existing member
        /// </summary>
        /// <param name="Member">Member to update</param>
        /// <returns>Member that was updated</returns>
        public Member UpdateMember(Member Member)
        {
            //if screen != null && telligentuser.getusrbyscreenname != null -> create user
            //TelligentService.GetPosesMember(string screenName)
            //CommunityHelper.CreateUser(screenname, email)

            //bg: Update member properties that are outside of entity:
            //    UpdateMember_ExtendedProperties checks a n data flag on member, 
            //    and does nothing if none of the new properties have been set outside of the database
            if (!this.UpdateMember_ExtendedProperties(Member))
            {
                throw new Exception("An error occured when trying to update extended member proprerties.");
            }


            try
            {
                if (!ClearnAllMemberInterests(Member.MemberId))
                {
                    throw new Exception("An error occured when trying to update member interests.");
                }
            }
            catch (Exception ex)
            {
                //log the exception 
                //bubble it up so the error can be displayed
                throw ex;
            }
            try
            {
                Member = this.mapMember(Member);

                _db.SaveChanges();

                return Member;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw ex;
            }

        }

        /// <summary>
        /// Updates information about an existing child
        /// </summary>
        /// <param name="Child">Child to update</param>
        /// <returns>Child that was updated</returns>
        public Child UpdateChild(Child Child)
        {
            try
            {
                Child = this.mapChild(Child);

                _db.SaveChanges();

                return Child;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw ex;
            }
        }

        public bool UpdateEmail(Member Member, string newEmail)
        {
            var ret = false;

            if (!string.IsNullOrEmpty(Member.Email) && !string.IsNullOrEmpty(newEmail))
            {
                try
                {
                    var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];
                    var user = provider.GetUser(Member.MemberId, false);

                    //update username via stored procedure
                    ret = this.updateEmail(provider.ApplicationName, user.UserName, newEmail);

                    if (ret)
                    {
                        user = provider.GetUser(Member.MemberId, false);

                        user.Email = newEmail;

                        //update email property on ASP.Net user
                        provider.UpdateUser(user);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return ret;
        }

        public bool UpdatePassword(Member Member, string oldPassword, string newPassword)
        {
            var ret = false;

            var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];
            var user = provider.GetUser(Member.MemberId, false);

            try
            {
                ret = user.ChangePassword(oldPassword, newPassword);
                
                if (!ret)
                {
                    //provided wrong password
                    throw new Exception("Password reset failed, please try again");
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }

            return ret;
        }

        private bool updateEmail(string applicationName, string oldUsername, string newUsername)
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["membership"].ConnectionString;

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = "usp_ChangeUsername";
                myCommand.CommandType = CommandType.StoredProcedure;

                myCommand.Parameters.AddWithValue("@ApplicationName", applicationName);
                myCommand.Parameters.AddWithValue("@OldUserName", oldUsername);
                myCommand.Parameters.AddWithValue("@NewUserName", newUsername);

                SqlParameter retValParam = new SqlParameter("@ReturnValue", SqlDbType.Int);
                retValParam.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(retValParam);

                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();

                int returnValue = -1;
                if (retValParam.Value != null)
                {
                    returnValue = Convert.ToInt32(retValParam.Value);
                }

                if (returnValue != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        #endregion

        #region Support Methods

        #region Private
        /// <summary>
        /// Private method that maps a potentially Entity-disconnected Member to a known-connected instance
        /// </summary>
        /// <param name="Member">Potentially disconnected Member</param>
        /// <returns>Known connected Member</returns>
        private Member mapMember(Member Member)
        {
            var tMember = _db.Members.Where(x => x.MemberId == Member.MemberId).FirstOrDefault();

            if (tMember == null)
            {
                tMember = new Member();
                tMember.MemberId = Member.MemberId;
            }

            tMember.AgreedToSignUpTerms = Member.AgreedToSignUpTerms;
            tMember.allowConnections = Member.allowConnections;
            tMember.allowNewsletter = Member.allowNewsletter;
            tMember.emailSubscription = Member.emailSubscription;
            tMember.hasOtherChildren = Member.hasOtherChildren;
            tMember.isFacebookUser = Member.isFacebookUser;
            tMember.isPrivate = Member.isPrivate;
            tMember.PersonalityType = Member.PersonalityType;
            tMember.Role = Member.Role;
            tMember.ScreenName = Member.ScreenName.RemoveHTML();
            tMember.UserId = Member.UserId;

            if (!string.IsNullOrEmpty(Member.FirstName))
            {
                tMember.FirstName = Member.FirstName.RemoveHTML();
            }
            if (!string.IsNullOrEmpty(Member.LastName))
            {
                tMember.LastName = Member.LastName.RemoveHTML();
            }
            if (Member.Phone != null)
            {
                tMember.Phone = Member.Phone;
            }
            if (!string.IsNullOrEmpty(Member.ZipCode))
            {
                tMember.ZipCode = Member.ZipCode.RemoveHTML();
            }

            tMember.Interests.Clear();
            tMember.Journeys.Clear();

            foreach (var interest in Member.Interests)
            {
                var i = _db.Interests.Where(x => x.Key == interest.Key).FirstOrDefault();
                if (i != null)
                {
                    tMember.Interests.Add(i);
                }
            }

            foreach (var journey in Member.Journeys)
            {
                var j = _db.Journeys.Where(x => x.Key == journey.Key).FirstOrDefault();
                if (j != null)
                {
                    tMember.Journeys.Add(j);
                }
            }

            foreach (var child in Member.Children)
            {
                var tChild = mapChild(child);

                tMember.Children.Add(tChild);
            }

            return tMember;
        }

        /// <summary>
        /// Private method that maps a potentially Entity-disconnected Child to a known-connected instance
        /// </summary>
        /// <param name="child">Potentially disconnected Child</param>
        /// <returns>Known connected Child</returns>
        private Child mapChild(Child child)
        {
            //var tChild = _db.Children.Where(x => x.ChildId == child.ChildId).FirstOrDefault();
            var tChild = this.GetChild(child.ChildId);

            if (tChild == null)
            {
                tChild = new Child();
                tChild.ChildId = child.ChildId;
            }

            tChild.EvaluationStatus = child.EvaluationStatus;
            tChild.Gender = child.Gender.RemoveHTML();

            //gender is required, boy is now default if nothing is provided
            if (string.IsNullOrEmpty(tChild.Gender))
            {
                tChild.Gender = "boy";
            }

            tChild.HomeLife = child.HomeLife;
            tChild.IEPStatus = child.IEPStatus;
            tChild.Nickname = child.Nickname.RemoveHTML();

            //DB field limited to 20 characters, try to use more and this will puke
            if (tChild.Nickname.Length > 20)
            {
                tChild.Nickname = tChild.Nickname.Substring(0, 20);
            }

            tChild.Section504Status = child.Section504Status;

            tChild.Issues.Clear();
            tChild.Grades.Clear();
            tChild.Diagnoses.Clear();

            foreach (var issue in child.Issues)
            {
                var i = _db.Issues.Where(x => x.Key == issue.Key).FirstOrDefault();
                if (i != null)
                {
                    tChild.Issues.Add(i);
                }
            }

            foreach (var diagnosis in child.Diagnoses)
            {
                var d = _db.Diagnoses.Where(x => x.Key == diagnosis.Key).FirstOrDefault();
                if (d != null)
                {
                    tChild.Diagnoses.Add(d);
                }
            }

            foreach (var grade in child.Grades)
            {
                var g = _db.Grades.Where(x => x.Key == grade.Key).FirstOrDefault();
                if (g != null)
                {
                    tChild.Grades.Add(g);
                }
            }

            return tChild;
        }

        #endregion

        #region Public
        /// <summary>
        /// Verifies credentials and process login for the user. Uses ASP.Net Membership for authentication and sets the Sitecore Virtual User
        /// </summary>
        /// <param name="Username">Email address of the user</param>
        /// <param name="Password">User's password</param>
        /// <returns>Returns an instance of the Member object filled with the current user, if authentication is successful</returns>
        public Member AuthenticateUser(string Username, string Password)
        {
            // use custom provider
            var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];

            // authenticate against custom provider
            var isAuthenticated = provider.ValidateUser(Username, Password);
            if (!isAuthenticated)
            {
                throw new Exception("Invalid Username or Password");
            }

            // set SC virtual user

            // set Telligent user

            var membershipUser = provider.GetUser(Username, true);
            Member member = new Member();

            try
            {
                member = this.GetMember(Guid.Parse(membershipUser.ProviderUserKey.ToString()));
                if (member == null)
                {
                    throw new Exception("Membership User does not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return member;
        }

        /// <summary>
        /// Resets a member's password to the new password
        /// </summary>
        /// <param name="MemberId">MemberID to update</param>
        /// <param name="NewPassword">New password</param>
        /// <returns>True if password was successfully updated</returns>
        public bool ResetPassword(Guid MemberId, string NewPassword)
        {
            try
            {
                var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];
                var user = provider.GetUser(MemberId, false);

                user.ChangePassword(user.ResetPassword(), NewPassword);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Trims HTML and whitespace from Member string fields
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static Member trimFields(Member member)
        {
            member.FirstName = member.FirstName != null ? member.FirstName.Trim() : string.Empty;
            member.ScreenName = member.ScreenName != null ? member.ScreenName.Trim() : string.Empty;
            member.LastName = member.LastName != null ? member.LastName.Trim() : string.Empty;
            member.ZipCode = member.ZipCode != null ? member.ZipCode.Trim() : string.Empty;
            member.MobilePhoneNumber = member.MobilePhoneNumber != null ? member.MobilePhoneNumber.Trim() : string.Empty;

            return member;
        }

        /// <summary>
        /// Trims HTML and whitespace from Child string fields
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public static Child trimFields(Child child)
        {
            child.Nickname = child.Nickname != null ? child.Nickname.Trim() : string.Empty;
            child.Gender = child.Gender != null ? child.Gender.Trim() : string.Empty;

            return child;
        }

        /// <summary>
        /// Returns true or false if a Child ID already exists
        /// </summary>
        /// <param name="ChildId">Child ID to check</param>
        /// <returns>True if child exists, false if not</returns>
        public bool isExistingChild(Guid ChildId)
        {
            var child = _db.Children.FirstOrDefault(x => x.ChildId == ChildId);

            if (child != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns trus or false based on the user's connection settings
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>true if user is open to connecting, false if the user is not open to connect or does not exist</returns>
        public static bool isOpenToConnect(string username)
        {
            string sql = "SELECT allowConnections FROM Members WHERE (ScreenName = @Username)";
            bool ret = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ret = reader.GetBoolean(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ret;
        }

        #endregion

        #endregion

        /// <summary>
        /// It will help if we pull the data back from the db so we can display it and use it.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private Member FillMember_AlertPreferences(Member member)
        {
            string sql = " SELECT AdvocacyAlerts, " +
                                " ContentReminders, " +
                                " EventReminders, " +
                                " ObservationLogReminders, " +
                                " SupportPlanReminders, " +
                                " PrivateMessageAlerts " +
                                " FROM MemberAlertPreferences " +
                                " WHERE (MemberId = @MemberId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                member.AdvocacyAlerts = reader.GetBoolean(0);
                                member.ContentReminders = reader.GetBoolean(1);
                                member.EventReminders = reader.GetBoolean(2);
                                member.NotificationsDigest = false;//gotta check if this is in the db. bg: bug. think we might have dupe data
                                member.ObservationLogReminders = reader.GetBoolean(3);
                                member.SupportPlanReminders = reader.GetBoolean(4);
                                member.PrivateMessageAlerts = reader.GetBoolean(5);
                                //member.allowNewsletter; //set in entity

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }

        /// <summary>
        /// Just used to add an entry into our pref table. Anything here on out is always an update
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        private bool SeedMemberAlertPrefernceTable(Guid MemberId)
        {
            bool success = false;
            string sql = " INSERT INTO MemberAlertPreferences(MemberId) " +
                         " VALUES (@MemberId) ";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            success = true;
            return success;
        }

        /// <summary>
        /// Updates the MemberAlertPreferences 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool UpdateMemberAlertPrefernces(Member member)
        {
            bool success = false;
            string sql = " UPDATE MemberAlertPreferences " +
                            "SET  SupportPlanReminders = @SupportPlanReminders, " +
                                " ObservationLogReminders = @ObservationLogReminders, " +
                                " EventReminders = @EventReminders, " +
                                " ContentReminders = @ContentReminders, " +
                                " AdvocacyAlerts = @AdvocacyAlerts, " +
                                " PrivateMessageAlerts = @PrivateMessageAlerts" +
                                " WHERE (MemberId = @MemberId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                        cmd.Parameters.AddWithValue("@SupportPlanReminders", member.SupportPlanReminders);
                        cmd.Parameters.AddWithValue("@ObservationLogReminders", member.ObservationLogReminders);
                        cmd.Parameters.AddWithValue("@EventReminders", member.EventReminders);
                        cmd.Parameters.AddWithValue("@ContentReminders", member.ContentReminders);
                        cmd.Parameters.AddWithValue("@AdvocacyAlerts", member.AdvocacyAlerts);
                        cmd.Parameters.AddWithValue("@PrivateMessageAlerts", member.PrivateMessageAlerts);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }

        /// <summary>
        /// Updates the .Net member in our Membership Database to include a comment.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        private bool AddMemberComment(Member member, string Comment)
        {
            bool commentAdded = false;
            try
            {
                MembershipUser mUsr = GetUser(member.MemberId);
                mUsr.Comment = Comment;
                var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];
                provider.UpdateUser(mUsr);
                //comment added.
                commentAdded = true;
            }
            catch (Exception e)
            {
            }
            return commentAdded;
        }

        /// <summary>
        /// Used to inflate a member's quiz items and the responses that the user has saved to the db so far
        /// </summary>
        /// <param name="member">An inflated website Member</param>
        /// <returns>The same member, but now with quiz results.</returns>
        public Member QuizResults_FillMember(Member member)
        {
            string sql = "SELECT QuizId, QuestionId, AnswerValue " +
                " FROM  QuizResults " +
                " WHERE (MemberId = @MemberId) " +
                " ORDER BY QuizId"; //ordering by QuizId will let us loop through rows and know when to make a new Quiz object. 

            //each time we encounter a new quizid we need to populate a new set of quiz answers
            //default guid is a throw away
            Quiz quiz = new Quiz();
            quiz.QuizID = Guid.NewGuid();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            //first thing first. Clear out any existing items in the current member.
                            if (member.CompletedQuizes.Any())
                            {
                                member.CompletedQuizes.Clear();
                            }
                            bool firstrow = true;
                            while (reader.Read())
                            {
                                //see if we need a new quiz or of the existing quiz we are working with is still good.
                                if (quiz.QuizID != reader.GetGuid(0))// 0=QuizId. True when a new quiz is found. Always true for the first row.
                                {
                                    if (!firstrow)//dont add a filled quiz if this is the first read from the reader. New quiz id, but first quiz
                                    {
                                        //save the last quiz to the member
                                        member.CompletedQuizes.Add(quiz);//save the quiz that we were filling to the list.
                                    }
                                    else
                                    {
                                        firstrow = false;//this was the first row, now its not
                                    }
                                    quiz = new Quiz();//A new set of quiz answers was found. Setup a new quiz container
                                    quiz.QuizID = reader.GetGuid(0);// (0)=QuizId.
                                }
                                //every single row is always a new QuizItem
                                QuizItem quizItem = new QuizItem();
                                quizItem.QuestionId = reader.GetGuid(1);//(1)=QuestionId

                                //always check for nulls from a reader or it *will* eventually break.
                                if (!reader.IsDBNull(2))//(2)=AnswerValue
                                {
                                    quizItem.AnswerValue = reader.GetString(2);//(2)=AnswerValue
                                }
                                else
                                {
                                    quizItem.AnswerValue = string.Empty;
                                }
                                quiz.MemberAnswers.Add(quizItem);
                            }// * no matter what now, there is still a quiz that needs to still be added to member 
                            // * reader stops when there are no more rows to read, but we still haven't added the last quiz                            
                            member.CompletedQuizes.Add(quiz);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member; //if the member had any quiz results in the db, it is now inflated with them

        }

        public bool ChecklistResults_SaveToDb(Guid MemberId, Checklist checklist)
        {
            bool successFlag = false;
            QuizResults_SaveToDb(MemberId, checklist);
            successFlag = true;
            return successFlag;
        }

        /// <summary>
        /// We can come back to this later but right now we are going to blow out
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool QuizResults_SaveToDb(Guid MemberId, Quiz quiz)
        {
            bool success = false;
            //clear out the existing quiz
            if (!DeleteQuizResults(MemberId, quiz.QuizID))
            {
                throw new Exception("An error occured when trying to clear existing quiz data.");
            }
            //save the member's results
            string sql = " INSERT INTO QuizResults " +
                                   " (MemberId, QuizId, QuestionId, AnswerValue) " +
                           "  VALUES (@MemberId, @QuizId, @QuestionId, @AnswerValue) ";
            Guid QuizId = quiz.QuizID;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    foreach (QuizItem memberAnswer in quiz.MemberAnswers)
                    {
                        //insert an answer row
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MemberId", MemberId);
                            cmd.Parameters.AddWithValue("@QuizId", QuizId);
                            cmd.Parameters.AddWithValue("@QuestionId", memberAnswer.QuestionId);
                            cmd.Parameters.AddWithValue("@AnswerValue", memberAnswer.AnswerValue);
                            cmd.ExecuteNonQuery();
                            success = true;
                            cmd.Parameters.Clear();//clear out the existing params for the next iteration
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            success = true;

            return success;
        }

        /// <summary>
        /// Clears out the current database entries for the Member's quiz results
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="QuizId"></param>
        /// <returns></returns>
        private bool DeleteQuizResults(Guid MemberId, Guid QuizId)
        {
            bool success = false;
            try
            {
                string sql = "DELETE FROM QuizResults " +
                      " WHERE (MemberId = @MemberId) AND (QuizId = @QuizId)";

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.Parameters.AddWithValue("@QuizId", QuizId);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }
        public bool LogMemberActivity_AsDeleted(Guid MemberId, Guid ContentId, string Activity, int ActivityType)
        {
            bool successFlag = false;
            string sql = " UPDATE dbo.MemberActivity " +
                           " SET Deleted = 1 " +
                           " WHERE (MemberId = @MemberId) AND " +
                                 " ([Key] = @ContentId) AND " +
                                 " (Value = @ActivityValue) AND " +
                                 " (ActivityType = @ActivityType)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.Parameters.AddWithValue("@ContentId", ContentId);
                        cmd.Parameters.AddWithValue("@ActivityValue", Activity);
                        cmd.Parameters.AddWithValue("@ActivityType", ActivityType);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            successFlag = true;
            return successFlag;
        }
        /// <summary>
        /// Method deletes activities from from the database. Was being used privately, now exposed.
        /// </summary>
        /// <param name="MemberId">The target member's guid</param>
        /// <param name="ContentId">The content item's guid</param>
        /// <param name="Activity"></param>
        /// <param name="ActivityType">FoundHeplfulVoteType</param>
        /// <returns></returns>
        public bool ClearHelpfulVote(Guid MemberId, Guid ContentId, string Activity, int ActivityType)
        {
            bool success = false;
            try
            {
                //delete any rows where this user had previously added in a helpful or not helpful vote for this content item
                string sql = " DELETE FROM dbo.MemberActivity " +
                                " WHERE (MemberId = @MemberId) AND " +
                                 " ([Key] = @ContentId) AND " +
                                 " (ActivityType = @FoundHelpfulVoteType)";

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.Parameters.AddWithValue("@ContentId", ContentId);
                        cmd.Parameters.AddWithValue("@FoundHelpfulVoteType", ActivityType);
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            success = true;
            return success;

        }
        /// <summary>
        /// We record multiple states of helpfulness. Some are contextutal and are filtered on reads. 
        /// We also record both if an item WAS or WASNOT helpful as distinct rows. 
        /// </summary>
        /// <param name="MemberId">The member you are recording</param>
        /// <param name="ContentId">The content item they interacted with</param>
        /// <param name="Activity">Use Constants. UserActivity_Values</param>
        /// <param name="ActivityType">Use Constants. UserActivity_Types</param>
        /// <param name="SpecialFilter">Use Constatnts. UserActivity_SpecialFilters to provide context of WHERE this was found helpful.</param>
        /// <returns></returns>
        public bool LogMemberHelpfulVote (Guid MemberId, Guid ContentId, 
                                        string Activity, int ActivityType, 
                                        string SpecialFilter)
        {
            bool success = this.LogMemberHelpfulVote(MemberId,
                                ContentId,
                                Activity + "_" + SpecialFilter,
                                ActivityType );
            return success;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="ContentId"></param>
        /// <param name="Activity">Use Constants: UserActivity_Values</param>
        /// <param name="ActivityType">Use Constants: UserActivity_Types</param>
        /// <returns></returns>
        public bool LogMemberHelpfulVote(Guid MemberId, Guid ContentId, string Activity, int ActivityType)
        {
            bool success = false;
            //if the vote already exists then we drop the existing vote and insert a new one
            ClearHelpfulVote(MemberId, ContentId, Activity, ActivityType);

            //insert the vote
            LogMemberActivity(MemberId, ContentId, Activity, ActivityType);

            success = true;
            return success;
        }
        /// <summary>
        /// Records in our activity log a page view of a specific item within a specific subtopic
        /// </summary>
        /// <param name="MemberId"></param>
        /// <param name="ContentId"></param>
        /// <param name="Subtopic"></param>
        /// <returns></returns>
        public bool LogSubtopicPageView(Guid MemberId, Guid ContentId, Guid Subtopic)
        {
            return LogMemberActivity(MemberId,
                                ContentId,
                                UnderstoodDotOrg.Common.Constants.UserActivity_Values.SubtopicItemViewed + Subtopic.ToString(),
                                UnderstoodDotOrg.Common.Constants.UserActivity_Types.ContentRelated);

        }

        /// <summary>
        /// Inserts a row into our member activity log table with information about what the specified user has just done
        /// </summary>
        /// <param name="MemberId">Member object's MemberId</param>
        /// <param name="ContentId">Guid of the Sitecore Content Item involved </param>
        /// <param name="Activity">Can be a constant for easy of implementation but you can also passs in a URL or serialized xml</param>
        /// <param name="ActivityType">Constant Int for reporting purposes</param>
        /// <returns></returns>
        public bool LogMemberActivity(Guid MemberId, Guid ContentId, string Activity, int ActivityType)
        {
            bool success = false;


            try
            {

                string sql = "INSERT INTO dbo.MemberActivity " +
                                        " ([Key], MemberId, ActivityType, Value) " +
                                        " VALUES (@Key, @MemberId, @ActivityType, @Value)";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Key", ContentId);
                        cmd.Parameters.AddWithValue("@MemberId", MemberId);
                        cmd.Parameters.AddWithValue("@ActivityType", ActivityType);
                        cmd.Parameters.AddWithValue("@Value", Activity); //UnderstoodDotOrg.Common.Constants.UserActivityTypes.Favorited // - * example
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //bg: I would like to log this, need to find that log method again.
                throw ex;
            }
            success = true;


            //push this up into salesforce... eventually....
            return success;
        }

        private bool ClearnAllMemberInterests(Guid MemberId)
        {
            bool successFlag = false;

            //BG: Before we let entity do its thing we need to clear out some values. Entity is not checking for dirty flags, it is only doing inserts
            //it is however doing full atomic inserts so as long as we reset some one to many sets of data we will end up with the desired results, 
            //otherwise all we do is add to the list, and never can remove any itmes. blow them all out first, then let entity insert all of the values as it is.
            string sql = "member_ClearAllMemberInterests";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MemberId", MemberId);
                    cmd.ExecuteNonQuery();
                }
            }
            successFlag = true;
            return successFlag;
        }

        /// <summary>
        /// Fill the Member object with values from the database
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private Member FillMember_ExtendedPropertiesFromDb(Member member)
        {
            try
            {
                string sql = " SELECT  PreferedLanguage, AgreedToSignUpTerms, MobilePhoneNumber " +
                             " FROM  dbo.Members " +
                             " WHERE (MemberId = @MemberId)";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                member.PreferredLanguage = reader.GetGuid(0);
                                member.AgreedToSignUpTerms = reader.GetBoolean(1);
                                if (!reader.IsDBNull(2))
                                {
                                    member.MobilePhoneNumber = reader.GetString(2) ?? string.Empty;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //add in member alert preferences
            try
            {
                string sql = " SELECT [SupportPlanReminders] " +
                            " ,[ObservationLogReminders] " +
                            " ,[EventReminders] " +
                            " ,[ContentReminders] " +
                            " ,[AdvocacyAlerts] " +
                            " ,[PrivateMessageAlerts] " +
                            " FROM [dbo].[MemberAlertPreferences] " +
                            " Where MemberId =@MemberId";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                member.SupportPlanReminders = reader.GetBoolean(0);
                                member.ObservationLogReminders = reader.GetBoolean(1);
                                member.EventReminders = reader.GetBoolean(2);
                                member.ContentReminders = reader.GetBoolean(3);
                                member.AdvocacyAlerts = reader.GetBoolean(4);
                                member.PrivateMessageAlerts = reader.GetBoolean(5);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return member;
        }

        /// <summary>
        /// This will be depreciated after we update the edmx but until then we are going to have a way to update all of the values that have been added on in Membership 1.2
        /// </summary>
        /// <param name="member">The Website Member that we want to update the databse with.</param>
        /// <returns></returns>
        public bool UpdateMember_ExtendedProperties(Member member)
        {
            bool success = false;
            try
            {

                string sql = "UPDATE  dbo.Members " +
                        " SET PreferedLanguage = @PreferedLanguage, " +
                        " AgreedToSignUpTerms = @AgreedToSignUpTerms, " +
                        " MobilePhoneNumber = @MobilePhoneNumber,  " +
                        " Subscribed_DailyDigest = @Subscribed_DailyDigest,  " +
                        " Subscribed_WeeklyDigest = @Subscribed_WeeklyDigest  " +
                        " WHERE (MemberId = @MemberId)";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@PreferedLanguage", member.PreferredLanguage.ToString());
                        cmd.Parameters.AddWithValue("@AgreedToSignUpTerms", member.AgreedToSignUpTerms);
                        cmd.Parameters.AddWithValue("@MobilePhoneNumber", member.MobilePhoneNumber != null ? member.MobilePhoneNumber : "");
                        cmd.Parameters.AddWithValue("@Subscribed_DailyDigest", member.Subscribed_DailyDigest);
                        cmd.Parameters.AddWithValue("@Subscribed_WeeklyDigest", member.Subscribed_WeeklyDigest);
                        cmd.Parameters.AddWithValue("@MemberId", member.MemberId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //bg: I would like to log this, need to find that log method again.
                throw ex;
            }

            success = true;


            //push this up into salesforce... eventually....
            return success;
        }
    }
}
