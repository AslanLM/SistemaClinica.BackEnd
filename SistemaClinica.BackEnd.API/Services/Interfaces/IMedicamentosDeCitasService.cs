using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IMedicamentosDeCitasService
    {
        List<MedicamentosDeCitas> SeleccionarTodos();

        List<MedicamentosDeCitas> SeleccionarTodosPorIdCita(int IdCita);

        MedicamentosDeCitas SeleccionarPorIdMultiple(int IdMedicamento, int IdCita);
        void Insertar(MedicamentosDeCitas model);
        void Actualizar(MedicamentosDeCitas model);
        void Eliminar(int id);
    }
}
