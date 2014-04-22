using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common
{
    public static class Constants
    {
        public static readonly string SCLANG_QUERY_STRING = "sc_lang";

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


    }
}
