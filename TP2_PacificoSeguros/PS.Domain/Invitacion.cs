using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain
{
    public class Invitacion
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaEnvio { get; set; }
        public virtual Prestadora Prestadora { get; set; }
    }
}
