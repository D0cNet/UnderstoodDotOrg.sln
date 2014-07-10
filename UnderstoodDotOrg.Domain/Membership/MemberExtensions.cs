using Sitecore.Data.Items;
using Sitecore.Links;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Domain.Membership
{
    public static class MemberExtensions
    {
        public static string GetMemberPublicProfile(this Member Member)
        {
            return MembershipHelper.GetPublicProfileUrl(Member);
        }

        public static string GetCommuityRegistrationProfile(this Member member)
        {
            return LinkManager.GetItemUrl( Sitecore.Context.Database.GetItem(Constants.Pages.CommunityRegistrationPage));
        }
    }
}
