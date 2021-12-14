using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IDiagnosticosDeCitasService
    {
        List<DiagnosticosDeCitas> SeleccionarTodos();

        List<DiagnosticosDeCitas> SeleccionarTodosPorIdCita(int IdCita);

        DiagnosticosDeCitas SeleccionarPorIdMultiple(int IdDiagnostico, int IdCita);
        void Insertar(DiagnosticosDeCitas model);
        void Actualizar(DiagnosticosDeCitas model);
        void Eliminar(int id);
    }
}
