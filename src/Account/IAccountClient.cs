using System.Collections.Generic;
using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Account.Models;

namespace Talrand.SocialMedia.Instagram.Account
{
    public interface IAccountClient
    {
        /// <summary>Facebook Graph OAuth Access Token</summary>
        string AccessToken { get; set; }

        /// <summary>Gets all pages for the authenticated user</summary>
        /// <returns>List of Page data</returns>
        Task<List<Page>> GetPagesAsync();

        /// <summary>Get Instagram Id linked to passed Facebook page</summary>
        /// <param name="facebookPageId">Id of Facebook page</param>
        /// <returns>Id of Instagram page linked to Facebook page</returns>
        Task<string> GetPageInstagramIdAsync(string facebookPageId);
    }
}