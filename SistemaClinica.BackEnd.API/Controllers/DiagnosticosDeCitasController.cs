using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosDeCitasController : ControllerBase
    {
        private readonly IDiagnosticosDeCitasService DiagnosticosDeCitasServicio;
        public DiagnosticosDeCitasController(IDiagnosticosDeCitasService DiagnosticosDeCitasService)
        {
            DiagnosticosDeCitasServicio = DiagnosticosDeCitasService;
        }
        // GET: api/<DiagnosticosDeCitasController>
        [HttpGet]
        public List<DiagnosticosDeCitasDto> Get()
        {
            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas = DiagnosticosDeCitasServicio.SeleccionarTodos();

            List<DiagnosticosDeCitasDto> ListaTodosLoDiagnosticosDeCitasDto = new();

            foreach (var DiagnosticosDeCitasseleccionado in ListaTodosLosDiagnosticosDeCitas)
            {
                DiagnosticosDeCitasDto DiagnosticosDeCitasDTO = new();

                DiagnosticosDeCitasDTO.IdDiagnostico = DiagnosticosDeCitasseleccionado.IdDiagnostico;
                DiagnosticosDeCitasDTO.IdCita = DiagnosticosDeCitasseleccionado.IdCita;
                DiagnosticosDeCitasDTO.Activo = DiagnosticosDeCitasseleccionado.Activo;

                ListaTodosLoDiagnosticosDeCitasDto.Add(DiagnosticosDeCitasDTO);
            }

            return ListaTodosLoDiagnosticosDeCitasDto;
        }

        // GET api/<DiagnosticosDeCitasController>/5
        [HttpGet("{IdCita}")]
        public List<DiagnosticosDeCitasDto> Get(int IdCita)
        {
            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas = DiagnosticosDeCitasServicio.SeleccionarTodosPorIdCita(IdCita);

            List<DiagnosticosDeCitasDto> ListaTodosLosDiagnosticosDeCitasDto = new();

            foreach (var DiagnosticosDeCitasseleccionado in ListaTodosLosDiagnosticosDeCitas)
            {
                DiagnosticosDeCitasDto DiagnosticosDeCitasDTO = new();

                DiagnosticosDeCitasDTO.IdDiagnostico = DiagnosticosDeCitasseleccionado.IdDiagnostico;
                DiagnosticosDeCitasDTO.IdCita = DiagnosticosDeCitasseleccionado.IdCita;
                DiagnosticosDeCitasDTO.Activo = DiagnosticosDeCitasseleccionado.Activo;

                ListaTodosLosDiagnosticosDeCitasDto.Add(DiagnosticosDeCitasDTO);
            }

            return ListaTodosLosDiagnosticosDeCitasDto;
        }

        // POST api/<DiagnosticosDeCitasController>
        [HttpPost]
        public IActionResult Post([FromBody] DiagnosticosDeCitasDto DiagnosticosDeCitasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            DiagnosticosDeCitas DiagnosticosDeCitasPorInsertar = new();

            DiagnosticosDeCitasPorInsertar.IdDiagnostico = DiagnosticosDeCitasDTO.IdDiagnostico;
            DiagnosticosDeCitasPorInsertar.IdCita = DiagnosticosDeCitasDTO.IdCita;

            DiagnosticosDeCitasPorInsertar.CreadoPor = "lackwoodsj";

            DiagnosticosDeCitasServicio.Insertar(DiagnosticosDeCitasPorInsertar);

            return Ok();
        }

        // DELETE api/<DiagnosticosDeCitaController>/5
        [HttpDelete("{IdDiagnostico}/{IdCita}")]
        public IActionResult Delete(int IdDiagnostico, int IdCita)
        {
            DiagnosticosDeCitas DiagnosticosDeCitasseleccionado = new();

            DiagnosticosDeCitasseleccionado = DiagnosticosDeCitasServicio.SeleccionarPorIdMultiple(IdDiagnostico, IdCita);

            if (DiagnosticosDeCitasseleccionado.IdDiagnostico is 0)
            {
                return NotFound("Paciente no encontrado");
            }

            DiagnosticosDeCitasseleccionado.Activo = false; //Esto realiza el eliminado lógico

            DiagnosticosDeCitasServicio.Actualizar(DiagnosticosDeCitasseleccionado);

            return Ok("Registro eliminado");
        }
    }
}
