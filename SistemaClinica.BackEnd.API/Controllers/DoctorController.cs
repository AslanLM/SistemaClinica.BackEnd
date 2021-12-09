using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private readonly IDoctorService Doctor;
        public DoctoresController(IDoctorService DoctoresService)
        {
            Doctor = DoctoresService;
        }
        // GET: api/<DoctoresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DoctoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Doctores Doctorseleccionado = new();

            Doctorseleccionado = Doctor.SeleccionarPorId(id);

            if (Doctorseleccionado.CedulaDoctor is null)
            {
                return NotFound("Doctor no encontrado");
            }

            DoctoresDto DoctoresDTO = new();

            DoctoresDTO.CedulaDoctor = Doctorseleccionado.CedulaDoctor;
            DoctoresDTO.NombreDoctor = Doctorseleccionado.NombreDoctor;
            DoctoresDTO.Apellido = Doctorseleccionado.Apellido;
            DoctoresDTO.Telefono = Doctorseleccionado.Telefono;
            DoctoresDTO.Activo = Doctorseleccionado.Activo;

            return Ok(DoctoresDTO);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromBody] DoctoresDto DoctoresDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Doctores DoctorPorInsertar = new();

            DoctorPorInsertar.CedulaDoctor = DoctoresDTO.CedulaDoctor;
            DoctorPorInsertar.NombreDoctor = DoctoresDTO.NombreDoctor;
            DoctorPorInsertar.Apellido = DoctoresDTO.Apellido;
            DoctorPorInsertar.Telefono = DoctoresDTO.Telefono;

            DoctorPorInsertar.CreadoPor = "diazgs";

            Doctor.Insertar(DoctorPorInsertar);

            return Ok();
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] DoctoresDto DoctoresDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Doctores Doctorseleccionado = new();

            Doctorseleccionado = Doctor.SeleccionarPorId(id);

            if (Doctorseleccionado.CedulaDoctor is null)
            {
                return NotFound("Aula no encontrada");
            }

            Doctores DoctorPorActualizar = new();

            DoctorPorActualizar.CedulaDoctor = DoctoresDTO.CedulaDoctor;
            DoctorPorActualizar.NombreDoctor = DoctoresDTO.NombreDoctor;
            DoctorPorActualizar.Apellido = DoctoresDTO.Apellido;
            DoctorPorActualizar.Telefono = DoctoresDTO.Telefono;
            DoctorPorActualizar.Activo = DoctoresDTO.Activo;

            DoctorPorActualizar.FechaModificacion = System.DateTime.Now;
            DoctorPorActualizar.ModificadoPor = "diazgs";

            Doctor.Actualizar(DoctorPorActualizar);

            return Ok();
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
