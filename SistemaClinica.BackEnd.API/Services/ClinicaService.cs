using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class ClinicaService : IClinicaService
    {
        private IUnitOfWork BD;
        public ClinicaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Clinicas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ClinicaRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Clinicas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.ClinicaRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Clinicas SeleccionarPorId(int id)
        {
            Clinicas ClinicaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                ClinicaSeleccionada = bd.Repositories.ClinicaRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return ClinicaSeleccionada;
        }

        public List<Clinicas> SeleccionarTodos()
        {
            List<Clinicas> ListaTodasLasClinicas;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasClinicas = bd.Repositories.ClinicaRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasClinicas;

        }
    }
}
