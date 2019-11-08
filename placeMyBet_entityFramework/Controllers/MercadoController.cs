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
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.Retrieve();

            return mercados;
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var repo = new MercadoRepository();
            Mercado mercado = repo.Retrieve(id);

            return mercado;
        }

        // GET: api/Mercado?partido=partido
        //public IEnumerable<MercadoDTO> GetByPartido(int id)
        //{
        //    var repo = new MercadoRepository();
        //    List<MercadoDTO> m = repo.RetrieveByPartido(id);

        //    return m;
        //}

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
