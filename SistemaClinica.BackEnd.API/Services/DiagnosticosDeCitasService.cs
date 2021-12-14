using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class DiagnosticosDeCitasService : IDiagnosticosDeCitasService
    {
        private IUnitOfWork BD;
        public DiagnosticosDeCitasService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(DiagnosticosDeCitas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DiagnosticosDeCitasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(DiagnosticosDeCitas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DiagnosticosDeCitasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public DiagnosticosDeCitas SeleccionarPorIdMultiple(int IdDiagnostico, int IdCita)
        {
            DiagnosticosDeCitas DiagnosticosDeCitasSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                DiagnosticosDeCitasSeleccionado = bd.Repositories.DiagnosticosDeCitasRepository.SeleccionarPorIdMultiple(IdDiagnostico, IdCita);

                bd.SaveChanges();
            }

            return DiagnosticosDeCitasSeleccionado;
        }

        public List<DiagnosticosDeCitas> SeleccionarTodos()
        {
            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosDiagnosticosDeCitas = bd.Repositories.DiagnosticosDeCitasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosDiagnosticosDeCitas;
        }

        public List<DiagnosticosDeCitas> SeleccionarTodosPorIdCita(int IdCita)
        {
            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosDiagnosticosDeCitas = bd.Repositories.DiagnosticosDeCitasRepository.SeleccionarTodosPorIdCita(IdCita);

                bd.SaveChanges();
            }

            return ListaTodosLosDiagnosticosDeCitas;
        }
    }
}
