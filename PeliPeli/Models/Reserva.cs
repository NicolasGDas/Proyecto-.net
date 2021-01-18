using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdPelicula { get; set; }
        public int IdFuncion { get; set; }
        public virtual ICollection<Asiento> Asientos { get; set; }
        public double Total { get; set; }
    }
}