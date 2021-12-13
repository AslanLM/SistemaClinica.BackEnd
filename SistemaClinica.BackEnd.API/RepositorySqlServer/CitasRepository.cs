using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.RepositorySqlServer
{
    public class CitasRepository : ConexionBD, ICitasRepository
    {
        public CitasRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Citas citas)
        {
            var query = "SP_Citas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdCita", citas.IdCita);
            command.Parameters.AddWithValue("@FechaYHoraInicioCita", citas.FechaYHoraInicioCita);
            command.Parameters.AddWithValue("@FechaYHoraInicioCita", citas.FechaYHoraFinCita);
            command.Parameters.AddWithValue("@CedulaDoctor", citas.CedulaDoctor);
            command.Parameters.AddWithValue("@CedulaPaciente", citas.CedulaPaciente);
            command.Parameters.AddWithValue("@IdConsultorio", citas.IdConsultorio);
            command.Parameters.AddWithValue("@IdDiagnostico", citas.IdDiagnostico);
            command.Parameters.AddWithValue("@MontoDeConsulta", citas.MontoDeConsulta);
            command.Parameters.AddWithValue("@Activo", citas.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", citas.ModificadoPor);


            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Citas citas)
        {

            var query = "SP_Citas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //command.Parameters.AddWithValue("@IdClinica", clinica.IdClinica);
            command.Parameters.AddWithValue("@FechaYHoraInicioCita", citas.FechaYHoraInicioCita);
            command.Parameters.AddWithValue("@FechaYHoraFinCita", citas.FechaYHoraFinCita);
            command.Parameters.AddWithValue("@CedulaDoctor", citas.CedulaDoctor);
            command.Parameters.AddWithValue("@CedulaPaciente", citas.CedulaPaciente);
            command.Parameters.AddWithValue("@IdConsultorio", citas.IdConsultorio);
            command.Parameters.AddWithValue("@IdDiagnostico", citas.IdDiagnostico);
            command.Parameters.AddWithValue("@MontoDeConsulta", citas.MontoDeConsulta);

            command.Parameters.AddWithValue("@CreadoPor", citas.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Citas SeleccionarPorId(int IdCita)
        {
            var query = "SELECT * FROM vwCitas_SeleccionarTodos WHERE IdCita = @IdCita";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdCita", IdCita);

            SqlDataReader reader = command.ExecuteReader();

            Citas CitaSeleccionada = new();

            while (reader.Read())
            {
                CitaSeleccionada.IdCita = Convert.ToInt32(reader["IdCita"]);
                CitaSeleccionada.FechaYHoraInicioCita = Convert.ToDateTime(reader["FechaYHoraInicioCita"]);
                CitaSeleccionada.FechaYHoraInicioCita = Convert.ToDateTime(reader["FechaYHoraInicioCita"]);
                CitaSeleccionada.CedulaDoctor = Convert.ToString(reader["CedulaDoctor"]);
                CitaSeleccionada.CedulaPaciente = Convert.ToString(reader["CedulaPaciente"]);
                CitaSeleccionada.IdConsultorio = Convert.ToString(reader["IdConsultorio"]);
                CitaSeleccionada.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                CitaSeleccionada.MontoDeConsulta = Convert.ToDecimal(reader["MontoDeConsulta"]);
                CitaSeleccionada.MontoDeMedicamentos = Convert.ToDecimal(reader["MontoDeMedicamentos"]);
                CitaSeleccionada.MontoTotal = Convert.ToDecimal(reader["MontoTotal"]);
                CitaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CitaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CitaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CitaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CitaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return CitaSeleccionada;
        }

        public List<Citas> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwCitas_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Citas> ListaTodasLasCitas = new List<Citas>();

            while (reader.Read())
            {
                Citas CitaSeleccionada = new();

                CitaSeleccionada.IdCita = Convert.ToInt32(reader["IdCita"]);
                CitaSeleccionada.FechaYHoraInicioCita = Convert.ToDateTime(reader["FechaYHoraInicioCita"]);
                CitaSeleccionada.FechaYHoraInicioCita = Convert.ToDateTime(reader["FechaYHoraInicioCita"]);
                CitaSeleccionada.CedulaDoctor = Convert.ToString(reader["CedulaDoctor"]);
                CitaSeleccionada.CedulaPaciente = Convert.ToString(reader["CedulaPaciente"]);
                CitaSeleccionada.IdConsultorio = Convert.ToString(reader["IdConsultorio"]);
                CitaSeleccionada.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                CitaSeleccionada.MontoDeConsulta = Convert.ToDecimal(reader["MontoDeConsulta"]);
                CitaSeleccionada.MontoDeMedicamentos = Convert.ToDecimal(reader["MontoDeMedicamentos"]); //(reader.IsDBNull("MontoDeMedicamentos")) ? 0 : Convert.ToDecimal(reader["MontoDeMedicamentos"]);
                CitaSeleccionada.MontoTotal = Convert.ToDecimal(reader["MontoTotal"]);
                CitaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                CitaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                CitaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                CitaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                CitaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasCitas.Add(CitaSeleccionada);
            }

            reader.Close();

            return ListaTodasLasCitas;
        }
    }
}
