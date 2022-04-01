using APIsurveys.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Modelos
{
    public class CamposEncuesta
    {
        public enum TipoCampo
        {
            Texto,
            Numero,
            Fecha
        }
        [Key]
        public int IdCampoEncuesta { get; set; }
        [Required]
        public string NombreCampo { get; set; }
        [Required]
        public string TituloCampo { get; set; }
        [Required]
        public bool EsRequerido { get; set; }
        public string Respuesta { get; set; }
        [Required]
        public TipoCampo tipoCampo { get; set; }

        public int? IdEncuesta { get; set; }
        public Encuesta Encuesta { get; set; }
    }
}
