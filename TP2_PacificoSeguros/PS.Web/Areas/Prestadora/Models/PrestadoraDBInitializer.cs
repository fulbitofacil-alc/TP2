using PS.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PS.Web.Areas.Prestadora.Models
{
    public class PrestadoraDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var tipos = new List<TipoPrestadora>
            {
                new TipoPrestadora() {Descripcion = "Salud"},
                new TipoPrestadora() {Descripcion = "Vehicular"}
            };

            tipos.ForEach(x => context.TiposPrestadora.Add(x));
            context.SaveChanges();

            var prestadoras = new List<PrestadoraViewModel>
            {
                new PrestadoraViewModel() {Nombre="Prestadora1", RUC="12345678901", Tipo = tipos[0], Direccion="Direccion 1",Representante="-",TelefonoContacto="-"},
                new PrestadoraViewModel() {Nombre="Prestadora2", RUC="12345678902", Tipo = tipos[0], Direccion="Direccion 2",Representante="-",TelefonoContacto="-"},
                new PrestadoraViewModel() {Nombre="Prestadora3", RUC="12345678903", Tipo = tipos[0], Direccion="Direccion 3",Representante="-",TelefonoContacto="-"},
                new PrestadoraViewModel() {Nombre="Prestadora4", RUC="12345678904", Tipo = tipos[1], Direccion="Direccion 4",Representante="-",TelefonoContacto="-"},
                new PrestadoraViewModel() {Nombre="Prestadora5", RUC="12345678905", Tipo = tipos[0], Direccion="Direccion 5",Representante="-",TelefonoContacto="-"},
                new PrestadoraViewModel() {Nombre="Prestadora6", RUC="12345678906", Tipo = tipos[0], Direccion="Direccion 6",Representante="-",TelefonoContacto="-"},
            };
            prestadoras.ForEach(x => context.Prestadoras.Add(x));
            context.SaveChanges();

            var invitaciones = new List<Invitacion>
            {
                new Invitacion() {FechaEnvio = DateTime.Today, Prestadora = prestadoras[0]},
                new Invitacion() {FechaEnvio = DateTime.Today, Prestadora = prestadoras[1]},
                new Invitacion() {FechaEnvio = DateTime.Today, Prestadora = prestadoras[5]},
            };
            invitaciones.ForEach(x => context.Invitaciones.Add(x));
            context.SaveChanges();

            //All standards will
            base.Seed(context);
        }
    }
}