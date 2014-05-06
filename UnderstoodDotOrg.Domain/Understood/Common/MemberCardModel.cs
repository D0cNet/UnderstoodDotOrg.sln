using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class MemberCardModel
    {
        public  MemberCardModel()
        {
            this.AvatarUrl = Constants.Settings.AnonymousAvatar;
            this.Children = new List<ChildCardModel>();
            this.UserLabel = String.Empty; //TODO: find role                                                                                   
            this.UserLocation = Constants.Settings.DefaultLocation; //TODO: find location translate from zipcode
            this.UserName = String.Empty;
        }

        public  MemberCardModel(Member m)
        {
            
                                                
            this.AvatarUrl = Constants.Settings.AnonymousAvatar;
            this.Children = m.Children.ConvertToChildCardModelList();
            this.UserLabel = "Blogger"; //TODO: find role                                                                                   
            this.UserLocation = Constants.Settings.DefaultLocation; //TODO: find location translate from zipcode
            this.UserName = m.ScreenName;
            
                                                 
        }
        
        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public string UserLocation { get; set; }
        public string UserLabel { get; set; }
        public List<ChildCardModel> Children { get; set; }
        public List<Constants.TelligentRole> Roles { get; set; }
    }
}
