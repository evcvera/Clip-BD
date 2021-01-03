using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using LoginCompleto.Models.WalletAccountModel;

namespace LoginCompleto.Service.WalletAccountService
{
    public class NewWalletAccountService
    {
        private const string StrConn = "Server=DESKTOP-5H4DSE8\\SQLEXPRESS;Database=ClipMoney;User Id=sa;Password=darwoft;";

        public bool NewWalletService(WalletAccountModel walletAccountModel)
        {
            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = "INSERT INTO WalletAccount (Id, Email, Type, State, Balance," +
                               "CreatedOn, DeletedOn ) " +
                               "VALUES (@Id, @Email, @Type, @State, @Balance, @CreatedOn, @DeletedOn)";

            comm.Parameters.Add(new SqlParameter("@Id", walletAccountModel.Id));
            comm.Parameters.Add(new SqlParameter("@Email", walletAccountModel.Email));
            comm.Parameters.Add(new SqlParameter("@Type", walletAccountModel.Type));
            comm.Parameters.Add(new SqlParameter("@State", walletAccountModel.State));
            comm.Parameters.Add(new SqlParameter("@Balance", walletAccountModel.Balance));
            comm.Parameters.Add(new SqlParameter("@CreatedOn", walletAccountModel.CreatedOn));
            comm.Parameters.Add(new SqlParameter("@DeletedOn", walletAccountModel.DeletedOn));

            comm.ExecuteNonQuery();

            conn.Close();

            return true;
        }

        public bool IsCbuExist(string cbu)
        {
            if(cbu == null)
            {
                return true;
            }
            else { 
            bool isCbuOk;

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();
            SqlCommand comm = conn.CreateCommand();

            comm.CommandText = " SELECT Id" +
                               " FROM WalletAccount" +
                               " WHERE Id LIKE @Id";

            comm.Parameters.Add(new SqlParameter("@Id", cbu));

            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                isCbuOk = true;
            }
            else
            {
                isCbuOk = false;
            }

            dr.Close();
            conn.Close();

            return isCbuOk;
            }
        }
    }
}