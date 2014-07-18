using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using System.Web.Security;


namespace UnderstoodDotOrg.Domain.Understood.Common
{
    [Serializable]
    public class MemberCardModel 
    {
        public  MemberCardModel()
        {
            this.AvatarUrl = Constants.Settings.AnonymousAvatar; ///TODO: find Avatar URL
            this.Children = new List<ChildCardModel>();
            this.UserLabel = String.Empty; //TODO: find role                                                                                   
            this.UserLocation = Constants.Settings.DefaultLocation; //TODO: find location translate from zipcode
            this.UserName = String.Empty;
        }

        public MemberCardModel(Member m, Func<string, List<UserBadgeModel>> badgesPop = null)
        {
            if (m != null)
            {
                if (!String.IsNullOrEmpty(m.ScreenName))
                {
                    
                    this.AvatarUrl = Constants.Settings.AnonymousAvatar; ///TODO: find Avatar URL
                    this.Children = m.Children.ConvertToChildCardModelList();
                    this.UserLabel = "Blogger"; //TODO: find role                                                                                   
                    this.UserLocation = Constants.Settings.DefaultLocation; //TODO: find location translate from zipcode
                    this.UserName = m.ScreenName;
                    this.Contactable = m.allowConnections;
                    this.ProfileLink = m.GetMemberPublicProfile();
                    if (badgesPop != null)
                        Badges = badgesPop(m.ScreenName);
                }
            }                                 
        }

        public MemberCardModel(string username,Func<string,List<UserBadgeModel>> badgesPop=null)
        {
            MembershipManager memMan = new MembershipManager();

            Member mUser = memMan.GetMemberByScreenName(username);
            if (mUser != null)
            {
               
                    this.AvatarUrl = Constants.Settings.AnonymousAvatar; ///TODO: find Avatar URL
                    this.Children = mUser.Children.ConvertToChildCardModelList();
                    this.UserLabel = "Blogger"; //TODO: find role                                                                                   
                    this.UserLocation = Constants.Settings.DefaultLocation; //TODO: find location translate from zipcode
                    this.UserName = mUser.ScreenName;
                    this.Contactable = mUser.allowConnections;
                    this.ProfileLink = mUser.GetMemberPublicProfile();
                    if (badgesPop != null)
                        Badges = badgesPop(username);
                
            }
            
        }
        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public string UserLocation { get; set; }
        public string UserLabel { get; set; }
        public List<ChildCardModel> Children { get; set; }
        public List<int> Roles { get; set; }
        public List<UserBadgeModel> Badges{get;set;}

        public bool Contactable { get; set; }

        public string ProfileLink { get; set; }
    }
}
