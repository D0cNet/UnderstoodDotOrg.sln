using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common
{
    public static class Constants
    {
        public const int PERSONALIZATION_ARTICLES_PER_USER = 40;

        #region Query Strings

        public static readonly string SCLANG_QUERY_STRING = "sc_lang";
        public static readonly string CHALLENGE_QUERY_STRING = "challenge";
        public static readonly string GRADE_QUERY_STRING = "grade";
        public static readonly string HANDLER_CHILD_QUERY_STRING = "childid";
        public static readonly string HANDLER_MEMBER_QUERY_STRING = "memberid";
        public static readonly string HANDLER_TIMELY_DATE_QUERY_STRING = "date";

        #endregion

        public static string CURRENT_INDEX_NAME
        {
            get
            {
                return string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name.ToLower());
            }
        }

        public static string MembershipProviderName
        {
            get
            {
                return "UnderstoodMembership";
            }
        }

        #region Container Guid

        public static Guid GradeContainer
        {
            get
            {
                return new Guid("{1106FF43-4C23-412E-A37D-E19C6A34CF8F}");
            }
        }

        public static Guid ChallengesContainer
        {
            get
            {
                return new Guid("{DAB8D18D-844D-489C-91CC-757F8783781E}");
            }
        }

        #endregion

        #region Page Guids

        public static class Pages
        {
            public static Guid BehaviorToolsResults
            {
                get
                {
                    return new Guid("{D4E382E1-34D1-47DB-8430-9EE4A1545B25}");
                }
            }
        }

        #endregion

        public static Dictionary<Guid, string> Issues
        {
            get
            {
                return new Dictionary<Guid, string> 
                { 
                    {Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"), "Attention or Staying Focused"},
                    {Guid.Parse("{777EA342-4313-45CC-BDB5-AE141FCFA016}"), "Executive Function"},
                    {Guid.Parse("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"), "Hyperactivity or Impulsivity"},
                    {Guid.Parse("{3390C210-0B22-48FD-A411-881F956EDC0C}"), "Listening"},
                    {Guid.Parse("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"), "Math"},
                    {Guid.Parse("{CB5320E9-5F0D-4204-B76C-DE630A8BBE51}"), "Motor Skill"},
                    {Guid.Parse("{2611BEA0-33E6-4732-9BD5-B56857C5EA26}"), "Reading"},
                    {Guid.Parse("{CE405288-18FA-4665-A94C-AE6A558795DF}"), "Social Skills"},
                    {Guid.Parse("{3B4DC3FC-517D-47B5-B151-198AB7B3C6D4}"), "Spoken Language"},
                    {Guid.Parse("{B904242D-E290-4A2E-86D9-372DC42AB692}"), "Writing"},
                };
            }
        }

        public static Dictionary<Guid, string> Diagnosis
        {
            get
            {
                return new Dictionary<Guid, string> 
                { 
                    {Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"), "ADHD"},
                    {Guid.Parse("{B6D3DF62-CBEC-4311-8544-38B6E890762A}"), "Auditory Processing Issue"},
                    {Guid.Parse("{CC002EC5-4328-4719-9A8D-9350E482A8FB}"), "Dyscalculia"},
                    {Guid.Parse("{DF62BA5C-234B-4A4F-813D-FE6F765E2A4A}"), "Dysgraphia"},
                    {Guid.Parse("{07544BF9-EFD2-4613-8E9D-304347993BA8}"), "Dyslexia"},
                    {Guid.Parse("{8E9E9A5A-D630-472F-9264-16039F28A12E}"), "Dyspraxia"},
                    {Guid.Parse("{D5C01CEF-3A6F-455A-ABDD-282C26086AC5}"), "Executive Functioning"},
                    {Guid.Parse("{B998E9E7-D05C-4279-B5D7-448F93089228}"), "Expressive Language Disorder"},
                    {Guid.Parse("{E55DEB0F-00D5-4F59-B86C-05655333FC72}"), "Nonverbal Learning"},
                    {Guid.Parse("{A66286A0-CD70-4FDD-9D13-9CF1C90EFC4A}"), "Receptive Language Disorder"},
                    {Guid.Parse("{256CBB20-A2DD-468E-82C6-EA7B7B82BCBA}"), "Sensory Processing"},
                    {Guid.Parse("{6A4BE256-C9D3-4F3A-9FC0-C2AD9F6304CE}"), "Social Pragmatic Language Disorder"},
                    {Guid.Parse("{493C315E-DDA0-47D6-9B8E-78125858F43A}"), "Visual Processing"},
                };
            }
        }

        public static class SolrFields
        {
            public const string ChildGrades = "_child_grades";
            public const string ChildIssues = "_child_issues";
            public const string ChildDiagnoses = "_child_diagnoses";
            public const string OverrideTypes = "_override_type";
            public const string TimelyStart = "date_start";
            public const string TimelyEnd = "date_end";
            public const string ParentInterests = "_applicable_interests";
            public const string Templates = "alltemplates";
            public const string ImportanceLevels = "_importance_level";
            public const string ApplicableEvaluations = "_other_applicable_evaluations";
            public const string DiagnosedConditions = "_diagnosed_condition";
        }

        public static class ArticleTags
        {
            public static string ExcludeFromPersonalization = "{6100E802-A5B9-431F-9F4F-58238DF23DC7}";
            public static string MustRead = "{C15701FE-ACA7-4423-B630-79329383BFB1}";
            public static string Evaluated504 = "{93BF5E6A-9884-42A2-ABB7-7457D1AC0037}";
            public static string EvaluatedIEP = "{5258F442-2E85-4D11-A513-63852B7AA48B}";
            public static string ConditionDiagnosed = "{19EC4E1A-9E55-4FC1-942D-2BCBF99F0083}";
            public static string ConditionUndiagnosed = "{C9D1AD3D-C704-41D1-8817-BA1867030F45}";
            public static string AllChildDiagnosis = "{3FB0E002-E7EE-4726-B21E-2F1E6058AF5F}";
            public static string AllChildGrades = "{7DD838FD-8BD3-4861-8E1E-540E6ED9BBE9}";
            public static string AllChildIssues = "{9E988E8F-4036-49E7-B9ED-687C99A669F9}";
        }

        public static class ChildEvaluation
        {
            public static string Status504InProgress = "{55F38A58-7506-454E-95E5-0ECE22A3B99C}";
            public static string Status504No = "{5754554A-D588-4EF9-8F9C-1E1DE66446F8}";
            public static string Status504Yes = "{82102C70-B526-47FB-BD99-5F71A33C3C87}";
            public static string StatusEvaluationInProgress = "{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}";
            public static string StatusEvaluationNo = "{992AB3CB-BAE7-47C6-B040-B674DC7FD29C}";
            public static string StatusEvaluationYes = "{990FB117-F12E-4E3C-898B-8A9EB217FCFD}";
            public static string StatusIEPInProgress = "{73842143-B6CA-4B6A-A94F-BA59C475A6D7}";
            public static string StatusIEPNo = "{80CB7C44-F570-4991-B395-6A634C2DE1D5}";
            public static string StatusIEPYes = "{FBE464C6-0E52-45C5-A1E9-660CB3C6B688}";
        }

        public static class Settings
        {
            public static string TelligentConfig = "TelligentConfig";
            public static string PersonalizationHandlerAllowedIps = "PersonalizationHandlerAllowedIps";
            public static string TelligentAdminApiKey = "TelligentAdminApiKey";
            //Added for default avatar
            public static string AnonymousAvatar = Sitecore.Configuration.Settings.GetSetting("TelligentConfig") + "/utility/anonymous.gif";
            public static string DefaultLocation = "Toronto";
        }
    }
}
