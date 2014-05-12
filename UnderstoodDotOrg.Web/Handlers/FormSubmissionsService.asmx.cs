using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using UnderstoodDotOrg.Domain.Understood.Submissions;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for FormSubmissions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class FormSubmissionsService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public SubmissionResult SubmitSuggestion(string message)
        {
            message = message.Trim();

            // TODO: Submit to salesforce


            return new SubmissionResult
            {
                Message = String.Empty,
                IsValid = !String.IsNullOrEmpty(message)
            };
        }
    }
}
