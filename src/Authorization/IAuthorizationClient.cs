using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Authorization.Models;

namespace Talrand.SocialMedia.Instagram.Authorization
{
    public interface IAuthorizationClient
    {
        AppDetails AppDetails { get; }

        /// <summary>Creates initial authorisation url to begin OAuth flow</summary>
        /// <param name="scopes">A list of scopes app requires permission for</param>
        /// <returns>Url to begin OAuth authentication flow</returns>
        string CreateAuthUrl(string[] scopes);

        /// <summary>Converts a short lived access token into a long lived access token (see https://developers.facebook.com/docs/facebook-login/access-tokens/refreshing/)</summary>
        /// <param name="shortLivedAcessToken">Short lived Facebook Graph access token</param>
        /// <returns>Long lived Facebook Graph access token</returns>
        Task<Token> GetLongLivedAccessTokenAsync(string shortLivedAcessToken);
    }
}