using LoginCompleto.Models;
using System;
using System.Net;
using System.Web.Http;

namespace LoginCompleto.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/registration")]
    public class RegistrationController : ApiController
    {

        [HttpPost]
        [Route("newuser")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult NewUser(NewUser newUser)
        {
            newUser.UpAccountDate = DateTime.Now;
            newUser.Birthdate = DateTime.Now;
            newUser.Telephone = "33";
            newUser.Address = "TUCUMAN";
            newUser.City = "TUCUMAN";
            newUser.PostCode = "5000";
            newUser.ImgDNI = "imgDNI";
            newUser.AccountState = 1;

            NewUserManager newUserManager = new NewUserManager();

            if (newUser == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            else if(newUserManager.UserExist(newUser.Email))
            {
                newUserManager.Insert(newUser);
                return Ok(true);
            } else
            {
                return Ok(false);
            }
        }
    }
}