using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PS.Domain;

namespace PS.DAL
{
    public class PrestadorasContext : DbContext
    {
        public PrestadorasContext() : base("name=PrestadorasContext")
        {

        }

        public DbSet<Prestadora> Prestadoras { get; set; }
        public DbSet<TipoPrestadora> TiposPrestadora { get; set; }
        public DbSet<SolicitudAfiliacion> SolicitudesAfiliacion { get; set; }
        public DbSet<Invitacion> Invitaciones { get; set; }
    }
}
