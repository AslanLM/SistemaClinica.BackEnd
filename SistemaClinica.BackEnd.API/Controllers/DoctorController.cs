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
        private readonly IDoctorService DoctorServicio;
        public DoctoresController(IDoctorService DoctoresService)
        {
            DoctorServicio = DoctoresService;
        }
        // GET: api/<DoctoresController>
        [HttpGet]
       public List<DoctoresDto> Get()
        {
            List<Doctores> ListaTodosLosDoctores = DoctorServicio.SeleccionarTodos();

            List<DoctoresDto> ListaTodosLosDoctoresDto = new();

            foreach (var Doctorseleccionado in ListaTodosLosDoctores)
            {
                DoctoresDto DoctoresDTO = new();

                DoctoresDTO.CedulaDoctor = Doctorseleccionado.CedulaDoctor;
                DoctoresDTO.NombreDoctor = Doctorseleccionado.NombreDoctor;
                DoctoresDTO.Apellidos = Doctorseleccionado.Apellidos;
                DoctoresDTO.Telefono = Doctorseleccionado.Telefono;
                DoctoresDTO.Activo = Doctorseleccionado.Activo;

                ListaTodosLosDoctoresDto.Add(DoctoresDTO);
            }

            return ListaTodosLosDoctoresDto;
        }

        // GET api/<DoctoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Doctores Doctorseleccionado = new();

            Doctorseleccionado = DoctorServicio.SeleccionarPorId(id);

            if (Doctorseleccionado.CedulaDoctor is null)
            {
                return NotFound("Doctor no encontrado");
            }

            DoctoresDto DoctoresDTO = new();

            DoctoresDTO.CedulaDoctor = Doctorseleccionado.CedulaDoctor;
            DoctoresDTO.NombreDoctor = Doctorseleccionado.NombreDoctor;
            DoctoresDTO.Apellidos = Doctorseleccionado.Apellidos;
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
            DoctorPorInsertar.Apellidos = DoctoresDTO.Apellidos;
            DoctorPorInsertar.Telefono = DoctoresDTO.Telefono;

            DoctorPorInsertar.CreadoPor = "diazgs";

            DoctorServicio.Insertar(DoctorPorInsertar);

            return Ok();
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] DoctoresDto DoctoresDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Doctores Doctorseleccionado = new();

            Doctorseleccionado = DoctorServicio.SeleccionarPorId(id);

            if (Doctorseleccionado.CedulaDoctor is null)
            {
                return NotFound("Doctor no encontrado");
            }

            Doctores DoctorPorActualizar = new();
            DoctorPorActualizar.CedulaDoctor = DoctoresDTO.CedulaDoctor;
            DoctorPorActualizar.NombreDoctor = DoctoresDTO.NombreDoctor;
            DoctorPorActualizar.Apellidos = DoctoresDTO.Apellidos;
            DoctorPorActualizar.Telefono = DoctoresDTO.Telefono;
            DoctorPorActualizar.Activo = DoctoresDTO.Activo;

            DoctorPorActualizar.FechaModificacion = System.DateTime.Now;
            DoctorPorActualizar.ModificadoPor = "diazgs";

            DoctorServicio.Actualizar(DoctorPorActualizar);

            return Ok();
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Doctores Doctorseleccionado = new();

            Doctorseleccionado = DoctorServicio.SeleccionarPorId(id);

            if (Doctorseleccionado.CedulaDoctor is null)
            {
                return NotFound("Doctor no encontrado");
            }

            Doctorseleccionado.Activo = false; //Esto realiza el eliminado lógico

            DoctorServicio.Actualizar(Doctorseleccionado);

            return Ok("Registro eliminado");
        }

    }
}
