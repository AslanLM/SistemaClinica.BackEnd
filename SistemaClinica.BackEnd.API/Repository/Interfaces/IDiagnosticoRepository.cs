using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
   public interface IDiagnosticoRepository : IObtenerRepository<Diagnosticos, int>, IInsertarRepository<Diagnosticos>, IActualizarRepository<Diagnosticos>, IEliminarRepository<int>
    {
    }
}
