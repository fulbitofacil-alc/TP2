using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PS.Web.Areas.Prestadora.Models
{
    [Table("Prestadora")]
    public class PrestadoraViewModel
    {
        public int Id { get; set; }
        [Required]
        public string RUC { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string TelefonoContacto { get; set; }
        [Required]
        public string Representante { get; set; }
        [Required(ErrorMessage="El tipo de prestadora es obligatario")]
        public virtual TipoPrestadora Tipo { get; set; }

        [NotMapped]
        public string Observaciones { get; set; }
    }

    [Table("TipoPrestadora")]
    public class TipoPrestadora
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El tipo de prestadora es obligatario")]
        public string Descripcion { get; set; }
    }

    [Table("Invitacion")]
    public class Invitacion
    {
        public int Id { get; set; }
        public DateTime FechaEnvio { get; set; }
        public virtual PrestadoraViewModel Prestadora { get; set; }
    }

    [Table("SolicitudAfiliacion")]
    public class SolicitudAfiliacion
    {
        public  int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public virtual PrestadoraViewModel Prestadora { get; set; }
        public string Observaciones { get; set; }
    }
}