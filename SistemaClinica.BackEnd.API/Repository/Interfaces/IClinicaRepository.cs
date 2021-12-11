using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IClinicaRepository : IObtenerRepository<Clinicas, int>, IInsertarRepository<Clinicas>, IActualizarRepository<Clinicas>, IEliminarRepository<int>
    {
    }
}
