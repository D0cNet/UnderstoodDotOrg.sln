using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using System.Net.Sockets;
using UnderstoodDotOrg.Domain.Membership;
using System.Diagnostics;

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

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            InitSearchParams();
            InitSearchTargets();

            stopWatch.Stop();

            context.Response.Write(String.Format("Elapsed time: {0} seconds", stopWatch.Elapsed.Seconds));
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
                _searchDate = DateTime.Now;
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