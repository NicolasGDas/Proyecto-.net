using PeliPeli.Models;
using PeliPeli.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeliPeli.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Asientos(int IdFuncion)
        {
            ViewBag.Error = TempData["Error"];
            var Funcion = RNFunciones.ObtenerFuncionPorId(IdFuncion);
            var Pelicula = RNPeliculas.ObtenerPeliculaPorId(Funcion.IdPelicula);
            AsientosViewModel a = new AsientosViewModel { IdFuncion = IdFuncion, IdPelicula = Funcion.IdPelicula, AsientosNoDisponibles = Funcion.Asientos, FechaHora = Funcion.FechaHora, TituloPelicula = Pelicula.Titulo };
            return View(a);
        }

        [HttpPost]
        public ActionResult Asientos(int IdPelicula, int IdFuncion, string[] Asientos, double Total)
        {
            int i = 0;
            bool AsientoOk=true;
            while (Asientos.Length>i && AsientoOk)
            {
                AsientoOk = !RNAsientos.EstaReservado(IdFuncion, Asientos[i]);
                i++;
            }
            if (i == Asientos.Length && AsientoOk)
            {
                //Todo OK
                Reserva r = RNReservas.RegistrarReserva(IdPelicula, IdFuncion, Asientos, Total);
                return RedirectToAction("Confirmacion", new { r.IdReserva });
            }
            else
            {
                TempData["Error"] = "Lo sentimos. El/los asientos seleccionados ya fueron ocupados. Vuelva a seleccionar.";
                return RedirectToAction("Asientos", new { IdPelicula, IdFuncion });
            }

        }
        public ActionResult Listar()
        {
            List<Reserva> reservas = RNReservas.ListarReservas();
            List<ReservaViewModel> reservasListado=new List<ReservaViewModel>();
            Pelicula p;
            Funcion f;
            foreach (Reserva r in reservas)
            {
                p = RNPeliculas.ObtenerPeliculaPorId(r.IdPelicula);
                f = RNFunciones.ObtenerFuncionPorId(r.IdFuncion);
                reservasListado.Add(new ReservaViewModel { Reserva = r, TituloPelicula = p.Titulo, FechaHora = f.FechaHora });
            }
            return View(reservasListado);
        }

        public ActionResult Eliminar(int id)
        {
            Reserva r = RNReservas.ObtenerReservaPorID(id);
            Pelicula p = RNPeliculas.ObtenerPeliculaPorId(r.IdPelicula);
            Funcion f = RNFunciones.ObtenerFuncionPorId(r.IdFuncion);
            ReservaViewModel reservaDevolver = new ReservaViewModel() { Reserva = r, TituloPelicula = p.Titulo, FechaHora = f.FechaHora };
            return View(reservaDevolver);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfimacionEliminacion(int id)
        {
            RNReservas.CancelarReserva(id);
            return RedirectToAction("Listar");
        }

        public ActionResult Confirmacion(int IdReserva)
        {
            Reserva r = RNReservas.ObtenerReservaPorID(IdReserva);
            Pelicula p = RNPeliculas.ObtenerPeliculaPorId(r.IdPelicula);
            Funcion f = RNFunciones.ObtenerFuncionPorId(r.IdFuncion);

            ReservaViewModel reserva = new ReservaViewModel { Reserva=r, TituloPelicula = p.Titulo, FechaHora = f.FechaHora, Imagen = p.Imagen};
            return View(reserva);
        }
    }
}