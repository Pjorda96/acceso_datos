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

        // GETByUser: api/Apuesta?email=email
        public IEnumerable<ApuestaDTO> GetByUserEmail(string email)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> a = repo.RetrieveByUserEmail(email);

            return a;
        }

        // GETByMercado: api/Apuesta?email=email
        //[Authorize(Roles = "Admin")]
        //public IEnumerable<ApuestaDTO> GetByMercado(int mercado)
        //{
        //    var repo = new ApuestaRepository();
        //    List<ApuestaDTO> a = repo.RetrieveByMercado(mercado);

        //    return a;
        //}

        /*** Ejercicio 2 ***/
        // GETByMercado: api/Apuesta?mercado=mercado
        public IEnumerable<ApuestaDTO> GetByMercadoGt(int mercado)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> a = repo.RetrieveByMercadoGt(mercado, 100);

            return a;
        }
        /*** Fin Ejercicio 2 ***/

        // POST: api/Apuesta
        /*** Ejercicio 3 ***/
        //[Authorize]
        public string Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            String response = repo.Save(apuesta);

            return response;
            /*** Ejercicio 3 ***/
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
