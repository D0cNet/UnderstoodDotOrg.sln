using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;
using MembershipProvider = System.Web.Security.Membership;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void teardown(string Username, string Password)
        {
            var provider = MembershipProvider.Providers[UnderstoodDotOrg.Common.Constants.MembershipProviderName];

            var isExistingUser = provider.ValidateUser(Username, Password);

            if (isExistingUser)
            {
                provider.DeleteUser(Username, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "jtesting@test.com";
            string password = "Jtest1!";

            teardown(username, password);

            var parent = new Member()
            {
                FirstName = "Testing",
                LastName = "User",
                ScreenName = "JustTesting",
                ZipCode = "12345",
                Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"),
                PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),
                hasOtherChildren = false,
                allowConnections = false,
                allowNewsletter = false,
                isPrivate = false,
                //Interests = new List<Interest>() {
                //    new Interest() {
                //        Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
                //    }
                //},
                //Journeys = new List<Journey>() {
                //    new Journey() {
                //        Key = Guid.Parse("{CB9F1AC5-4E58-499C-8D07-8BC4E8D42F0F}"),
                //    }
                //},
                //Children = new List<Child>() { 
                //    new Child() {
                //        Nickname = "Bobby",
                //        IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                //        Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                //        EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                //        HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
                //        Gender = "boy",
                //        Issues = new List<Issue>() { 
                //            new Issue() {
                //                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                //            }  
                //        },
                //        Diagnoses = new List<Diagnosis>() { 
                //            new Diagnosis() {
                //                Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                //            }
                //        },           
                //        Grades = new List<Grade>() {
                //            new Grade() {
                //                Key = Constants.GradesByValue["3"],
                //            }
                //        },
                //    },
                //    new Child() {
                //        Nickname = "Sally",
                //        IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                //        Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                //        EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                //        HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
                //        Gender = "girl",
                //        Issues = new List<Issue>() { 
                //            new Issue() {
                //                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                //            }  
                //        },
                //        Diagnoses = new List<Diagnosis>() { 
                //            new Diagnosis() {
                //                Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                //            }
                //        },           
                //        Grades = new List<Grade>() {
                //            new Grade() {
                //                Key = Constants.GradesByValue["5"],
                //            }
                //        },
                //    },
                //},
            };

            var membershipManager = new MembershipManager();

            parent = membershipManager.AddMember(parent, username, password);

            Response.Write(parent.FirstName + "<br />");

            //var p = membershipManager.GetMember("{B226F173-9B4C-43C9-B09B-933A288FE5E6}");
            var p = membershipManager.GetMember(parent.MemberId);

            //Response.Write(p.MemberId.ToString() + "<br/>" + p.Children.Count.ToString() + "<br/>");

            p.FirstName += " - edited";

            p.Interests = new List<Interest>() {
                new Interest() {
                    Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
                }
            };

            var t = membershipManager.UpdateMember(p);

            Response.Write(t.FirstName + "<br />");
        }
    }
}