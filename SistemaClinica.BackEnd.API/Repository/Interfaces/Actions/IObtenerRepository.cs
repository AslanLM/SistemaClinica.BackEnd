using System.Collections.Generic;

namespace SistemaClinica.BackEnd.API.Repository.Interfaces.Actions
{
    public interface IObtenerRepository<T, Y> where T : class
    {
        IEnumerable<T> SeleccionarTodos();
        T SeleccionarPorId(Y id);
    }
}
