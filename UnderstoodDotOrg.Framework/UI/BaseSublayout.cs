using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web.Security;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using System;

namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseSublayout : System.Web.UI.UserControl
    {

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

        private bool? _isUserLoggedIn;
        public bool IsUserLoggedIn
        {
            get
            {
                return (_isUserLoggedIn = _isUserLoggedIn ?? CurrentMember != null && CurrentUser != null).Value;
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
			Response.Redirect(Request.RawUrl);
		}

        public BaseSublayout() : base() { }

    }
}