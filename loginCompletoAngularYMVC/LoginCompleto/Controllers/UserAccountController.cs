using LoginCompleto.Models.UserModel;
using LoginCompleto.Service.UserService;
using System.Web.Http;

namespace LoginCompleto.Controllers
{
    [Authorize]
    [RoutePrefix("api/useraccount")]
    public class UserAccountController : ApiController
    {
        [HttpPost]
        [Route("changepassword")]
        public IHttpActionResult ChangePassword([FromBody] ChangeUserPassword changeUserPassword)
        {
            ChangeUserPasswordService changeUserPasswordService = new ChangeUserPasswordService();

            if(changeUserPasswordService.IsUserEmailPassOk(changeUserPassword.Email, changeUserPassword.Password))
            {
                return Ok(changeUserPasswordService.ChangePasswordService(changeUserPassword));
            }
            { 
                return Ok(false);
            }
        }
    }
}