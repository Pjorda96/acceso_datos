using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();

            return apuestas;
        }

        // GET: api/Apuesta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuesta
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
