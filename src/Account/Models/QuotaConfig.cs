using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class QuotaConfig
    {
        [DataMember(Name = "quota_total")]
        public int QuotaTotal { get; set; }
        
        [DataMember(Name = "quota_duration")]
        public int QuotaDuration { get; set; }
    }
}