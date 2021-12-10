using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesService PacientesServicio;  
        public PacientesController(IPacientesService PacientesService)
        {
            PacientesServicio = PacientesService;
        }
        // GET: api/<PacientesController>
        [HttpGet]
        public List<PacientesDto> Get()
        {
            List<Pacientes> ListaTodosLosPacientes = PacientesServicio.SeleccionarTodos();

            List<PacientesDto> ListaTodosLosPacientesDto = new();

            foreach (var Pacientesseleccionado in ListaTodosLosPacientes)
            {
                PacientesDto PacientesDTO = new();

                PacientesDTO.CedulaPaciente = Pacientesseleccionado.CedulaPaciente;
                PacientesDTO.NombrePaciente = Pacientesseleccionado.NombrePaciente;
                PacientesDTO.Apellidos = Pacientesseleccionado.Apellidos;
                PacientesDTO.Telefono = Pacientesseleccionado.Telefono;
                PacientesDTO.Edad = Pacientesseleccionado.Edad;
                PacientesDTO.Activo = Pacientesseleccionado.Activo;

                ListaTodosLosPacientesDto.Add(PacientesDTO);
            }

            return ListaTodosLosPacientesDto;
        }

        // GET api/<PacientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Pacientes Pacientesseleccionado = new();

            Pacientesseleccionado = PacientesServicio.SeleccionarPorId(id);

            if (Pacientesseleccionado.CedulaPaciente is null)
            {
                return NotFound("Paciente no encontrado");
            }

            PacientesDto PacientesDTO = new();

            PacientesDTO.CedulaPaciente = Pacientesseleccionado.CedulaPaciente;
            PacientesDTO.NombrePaciente = Pacientesseleccionado.NombrePaciente;
            PacientesDTO.Apellidos = Pacientesseleccionado.Apellidos;
            PacientesDTO.Telefono = Pacientesseleccionado.Telefono;
            PacientesDTO.Edad = Pacientesseleccionado.Edad;
            PacientesDTO.Activo = Pacientesseleccionado.Activo;

            return Ok(PacientesDTO);
        }

        // POST api/<PacientesController>
        [HttpPost]
        public IActionResult Post([FromBody] PacientesDto PacientesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Pacientes PacientePorInsertar = new();

            PacientePorInsertar.CedulaPaciente = PacientesDTO.CedulaPaciente;
            PacientePorInsertar.NombrePaciente = PacientesDTO.NombrePaciente;
            PacientePorInsertar.Apellidos = PacientesDTO.Apellidos;
            PacientePorInsertar.Telefono = PacientesDTO.Telefono;
            PacientePorInsertar.Edad = PacientesDTO.Edad;

            PacientePorInsertar.CreadoPor = "lackwoodsj";

            PacientesServicio.Insertar(PacientePorInsertar);

            return Ok();
        }

        // PUT api/<PacientesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PacientesDto PacientesDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Pacientes Pacienteseleccionado = new();

            Pacienteseleccionado = PacientesServicio.SeleccionarPorId(id);

            if (Pacienteseleccionado.CedulaPaciente is null)
            {
                return NotFound("Paciente no encontrado");
            }

            Pacientes PacientePorActualizar = new();

            PacientePorActualizar.CedulaPaciente = PacientesDTO.CedulaPaciente;
            PacientePorActualizar.NombrePaciente = PacientesDTO.NombrePaciente;
            PacientePorActualizar.Apellidos = PacientesDTO.Apellidos;
            PacientePorActualizar.Telefono = PacientesDTO.Telefono;
            PacientePorActualizar.Edad = PacientesDTO.Edad;
            PacientePorActualizar.Activo = PacientesDTO.Activo;

            PacientePorActualizar.FechaModificacion = System.DateTime.Now;
            PacientePorActualizar.ModificadoPor = "Lackwoodsj";

            PacientesServicio.Actualizar(PacientePorActualizar);

            return Ok();
        }

        // DELETE api/<PacientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Pacientes Pacientesseleccionado = new();

            Pacientesseleccionado = PacientesServicio.SeleccionarPorId(id);

            if (Pacientesseleccionado.CedulaPaciente is null)
            {
                return NotFound("Paciente no encontrado");
            }

            Pacientesseleccionado.Activo = false; //Esto realiza el eliminado lógico

            PacientesServicio.Actualizar(Pacientesseleccionado);

            return Ok("Registro eliminado");
        }
    }
}
