using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentosService MedicamentosServicio;
        public MedicamentosController(IMedicamentosService MedicamentosService)
        {
            MedicamentosServicio = MedicamentosService;
        }
        // GET: api/<MedicamentosController>
        [HttpGet]
        public List<MedicamentosDto> Get()
        {
            List<Medicamentos> ListaTodosLosMedicamentos = MedicamentosServicio.SeleccionarTodos();

            List<MedicamentosDto> ListaTodosLosMedicamentosDto = new();

            foreach (var Medicamentosseleccionado in ListaTodosLosMedicamentos)
            {
                MedicamentosDto MedicamentosDTO = new();

                MedicamentosDTO.IdMedicamento = Medicamentosseleccionado.IdMedicamento;
                MedicamentosDTO.NombreMedicamento = Medicamentosseleccionado.NombreMedicamento;
                MedicamentosDTO.Precio = Medicamentosseleccionado.Precio;
                MedicamentosDTO.Activo = Medicamentosseleccionado.Activo;

                ListaTodosLosMedicamentosDto.Add(MedicamentosDTO);
            }

            return ListaTodosLosMedicamentosDto;
        }

        // GET api/<MedicamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Medicamentos Medicamentosseleccionado = new();

            Medicamentosseleccionado = MedicamentosServicio.SeleccionarPorId(id);

            if (Medicamentosseleccionado.IdMedicamento is null)
            {
                return NotFound("Doctor no encontrado");
            }

            MedicamentosDto MedicamentosDTO = new();

            MedicamentosDTO.IdMedicamento = Medicamentosseleccionado.IdMedicamento;
            MedicamentosDTO.NombreMedicamento = Medicamentosseleccionado.NombreMedicamento;
            MedicamentosDTO.Precio = Medicamentosseleccionado.Precio;
            MedicamentosDTO.Activo = Medicamentosseleccionado.Activo;

            return Ok(MedicamentosDTO);
        }

        // POST api/<MedicamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] MedicamentosDto MedicamentosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Medicamentos MedicamentosPorInsertar = new();

            MedicamentosPorInsertar.IdMedicamento = MedicamentosDTO.IdMedicamento;
            MedicamentosPorInsertar.NombreMedicamento = MedicamentosDTO.NombreMedicamento;
            MedicamentosPorInsertar.Precio = MedicamentosDTO.Precio;
            MedicamentosPorInsertar.Activo = MedicamentosDTO.Activo;

            MedicamentosPorInsertar.CreadoPor = "diazgs";

            MedicamentosServicio.Insertar(MedicamentosPorInsertar);

            return Ok();
        }

        // PUT api/<MedicamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] MedicamentosDto MedicamentosDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            Medicamentos Medicamentosseleccionado = new();

            Medicamentosseleccionado = MedicamentosServicio.SeleccionarPorId(id);

            if (Medicamentosseleccionado.IdMedicamento is null)
            {
                return NotFound("Medicamentos no encontrados");
            }

            Medicamentos MedicamentosPorActualizar = new();

            MedicamentosPorActualizar.IdMedicamento = MedicamentosDTO.IdMedicamento;
            MedicamentosPorActualizar.NombreMedicamento = MedicamentosDTO.NombreMedicamento;
            MedicamentosPorActualizar.Precio = MedicamentosDTO.Precio;
            MedicamentosPorActualizar.Activo = MedicamentosDTO.Activo;

            MedicamentosPorActualizar.FechaModificacion = System.DateTime.Now;
            MedicamentosPorActualizar.ModificadoPor = "diazgs";

            MedicamentosServicio.Actualizar(MedicamentosPorActualizar);

            return Ok();
        }

        // DELETE api/<MedicamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Medicamentos Medicamentosseleccionado = new();

            Medicamentosseleccionado = MedicamentosServicio.SeleccionarPorId(id);

            if (Medicamentosseleccionado.IdMedicamento is null)
            {
                return NotFound("Doctor no encontrado");
            }

            Medicamentosseleccionado.Activo = false; //Esto realiza el eliminado lógico

            MedicamentosServicio.Actualizar(Medicamentosseleccionado);

            return Ok("Registro eliminado");
        }

    }
}
