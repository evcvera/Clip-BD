namespace LoginCompleto.Models
{
    public class User
    {
        public User(NewUser loginUser, string token)
        {
            this.loginUser = loginUser;
            this.token = token;
        }

        public NewUser loginUser { get; set; }
        public string token { get; set; }
    }
}