using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface ICitasRepository : IObtenerRepository<Citas, int>, IInsertarRepository<Citas>, IActualizarRepository<Citas>, IEliminarRepository<int>
    {
    }
}
