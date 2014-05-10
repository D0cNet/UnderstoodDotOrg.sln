using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Handlers
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {
        private Guid itemId
        {
            get
            {
                Guid id;
                Guid.TryParse(HttpHelper.GetQueryString("id"), out id);

                return id;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var requestedItem = Sitecore.Context.Database.GetItem(itemId.ToString());
            var infographicArticle = new InfographicArticlePageItem(requestedItem);
            var mediaItem = infographicArticle.Image.MediaItem;

            Stream mediaStream = mediaItem.GetMediaStream();
            long FileSize;

            FileSize = mediaStream.Length;
            byte[] Buffer = new byte[(int)FileSize];
            mediaStream.Read(Buffer, 0, (int)mediaStream.Length);
            mediaStream.Close();

            context.Response.Clear();
            context.Response.ContentType = string.Format(mediaItem.MimeType);
            context.Response.AddHeader("content-disposition", "attachment; filename=" + mediaItem.Name + "." + mediaItem.Extension);
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            context.Response.BinaryWrite(Buffer);

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}