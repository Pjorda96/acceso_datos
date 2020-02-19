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
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestaRepository();
            List<Apuesta> apuestas = repo.Retrieve();

            return apuestas;
        }

        // GET: api/Apuesta/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve(id);

            return a;
        }

        //Ejercicio 1
        // GETByAmount: api/Apuesta?importe=1
        public IEnumerable<ApuestaAmountDTO> GetByAmount(double importe)
        {
            var repo = new ApuestaRepository();
            List<ApuestaAmountDTO> a = repo.RetrieveByAmount(importe);

            return a;
        }
        //Fin Ejercicio 1

        //Ejercicio 2
        // GETByAmount: api/Apuesta?equipo=Valencia
        public IEnumerable<Apuesta> GetByEquipo(String equipo)
        {
            var repo = new ApuestaRepository();
            List<Apuesta> a = repo.RetrieveByEquipo(equipo);

            return a;
        }
        //Fin Ejercicio 2

        // GETByUser: api/Apuesta?email=email
        public IEnumerable<ApuestaDTO> GetByUserEmail(string email)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> a = repo.RetrieveByUserEmail(email);

            return a;
        }

        // GETByMercado: api/Apuesta?email=email
        [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestaDTO> GetByMercado(int mercado)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> a = repo.RetrieveByMercado(mercado);

            return a;
        }

        // POST: api/Apuesta
        //[Authorize]
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
