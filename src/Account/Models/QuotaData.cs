using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class QuotaData
    {
        [DataMember(Name="data")]
        public Quota[] Data { get; set; }
    }
}