using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Modelos.Dto
{
    public class EncuestaDto
    {
       
        public int IdEncuesta { get; set; }
      
        public string NombreEncuesta { get; set; }
   
        public string Descripcion { get; set; }
       
        public string? LinkEncuesta { get; set; }
      
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public int IdUser { get; set; }
      
    }
}
