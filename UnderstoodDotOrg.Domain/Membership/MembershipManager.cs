using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MembershipProvider = System.Web.Security.Membership;

namespace UnderstoodDotOrg.Domain.Membership
{
    public class MembershipManager : IMembershipManager, IDisposable
    {
        Membership _db;

        public MembershipManager()
            : this(new Membership(connString))
        { }

        public MembershipManager(Membership db)
        {
            _db = db;
        }

        /// <summary>
        /// Entity-specific connection string
        /// </summary>
        private static string connString = @"metadata=res://*/Membership.MembershipModel.csdl|res://*/Membership.MembershipModel.ssdl|res://*/Membership.MembershipModel.msl;provider=System.Data.SqlClient;provider connection string='data source=162.209.22.3;initial catalog=Understood.org.DEV.membership;persist security info=True;user id=understood_org;password=dahyeSDf;MultipleActiveResultSets=True;App=EntityFramework'";

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
                member = this.GetMember(membershipUser.ProviderUserKey.ToString());
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

        private Member mapMember(Member Member)
        {
            var tMember = _db.Members.Where(x => x.MemberId == Member.MemberId).FirstOrDefault();

            if (tMember == null)
            {
                tMember = new Member();
                tMember.MemberId = Member.MemberId;
            }

            tMember.allowConnections = Member.allowConnections;
            tMember.allowNewsletter = Member.allowNewsletter;
            tMember.emailSubscription = Member.emailSubscription;
            tMember.FirstName = Member.FirstName;
            tMember.hasOtherChildren = Member.hasOtherChildren;
            tMember.isFacebookUser = Member.isFacebookUser;
            tMember.isPrivate = Member.isPrivate;
            tMember.LastName = Member.LastName;
            tMember.PersonalityType = Member.PersonalityType;
            tMember.Phone = Member.Phone;
            tMember.Role = Member.Role;
            tMember.ScreenName = Member.ScreenName;
            tMember.UserId = Member.UserId;
            tMember.ZipCode = Member.ZipCode;

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

        private Child mapChild(Child child)
        {
            var tChild = _db.Children.Where(x => x.ChildId == child.ChildId).FirstOrDefault();

            if (tChild == null)
            {
                tChild = new Child();
                tChild.ChildId = child.ChildId;
            }

            tChild.EvaluationStatus = child.EvaluationStatus;
            tChild.Gender = child.Gender;
            tChild.HomeLife = child.HomeLife;
            tChild.IEPStatus = child.IEPStatus;
            tChild.Nickname = child.Nickname;
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

                return tMember;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private Journey GetJourney(Guid JourneyId)
        //{
        //    try
        //    {
        //        using (_db)
        //        {
        //            return _db.Journeys
        //                .Where(x => x.Key == JourneyId)
        //                //.AsNoTracking()
        //                .First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private Diagnosis GetDiagnosis(Guid DiagnosisId)
        //{
        //    try
        //    {
        //        using (_db)
        //        {
        //            return _db.Diagnoses
        //                .Where(x => x.Key == DiagnosisId)
        //                //.AsNoTracking()
        //                .First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private Grade GetGrade(Guid GradeId)
        //{
        //    try
        //    {
        //        using (_db)
        //        {
        //            return _db.Grades
        //                .Where(x => x.Key == GradeId)
        //                //.AsNoTracking()
        //                .First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private Issue GetIssue(Guid IssueId)
        //{
        //    try
        //    {
        //        using (_db)
        //        {
        //            return _db.Issues
        //                .Where(x => x.Key == IssueId)
        //                //.AsNoTracking()
        //                .First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private Interest GetInterest(Guid InterestId)
        //{
        //    try
        //    {
        //        using (_db)
        //        {
        //            return _db.Interests
        //                .Where(x => x.Key == InterestId)
        //                //.AsNoTracking()
        //                .First();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Adds a new user to the authentication database, and then adds a new member to the membership database
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

                var isExistingUser = provider.ValidateUser(Username, Password);

                if (isExistingUser)
                {
                    Member.MemberId = Guid.Parse(provider.GetUser(Username, true).ProviderUserKey.ToString());

                    return this.UpdateMember(Member);
                }
                else
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

                    return this.AddMember(Member);
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
                var tChild = mapChild(Child);
                tChild.Members.Add(_db.Members.Where(x => x.MemberId == MemberId).First());

                _db.Children.Add(Child);
                _db.SaveChanges();

                return tChild;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates information about an existing member
        /// </summary>
        /// <param name="Member">Member to update</param>
        /// <returns>Member that was updated</returns>
        public Member UpdateMember(Member Member)
        {
            try
            {
                Member = this.mapMember(Member);

                _db.SaveChanges();

                return Member;
            }
            catch (Exception ex)
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns custom Member object
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
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

            return member;
            //}
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
        /// Returns Member by Member Guid
        /// </summary>
        /// <param name="MemberId">Guid of member to return</param>
        /// <returns>Member that was requested</returns>
        public Member GetMember(string MemberId)
        {
            return this.GetMember(Guid.Parse(MemberId));
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

            return child;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
     
        public List<Member> GetMembers()
        {
            List<Member> members = null; 
            using (var db = new Membership(connString))
            {
                var query = from m in db.Members
                            select m;
                members = query.ToList<Member>();             
            }
            return members;
        }
    }
}
