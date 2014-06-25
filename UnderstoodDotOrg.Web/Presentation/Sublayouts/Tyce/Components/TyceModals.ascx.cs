using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TyceModals : BaseSublayout<TyceBasePageItem>
    {
        
        private TyceQuestionsPageItem _tyceQuestionsPage;
        private TycePlayerPageItem _tycePlayerPage;
        private TyceNextStepsPageItem _tyceNextStepsPage;
        private TyceOverviewPageItem _tyceOverviewPage;

        protected TyceQuestionsPageItem TyceQuestionsPage
        {
            get
            {
                return (_tyceQuestionsPage = _tyceQuestionsPage ?? Model.GetQuestionsPage());
            }
        }
        protected TycePlayerPageItem TycePlayerPage
        {
            get
            {
                return (_tycePlayerPage = _tycePlayerPage ?? Model.GetPlayerPage());
            }
        }
        protected TyceOverviewPageItem TyceOverviewPage
        {
            get
            {
                return (_tyceOverviewPage = _tyceOverviewPage ?? Model.GetOverviewPage());
            }
        }
        protected TyceNextStepsPageItem TyceNextStepsPage
        {
            get
            {
                return (_tyceNextStepsPage = _tyceNextStepsPage ?? Model.GetNextStepsPage());
            }
        }

        private string _tyceQuestionsPageUrl;
        private string _tycePlayerPageUrl;
        private string _tyceNextStepsPageUrl;
        private string _tyceOverviewPageUrl;

        protected string TyceQuestionsPageUrl
        {
            get
            {
                return (_tyceQuestionsPageUrl = _tyceQuestionsPageUrl ?? TyceQuestionsPage.GetUrl());
            }
        }
        protected string TycePlayerPageUrl
        {
            get
            {
                return (_tycePlayerPageUrl = _tycePlayerPageUrl ?? TycePlayerPage.GetUrl());
            }
        }
        protected string TyceOverviewPageUrl
        {
            get
            {
                return (_tyceOverviewPageUrl = _tyceOverviewPageUrl ?? TyceOverviewPage.GetUrl());
            }
        }
        protected string TyceNextStepsPageUrl
        {
            get
            {
                return (_tyceNextStepsPageUrl = _tyceNextStepsPageUrl ?? TyceNextStepsPage.GetUrl());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}