using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IClinicaService
    {
        List<Clinicas> SeleccionarTodos();
        Clinicas SeleccionarPorId(int id);
        void Insertar(Clinicas model);
        void Actualizar(Clinicas model);
        void Eliminar(int id);
    }
}

