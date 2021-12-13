using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService CitaServicio;
        public CitasController(ICitaService CitaService)
        {
            CitaServicio = CitaService;
        }
        // GET: api/<CitaController>
        [HttpGet]
        public List<CitasDto> Get()
        {
            List<Citas> ListaTodasLasCitas = CitaServicio.SeleccionarTodos();

            List<CitasDto> ListaTodasLasCitasDto = new();

            foreach (var Citaseleccionada in ListaTodasLasCitas)
            {
                CitasDto CitasDTO = new();

                CitasDTO.IdCita = Citaseleccionada.IdCita;
                CitasDTO.FechaYHoraInicioCita = Citaseleccionada.FechaYHoraInicioCita;
                CitasDTO.FechaYHoraFinCita = Citaseleccionada.FechaYHoraFinCita;
                CitasDTO.CedulaDoctor = Citaseleccionada.CedulaDoctor;
                CitasDTO.CedulaPaciente = Citaseleccionada.CedulaPaciente;
                CitasDTO.IdConsultorio = Citaseleccionada.IdConsultorio;
                CitasDTO.IdDiagnostico = Citaseleccionada.IdDiagnostico;
                CitasDTO.MontoDeConsulta = Citaseleccionada.MontoDeConsulta;
                CitasDTO.MontoDeMedicamentos = Citaseleccionada.MontoDeMedicamentos;
                CitasDTO.MontoTotal = Citaseleccionada.MontoTotal;
                CitasDTO.Activo = Citaseleccionada.Activo;
                

                ListaTodasLasCitasDto.Add(CitasDTO);
            }

            return ListaTodasLasCitasDto;
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Citas Citaseleccionada = new();

            Citaseleccionada = CitaServicio.SeleccionarPorId(id);

            if (Citaseleccionada.IdCita is 0)
            {
                return NotFound("Cita no encontrada");
            }

            CitasDto CitasDTO = new();

            CitasDTO.IdCita = Citaseleccionada.IdCita;
            CitasDTO.FechaYHoraInicioCita = Citaseleccionada.FechaYHoraInicioCita;
            CitasDTO.FechaYHoraFinCita = Citaseleccionada.FechaYHoraFinCita;
            CitasDTO.CedulaDoctor = Citaseleccionada.CedulaDoctor;
            CitasDTO.CedulaPaciente = Citaseleccionada.CedulaPaciente;
            CitasDTO.IdConsultorio = Citaseleccionada.IdConsultorio;
            CitasDTO.IdDiagnostico = Citaseleccionada.IdDiagnostico;
            CitasDTO.MontoDeConsulta = Citaseleccionada.MontoDeConsulta;
            CitasDTO.MontoDeMedicamentos = Citaseleccionada.MontoDeMedicamentos;
            CitasDTO.MontoTotal = Citaseleccionada.MontoTotal;
            CitasDTO.Activo = Citaseleccionada.Activo;

            return Ok(CitasDTO);
        }

        // POST api/<CitaController>
        [HttpPost]
        public IActionResult Post([FromBody] CitasDto CitasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Citas CitaPorInsertar = new();

            //CitaPorInsertar.IdCita = CitasDTO.IdCita;
            CitaPorInsertar.FechaYHoraInicioCita = CitasDTO.FechaYHoraInicioCita;
            CitaPorInsertar.FechaYHoraFinCita = CitasDTO.FechaYHoraFinCita;
            CitaPorInsertar.CedulaDoctor = CitasDTO.CedulaDoctor;
            CitaPorInsertar.CedulaPaciente = CitasDTO.CedulaPaciente;
            CitaPorInsertar.IdConsultorio = CitasDTO.IdConsultorio;
            CitaPorInsertar.IdDiagnostico = CitasDTO.IdDiagnostico;
            CitaPorInsertar.MontoDeConsulta = CitasDTO.MontoDeConsulta;
            //CitaPorInsertar.MontoDeMedicamentos = CitasDTO.MontoDeMedicamentos;
            //CitaPorInsertar.MontoTotal = CitasDTO.MontoTotal;

            CitaPorInsertar.CreadoPor = "diazgs";

            CitaServicio.Insertar(CitaPorInsertar);

            return Ok();
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CitasDto CitasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Citas Citaseleccionada = new();

            Citaseleccionada = CitaServicio.SeleccionarPorId(id);

            if (Citaseleccionada.IdCita is 0)
            {
                return NotFound("Citaa no encontrada");
            }

            Citas CitaPorActualizar = new();

            CitaPorActualizar.IdCita = CitasDTO.IdCita;
            CitaPorActualizar.FechaYHoraInicioCita = CitasDTO.FechaYHoraInicioCita;
            CitaPorActualizar.FechaYHoraFinCita = CitasDTO.FechaYHoraFinCita;
            CitaPorActualizar.CedulaDoctor = CitasDTO.CedulaDoctor;
            CitaPorActualizar.CedulaPaciente = CitasDTO.CedulaPaciente;
            CitaPorActualizar.IdConsultorio = CitasDTO.IdConsultorio;
            CitaPorActualizar.MontoDeConsulta = CitasDTO.MontoDeConsulta;
            CitaPorActualizar.MontoDeMedicamentos = CitasDTO.MontoDeMedicamentos;
            CitaPorActualizar.MontoTotal = CitasDTO.MontoTotal;

            CitaPorActualizar.FechaModificacion = System.DateTime.Now;
            CitaPorActualizar.ModificadoPor = "Yo mismo";

            CitaServicio.Actualizar(CitaPorActualizar);

            return Ok();
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Citas Citaseleccionada = new();

            Citaseleccionada = CitaServicio.SeleccionarPorId(id);

            if (Citaseleccionada.IdCita is 0)
            {
                return NotFound("Cita no encontrada");
            }

            Citaseleccionada.Activo = false; //Esto realiza el eliminado lógico

            CitaServicio.Actualizar(Citaseleccionada);

            return Ok("Registro eliminado");
        }
    }
}
