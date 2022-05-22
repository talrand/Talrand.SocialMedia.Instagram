using System.Collections.Generic;
using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Publish.Models;

namespace Talrand.SocialMedia.Instagram.Publish
{
    public interface IPublishClient
    {
        /// <summary>Id of Instagram account to publish media to</summary>
        string InstagramId { get; set; }
        
        /// <summary>Facebook Graph access token used to authenticate api calls</summary>
        string AccessToken { get; set; }

        /// <summary>Publish image to user's Instagram account</summary>
        /// <param name="imageUrl">
        /// Url of the image to publish (for guidelines on image format visit https://developers.facebook.com/docs/instagram-api/reference/ig-user/media#creating)
        /// </param>
        /// <param name="caption">Text to display in Instagram post</param>
        Task<string> PublishImageAsync(string imageUrl, string caption, List<UserTags> userTags = null);

        /// <summary>Publish video to user's Instagram account </summary>
        /// <param name="videoUrl">
        /// Url of the video to publish (for guidelines on video format visit https://developers.facebook.com/docs/instagram-api/reference/ig-user/media#creating)
        /// </param>
        /// <param name="caption">Text to display in Instagram post</param>
        /// <param name="thumbnailOffset">Location in milliseconds of the video frame to be used as the video's cover thumbnail image</param>
        /// <returns></returns>
        Task<string> PublishVideoAsync(string videoUrl, string caption, int thumbnailOffset = 0);

        /// <summary>Gets the number of times the user has published Media in the past 24 hours</summary>
        Task<int?> GetQuotaUsageAsync();
    }
}