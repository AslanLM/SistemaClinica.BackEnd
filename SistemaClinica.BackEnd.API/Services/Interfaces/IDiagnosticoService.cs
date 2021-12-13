using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IDiagnosticoService
    {
        List<Diagnosticos> SeleccionarTodos();
        Diagnosticos SeleccionarPorId(int id);
        void Insertar(Diagnosticos model);
        void Actualizar(Diagnosticos model);
        void Eliminar(int id);
    }
}

