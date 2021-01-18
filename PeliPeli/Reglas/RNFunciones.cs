using PeliPeli.Datos;
using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PeliPeli.Reglas
{
    public class RNFunciones
    {
        private static BaseDatosContext bd = BaseDatosContext.InstanciaBD;
        //private static BaseDatosContext bd = new BaseDatosContext();

        public static List<Funcion> ListarFunciones()
        {
            return bd.Funciones.ToList();
        }

        public static Funcion ObtenerFuncionPorId(int IdFuncion, BaseDatosContext contexto)
        {
            return contexto.Funciones
                .Include(x => x.Asientos)
                .Where(f => f.IdFuncion == IdFuncion).FirstOrDefault();
        }
        public static Funcion ObtenerFuncionPorId(int IdFuncion)
        {
            return ObtenerFuncionPorId(IdFuncion, bd);
        }
    }
}