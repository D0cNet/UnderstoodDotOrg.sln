using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive {
    public partial class VideoResources : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
          ltBrightCovePlayer.Text =  GetEmbedCode("480", "270");
          ltVideoDetailShow.Text = DictionaryConstants.CloseTranscriptLabel;
          WebinarEventPageItem contextItem = Sitecore.Context.Item;
          if (contextItem != null) {
              frVideoTranscript.Item = contextItem;
          }
        }

        private const string BackgroundColor = "#ffffff";
        private static string CreateEmbedID() {
            Random r = new Random();
            return "BrightcoveVideo_" + r.Next(1001).ToString();
        }

        /// <summary>
        /// This will build an html object tag based on the information provided
        /// </summary>
        public static string GetEmbedCode(string playerWidth, string playerHeight) {

            StringBuilder embed = new StringBuilder();

            
                //this one works
                embed.AppendLine("<!-- Start of Brightcove Player -->");
                embed.AppendLine("");
                embed.AppendLine("<div style=\"display:none\"></div>");
                embed.AppendLine("<script language=\"JavaScript\" type=\"text/javascript\" src=\"/presentation/includes/js/BrightcoveExperiences.js\"></script>");
                embed.AppendLine("<object id=\"" + CreateEmbedID() + "\" class=\"BrightcoveExperience\">");
                embed.AppendLine("<param name=\"bgcolor\" value=\"" + BackgroundColor + "\" />");
                embed.AppendLine("<param name=\"width\" value=\"" + playerWidth + "\" />");
                embed.AppendLine("<param name=\"height\" value=\"" + playerHeight + "\" />");
                embed.AppendLine("<param name=\"playerID\" value=\"3203925133001\" />");
                embed.AppendLine("<param name=\"playerKey\" value=\"AQ~~,AAAC6NDP1nE~,dOSiqHy89Sli4ZPOUFfVGW6O9wJ4rR6y\" />");
                embed.AppendLine("<param name=\"@videoPlayer\" value=\"3203925031001\"/>");
                embed.AppendLine("<param name=\"isVid\" value=\"true\" />");
                embed.AppendLine("<param name=\"autoStart\" value=\"false\" />");
                embed.AppendLine("<param name=\"isUI\" value=\"true\" />");
                embed.AppendLine("<param name=\"dynamicStreaming\" value=\"true\" />");
                embed.AppendLine("<param name=\"templateLoadHandler\" value=\"myTemplateLoaded\" />");
                embed.AppendLine("<param name=\"allowScriptAccess\" value=\"always\" />");
                embed.AppendLine("<param name=\"includeAPI\" value=\"true\" />");
                embed.AppendLine("<param name=\"wmode\" value=\"opaque\" />");
                embed.AppendLine("</object>");

                embed.AppendLine("");
                embed.AppendLine("<!-- End of Brightcove Player -->");
            
            return embed.ToString();
        }
    }
}