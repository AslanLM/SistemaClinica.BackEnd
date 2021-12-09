using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.Repository;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

using System.Data.SqlClient;

namespace SistemaClinica.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IDoctoresRepository DoctorRepository { get; }
        public IPacientesRepository PacientesRepository { get; }
        //Acá van todos los otros repositorios
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            DoctorRepository = new DoctoresRepository(context, transaction);
            PacientesRepository = new PacientesRepository(context, transaction);
            //Acá van todos los otros repositorios

        }

    }
}
