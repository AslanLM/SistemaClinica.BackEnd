using SistemaClinica.BackEnd.API.Services.Interfaces;
using SistemaClinica.BackEnd.API.Models;
using System.Collections.Generic;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

namespace SistemaClinica.BackEnd.API.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private IUnitOfWork BD;
        public DiagnosticoService(IUnitOfWork unitOfWork)
        {
            BD = unitOfWork;
        }
        public void Actualizar(Diagnosticos model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DiagnosticoRepository.Actualizar(model);

                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insertar(Diagnosticos model)
        {
            using (var bd = BD.Conectar())
            {
                bd.Repositories.DiagnosticoRepository.Insertar(model);

                bd.SaveChanges();
            }
        }

        public Diagnosticos SeleccionarPorId(int id)
        {
            Diagnosticos DiagnosticoSeleccionada = new();

            using (var bd = BD.Conectar())
            {
                DiagnosticoSeleccionada = bd.Repositories.DiagnosticoRepository.SeleccionarPorId(id);

                bd.SaveChanges();
            }

            return DiagnosticoSeleccionada;
        }

        public List<Diagnosticos> SeleccionarTodos()
        {
            List<Diagnosticos> ListaTodasLosDiagnosticos;

            using (var bd = BD.Conectar())
            {
                ListaTodasLosDiagnosticos = bd.Repositories.DiagnosticoRepository.SeleccionarTodos();

                bd.SaveChanges();
            }

            return ListaTodasLosDiagnosticos;

        }
    }
}
