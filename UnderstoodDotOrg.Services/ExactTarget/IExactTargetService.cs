using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.ExactTarget;

namespace UnderstoodDotOrg.Services.ExactTarget
{
    public interface IExactTargetService
    {

        /// <summary>
        /// This service is used to validate and reformat US addresses.
        /// </summary>
        /// <param name="address">Address object to validate.</param>
        /// <returns>
        ///     Validated, reformatted address, according to the USPS formatting.
        ///     Null if address could not be found or validated.
        /// </returns>
        //Address ValidateAddress(Address address);


        /// <summary>
        /// Use this method to send a test email with Exact Target
        /// </summary>
        void InvokeTriggeredSendEmail(TriggeredSendEmail triggeredSendEmail);
        
    }
}
