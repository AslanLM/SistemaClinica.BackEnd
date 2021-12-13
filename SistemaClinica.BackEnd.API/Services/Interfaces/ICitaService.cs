using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface ICitaService
    {
        List<Citas> SeleccionarTodos();
        Citas SeleccionarPorId(int id);
        void Insertar(Citas model);
        void Actualizar(Citas model);
        void Eliminar(int id);
    }
}
