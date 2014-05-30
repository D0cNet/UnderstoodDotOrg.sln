using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseRegistration : BaseSublayout
    {
        public BaseRegistration()
        {
            this.Load += new EventHandler(this.Page_Load);
        }

        private string sessionKey = "understood_org_registering_user";

        public static string YesButton { get { return DictionaryConstants.YesButtonText; } }
        public static string NoButton { get { return DictionaryConstants.NoButtonText; } }
        public static string GirlButton { get { return DictionaryConstants.GirlButtonText; } }
        public static string BoyButton { get { return DictionaryConstants.BoyButtonText; } }
        public static string NextButtonText { get { return DictionaryConstants.NextButtonText; } }
        public static string InProgressText { get { return DictionaryConstants.InProgressButtonText; } }

        public string AccessToken
        {
            get
            {
                if (Session[Constants.currentUserFacebookAccessToken] != null)
                {
                    return Session[Constants.currentUserFacebookAccessToken].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Member registeringUser
        {
            get { return (Member)(Session[sessionKey]); }
            set { Session[sessionKey] = value; }
        }
        public void FlushRegisteringUser()
        {
            Session[sessionKey] = null;
        }


        public void Page_Load(object sender, EventArgs e)
        {
            string facebookId = "var fbAppId = '{0}';";
            string appId = ConfigurationManager.AppSettings[Constants.Settings.FacebookAppId];

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "fbAppId", string.Format(facebookId, appId), true);
        }
    }

}
