using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Services;
using UnderstoodDotOrg.Services.AccessControlServices;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for ContentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ContentService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession=true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public HelpfulContentResult FoundCommentHelpful(string contentId, string contentTypeId)
        {
            var result = new HelpfulContentResult
            {
                IsSuccessful = false,
                IsLoggedIn = IsLoggedIn()
            };

            if (result.IsLoggedIn)
            {
                var member = (Member)Session[Constants.currentMemberKey];
                result.IsSuccessful = TelligentService.LikeComment(member.ScreenName, contentId, contentTypeId);
                result.HelpfulCount = TelligentService.GetTotalLikes(contentId);
            }

            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ContentServiceResult FlagComment(string contentId)
        {
            var result = new ContentServiceResult
            {
                IsSuccessful = false,
                IsLoggedIn = IsLoggedIn()
            };

            if (result.IsLoggedIn)
            {
                result.IsSuccessful = TelligentService.FlagComment(contentId);
                if (result.IsSuccessful)
                {
                    result.Message = DictionaryConstants.UnderReviewLabel;
                }
            }

            return result;
        }

        private bool IsLoggedIn()
        {
            if (Session[Constants.currentUserKey] != null
                && Session[Constants.currentMemberKey] != null)
            {
                try
                {
                    var user = (MembershipUser)Session[Constants.currentUserKey];
                    var member = (Member)Session[Constants.currentMemberKey];

                    return true;
                }
                catch { }
            }

            return false;
        }
    }
}
