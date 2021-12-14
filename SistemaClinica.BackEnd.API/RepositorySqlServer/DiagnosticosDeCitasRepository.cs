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
    public class DiagnosticosDeCitasRepository : ConexionBD, IDiagnosticosDeCitasRepository
    {
        public DiagnosticosDeCitasRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(DiagnosticosDeCitas diagnosticosDeCitas)
        {
            var query = "SP_DiagnosticosDeCitas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdDiagnostico", diagnosticosDeCitas.IdDiagnostico);
            command.Parameters.AddWithValue("@IdCita", diagnosticosDeCitas.IdCita);
            command.Parameters.AddWithValue("@Activo", diagnosticosDeCitas.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", diagnosticosDeCitas.ModificadoPor);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(DiagnosticosDeCitas diagnosticosDeCitas)
        {

            var query = "SP_DiagnosticosDeCitas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdDiagnostico", diagnosticosDeCitas.IdDiagnostico);
            command.Parameters.AddWithValue("@IdCita", diagnosticosDeCitas.IdCita);
            command.Parameters.AddWithValue("@CreadoPor",  diagnosticosDeCitas.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public DiagnosticosDeCitas SeleccionarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public DiagnosticosDeCitas SeleccionarPorIdMultiple(int IdDiagnostico, int IdCita)
        {
            var query = "SELECT * FROM vwDiagnosticosDeCitas_SeleccionarTodos WHERE IdDiagnostico = @IdDiagnostico AND IdCita = @IdCita";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdDiagnostico", IdDiagnostico);
            command.Parameters.AddWithValue("@IdCita", IdCita);

            SqlDataReader reader = command.ExecuteReader();

            DiagnosticosDeCitas DiagnosticosDeCitasSeleccionado = new();

            while (reader.Read())
            {
                DiagnosticosDeCitasSeleccionado.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                DiagnosticosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                DiagnosticosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DiagnosticosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DiagnosticosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DiagnosticosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DiagnosticosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return DiagnosticosDeCitasSeleccionado;

        }

        public List<DiagnosticosDeCitas> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwDiagnosticosDeCitas_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas = new List<DiagnosticosDeCitas>();

            while (reader.Read())
            {
                DiagnosticosDeCitas DiagnosticosDeCitasSeleccionado = new();

                DiagnosticosDeCitasSeleccionado.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                DiagnosticosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                DiagnosticosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DiagnosticosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DiagnosticosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DiagnosticosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DiagnosticosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);


                ListaTodosLosDiagnosticosDeCitas.Add(DiagnosticosDeCitasSeleccionado);
            }

            reader.Close();

            return ListaTodosLosDiagnosticosDeCitas;
        }

        public List<DiagnosticosDeCitas> SeleccionarTodosPorIdCita(int IdCita)
        {
            var query = "SELECT * FROM vwDiagnosticosDeCitas_SeleccionarTodos WHERE IdCita = @IdCita ";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdCita", IdCita);


            SqlDataReader reader = command.ExecuteReader();

            List<DiagnosticosDeCitas> ListaTodosLosDiagnosticosDeCitas = new List<DiagnosticosDeCitas>();

            while (reader.Read())
            {
                DiagnosticosDeCitas DiagnosticosDeCitasSeleccionado = new();

                DiagnosticosDeCitasSeleccionado.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                DiagnosticosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                DiagnosticosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DiagnosticosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DiagnosticosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DiagnosticosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DiagnosticosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosDiagnosticosDeCitas.Add(DiagnosticosDeCitasSeleccionado);
            }

            reader.Close();

            return ListaTodosLosDiagnosticosDeCitas;
        }
    }
}
