using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placeMyBet.Models
{
    public class LigasDTO
    {
        public LigasDTO(String abreviatura, String nombre)
        {
            Abreviatura = abreviatura;
            Nombre = nombre;
        }

        public String Abreviatura { get; set; }

        public String Nombre { get; set; }
    }
}