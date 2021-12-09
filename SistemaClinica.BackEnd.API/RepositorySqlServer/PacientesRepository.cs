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
    public class PacientesRepository : ConexionBD, IPacientesRepository
    {
        public PacientesRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Pacientes paciente)
        {
            var query = "UPDATE Aula SET NombrePaciente = @NombrePaciente, Apellido  = @Apellido, Telefono = @Telefono, Edad = @Edad, FechaModificacion = @FechaModificacion, ModificadoPor = @ModificadoPor WHERE CedulaPaciente = @Paciente";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@NombrePaciente", paciente.NombrePaciente);
            command.Parameters.AddWithValue("@Apellido", paciente.Apellidos);
            command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            command.Parameters.AddWithValue("@Telefono", paciente.Edad);
            command.Parameters.AddWithValue("@FechaModificacion", paciente.FechaModificacion);
            command.Parameters.AddWithValue("@ModificadoPor", paciente.ModificadoPor);
            command.Parameters.AddWithValue("@CedulaDoctor", paciente.CedulaPaciente);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Pacientes paciente)
        {

            var query = "SP_Doctores_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaPaciente", paciente.CedulaPaciente);
            command.Parameters.AddWithValue("@NombreDoctor", paciente.NombrePaciente);
            command.Parameters.AddWithValue("@Apellido", paciente.Apellidos);
            command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            command.Parameters.AddWithValue("@Telefono", paciente.Edad);
            command.Parameters.AddWithValue("@CreadoPor", paciente.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Pacientes SeleccionarPorId(String CedulaPaciente)
        {
            var query = "SELECT * FROM vw_Aula_SeleccionarActivos WHERE NumeroAula = @CedulaDoctor";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaPaciente", CedulaPaciente);

            SqlDataReader reader = command.ExecuteReader();

            Pacientes PacienteSeleccionado = new();

            while (reader.Read())
            {
                PacienteSeleccionado.CedulaPaciente = Convert.ToString(reader["CedulaPaciente"]);
                PacienteSeleccionado.NombrePaciente = Convert.ToString(reader["NombrePaciente"]);
                PacienteSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                PacienteSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                PacienteSeleccionado.Edad = Convert.ToString(reader["Edad"]);
                PacienteSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                PacienteSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                PacienteSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                PacienteSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                PacienteSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return PacienteSeleccionado;
        }

        public IEnumerable<Pacientes> SeleccionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
