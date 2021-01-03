using System.Data.SqlClient;

namespace LoginCompleto.Models
{
    public class NewUserManager
    {
        //CECI
        //private const string StrConn = "Server=DESKTOP-UC8PIF7\\SQLEXPRESSV2;Database=ClipMoney;User Id=sa;Password=492clip1120;";

        //ERNESTO
        private const string StrConn = "Server=DESKTOP-5H4DSE8\\SQLEXPRESS;Database=ClipMoney;User Id=sa;Password=darwoft;";

        public bool UserExist(string email)
        {
            bool isUserExist;

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = " SELECT Email" +
                               " FROM UserAccount" +
                               " WHERE Email LIKE @Email";

            comm.Parameters.Add(new SqlParameter("@Email", email));

            SqlDataReader dr = comm.ExecuteReader();

            if (!dr.HasRows) {
                isUserExist = true;
            } else {
                isUserExist = false;
            }

            dr.Close();
            conn.Close();

            return isUserExist;
        }

        public void Insert(NewUser newAccount)
        {
            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO UserAccount (Name, LastName, Email, Password, Birthdate," +
                               "Telephone, cuil, AccountState, UpAccountDate, Address, City, PostCode, imgDNI) " +
                               "VALUES (@Name, @LastName, @Email, @Password, @Birthdate, @Telephone, @cuil, " +
                               "@AccountState, @UpAccountDate, @Address, @City, @PostCode, @imgDNI)";

            comm.Parameters.Add(new SqlParameter("@Name", newAccount.Name));
            comm.Parameters.Add(new SqlParameter("@LastName", newAccount.LastName));
            comm.Parameters.Add(new SqlParameter("@Email", newAccount.Email));
            comm.Parameters.Add(new SqlParameter("@Password", newAccount.Password));
            comm.Parameters.Add(new SqlParameter("@Birthdate", newAccount.Birthdate));
            comm.Parameters.Add(new SqlParameter("@Telephone", newAccount.Telephone));
            comm.Parameters.Add(new SqlParameter("@cuil", newAccount.Cuil));
            comm.Parameters.Add(new SqlParameter("@AccountState", newAccount.AccountState));
            comm.Parameters.Add(new SqlParameter("@UpAccountDate", newAccount.UpAccountDate));
            comm.Parameters.Add(new SqlParameter("@Address", newAccount.Address));
            comm.Parameters.Add(new SqlParameter("@City", newAccount.City));
            comm.Parameters.Add(new SqlParameter("@PostCode", newAccount.PostCode));
            comm.Parameters.Add(new SqlParameter("@imgDNI", newAccount.ImgDNI));

            comm.ExecuteNonQuery();

            conn.Close();
        }
    }
}