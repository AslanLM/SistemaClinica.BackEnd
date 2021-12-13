using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService DiagnosticoServicio;
        public DiagnosticoController(IDiagnosticoService DiagnosticoService)
        {
            DiagnosticoServicio = DiagnosticoService;
        }
        // GET: api/<DiagnosticoController>
        [HttpGet]
        public List<DiagnosticosDto> Get()
        {
            List<Diagnosticos> ListaTodosLosDiagnosticos = DiagnosticoServicio.SeleccionarTodos();

            List<DiagnosticosDto> ListaTodosLosDiagnosticosDto = new();

            foreach (var Diagnosticoseleccionada in ListaTodosLosDiagnosticos)
            {
                DiagnosticosDto DiagnosticosDTO = new();

                DiagnosticosDTO.IdDiagnostico = Diagnosticoseleccionada.IdDiagnostico;
                DiagnosticosDTO.Diagnostico = Diagnosticoseleccionada.Diagnostico;
                DiagnosticosDTO.Activo = Diagnosticoseleccionada.Activo;

                ListaTodosLosDiagnosticosDto.Add(DiagnosticosDTO);
            }

            return ListaTodosLosDiagnosticosDto;
        }

        // GET api/<DiagnosticoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Diagnosticos Diagnosticoseleccionada = new();

            Diagnosticoseleccionada = DiagnosticoServicio.SeleccionarPorId(id);

            if (Diagnosticoseleccionada.IdDiagnostico is 0)
            {
                return NotFound(" Diagnosticono encontrado");
            }

            DiagnosticosDto DiagnosticosDTO = new();

            DiagnosticosDTO.IdDiagnostico = Diagnosticoseleccionada.IdDiagnostico;
            DiagnosticosDTO.Diagnostico = Diagnosticoseleccionada.Diagnostico;
            DiagnosticosDTO.Activo = Diagnosticoseleccionada.Activo;

            return Ok(DiagnosticosDTO);
        }

        // POST api/<DiagnosticoController>
        [HttpPost]
        public IActionResult Post([FromBody] DiagnosticosDto DiagnosticosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Diagnosticos DiagnosticoPorInsertar = new();

            //DiagnosticoPorInsertar.IdDignostico = DianosticosDTO.IdDignostico;
            DiagnosticoPorInsertar.Diagnostico = DiagnosticosDTO.Diagnostico;

            DiagnosticoPorInsertar.CreadoPor = "diazgs";

            DiagnosticoServicio.Insertar(DiagnosticoPorInsertar);

            return Ok();
        }

        // PUT api/<DiagnosticoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DiagnosticosDto DiagnosticosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Diagnosticos Diagnosticoseleccionada = new();

            Diagnosticoseleccionada = DiagnosticoServicio.SeleccionarPorId(id);

            if (Diagnosticoseleccionada.IdDiagnostico is 0)
            {
                return NotFound("Diagnostico no encontrada");
            }

            Diagnosticos DiagnosticoPorActualizar = new();

            DiagnosticoPorActualizar.IdDiagnostico = DiagnosticosDTO.IdDiagnostico;
            DiagnosticoPorActualizar.Diagnostico = DiagnosticosDTO.Diagnostico;
            DiagnosticoPorActualizar.Activo = DiagnosticosDTO.Activo;

            DiagnosticoPorActualizar.FechaModificacion = System.DateTime.Now;
            DiagnosticoPorActualizar.ModificadoPor = "Yo mismo";

            DiagnosticoServicio.Actualizar(DiagnosticoPorActualizar);

            return Ok();
        }

        // DELETE api/< DiagnosticoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Diagnosticos Diagnosticoseleccionada = new();

            Diagnosticoseleccionada = DiagnosticoServicio.SeleccionarPorId(id);

            if (Diagnosticoseleccionada.IdDiagnostico is 0)
            {
                return NotFound(" Diagnostico no encontrada");
            }

            Diagnosticoseleccionada.Activo = false; //Esto realiza el eliminado lógico

            DiagnosticoServicio.Actualizar(Diagnosticoseleccionada);

            return Ok("Registro eliminado");
        }

    }
}
