using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "jtesting@test.com";
            string password = "Jtest1!";

            var parent = new Member()
            {
                FirstName = "Testing",
                LastName = "User",
                ScreenName = "JustTesting",
                ZipCode = "12345",
                Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"),
                HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
                PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),
                hasOtherChildren = false,
                allowConnections = false,
                allowNewsletter = false,
                isPrivate = false,
                Interests = new List<Interest>() {
                    new Interest() {
                        Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
                        CategoryName = "Technologies and Apps",
                        Value = "Apps",
                    }
                },
                Children = new List<Child>() { 
                    new Child() {
                        Nickname = "Bobby",
                        IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
                        EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                        Issues = new List<Issue>() { 
                            new Issue() {
                                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                                Value = "Attention or Staying Focused"
                            }  
                        },
                        Diagnoses = new List<Diagnosis>() { 
                            new Diagnosis() {
                                Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                                Value = "ADHD"
                            }
                        },                
                    }
                },
            };

            var membershipManager = new MembershipManager();
            parent = membershipManager.AddMember(parent, username, password);

            Response.Write("Member ID: " + parent.MemberId.ToString() + "</br>User ID: " + parent.UserId.ToString());
        }
    }
}