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
    public class ConsultorioRepository : ConexionBD, IConsultorioRepository
    { 
        public ConsultorioRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Consultorios consultorios)
        {
            var query = "SP_Doctores_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdConsultorio", consultorios.IdConsultorio);
            command.Parameters.AddWithValue("@NombreConsultorio", consultorios.NombreConsultorio);
            command.Parameters.AddWithValue("@IdClinica", consultorios.IdClinica);
            command.Parameters.AddWithValue("@ModificadoPor", consultorios.ModificadoPor);


            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Consultorios consultorios)
        {

            var query = "SP_Consultorios_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdConsultorio", consultorios.IdConsultorio);
            command.Parameters.AddWithValue("@NombreConsultorio", consultorios.NombreConsultorio);
            command.Parameters.AddWithValue("@IdClinica", consultorios.IdClinica);
            command.Parameters.AddWithValue("@CreadoPor", consultorios.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Consultorios SeleccionarPorId(String IdConsultorio)
        {
            var query = "SELECT * FROM vwConsultorios_SeleccionarTodos WHERE IdConsultorio = @IdConsultorio";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdConsultorio", IdConsultorio);

            SqlDataReader reader = command.ExecuteReader();

            Consultorios ConsultorioSeleccionado = new();

            while (reader.Read())
            {
                ConsultorioSeleccionado.IdConsultorio = Convert.ToString(reader["IdConsultorio"]);
                ConsultorioSeleccionado.NombreConsultorio = Convert.ToString(reader["NombreConsultorio"]);
                ConsultorioSeleccionado.IdClinica = Convert.ToInt32(reader["IdClinica"]);
                ConsultorioSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                ConsultorioSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ConsultorioSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ConsultorioSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ConsultorioSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return ConsultorioSeleccionado;
        }

        public List<Consultorios> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwConsultorio_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Consultorios> ListaTodosLosConsultorios = new List<Consultorios>();

            while (reader.Read())
            {
                Consultorios ConsultorioSeleccionado = new();

                ConsultorioSeleccionado.IdConsultorio = Convert.ToString(reader["IdConsultorio"]);
                ConsultorioSeleccionado.NombreConsultorio = Convert.ToString(reader["NombreConsultorio"]);
                ConsultorioSeleccionado.IdClinica = Convert.ToInt32(reader["IdClinica"]);
                ConsultorioSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                ConsultorioSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                ConsultorioSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                ConsultorioSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                ConsultorioSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);


                ListaTodosLosConsultorios.Add(ConsultorioSeleccionado);
            }

            reader.Close();

            return ListaTodosLosConsultorios;
        }
    }
}
