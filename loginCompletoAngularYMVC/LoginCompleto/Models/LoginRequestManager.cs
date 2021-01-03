using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace LoginCompleto.Models
{
    public class LoginRequestManager
    {
        //CECI
        //private const string StrConn = "Server=DESKTOP-UC8PIF7\\SQLEXPRESSV2;Database=ClipMoney;User Id=sa;Password=492clip1120;";

        //ERNESTO
        private const string StrConn = "Server=DESKTOP-5H4DSE8\\SQLEXPRESS;Database=ClipMoney;User Id=sa;Password=darwoft;";

        public NewUser Login(LoginRequest login)
        {

            NewUser loginViewModel = new NewUser();

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = " SELECT *" +
                               " FROM UserAccount" +
                               " WHERE Email LIKE @Email AND Password LIKE @Password";

            comm.Parameters.Add(new SqlParameter("@Email", login.Email));
            comm.Parameters.Add(new SqlParameter("@Password", login.Password));

            SqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                loginViewModel.Name = dr.GetString(0);
                loginViewModel.LastName = dr.GetString(1);
                loginViewModel.Cuil = dr.GetString(2);
                loginViewModel.Email = dr.GetString(3);

                loginViewModel.Password = "";
                loginViewModel.Birthdate = dr.GetDateTime(5);
                loginViewModel.Telephone = dr.GetString(6);
                loginViewModel.AccountState = dr.GetInt32(7);

                loginViewModel.UpAccountDate = dr.GetDateTime(8);
                loginViewModel.Address = dr.GetString(9);
                loginViewModel.City = dr.GetString(10);
                loginViewModel.PostCode = dr.GetString(11);

                loginViewModel.ImgDNI = dr.GetString(12);
            }
            else
            {
            }

            dr.Close();
            conn.Close();

            return loginViewModel;

        }

    }
}