using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MembershipProvider = System.Web.Security.Membership;

namespace UnderstoodDotOrg.Domain.Membership
{
    class MembershipManager : IMembershipManager
    {
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
                using (var db = new Membership())
                {
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

        public Child AddChild(Child Child, Guid MemberId)
        {
            try
            {
                using (var db = new Membership())
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
                using (var db = new Membership())
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
                using (var db = new Membership())
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

            using (var db = new Membership())
            {
                var query = from m in db.Members
                            where m.MemberId == MemberId
                            select m;

                member = query.First();
            }

            return member;
        }

        public Member GetMember(string MemberId)
        {
            return this.GetMember(Guid.Parse(MemberId));
        }
    }
}
