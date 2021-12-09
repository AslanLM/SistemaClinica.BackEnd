using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IPacientesRepository : IObtenerRepository<Pacientes, string>, IInsertarRepository<Pacientes>, IActualizarRepository<Pacientes>, IEliminarRepository<int>
    {
    }
}
