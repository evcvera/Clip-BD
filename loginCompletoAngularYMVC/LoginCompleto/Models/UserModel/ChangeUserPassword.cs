namespace LoginCompleto.Models.UserModel
{
    public class ChangeUserPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public ChangeUserPassword(
            string Email,
            string Password,
            string NewPassword)
        {
            this.Email = Email;
            this.Password = Password;
            this.NewPassword = NewPassword;
        }

        public ChangeUserPassword()
        {

        }
    }
}