using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class PartidoController : ApiController
    {
        // GET: api/Partido
        public IEnumerable<PartidoDTO> Get()
        {
            var repo = new PartidoRepository();
            List<PartidoDTO> partidos = repo.RetrieveDTO();

            return partidos;
        }

        // GET: api/Partido/5
        public Partido Get(int id)
        {
            //var repo = new PartidoRepository();
            //Partido p = repo.Retrieve();
            return null;
        }

        // POST: api/Partido
        public void Post([FromBody]Partido partido)
        {
            var repo = new PartidoRepository();
            repo.Save(partido);
        }

        // PUT: api/Partido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Partido/5
        public void Delete(int id)
        {
        }
    }
}
