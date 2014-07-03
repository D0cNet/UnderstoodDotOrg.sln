using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web.Security;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using Sitecore.Data;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseSublayout : System.Web.UI.UserControl
    {
        private List<INotification> _notifications;
        public List<INotification> Notifications
        {
            get
            {
                return _notifications = _notifications ?? Session["_notifications"] as List<INotification>;
            }

            set
            {
                Session["_notifications"] = _notifications = value;
            }
        }

        private Item _dataSource = null;
        public Item DataSource
        {
            get
            {
                if (_dataSource == null)
                {
                    if (Parent is Sublayout)
                    {
                        _dataSource = Sitecore.Context.Database.GetItem(((Sublayout)Parent).DataSource);
                    }
                }

                // if we're still null, fall back to the context item
                if (_dataSource == null)
                {
                    _dataSource = Sitecore.Context.Item;
                }

                return _dataSource;
            }
            set
            {
                _dataSource = value;
            }
        }

        private string _parameters = null;
        public string Parameters
        {
            get
            {
                if (_parameters == null)
                    if (Parent is Sublayout)
                        _parameters = ((Sublayout)Parent).Parameters;
                return _parameters;
            }
        }

        private string _additionalCssClass;
        public string AdditionalCssClass
        {
            get
            {
                return (_additionalCssClass = _additionalCssClass ?? GetParameter("AdditionalCSSClass"));
            }
        }

        public string GetParameter(string key)
        {
            string rawParameters = this.Parameters;
            NameValueCollection parameters = Sitecore.Web.WebUtil.ParseUrlParameters(rawParameters);
            return (parameters[key] != null) ? System.Web.HttpUtility.UrlDecode(parameters[key]) : String.Empty;
        }

        private MembershipUser _currentUser;
        public MembershipUser CurrentUser
        {
            get
            {
                return (_currentUser = _currentUser ?? (MembershipUser)Session[Constants.currentUserKey]);
            }
            set
            {
                Session[Constants.currentUserKey] =
                    _currentUser = value;
            }
        }

        private Member _currentMember;
        public Member CurrentMember
        {
            get
            {
                return (_currentMember = _currentMember ?? (Member)Session[Constants.currentMemberKey]);
            }
            set
            {
                Session[Constants.currentMemberKey] =
                    _currentMember = value;
            }
        }

        public bool IsUserLoggedIn
        {
            get
            {
                return CurrentMember != null && CurrentUser != null;
            }
        }
        private Member _unauthenticatedSessionMember;
        /// <summary>
        /// Use this as a container for temporary session based members who are not in our database
        /// </summary>
        public Member UnauthenticatedSessionMember
        {
            get
            {
                return (_unauthenticatedSessionMember = _unauthenticatedSessionMember ?? (Member)Session[Constants.sessionUnauthenticatedMemberKey]);
            }
            set
            {
                Session[Constants.sessionUnauthenticatedMemberKey] =
                    _unauthenticatedSessionMember = value;
            }
        }

        public void FlushCurrentMemberUser()
        {
            CurrentMember = null;
            CurrentUser = null;
        }

        protected void Logout()
        {
            FlushCurrentMemberUser();

            // CH: don't want to put this in FlushCurrentMemberUser, because it's called a few times during signup
            Session[Constants.currentUserFacebookAccessToken] = null;
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }

        protected void Logout(string url)
        {
            FlushCurrentMemberUser();

            // CH: don't want to put this in FlushCurrentMemberUser, because it's called a few times during signup
            Session[Constants.currentUserFacebookAccessToken] = null;

            Response.Redirect(url);
        }

        public BaseSublayout()
            : base()
        {
            this.Init += BaseSublayout_Init;
        }

        void BaseSublayout_Init(object sender, EventArgs e)
        {
            var contextItem = Sitecore.Context.Item;

            if (contextItem == null)
            {
                return;
            }

            if (!contextItem.IsOfType(TermsandConditionsItem.TemplateId)
                && CurrentMember != null
                && !CurrentMember.AgreedToSignUpTerms)
            {
                // TODO: refactor to do direct page lookup
                var home = MainsectionItem.GetHomePageItem();
                if (home != null)
                {
                    var myAccount = home.GetMyAccountFolder();
                    if (myAccount != null)
                    {
                        var terms = myAccount.GetTermsandConditionsPage();
                        Session[Constants.SessionPreviousUrl] = Request.RawUrl;
                        Response.Redirect(terms.GetUrl());
                    }
                }

            }
        }

        protected string getItemName(Guid guid)
        {
            Item item = Sitecore.Context.Database.GetItem(new ID(guid));

            if (item != null)
            {
                return item.Name;
            }

            return "";
        }

        /// <summary>
        /// Set or overwrite cookie values, creates cookie that will expire in 10 years
        /// </summary>
        /// <param name="cookieName">Cookie to create / overwrite</param>
        /// <param name="value">Value for cookie</param>
        public void setCookie(string cookieName, string value)
        {
            Request.Cookies.Remove(cookieName);
            Request.Cookies.Set(new System.Web.HttpCookie(cookieName, value) { Expires = DateTime.Now.AddYears(10) });
        }

        /// <summary>
        /// Return value from desired cookie
        /// </summary>
        /// <param name="cookieName">Cookie to read</param>
        /// <returns>Value stored in cookie or string.Empty</returns>
        public string getCookie(string cookieName)
        {
            var cookie = Request.Cookies[cookieName];

            if (cookie != null)
            {
                var cookieValue = cookie.Value;

                if (!string.IsNullOrEmpty(cookieValue))
                {
                    return cookieValue;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns true for international users or false for US users
        /// </summary>
        public bool isInternationalUser
        {
            get
            {
                var internationalCookie = this.getCookie(Constants.Cookies.IsInternationalUser);

                bool isInternational = false;

                if (!string.IsNullOrEmpty(internationalCookie))
                {
                    isInternational = bool.Parse(internationalCookie);
                }
                else
                {
                    //check IP
                    var country = UnderstoodDotOrg.Services.LocationServices.GeoIPLookup.GetCountry(this.GetIPAddress());

                    //set cookie with bool.true or bool.false
                    if (country == "US")
                    {
                        this.setCookie(Constants.Cookies.IsInternationalUser, bool.FalseString);
                    }
                    else
                    {
                        this.setCookie(Constants.Cookies.IsInternationalUser, bool.TrueString);
                    }
                }

                return isInternational;
            }
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}