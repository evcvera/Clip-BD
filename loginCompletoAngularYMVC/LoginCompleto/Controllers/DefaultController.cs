using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using LoginCompleto.Models;

namespace LoginCompleto.Controllers
{
    [Authorize]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<Cliente> Get()
        {
            List<Cliente> lista = new List<Cliente>();
            lista.Add(new Cliente() {nombre = "pablo", apellido = "marmol", birthdate = DateTime.UtcNow.Date});
            lista.Add(new Cliente() {nombre = "pedro", apellido = "picapiedras", birthdate = DateTime.UtcNow.Date});

            return lista;
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
