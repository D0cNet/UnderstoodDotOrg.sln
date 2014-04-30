using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using System.Net.Sockets;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for RunPersonalizationService
    /// </summary>
    public class RunPersonalizationService : IHttpHandler
    {
        private Guid? _childId;
        private Guid? _memberId;
        private DateTime _searchDate;
        private MembershipManager _membershipManager = new MembershipManager();

        public void ProcessRequest(HttpContext context)
        {
            if (!HasAccessPrivileges(context))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(String.Format("Access denied - {0}", HttpHelper.GetIpAddress()));
                return;
            }

            context.Response.ContentType = "text/html";
            
            InitSearchParams();
            InitSearchTargets();

            context.Response.Write("Running personalization!!!!");
            context.Response.Write("<br>is this request coming from a local machine: " + context.Request.IsLocal.ToString()); 
        }

        private void InitSearchTargets()
        {
            // No child specified
            if (!_childId.HasValue)
            {
                if (!_memberId.HasValue)
                {
                    UpdateMembers();
                }
                else
                {
                    UpdateMember(_memberId.Value);
                }
            }
            else
            {
                if (!_memberId.HasValue)
                {
                    UpdateChild(_childId.Value);
                }
                else
                {
                    UpdateChild(_memberId.Value, _childId.Value);
                }
            }
        }

        private void InitSearchParams()
        {
            // Default date to current if a valid date isn't provided
            if (!DateTime.TryParse(HttpHelper.GetQueryString(Constants.HANDLER_TIMELY_DATE_QUERY_STRING), out _searchDate))
            {
                _searchDate = DateTime.UtcNow;
            }

            Guid childId, memberId;

            if (Guid.TryParse(HttpHelper.GetQueryString(Constants.HANDLER_CHILD_QUERY_STRING), out childId))
            {
                _childId = childId;
            }

            if (Guid.TryParse(HttpHelper.GetQueryString(Constants.HANDLER_MEMBER_QUERY_STRING), out memberId))
            {
                _memberId = memberId;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void UpdateMembers()
        {
            // TODO: Grab all members active within past week using membership provider
            List<Member> members = new List<Member>();
            
            // TODO: loop through active members and call UpdateMember
            foreach (Member m in members)
            {
                UpdateMember(m);
            }
        }

        private void UpdateMember(Guid memberId)
        {
            Member member = null;
            try
            {
                member = _membershipManager.GetMember(memberId);
            }
            catch { }

            if (member == null)
            {
                return;
            }

            UpdateMember(member);
        }

        private void UpdateMember(Member member)
        {
            // TODO: Temp data
            member = new Member()
            {
                FirstName = "Testing",
                LastName = "User",
                ScreenName = "JustTesting",
                ZipCode = "12345",
                //Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"),
                //HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
                //PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),
                //hasOtherChildren = false,
                //allowConnections = false,
                //allowNewsletter = false,
                //isPrivate = false,
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
                        //Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
                        EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                        Issues = new List<Issue>() { 
                            new Issue() {
                                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                        //        Value = "Attention or Staying Focused"
                            }  
                        },
                        Diagnoses = new List<Diagnosis>() { 
                            new Diagnosis() {
                                Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                        //        Value = "ADHD"
                            }
                        },                
                    }
                },
            };

            foreach (var child in member.Children)
            {
                UpdateChild(member, child);
            }     
        }

        private void UpdateChild(Member member, Child child)
        {
            List<UnderstoodDotOrg.Domain.Search.Article> articles = Domain.Search.SearchHelper.GetArticles(member, child, _searchDate);

            // TODO: Save results to membership table
        }

        private void UpdateChild(Guid childId)
        {
            Child child = null;
            try
            {
                child = _membershipManager.GetChild(childId);
            }
            catch { }

            if (child.Members.Any())
            {
                foreach (Member m in child.Members)
                {
                    UpdateChild(m, child);
                }
            }
        }

        private void UpdateChild(Guid memberId, Guid childId)
        {
            Member member = null;
            Child child = null;

            try
            {
                member = _membershipManager.GetMember(memberId);
                child = _membershipManager.GetChild(childId);
            }
            catch { }
            
            if (member != null && child != null && child.Members.Contains(member))
            {
                UpdateChild(member, child);
            }
        }

        /// <summary>
        /// Restricts service to local server or allowed ips
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Boolean if a this service is allowed to run</returns>
        private bool HasAccessPrivileges(HttpContext context)
        {
            return context.Request.IsLocal || HasAllowedIp();
        }

        /// <summary>
        /// Checks SitecoreSettings config for IP
        /// </summary>
        /// <returns>Boolean whether IP exists in config</returns>
        private bool HasAllowedIp()
        {
            string address = HttpHelper.GetIpAddress();
            if (!String.IsNullOrEmpty(address))
            {
                List<string> allowedIps = Sitecore.Configuration.Settings.GetSetting(Constants.Settings.PersonalizationHandlerAllowedIps).Split(',').ToList<string>();

                return allowedIps.Contains(address);
            }

            return false;
        }
    }
}