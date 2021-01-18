using PeliPeli.Datos;
using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PeliPeli.Reglas
{
    public class RNPeliculas
    {
        //private static BaseDatosContext bd = new BaseDatosContext();
        private static BaseDatosContext bd = BaseDatosContext.InstanciaBD;
        public static List<Pelicula> ListarPeliculas()
        {
            return bd.Peliculas.ToList();
        }

        public static Pelicula ObtenerPeliculaPorId(int IdPelicula, BaseDatosContext contexto)
        {
            return contexto.Peliculas.Where(p => p.IdPelicula == IdPelicula).FirstOrDefault();
        }

        public static Pelicula ObtenerPeliculaPorId(int IdPelicula)
        {
            return ObtenerPeliculaPorId(IdPelicula, bd);
        }

        public static void AgregarPelicula(Pelicula pelicula)
        {
            bd.Peliculas.Add(pelicula);
            bd.SaveChanges();
        }

        public static void EditarPelicula(Pelicula pelicula)
        {
            Pelicula p = ObtenerPeliculaPorId(pelicula.IdPelicula);
            p.Genero = pelicula.Genero;
            bd.Entry(p).CurrentValues.SetValues(pelicula);
            bd.Entry(p).State = EntityState.Modified;
            //bd.Peliculas.AddOrUpdate(pelicula);
            bd.SaveChanges();
        }

        public static void EliminarPelicula(int id)
        {
            Pelicula pelicula = ObtenerPeliculaPorId(id);
            bd.Peliculas.Remove(pelicula);
            bd.SaveChanges();
        }

        public static void MarcarComoTopReservada(int id)
        {
            Pelicula p = ObtenerPeliculaPorId(id);
            p.TopReservada = true;
            bd.Peliculas.AddOrUpdate(p);
            bd.SaveChanges();
        }
    }
}