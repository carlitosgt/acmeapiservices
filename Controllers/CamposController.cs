using APIsurveys.Modelos;
using APIsurveys.Modelos.Dto;
using APIsurveys.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamposController : ControllerBase
    {
        private readonly ICamposEncuestaRepositorio _repositorio;
        protected ResponseDto _response;

        public CamposController(ICamposEncuestaRepositorio repositorio)
        {
            _repositorio = repositorio;
            _response = new ResponseDto();
        }

        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CamposEncuesta>>> GetCamposEncuesta()
        {
            try
            {
                var lista = await _repositorio.Get();
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

        // PUT: api/encuesta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampoEncuesta(int id, CamposEncuestaDto encuestaDto)
        {
            try
            {
                CamposEncuestaDto model = await _repositorio.CreateUpdate(encuestaDto);
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

        // GET: api/encuesta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CamposEncuesta>> GetCampoEncuestaBy(int id)
        {
            var encuesta = await _repositorio.ById(id);
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

        // POST: api/Encuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<CamposEncuesta>> PostCampoEncuesta(CamposEncuestaDto encuestaDto)
        {
            try
            {
                CamposEncuestaDto model = await _repositorio.CreateUpdate(encuestaDto);
                _response.Result = model;
                return CreatedAtAction("GetCampoEncuestaBy", new { id = model.IdCampoEncuesta }, _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }


        }


    }
}
