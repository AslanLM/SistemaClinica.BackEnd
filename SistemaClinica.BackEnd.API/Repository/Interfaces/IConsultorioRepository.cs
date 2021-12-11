using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IConsultorioRepository : IObtenerRepository<Consultorios, string>, IInsertarRepository<Consultorios>, IActualizarRepository<Consultorios>, IEliminarRepository<int>
    {
    }
}
