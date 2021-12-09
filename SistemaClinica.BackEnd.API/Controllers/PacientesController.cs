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
        private readonly IPacientesService Pacientes; 
        public PacientesController(IPacientesService PacientesService)
        {
            Pacientes = PacientesService;
        }
        // GET: api/<PacientesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PacientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Pacientes Pacientesseleccionado = new();

            Pacientesseleccionado = Pacientes.SeleccionarPorId(id);

            if (Pacientesseleccionado.CedulaPaciente is null)
            {
                return NotFound("Doctor no encontrado");
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

            Pacientes.Insertar(PacientePorInsertar);

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

            Pacienteseleccionado = Pacientes.SeleccionarPorId(id);

            if (Pacienteseleccionado.CedulaPaciente is null)
            {
                return NotFound("Paciente no encontrada");
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

            Pacientes.Actualizar(PacientePorActualizar);

            return Ok();
        }

        // DELETE api/<PacientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
