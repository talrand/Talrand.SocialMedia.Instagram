using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class Cursors
    {
        [DataMember(Name = "before")]
        public string Before { get; set; }

        [DataMember(Name = "after")]
        public string After { get; set; }
    }
}