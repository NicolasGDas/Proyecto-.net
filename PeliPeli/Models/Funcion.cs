using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class Funcion
    {
        [Key]
        public int IdFuncion { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdPelicula { get; set; }
        public virtual ICollection<Asiento> Asientos { get; set; }
    }
}