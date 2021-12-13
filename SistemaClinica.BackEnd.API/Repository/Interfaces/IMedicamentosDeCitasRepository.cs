using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{ 
    public interface IMedicamentosDeCitasRepository : IObtenerRepository<MedicamentosDeCitas, int>, IInsertarRepository<MedicamentosDeCitas>, IActualizarRepository<MedicamentosDeCitas>, IEliminarRepository<int>
    {
    }
}