﻿using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.Repository;
using SistemaClinica.BackEnd.API.UnitOfWork.Interfaces;

using System.Data.SqlClient;
using SistemaClinica.BackEnd.API.RepositorySqlServer;

namespace SistemaClinica.BackEnd.API.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IDoctoresRepository DoctorRepository { get; }
        public IPacientesRepository PacientesRepository { get; }
        public IClinicaRepository ClinicaRepository { get; }
        public IConsultorioRepository ConsultorioRepository { get; }
        public IMedicamentosRepository MedicamentosRepository { get; }
        public ICitasRepository CitasRepository { get; }
        //Acá van todos los otros repositorios
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            DoctorRepository = new DoctoresRepository(context, transaction);
            PacientesRepository = new PacientesRepository(context, transaction);
            ClinicaRepository = new ClinicaRepository(context, transaction);
            ConsultorioRepository = new ConsultorioRepository(context, transaction);
            MedicamentosRepository = new MedicamentosRepository(context, transaction);
            CitasRepository = new CitasRepository(context, transaction);



            //Acá van todos los otros repositorios

        }

    }
}
