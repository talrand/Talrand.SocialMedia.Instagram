using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class Quota
    {
        [DataMember(Name = "quota_usage")]
        public int QuotaUsage { get; set; }
        
        [DataMember(Name = "config")]
        public QuotaConfig Config { get; set; }
    }
}
