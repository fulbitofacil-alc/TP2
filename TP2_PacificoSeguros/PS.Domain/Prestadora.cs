using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Domain
{
    public class Prestadora
    {
        [Key]
        public int Id { get; set; }
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TelefonoContacto { get; set; }
        public string Representante { get; set; }
        public virtual TipoPrestadora Tipo { get; set; }
    }
}
