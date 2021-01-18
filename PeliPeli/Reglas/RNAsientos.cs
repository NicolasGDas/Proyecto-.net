using PeliPeli.Datos;
using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeliPeli.Reglas
{
    public class RNAsientos
    {
        private static BaseDatosContext bd = BaseDatosContext.InstanciaBD;
        public static Asiento ObtenerAsiento(int IdFuncion, string Asiento) //"F-4"
        {
            Funcion funcion = RNFunciones.ObtenerFuncionPorId(IdFuncion);
            string Fila = Asiento.Split('-')[0];
            int Columna = Convert.ToInt32(Asiento.Split('-')[1]);
            return funcion.Asientos.Where(a => a.Fila == Fila && a.Columna == Columna).FirstOrDefault();
        }
        public static List<Asiento> ObtenerAsientosPorReserva(int IdReserva)
        {
            ICollection<Asiento> asientos = RNReservas.ObtenerReservaPorID(IdReserva).Asientos;
            return asientos.Where(a => a.IdReserva == IdReserva).ToList();
        }
        public static bool EstaReservado(int IdFuncion, string Asiento)
        {
            Asiento a = ObtenerAsiento(IdFuncion, Asiento);
            return a != null;
        }

        public static void AgregarAsiento(int IdFuncion, string Asiento)
        {
            Funcion funcion = RNFunciones.ObtenerFuncionPorId(IdFuncion);
            string Fila = Asiento.Split('-')[0];
            int Columna = Convert.ToInt32(Asiento.Split('-')[1]);
            funcion.Asientos.Add(new Asiento { Fila = Fila, Columna = Columna });
            bd.SaveChanges();

        }

        public static void LiberarAsientos(ICollection<Asiento> Asientos, BaseDatosContext contexto)
        {
            contexto.Asientos.RemoveRange(Asientos);
            contexto.SaveChanges();
        }
    }
}