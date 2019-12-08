using System;
using System.Collections.Generic;
using System.Linq;
using placeMyBet.Models;

namespace PlaceMyBet.Models
{
    public class PartidoRepository
    {
        internal List<Partido> Retrieve()
        {
            var partidos = new List<Partido>();

            using (var context = new PlaceMyBetContext())
            {
                partidos = context.Partidos.ToList();
            }

            return partidos;
        }

        internal Partido Retrieve(int id)
        {
            var partido = new Partido();

            using (var context = new PlaceMyBetContext())
            {
                partido = context.Partidos
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }

            return partido;
        }

        public PartidoDTO ToDTO(Partido p)
        {
            return new PartidoDTO(p.Local, p.Visitante);
        }

        internal List<PartidoDTO> RetrieveDTO()
        {
            var partidos = new List<PartidoDTO>();

            using (var context = new PlaceMyBetContext())
            {
                partidos = context.Partidos.Select(p => ToDTO(p)).ToList();
            }

            return partidos;
        }

        internal void Save(Partido p)
        {
            var context = new PlaceMyBetContext();

            context.Partidos.Add(p);
            context.SaveChanges();
        }

        internal void Update(int id, Partido p)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            Partido partido = Retrieve(id);

            partido.Local = p.Local;
            partido.Visitante = p.Visitante;
            context.SaveChanges();
        }

        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            Partido partido = Retrieve(id);

            context.Partidos.Remove(partido);
            context.SaveChanges();
        }
    }
}