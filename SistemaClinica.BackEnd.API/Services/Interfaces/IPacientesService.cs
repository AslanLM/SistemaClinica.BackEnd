using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IPacientesService
    {
        List<Pacientes> SeleccionarTodos();
        Pacientes SeleccionarPorId(string id);
        void Insertar(Pacientes model);
        void Actualizar(Pacientes model);
        void Eliminar(int id);
    }
}
