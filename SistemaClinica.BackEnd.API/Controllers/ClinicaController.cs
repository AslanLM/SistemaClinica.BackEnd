using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;


namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
         private readonly IClinicaService ClinicaServicio;
        public ClinicaController(IClinicaService ClinicaService)
        {
            ClinicaServicio = ClinicaService;
        }
        // GET: api/<ClinicaController>
        [HttpGet]
        public List<ClinicasDto> Get()
        {
            List<Clinicas> ListaTodasLasClinicas = ClinicaServicio.SeleccionarTodos();

            List<ClinicasDto> ListaTodasLasClinicasDto = new();

            foreach (var Clinicaseleccionada in ListaTodasLasClinicas)
            {
                ClinicasDto ClinicasDTO = new();

                ClinicasDTO.IdClinica = Clinicaseleccionada.IdClinica;
                ClinicasDTO.NombreClinica = Clinicaseleccionada.NombreClinica;
                ClinicasDTO.CedulaJuridica = Clinicaseleccionada.CedulaJuridica;
                ClinicasDTO.Activo = Clinicaseleccionada.Activo;

                ListaTodasLasClinicasDto.Add(ClinicasDTO);
            }

            return ListaTodasLasClinicasDto;
        }

        // GET api/<ClinicaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Clinicas Clinicaseleccionada = new();

            Clinicaseleccionada = ClinicaServicio.SeleccionarPorId(id);

            if (Clinicaseleccionada.IdClinica is 0)
            {
                return NotFound("Clinica no encontrado");
            }

            ClinicasDto ClinicasDTO = new();

            ClinicasDTO.IdClinica = Clinicaseleccionada.IdClinica;
            ClinicasDTO.NombreClinica = Clinicaseleccionada.NombreClinica;
            ClinicasDTO.CedulaJuridica = Clinicaseleccionada.CedulaJuridica;
            ClinicasDTO.Activo = Clinicaseleccionada.Activo;

            return Ok(ClinicasDTO);
        }

        // POST api/<ClinicaController>
        [HttpPost]
        public IActionResult Post([FromBody] ClinicasDto ClinicasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Clinicas ClinicaPorInsertar = new();

            ClinicaPorInsertar.IdClinica = ClinicasDTO.IdClinica;
            ClinicaPorInsertar.NombreClinica = ClinicasDTO.NombreClinica;
            ClinicaPorInsertar.CedulaJuridica = ClinicasDTO.CedulaJuridica;

            ClinicaPorInsertar.CreadoPor = "diazgs";

            ClinicaServicio.Insertar(ClinicaPorInsertar);

            return Ok();
        }

        // PUT api/<ClinicaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClinicasDto ClinicasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Clinicas Clinicaseleccionada = new();

            Clinicaseleccionada = ClinicaServicio.SeleccionarPorId(id);

            if (Clinicaseleccionada.IdClinica is 0)
            {
                return NotFound("Clinica no encontrada");
            }

            Clinicas ClinicaPorActualizar = new();

            ClinicaPorActualizar.IdClinica = ClinicasDTO.IdClinica;
            ClinicaPorActualizar.NombreClinica = ClinicasDTO.NombreClinica;
            ClinicaPorActualizar.CedulaJuridica = ClinicasDTO.CedulaJuridica;
            ClinicaPorActualizar.Activo = ClinicasDTO.Activo;

            ClinicaPorActualizar.FechaModificacion = System.DateTime.Now;
            ClinicaPorActualizar.ModificadoPor = "Yo mismo";

            ClinicaServicio.Actualizar(ClinicaPorActualizar);

            return Ok();
        }

        // DELETE api/<ClinicaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Clinicas Clinicaseleccionada = new();

            Clinicaseleccionada = ClinicaServicio.SeleccionarPorId(id);

            if (Clinicaseleccionada.IdClinica is 0)
            {
                return NotFound("Clinica no encontrada");
            }

            Clinicaseleccionada.Activo = false; //Esto realiza el eliminado lógico

            ClinicaServicio.Actualizar(Clinicaseleccionada);

            return Ok("Registro eliminado");
        }

    }
}
