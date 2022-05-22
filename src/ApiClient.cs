using System;
using Talrand.SocialMedia.Instagram.Account;
using Talrand.SocialMedia.Instagram.Authorization;
using Talrand.SocialMedia.Instagram.Publish;

namespace Talrand.SocialMedia.Instagram
{
    public class ApiClient : IApiClient
    {
        private readonly IAccountClient _accountClient = new AccountClient();
        private readonly IAuthorizationClient _authorizationClient = new AuthorizationClient();
        private readonly IPublishClient _publishClient = new PublishClient();

        public IAuthorizationClient Authorization => _authorizationClient;

        public IAccountClient Account => _accountClient;

        public IPublishClient Publish => _publishClient;
    }
}