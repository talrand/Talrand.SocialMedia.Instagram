using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Publish.Models
{
    [DataContract]
    public class MediaId
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}