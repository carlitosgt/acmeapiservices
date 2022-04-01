using APIsurveys.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Repositorio
{
    public interface IEncuestaRepositorio
    {
        Task<List<EncuestaDto>> GetEncuestas();

        Task<EncuestaDto> GetEncuestasById(int id);

        Task<EncuestaDto> CreateUpdate(EncuestaDto encuestaDto);

        Task<bool> DeleteEncuesta(int id);

    }
}
