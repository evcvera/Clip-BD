using LoginCompleto.Models.UserModel;
using System.Data.SqlClient;

namespace LoginCompleto.Service.UserService
{
    public class ChangeUserPasswordService
    {
        private const string StrConn = "Server=DESKTOP-5H4DSE8\\SQLEXPRESS;Database=ClipMoney;User Id=sa;Password=darwoft;";

        public bool ChangePasswordService(ChangeUserPassword changeUserPassword)
        {

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = "UPDATE UserAccount " +
                               "SET Password = @Password" +
                               " WHERE Email = @Email";

            comm.Parameters.Add(new SqlParameter("@Email", changeUserPassword.Email));
            comm.Parameters.Add(new SqlParameter("@Password", changeUserPassword.NewPassword));

            SqlDataReader dr = comm.ExecuteReader();

            dr.Close();
            conn.Close();

            return true;
        }

        public bool IsUserEmailPassOk(string email, string password)
        {
            bool isUserEmailPassOk;

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = " SELECT Email" +
                               " FROM UserAccount" +
                               " WHERE Email LIKE @Email AND Password LIKE @Password";

            comm.Parameters.Add(new SqlParameter("@Email", email));
            comm.Parameters.Add(new SqlParameter("@Password", password));

            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                isUserEmailPassOk = true;
            }
            else
            {
                isUserEmailPassOk = false;
            }

            dr.Close();
            conn.Close();

            return isUserEmailPassOk;
        }
    }
}