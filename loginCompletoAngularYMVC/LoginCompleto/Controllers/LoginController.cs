using System.Net;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using LoginCompleto.Models;

namespace LoginCompleto.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

            LoginRequestManager loginRequestManager = new LoginRequestManager();
            var loginUser = loginRequestManager.Login(login);

            if (login == null) 
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //bool isCredentialValid = (login.Password == "123456");
            //bool isUserValid = (login.Email == "clip");

            if (loginUser.Name != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Email);
                return Ok(new User(loginUser, token));
            }
            else
            {
                return Ok(false);
            }
            //else
            //{
            //    return Unauthorized();
            //}
        }
    }
}
