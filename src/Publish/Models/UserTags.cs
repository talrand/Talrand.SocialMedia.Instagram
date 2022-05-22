using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Publish.Models
{
    [DataContract]
    public class UserTags
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "x")]
        public float X { get; set; }

        [DataMember(Name = "y")]
        public float Y { get; set; }
    }
}