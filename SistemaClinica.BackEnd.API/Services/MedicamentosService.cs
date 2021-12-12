using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class MedicamentosService : IMedicamentosService
    {
        private IUnitOfWork BD;
        public MedicamentosService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Medicamentos model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MedicamentosRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Medicamentos model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MedicamentosRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Medicamentos SeleccionarPorId(string id)
        {
            Medicamentos MedicamentosSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                MedicamentosSeleccionado = bd.Repositories.MedicamentosRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return MedicamentosSeleccionado;
        }

        public List<Medicamentos> SeleccionarTodos()
        {
            List<Medicamentos> ListaTodosLosMedicamentos;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosMedicamentos = bd.Repositories.MedicamentosRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosMedicamentos;
        }
    }
}

