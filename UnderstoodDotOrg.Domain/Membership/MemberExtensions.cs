using Sitecore.Links;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.Membership
{
    public static class MemberExtensions
    {
        public static string GetMemberPublicProfile(string ScreenName)
        {
            return string.Format(MainsectionItem.GetHomePageItem()
                .GetMyAccountFolder()
                .GetPublicAccountFolder()
                .GetPublicAccountPage()
                .GetUrl() + "?{0}={1}", 
                Constants.ACCOUNT_EMAIL, ScreenName);
        }

        public static string GetMemberPublicProfile(this Member Member)
        {
            return GetMemberPublicProfile(Member.ScreenName);
        }

        public static string GetCommuityRegistrationProfile(this Member member)
        {
            return LinkManager.GetItemUrl( Sitecore.Context.Database.GetItem(Constants.Pages.CommunityRegistrationPage));
        }
    }
}
