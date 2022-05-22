using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class CategoryList
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}