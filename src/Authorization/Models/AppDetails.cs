namespace Talrand.SocialMedia.Instagram.Authorization.Models
{
    public class AppDetails
    {
        public long Id { get; set; }
        public string Secret { get; set; }
        public string RedirectUri { get; set; }

        internal bool IsValid()
        {
            return Id != 0 && !string.IsNullOrWhiteSpace(Secret) && !string.IsNullOrWhiteSpace(RedirectUri);
        }
    }
}