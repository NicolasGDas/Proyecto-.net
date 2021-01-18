using PeliPeli.Datos;
using PeliPeli.Models;
using PeliPeli.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeliPeli.Controllers
{
    public class PeliculaController : Controller
    {
       // GET: Pelicula
        public ActionResult Detalle(int id)
        {
            return View(RNPeliculas.ObtenerPeliculaPorId(id));

        }

        public ActionResult Listar()
        {
            return View(RNPeliculas.ListarPeliculas());
        }

        public ActionResult Nueva()
        {
            PeliculaViewModel p = new PeliculaViewModel { Generos = RNGeneros.ListarGeneros() };
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nueva([Bind(Include = "IdPelicula,Titulo,Duracion,FechaEstreno,Argumento,Actores,Director,Categoria,Trailer,Imagen")] Pelicula pelicula, int Genero, DateTime[] Funciones)
        {
            if (ModelState.IsValid)
            {
                pelicula.Genero = RNGeneros.ObtenerGeneroPorID(Genero);
                List<Funcion> funciones = new List<Funcion>();
                foreach(DateTime f in Funciones)
                {
                    funciones.Add(new Funcion { IdPelicula = pelicula.IdPelicula, FechaHora = f });
                }
                pelicula.Funciones = funciones;
                RNPeliculas.AgregarPelicula(pelicula);
                return RedirectToAction("Listar");
            }

            return View(pelicula);
        }

        public ActionResult Editar(int id)
        {
            PeliculaViewModel p = new PeliculaViewModel
            {
                Pelicula = RNPeliculas.ObtenerPeliculaPorId(id),
                Generos = RNGeneros.ListarGeneros()
            };
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IdPelicula,Titulo,Duracion,FechaEstreno,Argumento,Actores,Director,Categoria,Trailer,Imagen")] Pelicula pelicula, int Genero)
        {
            if (ModelState.IsValid)
            {
                pelicula.Genero = RNGeneros.ObtenerGeneroPorID(Genero);
                RNPeliculas.EditarPelicula(pelicula);
                return RedirectToAction("Listar");
            }
            return View(pelicula);
        }

        public ActionResult Eliminar(int id)
        {
            return View(RNPeliculas.ObtenerPeliculaPorId(id));
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfimacionEliminacion(int id)
        {
            if (RNReservas.PeliculaReservada(id))
            {
                TempData["Error"] = "No puede eliminar una pelicula que ya ha sido reservada";
            }
            else
            {
                RNPeliculas.EliminarPelicula(id);
            }
             return RedirectToAction("Listar");
        }

    }
}