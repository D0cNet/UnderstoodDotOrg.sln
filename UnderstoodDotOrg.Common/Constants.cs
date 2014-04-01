using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common {
   public class Constants {
       public static readonly string SCLANG_QUERY_STRING = "sc_lang";

	   public static string CURRENT_INDEX_NAME
	   {
		   get
		   {
			   return string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name.ToLower());
		   }
	   }
    }
}
