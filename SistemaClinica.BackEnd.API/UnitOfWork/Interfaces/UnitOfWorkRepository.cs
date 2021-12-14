
using SistemaClinica.BackEnd.API.Repository.Interfaces;

namespace SistemaClinica.BackEnd.API.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository 
    {
        IDoctoresRepository DoctorRepository { get; }
        IPacientesRepository PacientesRepository { get; }
        IClinicaRepository ClinicaRepository { get; }
        IConsultorioRepository ConsultorioRepository { get; }
        IMedicamentosRepository MedicamentosRepository { get; }
        IMedicamentosDeCitasRepository MedicamentosDeCitasRepository { get; }
        ICitasRepository CitasRepository { get; }
        IDiagnosticoRepository DiagnosticoRepository { get; }
        IDiagnosticosDeCitasRepository DiagnosticosDeCitasRepository { get; }

    }
}
