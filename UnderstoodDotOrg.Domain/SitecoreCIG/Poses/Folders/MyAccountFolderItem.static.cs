using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Links;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class MyAccountFolderItem
    {
        private static MyAccountFolderItem MyAccountFolder 
        { 
            get 
            {
                return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath).GetChildren().FirstOrDefault(x => x.TemplateID.ToString() == MyAccountFolderItem.TemplateId);
            } 
        }

        public static MyProfileStepOneItem GetMyProfileStepOnePage()
        {
            if (MyAccountFolder != null)
            {
                return MyAccountFolder.InnerItem.Children
                    .FirstOrDefault(i => i.IsOfType(MyProfileStepOneItem.TemplateId));
            }
            return null;
        }

        public static string GetSignUpPage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }
            
            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == SignUpPageItem.TemplateId));
        }

        public static string GetSignInPage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }

            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == SignInPageItem.TemplateId));
        }

        public static string GetForgotPasswordPage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }

            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == ForgotPasswordItem.TemplateId));
        }

        public static string GetResetPasswordPage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }

            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == ResetYourPasswordItem.TemplateId));
        }

        public static string GetMyAccountPage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }

            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == MyAccountItem.TemplateId));
        }

        public static string GetMyProfilePage()
        {
            if (MyAccountFolder == null)
            {
                return string.Empty;
            }

            return LinkManager.GetItemUrl(MyAccountFolder.InnerItem.Children.FirstOrDefault(x => x.TemplateID.ToString() == MyProfileItem.TemplateId));
        }
    }
}