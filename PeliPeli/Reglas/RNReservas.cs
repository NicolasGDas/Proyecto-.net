using PeliPeli.Datos;
using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PeliPeli.Reglas
{
    public class RNReservas
    {
        private static BaseDatosContext bd = BaseDatosContext.InstanciaBD;

        public static List<Reserva> ListarReservas()
        {
            return bd.Reservas.ToList();
        }
        public static Reserva RegistrarReserva(int IdPelicula, int IdFuncion, string[] Asientos, double total)
        {
            Reserva r = new Reserva { IdPelicula = IdPelicula, IdFuncion = IdFuncion, Total = total };
            r.Asientos = new List<Asiento>();
            foreach (string Asiento in Asientos)
            {
                r.Asientos.Add(new Asiento { Fila = Asiento.Split('-')[0], Columna = Convert.ToInt32(Asiento.Split('-')[1]), IdFuncion=IdFuncion });
            }

            bd.Reservas.Add(r);
            bd.SaveChanges();
            return r;
        }
        public static Reserva ObtenerReservaPorID(int IdReserva)
        {
            return bd.Reservas.Where(r => r.IdReserva == IdReserva).FirstOrDefault();
        }

        public static List<int> PeliculasMasReservada()
        {
            var items = bd.Reservas
             .GroupBy(x => x.IdPelicula)
             .Select(x => new { IdPelicula = x.Key, Count = x.Count() })
             .OrderByDescending(x => x.Count)
             .Take(5);

            List<int> topReservadas = new List<int>();
            foreach(var item in items)
            {
                topReservadas.Add(item.IdPelicula);
            }

            return topReservadas;
        }
        public static void CancelarReserva(int IdReserva)
        {
            Reserva r = ObtenerReservaPorID(IdReserva);
            RNAsientos.LiberarAsientos(r.Asientos, bd);
            bd.Reservas.Remove(r);
            bd.SaveChanges();
        }

        public static bool PeliculaReservada(int IdPelicula)
        {
           var reserva = bd.Reservas.Where(r => r.IdPelicula == IdPelicula).FirstOrDefault();
           return reserva != null;
        }
    }
}

