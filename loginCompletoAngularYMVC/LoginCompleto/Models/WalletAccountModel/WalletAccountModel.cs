
using System;

namespace LoginCompleto.Models.WalletAccountModel
{
    public class WalletAccountModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }


        public WalletAccountModel(
            string Id,
            string Email,
            int Type,
            int State,
            int Balance,
            DateTime CreatedOn,
            DateTime DeletedOn)
        {
            this.Id = Id;
            this.Email = Email;
            this.Type = Type;
            this.State = State;
            this.Balance = Balance;
            this.CreatedOn = CreatedOn;
            this.DeletedOn = DeletedOn;
        }

        public WalletAccountModel()
        {

        }
    }
}