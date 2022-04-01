using API.Modelos;
using API.Modelos.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ClienteDto, Cliente>();
                //config.CreateMap<Cliente, ClienteDto>();
                
            });

            return mappingConfig;
        }
    }
}
