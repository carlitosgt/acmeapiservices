using APIsurveys.Modelos;
using APIsurveys.Modelos.Dto;
using AutoMapper;

namespace APIsurveys
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CamposEncuestaDto, CamposEncuesta>();
                config.CreateMap<CamposEncuesta, CamposEncuestaDto>();
                config.CreateMap<EncuestaDto, Encuesta>();
                config.CreateMap<Encuesta, EncuestaDto>();

            });

            return mappingConfig;
        }
    }
}
