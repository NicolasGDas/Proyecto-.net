using System;

namespace PeliPeli.Models
{
    public class ReservaViewModel
    {
        public Reserva Reserva { get; set; }
        public string TituloPelicula { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaHora { get; set; }
    }
}