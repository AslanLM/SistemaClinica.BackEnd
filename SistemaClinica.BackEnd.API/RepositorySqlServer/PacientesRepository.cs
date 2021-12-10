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
            var query = "SP_Pacientes_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaPaciente", paciente.CedulaPaciente);
            command.Parameters.AddWithValue("@NombrePaciente", paciente.NombrePaciente);
            command.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
            command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            command.Parameters.AddWithValue("@Edad", paciente.Edad);
            command.Parameters.AddWithValue("@ModificadoPor", paciente.ModificadoPor);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Pacientes paciente)
        {

            var query = "SP_Pacientes_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaPaciente", paciente.CedulaPaciente);
            command.Parameters.AddWithValue("@NombrePaciente", paciente.NombrePaciente);
            command.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
            command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
            command.Parameters.AddWithValue("@Edad", paciente.Edad);
            command.Parameters.AddWithValue("@CreadoPor", paciente.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Pacientes SeleccionarPorId(String CedulaPaciente)
        {
            var query = "SELECT * FROM vwPaciente_SeleccionarTodos WHERE CedulaPaciente = @CedulaPaciente";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaPaciente", CedulaPaciente);

            SqlDataReader reader = command.ExecuteReader();

            Pacientes PacientesSeleccionado = new();

            while (reader.Read())
            {
                PacientesSeleccionado.CedulaPaciente = Convert.ToString(reader["CedulaPaciente"]);
                PacientesSeleccionado.NombrePaciente = Convert.ToString(reader["NombrePaciente"]);
                PacientesSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                PacientesSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                PacientesSeleccionado.Edad = Convert.ToInt32(reader["Edad"]);
                PacientesSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                PacientesSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                PacientesSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                PacientesSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                PacientesSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return PacientesSeleccionado;
        }

        public List<Pacientes> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwPaciente_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Pacientes> ListaTodosLosPacientes = new List<Pacientes>();

            while (reader.Read())
            {
                Pacientes PacientesSeleccionado = new();

                PacientesSeleccionado.CedulaPaciente = Convert.ToString(reader["CedulaPaciente"]);
                PacientesSeleccionado.NombrePaciente = Convert.ToString(reader["NombrePaciente"]);
                PacientesSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                PacientesSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                PacientesSeleccionado.Edad = Convert.ToInt32(reader["Edad"]);
                PacientesSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                PacientesSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                PacientesSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                PacientesSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                PacientesSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosPacientes.Add(PacientesSeleccionado);
            }

            reader.Close();

            return ListaTodosLosPacientes;
        }
    }
}

