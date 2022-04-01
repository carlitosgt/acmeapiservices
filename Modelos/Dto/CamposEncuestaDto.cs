using APIsurveys.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Modelos.Dto
{
    public class CamposEncuestaDto
    {
      
        public int IdCampoEncuesta { get; set; }
        public string NombreCampo { get; set; }

        public string TituloCampo { get; set; }

        public bool EsRequerido { get; set; }
        public string Respuesta { get; set; }
        public int tipoCampo { get; set; }

        public int? IdEncuesta { get; set; }
        //public Encuesta Encuesta { get; set; }
    }
}
