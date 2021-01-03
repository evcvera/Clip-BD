using LoginCompleto.Models;
using LoginCompleto.Models.WalletAccountModel;
using LoginCompleto.Service.WalletAccountService;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LoginCompleto.Controllers
{
    [Authorize]
    [RoutePrefix("api/walletaccount")]
    public class WalletAccountController : ApiController
    {
        [HttpPost]
        [Route("newwallet")]
        public IHttpActionResult Newwallet([FromBody] WalletAccountModel walletAccountModel)
        {
            Random rnd = new Random();
            string cbu = "";
            //walletAccountModel.Id = "111111111111111111";
            //PARA VERIFICAR QUE NO EXITAN REPETIDOS
            walletAccountModel.CreatedOn = DateTime.Now;
            walletAccountModel.DeletedOn = DateTime.Now;
            NewWalletAccountService newWalletAccountService = new NewWalletAccountService();

            while (newWalletAccountService.IsCbuExist(walletAccountModel.Id) )
            {
                for (int i = 0; i < 22; i++)
                {
                    int randomNumber = rnd.Next(10);
                    cbu += randomNumber.ToString();
                }
                walletAccountModel.Id = cbu;
            }

            return Ok(newWalletAccountService.NewWalletService(walletAccountModel));
        }

        [HttpPost]
        [Route("getwallet")]
        //public IHttpActionResult GetWallet([FromBody] NewUser newUser)
        public IHttpActionResult GetWallet([FromBody] NewUser newUser)
        {
            GetWalletAccountService walletAccountModel = new GetWalletAccountService();

            List<WalletAccountModel> WalletAccountList = walletAccountModel.GetWalletService(newUser.Email);

            return Ok(WalletAccountList);
        }
    }
}