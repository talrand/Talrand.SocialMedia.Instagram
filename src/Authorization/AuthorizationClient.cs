using System;
using System.Threading.Tasks;
using Talrand.SocialMedia.Instagram.Authorization.Models;

namespace Talrand.SocialMedia.Instagram.Authorization
{
    internal class AuthorizationClient : FacebookGraphHttpClient, IAuthorizationClient
    {
        private AppDetails _appDetails = new AppDetails();
        public AppDetails AppDetails => _appDetails;

        public string CreateAuthUrl(string[] scopes)
        {
            if (!AppDetails.IsValid()) throw new ArgumentException("Required App Details have not been entered");

            return $"https://www.facebook.com/v10.0/dialog/oauth?response_type=token&client_id={AppDetails.Id}&redirect_uri={AppDetails.RedirectUri}&scopes={string.Join(",", scopes)}";
        }

        public async Task<Token> GetLongLivedAccessTokenAsync(string shortLivedAcessToken)
        {
            if (AppDetails.IsValid()) throw new ArgumentException("Required App Details have not been entered");
            if (String.IsNullOrEmpty(shortLivedAcessToken)) throw new ArgumentNullException(nameof(shortLivedAcessToken));
            
            // Construct url to exchange passed short lived acces token for a long lived access token
            string url = $"oauth/access_token?grant_type=fb_exchange_token&client_id={AppDetails.Id}&client_secret={AppDetails.Secret}&fb_exchange_token={shortLivedAcessToken}";
            
            return await GetAsync<Token>(url).ConfigureAwait(false);
        }
    }
}