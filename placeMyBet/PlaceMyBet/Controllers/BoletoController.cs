using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class BoletoController : ApiController
    {
        // GET: api/Boleto
        public IEnumerable<BoletoDTO> Get()
        {
            var repo = new BoletoRepository();
            List<BoletoDTO> boletos = repo.RetrieveDTO();

            return boletos;
        }

        // GET: api/Boleto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Boleto
        public void Post([FromBody]Boleto boleto)
        {
            var repo = new BoletoRepository();
            repo.Save(boleto);
        }

        // PUT: api/Boleto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Boleto/5
        public void Delete(int id)
        {
        }
    }
}
