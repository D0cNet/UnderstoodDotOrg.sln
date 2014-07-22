using MaxMind.GeoIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Services.LocationServices
{
    public static class GeoIPLookup
    {


        public static string GetCountry(string ClientIP)
        {
            //shortcut for local
            if (ClientIP == "127.0.0.1")
            {
                return "US";
            }

            // future licensed webservice call
            //int _userId = int.Parse(Sitecore.Configuration.Settings.GetSetting(Constants.GeoIPLookup.GeoIPUserId));
            //string _licenseKey = Sitecore.Configuration.Settings.GetSetting(Constants.GeoIPLookup.GeoIPLicenseKey);

            //var client = new WebServiceClient(_userId, _licenseKey);
            //var omni = client.Country(ClientIP);

            //return omni.Country.IsoCode;

            // temporary free database
            string _database = Sitecore.Configuration.Settings.GetSetting(Constants.GeoIPLookup.GeoIPDatabaseName);
            string _dataFolder = Sitecore.Configuration.Settings.DataFolder;


            try
            {
                var reader = new DatabaseReader(_dataFolder + "\\" + _database);

                var country = reader.Country(ClientIP);
                return country.Country.IsoCode;
            }
            catch (Exception)
            {
                return "US";
            }
            
        }


    }
}
