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
    public class ClinicaRepository : ConexionBD, IClinicaRepository
    {
        public ClinicaRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Clinicas clinica)
        {
            var query = "SP_Clinicas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdClinica", clinica.IdClinica);
            command.Parameters.AddWithValue("@NombreClinica", clinica.NombreClinica);
            command.Parameters.AddWithValue("@CedulaJuridica", clinica.CedulaJuridica);
            command.Parameters.AddWithValue("@ModificadoPor", clinica.ModificadoPor);


            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Clinicas clinica)
        {

            var query = "SP_Clinicas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdClinica", clinica.IdClinica);
            command.Parameters.AddWithValue("@NombreClinica", clinica.NombreClinica);
            command.Parameters.AddWithValue("@CedulaJuridica", clinica.CedulaJuridica);
            command.Parameters.AddWithValue("@CreadoPor", clinica.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Clinicas SeleccionarPorId(int IdClinica)
        {
            var query = "SELECT * FROM vwClinicas_SeleccionarTodo WHERE IdClinica = @IdClinica";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdClinica", IdClinica);

            SqlDataReader reader = command.ExecuteReader();

            Clinicas ClinicaSeleccionada = new();

            while (reader.Read())
            {
                ClinicaSeleccionada.IdClinica = Convert.ToInt32(reader["IdClinica"]);
                ClinicaSeleccionada.NombreClinica = Convert.ToString(reader["NombreClinica"]);
                ClinicaSeleccionada.CedulaJuridica = Convert.ToString(reader["CedulaJuridica"]);
                ClinicaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                ClinicaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ClinicaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ClinicaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ClinicaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return ClinicaSeleccionada;
        }

        public List<Clinicas> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwClinicas_SeleccionarTodo";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Clinicas> ListaTodasLasClinicas = new List<Clinicas>();

            while (reader.Read())
            {
                Clinicas ClinicaSeleccionada = new();

                ClinicaSeleccionada.IdClinica = Convert.ToInt32(reader["IdClinica"]);
                ClinicaSeleccionada.NombreClinica = Convert.ToString(reader["NombreClinica"]);
                ClinicaSeleccionada.CedulaJuridica = Convert.ToString(reader["CedulaJuridica"]);
                ClinicaSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                ClinicaSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ClinicaSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ClinicaSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ClinicaSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodasLasClinicas.Add(ClinicaSeleccionada);
            }

            reader.Close();

            return ListaTodasLasClinicas;
        }
    }
}
