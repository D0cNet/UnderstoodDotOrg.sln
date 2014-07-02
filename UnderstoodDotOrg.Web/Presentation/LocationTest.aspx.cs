using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Services.LocationServices;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class LocationTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxLocation.Text = GeoIPLookup.GetCountry("50.241.102.161");
        }
    }
}