using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IDoctorService
    {
        List<Doctores> SeleccionarTodos();
        Doctores SeleccionarPorId(string id);
        void Insertar(Doctores model);
        void Actualizar(Doctores model);
        void Eliminar(int id);
    }
}
