using APIsurveys.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Modelos
{
    public class Encuesta
    {
        [Key]
        public int IdEncuesta { get; set; }
        [Required]
        public string NombreEncuesta { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string? LinkEncuesta { get; set; }
        public DateTime? FechaCreacion { get; set; }
        [Required]
        // Modificación: conexión con Usuario
        public int IdUser { get; set; }
        public User User { get; set; }


    }
}
