using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IConsultorioService
    {
        List<Consultorios> SeleccionarTodos();
        Consultorios SeleccionarPorId(string id);
        void Insertar(Consultorios model);
        void Actualizar(Consultorios model);
        void Eliminar(int id);
    }
}
