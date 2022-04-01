using API.Modelos;
using API.Modelos.Dto;
using API.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class EncuestaController : ControllerBase
        {
            private readonly IEncuestaRepositorio _encuestaRepositorio;
            protected ResponseDto _response;

            public EncuestaController(IEncuestaRepositorio encuestaRepositorio)
            {
                _encuestaRepositorio = encuestaRepositorio;
                _response = new ResponseDto();
            }

            // GET: api/Encuestas
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Encuesta>>> GetEncuestas()
            {
                try
                {
                    var lista = await _encuestaRepositorio.GetEncuestas();
                    _response.Result = lista;
                    _response.DisplayMessage = "Lista de Encuestas";
                }
                catch (Exception ex)
                {

                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { ex.ToString() };
                }

                return Ok(_response);
            }

            // GET: api/encuesta/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Encuesta>> GetEncuesta(int id)
            {
                var encuesta = await _encuestaRepositorio.GetEncuestasById(id);
                if (encuesta == null)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Encuesta No Existe";
                    return NotFound(_response);
                }
                _response.Result = encuesta;
                _response.DisplayMessage = "Informacion de la encuesta";
                return Ok(_response);
            }

            // PUT: api/encuesta/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutEncuesta(int id, EncuestaDto encuestaDto)
            {
                try
                {
                    EncuestaDto model = await _encuestaRepositorio.CreateUpdate(encuestaDto);
                    _response.Result = model;
                    return Ok(_response);
                }
                catch (Exception ex)
                {

                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Actualizar el Registro";
                    _response.ErrorMessages = new List<string> { ex.ToString() };
                    return BadRequest(_response);
                }
            }

            // POST: api/Encuestas
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Encuesta>> PostEncuesta(EncuestaDto encuestaDto)
            {
                try
                {
                    EncuestaDto model = await _encuestaRepositorio.CreateUpdate(encuestaDto);
                    _response.Result = model;
                    return CreatedAtAction("GetEncuesta", new { id = model.IdEncuesta }, _response);
                }
                catch (Exception ex)
                {

                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Grabar el Registro";
                    _response.ErrorMessages = new List<string> { ex.ToString() };
                    return BadRequest(_response);
                }


            }

            // DELETE: api/encuesta/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteEncuesta(int id)
            {
                try
                {
                    bool estaEliminado = await _encuestaRepositorio.DeleteEncuesta(id);
                    if (estaEliminado)
                    {
                        _response.Result = estaEliminado;
                        _response.DisplayMessage = "Encuesta Eliminado con Exito";
                        return Ok(_response);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.DisplayMessage = "Error al Eliminar Encuesta";
                        return BadRequest(_response);
                    }
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { ex.ToString() };
                    return BadRequest(_response);
                }
            }
            }
        
}
