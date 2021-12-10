using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork BD;
        public DoctorService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Doctores model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DoctorRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Doctores model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DoctorRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Doctores SeleccionarPorId(string id)
        {
            Doctores DoctorSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                DoctorSeleccionado = bd.Repositories.DoctorRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return DoctorSeleccionado;
        }

        public List<Doctores> SeleccionarTodos()
        {
            List<Doctores> ListaTodosLosDoctores;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosDoctores = bd.Repositories.DoctorRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosDoctores;

        }
    }
}

