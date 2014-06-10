
namespace UnderstoodDotOrg.Domain.CommonSenseMedia
{
    /// <summary>
    /// Class for defining the parts of a ReviewImage
    /// </summary>
    public class ReviewImageModel
    {
        /// <summary>
        /// URL to image
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Alt-text to use for the image
        /// </summary>
        public string AltText { get; set; }

        /// <summary>
        /// Name to use for the image
        /// </summary>
        public string Name { get; set; }
    }
}
