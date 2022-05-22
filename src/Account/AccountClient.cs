using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Account.Models;

namespace Talrand.SocialMedia.Instagram.Account
{
    internal class AccountClient : FacebookGraphHttpClient, IAccountClient
    {
        public string AccessToken { get; set; }

        public async Task<List<Page>> GetPagesAsync()
        {
            if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));

            List<Page> pages = new List<Page>();
            PageList pageList = null;
            string pageListUrl = "";

            // Construct initial page url
            pageListUrl = $"me/accounts?access_token{AccessToken}";

            do
            {
                // Call Graph API to get list of pages
                pageList = await GetAsync<PageList>(pageListUrl).ConfigureAwait(false);

                foreach (Page page in pageList.Data)
                {
                    pages.Add(page);
                }

                // Graph API uses paging for lists of pages. Get next page list if applicable
                pageListUrl = pageList?.Paging?.Next;

            } while (!string.IsNullOrEmpty(pageListUrl));

            return pages;
        }

        public async Task<string> GetPageInstagramIdAsync(string facebookPageId)
        {
            if (string.IsNullOrEmpty(AccessToken)) throw new ArgumentNullException(nameof(AccessToken));
            if (string.IsNullOrEmpty(facebookPageId)) throw new ArgumentNullException(nameof(facebookPageId));

            InstagramPage page = await GetAsync<InstagramPage>($"{facebookPageId}?access_token={AccessToken}fields=instagramn_business_account").ConfigureAwait(false);

            return page?.InstagramBusinessAccount?.Id;
        }
    }
}