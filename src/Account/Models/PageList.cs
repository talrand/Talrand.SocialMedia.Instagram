using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class PageList
    {
        [DataMember(Name = "data")]
        public Page[] Data { get; set; }

        [DataMember(Name = "paging")]
        public Paging Paging { get; set; }
    }
}