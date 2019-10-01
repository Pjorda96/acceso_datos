using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();

            return mercados;
        }

        // GET: api/Mercado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mercado
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadoRepository();
            repo.Save(mercado);
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
