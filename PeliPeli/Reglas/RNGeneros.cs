using PeliPeli.Datos;
using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeliPeli.Reglas
{
    public class RNGeneros
    {
        private static BaseDatosContext bd = BaseDatosContext.InstanciaBD;
        public static List<Genero> ListarGeneros()
        {
            return bd.Generos.ToList();
        }

        public static Genero ObtenerGeneroPorID(int IdGenero)
        {
            return bd.Generos.Where(g => g.IdGenero == IdGenero).FirstOrDefault();
        }
    }
}