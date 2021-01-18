using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeliPeli.Datos
{

    public class PeliculasInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BaseDatosContext>
    {
        protected override void Seed(BaseDatosContext context)
        {
            var Funciones1 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 14:30"), IdPelicula=1},
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 21:30"), IdPelicula=1},
                new Funcion { FechaHora = DateTime.Parse("2020-12-07 19:00"), IdPelicula=1}
            };

            var Funciones2 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 14:30"), IdPelicula=2},
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 21:30"), IdPelicula=2},
                new Funcion { FechaHora = DateTime.Parse("2020-12-07 19:00"), IdPelicula=2}
            };
            var Funciones3 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 14:30"), IdPelicula=3},
                new Funcion { FechaHora = DateTime.Parse("2020-12-05 21:30"), IdPelicula=3},
                new Funcion { FechaHora = DateTime.Parse("2020-12-07 19:00"), IdPelicula=3}
            };
            var Funciones4 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-03 14:30"), IdPelicula=4},
                new Funcion { FechaHora = DateTime.Parse("2020-12-11 21:30"), IdPelicula=4},
                new Funcion { FechaHora = DateTime.Parse("2020-12-15 19:00"), IdPelicula=4}
            };
            var Funciones5 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-05 14:30"), IdPelicula=5},
                new Funcion { FechaHora = DateTime.Parse("2020-12-10 21:30"), IdPelicula=5},
                new Funcion { FechaHora = DateTime.Parse("2020-12-13 19:00"), IdPelicula=5}
            };
            var Funciones6 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-02 14:30"), IdPelicula=6},
                new Funcion { FechaHora = DateTime.Parse("2020-12-08 21:30"), IdPelicula=6},
                new Funcion { FechaHora = DateTime.Parse("2020-12-12 19:00"), IdPelicula=6}
            };
            var Funciones7 = new List<Funcion>
            {
                new Funcion { FechaHora = DateTime.Parse("2020-12-13 14:30"), IdPelicula=7},
                new Funcion { FechaHora = DateTime.Parse("2020-12-05 21:30"), IdPelicula=7},
                new Funcion { FechaHora = DateTime.Parse("2020-12-09 19:00"), IdPelicula=7}
            };

            var generos = new List<Genero>
            {
                 new Genero { Nombre = "Terror" },
                 new Genero { Nombre = "Accion" },
                 new Genero { Nombre = "Drama" },
                 new Genero { Nombre = "Animacion" },
                 new Genero { Nombre = "Comedia" }
            };
            Funciones1.ForEach(f => context.Funciones.Add(f));
            Funciones2.ForEach(f => context.Funciones.Add(f));
            Funciones3.ForEach(f => context.Funciones.Add(f));
            Funciones4.ForEach(f => context.Funciones.Add(f));
            Funciones5.ForEach(f => context.Funciones.Add(f));
            Funciones6.ForEach(f => context.Funciones.Add(f));
            Funciones7.ForEach(f => context.Funciones.Add(f));

            var Peliculas = new List<Pelicula>
            {
                new Pelicula{
                    Titulo="El origen",
                    Argumento="Dom Cobb es un ladrón con una extraña habilidad para entrar a los sueños de la gente y robarles los secretos de sus subconscientes. Su habilidad lo ha vuelto muy popular en el mundo del espionaje corporativo, pero ha tenido un gran costo en la gente que ama. Cobb obtiene la oportunidad de redimirse cuando recibe una tarea imposible: plantar una idea en la mente de una persona. Si tiene éxito, será el crimen perfecto, pero un enemigo se anticipa a sus movimientos.",
                    Categoria="+13",
                    Actores="Leonardo DiCaprio",
                    Director="Christopher Nolan",
                    Duracion=148,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[1],
                    Imagen="estreno1.jpg",
                    Funciones=Funciones1},
                new Pelicula{
                    Titulo="Titanic",
                    Argumento="Una joven de la alta sociedad abandona a su arrogante pretendiente por un artista humilde en el trasatlántico que se hundió durante su viaje inaugural.",
                    Categoria="+13",
                    Actores="Leonardo DiCaprio",
                    Director="James Cameron",
                    Duracion=195,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[2],
                    Imagen="estreno2.jpg",
                    Funciones=Funciones2},
                new Pelicula{
                    Titulo="Marley y yo",
                    Argumento="John y Jenny deciden dejar atrás los duros inviernos de Míchigan para iniciar sus nuevas vidas en la soleada West Palm Beach, donde adoptan a un perro incorregible.",
                    Categoria="+13",
                    Actores="Owen Wilson, Jennifer Aniston",
                    Director="David Frankel",
                    Duracion=120,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[2],
                    Imagen="estreno3.jpg",
                    Funciones=Funciones3},
                new Pelicula{
                    Titulo="Toy Story 4",
                    Argumento="Woody siempre ha tenido claro cuál es su labor en el mundo: cuidar a su dueño, ya sea Andy o Bonnie. Sin embargo, ahora descubrirá lo grande que puede ser el mundo para un juguete cuando el pequeño Forky se convierta en su nuevo compañero de habitación y se embarquen en una aventura que no olvidarán jamás durante un viaje por carretera.",
                    Categoria="+13",
                    Actores="Tom Hanks, Annie Potts",
                    Director="Josh Cooley",
                    Duracion=100,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[3],
                    Imagen="estreno4.jpg",
                    Funciones=Funciones4},
                new Pelicula{
                    Titulo="Son como niños 2",
                    Argumento="El último día de escuela trae sorpresas y experiencias de aprendizaje inesperadas a un grupo de padres. ",
                    Categoria="+13",
                    Actores="Adam Sandler, David Spade, Salma Hayek",
                    Director="Dennis Dugan",
                    Duracion=101,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[4],
                    Imagen="estreno5.jpg",
                    Funciones=Funciones5},
                new Pelicula{
                    Titulo="Ouija: el origen del mal",
                    Argumento="En Los Ángeles de 1967, una madre viuda y sus dos hijas añaden un nuevo truco para reforzar su estafador negocio de espiritismo y sin darse cuenta invitan a un espíritu maligno en su casa. Cuando la hija menor es poseída por el implacable espíritu, esta pequeña familia deberá enfrentar a temores impensables para salvarla y enviar de regreso a la perversa entidad. ",
                    Categoria="+13",
                    Actores="Elizabeth Reaser, Lulu Wilson, Annalise Basso",
                    Director="Mike Flanagan",
                    Duracion=99,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[0],
                    Imagen="estreno6.jpg",
                    Funciones=Funciones6},
                new Pelicula{
                    Titulo="Tenet",
                    Argumento="Una acción épica que gira en torno al espionaje internacional, los viajes en el tiempo y la evolución, en la que un agente secreto debe prevenir la Tercera Guerra Mundial. ",
                    Categoria="+13",
                    Actores="Elizabeth Debicki, Robert Pattinson, John David Washington",
                    Director="Christopher Nolan",
                    Duracion=150,
                    FechaEstreno=DateTime.Parse("2013-6-27"),
                    Genero=generos[1],
                    Imagen="estreno7.jpg",
                    Funciones=Funciones7}
            };

            //Funciones.ForEach(f => context.Funciones.Add(f));
            Peliculas.ForEach(p => context.Peliculas.Add(p));
            context.SaveChanges();
        }
    }
}