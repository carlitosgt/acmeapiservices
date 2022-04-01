using APIsurveys.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Repositorio
{
    public interface ICamposEncuestaRepositorio
    {
        Task<List<CamposEncuestaDto>> Get();

        Task<CamposEncuestaDto> ById(int id);

        Task<CamposEncuestaDto> CreateUpdate(CamposEncuestaDto encuestaDto);

        Task<bool> Delete(int id);

    }
}
