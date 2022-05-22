using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Account.Models;
using Talrand.SocialMedia.Instagram.Publish.Models;

namespace Talrand.SocialMedia.Instagram.Publish
{
    internal class PublishClient : FacebookGraphHttpClient, IPublishClient
    {
        public string InstagramId { get; set; }
        public string AccessToken { get; set; }

        public async Task<int?> GetQuotaUsageAsync()
        {
            if (string.IsNullOrEmpty(InstagramId)) throw new ArgumentNullException(nameof(InstagramId));
            if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));

            // Construct url to retrieve current publish quota usage
            string url = $"{InstagramId}/content_publishing_limit?access_token={AccessToken}&fields=quota_usage,rate_limit_settings";

            QuotaData quotaData = await GetAsync<QuotaData>($"{InstagramId}/content").ConfigureAwait(false);

            return quotaData?.Data[0]?.QuotaUsage;
        }

        public async Task<string> PublishImageAsync(string imageUrl, string caption, List<UserTags> userTags = null)
        {
            if (string.IsNullOrEmpty(InstagramId)) throw new ArgumentNullException(nameof(InstagramId));
            if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));
            if (string.IsNullOrEmpty(imageUrl)) throw new ArgumentNullException(nameof(imageUrl));

            // Upload image and get media container for publishing live
            string mediaContainerId = await CreateImageContainerAsync(imageUrl, caption, userTags).ConfigureAwait(false);

            // Publish media container
            return await PublishMediaContainerAsync(mediaContainerId).ConfigureAwait(false);
        }

        /// <summary>Creates an Instagram Media container for the passed image url</summary>
        private async Task<string> CreateImageContainerAsync(string imageUrl, string caption, List<UserTags> userTags = null)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(imageUrl), "image_url");
            formData.Add(new StringContent(AccessToken), "access_token");

            if (!string.IsNullOrEmpty(caption))
            {
                formData.Add(new StringContent(caption), "caption");
            }

            if (userTags != null)
            {
                formData.Add(new StringContent(JsonSerializer.Serialize(userTags), Encoding.UTF8), "user_tags");
            }

            MediaId media = await PostAsync<MediaId>($"{InstagramId}/media", formData).ConfigureAwait(false);

            return media?.Id;
        }

        /// <summary>Publish previously created media container</summary>
        /// <param name="mediaContainerId">Id of the media container to publish</param>
        /// <returns>Id of the published Instagram post</returns>
        private async Task<string> PublishMediaContainerAsync(string mediaContainerId)
        {
            if (string.IsNullOrEmpty(mediaContainerId)) throw new ArgumentNullException(nameof(mediaContainerId));

            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(mediaContainerId), "creation_id");
            formData.Add(new StringContent(AccessToken), "access_token");

            MediaId media = await PostAsync<MediaId>($"{InstagramId}/media_publish", formData).ConfigureAwait(false);

            return media?.Id;
        }

        public async Task<string> PublishVideoAsync(string videoUrl, string caption, int thumbnailOffset = 0)
        {
            if (string.IsNullOrEmpty(InstagramId)) throw new ArgumentNullException(nameof(InstagramId));
            if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));
            if (string.IsNullOrEmpty(videoUrl)) throw new ArgumentNullException(nameof(videoUrl));

            // Upload video and get media container for publishing live
            string mediaContainerId = await CreateVideoContainerAsync(videoUrl, caption, thumbnailOffset);

            // Publish media 
            return await PublishMediaContainerAsync(mediaContainerId).ConfigureAwait(false);
        }

        /// <summary>Creates an Instagram Video container for the passed video url</summary>
        private async Task<string> CreateVideoContainerAsync(string videoUrl, string caption, int thumbnailOffset)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent("video"), "media_type");
            formData.Add(new StringContent(videoUrl), "video_url");
            formData.Add(new StringContent(AccessToken), "access_token");

            if (!string.IsNullOrEmpty(caption))
            {
                formData.Add(new StringContent(caption), "caption");
            }

            if (thumbnailOffset > 0)
            {
                formData.Add(new StringContent(thumbnailOffset.ToString()), "thumbnail_offset");
            }

            MediaId media = await PostAsync<MediaId>($"{InstagramId}/media", formData).ConfigureAwait(false);

            return media?.Id;
        }
    }
}