using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IDoctoresRepository : IObtenerRepository<Doctores, string>, IInsertarRepository<Doctores>, IActualizarRepository<Doctores>, IEliminarRepository<int>
    {
    }
}
