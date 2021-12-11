using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultorioController : ControllerBase
    {
        private readonly IConsultorioService ConsultorioServicio;
        public ConsultorioController(IConsultorioService ConsultorioService)
        {
            ConsultorioServicio = ConsultorioService;
        }
        // GET: api/<ConsultorioController>
        [HttpGet]
        public List<ConsultoriosDto> Get()
        {
            List<Consultorios> ListaTodosLosConsultorios = ConsultorioServicio.SeleccionarTodos();

            List<ConsultoriosDto> ListaTodosLosConsultoriosDto = new();

            foreach (var Consultorioseleccionado in ListaTodosLosConsultorios)
            {
                ConsultoriosDto ConsultoriosDTO = new();

                ConsultoriosDTO.IdConsultorio = Consultorioseleccionado.IdConsultorio;
                ConsultoriosDTO.NombreConsultorio = Consultorioseleccionado.NombreConsultorio;
                ConsultoriosDTO.IdClinica = Consultorioseleccionado.IdClinica;
                ConsultoriosDTO.Activo = Consultorioseleccionado.Activo;

                ListaTodosLosConsultoriosDto.Add(ConsultoriosDTO);
            }

            return ListaTodosLosConsultoriosDto;
        }

        // GET api/<ConsultorioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Consultorios Consultorioseleccionado = new();

            Consultorioseleccionado = ConsultorioServicio.SeleccionarPorId(id);

            if (Consultorioseleccionado.IdConsultorio is null)
            {
                return NotFound("Consultorio no encontrado");
            }

            ConsultoriosDto ConsultoriosDTO = new();

            ConsultoriosDTO.IdConsultorio = Consultorioseleccionado.IdConsultorio;
            ConsultoriosDTO.NombreConsultorio = Consultorioseleccionado.NombreConsultorio;
            ConsultoriosDTO.IdClinica = Consultorioseleccionado.IdClinica;
            ConsultoriosDTO.Activo = Consultorioseleccionado.Activo;

            return Ok(ConsultoriosDTO);
        }

        // POST api/<ConsultorioController>
        [HttpPost]
        public IActionResult Post([FromBody] ConsultoriosDto ConsultoriosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Consultorios ConsultorioPorInsertar = new();

            ConsultorioPorInsertar.IdConsultorio = ConsultoriosDTO.IdConsultorio;
            ConsultorioPorInsertar.NombreConsultorio = ConsultoriosDTO.NombreConsultorio;
            ConsultorioPorInsertar.IdClinica = ConsultoriosDTO.IdClinica;
            

            ConsultorioPorInsertar.CreadoPor = "diazgs";

            ConsultorioServicio.Insertar(ConsultorioPorInsertar);

            return Ok();
        }

        // PUT api/<ConsultorioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ConsultoriosDto ConsultoriosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Consultorios Consultorioseleccionado = new();

            Consultorioseleccionado = ConsultorioServicio.SeleccionarPorId(id);

            if (Consultorioseleccionado.IdConsultorio is null)
            {
                return NotFound("Consultorio no encontrado");
            }

            Consultorios ConsultorioPorActualizar = new();
            ConsultorioPorActualizar.IdConsultorio = ConsultoriosDTO.IdConsultorio;
            ConsultorioPorActualizar.NombreConsultorio = ConsultoriosDTO.NombreConsultorio;
            ConsultorioPorActualizar.IdClinica = ConsultoriosDTO.IdClinica;
            ConsultorioPorActualizar.Activo = ConsultoriosDTO.Activo;

            ConsultorioPorActualizar.FechaModificacion = System.DateTime.Now;
            ConsultorioPorActualizar.ModificadoPor = "diazgs";

            ConsultorioServicio.Actualizar(ConsultorioPorActualizar);

            return Ok();
        }

        // DELETE api/ConsultorioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Consultorios Consultorioseleccionado = new();

            Consultorioseleccionado = ConsultorioServicio.SeleccionarPorId(id);

            if (Consultorioseleccionado.IdConsultorio is null)
            {
                return NotFound("Consultorio no encontrado");
            }

            Consultorioseleccionado.Activo = false; //Esto realiza el eliminado lógico

            ConsultorioServicio.Actualizar(Consultorioseleccionado);

            return Ok("Registro eliminado");
        }

    }
}
