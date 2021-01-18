using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class AsientosViewModel
    {
        public int IdFuncion { get; set; }
        public int IdPelicula { get; set; }
        public string TituloPelicula { get; set; }
        public DateTime FechaHora { get; set; }
        public ICollection<Asiento> AsientosNoDisponibles { get; set; }
    }
}