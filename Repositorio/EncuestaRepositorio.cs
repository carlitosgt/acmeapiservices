using API.Data;
using API.Modelos;
using API.Modelos.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repositorio
{
    public class EncuestaRepositorio : IEncuestaRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public EncuestaRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EncuestaDto> CreateUpdate(EncuestaDto encuestaDto)
        {
            Encuesta encuesta = _mapper.Map<EncuestaDto, Encuesta>(encuestaDto);
            if (encuesta.IdEncuesta > 0)
            {
                _db.Encuestas.Update(encuesta);
            }
            else
            {
                await _db.Encuestas.AddAsync(encuesta);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Encuesta, EncuestaDto>(encuesta);
        }

        public async Task<bool> DeleteEncuesta(int idEncuesta)
        {
            try
            {
                Encuesta encuesta = await _db.Encuestas.FindAsync(idEncuesta);
                if (encuesta == null)
                {
                    return false;
                }
                _db.Encuestas.Remove(encuesta);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<EncuestaDto> GetEncuestaById(int id)
        {
            Encuesta encuesta = await _db.Encuestas.FindAsync(id);

            return _mapper.Map<EncuestaDto>(encuesta);

        }

        public async Task<List<EncuestaDto>> GetEncuestas()
        {
            List<Encuesta> lista = await _db.Encuestas.ToListAsync();

            return _mapper.Map<List<EncuestaDto>>(lista);
        }

        public Task<EncuestaDto> GetEncuestasById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
