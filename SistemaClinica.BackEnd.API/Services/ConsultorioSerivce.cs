using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class ConsultorioSerivce : IConsultorioService
    {
        private IUnitOfWork BD;
        public ConsultorioSerivce(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Consultorios model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ConsultorioRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Consultorios model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ConsultorioRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Consultorios SeleccionarPorId(string id)
        {
            Consultorios ConsultorioSeleccionado = new();

            using (var bd = BD.Conectar())
            {
                ConsultorioSeleccionado = bd.Repositories.ConsultorioRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return ConsultorioSeleccionado;
        }

        public List<Consultorios> SeleccionarTodos()
        {
            List<Consultorios> ListaTodosLosConsultorios;

            using (var bd = BD.Conectar())
            {
                ListaTodosLosConsultorios = bd.Repositories.ConsultorioRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodosLosConsultorios;

        }
    }
}
