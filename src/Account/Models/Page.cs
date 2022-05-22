using System.Runtime.Serialization;

namespace Talrand.SocialMedia.Instagram.Account.Models
{
    [DataContract]
    public class Page
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        
        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "category_list")]
        public CategoryList[] CategoryList { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "tasks")]
        public string[] Tasks { get; set; }
    }
}