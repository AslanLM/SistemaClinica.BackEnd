using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{ 
    public interface IMedicamentosDeCitasRepository : IObtenerRepository<MedicamentosDeCitas, int>, IInsertarRepository<MedicamentosDeCitas>, IActualizarRepository<MedicamentosDeCitas>, IEliminarRepository<int>
    {
        MedicamentosDeCitas SeleccionarPorIdMultiple(int IdMedicamento, int IdCita);

        List<MedicamentosDeCitas> SeleccionarTodosPorIdCita(int IdCita);



    }
}