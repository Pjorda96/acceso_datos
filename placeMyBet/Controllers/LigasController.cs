using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using placeMyBet.Models;

namespace placeMyBet.Controllers
{
    public class LigasController : ApiController
    {
        // GET: api/Ligas
        public IEnumerable<LigasDTO> Get()
        {
            var repo = new LigasRepository();
            List<LigasDTO> ligas = repo.RetrieveDTO();

            return ligas;
        }
    }
}
