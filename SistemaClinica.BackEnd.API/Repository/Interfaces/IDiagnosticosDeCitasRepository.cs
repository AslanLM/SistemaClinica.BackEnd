using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IDiagnosticosDeCitasRepository : IObtenerRepository<DiagnosticosDeCitas, int>, IInsertarRepository<DiagnosticosDeCitas>, IActualizarRepository<DiagnosticosDeCitas>, IEliminarRepository<int>
    {
        DiagnosticosDeCitas SeleccionarPorIdMultiple(int Diagnostico, int IdCita);

        List<DiagnosticosDeCitas> SeleccionarTodosPorIdCita(int IdCita);
    }
}
