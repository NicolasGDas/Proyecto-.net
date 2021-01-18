using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeliPeli.Models
{
    public class Pelicula
    {
        [Key]
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string Argumento { get; set; }
        public string Actores { get; set; } //Podría ser una lista de Actor
        public string Director { get; set; } //Podria ser una clase Director
        public string Categoria { get; set; } //+13 / +16 etc
        public string Trailer { get; set; } //Link al video de youtube
        public string Imagen { get; set; } //Link de la imagen
        public bool TopReservada { get; set; }
        public virtual ICollection<Funcion> Funciones { get; set; }
        //public List<Funcion> Funciones { get; set; }
    }
}