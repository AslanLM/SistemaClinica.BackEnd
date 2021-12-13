using SistemaClinica.BackEnd.API.Repository.Interfaces.Actions;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces
{
    public interface IMedicamentosRepository : IObtenerRepository<Medicamentos, int>, IInsertarRepository<Medicamentos>, IActualizarRepository<Medicamentos>, IEliminarRepository<int>
    {
    }
}