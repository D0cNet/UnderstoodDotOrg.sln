using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Services.MemberServices
{
    public static class MemberExtensions
    {
        public static string zipCodeToState(this Member member )
        {
            string state = String.Empty;
            XmlNode node = null;
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    if (!String.IsNullOrEmpty(member.ZipCode))
                    {
                        var requestUrl = "www.webservicex.net/uszip.asmx/GetInfoByZIP?USZip=" + member.ZipCode.Trim();
                        var xml = webClient.DownloadString(requestUrl);
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xml);
                        node = xmlDoc.SelectSingleNode("NewDataSet/Table/State");
                        if (node != null)
                        {
                            state = node.InnerText;
                        }
                    }
                }
            }catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error from Member Extension Method zipCodeToState:\n "+ex.Message, ex);
            }
            return state;
        }
    }
}
