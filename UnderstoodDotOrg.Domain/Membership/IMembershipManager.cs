using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace UnderstoodDotOrg.Domain.Membership
{
    interface IMembershipManager
    {
        //authenticate
        Member AuthenticateUser(string Username, string Password);

        Member AddMember(Member Member);

        Member AddMember(Member Member, string Username, string Password);

        Child AddChild(Child Child, Guid MemberId);

        //?add interest
        //?add issue
        //?add diagnosis
        //future: add member to child

        Member UpdateMember(Member Member);

        Child UpdateChild(Child Child);

        Member GetMember(Guid MemberId);

        Member GetMember(string MemberId);

        Child GetChild(Guid ChildId);
    }
}
