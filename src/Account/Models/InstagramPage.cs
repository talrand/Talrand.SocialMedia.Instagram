using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class InstagramPage
    {
        [DataMember(Name = "instagram_business_account")]
        public InstagramBusinessAccount InstagramBusinessAccount { get; set; }
        
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}