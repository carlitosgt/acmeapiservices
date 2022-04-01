using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelos
{
    public class Encuesta
    {
        [Key]
        public int IdEncuesta { get; set; }
        [Required]
        public string NombreEncuesta { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string LinkEncuesta { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int IdUser { get; set; }
        public User User { get; set; }

    }
}
