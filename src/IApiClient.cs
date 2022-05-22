using Talrand.SocialMedia.Instagram.Account;
using Talrand.SocialMedia.Instagram.Authorization;
using Talrand.SocialMedia.Instagram.Publish;
using System.Net.Http;

namespace Talrand.SocialMedia.Instagram
{
    public interface IApiClient
    {
        IAuthorizationClient Authorization { get; }
        IAccountClient Account { get; }
        IPublishClient Publish { get; }
    }
}