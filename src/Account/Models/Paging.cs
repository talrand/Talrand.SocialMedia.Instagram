using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class Paging
    {
        [DataMember(Name = "cursors")]
        public Cursors Cursors { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }
    }
}