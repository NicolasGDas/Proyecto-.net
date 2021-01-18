using PeliPeli.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeliPeli.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? IdReserva)
        {
            if (IdReserva.HasValue)
            {
                RNReservas.CancelarReserva((int)IdReserva);
            }
            List<int> topReservadas = RNReservas.PeliculasMasReservada();
            foreach(int item in topReservadas)
            {
                RNPeliculas.MarcarComoTopReservada(item);
            }
            return View(RNPeliculas.ListarPeliculas());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}