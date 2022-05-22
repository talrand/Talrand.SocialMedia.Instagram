using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class InstagramBusinessAccount
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}