using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class PacientesService : IPacientesService
    {
        private IUnitOfWork BD;
        public PacientesService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Pacientes model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.PacientesRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Pacientes model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DoctorRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Pacientes SeleccionarPorId(string id)
        {
            Pacientes PacienteSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                PacienteSeleccionado = bd.Repositories.PacientesRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return PacienteSeleccionado;
        }

        public IEnumerable<Doctores> SeleccionarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
