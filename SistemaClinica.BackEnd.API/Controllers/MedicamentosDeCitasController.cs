using Microsoft.AspNetCore.Mvc;
using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Dtos;
using SistemaClinica.BackEnd.API.Services.Interfaces;
using System.Collections.Generic;
    
namespace SistemaClinica.BackEnd.API.Controllers  
{
    [Route("api/[controller]")] 
    [ApiController]
    public class MedicamentosDeCitasController : ControllerBase 
    {
        private readonly IMedicamentosDeCitasService MedicamentosDeCitasServicio;
        public MedicamentosDeCitasController(IMedicamentosDeCitasService MedicamentosDeCitasService)
        {
            MedicamentosDeCitasServicio = MedicamentosDeCitasService;
        }
        // GET: api/<MedicamentosDeCitasController>
        [HttpGet]
        public List<MedicamentosDeCitasDto> Get()
        {
            List<MedicamentosDeCitas> ListaTodosLosMedicamentosDeCitas = MedicamentosDeCitasServicio.SeleccionarTodos();

            List<MedicamentosDeCitasDto> ListaTodosLosMedicamentosDeCitasDto = new();

            foreach (var MedicamentosDeCitasseleccionado in ListaTodosLosMedicamentosDeCitas)
            {
                MedicamentosDeCitasDto MedicamentosDeCitasDTO = new();

                MedicamentosDeCitasDTO.IdMedicamento = MedicamentosDeCitasseleccionado.IdMedicamento;
                MedicamentosDeCitasDTO.IdCita = MedicamentosDeCitasseleccionado.IdCita;
                MedicamentosDeCitasDTO.PrecioMedicamento = MedicamentosDeCitasseleccionado.PrecioMedicamento;
                MedicamentosDeCitasDTO.Activo = MedicamentosDeCitasseleccionado.Activo;

                ListaTodosLosMedicamentosDeCitasDto.Add(MedicamentosDeCitasDTO);
            }

            return ListaTodosLosMedicamentosDeCitasDto;
        }

        // GET api/<MedicamentosDeCitasController>/5
        [HttpGet("{IdCita}")]
        public List<MedicamentosDeCitasDto> Get(int IdCita)
        {
            List<MedicamentosDeCitas> ListaTodosLosMedicamentosDeCitas = MedicamentosDeCitasServicio.SeleccionarTodosPorIdCita(IdCita);

            List<MedicamentosDeCitasDto> ListaTodosLosMedicamentosDeCitasDto = new();

            foreach (var MedicamentosDeCitasseleccionado in ListaTodosLosMedicamentosDeCitas)
            {
                MedicamentosDeCitasDto MedicamentosDeCitasDTO = new();

                MedicamentosDeCitasDTO.IdMedicamento = MedicamentosDeCitasseleccionado.IdMedicamento;
                MedicamentosDeCitasDTO.IdCita = MedicamentosDeCitasseleccionado.IdCita;
                MedicamentosDeCitasDTO.PrecioMedicamento = MedicamentosDeCitasseleccionado.PrecioMedicamento;
                MedicamentosDeCitasDTO.Activo = MedicamentosDeCitasseleccionado.Activo;

                ListaTodosLosMedicamentosDeCitasDto.Add(MedicamentosDeCitasDTO);
            }

            return ListaTodosLosMedicamentosDeCitasDto;
        }

        // POST api/<MedicamentosDeCitasController>
        [HttpPost]
        public IActionResult Post([FromBody] MedicamentosDeCitasDto MedicamentosDeCitasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            MedicamentosDeCitas MedicamentosDeCitasPorInsertar = new();

            MedicamentosDeCitasPorInsertar.IdMedicamento = MedicamentosDeCitasDTO.IdMedicamento;
            MedicamentosDeCitasPorInsertar.IdCita = MedicamentosDeCitasDTO.IdCita;
            MedicamentosDeCitasPorInsertar.PrecioMedicamento = MedicamentosDeCitasDTO.PrecioMedicamento;

            MedicamentosDeCitasPorInsertar.CreadoPor = "lackwoodsj";

            MedicamentosDeCitasServicio.Insertar(MedicamentosDeCitasPorInsertar);

            return Ok();
        }

        // PUT api/<MedicamentosDeCitasController>/5/3
       /* [HttpPut("{IdMedicamento}/{IdCita}")]
        public IActionResult Put(int IdMedicamento, int IdCita, [FromBody] MedicamentosDeCitasDto MedicamentosDeCitasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            MedicamentosDeCitas MedicamentosDeCitasseleccionado = new();

            MedicamentosDeCitasseleccionado = MedicamentosDeCitasServicio.SeleccionarPorIdMultiple(IdMedicamento, IdCita);

            if (MedicamentosDeCitasseleccionado.IdMedicamento is 0 && MedicamentosDeCitasseleccionado.IdCita is 0)
            {
                return NotFound("Medicamento no encontrado");
            }

            MedicamentosDeCitas MedicamentosDeCitasPorActualizar = new();

            MedicamentosDeCitasPorActualizar.IdMedicamento = MedicamentosDeCitasDTO.IdMedicamento;
            MedicamentosDeCitasPorActualizar.IdCita = MedicamentosDeCitasDTO.IdCita;
            MedicamentosDeCitasPorActualizar.PrecioMedicamento = MedicamentosDeCitasDTO.PrecioMedicamento;
            MedicamentosDeCitasPorActualizar.Activo = MedicamentosDeCitasDTO.Activo;

            MedicamentosDeCitasPorActualizar.FechaModificacion = System.DateTime.Now;
            MedicamentosDeCitasPorActualizar.ModificadoPor = "Lackwoodsj";

            MedicamentosDeCitasServicio.Actualizar(MedicamentosDeCitasPorActualizar);

            return Ok();
        }*/

        // DELETE api/<MedicamentosDeCitaController>/5
        [HttpDelete("{IdMedicamento}/{IdCita}")]
        public IActionResult Delete(int IdMedicamento, int IdCita)
        {
            MedicamentosDeCitas MedicamentosDeCitasseleccionado = new();

            MedicamentosDeCitasseleccionado = MedicamentosDeCitasServicio.SeleccionarPorIdMultiple(IdMedicamento, IdCita);

            if (MedicamentosDeCitasseleccionado.IdMedicamento is 0)
            {
                return NotFound("Paciente no encontrado");
            }

            MedicamentosDeCitasseleccionado.Activo = false; //Esto realiza el eliminado lógico

            MedicamentosDeCitasServicio.Actualizar(MedicamentosDeCitasseleccionado);

            return Ok("Registro eliminado");
        }
    }
}
