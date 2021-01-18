using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class Asiento
    {
        [Key]
        public int IdAsiento { get; set; }
        public string Fila { get; set; }
        public int IdFuncion { get; set; }
        public int Columna { get; set; }
        public int IdReserva { get; set; }
    }
}