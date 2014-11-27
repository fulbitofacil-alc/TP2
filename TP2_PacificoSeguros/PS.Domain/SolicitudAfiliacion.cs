using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain
{
    public class SolicitudAfiliacion
    {
        [Key]
        public int Numero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Prestadora Prestadora { get; set; }
    }
}
