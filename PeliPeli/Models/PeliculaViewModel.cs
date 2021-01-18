using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class PeliculaViewModel
    {
        public ICollection<Genero> Generos { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}