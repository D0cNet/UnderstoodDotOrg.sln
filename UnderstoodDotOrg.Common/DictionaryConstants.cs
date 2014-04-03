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
    }
}
