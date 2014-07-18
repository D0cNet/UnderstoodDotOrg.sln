namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
    using UnderstoodDotOrg.Framework.UI;

    public partial class My_Profile : BaseSublayout
    {
        private MyProfileItem _currentPage;
        private MyProfileItem CurrentPage
        {
            get
            {
                if (_currentPage == null)
                {
                    _currentPage = new MyProfileItem(Sitecore.Context.Item);
                }

                return _currentPage;
            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentMember == null && this.CurrentUser == null)
            {
                if (!string.IsNullOrEmpty(CurrentPage.SignInPage.Url))
                {
                    Response.Redirect(CurrentPage.SignInPage.Url);
                }
                else
                {
                    Response.Redirect("/");
                }
            }

            if (!IsPostBack)
            {
                //update member
                MembershipManager membershipManager = new MembershipManager();
                this.CurrentMember = membershipManager.GetMember(this.CurrentMember.MemberId);
                this.CurrentUser = membershipManager.GetUser(this.CurrentMember.MemberId, true);

                MyProfileItem context = (MyProfileItem)Sitecore.Context.Item;
                HyperLink myHL = (HyperLink)this.FindControl("uxAddChild");
                myHL.Text = context.AddChildText;

                SetLabels();
                SetRole();

                uxChildList.DataSource = this.CurrentMember.Children;
                uxChildList.DataBind();

                //disable new children if you already have 6 or more
                if (this.CurrentMember.Children.Count >= 6)
                {
                    uxAddChild.Visible = false;
                }

                SetInterests();

                uxEmailAddress.Text = this.CurrentUser.UserName;

                SetJourney();

                uxPassword.Text = replacePassword("digitalpulp!");

                string phoneNumber = string.Empty;

                if (!string.IsNullOrEmpty(this.CurrentMember.MobilePhoneNumber))
                {
                    phoneNumber = this.CurrentMember.MobilePhoneNumber.Replace("-", string.Empty).Trim();

                    //if (phoneNumber.Length == 10 && !phoneNumber.Contains("-"))
                    //{
                    phoneNumber = phoneNumber.Insert(3, "-");
                    phoneNumber = phoneNumber.Insert(7, "-");
                    //}
                }
                else
                {
                    //10 points to Gryffindor if you know where this phone number comes from
                    txtPhoneNumber.Attributes["placeholder"] = "212-555-2368";
                }

                uxPhoneNumber.Text = phoneNumber;
                txtPhoneNumber.Text = phoneNumber;

                uxPrivacyLevel.Text = this.CurrentMember.allowConnections ? DictionaryConstants.OpenToConnect : DictionaryConstants.NotOpenToConnect;

                uxScreenname.Text = this.CurrentMember.ScreenName;

                uxZipcode.Text = this.CurrentMember.ZipCode.Trim();

                uxAddChild.Text = string.Format(uxAddChild.Text, ((ChildCount)this.CurrentMember.Children.Count).ToString());
                uxAddChild.NavigateUrl = MyProfileStepTwoItem.GetCompleteMyProfileStepTwo().GetUrl() + "?" + Constants.QueryStrings.Registration.Mode + "=" + Constants.QueryStrings.Registration.ModeAdd;

                if (Session["PostReloadScript"] != null)
                {
                    string reloadScript = Session["PostReloadScript"].ToString();

                    if (reloadScript != "")
                    {
                        ltlJS.Text = string.Format("<script type=\"text/javascript\">{0}</script>", reloadScript);
                        Session["PostReloadScript"] = null;
                    }
                }

                //top of edit interests
                hypEditCommunityAboutMe.NavigateUrl = String.Format(MyProfileStepFourItem.GetCompleteMyProfileStepFour().GetUrl() + "?{0}={1}", Constants.QueryStrings.Registration.Mode, Constants.QueryStrings.Registration.ModeEdit);

                //jump to edit community
                hypEditCommunity.NavigateUrl = hypCompleteYourProfile.NavigateUrl = String.Format(MyProfileStepFourItem.GetCompleteMyProfileStepFour().GetUrl() + "?{0}={1}#community", Constants.QueryStrings.Registration.Mode, Constants.QueryStrings.Registration.ModeEdit);

                if (!string.IsNullOrEmpty(this.CurrentMember.ScreenName))
                {
                    hypViewAsVisitors.NavigateUrl = MembershipHelper.GetPublicProfileAsVisitorUrl(CurrentMember.ScreenName);
                    hypViewAsMembers.NavigateUrl = MembershipHelper.GetPublicProfileAsMemberUrl(CurrentMember.ScreenName);
                    hypViewAsFriends.NavigateUrl = MembershipHelper.GetPublicProfileUrl(CurrentMember.ScreenName);
                }
                else
                {
                    uxNoProfile.Visible = true;
                    uxPublicView.Visible = false;
                }
            }
        }

        private void SetInterests()
        {
            uxInterestList.DataSource = this.CurrentMember.Interests.Where(x => x.CategoryName != "Journey").ToList();
            uxInterestList.DataBind();

            IEnumerable<ParentInterestItem> parentInterests = GlobalsItem.GetParentInterests();

            IEnumerable<Guid> currentMemberInterestIDs = this.CurrentMember.Interests.Where(i => i.CategoryName != "Journey").Select(i => i.Key);

            foreach (ParentInterestItem pi in parentInterests)
            {
                Guid guid = pi.ID.Guid;

                ListItem li = new ListItem(pi.InterestName.Raw, pi.ID.Guid.ToString());

                if (currentMemberInterestIDs.Contains(guid))
                {
                    li.Selected = true;
                }
            }
        }

        private void SetJourney()
        {
            var journeyInterests = this.CurrentMember.Journeys;
            if (journeyInterests != null && journeyInterests.Count > 0)
            {
                uxJourney.Text = string.Join(", ", journeyInterests.Select(i => i.Value));
            }

            IEnumerable<ParentInterestItem> parentJournies = GlobalsItem.GetParentJournies();

            IEnumerable<Guid> currentMemberJourneyIDs = this.CurrentMember.Journeys.Select(i => i.Key);

            foreach (ParentInterestItem pi in parentJournies)
            {
                Guid guid = pi.ID.Guid;

                ListItem li = new ListItem(pi.InterestName.Raw, pi.ID.Guid.ToString());

                if (currentMemberJourneyIDs.Contains(guid))
                {
                    li.Selected = true;
                }
            }
        }

        private void SetRole()
        {
            string role = getItemName(this.CurrentMember.Role);

            uxRole.Text = role;

            IEnumerable<ParentRoleItem> parentRoles = GlobalsItem.GetParentRoles();

            foreach (ParentRoleItem pr in parentRoles)
            {
                Guid guid = pr.ID.Guid;

                ListItem li = new ListItem(pr.RoleName.Raw, guid.ToString());

                if (guid == this.CurrentMember.Role)
                {
                    li.Selected = true;
                }
            }
        }

        private void SetLabels()
        {
            ltlAboutMeLabel.Text = DictionaryConstants.AboutMeLabel;
            ltlCommunityLabel.Text = DictionaryConstants.CommunityLabel;
            ltlContactLabel.Text = DictionaryConstants.ContactLabel;
            ltlContactReminderText.Text = DictionaryConstants.ContactReminderText;
            ltlEmailAndPasswordLabel.Text = DictionaryConstants.EmailAndPasswordLabel;
            ltlEmailLabel.Text = DictionaryConstants.EmailLabel;
            ltlMobilePhoneLabel.Text = DictionaryConstants.MobilePhoneLabel;
            ltlMyChildrenLabel.Text = DictionaryConstants.MyChildrenLabel;
            ltlMyConnectionsLabel.Text = DictionaryConstants.MyConnectionsLabel;
            ltlMyInterestsLabel.Text = DictionaryConstants.MyInterestsLabel;
            ltlMyJourneyLabel.Text = DictionaryConstants.MyJourneyLabel;
            ltlMyLocationLabel.Text = DictionaryConstants.MyLocationLabel;
            ltlMyPublicViewLabel.Text = DictionaryConstants.MyPublicViewLabel;
            ltlMyRoleLabel.Text = DictionaryConstants.MyRoleLabel;
            ltlMyScreenNameLabel.Text = DictionaryConstants.MyScreenNameLabel;
            ltlNicknameReminderText.Text = DictionaryConstants.NicknameReminderText;
            ltlPasswordLabel.Text = DictionaryConstants.PasswordLabel;
            ltlPrivacyLabel.Text = DictionaryConstants.PrivacyLabel;
            ltlZipcodeReminderText.Text = DictionaryConstants.ZipcodeReminderText;
        }

        private string replacePassword(string password)
        {
            string ret = string.Empty;

            for (int i = 0; i < password.Length; i++)
            {
                ret += "·";
            }

            return ret;
        }

        enum ChildCount
        {
            First = 0,
            Second = 1,
            Third = 2,
            Fourth = 3,
            Fifth = 4,
            Sixth = 5
        }

        protected void uxChildList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            string[] g = { "boy", "girl" };

            var item = e.Item.DataItem as Child;
            var uxChildIssueList = e.Item.FindControl("uxChildIssueList") as ListView;
            var uxGrade = e.Item.FindControl("uxGrade") as Literal;
            var gender = e.Item.FindControl("uxGender") as Literal;
            var evaluatedStatus = e.Item.FindControl("uxEvaluationStatus") as Literal;

            if (item != null)
            {
                if (uxChildIssueList != null)
                {
                    uxChildIssueList.DataSource = item.Issues;
                    uxChildIssueList.DataBind();
                }

                if (uxGrade != null)
                {
                    //grade.Text = getItemName(item.Grade); //lookup
                    //grade.Text = item.Grades.FirstOrDefault()

                    var grade = item.Grades.FirstOrDefault();

                    if (grade != null)
                    {
                        uxGrade.Text = grade.Value;
                    }
                }

                if (gender != null)
                {
                    gender.Text = item.Gender;
                }

                if (evaluatedStatus != null)
                {
                    evaluatedStatus.Text = getItemName(item.EvaluationStatus); //lookup
                }
            }
        }

        private void ReloadPage()
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void lbSave_PhoneNumber_Click(object sender, EventArgs e)
        {
            this.CurrentMember.MobilePhoneNumber = txtPhoneNumber.Text.Replace("-", string.Empty);

            var membershipmManager = new MembershipManager();
            membershipmManager.UpdateMember(this.CurrentMember);

            Response.Redirect(Request.Url.ToString());
        }

        protected string getChildEditLink(ListViewDataItem Container)
        {
            string ret = MyProfileStepTwoItem.GetCompleteMyProfileStepTwo().GetUrl()
                + '?' + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.Mode + '=' + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.ModeEdit
                + "&" + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.ChildIndex + "=" + Container.DataItemIndex;

            return ret;
        }

        public string MapToSitecoreIssue(string GUID)
        {
            ChildIssueItem temp = Sitecore.Context.Database.GetItem(new Guid(GUID));
            if (temp != null)
                return temp.IssueName;

            return "";
        }

        public string MapToSitecoreInterest(string GUID)
        {
            ParentInterestItem temp = Sitecore.Context.Database.GetItem(new Guid(GUID));
            if (temp != null)
                return temp.InterestName;

            return "";
        }
    }
}