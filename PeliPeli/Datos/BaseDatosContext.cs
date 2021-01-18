using PeliPeli.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PeliPeli.Datos
{
    public class BaseDatosContext:DbContext
    {
            private static readonly BaseDatosContext instanciaBD = new BaseDatosContext();
            public BaseDatosContext() : base()
            {
            }

            public DbSet<Pelicula> Peliculas { get; set; }
            public DbSet<Funcion> Funciones { get; set; }
            public DbSet<Reserva> Reservas { get; set; }
            public DbSet<Asiento> Asientos { get; set; }
            public DbSet<Genero> Generos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
            public static BaseDatosContext InstanciaBD
            {
                get
                {
                    return instanciaBD;
                }
            }

    }
    
}