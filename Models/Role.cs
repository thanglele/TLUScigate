namespace OAuthv2.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> userRoles { get; set; }
    }
}
