using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages
{
    public partial class TyceBasePageItem
    {
        private bool? _isOverviewPage;
        public bool IsOverviewPage
        {
            get
            {
                return (_isOverviewPage = _isOverviewPage ?? InnerItem.IsOfType(TyceOverviewPageItem.TemplateId)).Value;
            }
        }
        private bool? _isQuestionsPage;
        public bool IsQuestionsPage
        {
            get
            {
                return (_isQuestionsPage = _isQuestionsPage ?? InnerItem.IsOfType(TyceQuestionsPageItem.TemplateId)).Value;
            }
        }
        private bool? _isPlayerPage;
        public bool IsPlayerPage
        {
            get
            {
                return (_isPlayerPage = _isPlayerPage ?? InnerItem.IsOfType(TycePlayerPageItem.TemplateId)).Value;
            }
        }
        private bool? _isNextStepsPage;
        public bool IsNextStepsPage
        {
            get
            {
                return (_isNextStepsPage = _isNextStepsPage ?? InnerItem.IsOfType(TyceNextStepsPageItem.TemplateId)).Value;
            }
        }

        public TyceOverviewPageItem GetOverviewPage()
        {
            return IsOverviewPage ? InnerItem : InnerItem.Parent;
        }

        public TyceQuestionsPageItem GetQuestionsPage()
        {
            return IsPlayerPage ?
                InnerItem :
                IsOverviewPage ?
                    InnerItem.Children.FirstOrDefault(i => i.IsOfType(TyceQuestionsPageItem.TemplateId)) :
                    InnerItem.Parent.Children.FirstOrDefault(i => i.IsOfType(TyceQuestionsPageItem.TemplateId));
        }

        public TycePlayerPageItem GetPlayerPage()
        {
            return IsPlayerPage ?
                InnerItem :
                IsOverviewPage ?
                    InnerItem.Children.FirstOrDefault(i => i.IsOfType(TycePlayerPageItem.TemplateId)) :
                    InnerItem.Parent.Children.FirstOrDefault(i => i.IsOfType(TycePlayerPageItem.TemplateId));
        }

        public TyceNextStepsPageItem GetNextStepsPage()
        {
            return IsPlayerPage ?
                InnerItem :
                IsOverviewPage ?
                    InnerItem.Children.FirstOrDefault(i => i.IsOfType(TyceNextStepsPageItem.TemplateId)) :
                    InnerItem.Parent.Children.FirstOrDefault(i => i.IsOfType(TyceNextStepsPageItem.TemplateId));
        }
    }
}