using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MembershipProvider = System.Web.Security.Membership;

namespace UnderstoodDotOrg.Domain.Membership
{
    public class MembershipManager : IMembershipManager
    {
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

        public Member AddMember(Member Member)
        {
            try
            {
                using (var db = new Membership(connString))
                {
                    //add last modified date
                    db.Members.Add(Member);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Member;
        }

        public Member AddMember(Member Member, string Username, string Password)
        {
            try
            {
                // use custom provider for authentication
                var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];
                
                var isExistingUser = provider.ValidateUser(Username, Password);

                Guid memberId;

                if (isExistingUser)
                {
                    memberId = Guid.Parse(provider.GetUser(Username, true).ProviderUserKey.ToString());
                }
                else
                {
                    memberId = Guid.NewGuid();
                    var status = new MembershipCreateStatus();

                    var user = provider.CreateUser(Username, Password, Username, null, null, true, memberId, out status);

                    if (status != MembershipCreateStatus.Success)
                    {
                        throw new Exception("Unable to create user. Reason: " + status);
                    }
                }

                Member.MemberId = memberId;

                return this.AddMember(Member);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Child AddChild(Child Child, Guid MemberId)
        {
            try
            {
                using (var db = new Membership(connString))
                {
                    Child.Members.Add(this.GetMember(MemberId));
                    db.Children.Add(Child);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Child;
        }

        public Member UpdateMember(Member Member)
        {
            try
            {
                using (var db = new Membership(connString))
                {
                    db.Entry(Member).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Member;
        }

        public Child UpdateChild(Child Child)
        {
            try
            {
                using (var db = new Membership(connString))
                {
                    db.Entry(Child).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Child;
        }

        public Member GetMember(Guid MemberId)
        {
            Member member = new Member();

            using (var db = new Membership(connString))
            {
                var query = from m in db.Members
                            where m.MemberId == MemberId
                            select m;

                member = query.First();
            }

            //TODO: throw exception if no user was found

            return member;
        }

        public Member GetMember(string MemberId)
        {
            return this.GetMember(Guid.Parse(MemberId));
        }

        public Child GetChild(Guid ChildId)
        {
            Child child = new Child();

            using (var db = new Membership(connString))
            {
                var query = from c in db.Children
                            where c.ChildId == ChildId
                            select c;

                child = query.First();
            }

            return child;
        }
    }
}
