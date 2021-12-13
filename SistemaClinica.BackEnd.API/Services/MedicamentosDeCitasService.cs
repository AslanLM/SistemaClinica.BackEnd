using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class MedicamentosDeCitasService : IMedicamentosDeCitasService
    {
        private IUnitOfWork BD;
        public MedicamentosDeCitasService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(MedicamentosDeCitas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MedicamentosDeCitasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(MedicamentosDeCitas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.MedicamentosDeCitasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public MedicamentosDeCitas SeleccionarPorId(string id)
        {
            MedicamentosDeCitas MedicamentosDeCitasSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                MedicamentosDeCitasSeleccionado = bd.Repositories.MedicamentosDeCitasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return MedicamentosDeCitasSeleccionado;
        }

        public List<MedicamentosDeCitas> SeleccionarTodos()
        {
            List<MedicamentosDeCitas> ListaTodosLosMedicamentosDeCitas;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosMedicamentosDeCitas = bd.Repositories.MedicamentosDeCitasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosMedicamentosDeCitas;
        }
    }
}
