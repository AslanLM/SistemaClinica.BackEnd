using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IMedicamentosService
    {
        List<Medicamentos> SeleccionarTodos();
        Medicamentos SeleccionarPorId(string id);
        void Insertar(Medicamentos model);
        void Actualizar(Medicamentos model);
        void Eliminar(int id);
    }
}
