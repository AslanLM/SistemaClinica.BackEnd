using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class CitaService : ICitaService
    {
        private IUnitOfWork BD;
        public CitaService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Citas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CitasRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Citas model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.CitasRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Citas SeleccionarPorId(int id)
        {
            Citas CitaSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                CitaSeleccionada = bd.Repositories.CitasRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return CitaSeleccionada;
        }

        public List<Citas> SeleccionarTodos()
        {
            List<Citas> ListaTodasLasCitas;

            using (var bd = BD.Conectar())
            {
                ListaTodasLasCitas = bd.Repositories.CitasRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLasCitas;

        }
    }
}
