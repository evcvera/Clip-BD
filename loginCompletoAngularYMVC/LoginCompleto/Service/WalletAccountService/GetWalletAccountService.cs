using LoginCompleto.Models.WalletAccountModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginCompleto.Service.WalletAccountService
{
    public class GetWalletAccountService
    {
        private const string StrConn = "Server=DESKTOP-5H4DSE8\\SQLEXPRESS;Database=ClipMoney;User Id=sa;Password=darwoft;";

        public List<WalletAccountModel> GetWalletService(string email)
        {
            List<WalletAccountModel> lista = new List<WalletAccountModel>();

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * " +
                               "FROM WalletAccount " +
                               "WHERE Email LIKE @Email";

            comm.Parameters.Add(new SqlParameter("@Email", email));

            SqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                string Id = dr.GetString(0);
                string Mail = dr.GetString(1);
                int Type = dr.GetInt32(2);
                int State = dr.GetInt32(3);
                int Balance = dr.GetInt32(4);
                DateTime CreatedOn = dr.GetDateTime(5);
                DateTime DeletedOn = dr.GetDateTime(6);


                WalletAccountModel p = new WalletAccountModel(Id, Mail, Type, State, Balance, CreatedOn, DeletedOn);
                lista.Add(p);
            }

            dr.Close();
            conn.Close();

            return lista;
        }
    }
}