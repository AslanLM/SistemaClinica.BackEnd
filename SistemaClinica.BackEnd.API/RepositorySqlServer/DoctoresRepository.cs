using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Repository
{
    public class DoctoresRepository : ConexionBD, IDoctoresRepository
    {
        public DoctoresRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Doctores doctor)
        {
            var query = "UPDATE Aula SET NombreDoctor = @NombreDoctor, Apellido  = @Apellido, Telefono = @Telefono, FechaModificacion = @FechaModificacion, ModificadoPor = @ModificadoPor WHERE CedulaDoctor = @Doctor";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NombreDoctor", doctor.NombreDoctor);
            command.Parameters.AddWithValue("@Apellido", doctor.Apellido);
            command.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            command.Parameters.AddWithValue("@FechaModificacion", doctor.FechaModificacion);
            command.Parameters.AddWithValue("@ModificadoPor", doctor.ModificadoPor);
            command.Parameters.AddWithValue("@CedulaDoctor", doctor.CedulaDoctor);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Doctores doctor)
        {

            var query = "SP_Doctores_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaDoctor", doctor.CedulaDoctor);
            command.Parameters.AddWithValue("@NombreDoctor", doctor.NombreDoctor);
            command.Parameters.AddWithValue("@Apellido", doctor.Apellido);
            command.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            command.Parameters.AddWithValue("@CreadoPor", doctor.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Doctores SeleccionarPorId(String CedulaDoctor)
        {
            var query = "SELECT * FROM vw_Aula_SeleccionarActivos WHERE NumeroAula = @CedulaDoctor";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaDoctor", CedulaDoctor);

            SqlDataReader reader = command.ExecuteReader();

            Doctores DoctorSeleccionado = new();

            while (reader.Read())
            {
                DoctorSeleccionado.CedulaDoctor = Convert.ToString(reader["CedulaDoctor"]);
                DoctorSeleccionado.NombreDoctor = Convert.ToString(reader["NombreDoctor"]);
                DoctorSeleccionado.Apellido = Convert.ToString(reader["Apellido"]);
                DoctorSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                DoctorSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DoctorSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DoctorSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DoctorSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DoctorSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return DoctorSeleccionado;
        }

        public IEnumerable<Doctores> SeleccionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
