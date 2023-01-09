namespace Prototype.models
{
    public class User
    {
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string imageUrl { get; set; } = "https://glimesh-user-assets.nyc3.cdn.digitaloceanspaces.com/uploads/avatars/Mr.bean.png?v=63782882977";
        public string email { get; set; } = "ifuentes16730@iesjoanramis.org";
        private string password { get; set; }
    }
}
