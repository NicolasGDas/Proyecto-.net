using System.ComponentModel.DataAnnotations;

namespace PeliPeli.Models
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        public string Nombre { get; set; }
    }
}