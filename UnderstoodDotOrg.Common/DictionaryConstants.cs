using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Globalization;

namespace UnderstoodDotOrg.Common
{
    public class DictionaryConstants
    {
        private static string PosesDictionary = "Poses Dictionary";

        public static string YesButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Yes Button Text");
            }
        }

        public static string NoButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "No Button Text");
            }
        }

        public static string BoyButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Boy Button Text");
            }
        }

        public static string GirlButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Girl Button Text");
            }
        }

        public static string InProgressButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "In Progress Button Text");
            }
        }

        public static string SubmitButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Submit Button Text");
            }
        }

        public static string MomButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Mom Button Text");
            }
        }

        public static string DadButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Dad Button Text");
            }
        }

        public static string NextButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Next Button Text");
            }
        }

        public static string SignUpButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Sign Up Button Text");
            }
        }

        public static string ScreenNameWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Screen Name Watermark");
            }
        }

        public static string ZipCodeWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Zip Code Watermark");
            }
        }

        public static string ParentRoleDefault
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Parent List Watermark");
            }
        }

        public static class Grades
        {
            public static string SelectGrade
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Select Grade");
                }
            }

            public static string Grade1
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 1");
                }
            }

            public static string Grade2
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 2");
                }
            }
            public static string Grade3
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 3");
                }
            }
            public static string Grade4
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 4");
                }
            }
            public static string Grade5
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 5");
                }
            }
            public static string Grade6
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 6");
                }
            }
            public static string Grade7
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 7");
                }
            }
            public static string Grade8
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 8");
                }
            }
            public static string Grade9
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 9");
                }
            }
            public static string Grade10
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 10");
                }
            }
            public static string Grade11
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 11");
                }
            }
            public static string Grade12
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 12");
                }
            }

        }
    }
}
