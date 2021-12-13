using System.Collections.Generic;
using SistemaClinica.BackEnd.API.Models;

namespace SistemaClinica.BackEnd.API.Services.Interfaces
{
    public interface IMedicamentosDeCitasService
    {
        List<MedicamentosDeCitas> SeleccionarTodos();
        MedicamentosDeCitas SeleccionarPorId(int id);
        void Insertar(MedicamentosDeCitas model);
        void Actualizar(MedicamentosDeCitas model);
        void Eliminar(int id);
    }
}
