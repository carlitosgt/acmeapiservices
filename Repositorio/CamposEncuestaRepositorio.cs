using APIsurveys.Data;
using APIsurveys.Modelos;
using APIsurveys.Modelos.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APIsurveys.Repositorio
{
    public class CamposEncuestaRepositorio : ICamposEncuestaRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CamposEncuestaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CamposEncuestaDto> CreateUpdate(CamposEncuestaDto encuestaDto)
        {

            CamposEncuesta encuesta = _mapper.Map<CamposEncuestaDto, CamposEncuesta>(encuestaDto);
            if (encuesta.IdEncuesta > 0)
            {
                _db.CamposEncuesta.Update(encuesta);
            }
            else
            {
                await _db.CamposEncuesta.AddAsync(encuesta);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<CamposEncuesta, CamposEncuestaDto>(encuesta);
        }

        public async Task<bool> Delete(int idEncuesta)
        {
            try
            {
                CamposEncuesta encuesta = await _db.CamposEncuesta.FindAsync(idEncuesta);
                if (encuesta == null)
                {
                    return false;
                }
                _db.CamposEncuesta.Remove(encuesta);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<CamposEncuestaDto> ById(int id)
        {
            CamposEncuesta encuesta = await _db.CamposEncuesta.FindAsync(id);

            return _mapper.Map<CamposEncuestaDto>(encuesta);

        }

        public async Task<List<CamposEncuestaDto>> Get()
        {
            List<CamposEncuesta> lista = await _db.CamposEncuesta.ToListAsync();

            return _mapper.Map<List<CamposEncuestaDto>>(lista);
        }

        public async Task<List<CamposEncuestaDto>> ByIdEncuesta(int id)
        {
            var result = await _db.CamposEncuesta.Where(m => m.IdEncuesta == id).ToListAsync();
            
            return _mapper.Map<List<CamposEncuestaDto>>(result);
        }


    }
}
